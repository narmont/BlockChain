using System.Data.Entity;

namespace BlockchainMSSQL
{
    class LocalSQLContext : DbContext
    {
        /// <summary>
        /// Создать экземпляр контекста данных SQL.
        /// </summary>
        public LocalSQLContext()
            : base("BlockchainLocalConnection")
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
