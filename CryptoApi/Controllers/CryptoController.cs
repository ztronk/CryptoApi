using CryptoApi.Attribute;
using CryptoApi.Models;
using CryptoApi.Utills;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CryptoApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
