namespace VISION._LOCAL_ADMIN.SABITLER
{
    partial class GENEL_LISTE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GENEL_LISTE));
            this.GRD_LISTE = new DevExpress.XtraGrid.GridControl();
            this.GRD_VIEW_LISTE = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridClm_SiraNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridClm_DergiBirimleri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManagers = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.BR_KAPAT = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_LISTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_VIEW_LISTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GRD_LISTE
            // 
            this.GRD_LISTE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GRD_LISTE.Location = new System.Drawing.Point(0, 47);
            this.GRD_LISTE.MainView = this.GRD_VIEW_LISTE;
            this.GRD_LISTE.Name = "GRD_LISTE";
            this.GRD_LISTE.Size = new System.Drawing.Size(512, 572);
            this.GRD_LISTE.TabIndex = 547;
            this.GRD_LISTE.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GRD_VIEW_LISTE});
            this.GRD_LISTE.Click += new System.EventHandler(this.GRD_LISTE_Click);
            this.GRD_LISTE.DoubleClick += new System.EventHandler(this.GRD_LISTE_DoubleClick);
            // 
            // GRD_VIEW_LISTE
            // 
            this.GRD_VIEW_LISTE.ColumnPanelRowHeight = 40;
            this.GRD_VIEW_LISTE.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridClm_SiraNo,
            this.gridClm_DergiBirimleri});
            this.GRD_VIEW_LISTE.CustomizationFormBounds = new System.Drawing.Rectangle(807, 482, 217, 198);
            this.GRD_VIEW_LISTE.GridControl = this.GRD_LISTE;
            this.GRD_VIEW_LISTE.IndicatorWidth = 30;
            this.GRD_VIEW_LISTE.Name = "GRD_VIEW_LISTE";
            this.GRD_VIEW_LISTE.OptionsSelection.MultiSelect = true;
            this.GRD_VIEW_LISTE.OptionsView.ShowAutoFilterRow = true;
            this.GRD_VIEW_LISTE.OptionsView.ShowFooter = true;
            this.GRD_VIEW_LISTE.OptionsView.ShowGroupPanel = false;
            // 
            // gridClm_SiraNo
            // 
            this.gridClm_SiraNo.Caption = "Sıra No";
            this.gridClm_SiraNo.FieldName = "SIRA_INDEX";
            this.gridClm_SiraNo.Name = "gridClm_SiraNo";
            this.gridClm_SiraNo.OptionsColumn.AllowEdit = false;
            this.gridClm_SiraNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridClm_SiraNo.Width = 50;
            // 
            // gridClm_DergiBirimleri
            // 
            this.gridClm_DergiBirimleri.AppearanceHeader.Options.UseTextOptions = true;
            this.gridClm_DergiBirimleri.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridClm_DergiBirimleri.Caption = "Açıklama";
            this.gridClm_DergiBirimleri.FieldName = "DEFAULT_ACIKLAMA";
            this.gridClm_DergiBirimleri.Name = "gridClm_DergiBirimleri";
            this.gridClm_DergiBirimleri.OptionsColumn.AllowEdit = false;
            this.gridClm_DergiBirimleri.Visible = true;
            this.gridClm_DergiBirimleri.VisibleIndex = 0;
            this.gridClm_DergiBirimleri.Width = 428;
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
            this.BR_KAPAT});
            this.barManagers.MaxItemId = 28;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BR_KAPAT, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(512, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 619);
            this.barDockControlBottom.Size = new System.Drawing.Size(512, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 572);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(512, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 572);
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // GENEL_LISTE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 644);
            this.Controls.Add(this.GRD_LISTE);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "GENEL_LISTE";
            this.Text = "GENEL_LISTE";
            ((System.ComponentModel.ISupportInitialize)(this.GRD_LISTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_VIEW_LISTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GRD_LISTE;
        private DevExpress.XtraGrid.Views.Grid.GridView GRD_VIEW_LISTE;
        private DevExpress.XtraGrid.Columns.GridColumn gridClm_SiraNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridClm_DergiBirimleri;
        private DevExpress.XtraBars.BarManager barManagers;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem BR_KAPAT;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
    }
}