using BlockchainLibrary;
using BlockchainMSSQL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BlockchainForm
{
    public partial class NiceForm : MetroFramework.Forms.MetroForm
    {
        private IDataProvider _dataProvider = DataProviderHelper.GetDefaultDataProvider();

        private Chain _chain = new Chain();
        private Point curLocation;
        const int OFFSET = 10;

        private string curText = null;
        private MetroFramework.Controls.MetroPanel curPanel = null;
        private MetroFramework.Controls.MetroPanel curGrid = null;
        private User curUser = null;
        private User sessionUser = null;
        private double curMoney = 0.0;

        private Size GetSizePanel => new Size(300, 309);
        private Size GetSizeTxtMoney => new Size(75, 23);
        private Size GetSizeTxtUser => new Size(105, 23);
        private Size GetSizeTxtDateTime => new Size(107, 23);
        private Size GetSizeTxtHash => new Size(290, 23);
        private Size GetSizeTxtContent => new Size(290, 200);
        private Point GetLocationPanel => new Point(3, 3);
        private Point GetLocationTxtHash => new Point(4, 4);
        private Point GetLocationTxtContent => new Point(4, 33);
        private Point GetLocationTxtUser => new Point(4, 250);
        private Point GetLocationTxtMoney => new Point(110, 250);
        private Point GetLocationTxtDateTime => new Point(187, 250);
        private Point GetLocationTxtPrevHash => new Point(4, 281);

        public NiceForm()
        {
            InitializeComponent();
        }
        
        private void LoadData(BlockchainLibrary.Block block)
        {
            var panel = new MetroFramework.Controls.MetroPanel()
            {
                Anchor = (AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top),
                Size = GetSizePanel,
                Location = new System.Drawing.Point(curLocation.X, curLocation.Y),
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            };

            panel.Controls.Clear();

            var txtHash = new MetroFramework.Controls.MetroTextBox
            {
                Anchor = (AnchorStyles.Left | AnchorStyles.Top),
                Text = block.Hash,
                Enabled = false,
                ReadOnly = true,
                Size = new System.Drawing.Size() { Width = GetSizeTxtHash.Width, Height = GetSizeTxtHash.Height },
                Location = new System.Drawing.Point(GetLocationTxtHash.X, GetLocationTxtHash.Y)

            };
            panel.Controls.Add(txtHash);

            var txtContent = new MetroFramework.Controls.MetroTextBox
            {
                Anchor = (AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top),
                Text = block.Data.Content,
                Multiline = true,
                ReadOnly = true,
                Size = new System.Drawing.Size() { Width = GetSizeTxtContent.Width, Height = GetSizeTxtContent.Height },
                Location = new System.Drawing.Point(GetLocationTxtContent.X, GetLocationTxtContent.Y)
            };
            panel.Controls.Add(txtContent);

            var txtUser = new MetroFramework.Controls.MetroTextBox
            {
                Anchor = (AnchorStyles.Left | AnchorStyles.Bottom),
                Text = block.UserFrom.Login,
                ReadOnly = true,
                Size = new System.Drawing.Size() { Width = GetSizeTxtUser.Width, Height = GetSizeTxtUser.Height },
                Location = new System.Drawing.Point(GetLocationTxtUser.X, GetLocationTxtUser.Y)
            };
            panel.Controls.Add(txtUser);

            var txtMoney = new MetroFramework.Controls.MetroTextBox
            {
                Anchor = (AnchorStyles.Left | AnchorStyles.Bottom),
                Text = block.Money.ToString() + " $",
                ReadOnly = true,
                Size = new System.Drawing.Size() { Width = GetSizeTxtMoney.Width, Height = GetSizeTxtMoney.Height },
                Location = new System.Drawing.Point(GetLocationTxtMoney.X, GetLocationTxtMoney.Y)
            };
            panel.Controls.Add(txtMoney);

            var txtDateTime = new MetroFramework.Controls.MetroTextBox
            {
                Anchor = (AnchorStyles.Left | AnchorStyles.Bottom),
                Text = block.CreatedOn.ToString(),
                ReadOnly = true,
                Size = new System.Drawing.Size() { Width = GetSizeTxtDateTime.Width, Height = GetSizeTxtDateTime.Height },
                Location = new System.Drawing.Point(GetLocationTxtDateTime.X, GetLocationTxtDateTime.Y)
            };
            panel.Controls.Add(txtDateTime);
            
            var txtPrevHash = new MetroFramework.Controls.MetroTextBox
            {
                Anchor = (AnchorStyles.Left | AnchorStyles.Bottom),
                Text = block.PreviousHash,
                ReadOnly = true,
                Size = new System.Drawing.Size() { Width = GetSizeTxtHash.Width, Height = GetSizeTxtHash.Height },
                Location = new System.Drawing.Point(GetLocationTxtPrevHash.X, GetLocationTxtPrevHash.Y)
            };
            panel.Controls.Add(txtPrevHash);

            curGrid.Controls.Add(panel);
            curLocation = new Point(panel.Location.X + panel.Width + OFFSET, panel.Location.Y);
        }
        
        private void AddNewPanel()
        {
            var panel = new MetroFramework.Controls.MetroPanel()
            {
                Anchor = (AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top),
                Size = GetSizePanel,
                Location = new System.Drawing.Point(curLocation.X, curLocation.Y),
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            };

            panel.Controls.Clear();

            var txtHash = new MetroFramework.Controls.MetroTextBox
            {
                Anchor = (AnchorStyles.Left | AnchorStyles.Top),
                Text = "Рассчитываемый хеш блока будет здесь",
                Enabled = false,
                ReadOnly = true,
                Size = new System.Drawing.Size() { Width = GetSizeTxtHash.Width, Height = GetSizeTxtHash.Height },
                Location = new System.Drawing.Point(GetLocationTxtHash.X, GetLocationTxtHash.Y)

            };
            panel.Controls.Add(txtHash);

            var txtContent = new MetroFramework.Controls.MetroTextBox
            {
                Anchor = (AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top),
                Multiline = true,
                Size = new System.Drawing.Size() { Width = GetSizeTxtContent.Width, Height = GetSizeTxtContent.Height },
                Location = new System.Drawing.Point(GetLocationTxtContent.X, GetLocationTxtContent.Y)

            };
            txtContent.TextChanged += SaveText;
            panel.Controls.Add(txtContent);

            var users = _dataProvider.GetUsers().Where(x => x.UserId != sessionUser.UserId).ToList();
            var cmbUser = new MetroFramework.Controls.MetroComboBox
            {
                Anchor = (AnchorStyles.Left | AnchorStyles.Bottom),
                Name = "cmbUser",
                Size = new System.Drawing.Size() { Width = GetSizeTxtUser.Width + GetSizeTxtDateTime.Width + 2, Height = GetSizeTxtDateTime.Height },
                Location = new System.Drawing.Point(GetLocationTxtUser.X, GetLocationTxtUser.Y),
                DataSource = users,
                DisplayMember = "Login",
                ValueMember = "UserID"
            };
            cmbUser.SelectedItem = null;
            cmbUser.SelectedIndexChanged += SaveUser;
            panel.Controls.Add(cmbUser);

            var txtMoney = new MetroFramework.Controls.MetroTextBox
            {
                Anchor = (AnchorStyles.Left | AnchorStyles.Bottom),
                WaterMark = "Сумма",
                Name = "txtMoney",
                Size = new System.Drawing.Size() { Width = GetSizeTxtMoney.Width, Height = GetSizeTxtMoney.Height },
                Location = new System.Drawing.Point(GetLocationTxtMoney.X + GetSizeTxtDateTime.Width + 2, GetLocationTxtMoney.Y)
            };
            txtMoney.TextChanged += SaveMoney;
            panel.Controls.Add(txtMoney);

            var button = new MetroFramework.Controls.MetroButton()
            {
                Anchor = (AnchorStyles.Left | AnchorStyles.Bottom),
                Name = "button",
                Text = "Создать новый блок",
                Size = new System.Drawing.Size() { Width = GetSizeTxtHash.Width, Height = GetSizeTxtHash.Height },
                Location = new System.Drawing.Point(GetLocationTxtPrevHash.X, GetLocationTxtPrevHash.Y),
            };
            button.Click += CreateNewBlock;
            panel.Controls.Add(button);

            curGrid.Controls.Add(panel);
            curLocation = new Point(panel.Location.X + panel.Width + OFFSET, panel.Location.Y);
            curPanel = panel;
        }

        private void SaveText(object sender, EventArgs e)
        {
            curText = (sender as MetroFramework.Controls.MetroTextBox).Text;
        }
        private void SaveUser(object sender, EventArgs e)
        {
            curUser = (sender as MetroFramework.Controls.MetroComboBox).SelectedItem as User;
        }
        private void SaveMoney(object sender, EventArgs e)
        {
            var txt = (sender as MetroFramework.Controls.MetroTextBox);
            curMoney = 0.0;
            Double.TryParse(txt.Text, out curMoney);
        }

        private void CreateNewBlock(object sender, EventArgs e)
        {
            if (curUser == sessionUser) return;

            if (curUser == null)
            {
                MessageBox.Show("Выберите пользователя для транзакции!");
                return;
            }
            if (curText == string.Empty)
            {
                MessageBox.Show("Введите текст транзакции!");
                return;
            }
            if (curMoney > sessionUser.Money)
            {
                MessageBox.Show("Недостаточно средств для перевода!");
                return;
            }

            var block = _chain.AddContent(curUser, curText, curMoney);

            curPanel.Controls[0].Text = block.Hash;
            (curPanel.Controls[1] as MetroFramework.Controls.MetroTextBox).ReadOnly = true;

            foreach (Control item in curPanel.Controls)
            {
                if (item.Name == "button")
                {
                    curPanel.Controls.Remove(item);
                    break;
                }
            }
            foreach (Control item in curPanel.Controls)
            {
                if (item.Name == "cmbUser")
                {
                    curPanel.Controls.Remove(item);
                    break; 
                }
            }
            foreach (Control item in curPanel.Controls)
            {
                if (item.Name == "txtMoney")
                {
                    curPanel.Controls.Remove(item);
                    break;
                }
            }

            var txtUser = new MetroFramework.Controls.MetroTextBox
            {
                //Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top),
                Text = block.UserFrom.Login,
                ReadOnly = true,
                Size = new System.Drawing.Size() { Width = GetSizeTxtUser.Width, Height = GetSizeTxtUser.Height },
                Location = new System.Drawing.Point(GetLocationTxtUser.X, GetLocationTxtUser.Y)
            };
            curPanel.Controls.Add(txtUser);

            var txtMoney = new MetroFramework.Controls.MetroTextBox
            {
                Anchor = (AnchorStyles.Left | AnchorStyles.Bottom),
                Text = block.Money.ToString() + " $",
                Size = new System.Drawing.Size() { Width = GetSizeTxtMoney.Width, Height = GetSizeTxtMoney.Height },
                Location = new System.Drawing.Point(GetLocationTxtMoney.X, GetLocationTxtMoney.Y)
            };
            curPanel.Controls.Add(txtMoney);

            var txtDateTime = new MetroFramework.Controls.MetroTextBox
            {
                //Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top),
                Text = block.CreatedOn.ToString(),
                ReadOnly = true,
                Size = new System.Drawing.Size() { Width = GetSizeTxtDateTime.Width, Height = GetSizeTxtDateTime.Height },
                Location = new System.Drawing.Point(GetLocationTxtDateTime.X, GetLocationTxtDateTime.Y)
            };
            curPanel.Controls.Add(txtDateTime);

            var txtPrevHash = new TextBox
            {
                Text = block.PreviousHash,
                ReadOnly = true,
                Size = new System.Drawing.Size() { Width = GetSizeTxtHash.Width, Height = GetSizeTxtHash.Height },
                Location = new System.Drawing.Point(GetLocationTxtPrevHash.X, GetLocationTxtPrevHash.Y)
            };

            curPanel.Controls.Add(txtPrevHash);
            curLocation = new Point(curPanel.Location.X + curPanel.Width + OFFSET, curPanel.Location.Y);

            curText = string.Empty;
            AddNewPanel();
            UpdateMyMoney();
            this.Refresh();
        }

        private void UpdateMyMoney()
        {
            TxtMyMoney.Text = sessionUser.Money + " $";
        }

        private void GetNormalSizeForTabPages()
        {
            MainTabPages.ItemSize = new Size(MainTabPages.Width / 3 - 1, 40);
        }

        private void NiceForm_Load(object sender, EventArgs e)
        {
            sessionUser = Session.GetCurrentUser();
            UpdateMyMoney();
            MainTabPages_SelectedIndexChanged(null, null);
        }
        

        private void ClearPanels(MetroFramework.Controls.MetroPanel panel)
        {
            curGrid.HorizontalScroll.Value = 0;

            bool ok = true;

            do
            {
                ok = true;
                for (int i = 0; i < curGrid.Controls.Count; i++)
                {
                    if (curGrid.Controls[i] is MetroFramework.Controls.MetroPanel)
                    {
                        curGrid.Controls.RemoveAt(i);
                        ok = false;
                        break;
                    }
                }
            } while (ok == false);
        }

        private void FillGrid(List<BlockchainLibrary.Block> blocks, bool withAddNewPanel)
        {
            curLocation = GetLocationPanel;

            foreach (var block in blocks)
            {
                LoadData(block);
            }

            if (withAddNewPanel) AddNewPanel();
            GetNormalSizeForTabPages();
            curGrid.HorizontalScrollbar = true;
            curGrid.AutoScroll = true;
        }

        private void MainTabPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<BlockchainLibrary.Block> blocks = _chain.BlockChain.ToList();
            var widthAddPanel = false;

            if (MainTabPages.SelectedIndex == 0)
            {
                curGrid = GridPanel;
            }
            else if (MainTabPages.SelectedIndex == 1)
            {
                curGrid = MyOutcomePanel;
                blocks = blocks.Where(x => x.UserFrom.UserId == sessionUser.UserId).ToList();
                widthAddPanel = true;
            }
            else if (MainTabPages.SelectedIndex == 2)
            {
                curGrid = MyIncomePanel;
                blocks = blocks.Where(x => x.UserTo.UserId == sessionUser.UserId).ToList();
            }

            ClearPanels(curGrid);

            FillGrid(blocks, widthAddPanel);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (BtnCalc.Visible == false)
            {
                BtnAttack.Text = "Вернуть исходное состояние";
                MessageBox.Show("Измените содержание любого блока. Хэш блока изменится - вы сможете наблюдать процесс нарушения всей цепочки блоков начиная от корректируемого");
                BtnCalc.Visible = true;

                foreach (Control control in GridPanel.Controls)
                {
                    if (control is MetroFramework.Controls.MetroPanel)
                    {
                        var panel = control as MetroFramework.Controls.MetroPanel;
                        var txtContext = panel.Controls[1] as MetroFramework.Controls.MetroTextBox;
                        txtContext.ReadOnly = false;
                    }
                }
            }
            else
            {
                BtnAttack.Text = "Применить атаку с внедрением";
                BtnCalc.Visible = false;
                curGrid = GridPanel;
                _chain = new Chain();
                ClearPanels(curGrid);
                FillGrid(_chain.BlockChain.ToList(), false);
            }
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            BlockchainLibrary.Block[] blocks = new BlockchainLibrary.Block[_chain.Length];
            _chain.BlockChain.ToList().CopyTo(blocks);

            for (int i = 0, j = 0; i < GridPanel.Controls.Count && j < _chain.Length; i++)
            {
                if (GridPanel.Controls[i] is MetroFramework.Controls.MetroPanel)
                {
                    var panel = GridPanel.Controls[i] as MetroFramework.Controls.MetroPanel;
                    var txtHash = panel.Controls[0] as MetroFramework.Controls.MetroTextBox;
                    var txtContext = panel.Controls[1] as MetroFramework.Controls.MetroTextBox;

                    if (j > 0) blocks[j].SetprevHash(blocks[j - 1].GetHash());
                    blocks[j].SetData(txtContext.Text);
                    
                    if (blocks[j].IsCorrect() == false)
                    {
                        panel.UseCustomBackColor = true;
                        panel.BackColor = Color.PaleVioletRed;
                    }
                    else
                    {
                        panel.BackColor = SystemColors.Control;
                        panel.UseCustomBackColor = false;
                    }
                    txtHash.Text = blocks[j].GetHash();

                    j++;
                }
            }
        }
    }
}
