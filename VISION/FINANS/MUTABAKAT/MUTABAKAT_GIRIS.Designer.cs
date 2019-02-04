namespace VISION.FINANS.MUTABAKAT
{
    partial class MUTABAKAT_GIRIS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MUTABAKAT_GIRIS));
            this.barManagers = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.BR_KAPAT = new DevExpress.XtraBars.BarButtonItem();
            this.BR_KAYDET = new DevExpress.XtraBars.BarButtonItem();
            this.BR_YENI = new DevExpress.XtraBars.BarButtonItem();
            this.BR_LIST = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lbID = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.BR_ID = new DevExpress.XtraBars.BarStaticItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.TXT_MUTABAKAT_KODU = new DevExpress.XtraEditors.TextEdit();
            this.label19 = new System.Windows.Forms.Label();
            this.DTM_BITIS_TARIHI = new DevExpress.XtraEditors.DateEdit();
            this.TXT_NOTUM = new DevExpress.XtraEditors.MemoEdit();
            this.DTM_BASLANGIC_TARIHI = new DevExpress.XtraEditors.DateEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.LblNot = new System.Windows.Forms.Label();
            this.LblGrsTrh = new System.Windows.Forms.Label();
            this.TXT_DONEMI = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.CMB_FORM_TURU = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManagers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_MUTABAKAT_KODU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTM_BITIS_TARIHI.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTM_BITIS_TARIHI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_NOTUM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTM_BASLANGIC_TARIHI.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTM_BASLANGIC_TARIHI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_DONEMI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMB_FORM_TURU.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManagers
            // 
            this.barManagers.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManagers.DockControls.Add(this.barDockControlTop);
            this.barManagers.DockControls.Add(this.barDockControlBottom);
            this.barManagers.DockControls.Add(this.barDockControlLeft);
            this.barManagers.DockControls.Add(this.barDockControlRight);
            this.barManagers.Form = this;
            this.barManagers.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BR_KAPAT,
            this.BR_ID,
            this.BR_YENI,
            this.BR_KAYDET,
            this.lbID,
            this.BR_LIST});
            this.barManagers.MaxItemId = 27;
            this.barManagers.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.barManagers.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BR_KAPAT, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BR_KAYDET, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BR_YENI, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BR_LIST, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // BR_KAPAT
            // 
            this.BR_KAPAT.Caption = "Kapat";
            this.BR_KAPAT.Id = 0;
            this.BR_KAPAT.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BR_KAPAT.ImageOptions.Image")));
            this.BR_KAPAT.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BR_KAPAT.ImageOptions.LargeImage")));
            this.BR_KAPAT.Name = "BR_KAPAT";
            this.BR_KAPAT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BR_KAPAT_ItemClick);
            // 
            // BR_KAYDET
            // 
            this.BR_KAYDET.Caption = "Kaydet";
            this.BR_KAYDET.Id = 24;
            this.BR_KAYDET.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BR_KAYDET.ImageOptions.Image")));
            this.BR_KAYDET.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BR_KAYDET.ImageOptions.LargeImage")));
            this.BR_KAYDET.Name = "BR_KAYDET";
            this.BR_KAYDET.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BR_KAYDET_ItemClick);
            // 
            // BR_YENI
            // 
            this.BR_YENI.Caption = "Yeni";
            this.BR_YENI.Id = 22;
            this.BR_YENI.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BR_YENI.ImageOptions.Image")));
            this.BR_YENI.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BR_YENI.ImageOptions.LargeImage")));
            this.BR_YENI.Name = "BR_YENI";
            this.BR_YENI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BR_YENI_ItemClick);
            // 
            // BR_LIST
            // 
            this.BR_LIST.Caption = "List";
            this.BR_LIST.Id = 26;
            this.BR_LIST.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BR_LIST.ImageOptions.Image")));
            this.BR_LIST.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BR_LIST.ImageOptions.LargeImage")));
            this.BR_LIST.Name = "BR_LIST";
            this.BR_LIST.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BR_LIST_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarAppearance.Normal.BackColor = System.Drawing.Color.Yellow;
            this.bar3.BarAppearance.Normal.ForeColor = System.Drawing.Color.Black;
            this.bar3.BarAppearance.Normal.Options.UseBackColor = true;
            this.bar3.BarAppearance.Normal.Options.UseForeColor = true;
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lbID)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // lbID
            // 
            this.lbID.Id = 25;
            this.lbID.Name = "lbID";
            this.lbID.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManagers;
            this.barDockControlTop.Size = new System.Drawing.Size(472, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 248);
            this.barDockControlBottom.Manager = this.barManagers;
            this.barDockControlBottom.Size = new System.Drawing.Size(472, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Manager = this.barManagers;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 219);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(472, 29);
            this.barDockControlRight.Manager = this.barManagers;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 219);
            // 
            // BR_ID
            // 
            this.BR_ID.Caption = "BR_ID";
            this.BR_ID.Id = 4;
            this.BR_ID.Name = "BR_ID";
            this.BR_ID.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // TXT_MUTABAKAT_KODU
            // 
            this.TXT_MUTABAKAT_KODU.Enabled = false;
            this.TXT_MUTABAKAT_KODU.Location = new System.Drawing.Point(129, 151);
            this.TXT_MUTABAKAT_KODU.Name = "TXT_MUTABAKAT_KODU";
            this.TXT_MUTABAKAT_KODU.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TXT_MUTABAKAT_KODU.Properties.Appearance.Options.UseFont = true;
            this.TXT_MUTABAKAT_KODU.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TXT_MUTABAKAT_KODU.Properties.MaxLength = 12;
            this.TXT_MUTABAKAT_KODU.Size = new System.Drawing.Size(327, 20);
            this.TXT_MUTABAKAT_KODU.TabIndex = 1280;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Enabled = false;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label19.Location = new System.Drawing.Point(38, 151);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 20);
            this.label19.TabIndex = 1279;
            this.label19.Text = "Mutabakat Kodu";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DTM_BITIS_TARIHI
            // 
            this.DTM_BITIS_TARIHI.EditValue = new System.DateTime(2009, 11, 11, 0, 0, 0, 0);
            this.DTM_BITIS_TARIHI.Location = new System.Drawing.Point(129, 100);
            this.DTM_BITIS_TARIHI.Name = "DTM_BITIS_TARIHI";
            this.DTM_BITIS_TARIHI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DTM_BITIS_TARIHI.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DTM_BITIS_TARIHI.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.DTM_BITIS_TARIHI.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.DTM_BITIS_TARIHI.Size = new System.Drawing.Size(99, 20);
            this.DTM_BITIS_TARIHI.TabIndex = 1278;
            // 
            // TXT_NOTUM
            // 
            this.TXT_NOTUM.Location = new System.Drawing.Point(129, 177);
            this.TXT_NOTUM.Name = "TXT_NOTUM";
            this.TXT_NOTUM.Size = new System.Drawing.Size(328, 67);
            this.TXT_NOTUM.TabIndex = 1264;
            // 
            // DTM_BASLANGIC_TARIHI
            // 
            this.DTM_BASLANGIC_TARIHI.EditValue = new System.DateTime(2007, 11, 22, 12, 20, 56, 291);
            this.DTM_BASLANGIC_TARIHI.Location = new System.Drawing.Point(129, 74);
            this.DTM_BASLANGIC_TARIHI.Name = "DTM_BASLANGIC_TARIHI";
            this.DTM_BASLANGIC_TARIHI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DTM_BASLANGIC_TARIHI.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DTM_BASLANGIC_TARIHI.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.DTM_BASLANGIC_TARIHI.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.DTM_BASLANGIC_TARIHI.Size = new System.Drawing.Size(100, 20);
            this.DTM_BASLANGIC_TARIHI.TabIndex = 1263;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(64, 103);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(61, 18);
            this.label13.TabIndex = 1271;
            this.label13.Text = "Bitiş Tarihi";
            // 
            // LblNot
            // 
            this.LblNot.BackColor = System.Drawing.Color.Transparent;
            this.LblNot.Location = new System.Drawing.Point(38, 177);
            this.LblNot.Name = "LblNot";
            this.LblNot.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblNot.Size = new System.Drawing.Size(87, 15);
            this.LblNot.TabIndex = 1274;
            this.LblNot.Text = "Not";
            // 
            // LblGrsTrh
            // 
            this.LblGrsTrh.BackColor = System.Drawing.Color.Transparent;
            this.LblGrsTrh.Location = new System.Drawing.Point(38, 76);
            this.LblGrsTrh.Name = "LblGrsTrh";
            this.LblGrsTrh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblGrsTrh.Size = new System.Drawing.Size(87, 18);
            this.LblGrsTrh.TabIndex = 1270;
            this.LblGrsTrh.Text = "Başlangıç Tarihi";
            // 
            // TXT_DONEMI
            // 
            this.TXT_DONEMI.Location = new System.Drawing.Point(129, 126);
            this.TXT_DONEMI.Name = "TXT_DONEMI";
            this.TXT_DONEMI.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TXT_DONEMI.Properties.Appearance.Options.UseFont = true;
            this.TXT_DONEMI.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TXT_DONEMI.Properties.MaxLength = 12;
            this.TXT_DONEMI.Size = new System.Drawing.Size(327, 20);
            this.TXT_DONEMI.TabIndex = 1286;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(38, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 1285;
            this.label1.Text = "Dönemi";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CMB_FORM_TURU
            // 
            this.CMB_FORM_TURU.EditValue = "BA";
            this.CMB_FORM_TURU.Location = new System.Drawing.Point(129, 48);
            this.CMB_FORM_TURU.MenuManager = this.barManagers;
            this.CMB_FORM_TURU.Name = "CMB_FORM_TURU";
            this.CMB_FORM_TURU.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CMB_FORM_TURU.Properties.Items.AddRange(new object[] {
            "BA",
            "BS",
            "Cari Hesap Mutabakatı"});
            this.CMB_FORM_TURU.Size = new System.Drawing.Size(100, 20);
            this.CMB_FORM_TURU.TabIndex = 1291;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(38, 50);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 1292;
            this.label2.Text = "Form";
            // 
            // MUTABAKAT_GIRIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 275);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CMB_FORM_TURU);
            this.Controls.Add(this.TXT_DONEMI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXT_MUTABAKAT_KODU);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.DTM_BITIS_TARIHI);
            this.Controls.Add(this.TXT_NOTUM);
            this.Controls.Add(this.DTM_BASLANGIC_TARIHI);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.LblNot);
            this.Controls.Add(this.LblGrsTrh);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MUTABAKAT_GIRIS";
            this.Text = "MUTABAKAT_GIRIS";
            ((System.ComponentModel.ISupportInitialize)(this.barManagers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_MUTABAKAT_KODU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTM_BITIS_TARIHI.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTM_BITIS_TARIHI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_NOTUM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTM_BASLANGIC_TARIHI.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTM_BASLANGIC_TARIHI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_DONEMI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMB_FORM_TURU.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagers;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem BR_KAPAT;
        private DevExpress.XtraBars.BarButtonItem BR_KAYDET;
        private DevExpress.XtraBars.BarButtonItem BR_YENI;
        private DevExpress.XtraBars.BarButtonItem BR_LIST;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem lbID;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem BR_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.TextEdit TXT_MUTABAKAT_KODU;
        private System.Windows.Forms.Label label19;
        private DevExpress.XtraEditors.DateEdit DTM_BITIS_TARIHI;
        private DevExpress.XtraEditors.MemoEdit TXT_NOTUM;
        private DevExpress.XtraEditors.DateEdit DTM_BASLANGIC_TARIHI;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label LblNot;
        private System.Windows.Forms.Label LblGrsTrh;
        private DevExpress.XtraEditors.TextEdit TXT_DONEMI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.ComboBoxEdit CMB_FORM_TURU;
    }
}