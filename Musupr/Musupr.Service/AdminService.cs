using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Musupr.Domain.Models;
using Musupr.Repository;

namespace Musupr.Service
{
    public class AdminService
    {
        private IUnitOfWork _uow;

        public AdminService(IUnitOfWork uow)
        {
            _uow = uow;

        }


        public bool BloquearAnuncio(int Id)
        {
            Vaga vaga = _uow.Vagas.GetByID(Id);

            if (vaga.Bloqueada)
            {
                return true;
            }
            else
            {

                vaga.Bloqueada = true;
                vaga.TipoVaga = vaga.TipoVaga;
                vaga.Criador = vaga.Criador;
                _uow.Vagas.Update(vaga);
                _uow.Save();

                return true;
            }
        }

        public bool DesbloquearAnuncio(int Id)
        {
            Vaga vaga = _uow.Vagas.GetByID(Id);

            if (!vaga.Bloqueada)
            {
                return true;
            }
            else
            {
                vaga.Bloqueada = false;
                vaga.TipoVaga = vaga.TipoVaga;
                vaga.Criador = vaga.Criador;
                _uow.Vagas.Update(vaga);
                _uow.Save();
                return true;
            }
        }

        public bool BloquearUsuario(int Id)
        {
            Usuario usuario = _uow.Usuarios.GetByID(Id);

            if (usuario.Bloqueado)
            {
                return true;
            }
            else if(!usuario.Roles.Contains("admin"))
            {
                usuario.Bloqueado = true;
                _uow.Usuarios.Update(usuario);
                _uow.Save();
                return true;
            }

            return false;
        }

        public bool DesbloquearUsuario(int Id)
        {
            Usuario usuario = _uow.Usuarios.GetByID(Id);

            if (!usuario.Bloqueado)
            {
                return true;
            }
            else
            {
                usuario.Bloqueado = false;
                _uow.Usuarios.Update(usuario);
                _uow.Save();
                return true;
            }
        }

    }
}
