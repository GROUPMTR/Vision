namespace VISION.FINANS.MUHASEBE_AKTARIMI_MANUEL.ALIM
{
    partial class AKTARIM_PARAMETRESI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AKTARIM_PARAMETRESI));
            this.label6 = new System.Windows.Forms.Label();
            this.CMB_E_FATURA_SERISI = new DevExpress.XtraEditors.ComboBoxEdit();
            this.rd_TICARI = new System.Windows.Forms.RadioButton();
            this.rd_TEMEL = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtEdit_TARIH = new DevExpress.XtraEditors.DateEdit();
            this.BTN_VAZGEC = new DevExpress.XtraEditors.SimpleButton();
            this.BTN_TAMAM = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.CMB_E_FATURA_SERISI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdit_TARIH.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdit_TARIH.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "e-Fatura Serisi";
            // 
            // CMB_E_FATURA_SERISI
            // 
            this.CMB_E_FATURA_SERISI.Location = new System.Drawing.Point(93, 12);
            this.CMB_E_FATURA_SERISI.Name = "CMB_E_FATURA_SERISI";
            this.CMB_E_FATURA_SERISI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CMB_E_FATURA_SERISI.Size = new System.Drawing.Size(157, 20);
            this.CMB_E_FATURA_SERISI.TabIndex = 39;
            // 
            // rd_TICARI
            // 
            this.rd_TICARI.AutoSize = true;
            this.rd_TICARI.Location = new System.Drawing.Point(197, 39);
            this.rd_TICARI.Name = "rd_TICARI";
            this.rd_TICARI.Size = new System.Drawing.Size(53, 17);
            this.rd_TICARI.TabIndex = 38;
            this.rd_TICARI.Text = "Temel";
            this.rd_TICARI.UseVisualStyleBackColor = true;
            // 
            // rd_TEMEL
            // 
            this.rd_TEMEL.AutoSize = true;
            this.rd_TEMEL.Checked = true;
            this.rd_TEMEL.Location = new System.Drawing.Point(93, 39);
            this.rd_TEMEL.Name = "rd_TEMEL";
            this.rd_TEMEL.Size = new System.Drawing.Size(50, 17);
            this.rd_TEMEL.TabIndex = 37;
            this.rd_TEMEL.TabStop = true;
            this.rd_TEMEL.Text = "Ticari";
            this.rd_TEMEL.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Fatura Türü";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Tarih";
            // 
            // dtEdit_TARIH
            // 
            this.dtEdit_TARIH.EditValue = null;
            this.dtEdit_TARIH.Location = new System.Drawing.Point(93, 62);
            this.dtEdit_TARIH.Name = "dtEdit_TARIH";
            this.dtEdit_TARIH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdit_TARIH.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdit_TARIH.Size = new System.Drawing.Size(157, 20);
            this.dtEdit_TARIH.TabIndex = 30;
            // 
            // BTN_VAZGEC
            // 
            this.BTN_VAZGEC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTN_VAZGEC.ImageOptions.Image")));
            this.BTN_VAZGEC.Location = new System.Drawing.Point(64, 88);
            this.BTN_VAZGEC.Name = "BTN_VAZGEC";
            this.BTN_VAZGEC.Size = new System.Drawing.Size(90, 40);
            this.BTN_VAZGEC.TabIndex = 33;
            this.BTN_VAZGEC.Text = "Vazgeç";
            this.BTN_VAZGEC.Click += new System.EventHandler(this.BTN_VAZGEC_Click);
            // 
            // BTN_TAMAM
            // 
            this.BTN_TAMAM.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTN_TAMAM.ImageOptions.Image")));
            this.BTN_TAMAM.Location = new System.Drawing.Point(160, 88);
            this.BTN_TAMAM.Name = "BTN_TAMAM";
            this.BTN_TAMAM.Size = new System.Drawing.Size(90, 40);
            this.BTN_TAMAM.TabIndex = 31;
            this.BTN_TAMAM.Text = "Tamam";
            this.BTN_TAMAM.Click += new System.EventHandler(this.BTN_TAMAM_Click);
            // 
            // AKTARIM_PARAMETRESI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 137);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CMB_E_FATURA_SERISI);
            this.Controls.Add(this.rd_TICARI);
            this.Controls.Add(this.rd_TEMEL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BTN_VAZGEC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTN_TAMAM);
            this.Controls.Add(this.dtEdit_TARIH);
            this.Name = "AKTARIM_PARAMETRESI";
            this.Text = "AKTARIM_PARAMETRESI";
            this.Load += new System.EventHandler(this.AKTARIM_PARAMETRESI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CMB_E_FATURA_SERISI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdit_TARIH.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdit_TARIH.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.ComboBoxEdit CMB_E_FATURA_SERISI;
        private System.Windows.Forms.RadioButton rd_TICARI;
        private System.Windows.Forms.RadioButton rd_TEMEL;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton BTN_VAZGEC;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton BTN_TAMAM;
        private DevExpress.XtraEditors.DateEdit dtEdit_TARIH;
    }
}