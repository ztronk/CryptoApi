using CryptoApi.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CryptoApi.CQRS.Query
{
    public class CryptoQuery : BaseQuery<Encryption>
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Encryption>().ToTable("Encryption");
        }

        public List<Encryption> GetEncriptionDict()
        {
            return GetList().ToList();
        }
    }
}