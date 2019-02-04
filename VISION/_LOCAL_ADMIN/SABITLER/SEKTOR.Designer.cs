namespace VISION._LOCAL_ADMIN.SABITLER
{
    partial class SEKTOR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SEKTOR));
            this.barManagers = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.BR_KAPAT = new DevExpress.XtraBars.BarButtonItem();
            this.BR_KAYDET = new DevExpress.XtraBars.BarButtonItem();
            this.BR_YENI = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lbID = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.BR_ID = new DevExpress.XtraBars.BarStaticItem();
            this.BR_PARENT_ID = new DevExpress.XtraBars.BarStaticItem();
            this.BR_GUI = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.TXT_MUSTERI_KODU = new DevExpress.XtraEditors.ButtonEdit();
            this.TXT_MUSTERI_ADI = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TXT_URUN_ADI = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.LblNot = new System.Windows.Forms.Label();
            this.LblFirma = new System.Windows.Forms.Label();
            this.TXT_NOTUM = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_MUSTERI_KODU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_MUSTERI_ADI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_URUN_ADI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_NOTUM.Properties)).BeginInit();
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
            this.BR_PARENT_ID,
            this.BR_GUI,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem1,
            this.barButtonItem7,
            this.barButtonItem8,
            this.BR_YENI,
            this.BR_KAYDET,
            this.lbID});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BR_KAYDET, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BR_YENI, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // BR_KAPAT
            // 
            this.BR_KAPAT.Caption = "Kapat";
            this.BR_KAPAT.Glyph = ((System.Drawing.Image)(resources.GetObject("BR_KAPAT.Glyph")));
            this.BR_KAPAT.Id = 0;
            this.BR_KAPAT.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BR_KAPAT.LargeGlyph")));
            this.BR_KAPAT.Name = "BR_KAPAT";
            this.BR_KAPAT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BR_KAPAT_ItemClick);
            // 
            // BR_KAYDET
            // 
            this.BR_KAYDET.Caption = "Kaydet";
            this.BR_KAYDET.Glyph = ((System.Drawing.Image)(resources.GetObject("BR_KAYDET.Glyph")));
            this.BR_KAYDET.Id = 25;
            this.BR_KAYDET.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BR_KAYDET.LargeGlyph")));
            this.BR_KAYDET.Name = "BR_KAYDET";
            // 
            // BR_YENI
            // 
            this.BR_YENI.Caption = "Yeni";
            this.BR_YENI.Glyph = ((System.Drawing.Image)(resources.GetObject("BR_YENI.Glyph")));
            this.BR_YENI.Id = 24;
            this.BR_YENI.Name = "BR_YENI";
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
            this.lbID.Id = 26;
            this.lbID.Name = "lbID";
            this.lbID.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(390, 45);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 327);
            this.barDockControlBottom.Size = new System.Drawing.Size(390, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 45);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 282);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(390, 45);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 282);
            // 
            // BR_ID
            // 
            this.BR_ID.Caption = "BR_ID";
            this.BR_ID.Id = 4;
            this.BR_ID.Name = "BR_ID";
            this.BR_ID.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // BR_PARENT_ID
            // 
            this.BR_PARENT_ID.Caption = "BR_PARENT_ID";
            this.BR_PARENT_ID.Id = 6;
            this.BR_PARENT_ID.Name = "BR_PARENT_ID";
            this.BR_PARENT_ID.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // BR_GUI
            // 
            this.BR_GUI.Caption = "BR_GUI";
            this.BR_GUI.Id = 7;
            this.BR_GUI.Name = "BR_GUI";
            this.BR_GUI.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Gazete Tarifesi Giriş";
            this.barButtonItem2.Id = 10;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Dergi Tarifesi Giriş";
            this.barButtonItem3.Id = 11;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Gazete Tarifesi Düzeltme";
            this.barButtonItem4.Id = 12;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Dergi Tarifesi Düzeltme";
            this.barButtonItem5.Id = 13;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Dergi Tarifesi Giriş";
            this.barButtonItem6.Id = 14;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.barButtonItem1.Caption = "Dergi Tarifesi Düzeltme";
            this.barButtonItem1.Id = 15;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Televizyon Tarifesi Giriş";
            this.barButtonItem7.Id = 16;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "Televizyon Tarifesi Düzeltme";
            this.barButtonItem8.Id = 17;
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // TXT_MUSTERI_KODU
            // 
            this.TXT_MUSTERI_KODU.Location = new System.Drawing.Point(28, 86);
            this.TXT_MUSTERI_KODU.Name = "TXT_MUSTERI_KODU";
            this.TXT_MUSTERI_KODU.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TXT_MUSTERI_KODU.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.TXT_MUSTERI_KODU.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.TXT_MUSTERI_KODU.Size = new System.Drawing.Size(239, 20);
            this.TXT_MUSTERI_KODU.TabIndex = 1173;
            // 
            // TXT_MUSTERI_ADI
            // 
            this.TXT_MUSTERI_ADI.Enabled = false;
            this.TXT_MUSTERI_ADI.Location = new System.Drawing.Point(28, 202);
            this.TXT_MUSTERI_ADI.Name = "TXT_MUSTERI_ADI";
            this.TXT_MUSTERI_ADI.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TXT_MUSTERI_ADI.Properties.Appearance.Options.UseFont = true;
            this.TXT_MUSTERI_ADI.Properties.MaxLength = 12;
            this.TXT_MUSTERI_ADI.Size = new System.Drawing.Size(349, 20);
            this.TXT_MUSTERI_ADI.TabIndex = 1182;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(28, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 16);
            this.label1.TabIndex = 1181;
            this.label1.Text = "Sektör Açıklaması";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(28, 148);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 16);
            this.label12.TabIndex = 1180;
            this.label12.Text = "Sektör Kodu";
            // 
            // TXT_URUN_ADI
            // 
            this.TXT_URUN_ADI.Location = new System.Drawing.Point(28, 125);
            this.TXT_URUN_ADI.Name = "TXT_URUN_ADI";
            this.TXT_URUN_ADI.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TXT_URUN_ADI.Properties.Appearance.Options.UseFont = true;
            this.TXT_URUN_ADI.Properties.MaxLength = 40;
            this.TXT_URUN_ADI.Size = new System.Drawing.Size(349, 20);
            this.TXT_URUN_ADI.TabIndex = 1183;
            // 
            // textEdit1
            // 
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new System.Drawing.Point(28, 164);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.MaxLength = 12;
            this.textEdit1.Size = new System.Drawing.Size(239, 20);
            this.textEdit1.TabIndex = 1188;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(28, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 1187;
            this.label2.Text = "Ana Sektör Kodu";
            // 
            // LblNot
            // 
            this.LblNot.BackColor = System.Drawing.Color.Transparent;
            this.LblNot.Location = new System.Drawing.Point(28, 225);
            this.LblNot.Name = "LblNot";
            this.LblNot.Size = new System.Drawing.Size(118, 16);
            this.LblNot.TabIndex = 1186;
            this.LblNot.Text = "Not";
            // 
            // LblFirma
            // 
            this.LblFirma.BackColor = System.Drawing.Color.Transparent;
            this.LblFirma.Location = new System.Drawing.Point(28, 106);
            this.LblFirma.Name = "LblFirma";
            this.LblFirma.Size = new System.Drawing.Size(118, 16);
            this.LblFirma.TabIndex = 1185;
            this.LblFirma.Text = "Ana Sektör Açıklaması";
            // 
            // TXT_NOTUM
            // 
            this.TXT_NOTUM.Location = new System.Drawing.Point(28, 244);
            this.TXT_NOTUM.Name = "TXT_NOTUM";
            this.TXT_NOTUM.Size = new System.Drawing.Size(349, 57);
            this.TXT_NOTUM.TabIndex = 1184;
            // 
            // SEKTOR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 354);
            this.Controls.Add(this.TXT_URUN_ADI);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblNot);
            this.Controls.Add(this.LblFirma);
            this.Controls.Add(this.TXT_NOTUM);
            this.Controls.Add(this.TXT_MUSTERI_KODU);
            this.Controls.Add(this.TXT_MUSTERI_ADI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "SEKTOR";
            this.Text = "SEKTÖR";
            ((System.ComponentModel.ISupportInitialize)(this.barManagers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_MUSTERI_KODU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_MUSTERI_ADI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_URUN_ADI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_NOTUM.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagers;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem BR_KAPAT;
        private DevExpress.XtraBars.BarButtonItem BR_KAYDET;
        private DevExpress.XtraBars.BarButtonItem BR_YENI;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem lbID;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem BR_ID;
        private DevExpress.XtraBars.BarStaticItem BR_PARENT_ID;
        private DevExpress.XtraBars.BarStaticItem BR_GUI;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.ButtonEdit TXT_MUSTERI_KODU;
        private DevExpress.XtraEditors.TextEdit TXT_MUSTERI_ADI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.TextEdit TXT_URUN_ADI;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblNot;
        private System.Windows.Forms.Label LblFirma;
        private DevExpress.XtraEditors.MemoEdit TXT_NOTUM;
    }
}