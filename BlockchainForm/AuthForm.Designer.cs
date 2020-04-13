namespace BlockchainForm
{
    partial class AuthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            this.LblUser = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.TxtPassword = new MetroFramework.Controls.MetroTextBox();
            this.CmbUsers = new MetroFramework.Controls.MetroComboBox();
            this.LblPassword = new MetroFramework.Controls.MetroLabel();
            this.BtnExit = new MetroFramework.Controls.MetroButton();
            this.BtnRegistration = new MetroFramework.Controls.MetroButton();
            this.BtnEnter = new MetroFramework.Controls.MetroButton();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblUser
            // 
            this.LblUser.AutoSize = true;
            this.LblUser.Location = new System.Drawing.Point(3, 17);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(50, 19);
            this.LblUser.TabIndex = 0;
            this.LblUser.Text = "Логин:";
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.TxtPassword);
            this.metroPanel1.Controls.Add(this.CmbUsers);
            this.metroPanel1.Controls.Add(this.LblPassword);
            this.metroPanel1.Controls.Add(this.LblUser);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(24, 25);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(325, 81);
            this.metroPanel1.TabIndex = 1;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
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
            this.TxtPassword.Location = new System.Drawing.Point(66, 48);
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
            this.TxtPassword.TabIndex = 4;
            this.TxtPassword.UseSelectable = true;
            this.TxtPassword.WaterMark = "Введите ваш пароль...";
            this.TxtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // CmbUsers
            // 
            this.CmbUsers.FormattingEnabled = true;
            this.CmbUsers.ItemHeight = 23;
            this.CmbUsers.Location = new System.Drawing.Point(66, 7);
            this.CmbUsers.Name = "CmbUsers";
            this.CmbUsers.PromptText = "Выберите пользователя...";
            this.CmbUsers.Size = new System.Drawing.Size(254, 29);
            this.CmbUsers.TabIndex = 3;
            this.CmbUsers.UseSelectable = true;
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Location = new System.Drawing.Point(3, 52);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(57, 19);
            this.LblPassword.TabIndex = 2;
            this.LblPassword.Text = "Пароль:";
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(24, 127);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(87, 23);
            this.BtnExit.TabIndex = 10;
            this.BtnExit.Text = "Выход";
            this.BtnExit.UseSelectable = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnRegistration
            // 
            this.BtnRegistration.Location = new System.Drawing.Point(147, 127);
            this.BtnRegistration.Name = "BtnRegistration";
            this.BtnRegistration.Size = new System.Drawing.Size(87, 23);
            this.BtnRegistration.TabIndex = 9;
            this.BtnRegistration.Text = "Регистрация";
            this.BtnRegistration.UseSelectable = true;
            this.BtnRegistration.Click += new System.EventHandler(this.BtnRegistration_Click);
            // 
            // BtnEnter
            // 
            this.BtnEnter.Location = new System.Drawing.Point(240, 127);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(109, 23);
            this.BtnEnter.TabIndex = 8;
            this.BtnEnter.Text = "Войти в систему";
            this.BtnEnter.UseSelectable = true;
            this.BtnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 161);
            this.ControlBox = false;
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnRegistration);
            this.Controls.Add(this.BtnEnter);
            this.Controls.Add(this.metroPanel1);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AuthForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.Text = "AuthForm";
            this.Load += new System.EventHandler(this.AuthForm_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel LblUser;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTextBox TxtPassword;
        private MetroFramework.Controls.MetroComboBox CmbUsers;
        private MetroFramework.Controls.MetroLabel LblPassword;
        private MetroFramework.Controls.MetroButton BtnExit;
        private MetroFramework.Controls.MetroButton BtnRegistration;
        private MetroFramework.Controls.MetroButton BtnEnter;
    }
}