using CryptoApi.CQRS.Query;
using CryptoApi.Models;
using System.Data.Entity;

namespace CryptoApi.CQRS.Command
{
    public class LogCommand : BaseQuery<Log>
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>().ToTable("Log");
        }

        public void CreateLog(Log log)
        {
            CreateEntity(log);
        }
    }
}