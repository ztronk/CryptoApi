using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoApi.Models
{
    public class Log
    {
        public Log()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }

        /// <summary>Идентификатор записи</summary>
        [Key]
        [JsonProperty(PropertyName = "logId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid Id { get; set; }

        /// <summary>Дата создания записи</summary>
        [JsonProperty(PropertyName = "createdDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedDate { get; set; }

        /// <summary>Запрос</summary>
        [JsonProperty(PropertyName = "request", NullValueHandling = NullValueHandling.Ignore)]
        public string Request { get; set; }

        /// <summary>Ответ</summary>
        [JsonProperty(PropertyName = "response", NullValueHandling = NullValueHandling.Ignore)]
        public string Response { get; set; }
    }
}