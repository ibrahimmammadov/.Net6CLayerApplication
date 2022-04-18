using Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreatActionResult<T>(CResponseDto<T> cResponseDto)
        {
            if (cResponseDto.StatusCode==204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = cResponseDto.StatusCode
                };
            }
            return new ObjectResult(cResponseDto)
            {
                StatusCode = cResponseDto.StatusCode
            };
        }

        [NonAction]
        public IActionResult CreatActionResultForToken<T>(CResponseDto<T> cResponseDto)
        {
            return new ObjectResult(cResponseDto)
            {
                StatusCode = cResponseDto.StatusCode
            };
        }
    }
}
