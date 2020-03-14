using CryptoApi.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CryptoApi.Attribute
{
    /// <summary>
    /// Атрибут валидации
    /// </summary>
    public class ValidateRequestAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Валидация
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
                actionContext.Response = actionContext.Request.CreateResponse<Response<string>>(HttpStatusCode.BadRequest,
                                                                                                new Response<string>()
                                                                                                {
                                                                                                    Data = null,
                                                                                                    ErrorCode = (int)ServiceCode.BadRequest,
                                                                                                    ErrorMessage = "Некорректный запрос"
                                                                                                });
        }
    }
}