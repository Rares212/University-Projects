
namespace Imobiliare
{
    partial class Register
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
            this.lableUsername = new System.Windows.Forms.Label();
            this.textRegPassword = new System.Windows.Forms.TextBox();
            this.textRegUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textRegEmail = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textRegPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textRegName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textRegSurname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelRegDebug = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lableUsername
            // 
            this.lableUsername.AutoSize = true;
            this.lableUsername.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableUsername.Location = new System.Drawing.Point(156, 216);
            this.lableUsername.Name = "lableUsername";
            this.lableUsername.Size = new System.Drawing.Size(63, 14);
            this.lableUsername.TabIndex = 7;
            this.lableUsername.Text = "Username";
            // 
            // textRegPassword
            // 
            this.textRegPassword.Location = new System.Drawing.Point(225, 257);
            this.textRegPassword.MaxLength = 16;
            this.textRegPassword.Name = "textRegPassword";
            this.textRegPassword.PasswordChar = '*';
            this.textRegPassword.Size = new System.Drawing.Size(124, 20);
            this.textRegPassword.TabIndex = 6;
            // 
            // textRegUsername
            // 
            this.textRegUsername.Location = new System.Drawing.Point(225, 213);
            this.textRegUsername.MaxLength = 255;
            this.textRegUsername.Name = "textRegUsername";
            this.textRegUsername.Size = new System.Drawing.Size(124, 20);
            this.textRegUsername.TabIndex = 5;
            this.textRegUsername.TextChanged += new System.EventHandler(this.textUsername_TextChanged);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(156, 260);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(59, 14);
            this.labelPassword.TabIndex = 8;
            this.labelPassword.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(156, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Email";
            // 
            // textRegEmail
            // 
            this.textRegEmail.Location = new System.Drawing.Point(225, 170);
            this.textRegEmail.MaxLength = 255;
            this.textRegEmail.Name = "textRegEmail";
            this.textRegEmail.Size = new System.Drawing.Size(124, 20);
            this.textRegEmail.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(345, 329);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Create Account";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(285, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 28);
            this.label3.TabIndex = 12;
            this.label3.Text = "Register your account";
            // 
            // textRegPhone
            // 
            this.textRegPhone.Location = new System.Drawing.Point(504, 167);
            this.textRegPhone.MaxLength = 15;
            this.textRegPhone.Name = "textRegPhone";
            this.textRegPhone.Size = new System.Drawing.Size(124, 20);
            this.textRegPhone.TabIndex = 13;
            this.textRegPhone.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(414, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 14);
            this.label2.TabIndex = 14;
            this.label2.Text = "Phone number";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textRegName
            // 
            this.textRegName.Location = new System.Drawing.Point(504, 213);
            this.textRegName.MaxLength = 255;
            this.textRegName.Name = "textRegName";
            this.textRegName.Size = new System.Drawing.Size(124, 20);
            this.textRegName.TabIndex = 15;
            this.textRegName.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(414, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "Name";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textRegSurname
            // 
            this.textRegSurname.Location = new System.Drawing.Point(504, 257);
            this.textRegSurname.MaxLength = 255;
            this.textRegSurname.Name = "textRegSurname";
            this.textRegSurname.Size = new System.Drawing.Size(124, 20);
            this.textRegSurname.TabIndex = 17;
            this.textRegSurname.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(414, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 14);
            this.label5.TabIndex = 18;
            this.label5.Text = "Surname";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // labelRegDebug
            // 
            this.labelRegDebug.AutoSize = true;
            this.labelRegDebug.Location = new System.Drawing.Point(401, 399);
            this.labelRegDebug.Name = "labelRegDebug";
            this.labelRegDebug.Size = new System.Drawing.Size(10, 13);
            this.labelRegDebug.TabIndex = 19;
            this.labelRegDebug.Text = "-";
            this.labelRegDebug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(364, 358);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelRegDebug);
            this.Controls.Add(this.textRegSurname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textRegName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textRegPhone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textRegEmail);
            this.Controls.Add(this.lableUsername);
            this.Controls.Add(this.textRegPassword);
            this.Controls.Add(this.textRegUsername);
            this.Controls.Add(this.labelPassword);
            this.Name = "Register";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lableUsername;
        private System.Windows.Forms.TextBox textRegPassword;
        private System.Windows.Forms.TextBox textRegUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textRegEmail;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textRegPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textRegName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textRegSurname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelRegDebug;
        private System.Windows.Forms.Button button1;
    }
}