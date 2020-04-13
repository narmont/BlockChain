using BlockchainMSSQL;
using System;
using System.Linq;

namespace BlockchainLibrary
{
    /// <summary>
    /// Блок из цепочки блоков.
    /// </summary>
    public class Block : IHashable
    {
        /// <summary>
        /// Алгоритм хеширования.
        /// </summary>
        private IAlgorithm _algorithm = AlgorithmHelper.GetDefaultAlgorithm();
        
        /// <summary>
        /// Версия спецификации блока.
        /// </summary>
        public int Version { get; private set; }

        /// <summary>
        /// Момент создания блока.
        /// </summary>
        public DateTime CreatedOn { get; private set; }

        /// <summary>
        /// Хеш блока.
        /// </summary>
        public string Hash { get; private set; }

        /// <summary>
        /// Хеш предыдущего блока.
        /// </summary>
        public string PreviousHash { get; private set; }

        /// <summary>
        /// Данные блока.
        /// </summary>
        public Data Data { get; private set; }

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

        /// <summary>
        /// Создание блока цепочки из блока провайдера данных.
        /// </summary>
        /// <param name="block"> Блок провайдера данных. </param>
        public Block(IDataProvider provider, BlockchainMSSQL.Block block)
        {
            if (block == null)
            {
                throw new ArgumentException("Блок данных провайдера данных не может быть равен null.", nameof(block));
            }

            Version = block.Version;
            CreatedOn = block.CreatedOn.ToLocalTime();
            UserFrom = provider.FindUser(block.UserFrom.Login);
            UserTo = provider.FindUser(block.UserTo.Login);
            PreviousHash = block.PreviousHash;
            Data = new Data(block.Data);
            Hash = block.Hash;
            Money = block.Money;

            if (!this.IsCorrect())
            {
                throw new ArgumentException("Ошибка создания блока из блока провайдера данных. Блок некорректный.", nameof(Block));
            }
        }

        /// <summary>
        /// Создать экземпляр блока.
        /// </summary>
        /// <param name="previousBlock">Предыдущий блок.</param>
        /// <param name="data">Данные, сохраняемые в блоке.</param>
        /// <param name="algorithm">Алгоритм хеширования.</param>
        /// <param name="user"> Идентификатор пользователя, создавшего блок. </param>
        public Block(Block previousBlock, Data data, BlockchainMSSQL.User userFrom, BlockchainMSSQL.User userTo, double money, IAlgorithm algorithm = null)
        {
            #region Requires
            if (previousBlock == null)
            {
                throw new ArgumentException("Предыдущий блок не может быть равен null.", nameof(previousBlock));
            }

            if (!previousBlock.IsCorrect())
            {
                throw new ArgumentException("Предыдущий блок некорректный.", nameof(previousBlock));
            }

            if (data == null)
            {
                throw new ArgumentException("Данные не могут быть равны null.", nameof(data));
            }

            if (!data.IsCorrect())
            {
                throw new ArgumentException("Данные некорректные.", nameof(data));
            }
            #endregion

            if (algorithm != null)
            {
                _algorithm = algorithm;
            }

            Version = 1; 
            CreatedOn = DateTime.Now.ToUniversalTime();
            PreviousHash = previousBlock.Hash;
            Data = data;
            UserFrom = userFrom ?? throw new ArgumentException("Пользователь не может быть равен null.", nameof(userFrom));
            UserTo = userTo ?? throw new ArgumentException("Пользователь не может быть равен null.", nameof(userTo));
            Hash = this.GetHash(_algorithm);
            Money = money;

            if (!this.IsCorrect())
            {
                throw new ArgumentException("Ошибка создания блока. Блок некорректный.", nameof(Block));
            }
        }

        /// <summary>
        /// Создать новый экземпляр стартового (генезис) блока.
        /// </summary>
        /// <param name="user"> Пользователь системы. </param>
        /// <param name="algorithm"> Алгоритм хеширования. </param>
        protected Block(IDataProvider provider, IAlgorithm algorithm = null)
        {
            if (algorithm != null)
            {
                _algorithm = algorithm;
            }

            Version = 1;
            CreatedOn = DateTime.Parse("2018-01-01T00:00:00.000+00:00").ToUniversalTime();

            var user = provider.FindUser("root");

            if (user == null)
            {
                provider.AddUser("root", "1", 0);
                user = provider.FindUser("root");
            }
            
            UserFrom = user;
            UserTo = user;

            PreviousHash = "00000000-0000-0000-0000-000000000000";
            Data = new Data("Это стартовый блок", _algorithm);
            Hash = this.GetHash(_algorithm);

            if (!this.IsCorrect())
            {
                throw new ArgumentException("Ошибка создания генезис блока. Блок некорректный.", nameof(Block));
            }
        }
        
        /// <summary>
        /// Получить начальный блок цепочки блоков.
        /// </summary>
        /// <param name="algorithm"> Алгоритм хеширования. </param>
        /// <returns> Стартовый блок. </returns>
        public static Block GetGenesisBlock(IDataProvider provider, IAlgorithm algorithm = null)
        {
            if (algorithm == null)
            {
                algorithm = AlgorithmHelper.GetDefaultAlgorithm();
            }

            var genesisBlock = new Block(provider, algorithm);
            return genesisBlock;
        }

        /// <summary>
        /// Получить данные из объекта, на основе которых будет строиться хеш.
        /// </summary>
        /// <returns> Хешируемые данные. </returns>
        public string GetStringForHash()
        {
            var data = "";
            data += Version;
            //data += CreatedOn.Ticks;
            data += PreviousHash;
            data += Data.Hash;
            data += UserFrom.Login;
            data += UserTo.Login;

            return data;
        }

        public void SetData(string text)
        {
            this.Data = new Data(text);
        }
        public void SetprevHash(string hash)
        {
            this.PreviousHash = hash;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Идентификатор блока. </returns>
        public override string ToString()
        {
            return Hash;
        }
    }
}
