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
        public IHttpActionResult Get(Request request)
        {
            var res = EncryptionUtills.Encrypt(request);
            return Ok(res);
        }
    }
}
