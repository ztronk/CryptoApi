using CryptoApi.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CryptoApi.Query
{
    public class CryptoQuery : BaseQuery<Dictionary<char, char>()>
    {
        public Dictionary<char, char> GetCryptoDict()
        {
            return _context.ToDictionary() { new Dictionary<char, char>() { } };
        }
    }
}