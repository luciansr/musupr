using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Musupr.Domain.Models;
using Musupr.Repository;
using Musupr.Domain.DTModels;
using Musupr.Service.Helpers;

namespace Musupr.Service
{
    public class UsuarioService
    {
        private IUnitOfWork _uow;

        public UsuarioService(IUnitOfWork uow)
        {
            _uow = uow;

        }



        public UsuarioModel GetUsuarioModelByID(int id, int usuarioID, bool ehAdmin)
        {
            Usuario usuario = _uow.Usuarios.GetByID(id);

            Usuario usuarioRequisitante = _uow.Usuarios.GetByID(usuarioID);

            if (usuario != null)
            {
                UsuarioModel usuarioModel = new UsuarioModel(usuario);
                usuarioModel.PodeSerEditado = ehAdmin ||  (usuarioRequisitante != null && usuario.ID == usuarioRequisitante.ID);

                if (!usuarioModel.PodeSerEditado && usuarioModel.Bloqueado) return null;

                return usuarioModel;
            }

            return null;
        }

        public int EditaUsuario(UsuarioModel usuarioModel, int usuarioID, bool EhAdmin)
        {
            if (usuarioModel == null) return -1;

            Usuario usuarioAntigo = _uow.Usuarios.GetByID(usuarioModel.ID);

            if (usuarioAntigo == null) return -1;

            if (!EhAdmin && usuarioModel.ID != usuarioID) return -401;

            Usuario usuario = GetUsuarioFromUsuarioModel(usuarioModel);

            usuarioAntigo.Nome = usuario.Nome;
            usuarioAntigo.Descricao = usuario.Descricao;
            usuarioAntigo.DescricaoMarkdown = usuario.DescricaoMarkdown;

            usuarioAntigo.ProfileImageUrl = usuario.ProfileImageUrl;
            usuarioAntigo.HeaderImageUrl = usuario.HeaderImageUrl;

            _uow.Usuarios.Update(usuarioAntigo);
            _uow.Save();

            return usuarioAntigo.ID;

            throw new NotImplementedException();
        }

        private Usuario GetUsuarioFromUsuarioModel(UsuarioModel usuarioModel)
        {
            if (usuarioModel == null) return null;

            Usuario usuario = new Usuario();

            usuarioModel.Nome = HtmlRemoval.StripTagsRegex(usuarioModel.Nome);
            usuarioModel.DescricaoMarkdown = HtmlRemoval.StripTagsRegex(usuarioModel.DescricaoMarkdown);
            usuarioModel.Descricao = HtmlRemoval.StripTagsRegex(usuarioModel.Descricao);

            usuarioModel.ProfileImageUrl = HtmlRemoval.StripTagsRegex(usuarioModel.ProfileImageUrl);
            usuarioModel.HeaderImageUrl = HtmlRemoval.StripTagsRegex(usuarioModel.HeaderImageUrl);

            Uri uriResult;

            if (!(Uri.TryCreate(usuarioModel.ProfileImageUrl, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp))
            {
                usuarioModel.ProfileImageUrl = null;
            }

            if (!(Uri.TryCreate(usuarioModel.HeaderImageUrl, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp))
            {
                usuarioModel.HeaderImageUrl = null;
            }

            usuario.Nome = usuarioModel.Nome.Substring(0, usuarioModel.Nome.Length > 29 ? 29 : usuarioModel.Nome.Length);
            usuario.Descricao = usuarioModel.Descricao.Substring(0, usuarioModel.Descricao.Length > 79 ? 79 : usuarioModel.Descricao.Length);
            usuario.DescricaoMarkdown = usuarioModel.DescricaoMarkdown.Substring(0, usuarioModel.DescricaoMarkdown.Length > 3999 ? 3999 : usuarioModel.DescricaoMarkdown.Length);

            usuario.ProfileImageUrl = usuarioModel.ProfileImageUrl;
            usuario.HeaderImageUrl = usuarioModel.HeaderImageUrl;

            return usuario;
        }

        public IEnumerable<UsuarioModel> GetAllUsuarios()
        {
            return _uow.Usuarios.Get().Select(u => new UsuarioModel(u));
        }

        public bool IsUsernameUnique(string username)
        {
            return _uow.Usuarios.Count(u => u.UserID.ToLower() == username.ToLower()) <= 0;
        }

        public bool IsEmailUnique(string email)
        {
            return _uow.Usuarios.Count(u => u.Email.ToLower() == email.ToLower()) <= 0;
        }
    }
}
