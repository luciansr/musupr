using Musupr.Domain.DTModels;
using Musupr.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Musupr.App.MusuprAuthenticationProvider;

namespace Musupr.App.Controllers
{
    public class VagasController : ApiController
    {
        VagasService _vagasService;
        ReCaptchaService _reCaptchaService;

        public VagasController(VagasService vagasService, ReCaptchaService reCaptchaService)
        {
            _vagasService = vagasService;
            _reCaptchaService = reCaptchaService;
        }

        private int GetUsuarioID()
        {
            return AuthenticationHelper.GetKeyFromUser<int>("ID", Request.GetOwinContext());
        }

        private bool UsuarioEhAdmin()
        {
            return AuthenticationHelper.GetKeyFromUser<string>("Role", Request.GetOwinContext()).Contains("admin");
        }

        [HttpGet]
        public IHttpActionResult GetTiposDeVagas()
        {
            return Ok(_vagasService.GetTiposDeVagas());
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult SalvarAnuncio(ReCaptchaParam<VagaModel> recaptchaParam)
        {
            VagaModel vaga = recaptchaParam.param;

            if (!_reCaptchaService.ResponseIsCorrect(recaptchaParam.reCaptchaResponse))
            {
                return BadRequest(((int)ReCaptchaService.RESPONSE.INVALID).ToString());
            }

            int ID = _vagasService.SalvarAnuncio(vaga, GetUsuarioID(), UsuarioEhAdmin());

            if (ID > 0)
            {
                return Ok(ID);
            }

            return BadRequest((-ID).ToString());
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult AvaliaVaga(bool like, int vagaId)
        {
            return Ok(_vagasService.AvaliaVaga(like, vagaId, GetUsuarioID()));
        }

        [HttpGet]
        public IHttpActionResult GetVagaByID(int id)
        {
            VagaModel vaga = _vagasService.GetVagaModelByID(id, GetUsuarioID());

            if (vaga.Bloqueada || vaga.CriadorBloqueado) return BadRequest();

            if (vaga == null) return BadRequest();
            return Ok(vaga);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetVagaParaEditarByID(int id)
        {
            VagaModel vaga = _vagasService.GetVagaModelByID(id, GetUsuarioID());

            if (vaga == null) return BadRequest("NotFound");

            if (vaga.CriadorID != GetUsuarioID() && !UsuarioEhAdmin()) return BadRequest("401");

            return Ok(vaga);
        }

        [HttpGet]
        public IHttpActionResult GetSidebarInfo(int numberOfTags, int numberOfLastOpportunities)
        {
            return Ok(_vagasService.GetSidebarInfo(numberOfTags, numberOfLastOpportunities));
        }

        [HttpGet]
        public IHttpActionResult GetNTags(int n)
        {
            return Ok(_vagasService.GetNTags(n));
        }

        [HttpGet]
        public IHttpActionResult GetUltimasNVagas(int n)
        {
            return Ok(_vagasService.GetUltimasNVagas(n));
        }

        [HttpGet]
        public IHttpActionResult GetDadosDeVagaPorRecomendacao(int pagina, string busca)
        {
            return Ok(_vagasService.GetDadosDeVagaPorRecomendacao(pagina, busca, 10, GetUsuarioID()));
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult ExpirarAnuncio(int Id)
        {
            int retorno = _vagasService.ExpirarAnuncio(Id, GetUsuarioID(), UsuarioEhAdmin());

            if (retorno >= 0)
            {
                return Ok();
            }

            return BadRequest((-retorno).ToString());
        }

    }
}
