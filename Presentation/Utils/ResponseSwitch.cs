using Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Utils
{
    public static class ResponseSwitch
    {
        public static IActionResult StatusCodes<T>(ResponseDto<T> response)
        {
            switch (response.Code)
            {
                case 200:
                    return new OkObjectResult(response);
                case 400:
                    return new BadRequestObjectResult(response);
                default:
                    return new ObjectResult(response) { StatusCode = response.Code };
            }
        }
    }
}