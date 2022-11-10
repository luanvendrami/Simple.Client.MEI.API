using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using Domain.Helpers.HandlingError;

namespace Simple.Client.MEI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTest()
        {
            try
            {
                string result = null;
                if (result == null)
                {
                    throw new AppException("Email or password is incorrect");
                }
                return Ok();
            }
            catch 
            {
                throw new AppException("Email or password is incorrect");
            }
        }
    }
}
