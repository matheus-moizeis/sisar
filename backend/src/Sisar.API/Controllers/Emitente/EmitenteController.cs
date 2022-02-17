#region Namespaces

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sisar.API.Utilities;
using Sisar.API.ViewModel;
using Sisar.Core.Exceptions;
using Sisar.Service.DTO;
using Sisar.Service.Interfaces;

#endregion

namespace Sisar.API.Controllers
{
    [ApiController]
    public class EmitenteController : ControllerBase
    {
        #region Propriedades

        private readonly IMapper _mapper;
        private readonly IEmitenteService _emitenteService;

        #endregion

        #region Construtor

        public EmitenteController(IMapper mapper, IEmitenteService emitenteService)
        {
            _mapper = mapper;
            _emitenteService = emitenteService;
        }

        #endregion

        #region Métodos

        [HttpGet]
        [Route("api/v1/emitente/get-id/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var emitente = await _emitenteService.Get(id);

                if (emitente == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum funcionário foi encontrado com o ID informado.",
                        Success = false
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Emitente encontrado com sucesso!",
                    Success = true,
                    Data = emitente
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("api/v1/emitente/ativos")]
        public async Task<IActionResult> ListarAtivos()
        {
            try
            {
                var emitentes = await _emitenteService.ListarAtivos();

                if (emitentes == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum funcionário foi encontrado.",
                        Success = false
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Emitente(s) encontrado(s) com sucesso!",
                    Success = true,
                    Data = emitentes
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        #region CRUD

        [HttpPost]
        [Route("api/v1/emitente/")]
        public async Task<IActionResult> Create([FromBody] CreateEmitenteViewModel emitenteVM)
        {
            try
            {
                var emitenteDTO = _mapper.Map<EmitenteDTO>(emitenteVM);
                var emitenteCreated = await _emitenteService.Create(emitenteDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Emitente criado com sucesso!",
                    Success = true,
                    Data = new
                    {
                        Id = emitenteCreated.Id,
                        NomeFantasia = emitenteCreated.NomeFantasia,
                        RazaoSocial = emitenteCreated.RazaoSocial,
                        Ativo = emitenteCreated.Ativo
                    }
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Route("api/v1/emitente/")]
        public async Task<IActionResult> Update([FromBody] UpdateEmitenteViewModel emitenteVM)
        {
            try
            {
                var emitenteDTO = _mapper.Map<EmitenteDTO>(emitenteVM);

                var emitenteUpdated = await _emitenteService.Update(emitenteDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Emitente atualizado com sucesso!",
                    Success = true,
                    Data = emitenteUpdated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("api/v1/emitente/")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var todosEmitentes = await _emitenteService.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Usuários encontrados com sucesso!",
                    Success = true,
                    Data = todosEmitentes
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Route("api/v1/emitente/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            var emitente = await _emitenteService.Get(id);

            if (emitente == null)
                return BadRequest(new ResultViewModel
                {
                    Message = "Nenhum emitente foi encontrado com o ID informado.",
                    Success = false
                });

            try
            {
                await _emitenteService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Emitente removido com sucesso!",
                    Success = true
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        #endregion

        #endregion

    }
}
