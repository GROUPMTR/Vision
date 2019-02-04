namespace VISION.FINANS.ERP.ADMIN
{
    partial class CL_CARD_UPDATE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CL_CARD_UPDATE));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.BTN_KAPAT = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_GONDER = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.BR_CARI_BILGI = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridCntrl_LIST = new DevExpress.XtraGrid.GridControl();
            this.gridView_LIST = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.re_ImageCmbBx_FC = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.re_ImageCmbBx_AKTARIM_DURUMU = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCntrl_LIST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_LIST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_ImageCmbBx_FC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_ImageCmbBx_AKTARIM_DURUMU)).BeginInit();
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
            this.BTN_GONDER,
            this.BR_CARI_BILGI});
            this.barManager1.MaxItemId = 7;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTN_KAPAT, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTN_GONDER, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // BTN_KAPAT
            // 
            this.BTN_KAPAT.Caption = "Kapat";
            this.BTN_KAPAT.Id = 0;
            this.BTN_KAPAT.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTN_KAPAT.ImageOptions.Image")));
            this.BTN_KAPAT.Name = "BTN_KAPAT";
            this.BTN_KAPAT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_KAPAT_ItemClick);
            // 
            // BTN_GONDER
            // 
            this.BTN_GONDER.Caption = "Gönder";
            this.BTN_GONDER.Id = 1;
            this.BTN_GONDER.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTN_GONDER.ImageOptions.Image")));
            this.BTN_GONDER.Name = "BTN_GONDER";
            this.BTN_GONDER.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_GONDER_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BR_CARI_BILGI)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // BR_CARI_BILGI
            // 
            this.BR_CARI_BILGI.Caption = "barStaticItem1";
            this.BR_CARI_BILGI.Id = 6;
            this.BR_CARI_BILGI.Name = "BR_CARI_BILGI";
            this.BR_CARI_BILGI.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1390, 45);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 730);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1390, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 45);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 685);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1390, 45);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 685);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Caption = "Check";
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // gridCntrl_LIST
            // 
            this.gridCntrl_LIST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCntrl_LIST.Location = new System.Drawing.Point(0, 45);
            this.gridCntrl_LIST.MainView = this.gridView_LIST;
            this.gridCntrl_LIST.Name = "gridCntrl_LIST";
            this.gridCntrl_LIST.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.re_ImageCmbBx_FC,
            this.re_ImageCmbBx_AKTARIM_DURUMU});
            this.gridCntrl_LIST.Size = new System.Drawing.Size(1390, 685);
            this.gridCntrl_LIST.TabIndex = 8;
            this.gridCntrl_LIST.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_LIST});
            // 
            // gridView_LIST
            // 
            this.gridView_LIST.ColumnPanelRowHeight = 40;
            this.gridView_LIST.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn8,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gridView_LIST.GridControl = this.gridCntrl_LIST;
            this.gridView_LIST.Name = "gridView_LIST";
            this.gridView_LIST.OptionsSelection.MultiSelect = true;
            this.gridView_LIST.OptionsView.ColumnAutoWidth = false;
            this.gridView_LIST.OptionsView.ShowFooter = true;
            this.gridView_LIST.OptionsView.ShowGroupPanel = false;
            this.gridView_LIST.OptionsView.ShowIndicator = false;
            this.gridView_LIST.DoubleClick += new System.EventHandler(this.gridView_LIST_DoubleClick);
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn11.Caption = "CODE";
            this.gridColumn11.FieldName = "CODE";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            this.gridColumn11.Width = 149;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn8.Caption = "TITLE";
            this.gridColumn8.FieldName = "TITLE";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 352;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "ADDRESS1";
            this.gridColumn4.FieldName = "ADDRESS1";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 332;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "TELEPHONE1";
            this.gridColumn5.FieldName = "TELEPHONE1";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 132;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "FAX";
            this.gridColumn6.FieldName = "FAX";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "ADDRESS2";
            this.gridColumn7.FieldName = "ADDRESS2";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 291;
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
            // CL_CARD_UPDATE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 757);
            this.Controls.Add(this.gridCntrl_LIST);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "CL_CARD_UPDATE";
            this.Text = "CL_CARD_UPDATE";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCntrl_LIST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_LIST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_ImageCmbBx_FC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_ImageCmbBx_AKTARIM_DURUMU)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem BTN_KAPAT;
        private DevExpress.XtraBars.BarButtonItem BTN_GONDER;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem BR_CARI_BILGI;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.GridControl gridCntrl_LIST;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_LIST;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox re_ImageCmbBx_FC;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox re_ImageCmbBx_AKTARIM_DURUMU;
    }
}