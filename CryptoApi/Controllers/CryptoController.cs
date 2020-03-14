using CryptoApi.Attribute;
using CryptoApi.Models;
using CryptoApi.Utills;
using System.Web.Http;

namespace CryptoApi.Controllers
{
    public class CryptoController : ApiController
    {
        /// <summary>
        /// Получение шифорованного теста
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/crypto/get/")]
        [ValidateRequest]
        public IHttpActionResult Get(Request request)
        {
            var res = EncryptionUtills.EncryptProcess(request);
            return Ok(res);
        }
    }
}
