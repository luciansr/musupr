using Musupr.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Musupr.App.Controllers
{
    public class AccountController : ApiController
    {
        AccountService _accountService;
        ReCaptchaService _reCaptchaService;

        public AccountController(AccountService accountService, ReCaptchaService reCaptchaService)
        {
            _accountService = accountService;
            _reCaptchaService = reCaptchaService;
        }

        [HttpPost]
        public IHttpActionResult PedirTrocarSenha(string userID, string reCaptchaResponse)
        {
            if (!_reCaptchaService.ResponseIsCorrect(reCaptchaResponse))
            {
                return BadRequest(((int)ReCaptchaService.RESPONSE.INVALID).ToString());
            }

            if (_accountService.PedirTrocarSenha(userID))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        public IHttpActionResult TrocarSenha(string guid, string userID, string novaSenha, string reCaptchaResponse)
        {
            if (!_reCaptchaService.ResponseIsCorrect(reCaptchaResponse))
            {
                return BadRequest(((int)ReCaptchaService.RESPONSE.INVALID).ToString());
            }

            if (_accountService.TrocarSenha(guid, userID, novaSenha))
            {
                return Ok();
            }

            return BadRequest("0");
        }

        [HttpPost]
        public IHttpActionResult RegistrarUsuario(string Nome, string userID, string Email, string senha, string reCaptchaResponse)
        {
            if (!_reCaptchaService.ResponseIsCorrect(reCaptchaResponse))
            {
                return BadRequest(((int)ReCaptchaService.RESPONSE.INVALID).ToString());
            }

            if (_accountService.RegistrarUsuario(Nome, userID, Email, senha))
            {
                return Ok();
            }

            return BadRequest("0");
        }

    }
}
