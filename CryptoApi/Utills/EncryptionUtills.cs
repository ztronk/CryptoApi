using CryptoApi.CQRS.Command;
using CryptoApi.CQRS.Query;
using CryptoApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WebGrease.Css.Extensions;

namespace CryptoApi.Utills
{
    public static class EncryptionUtills
    {
        private static List<Encryption> cryptoDict;
        private static LogCommand logCommand = new LogCommand();

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
        public static Response<string> Encrypt(Request request)
        {
            var textArr = request.Text.Select(s => s.ToString()).ToArray();

            string resSymbols = null, errSymbols = null, cryptSymbol = null;

            textArr.ForEach(s =>
            {
                cryptSymbol = cryptoDict.Where(e => e.Key == s).Select(v => v.Code).FirstOrDefault();

                if (!string.IsNullOrEmpty(cryptSymbol))
                    resSymbols += cryptSymbol;
                else
                    errSymbols += s;
            });

            return new Response<string>()
            {
                Data = !string.IsNullOrEmpty(errSymbols) ? errSymbols : resSymbols,
                ErrorCode = !string.IsNullOrEmpty(errSymbols) ? (int)ServiceCode.BadRequest : (int)ServiceCode.OK,
                ErrorMessage = !string.IsNullOrEmpty(errSymbols) ? "Некорректный запрос" : null
            };
        }

        /// <summary>
        /// Логирование
        /// </summary>
        /// <param name="request">Запрос на сервис</param>
        /// <param name="response">Ответ сервиса</param>
        private static void Loggin(Request request, Response<string> response)
        {
            logCommand.CreateLog(new Log()
            {
                Request = JsonConvert.SerializeObject(request),
                Response = JsonConvert.SerializeObject(response)
            });
        }

        /// <summary>
        /// Процесс шифрования
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Response<string> EncryptProcess(Request request)
        {
            try
            {
                var response = Encrypt(request);
                Loggin(request, response);
                return response;
            }
            catch (Exception ex)
            {
                var response = new Response<string>()
                {
                    Data = null,
                    ErrorCode = (int)ServiceCode.InternalServerError,
                    ErrorMessage = "Ошибка сервиса"
                };

                Loggin(request, response);
                return response;
            }
        }
    }
}