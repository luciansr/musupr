using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Musupr.Domain.Models;
using Musupr.Repository;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Text.RegularExpressions;
using Musupr.Service.Helpers;

namespace Musupr.Service
{
    public class AccountService
    {
        private IUnitOfWork _uow;
        private EmailService _emailService;

        public AccountService(IUnitOfWork uow, EmailService emailService)
        {
            _uow = uow;
            _emailService = emailService;
        }

        public ClaimsIdentity FindUser(OAuthGrantResourceOwnerCredentialsContext context)
        {
            UnitOfWork IdentityContext = new UnitOfWork();

            try
            {
                string username = context.UserName;
                string password = context.Password;

                Usuario usuario = IdentityContext.Usuarios.Get(u => u.UserID.ToLower() == username.ToLower() && u.Senha == password && !u.Bloqueado).FirstOrDefault();

                if (usuario != null)
                {
                    ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);

                    identity.AddClaim(new Claim("Nome", usuario.Nome));
                    identity.AddClaim(new Claim("ID", usuario.ID.ToString()));
                    identity.AddClaim(new Claim("Role", usuario.Roles.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Role, usuario.Roles.ToString()));

                    return identity;
                }

                return null;
            }
            finally
            {
                IdentityContext.Dispose();
            }
        }

        public bool PedirTrocarSenha(string userID)
        {
            Usuario usuario = _uow.Usuarios.Get(u => u.UserID == userID).FirstOrDefault();

            if (usuario != null)
            {
                string GUID = Guid.NewGuid().ToString();

                usuario.GuidTrocaSenha = GUID;
                _uow.Usuarios.Update(usuario);
                _uow.Save();

                return _emailService.EnviarEmailTrocarSenha(usuario.Email, usuario.Nome, usuario.UserID, GUID);
            }

            return false;
        }

        public bool TrocarSenha(string guid, string userID, string novaSenha)
        {
            Usuario usuario = _uow.Usuarios.Get(u => u.UserID == userID).FirstOrDefault();

            if (usuario == null || usuario.GuidTrocaSenha != guid)
            {
                return false;
            }

            usuario.Senha = novaSenha;
            _uow.Usuarios.Update(usuario);
            _uow.Save();

            return true;
        }

        public bool RegistrarUsuario(string Nome, string userID, string Email, string senha)
        {
            Usuario usuario = _uow.Usuarios.Get(u => 
                u.UserID.ToLower() == userID.ToLower() ||
                u.Email.ToLower() == Email.ToLower()).FirstOrDefault();

            if (Nome != HtmlRemoval.StripTagsRegex(Nome) ||
                Email != HtmlRemoval.StripTagsRegex(Email) ||
                userID != HtmlRemoval.StripTagsRegex(userID)) return false;

            if (usuario != null || userID.Length < 6 || Nome.Length < 2 || Email.Length < 5 || senha.Length < 6) return false;

            string patternEmail = @"^[a-z0-9!#$%&'*+/=?^_`{|}~.-]+@[a-z0-9-]+\.([a-z0-9])+(\.[a-z0-9]+)*";
            Regex rgx = new Regex(patternEmail, RegexOptions.IgnoreCase);

            if (!rgx.IsMatch(Email)) return false;

            Usuario novoUsuario = new Usuario()
            {
                Nome =  Nome,
                Email = Email,
                UserID = userID,
                Senha = senha,
                Roles = "user",
                DataCriacao = DateTime.Now
            };

            _uow.Usuarios.Insert(novoUsuario);
            _uow.Save();

            return true;
        }
    }
}
