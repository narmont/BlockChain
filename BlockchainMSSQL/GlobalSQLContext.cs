using System;
using System.Data.Entity;

namespace BlockchainMSSQL
{
    /// <summary>
    /// Контекст подключения к базе данных MS SQL.
    /// </summary>
    public class GlobalSQLContext : DbContext
    {
        /// <summary>
        /// Создать экземпляр контекста данных SQL.
        /// </summary>
        public GlobalSQLContext()
            : base("BlockchainGlobalConnection")
        {
           
        }

        /// <summary>
        /// Пользователи.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Блоки данных.
        /// </summary>
        public DbSet<Block> Blocks { get; set; }
    }
}
