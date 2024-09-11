using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using FizzBuzz.Managers;
using FizzBuzz.Model;
using Newtonsoft.Json;

namespace FizzBuzz.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        IHttpContextAccessor _httpContextAccessor;
        IFizzBuzzManager _fizzBuzzManager;

        public FizzBuzzController(IHttpContextAccessor httpContextAccessor, IFizzBuzzManager fizzBuzzManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _fizzBuzzManager = fizzBuzzManager;
        }

        /// <summary>
        /// Returns List of FizzBuzz results
        /// </summary>
        /// <returns>string</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("get/")]
        public ActionResult<List<FizzBuzzResult>> Get([Required] int start, [Required] int end)
        {
            try
            {
                if(start > end){
                    ModelState.AddModelError("Range", "start must be before end");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                
                var response = _fizzBuzzManager.Results(start, end);

                return Ok(response);
            }
            catch (Exception exception)
            {                
                return BadRequest(exception);
            }
        }
    }

}