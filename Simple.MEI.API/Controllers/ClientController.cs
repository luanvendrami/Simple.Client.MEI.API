using Microsoft.AspNetCore.Mvc;
using Domain.Helpers.HandlingError;
using Domain.Interfaces.Services;
using Domain.Interfaces;

namespace Simple.Client.MEI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly IClientService _clientService;
        private readonly IUnitOfWork _unitOfWork;

        public ClientController(IClientService clientService, IUnitOfWork unitOfWork)
        {
            _clientService = clientService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var result = await _clientService.Create();
                if (!result.Item2)
                {
                    _unitOfWork.Rollback();
                    return ResultBadRequest(result.Item1);
                }
                _unitOfWork.Commit();
                return ResultOk(result.Item1);
            }
            catch 
            {
                throw new AppException("Error to create client.");
            }
        }
    }
}
