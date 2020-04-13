using BlockchainMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlockchainLibrary
{
    /// <summary>
    /// Цепочка блоков.
    /// </summary>
    public class Chain
    {
        /// <summary>
        /// Алгоритм хеширования.
        /// </summary>
        private IAlgorithm _algorithm = AlgorithmHelper.GetDefaultAlgorithm();

        /// <summary>
        /// Провайдер данных.
        /// </summary>
        private IDataProvider _dataProvider = DataProviderHelper.GetDefaultDataProvider();

        /// <summary>
        /// Провайдер данных.
        /// </summary>
        private IDataProvider _localProvider = DataProviderHelper.GetLocalDataProvider();
        

        /// <summary>
        /// Список, содержащий в себе все блоки.
        /// </summary>
        private List<Block> _blockChain = new List<Block>();
        
        /// <summary>
        /// Цепочка блоков.
        /// </summary>
        public IEnumerable<Block> BlockChain => _blockChain;

        /// <summary>
        /// Крайний блок в цепочке блоков.
        /// </summary>
        public Block PreviousBlock => _blockChain.Last();
        
        public int Length => _blockChain.Count;

        /// <summary>
        /// Получить данные из цепочки.
        /// </summary>
        /// <param name="localChain">Цепочка блоков. </param>
        private void LoadDataFromChain(Chain localChain)
        {
            if (localChain == null)
            {
                throw new ArgumentException("Цепочка блоков не может быть равна null.", nameof(localChain));
            }

            foreach (var block in localChain._blockChain)
            {
                _blockChain.Add(block);
            }
        }

        /// <summary>
        /// Создать новый экземпляр цепочки блоков.
        /// </summary>
        public Chain()
        {
            Session._curProvider = _dataProvider;
            var globalChain = GetGlobalChain();

            if (globalChain == null)
            {
                Session._curProvider = _localProvider;

                var localChain = GetLocalChain();

                if (localChain == null)
                {
                    Session._curProvider = _dataProvider;
                    CreateNewBlockChain();
                }
                else
                {
                    LoadDataFromChain(localChain);
                }
            }
            else
            {
                Session._curProvider = _dataProvider;
                var localChain = GetLocalChain();

                if (localChain == null) LoadDataFromChain(globalChain);
                else
                {
                    if (globalChain.Length > localChain.Length)
                    {
                        Session._curProvider = _dataProvider;
                        LoadDataFromChain(globalChain);
                    }
                    else
                    {
                        Session._curProvider = _localProvider;
                        LoadDataFromChain(localChain);
                    }
                }
            }
        }
        
        /// <summary>
        /// Создать новую пустую цепочку блоков.
        /// </summary>
        private void CreateNewBlockChain()
        {
            //_dataProvider.Crear();
            _blockChain = new List<Block>();
            var genesisBlock = Block.GetGenesisBlock(Session._curProvider, _algorithm);
            AddBlock(genesisBlock);
        }

        /// <summary>
        /// Проверить корректность цепочки блоков.
        /// </summary>
        /// <returns> Корректность цепочки блоков. true - цепочка блоков корректна, false - цепочка некорректна. </returns>
        public bool CheckCorrect()
        {
            foreach (var block in _blockChain)
            {
                if (!block.IsCorrect(_algorithm))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Создание цепочки блоков из списка блоков провайдера данных.
        /// </summary>
        /// <param name="blocks"> Блоки провайдера данных. </param>
        private Chain(IDataProvider provider, List<BlockchainMSSQL.Block> blocks)
        {
            if (blocks == null)
            {
                throw new ArgumentException("Список блоков провайдера данных не может быть равным null.", nameof(blocks));
            }

            foreach (var block in blocks)
            {
                var b = new Block(provider, block);
                _blockChain.Add(b);
            }

            if (!CheckCorrect())
            {
                throw new ArgumentException("Ошибка создания цепочки блоков. Цепочка некорректна.", nameof(Chain));
            }
        }

        /// <summary>
        /// Получение цепочки блоков из глобального хранилища.
        /// </summary>
        /// <returns></returns>
        private Chain GetGlobalChain()
        {
            var blocks = _dataProvider.GetBlocks();
            if (blocks.Count > 0)
            {
                var chain = new Chain(_dataProvider, blocks);
                return chain;
            }

            return null;
        }

        /// <summary>
        /// Получение цепочки блоков из локального хранилища.
        /// </summary>
        /// <returns></returns>
        private Chain GetLocalChain()
        {
            var blocks = _localProvider.GetBlocks();
            if (blocks.Count > 0)
            {
                var chain = new Chain(_localProvider, blocks);
                return chain;
            }

            return null;
        }

        /// <summary>
        /// Добавить данные в цепочку блоков.
        /// </summary>
        /// <param name="text"> Добавляемые данные. </param>
        public Block AddContent(User user, string text, double money)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Текст не должен быть пустым или равен null.", nameof(text));
            }

            var data = new Data(text);
            var block = new Block(PreviousBlock, data, Session.GetCurrentUser(), user, money, _algorithm);

            AddBlock(block);

            return block;
        }
        
        /// <summary>
        /// Авторизоваться пользователем сети.
        /// </summary>
        /// <param name="login"> Логин. </param>
        /// <param name="password"> Пароль. </param>
        /// <returns> Пользователь сети. null если не удалось авторизоваться. </returns>
        public User LoginUser(string login, string password)
        {
            if (string.IsNullOrEmpty(login))
            {
                throw new ArgumentException("Логин не может быть пустым или равным null.", nameof(login));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Пароль не может быть пустым или равным null.", nameof(password));
            }

            BlockchainMSSQL.User user = _dataProvider.FindUser(login);

            if (user == null)
            {
                return null;
            }

            var passwordHash = password.GetHash();
            if (user.Password != passwordHash)
            {
                return null;
            }

           // Session.SetCurrentUser(user);

            return user;
        }
        
        /// <summary>
        /// Добавить блок.
        /// </summary>
        /// <param name="block"> Добавляемый блок. </param>
        private void AddBlock(Block block)
        {
            if (!block.IsCorrect())
            {
                throw new ArgumentException("Блок не корректный.", nameof(block));
            }

            // Не добавляем уже существующий блок.
            if (_blockChain.Any(b => b.Hash == block.Hash))
            {
                return;
            }
            
            _blockChain.Add(block);
            Session._curProvider.AddBlock(block.Version, block.CreatedOn, block.Hash, block.PreviousHash, block.Data.Content, block.UserFrom, block.UserTo, block.Money);
            //_localProvider.AddBlock(block.Version, block.CreatedOn, block.Hash, block.PreviousHash, block.Data.Content, block.UserFrom, block.UserTo);

            if (!CheckCorrect())
            {
                throw new ArgumentException("Была нарушена корректность после добавления блока.", nameof(Chain));
            }
        }
    }
}
