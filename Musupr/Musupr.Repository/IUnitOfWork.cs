using System;
using Musupr.Domain.Models;

namespace Musupr.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Vaga> Vagas { get; }
        IRepository<Usuario> Usuarios { get; }
        IRepository<TipoVaga> TiposVaga { get; }

        IRepository<Qualificacao> Qualificacoes { get; }
        IRepository<NivelQualificacao> NiveisQualificacao { get; }
        IRepository<Avaliacao> Avaliacoes { get; }

        void Save();

    }
}
