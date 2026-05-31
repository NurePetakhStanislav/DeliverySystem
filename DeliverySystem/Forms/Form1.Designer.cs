namespace DeliverySystem
{
    partial class Form1
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
            textBoxLogin = new TextBox();
            textBoxPassword = new TextBox();
            buttonAgree = new Button();
            SuspendLayout();
            // 
            // textBoxLogin
            // 
            textBoxLogin.Font = new Font("Segoe UI", 12F);
            textBoxLogin.Location = new Point(36, 12);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.PlaceholderText = "Nickname";
            textBoxLogin.Size = new Size(222, 34);
            textBoxLogin.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI", 12F);
            textBoxPassword.Location = new Point(36, 52);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PlaceholderText = "Password";
            textBoxPassword.Size = new Size(222, 34);
            textBoxPassword.TabIndex = 1;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonAgree
            // 
            buttonAgree.Location = new Point(86, 92);
            buttonAgree.Name = "buttonAgree";
            buttonAgree.Size = new Size(114, 36);
            buttonAgree.TabIndex = 2;
            buttonAgree.Text = "Registration";
            buttonAgree.UseVisualStyleBackColor = true;
            buttonAgree.Click += buttonAgree_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(303, 136);
            Controls.Add(buttonAgree);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxLogin);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Button buttonAgree;
    }
}
