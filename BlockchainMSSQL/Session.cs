using System.Linq;

namespace BlockchainMSSQL
{
    /// <summary>
    /// Сессия пользователя.
    /// </summary>
    public static class Session
    {
        public static IDataProvider _curProvider = null;
        /// <summary>
        /// Текущий пользователь. Один экземпляр программы - один пользователь.
        /// </summary>
        private static User _curUser = null;

        /// <summary>
        /// Задать текущего пользователя (авторизация).
        /// </summary>
        /// <param name="user">Пользователь, прошедший аутентификацию. </param>
        public static void SetCurrentUser(User user)
        {
            _curUser = user;    
        }

        /// <summary>
        /// Получить текущего пользователя.
        /// </summary>
        /// <returns>Текущий пользователь. </returns>
        public static User GetCurrentUser()
        {
            return _curUser;
        }

        public static void UpdateMoney(double money)
        {
            _curUser.Money += money;
        }
    }
}
