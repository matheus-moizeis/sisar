#region Namespaces

using AutoMapper;
using Sisar.Core.Exceptions;
using Sisar.Domain.Entities;
using Sisar.Infra.Interfaces;
using Sisar.Service.DTO;
using Sisar.Service.Interfaces;

#endregion

namespace Sisar.Service.Services
{
    public class EmitenteService : IEmitenteService
    {
        #region Métodos

        private readonly IMapper _mapper;
        private readonly IEmitenteRepository _repository;

        #endregion

        #region Construtores
        public EmitenteService()
        { }
        public EmitenteService(IMapper mapper, IEmitenteRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        #endregion

        #region Métodos
        public async Task<List<EmitenteDTO>> ListarAtivos()
        {
            var emitentesAtivos = await _repository.ListarAtivos();

            return _mapper.Map<List<EmitenteDTO>>(emitentesAtivos);
        }
        public async Task<EmitenteDTO> Get(long id)
        {
            var emitente = await _repository.Get(id);

            return _mapper.Map<EmitenteDTO>(emitente);
        }

        #region CRUD

        public async Task<EmitenteDTO> Create(EmitenteDTO emitenteDTO)
        {
            var emitente = _mapper.Map<Emitente>(emitenteDTO);
            emitente.Validate();

            var emitenteCadastrado = await _repository.Create(emitente);

            return _mapper.Map<EmitenteDTO>(emitenteCadastrado);

        }

        public async Task<List<EmitenteDTO>> Get()
        {
            var todosEmitentes = await _repository.Get();

            return _mapper.Map<List<EmitenteDTO>>(todosEmitentes);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }

        public async Task<EmitenteDTO> Update(EmitenteDTO emitenteDTO)
        {
            var emitenteExists = await _repository.Get(emitenteDTO.Id);

            if (emitenteExists == null)
                throw new DomainException("Não existe nenhum emitente com o id informado!");

            var emitente = _mapper.Map<Emitente>(emitenteDTO);
            emitente.DtCriacao = emitenteExists.DtCriacao;
            emitente.Validate();

            var emitenteAtualizado = await _repository.Update(emitente);

            return _mapper.Map<EmitenteDTO>(emitenteAtualizado);
        }

        #endregion

        #endregion
    }
}
