using CryptoApi.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace CryptoApi.CQRS.Query
{
    public class BaseQuery<T> : DbContext where T : class
    {
        public BaseQuery()
            : base(Config.SqlConnName)
        { }

        public DbSet<T> context { get; set; }

        /// <summary>
        /// Получение всех записей сущности
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetList()
        {
            foreach (var item in context)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Добавление сущности
        /// </summary>
        /// <param name="entity"></param>
        public void CreateEntity(T entity)
        {
            context.Add(entity);
            SaveChanges();
        }

        /// <summary>
        /// Обновление сущности
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateEntity(T entity)
        {
            context.Add(entity);
            Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }
    }
}