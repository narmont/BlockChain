namespace BlockchainMSSQL
{
    /// <summary>
    /// Класс пользователя приложения.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Логин пользователя.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Финансы пользователя.
        /// </summary>
        public double Money { get; set; }
    }
}
