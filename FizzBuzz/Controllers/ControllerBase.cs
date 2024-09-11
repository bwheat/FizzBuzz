
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FizzBuzz.Controllers 
{

    public class BaseController : ControllerBase
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion //Fields

        public IHttpContextAccessor HttpContextAccessor
        {
            get
            {
                return _httpContextAccessor;
            }
        }

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        
    }
}