using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoApi.Models
{
    /// <summary>Запрос к сервису</summary>
    public class Request
    {
        public Request()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }

        /// <summary>Идентификатор заявки</summary>
        [Key]
        [JsonProperty(PropertyName = "requestId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid Id { get; set; }

        /// <summary>Дата создания заявки</summary>
        [JsonProperty(PropertyName = "createdDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedDate { get; set; }

        /// <summary>Текст запроса</summary>
        [JsonProperty(PropertyName = "text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
    }
}