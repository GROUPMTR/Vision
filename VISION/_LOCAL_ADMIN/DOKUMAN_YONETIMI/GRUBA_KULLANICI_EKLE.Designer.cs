namespace VISION._LOCAL_ADMIN.DOKUMAN_YONETIMI
{
    partial class GRUBA_KULLANICI_EKLE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GRUBA_KULLANICI_EKLE));
            this.barManagers = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.BTN_KAPAT = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_KAYDET = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lbID = new DevExpress.XtraBars.BarStaticItem();
            this.lbKodu = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.contextMenu_SIL = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MN_SIL = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu_EKLE = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MN_EKLE = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdCntrl_HAKLARI = new DevExpress.XtraGrid.GridControl();
            this.GRDW_ONAY_LISTE = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdCntrl_GENEL = new DevExpress.XtraGrid.GridControl();
            this.GRDW_GENEL_KULLANICI_LISTE = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.CMB_ONAY_GRUBU = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl31 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManagers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.contextMenu_SIL.SuspendLayout();
            this.contextMenu_EKLE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCntrl_HAKLARI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDW_ONAY_LISTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCntrl_GENEL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDW_GENEL_KULLANICI_LISTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CMB_ONAY_GRUBU.Properties)).BeginInit();
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTN_KAPAT, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTN_KAYDET, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // BTN_KAPAT
            // 
            this.BTN_KAPAT.Caption = "Kapat";
            this.BTN_KAPAT.Glyph = ((System.Drawing.Image)(resources.GetObject("BTN_KAPAT.Glyph")));
            this.BTN_KAPAT.Id = 0;
            this.BTN_KAPAT.Name = "BTN_KAPAT";
            // 
            // BTN_KAYDET
            // 
            this.BTN_KAYDET.Caption = "Kaydet";
            this.BTN_KAYDET.Glyph = ((System.Drawing.Image)(resources.GetObject("BTN_KAYDET.Glyph")));
            this.BTN_KAYDET.Id = 1;
            this.BTN_KAYDET.Name = "BTN_KAYDET";
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
            this.barDockControlTop.Size = new System.Drawing.Size(834, 45);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 453);
            this.barDockControlBottom.Size = new System.Drawing.Size(834, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 45);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 408);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(834, 45);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 408);
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
            // contextMenu_SIL
            // 
            this.contextMenu_SIL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MN_SIL});
            this.contextMenu_SIL.Name = "contextMenus";
            this.contextMenu_SIL.Size = new System.Drawing.Size(87, 26);
            // 
            // MN_SIL
            // 
            this.MN_SIL.Name = "MN_SIL";
            this.MN_SIL.Size = new System.Drawing.Size(86, 22);
            this.MN_SIL.Text = "Sil";
            // 
            // contextMenu_EKLE
            // 
            this.contextMenu_EKLE.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MN_EKLE});
            this.contextMenu_EKLE.Name = "contextMenus";
            this.contextMenu_EKLE.Size = new System.Drawing.Size(100, 26);
            // 
            // MN_EKLE
            // 
            this.MN_EKLE.Name = "MN_EKLE";
            this.MN_EKLE.Size = new System.Drawing.Size(99, 22);
            this.MN_EKLE.Text = "EKLE";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 81);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grdCntrl_HAKLARI);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdCntrl_GENEL);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(834, 372);
            this.splitContainerControl1.SplitterPosition = 418;
            this.splitContainerControl1.TabIndex = 251;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // grdCntrl_HAKLARI
            // 
            this.grdCntrl_HAKLARI.ContextMenuStrip = this.contextMenu_SIL;
            this.grdCntrl_HAKLARI.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdCntrl_HAKLARI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCntrl_HAKLARI.Location = new System.Drawing.Point(0, 0);
            this.grdCntrl_HAKLARI.MainView = this.GRDW_ONAY_LISTE;
            this.grdCntrl_HAKLARI.Name = "grdCntrl_HAKLARI";
            this.grdCntrl_HAKLARI.Size = new System.Drawing.Size(418, 372);
            this.grdCntrl_HAKLARI.TabIndex = 242;
            this.grdCntrl_HAKLARI.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GRDW_ONAY_LISTE});
            // 
            // GRDW_ONAY_LISTE
            // 
            this.GRDW_ONAY_LISTE.ColumnPanelRowHeight = 40;
            this.GRDW_ONAY_LISTE.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn8,
            this.gridColumn9});
            this.GRDW_ONAY_LISTE.GridControl = this.grdCntrl_HAKLARI;
            this.GRDW_ONAY_LISTE.Name = "GRDW_ONAY_LISTE";
            this.GRDW_ONAY_LISTE.OptionsBehavior.Editable = false;
            this.GRDW_ONAY_LISTE.OptionsView.ShowAutoFilterRow = true;
            this.GRDW_ONAY_LISTE.OptionsView.ShowGroupPanel = false;
            this.GRDW_ONAY_LISTE.OptionsView.ShowIndicator = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.Caption = "ONAYLAYACAKLAR";
            this.gridColumn12.FieldName = "ONAYLAYAN";
            this.gridColumn12.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn12.Image")));
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            this.gridColumn12.Width = 215;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "SIRA NO";
            this.gridColumn8.FieldName = "SIRA_NO";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Width = 57;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "ÜNVANI";
            this.gridColumn9.FieldName = "UNVANI";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            this.gridColumn9.Width = 107;
            // 
            // grdCntrl_GENEL
            // 
            this.grdCntrl_GENEL.ContextMenuStrip = this.contextMenu_EKLE;
            this.grdCntrl_GENEL.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdCntrl_GENEL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCntrl_GENEL.Location = new System.Drawing.Point(0, 0);
            this.grdCntrl_GENEL.MainView = this.GRDW_GENEL_KULLANICI_LISTE;
            this.grdCntrl_GENEL.Name = "grdCntrl_GENEL";
            this.grdCntrl_GENEL.Size = new System.Drawing.Size(410, 372);
            this.grdCntrl_GENEL.TabIndex = 242;
            this.grdCntrl_GENEL.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GRDW_GENEL_KULLANICI_LISTE});
            // 
            // GRDW_GENEL_KULLANICI_LISTE
            // 
            this.GRDW_GENEL_KULLANICI_LISTE.ColumnPanelRowHeight = 40;
            this.GRDW_GENEL_KULLANICI_LISTE.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn6});
            this.GRDW_GENEL_KULLANICI_LISTE.GridControl = this.grdCntrl_GENEL;
            this.GRDW_GENEL_KULLANICI_LISTE.Name = "GRDW_GENEL_KULLANICI_LISTE";
            this.GRDW_GENEL_KULLANICI_LISTE.OptionsBehavior.Editable = false;
            this.GRDW_GENEL_KULLANICI_LISTE.OptionsSelection.MultiSelect = true;
            this.GRDW_GENEL_KULLANICI_LISTE.OptionsView.ShowAutoFilterRow = true;
            this.GRDW_GENEL_KULLANICI_LISTE.OptionsView.ShowGroupPanel = false;
            this.GRDW_GENEL_KULLANICI_LISTE.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No";
            this.gridColumn1.FieldName = "OID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "KULLANICI LİSTESİ";
            this.gridColumn5.FieldName = "MAIL_ADRESI";
            this.gridColumn5.Image = ((System.Drawing.Image)(resources.GetObject("gridColumn5.Image")));
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 335;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "ÜNVANI";
            this.gridColumn6.FieldName = "UNVANI";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 116;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.CMB_ONAY_GRUBU);
            this.groupControl1.Controls.Add(this.labelControl31);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 45);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(834, 36);
            this.groupControl1.TabIndex = 252;
            this.groupControl1.Text = "groupControl1";
            // 
            // CMB_ONAY_GRUBU
            // 
            this.CMB_ONAY_GRUBU.EditValue = "";
            this.CMB_ONAY_GRUBU.Location = new System.Drawing.Point(96, 7);
            this.CMB_ONAY_GRUBU.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CMB_ONAY_GRUBU.Name = "CMB_ONAY_GRUBU";
            this.CMB_ONAY_GRUBU.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CMB_ONAY_GRUBU.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CMB_ONAY_GRUBU.Size = new System.Drawing.Size(313, 20);
            this.CMB_ONAY_GRUBU.TabIndex = 244;
            // 
            // labelControl31
            // 
            this.labelControl31.Location = new System.Drawing.Point(20, 10);
            this.labelControl31.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl31.Name = "labelControl31";
            this.labelControl31.Size = new System.Drawing.Size(58, 13);
            this.labelControl31.TabIndex = 243;
            this.labelControl31.Text = "Onay Grubu";
            // 
            // GRUBA_KULLANICI_EKLE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 480);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "GRUBA_KULLANICI_EKLE";
            this.Text = "GRUBA_KULLANICI_EKLE";
            ((System.ComponentModel.ISupportInitialize)(this.barManagers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.contextMenu_SIL.ResumeLayout(false);
            this.contextMenu_EKLE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCntrl_HAKLARI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDW_ONAY_LISTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCntrl_GENEL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDW_GENEL_KULLANICI_LISTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CMB_ONAY_GRUBU.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagers;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem BTN_KAPAT;
        public DevExpress.XtraBars.BarButtonItem BTN_KAYDET;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem lbID;
        private DevExpress.XtraBars.BarStaticItem lbKodu;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl grdCntrl_HAKLARI;
        private System.Windows.Forms.ContextMenuStrip contextMenu_SIL;
        private System.Windows.Forms.ToolStripMenuItem MN_SIL;
        private DevExpress.XtraGrid.Views.Grid.GridView GRDW_ONAY_LISTE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.GridControl grdCntrl_GENEL;
        private System.Windows.Forms.ContextMenuStrip contextMenu_EKLE;
        private System.Windows.Forms.ToolStripMenuItem MN_EKLE;
        private DevExpress.XtraGrid.Views.Grid.GridView GRDW_GENEL_KULLANICI_LISTE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit CMB_ONAY_GRUBU;
        private DevExpress.XtraEditors.LabelControl labelControl31;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}