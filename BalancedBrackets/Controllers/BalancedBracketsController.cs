using BalancedBrackets.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BalancedBrackets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BalancedBracketsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(string request)
        {
            try
            {
                var service = new BalancedBracketsService();
                var isBalanced = service.CheckBalance(request);

                return Ok(request);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
