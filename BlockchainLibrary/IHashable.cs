namespace BlockchainLibrary
{
    /// <summary>
    /// Объект, который может вычислить внутренний хеш.
    /// </summary>
    public interface IHashable
    {
        /// <summary>
        /// Хранимый хеш компонента.
        /// </summary>
        string Hash { get; }

        /// <summary>
        /// Получить данные из объекта, на основе которых будет строиться хеш.
        /// </summary>
        /// <returns> Хешируемые данные. </returns>
        string GetStringForHash();
    }
}
