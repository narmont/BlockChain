namespace BlockchainLibrary
{
    /// <summary>
    /// Класс, проверяющий корректность хеша.
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Проверка корректности хешируемого объекта.
        /// </summary>
        /// <param name="component"> Хешируемый компонент. </param>
        /// <param name="algorithm"> Алгоритм хеширования. </param>
        /// <returns> Корректность компонента. true - компонент корректный, false - компонент не корректен. </returns>
        public static bool IsCorrect(this IHashable component, IAlgorithm algorithm = null)
        {
            if (algorithm == null)
            {
                algorithm = AlgorithmHelper.GetDefaultAlgorithm();
            }

            var correct = component.Hash == component.GetHash(algorithm);
            return correct;
        }
    }
}
