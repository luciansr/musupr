using Musupr.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Musupr.App.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : ApiController
    {
        AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        public IHttpActionResult DesbloquearAnuncio(int Id)
        {
            if (_adminService.DesbloquearAnuncio(Id))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        public IHttpActionResult DesbloquearUsuario(int Id)
        {
            if (_adminService.DesbloquearUsuario(Id))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        public IHttpActionResult BloquearAnuncio(int Id)
        {
            if (_adminService.BloquearAnuncio(Id))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        public IHttpActionResult BloquearUsuario(int Id)
        {
            if (_adminService.BloquearUsuario(Id))
            {
                return Ok();
            }

            return BadRequest();
        }

    }
}
