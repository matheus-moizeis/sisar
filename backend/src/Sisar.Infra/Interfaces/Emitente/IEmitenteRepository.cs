using Sisar.Domain.Entities;

namespace Sisar.Infra.Interfaces
{
    public interface IEmitenteRepository : IBaseRepository<Emitente>
    {
        Task<List<Emitente>> ListarAtivos();
    }
}
