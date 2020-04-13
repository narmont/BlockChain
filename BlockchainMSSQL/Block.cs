using System;

namespace BlockchainMSSQL
{
    /// <summary>
    /// Блок, хранящийся в базе данных.
    /// </summary>
    public class Block
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int BlockId { get; set; }

        /// <summary>
        /// Версия спецификации блока.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Момент создания блока.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Хеш блока.
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// Хеш предыдущего блока.
        /// </summary>
        public string PreviousHash { get; set; }

        /// <summary>
        /// Данные блока.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Идентификатор пользователя, создавшего блок.
        /// </summary>
        public int UserFromID { get; set; }
        public User UserFrom { get; set; }

        /// <summary>
        /// Идентификатор пользователя, кому отправили блок.
        /// </summary>
        public int UserToID { get; set; }
        public User UserTo { get; set; }

        /// <summary>
        /// Финансовая транзакция.
        /// </summary>
        public double Money { get; set; }
    }
}
