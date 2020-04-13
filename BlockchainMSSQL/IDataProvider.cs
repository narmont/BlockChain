using System;
using System.Collections.Generic;

namespace BlockchainMSSQL
{
    /// <summary>
    /// Базовый интерфейс, который должен реализовывать провайдер данных.
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Добавление блока данных.
        /// </summary>
        /// <param name="version"> Версия блока. </param>
        /// <param name="code"> Уникальный код блока. </param>
        /// <param name="createdOn"> Дата создания блока. </param>
        /// <param name="hash"> Хеш блока. </param>
        /// <param name="previousHash"> Хеш предыдущего блока. </param>
        /// <param name="data"> Данные блока. </param>
        /// <param name="user"> Данные о пользователе. </param>
        void AddBlock(int version, DateTime createdOn, string hash, string previousHash, string data, User userFrom, User userTo, double money);

        /// <summary>
        /// Добавление пользователя.
        /// </summary>
        /// <param name="login"> Логин. </param>
        /// <param name="password"> Пароль. </param>
        void AddUser(string login, string password, double money);

        /// <summary>
        /// Поиск пользователя.
        /// </summary>
        /// <param name="login"> Логин. </param>
        User FindUser(string login);

        /// <summary>
        /// Поиск пользователя.
        /// </summary>
        /// <param name="login"> Логин. </param>
        User FindUser(string login, string password);

        /// <summary>
        /// Получить всех пользователей.
        /// </summary>
        /// <returns> Список всех пользователей. </returns>
        List<User> GetUsers();

        /// <summary>
        /// Получить все блоки.
        /// </summary>
        /// <returns> Список всех блоков. </returns>
        List<Block> GetBlocks();


        /// <summary>
        /// Очистить хранилище. Удаление всех блоков.
        /// </summary>
        void Clear();
    }
}