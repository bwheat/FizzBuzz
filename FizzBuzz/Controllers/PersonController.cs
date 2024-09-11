using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using FizzBuzz.Model;
using FizzBuzz.Managers;

namespace FizzBuzz.Controllers 
{
    // Write an MVC controller class with two methods. One that returns a view with a collection of objects, 
    // and a second that performs an add or update of the same type as the first method.
    // Please use attribute routing to decorate the methods and should indicate an appropriate method type.
    // The class used for the collection of objects should include an identifier property, and 2 or 3 other properties, 
    // which includes at least 1 string and 1 integer. For example: ID, First Name, Last Name & Age.    
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        IHttpContextAccessor _httpContextAccessor;
        IPersonManager _personManager;

        public PersonController(IHttpContextAccessor httpContextAccessor, IPersonManager personManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _personManager = personManager;
        }

        /// <summary>
        /// Returns List of Persons from the database
        /// </summary>
        /// <returns>string</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("get/")]
        public ActionResult Get()
        {
            try
            {               
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                
                var response = _personManager.Results();
                ViewData["Persons"] = response;
                return View(response);
            }
            catch (Exception exception)
            {                
                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Returns List of Persons from the database
        /// </summary>
        /// <returns>string</returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("update/")]
        public ActionResult Update(Person person)
        {
            try
            {               
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                
                var response = _personManager.Update(person);
                ViewData["Person"] = response;
                return View(response);
            }
            catch (Exception exception)
            {                
                return BadRequest(exception);
            }
        }
    }

}