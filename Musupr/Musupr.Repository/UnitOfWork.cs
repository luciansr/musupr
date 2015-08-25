using System;
using Musupr.Domain.Models;

namespace Musupr.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private MusuprContext context = new MusuprContext();

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private GenericRepository<Vaga> _vagas;
        public IRepository<Vaga> Vagas
        {
            get
            {
                return _vagas ?? (_vagas = new GenericRepository<Vaga>(context));
            }
        }

        private GenericRepository<Usuario> _usuarios;
        public IRepository<Usuario> Usuarios
        {
            get
            {
                return _usuarios ?? (_usuarios = new GenericRepository<Usuario>(context));
            }
        }

        private GenericRepository<TipoVaga> _tiposVaga;
        public IRepository<TipoVaga> TiposVaga
        {
            get
            {
                return _tiposVaga ?? (_tiposVaga = new GenericRepository<TipoVaga>(context));
            }
        }

        private GenericRepository<Qualificacao> _qualificacoes;
        public IRepository<Qualificacao> Qualificacoes
        {
            get
            {
                return _qualificacoes ?? (_qualificacoes = new GenericRepository<Qualificacao>(context));
            }
        }

        private GenericRepository<NivelQualificacao> _niveisQualificacao;
        public IRepository<NivelQualificacao> NiveisQualificacao
        {
            get
            {
                return _niveisQualificacao ?? (_niveisQualificacao = new GenericRepository<NivelQualificacao>(context));
            }
        }

        private GenericRepository<Avaliacao> _avaliacoes;
        public IRepository<Avaliacao> Avaliacoes
        {
            get
            {
                return _avaliacoes ?? (_avaliacoes = new GenericRepository<Avaliacao>(context));
            }
        }

    }

}
