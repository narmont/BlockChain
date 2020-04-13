namespace BlockchainForm
{
    partial class NiceForm
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
            this.MainTabPages = new MetroFramework.Controls.MetroTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.MyOutcomePanel = new MetroFramework.Controls.MetroPanel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.MyIncomePanel = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.TxtMyMoney = new MetroFramework.Controls.MetroLabel();
            this.BtnAttack = new MetroFramework.Controls.MetroButton();
            this.BtnCalc = new MetroFramework.Controls.MetroButton();
            this.GridPanel = new MetroFramework.Controls.MetroPanel();
            this.MainTabPages.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabPages
            // 
            this.MainTabPages.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.MainTabPages.Controls.Add(this.tabPage1);
            this.MainTabPages.Controls.Add(this.tabPage2);
            this.MainTabPages.Controls.Add(this.tabPage3);
            this.MainTabPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabPages.Location = new System.Drawing.Point(20, 60);
            this.MainTabPages.Name = "MainTabPages";
            this.MainTabPages.SelectedIndex = 0;
            this.MainTabPages.Size = new System.Drawing.Size(909, 388);
            this.MainTabPages.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.MainTabPages.TabIndex = 0;
            this.MainTabPages.UseSelectable = true;
            this.MainTabPages.SelectedIndexChanged += new System.EventHandler(this.MainTabPages_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GridPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(901, 346);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Общая цепочка";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.MyOutcomePanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(901, 346);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Мои отправления";
            // 
            // MyOutcomePanel
            // 
            this.MyOutcomePanel.AutoScroll = true;
            this.MyOutcomePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyOutcomePanel.HorizontalScrollbar = true;
            this.MyOutcomePanel.HorizontalScrollbarBarColor = true;
            this.MyOutcomePanel.HorizontalScrollbarHighlightOnWheel = false;
            this.MyOutcomePanel.HorizontalScrollbarSize = 10;
            this.MyOutcomePanel.Location = new System.Drawing.Point(0, 0);
            this.MyOutcomePanel.Name = "MyOutcomePanel";
            this.MyOutcomePanel.Size = new System.Drawing.Size(901, 346);
            this.MyOutcomePanel.TabIndex = 4;
            this.MyOutcomePanel.VerticalScrollbar = true;
            this.MyOutcomePanel.VerticalScrollbarBarColor = false;
            this.MyOutcomePanel.VerticalScrollbarHighlightOnWheel = false;
            this.MyOutcomePanel.VerticalScrollbarSize = 10;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.MyIncomePanel);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(901, 346);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Мои поступления";
            // 
            // MyIncomePanel
            // 
            this.MyIncomePanel.AutoScroll = true;
            this.MyIncomePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyIncomePanel.HorizontalScrollbar = true;
            this.MyIncomePanel.HorizontalScrollbarBarColor = true;
            this.MyIncomePanel.HorizontalScrollbarHighlightOnWheel = false;
            this.MyIncomePanel.HorizontalScrollbarSize = 10;
            this.MyIncomePanel.Location = new System.Drawing.Point(0, 0);
            this.MyIncomePanel.Name = "MyIncomePanel";
            this.MyIncomePanel.Size = new System.Drawing.Size(901, 346);
            this.MyIncomePanel.TabIndex = 5;
            this.MyIncomePanel.VerticalScrollbar = true;
            this.MyIncomePanel.VerticalScrollbarBarColor = false;
            this.MyIncomePanel.VerticalScrollbarHighlightOnWheel = false;
            this.MyIncomePanel.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(780, 38);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(72, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Мой счет:";
            // 
            // TxtMyMoney
            // 
            this.TxtMyMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtMyMoney.AutoSize = true;
            this.TxtMyMoney.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.TxtMyMoney.Location = new System.Drawing.Point(863, 38);
            this.TxtMyMoney.Name = "TxtMyMoney";
            this.TxtMyMoney.Size = new System.Drawing.Size(33, 19);
            this.TxtMyMoney.TabIndex = 2;
            this.TxtMyMoney.Text = "null";
            // 
            // BtnAttack
            // 
            this.BtnAttack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAttack.Location = new System.Drawing.Point(583, 34);
            this.BtnAttack.Name = "BtnAttack";
            this.BtnAttack.Size = new System.Drawing.Size(191, 23);
            this.BtnAttack.TabIndex = 3;
            this.BtnAttack.Text = "Применить атаку с внедрением";
            this.BtnAttack.UseSelectable = true;
            this.BtnAttack.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // BtnCalc
            // 
            this.BtnCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCalc.Location = new System.Drawing.Point(435, 34);
            this.BtnCalc.Name = "BtnCalc";
            this.BtnCalc.Size = new System.Drawing.Size(142, 23);
            this.BtnCalc.TabIndex = 4;
            this.BtnCalc.Text = "Перерасчитать блоки";
            this.BtnCalc.UseSelectable = true;
            this.BtnCalc.Visible = false;
            this.BtnCalc.Click += new System.EventHandler(this.BtnCalc_Click);
            // 
            // GridPanel
            // 
            this.GridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridPanel.HorizontalScrollbarBarColor = false;
            this.GridPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.GridPanel.HorizontalScrollbarSize = 10;
            this.GridPanel.Location = new System.Drawing.Point(0, 0);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(901, 346);
            this.GridPanel.TabIndex = 3;
            this.GridPanel.VerticalScrollbarBarColor = false;
            this.GridPanel.VerticalScrollbarHighlightOnWheel = false;
            this.GridPanel.VerticalScrollbarSize = 10;
            // 
            // NiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 468);
            this.Controls.Add(this.BtnCalc);
            this.Controls.Add(this.BtnAttack);
            this.Controls.Add(this.TxtMyMoney);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.MainTabPages);
            this.Name = "NiceForm";
            this.Text = "Демонстрация технологии Blockchain";
            this.Load += new System.EventHandler(this.NiceForm_Load);
            this.MainTabPages.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl MainTabPages;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private MetroFramework.Controls.MetroPanel MyOutcomePanel;
        private MetroFramework.Controls.MetroPanel MyIncomePanel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel TxtMyMoney;
        private MetroFramework.Controls.MetroButton BtnAttack;
        private MetroFramework.Controls.MetroButton BtnCalc;
        private MetroFramework.Controls.MetroPanel GridPanel;
    }
}