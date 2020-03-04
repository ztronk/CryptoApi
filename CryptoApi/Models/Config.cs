using System.Configuration;

namespace CryptoApi.Models
{
    /// <summary>Конфигурация сервиса</summary>
    static public class Config
    {
        private static string sqlConnStr;

        /// <summary>Данные для подключения к серверу базы данных</summary>
        public static string SqlConnStr
        {
            get
            {
                if (string.IsNullOrEmpty(sqlConnStr))
                    sqlConnStr = ConfigurationManager.ConnectionStrings["Crypto"].ConnectionString;

                return sqlConnStr;
            }
        }
    }
}