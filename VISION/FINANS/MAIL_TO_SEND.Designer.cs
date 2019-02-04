namespace VISION.FINANS
{
    partial class MAIL_TO_SEND
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAIL_TO_SEND));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LB_KIME = new System.Windows.Forms.Label();
            this.BTN_VAZGEC = new DevExpress.XtraEditors.SimpleButton();
            this.BTN_TAMAM = new DevExpress.XtraEditors.SimpleButton();
            this.txt_TO = new System.Windows.Forms.TextBox();
            this.txt_SUBJECT = new DevExpress.XtraEditors.TextEdit();
            this.txt_DETAIL = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SUBJECT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DETAIL.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Açıklama";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Konu";
            // 
            // LB_KIME
            // 
            this.LB_KIME.AutoSize = true;
            this.LB_KIME.Location = new System.Drawing.Point(9, 26);
            this.LB_KIME.Name = "LB_KIME";
            this.LB_KIME.Size = new System.Drawing.Size(29, 13);
            this.LB_KIME.TabIndex = 12;
            this.LB_KIME.Text = "Kime";
            // 
            // BTN_VAZGEC
            // 
            this.BTN_VAZGEC.Image = ((System.Drawing.Image)(resources.GetObject("BTN_VAZGEC.Image")));
            this.BTN_VAZGEC.Location = new System.Drawing.Point(162, 133);
            this.BTN_VAZGEC.Name = "BTN_VAZGEC";
            this.BTN_VAZGEC.Size = new System.Drawing.Size(92, 36);
            this.BTN_VAZGEC.TabIndex = 13;
            this.BTN_VAZGEC.Text = "Vazgeç";
            this.BTN_VAZGEC.Click += new System.EventHandler(this.BTN_VAZGEC_Click);
            // 
            // BTN_TAMAM
            // 
            this.BTN_TAMAM.Image = ((System.Drawing.Image)(resources.GetObject("BTN_TAMAM.Image")));
            this.BTN_TAMAM.Location = new System.Drawing.Point(260, 133);
            this.BTN_TAMAM.Name = "BTN_TAMAM";
            this.BTN_TAMAM.Size = new System.Drawing.Size(92, 36);
            this.BTN_TAMAM.TabIndex = 11;
            this.BTN_TAMAM.Text = "Gönder";
            this.BTN_TAMAM.Click += new System.EventHandler(this.BTN_TAMAM_Click);
            // 
            // txt_TO
            // 
            this.txt_TO.Location = new System.Drawing.Point(63, 23);
            this.txt_TO.Name = "txt_TO";
            this.txt_TO.Size = new System.Drawing.Size(289, 21);
            this.txt_TO.TabIndex = 8;
            // 
            // txt_SUBJECT
            // 
            this.txt_SUBJECT.Location = new System.Drawing.Point(63, 49);
            this.txt_SUBJECT.Name = "txt_SUBJECT";
            this.txt_SUBJECT.Size = new System.Drawing.Size(289, 20);
            this.txt_SUBJECT.TabIndex = 9;
            // 
            // txt_DETAIL
            // 
            this.txt_DETAIL.Location = new System.Drawing.Point(63, 75);
            this.txt_DETAIL.Name = "txt_DETAIL";
            this.txt_DETAIL.Size = new System.Drawing.Size(289, 52);
            this.txt_DETAIL.TabIndex = 10;
            // 
            // MAIL_TO_SEND
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 181);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LB_KIME);
            this.Controls.Add(this.BTN_VAZGEC);
            this.Controls.Add(this.BTN_TAMAM);
            this.Controls.Add(this.txt_TO);
            this.Controls.Add(this.txt_SUBJECT);
            this.Controls.Add(this.txt_DETAIL);
            this.Name = "MAIL_TO_SEND";
            this.Text = "Fatura Gönder";
            ((System.ComponentModel.ISupportInitialize)(this.txt_SUBJECT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DETAIL.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LB_KIME;
        private DevExpress.XtraEditors.SimpleButton BTN_VAZGEC;
        private DevExpress.XtraEditors.SimpleButton BTN_TAMAM;
        private System.Windows.Forms.TextBox txt_TO;
        private DevExpress.XtraEditors.TextEdit txt_SUBJECT;
        private DevExpress.XtraEditors.MemoEdit txt_DETAIL;
    }
}