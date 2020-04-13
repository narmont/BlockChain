namespace BlockchainForm
{
    partial class RegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtPassword = new MetroFramework.Controls.MetroTextBox();
            this.LblPassword = new MetroFramework.Controls.MetroLabel();
            this.LblUser = new MetroFramework.Controls.MetroLabel();
            this.TxtLogin = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // TxtPassword
            // 
            // 
            // 
            // 
            this.TxtPassword.CustomButton.Image = null;
            this.TxtPassword.CustomButton.Location = new System.Drawing.Point(232, 1);
            this.TxtPassword.CustomButton.Name = "";
            this.TxtPassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxtPassword.CustomButton.TabIndex = 1;
            this.TxtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxtPassword.CustomButton.UseSelectable = true;
            this.TxtPassword.CustomButton.Visible = false;
            this.TxtPassword.Lines = new string[0];
            this.TxtPassword.Location = new System.Drawing.Point(86, 61);
            this.TxtPassword.MaxLength = 32767;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '\0';
            this.TxtPassword.WaterMark = "Введите ваш пароль...";
            this.TxtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtPassword.SelectedText = "";
            this.TxtPassword.SelectionLength = 0;
            this.TxtPassword.SelectionStart = 0;
            this.TxtPassword.ShortcutsEnabled = true;
            this.TxtPassword.Size = new System.Drawing.Size(254, 23);
            this.TxtPassword.TabIndex = 7;
            this.TxtPassword.UseSelectable = true;
            this.TxtPassword.WaterMark = "Введите ваш пароль...";
            this.TxtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Location = new System.Drawing.Point(23, 65);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(57, 19);
            this.LblPassword.TabIndex = 6;
            this.LblPassword.Text = "Пароль:";
            // 
            // LblUser
            // 
            this.LblUser.AutoSize = true;
            this.LblUser.Location = new System.Drawing.Point(23, 30);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(50, 19);
            this.LblUser.TabIndex = 5;
            this.LblUser.Text = "Логин:";
            // 
            // TxtLogin
            // 
            // 
            // 
            // 
            this.TxtLogin.CustomButton.Image = null;
            this.TxtLogin.CustomButton.Location = new System.Drawing.Point(232, 1);
            this.TxtLogin.CustomButton.Name = "";
            this.TxtLogin.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxtLogin.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxtLogin.CustomButton.TabIndex = 1;
            this.TxtLogin.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxtLogin.CustomButton.UseSelectable = true;
            this.TxtLogin.CustomButton.Visible = false;
            this.TxtLogin.Lines = new string[0];
            this.TxtLogin.Location = new System.Drawing.Point(86, 26);
            this.TxtLogin.MaxLength = 32767;
            this.TxtLogin.Name = "TxtLogin";
            this.TxtLogin.PasswordChar = '\0';
            this.TxtLogin.WaterMark = "Введите ваш логин...";
            this.TxtLogin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtLogin.SelectedText = "";
            this.TxtLogin.SelectionLength = 0;
            this.TxtLogin.SelectionStart = 0;
            this.TxtLogin.ShortcutsEnabled = true;
            this.TxtLogin.Size = new System.Drawing.Size(254, 23);
            this.TxtLogin.TabIndex = 8;
            this.TxtLogin.UseSelectable = true;
            this.TxtLogin.WaterMark = "Введите ваш логин...";
            this.TxtLogin.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxtLogin.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton1
            // 
            this.metroButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.metroButton1.Location = new System.Drawing.Point(210, 101);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(130, 23);
            this.metroButton1.TabIndex = 9;
            this.metroButton1.Text = "Зарегистрироваться";
            this.metroButton1.UseSelectable = true;
            // 
            // metroButton2
            // 
            this.metroButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.metroButton2.Location = new System.Drawing.Point(23, 101);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(76, 23);
            this.metroButton2.TabIndex = 10;
            this.metroButton2.Text = "Отмена";
            this.metroButton2.UseSelectable = true;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 147);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.TxtLogin);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.LblPassword);
            this.Controls.Add(this.LblUser);
            this.DisplayHeader = false;
            this.Name = "RegistrationForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.Text = "RegistrationForm";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel LblPassword;
        private MetroFramework.Controls.MetroLabel LblUser;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        public MetroFramework.Controls.MetroTextBox TxtLogin;
        public MetroFramework.Controls.MetroTextBox TxtPassword;
    }
}