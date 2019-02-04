namespace VISION._LOCAL_ADMIN.MUSTERI
{
    partial class MUSTERI_GRUBU_GIRIS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MUSTERI_GRUBU_GIRIS));
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
            this.TXT_MUSTERI_KODU = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.LblSirketCode = new System.Windows.Forms.Label();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_MUSTERI_KODU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
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
            this.BR_KAYDET.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BR_KAYDET_ItemClick);
            // 
            // BR_YENI
            // 
            this.BR_YENI.Caption = "Yeni";
            this.BR_YENI.Glyph = ((System.Drawing.Image)(resources.GetObject("BR_YENI.Glyph")));
            this.BR_YENI.Id = 24;
            this.BR_YENI.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BR_YENI.LargeGlyph")));
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
            this.barDockControlTop.Size = new System.Drawing.Size(323, 28);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 118);
            this.barDockControlBottom.Size = new System.Drawing.Size(323, 26);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 28);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 90);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(323, 28);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 90);
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
            this.TXT_MUSTERI_KODU.Location = new System.Drawing.Point(116, 51);
            this.TXT_MUSTERI_KODU.Name = "TXT_MUSTERI_KODU";
            this.TXT_MUSTERI_KODU.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TXT_MUSTERI_KODU.Properties.Mask.EditMask = "[A-Z0-9]{0,10}";
            this.TXT_MUSTERI_KODU.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.TXT_MUSTERI_KODU.Properties.MaxLength = 10;
            this.TXT_MUSTERI_KODU.Size = new System.Drawing.Size(134, 20);
            this.TXT_MUSTERI_KODU.TabIndex = 585;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(13, 51);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 587;
            this.label4.Text = "Müşteri Grubu";
            // 
            // LblSirketCode
            // 
            this.LblSirketCode.BackColor = System.Drawing.Color.Transparent;
            this.LblSirketCode.Location = new System.Drawing.Point(13, 79);
            this.LblSirketCode.Name = "LblSirketCode";
            this.LblSirketCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblSirketCode.Size = new System.Drawing.Size(87, 20);
            this.LblSirketCode.TabIndex = 586;
            this.LblSirketCode.Text = "Açıklaması";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(116, 79);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textEdit1.Properties.Mask.EditMask = "[A-Z0-9]{0,10}";
            this.textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.textEdit1.Properties.MaxLength = 10;
            this.textEdit1.Size = new System.Drawing.Size(134, 20);
            this.textEdit1.TabIndex = 592;
            // 
            // MUSTERI_GRUBU_GIRIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 144);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.TXT_MUSTERI_KODU);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LblSirketCode);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MUSTERI_GRUBU_GIRIS";
            this.Text = "MUSTERI_GRUBU_GIRIS";
            ((System.ComponentModel.ISupportInitialize)(this.barManagers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_MUSTERI_KODU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit TXT_MUSTERI_KODU;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblSirketCode;
        private DevExpress.XtraEditors.TextEdit textEdit1;
    }
}