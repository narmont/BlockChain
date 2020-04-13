using System;

namespace BlockchainLibrary
{
    /// <summary>
    /// Данные хранимые в блоке из цепочки блоков.
    /// </summary>
    public class Data : IHashable
    {
        /// <summary>
        /// Алгоритм хеширования.
        /// </summary>
        private IAlgorithm _algorithm = AlgorithmHelper.GetDefaultAlgorithm();

        /// <summary>
        /// Содержимое блока.
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Хеш данных.
        /// </summary>
        public string Hash { get; private set; }
      
        /// <summary>
        /// Создать экземпляр данных.
        /// </summary>
        /// <param name="content"> Данные. </param>
        /// <param name="algorithm"> Алгоритм для хеширования. </param>
        public Data(string content, IAlgorithm algorithm = null)
        {
            // Проверяем предусловия.
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentException("Данные не могут быть пустыми или равняться null", nameof(content));
            }

            // Если не указан алгоритм, то берем по умолчанию.
            if (algorithm != null)
            {
                _algorithm = algorithm;
            }

            Content = content;

            Hash = this.GetHash(_algorithm);

            if (!this.IsCorrect())
            {
                throw new ArgumentException("Ошибка создания данных. Данные некорректны.", nameof(Data));
            }
        }

        /// <summary>
        /// Получить данные из объекта, на основе которых будет строиться хеш.
        /// </summary>
        /// <returns> Хешируемые данные. </returns>
        public string GetStringForHash()
        {
            var text = Content;
            return text;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Хранящиеся данные. </returns>
        public override string ToString()
        {
            return Content;
        }
    }
}
