using System.Configuration;

namespace CryptoApi.Models
{
    /// <summary>Конфигурация сервиса</summary>
    static public class Config
    {
        private static string sqlConnName;

        /// <summary>Данные для подключения к серверу базы данных</summary>
        public static string sqlConnName
        {
            get
            {
                if (string.IsNullOrEmpty(sqlConnName))
                    sqlConnName = ConfigurationManager.ConnectionStrings["Crypto"].ConnectionString;

                return sqlConnName;
            }
        }
    }
}