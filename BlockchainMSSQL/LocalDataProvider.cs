using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlockchainMSSQL
{
    /// <summary>
    /// Провайдер данных SQL.
    /// </summary>
    public class LocalDataProvider : IDataProvider
    {
        /// <summary>
        /// Добавление блока данных.
        /// </summary>
        /// <param name="version"> Версия блока. </param>
        /// <param name="createdOn"> Дата создания блока. </param>
        /// <param name="hash"> Хеш блока. </param>
        /// <param name="previousHash"> Хеш предыдущего блока. </param>
        /// <param name="data"> Данные блока. </param>
        /// <param name="user"> Данные о пользователе. </param>
        public void AddBlock(int version, DateTime createdOn, string hash, string previousHash, string data, User userFrom, User userTo, double money)
        {
            using (var db = new LocalSQLContext())
            {
                var block = new Block()
                {
                    Version = version,
                    CreatedOn = createdOn.ToLocalTime(),
                    Hash = hash,
                    PreviousHash = previousHash,
                    Data = data,
                    UserFrom = db.Users.Single(x => x.UserId == userFrom.UserId),
                    UserTo = db.Users.Single(x => x.UserId == userTo.UserId),
                    Money = money
                };

                db.Blocks.Add(block);

                var userDetach = db.Users.Single(x => x.UserId == userFrom.UserId);
                userDetach.Money -= money;
                if (userDetach.UserId == Session.GetCurrentUser().UserId) Session.UpdateMoney(-money);

                var userAttach = db.Users.Single(x => x.UserId == userTo.UserId);
                userAttach.Money += money;
                if (userAttach.UserId == Session.GetCurrentUser().UserId) Session.UpdateMoney(money);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Добавление пользователя.
        /// </summary>
        /// <param name="login"> Логин. </param>
        /// <param name="password"> Пароль. </param>
        public void AddUser(string login, string password, double money)
        {
            using (var db = new LocalSQLContext())
            {
                var user = new User()
                {
                    Login = login,
                    Password = password,
                    Money = money
                };

                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Поиск пользователя.
        /// </summary>
        /// <param name="login"> Логин. </param>
        public User FindUser(string login)
        {
            using (var db = new LocalSQLContext())
            {
                return db.Users.SingleOrDefault(x => x.Login == login);
            }
        }

        /// <summary>
        /// Поиск пользователя.
        /// </summary>
        /// <param name="login"> Логин. </param>
        /// <param name="password"> Пароль. </param>
        public User FindUser(string login, string password)
        {
            using (var db = new LocalSQLContext())
            {
                return db.Users.SingleOrDefault(x => x.Login == login && x.Password == password);
            }
        }

        /// <summary>
        /// Очистить хранилище. Удаление всех блоков.
        /// </summary>
        public void Clear()
        {
            using (var db = new LocalSQLContext())
            {
                db.Blocks.RemoveRange(db.Blocks);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получить все блоки.
        /// </summary>
        /// <returns> Список всех блоков. </returns>
        public List<Block> GetBlocks()
        {
            using (var db = new LocalSQLContext())
            {
                var blocks = db.Blocks.Include(x => x.UserFrom).Include(y => y.UserTo).ToList();

                return blocks;
            }
        }

        /// <summary>
        /// Получить всех пользователей.
        /// </summary>
        /// <returns> Список всех пользователей. </returns>
        public List<User> GetUsers()
        {
            using (var db = new LocalSQLContext())
            {
                var users = db.Users.Where(x => x.Login != "root").ToList();

                return users;
            }
        }
    }
}
