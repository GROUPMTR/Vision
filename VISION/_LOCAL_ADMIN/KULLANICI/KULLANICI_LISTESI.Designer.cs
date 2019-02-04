namespace VISION._LOCAL_ADMIN.KULLANICI
{
    partial class KULLANICI_LISTESI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KULLANICI_LISTESI));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.BTN_KAPAT = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_GUNCELLE = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lbID = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.re_PROGRESS_BAR = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.re_ItmChck_AUTO_UPDATE = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridCntrl_LIST = new DevExpress.XtraGrid.GridControl();
            this.GRD_VIEW_LISTE = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CL_SIRKET_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CL_KULLANICI_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CL_KULLANICI_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CL_KULLANICI_SOYADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CL_KULLANICI_MAIL = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_PROGRESS_BAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_ItmChck_AUTO_UPDATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCntrl_LIST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_VIEW_LISTE)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BTN_KAPAT,
            this.lbID,
            this.BTN_GUNCELLE});
            this.barManager1.MaxItemId = 18;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.re_PROGRESS_BAR,
            this.re_ItmChck_AUTO_UPDATE});
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTN_KAPAT, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTN_GUNCELLE, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            this.BTN_KAPAT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_KAPAT_ItemClick);
            // 
            // BTN_GUNCELLE
            // 
            this.BTN_GUNCELLE.Caption = "Kaydet";
            this.BTN_GUNCELLE.Glyph = ((System.Drawing.Image)(resources.GetObject("BTN_GUNCELLE.Glyph")));
            this.BTN_GUNCELLE.Id = 17;
            this.BTN_GUNCELLE.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BTN_GUNCELLE.LargeGlyph")));
            this.BTN_GUNCELLE.Name = "BTN_GUNCELLE";
            this.BTN_GUNCELLE.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_GUNCELLE_ItemClick);
            // 
            // bar3
            // 
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
            this.lbID.Id = 2;
            this.lbID.Name = "lbID";
            this.lbID.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(723, 28);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 573);
            this.barDockControlBottom.Size = new System.Drawing.Size(723, 26);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 28);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 545);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(723, 28);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 545);
            // 
            // re_PROGRESS_BAR
            // 
            this.re_PROGRESS_BAR.Name = "re_PROGRESS_BAR";
            // 
            // re_ItmChck_AUTO_UPDATE
            // 
            this.re_ItmChck_AUTO_UPDATE.AutoHeight = false;
            this.re_ItmChck_AUTO_UPDATE.Caption = "Check";
            this.re_ItmChck_AUTO_UPDATE.Name = "re_ItmChck_AUTO_UPDATE";
            // 
            // gridCntrl_LIST
            // 
            this.gridCntrl_LIST.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridCntrl_LIST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCntrl_LIST.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridCntrl_LIST.Location = new System.Drawing.Point(0, 28);
            this.gridCntrl_LIST.MainView = this.GRD_VIEW_LISTE;
            this.gridCntrl_LIST.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridCntrl_LIST.Name = "gridCntrl_LIST";
            this.gridCntrl_LIST.Size = new System.Drawing.Size(723, 545);
            this.gridCntrl_LIST.TabIndex = 555;
            this.gridCntrl_LIST.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GRD_VIEW_LISTE});
            this.gridCntrl_LIST.DoubleClick += new System.EventHandler(this.gridCntrl_LIST_DoubleClick);
            // 
            // GRD_VIEW_LISTE
            // 
            this.GRD_VIEW_LISTE.ColumnPanelRowHeight = 40;
            this.GRD_VIEW_LISTE.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOid,
            this.CL_SIRKET_KODU,
            this.CL_KULLANICI_KODU,
            this.CL_KULLANICI_ADI,
            this.CL_KULLANICI_SOYADI,
            this.CL_KULLANICI_MAIL});
            this.GRD_VIEW_LISTE.GridControl = this.gridCntrl_LIST;
            this.GRD_VIEW_LISTE.Name = "GRD_VIEW_LISTE";
            this.GRD_VIEW_LISTE.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.GRD_VIEW_LISTE.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.GRD_VIEW_LISTE.OptionsView.ShowFooter = true;
            this.GRD_VIEW_LISTE.OptionsView.ShowGroupPanel = false;
            this.GRD_VIEW_LISTE.OptionsView.ShowIndicator = false;
            // 
            // colOid
            // 
            this.colOid.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.colOid.AppearanceCell.Options.UseFont = true;
            this.colOid.FieldName = "Oid";
            this.colOid.Name = "colOid";
            this.colOid.OptionsColumn.AllowEdit = false;
            // 
            // CL_SIRKET_KODU
            // 
            this.CL_SIRKET_KODU.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.CL_SIRKET_KODU.AppearanceCell.Options.UseFont = true;
            this.CL_SIRKET_KODU.Caption = "Firma Kodu";
            this.CL_SIRKET_KODU.FieldName = "SIRKET_KODU";
            this.CL_SIRKET_KODU.Name = "CL_SIRKET_KODU";
            this.CL_SIRKET_KODU.OptionsColumn.AllowEdit = false;
            this.CL_SIRKET_KODU.Visible = true;
            this.CL_SIRKET_KODU.VisibleIndex = 0;
            this.CL_SIRKET_KODU.Width = 79;
            // 
            // CL_KULLANICI_KODU
            // 
            this.CL_KULLANICI_KODU.Caption = "Kodu";
            this.CL_KULLANICI_KODU.FieldName = "KODU";
            this.CL_KULLANICI_KODU.Name = "CL_KULLANICI_KODU";
            this.CL_KULLANICI_KODU.OptionsColumn.AllowEdit = false;
            this.CL_KULLANICI_KODU.Visible = true;
            this.CL_KULLANICI_KODU.VisibleIndex = 1;
            this.CL_KULLANICI_KODU.Width = 137;
            // 
            // CL_KULLANICI_ADI
            // 
            this.CL_KULLANICI_ADI.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.CL_KULLANICI_ADI.AppearanceCell.Options.UseFont = true;
            this.CL_KULLANICI_ADI.Caption = "Adı";
            this.CL_KULLANICI_ADI.FieldName = "ADI";
            this.CL_KULLANICI_ADI.Name = "CL_KULLANICI_ADI";
            this.CL_KULLANICI_ADI.OptionsColumn.AllowEdit = false;
            this.CL_KULLANICI_ADI.Visible = true;
            this.CL_KULLANICI_ADI.VisibleIndex = 2;
            this.CL_KULLANICI_ADI.Width = 120;
            // 
            // CL_KULLANICI_SOYADI
            // 
            this.CL_KULLANICI_SOYADI.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.CL_KULLANICI_SOYADI.AppearanceCell.Options.UseFont = true;
            this.CL_KULLANICI_SOYADI.Caption = "Soyadı";
            this.CL_KULLANICI_SOYADI.FieldName = "SOYADI";
            this.CL_KULLANICI_SOYADI.Name = "CL_KULLANICI_SOYADI";
            this.CL_KULLANICI_SOYADI.OptionsColumn.AllowEdit = false;
            this.CL_KULLANICI_SOYADI.Visible = true;
            this.CL_KULLANICI_SOYADI.VisibleIndex = 3;
            this.CL_KULLANICI_SOYADI.Width = 127;
            // 
            // CL_KULLANICI_MAIL
            // 
            this.CL_KULLANICI_MAIL.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.CL_KULLANICI_MAIL.AppearanceCell.Options.UseFont = true;
            this.CL_KULLANICI_MAIL.Caption = "Kullanıcı Mail";
            this.CL_KULLANICI_MAIL.FieldName = "MAIL_ADRESI";
            this.CL_KULLANICI_MAIL.Name = "CL_KULLANICI_MAIL";
            this.CL_KULLANICI_MAIL.OptionsColumn.AllowEdit = false;
            this.CL_KULLANICI_MAIL.Visible = true;
            this.CL_KULLANICI_MAIL.VisibleIndex = 4;
            this.CL_KULLANICI_MAIL.Width = 258;
            // 
            // KULLANICI_LISTESI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 599);
            this.Controls.Add(this.gridCntrl_LIST);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "KULLANICI_LISTESI";
            this.Text = "KULLANICI_LISTESI";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_PROGRESS_BAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_ItmChck_AUTO_UPDATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCntrl_LIST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_VIEW_LISTE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem BTN_KAPAT;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem lbID;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem BTN_GUNCELLE;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar re_PROGRESS_BAR;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit re_ItmChck_AUTO_UPDATE;
        private DevExpress.XtraGrid.GridControl gridCntrl_LIST;
        private DevExpress.XtraGrid.Views.Grid.GridView GRD_VIEW_LISTE;
        private DevExpress.XtraGrid.Columns.GridColumn colOid;
        private DevExpress.XtraGrid.Columns.GridColumn CL_KULLANICI_MAIL;
        private DevExpress.XtraGrid.Columns.GridColumn CL_SIRKET_KODU;
        private DevExpress.XtraGrid.Columns.GridColumn CL_KULLANICI_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn CL_KULLANICI_SOYADI;
        private DevExpress.XtraGrid.Columns.GridColumn CL_KULLANICI_KODU;
    }
}