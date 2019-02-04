namespace VISION._LOCAL_ADMIN.KULLANICI
{
    partial class KULLANICI_GRUP_LISTESI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KULLANICI_GRUP_LISTESI));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.BTN_KAPAT = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lbID = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.BTN_EKLE = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_KAYDET = new DevExpress.XtraBars.BarButtonItem();
            this.re_PROGRESS_BAR = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.re_ItmChck_AUTO_UPDATE = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridCntrl_LIST = new DevExpress.XtraGrid.GridControl();
            this.gridView_LIST = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTITLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSec = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_PROGRESS_BAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_ItmChck_AUTO_UPDATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCntrl_LIST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_LIST)).BeginInit();
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
            this.barEditItem1,
            this.BTN_EKLE,
            this.BTN_KAYDET});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTN_KAPAT, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            this.barDockControlTop.Size = new System.Drawing.Size(416, 28);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 461);
            this.barDockControlBottom.Size = new System.Drawing.Size(416, 26);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 28);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 433);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(416, 28);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 433);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = null;
            this.barEditItem1.Id = 15;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // BTN_EKLE
            // 
            this.BTN_EKLE.Caption = "Ekle";
            this.BTN_EKLE.Glyph = ((System.Drawing.Image)(resources.GetObject("BTN_EKLE.Glyph")));
            this.BTN_EKLE.Id = 16;
            this.BTN_EKLE.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BTN_EKLE.LargeGlyph")));
            this.BTN_EKLE.Name = "BTN_EKLE";
            // 
            // BTN_KAYDET
            // 
            this.BTN_KAYDET.Caption = "Kaydet";
            this.BTN_KAYDET.Glyph = ((System.Drawing.Image)(resources.GetObject("BTN_KAYDET.Glyph")));
            this.BTN_KAYDET.Id = 17;
            this.BTN_KAYDET.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BTN_KAYDET.LargeGlyph")));
            this.BTN_KAYDET.Name = "BTN_KAYDET";
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
            this.gridCntrl_LIST.MainView = this.gridView_LIST;
            this.gridCntrl_LIST.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridCntrl_LIST.Name = "gridCntrl_LIST";
            this.gridCntrl_LIST.Size = new System.Drawing.Size(416, 433);
            this.gridCntrl_LIST.TabIndex = 555;
            this.gridCntrl_LIST.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_LIST});
            // 
            // gridView_LIST
            // 
            this.gridView_LIST.ColumnPanelRowHeight = 40;
            this.gridView_LIST.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOid,
            this.colTITLE,
            this.colSec});
            this.gridView_LIST.GridControl = this.gridCntrl_LIST;
            this.gridView_LIST.Name = "gridView_LIST";
            this.gridView_LIST.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView_LIST.OptionsView.ShowAutoFilterRow = true;
            this.gridView_LIST.OptionsView.ShowFooter = true;
            this.gridView_LIST.OptionsView.ShowGroupPanel = false;
            // 
            // colOid
            // 
            this.colOid.FieldName = "Oid";
            this.colOid.Name = "colOid";
            this.colOid.OptionsColumn.AllowEdit = false;
            // 
            // colTITLE
            // 
            this.colTITLE.AppearanceHeader.Options.UseTextOptions = true;
            this.colTITLE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTITLE.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTITLE.Caption = "GRUP KODU";
            this.colTITLE.FieldName = "KODU";
            this.colTITLE.Image = ((System.Drawing.Image)(resources.GetObject("colTITLE.Image")));
            this.colTITLE.Name = "colTITLE";
            this.colTITLE.OptionsColumn.AllowEdit = false;
            this.colTITLE.Visible = true;
            this.colTITLE.VisibleIndex = 0;
            this.colTITLE.Width = 551;
            // 
            // colSec
            // 
            this.colSec.FieldName = "Sec";
            this.colSec.Name = "colSec";
            this.colSec.OptionsColumn.AllowEdit = false;
            // 
            // KULLANICI_GRUP_LISTESI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 487);
            this.Controls.Add(this.gridCntrl_LIST);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "KULLANICI_GRUP_LISTESI";
            this.Text = "Kullanıcı Grup Listesi";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_PROGRESS_BAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_ItmChck_AUTO_UPDATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCntrl_LIST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_LIST)).EndInit();
            this.ResumeLayout(false);

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
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraBars.BarButtonItem BTN_EKLE;
        private DevExpress.XtraBars.BarButtonItem BTN_KAYDET;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar re_PROGRESS_BAR;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit re_ItmChck_AUTO_UPDATE;
        private DevExpress.XtraGrid.GridControl gridCntrl_LIST;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_LIST;
        private DevExpress.XtraGrid.Columns.GridColumn colOid;
        private DevExpress.XtraGrid.Columns.GridColumn colTITLE;
        private DevExpress.XtraGrid.Columns.GridColumn colSec;
    }
}