using CryptoApi.Models;
using CryptoApi.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using WebGrease.Css.Extensions;

namespace CryptoApi.Utills
{
    public static class EncryptionUtills
    {
        private static List<Encryption> cryptoDict;

        static EncryptionUtills()
        {
            try
            {
                cryptoDict = new CryptoQuery().GetEncriptionDict();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Шифрование текста
        /// </summary>
        /// <param name="request">Запрос с клиента</param>
        /// <returns></returns>
        public static Reponse<string> Encrypt(Request request)
        {
            try
            { 
                if (string.IsNullOrEmpty(request.Text))
                    return new Reponse<string>()
                    {
                        Data = null,
                        ErrorCode = (int)ServiceCode.BadRequest,
                        ErrorMessage = "Некорректный запрос"
                    };

                var textArr = request.Text.Select(s => s.ToString()).ToArray();

                string res = null, errSymbols = null, cryptSymbol = null;

                textArr.ForEach(s =>
                {
                    cryptSymbol = cryptoDict.Where(e => e.Key == s).Select(v => v.Code).FirstOrDefault();

                    if (!string.IsNullOrEmpty(cryptSymbol))
                        res += cryptSymbol;
                    else
                        errSymbols += s;
                });

                if (!string.IsNullOrEmpty(errSymbols))
                    return new Reponse<string>()
                    {
                        Data = errSymbols,
                        ErrorCode = (int)ServiceCode.BadRequest,
                        ErrorMessage = "Некорректный запрос"
                    };

                return new Reponse<string>()
                {
                    Data = res,
                    ErrorCode = (int)ServiceCode.OK,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {
                return new Reponse<string>()
                {
                    Data = null,
                    ErrorCode = (int)ServiceCode.InternalServerError,
                    ErrorMessage = "Ошибка сервиса"
                };
            }
        }
    }
}