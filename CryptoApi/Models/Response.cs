using Newtonsoft.Json;

namespace CryptoApi.Models
{
    public class Reponse<T> where T : class
    {
        /// <summary>Возвращаемая сущность</summary>
        [JsonProperty(PropertyName = "entity", NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }

        /// <summary>Код ответа</summary>
        [JsonProperty(PropertyName = "errorCode")]
        public int ErrorCode { get; set; }

        /// <summary>Текст ошибки</summary>
        [JsonProperty(PropertyName = "errorMessage")]
        public string ErrorMessage { get; set; }
    }
}