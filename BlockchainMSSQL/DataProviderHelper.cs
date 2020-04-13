namespace BlockchainMSSQL
{
    /// <summary>
    /// Вспомогательный класс, содержащий методы для упрощения написания кода.
    /// </summary>
    public static class DataProviderHelper
    {
        /// <summary>
        /// Получить провайдер данных по умолчанию.
        /// </summary>
        /// <returns></returns>
        public static IDataProvider GetDefaultDataProvider()
        {
            return new GlobalDataProvider();
        }

        /// <summary>
        /// Получить провайдер данных локальный.
        /// </summary>
        /// <returns></returns>
        public static IDataProvider GetLocalDataProvider()
        {
            return new LocalDataProvider();
        }
    }
}
