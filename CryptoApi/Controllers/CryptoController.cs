using CryptoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebGrease.Css.Extensions;

namespace CryptoApi.Controllers
{
    public class CryptoController : ApiController
    {
        private static readonly Dictionary<char, char> CryptoDict = new Dictionary<char, char>()
        {
            { 'а', 'у' },
            { 'б', 'а' },
            { 'в', 'м' }
        };

        /// <summary>
        /// Получение шифорованного теста
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpPost]
        //[Route("api/crypto/get/{text}")]
        public IHttpActionResult Get([FromUri(Name = "text")]string text)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                    return Ok(new Reponse<string>()
                    {
                        Data = null,
                        ErrorCode = (int)ServiceCode.BadRequest,
                        ErrorMessage = "Некорректный запрос"
                    });

                var textArr = text.ToCharArray();

                string res = null;
                string errSymbols = null;
                char cryptSymbol;

                textArr.ForEach(s =>
                {
                    cryptSymbol = CryptoDict.Where(e => e.Key == s).Select(v => v.Value).FirstOrDefault();

                    if (cryptSymbol != char.MinValue)
                        res += cryptSymbol;
                    else
                        errSymbols += s;
                });

                if (!string.IsNullOrEmpty(errSymbols))
                    return Ok(new Reponse<string>()
                    {
                        Data = errSymbols,
                        ErrorCode = (int)ServiceCode.BadRequest,
                        ErrorMessage = "Некорректный запрос"
                    });
                else
                    return Ok(new Reponse<string>()
                    {
                        Data = res,
                        ErrorCode = (int)ServiceCode.OK,
                        ErrorMessage = null
                    });
            }
            catch (Exception ex)
            {
                return Ok(new Reponse<string>()
                {
                    Data = null,
                    ErrorCode = (int)ServiceCode.InternalServerError,
                    ErrorMessage = "Ошибка сервиса"
                });
            }
        }
    }
}
