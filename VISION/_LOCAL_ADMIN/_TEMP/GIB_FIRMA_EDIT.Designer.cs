namespace VISION._LOCAL_ADMIN._TEMP
{
    partial class GIB_FIRMA_EDIT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GIB_FIRMA_EDIT));
            this.GRD_LISTE = new DevExpress.XtraGrid.GridControl();
            this.gridView_LIST = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.re_ImageCmbBx_FC = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.re_ImageCmbBx_AKTARIM_DURUMU = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckedComboBoxEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.barManagers = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.BTN_KAPAT = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_REFRESH = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_FIRMA = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.BTN_LOGO_SECILENLERI_AKATAR = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.BTM_FIRMA_ID = new DevExpress.XtraBars.BarStaticItem();
            this.BTM_FIRMA_KODU = new DevExpress.XtraBars.BarStaticItem();
            this.BTM_FIRMA_NAME = new DevExpress.XtraBars.BarStaticItem();
            this.BR_SELECT_ROW_FATURA_NO = new DevExpress.XtraBars.BarStaticItem();
            this.BR_INFO = new DevExpress.XtraBars.BarStaticItem();
            this.BR_PROGRESS_BAR = new DevExpress.XtraBars.BarEditItem();
            this.re_PROGRESS_BAR = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.BR_BUG = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.re_ItmChck_AUTO_UPDATE = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_LISTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_LIST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_ImageCmbBx_FC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_ImageCmbBx_AKTARIM_DURUMU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_PROGRESS_BAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_ItmChck_AUTO_UPDATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GRD_LISTE
            // 
            this.GRD_LISTE.Cursor = System.Windows.Forms.Cursors.Default;
            this.GRD_LISTE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GRD_LISTE.Location = new System.Drawing.Point(0, 28);
            this.GRD_LISTE.MainView = this.gridView_LIST;
            this.GRD_LISTE.Name = "GRD_LISTE";
            this.GRD_LISTE.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.re_ImageCmbBx_FC,
            this.re_ImageCmbBx_AKTARIM_DURUMU,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckedComboBoxEdit1,
            this.repositoryItemSpinEdit1});
            this.GRD_LISTE.Size = new System.Drawing.Size(1318, 733);
            this.GRD_LISTE.TabIndex = 11;
            this.GRD_LISTE.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_LIST});
            // 
            // gridView_LIST
            // 
            this.gridView_LIST.ColumnPanelRowHeight = 40;
            this.gridView_LIST.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn24,
            this.gridColumn14});
            this.gridView_LIST.GridControl = this.GRD_LISTE;
            this.gridView_LIST.Name = "gridView_LIST";
            this.gridView_LIST.OptionsSelection.MultiSelect = true;
            this.gridView_LIST.OptionsView.ColumnAutoWidth = false;
            this.gridView_LIST.OptionsView.ShowAutoFilterRow = true;
            this.gridView_LIST.OptionsView.ShowFooter = true;
            this.gridView_LIST.OptionsView.ShowGroupPanel = false;
            this.gridView_LIST.OptionsView.ShowIndicator = false;
            // 
            // gridColumn24
            // 
            this.gridColumn24.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn24.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn24.Caption = "AccCustomerPartyName";
            this.gridColumn24.FieldName = "AccCustomerPartyName";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 0;
            this.gridColumn24.Width = 570;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "SIRKET_KODU";
            this.gridColumn14.FieldName = "SIRKET_KODU";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 1;
            this.gridColumn14.Width = 337;
            // 
            // re_ImageCmbBx_FC
            // 
            this.re_ImageCmbBx_FC.AutoHeight = false;
            this.re_ImageCmbBx_FC.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.re_ImageCmbBx_FC.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "0", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "1", 5)});
            this.re_ImageCmbBx_FC.Name = "re_ImageCmbBx_FC";
            // 
            // re_ImageCmbBx_AKTARIM_DURUMU
            // 
            this.re_ImageCmbBx_AKTARIM_DURUMU.AutoHeight = false;
            this.re_ImageCmbBx_AKTARIM_DURUMU.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.re_ImageCmbBx_AKTARIM_DURUMU.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "0", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "1", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "2", 1)});
            this.re_ImageCmbBx_AKTARIM_DURUMU.Name = "re_ImageCmbBx_AKTARIM_DURUMU";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckedComboBoxEdit1
            // 
            this.repositoryItemCheckedComboBoxEdit1.AutoHeight = false;
            this.repositoryItemCheckedComboBoxEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCheckedComboBoxEdit1.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null)});
            this.repositoryItemCheckedComboBoxEdit1.Name = "repositoryItemCheckedComboBoxEdit1";
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.OK)});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
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
            this.BTN_KAPAT,
            this.BR_SELECT_ROW_FATURA_NO,
            this.BTN_REFRESH,
            this.BR_PROGRESS_BAR,
            this.BTN_LOGO_SECILENLERI_AKATAR,
            this.BR_INFO,
            this.BR_BUG,
            this.BTM_FIRMA_KODU,
            this.BTM_FIRMA_NAME,
            this.BTM_FIRMA_ID,
            this.BTN_FIRMA});
            this.barManagers.MaxItemId = 21;
            this.barManagers.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.re_PROGRESS_BAR,
            this.re_ItmChck_AUTO_UPDATE,
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2});
            this.barManagers.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTN_KAPAT, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTN_REFRESH, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTN_FIRMA, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTN_LOGO_SECILENLERI_AKATAR, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // BTN_KAPAT
            // 
            this.BTN_KAPAT.Caption = "Kapat";
            this.BTN_KAPAT.Glyph = ((System.Drawing.Image)(resources.GetObject("BTN_KAPAT.Glyph")));
            this.BTN_KAPAT.Id = 0;
            this.BTN_KAPAT.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BTN_KAPAT.LargeGlyph")));
            this.BTN_KAPAT.Name = "BTN_KAPAT";
            // 
            // BTN_REFRESH
            // 
            this.BTN_REFRESH.Caption = "Güncelle";
            this.BTN_REFRESH.Glyph = ((System.Drawing.Image)(resources.GetObject("BTN_REFRESH.Glyph")));
            this.BTN_REFRESH.Id = 4;
            this.BTN_REFRESH.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BTN_REFRESH.LargeGlyph")));
            this.BTN_REFRESH.Name = "BTN_REFRESH";
            // 
            // BTN_FIRMA
            // 
            this.BTN_FIRMA.Caption = "Firma";
            this.BTN_FIRMA.Edit = this.repositoryItemComboBox2;
            this.BTN_FIRMA.Id = 20;
            this.BTN_FIRMA.Name = "BTN_FIRMA";
            this.BTN_FIRMA.Width = 109;
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Items.AddRange(new object[] {
            "GRM",
            "MDS",
            "MCM",
            "MEC",
            "MAX",
            "QUI"});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // BTN_LOGO_SECILENLERI_AKATAR
            // 
            this.BTN_LOGO_SECILENLERI_AKATAR.Caption = "Tümünü Seç";
            this.BTN_LOGO_SECILENLERI_AKATAR.Glyph = ((System.Drawing.Image)(resources.GetObject("BTN_LOGO_SECILENLERI_AKATAR.Glyph")));
            this.BTN_LOGO_SECILENLERI_AKATAR.Id = 7;
            this.BTN_LOGO_SECILENLERI_AKATAR.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BTN_LOGO_SECILENLERI_AKATAR.LargeGlyph")));
            this.BTN_LOGO_SECILENLERI_AKATAR.Name = "BTN_LOGO_SECILENLERI_AKATAR";
            this.BTN_LOGO_SECILENLERI_AKATAR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_LOGO_SECILENLERI_AKATAR_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BTM_FIRMA_ID),
            new DevExpress.XtraBars.LinkPersistInfo(this.BTM_FIRMA_KODU),
            new DevExpress.XtraBars.LinkPersistInfo(this.BTM_FIRMA_NAME),
            new DevExpress.XtraBars.LinkPersistInfo(this.BR_SELECT_ROW_FATURA_NO),
            new DevExpress.XtraBars.LinkPersistInfo(this.BR_INFO),
            new DevExpress.XtraBars.LinkPersistInfo(this.BR_PROGRESS_BAR),
            new DevExpress.XtraBars.LinkPersistInfo(this.BR_BUG)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // BTM_FIRMA_ID
            // 
            this.BTM_FIRMA_ID.Id = 18;
            this.BTM_FIRMA_ID.Name = "BTM_FIRMA_ID";
            this.BTM_FIRMA_ID.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // BTM_FIRMA_KODU
            // 
            this.BTM_FIRMA_KODU.Id = 14;
            this.BTM_FIRMA_KODU.Name = "BTM_FIRMA_KODU";
            this.BTM_FIRMA_KODU.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // BTM_FIRMA_NAME
            // 
            this.BTM_FIRMA_NAME.Id = 15;
            this.BTM_FIRMA_NAME.Name = "BTM_FIRMA_NAME";
            this.BTM_FIRMA_NAME.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // BR_SELECT_ROW_FATURA_NO
            // 
            this.BR_SELECT_ROW_FATURA_NO.Caption = "Fatura No";
            this.BR_SELECT_ROW_FATURA_NO.Id = 2;
            this.BR_SELECT_ROW_FATURA_NO.Name = "BR_SELECT_ROW_FATURA_NO";
            this.BR_SELECT_ROW_FATURA_NO.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // BR_INFO
            // 
            this.BR_INFO.Id = 9;
            this.BR_INFO.Name = "BR_INFO";
            this.BR_INFO.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // BR_PROGRESS_BAR
            // 
            this.BR_PROGRESS_BAR.Caption = "barEditItem1";
            this.BR_PROGRESS_BAR.Edit = this.re_PROGRESS_BAR;
            this.BR_PROGRESS_BAR.Id = 6;
            this.BR_PROGRESS_BAR.Name = "BR_PROGRESS_BAR";
            this.BR_PROGRESS_BAR.Width = 299;
            // 
            // re_PROGRESS_BAR
            // 
            this.re_PROGRESS_BAR.Name = "re_PROGRESS_BAR";
            // 
            // BR_BUG
            // 
            this.BR_BUG.Caption = "BUG";
            this.BR_BUG.Id = 12;
            this.BR_BUG.Name = "BR_BUG";
            this.BR_BUG.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1318, 28);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 761);
            this.barDockControlBottom.Size = new System.Drawing.Size(1318, 26);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 28);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 733);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1318, 28);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 733);
            // 
            // re_ItmChck_AUTO_UPDATE
            // 
            this.re_ItmChck_AUTO_UPDATE.AutoHeight = false;
            this.re_ItmChck_AUTO_UPDATE.Caption = "Check";
            this.re_ItmChck_AUTO_UPDATE.Name = "re_ItmChck_AUTO_UPDATE";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "Aktarılmamış Faturalar",
            "Aktarılmış Faturalar"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // GIB_FIRMA_EDIT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 787);
            this.Controls.Add(this.GRD_LISTE);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "GIB_FIRMA_EDIT";
            this.Text = "GIB_FIRMA_EDIT";
            ((System.ComponentModel.ISupportInitialize)(this.GRD_LISTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_LIST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_ImageCmbBx_FC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_ImageCmbBx_AKTARIM_DURUMU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_PROGRESS_BAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_ItmChck_AUTO_UPDATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GRD_LISTE;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_LIST;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox re_ImageCmbBx_AKTARIM_DURUMU;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox re_ImageCmbBx_FC;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraBars.BarManager barManagers;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem BTN_KAPAT;
        private DevExpress.XtraBars.BarButtonItem BTN_REFRESH;
        private DevExpress.XtraBars.BarButtonItem BTN_LOGO_SECILENLERI_AKATAR;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem BTM_FIRMA_ID;
        private DevExpress.XtraBars.BarStaticItem BTM_FIRMA_KODU;
        private DevExpress.XtraBars.BarStaticItem BTM_FIRMA_NAME;
        private DevExpress.XtraBars.BarStaticItem BR_SELECT_ROW_FATURA_NO;
        private DevExpress.XtraBars.BarStaticItem BR_INFO;
        private DevExpress.XtraBars.BarEditItem BR_PROGRESS_BAR;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar re_PROGRESS_BAR;
        private DevExpress.XtraBars.BarStaticItem BR_BUG;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem BTN_FIRMA;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit re_ItmChck_AUTO_UPDATE;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
    }
}