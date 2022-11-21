using Microsoft.AspNetCore.Mvc;
using Domain.Helpers.HandlingError;
using Domain.Interfaces.Services;
using Domain.Interfaces;
using Domain.Dto;

namespace Simple.Client.MEI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IUnitOfWork _unitOfWork;

        public ClientController(IClientService clientService, IUnitOfWork unitOfWork)
        {
            _clientService = clientService;
            _unitOfWork = unitOfWork;
        }


        [HttpGet("FetchClient")]
        public async Task<IActionResult> FetchClient([FromQuery]FetchClientInputDto fetchClientInputDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var result = await _clientService.FetchClient(fetchClientInputDto);
                if (!result.Item2)
                {
                    _unitOfWork.Rollback();
                    return BadRequest(new { Message = result.Item1 });
                }
                _unitOfWork.Commit();
                return Ok(result.Item3);
            }
            catch
            {
                throw new AppException("Error finding client.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientInputDto clientInputDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var result = await _clientService.Create(clientInputDto);
                if (!result.Item2)
                {
                    _unitOfWork.Rollback();
                    return BadRequest(result.Item1);
                }
                _unitOfWork.Commit();
                return Ok(result.Item1);
            }
            catch 
            {
                throw new AppException("Error to create client.");
            }
        }
    }
}
