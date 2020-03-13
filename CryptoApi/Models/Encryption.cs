using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoApi.Models
{
    public class Encryption
    {
        [Key]
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Code { get; set; }
    }
}