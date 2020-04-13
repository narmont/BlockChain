using BlockchainLibrary;
using BlockchainMSSQL;
using System;
using System.Windows.Forms;

namespace BlockchainForm
{
    public partial class AuthForm : MetroFramework.Forms.MetroForm
    {
        private const double START_MONEY_USER = 45.0;
        
        public AuthForm()
        {
            InitializeComponent();
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            Chain c = new Chain();
            CmbUsers.DataSource = Session._curProvider.GetUsers();
            CmbUsers.ValueMember = "UserId";
            CmbUsers.DisplayMember = "Login";
        }

        private void BtnRegistration_Click(object sender, EventArgs e)
        {
            using (RegistrationForm form = new RegistrationForm())
            {
               
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Session._curProvider.AddUser(form.TxtLogin.Text, form.TxtPassword.Text, START_MONEY_USER);
                    LoadUsers();
                    MessageBox.Show("Вы успешно зарегистрированы! Используйте свои данные для входа");
                }
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            User user = null;
            user = Session._curProvider.FindUser(CmbUsers.Text, TxtPassword.Text);

            if (user == null)
            {
                MessageBox.Show("Пользователь с данным логином и паролем не найден!");
                return;
            }

            Session.SetCurrentUser(user);

            using (NiceForm form = new NiceForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    
                }
            }
        }
    }
}
