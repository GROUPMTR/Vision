namespace VISION._LOCAL_ADMIN.ONAY_GRUPLARI
{
    partial class GRUP_LISTESI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GRUP_LISTESI));
            this.barManagers = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.BTN_KAPAT = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lbID = new DevExpress.XtraBars.BarStaticItem();
            this.lbKodu = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.BTN_KAYDET = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridCntrl_LIST = new DevExpress.XtraGrid.GridControl();
            this.gridView_LIST = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTITLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSec = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManagers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCntrl_LIST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_LIST)).BeginInit();
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
            this.BTN_KAPAT,
            this.BTN_KAYDET,
            this.lbID,
            this.lbKodu});
            this.barManagers.MaxItemId = 10;
            this.barManagers.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemTextEdit1});
            this.barManagers.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTN_KAPAT, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lbID),
            new DevExpress.XtraBars.LinkPersistInfo(this.lbKodu)});
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
            // lbKodu
            // 
            this.lbKodu.Id = 9;
            this.lbKodu.Name = "lbKodu";
            this.lbKodu.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(476, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 506);
            this.barDockControlBottom.Size = new System.Drawing.Size(476, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 475);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(476, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 475);
            // 
            // BTN_KAYDET
            // 
            this.BTN_KAYDET.Caption = "Kaydet";
            this.BTN_KAYDET.Glyph = ((System.Drawing.Image)(resources.GetObject("BTN_KAYDET.Glyph")));
            this.BTN_KAYDET.Id = 1;
            this.BTN_KAYDET.Name = "BTN_KAYDET";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "GENEL",
            "DEPARTMAN",
            "USER"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gridCntrl_LIST
            // 
            this.gridCntrl_LIST.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridCntrl_LIST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCntrl_LIST.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridCntrl_LIST.Location = new System.Drawing.Point(0, 31);
            this.gridCntrl_LIST.MainView = this.gridView_LIST;
            this.gridCntrl_LIST.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridCntrl_LIST.Name = "gridCntrl_LIST";
            this.gridCntrl_LIST.Size = new System.Drawing.Size(476, 475);
            this.gridCntrl_LIST.TabIndex = 554;
            this.gridCntrl_LIST.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_LIST});
            // 
            // gridView_LIST
            // 
            this.gridView_LIST.ColumnPanelRowHeight = 40;
            this.gridView_LIST.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSec,
            this.colTITLE});
            this.gridView_LIST.GridControl = this.gridCntrl_LIST;
            this.gridView_LIST.Name = "gridView_LIST";
            this.gridView_LIST.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView_LIST.OptionsView.ShowAutoFilterRow = true;
            this.gridView_LIST.OptionsView.ShowFooter = true;
            this.gridView_LIST.OptionsView.ShowGroupPanel = false;
            // 
            // colTITLE
            // 
            this.colTITLE.AppearanceHeader.Options.UseTextOptions = true;
            this.colTITLE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTITLE.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTITLE.Caption = "Onay Grubu";
            this.colTITLE.FieldName = "ONAY_GRUBU";
            this.colTITLE.Image = ((System.Drawing.Image)(resources.GetObject("colTITLE.Image")));
            this.colTITLE.Name = "colTITLE";
            this.colTITLE.OptionsColumn.AllowEdit = false;
            this.colTITLE.Visible = true;
            this.colTITLE.VisibleIndex = 1;
            this.colTITLE.Width = 325;
            // 
            // colSec
            // 
            this.colSec.Caption = "Onay Grubu Türü";
            this.colSec.FieldName = "ONAY_GRUBU_TURU";
            this.colSec.Image = ((System.Drawing.Image)(resources.GetObject("colSec.Image")));
            this.colSec.Name = "colSec";
            this.colSec.OptionsColumn.AllowEdit = false;
            this.colSec.Visible = true;
            this.colSec.VisibleIndex = 0;
            this.colSec.Width = 133;
            // 
            // GRUP_LISTESI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 531);
            this.Controls.Add(this.gridCntrl_LIST);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "GRUP_LISTESI";
            this.Text = "GRUP_LISTESI";
            ((System.ComponentModel.ISupportInitialize)(this.barManagers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCntrl_LIST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_LIST)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagers;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem BTN_KAPAT;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem lbID;
        private DevExpress.XtraBars.BarStaticItem lbKodu;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraBars.BarButtonItem BTN_KAYDET;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.GridControl gridCntrl_LIST;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_LIST;
        private DevExpress.XtraGrid.Columns.GridColumn colTITLE;
        private DevExpress.XtraGrid.Columns.GridColumn colSec;
    }
}