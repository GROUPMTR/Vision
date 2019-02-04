namespace Setups
{
    partial class Masters
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TEXT_DB = new System.Windows.Forms.TextBox();
            this.TEXT_PASSWORD = new System.Windows.Forms.TextBox();
            this.TEXT_LOGIN = new System.Windows.Forms.TextBox();
            this.TXT_SERVER = new System.Windows.Forms.TextBox();
            this.br_KAPAT = new System.Windows.Forms.Button();
            this.br_KAYDET = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Data Base";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Server";
            // 
            // TEXT_DB
            // 
            this.TEXT_DB.Location = new System.Drawing.Point(132, 112);
            this.TEXT_DB.Name = "TEXT_DB";
            this.TEXT_DB.Size = new System.Drawing.Size(225, 21);
            this.TEXT_DB.TabIndex = 25;
            // 
            // TEXT_PASSWORD
            // 
            this.TEXT_PASSWORD.Location = new System.Drawing.Point(132, 85);
            this.TEXT_PASSWORD.Name = "TEXT_PASSWORD";
            this.TEXT_PASSWORD.Size = new System.Drawing.Size(225, 21);
            this.TEXT_PASSWORD.TabIndex = 24;
            // 
            // TEXT_LOGIN
            // 
            this.TEXT_LOGIN.Location = new System.Drawing.Point(132, 58);
            this.TEXT_LOGIN.Name = "TEXT_LOGIN";
            this.TEXT_LOGIN.Size = new System.Drawing.Size(225, 21);
            this.TEXT_LOGIN.TabIndex = 23;
            // 
            // TXT_SERVER
            // 
            this.TXT_SERVER.Location = new System.Drawing.Point(132, 31);
            this.TXT_SERVER.Name = "TXT_SERVER";
            this.TXT_SERVER.Size = new System.Drawing.Size(225, 21);
            this.TXT_SERVER.TabIndex = 22;
            // 
            // br_KAPAT
            // 
            this.br_KAPAT.Location = new System.Drawing.Point(201, 138);
            this.br_KAPAT.Name = "br_KAPAT";
            this.br_KAPAT.Size = new System.Drawing.Size(75, 23);
            this.br_KAPAT.TabIndex = 21;
            this.br_KAPAT.Text = "KAPAT";
            this.br_KAPAT.UseVisualStyleBackColor = true;
            this.br_KAPAT.Click += new System.EventHandler(this.br_KAPAT_Click);
            // 
            // br_KAYDET
            // 
            this.br_KAYDET.Location = new System.Drawing.Point(282, 138);
            this.br_KAYDET.Name = "br_KAYDET";
            this.br_KAYDET.Size = new System.Drawing.Size(75, 23);
            this.br_KAYDET.TabIndex = 20;
            this.br_KAYDET.Text = "KAYDET";
            this.br_KAYDET.UseVisualStyleBackColor = true;
            this.br_KAYDET.Click += new System.EventHandler(this.br_KAYDET_Click);
            // 
            // Masters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 193);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TEXT_DB);
            this.Controls.Add(this.TEXT_PASSWORD);
            this.Controls.Add(this.TEXT_LOGIN);
            this.Controls.Add(this.TXT_SERVER);
            this.Controls.Add(this.br_KAPAT);
            this.Controls.Add(this.br_KAYDET);
            this.Name = "Masters";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TEXT_DB;
        private System.Windows.Forms.TextBox TEXT_PASSWORD;
        private System.Windows.Forms.TextBox TEXT_LOGIN;
        private System.Windows.Forms.TextBox TXT_SERVER;
        private System.Windows.Forms.Button br_KAPAT;
        private System.Windows.Forms.Button br_KAYDET;

    }
}

