using Sisar.Service.DTO;

namespace Sisar.Service.Interfaces
{
    public interface IEmitenteService
    {
        Task<EmitenteDTO> Create(EmitenteDTO emitenteDTO);

        Task<EmitenteDTO> Update(EmitenteDTO emitenteDTO);

        Task Remove(long id);

        Task<EmitenteDTO> Get(long id);

        Task<List<EmitenteDTO>> Get();

        Task<List<EmitenteDTO>> ListarAtivos();
    }
}
