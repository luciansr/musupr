using Musupr.App.MusuprAuthenticationProvider;
using Musupr.Domain.DTModels;
using Musupr.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Musupr.App.Controllers
{
    public class UsuarioController : ApiController
    {
        UsuarioService _usuarioService;
        ReCaptchaService _reCaptchaService;
        VagasService _vagasService;

        public UsuarioController(UsuarioService usuarioService, ReCaptchaService reCaptchaService, VagasService vagasService)
        {
            _usuarioService = usuarioService;
            _reCaptchaService = reCaptchaService;
            _vagasService = vagasService;
        }

        private int GetUsuarioID()
        {
            return AuthenticationHelper.GetKeyFromUser<int>("ID", Request.GetOwinContext());
        }

        private bool UsuarioEhAdmin()
        {
            string role = AuthenticationHelper.GetKeyFromUser<string>("Role", Request.GetOwinContext());

            return role != null && role.Contains("admin");
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult EditaUsuario(ReCaptchaParam<UsuarioModel> recaptchaParam)
        {
            UsuarioModel usuario = recaptchaParam.param;

            if (!_reCaptchaService.ResponseIsCorrect(recaptchaParam.reCaptchaResponse))
            {
                return BadRequest(((int)ReCaptchaService.RESPONSE.INVALID).ToString());
            }

            int ID = _usuarioService.EditaUsuario(usuario, GetUsuarioID(), UsuarioEhAdmin());

            if (ID > 0)
            {
                return Ok(ID);
            }

            return BadRequest((-ID).ToString());
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetItensDoUsuario()
        {
            bool ehAdmin = UsuarioEhAdmin();

            return Ok(new
            {
                vagas = _vagasService.GetVagasFromUsuario(GetUsuarioID(), ehAdmin),
                usuarios = ehAdmin ? _usuarioService.GetAllUsuarios() : null
            });
        }


        [HttpGet]
        public IHttpActionResult GetUsuarioByID(int id)
        {
            bool ehAdmin = UsuarioEhAdmin();

            UsuarioModel usuario = _usuarioService.GetUsuarioModelByID(id, GetUsuarioID(), ehAdmin);

            if (usuario == null) return BadRequest();

            if (usuario.PodeSerEditado)
            {
                return Ok(usuario);
            }
            else
            {
                return Ok(usuario);
            }

        }

        [HttpGet]
        public IHttpActionResult IsUsernameUnique(string username)
        {
            if (_usuarioService.IsUsernameUnique(username)) {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        public IHttpActionResult IsEmailUnique(string email)
        {
            if (_usuarioService.IsEmailUnique(email))
            {
                return Ok();
            }

            return BadRequest();
        }


    }
}
