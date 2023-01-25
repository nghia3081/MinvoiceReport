using System.Windows.Forms;
namespace MinvoiceReport
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.loginBtn = new System.Windows.Forms.Button();
            this.taxCodeLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.logoPanel = new System.Windows.Forms.PictureBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.taxCodeTxt = new System.Windows.Forms.TextBox();
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(227, 199);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(101, 31);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "Đăng nhập";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // taxCodeLabel
            // 
            this.taxCodeLabel.AutoSize = true;
            this.taxCodeLabel.Location = new System.Drawing.Point(70, 99);
            this.taxCodeLabel.Name = "taxCodeLabel";
            this.taxCodeLabel.Size = new System.Drawing.Size(72, 16);
            this.taxCodeLabel.TabIndex = 4;
            this.taxCodeLabel.Text = "Mã số thuế";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(70, 172);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(61, 16);
            this.passwordLabel.TabIndex = 6;
            this.passwordLabel.Text = "Mật khẩu";
            this.passwordLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // logoPanel
            // 
            this.logoPanel.ErrorImage = global::Report.Properties.Resources.lginvoice_01;
            this.logoPanel.Image = global::Report.Properties.Resources.lginvoice_01;
            this.logoPanel.InitialImage = global::Report.Properties.Resources.lginvoice_01;
            this.logoPanel.Location = new System.Drawing.Point(3, -10);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(538, 125);
            this.logoPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPanel.TabIndex = 7;
            this.logoPanel.TabStop = false;
            this.logoPanel.Click += new System.EventHandler(this.logoPanel_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(70, 135);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(67, 16);
            this.usernameLabel.TabIndex = 5;
            this.usernameLabel.Text = "Tài khoản";
            // 
            // taxCodeTxt
            // 
            this.taxCodeTxt.Location = new System.Drawing.Point(173, 96);
            this.taxCodeTxt.Name = "taxCodeTxt";
            this.taxCodeTxt.Size = new System.Drawing.Size(228, 22);
            this.taxCodeTxt.TabIndex = 8;
            // 
            // usernameTxt
            // 
            this.usernameTxt.Location = new System.Drawing.Point(173, 132);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(228, 22);
            this.usernameTxt.TabIndex = 9;
            // 
            // passwordTxt
            // 
            this.passwordTxt.Location = new System.Drawing.Point(173, 169);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.PasswordChar = '*';
            this.passwordTxt.Size = new System.Drawing.Size(228, 22);
            this.passwordTxt.TabIndex = 10;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(529, 268);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.usernameTxt);
            this.Controls.Add(this.taxCodeTxt);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.taxCodeLabel);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.logoPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "M-Invoice Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)(this.logoPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button loginBtn;
        private Label taxCodeLabel;
        private Label passwordLabel;
        private PictureBox logoPanel;
        private Label usernameLabel;
        private TextBox taxCodeTxt;
        private TextBox usernameTxt;
        private TextBox passwordTxt;
    }
}