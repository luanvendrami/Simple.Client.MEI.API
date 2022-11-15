using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Simple.Client.MEI.API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult ResultOk(string message, object? objResult = null)
            => Ok(new Result(message, objResult));
        protected IActionResult ResultBadRequest(string mensagem)
            => BadRequest(new Result(mensagem));

    }
    public class Result
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public object? IsResult { get; private set; }
        public Result(string message)
        {
            Success = false;
            Message = message;
        }
        public Result(string message, object result)
        {
            Success = true;
            Message = message;
            IsResult = result;
        }
    }
}
