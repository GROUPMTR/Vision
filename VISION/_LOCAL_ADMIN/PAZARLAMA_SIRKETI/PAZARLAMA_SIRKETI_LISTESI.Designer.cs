﻿namespace VISION._LOCAL_ADMIN.PAZARLAMA_SIRKETI
{
    partial class PAZARLAMA_SIRKETI_LISTESI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PAZARLAMA_SIRKETI_LISTESI));
            this.barManagers = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.BR_KAPAT = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
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
            this.GRD_LISTE = new DevExpress.XtraGrid.GridControl();
            this.GRD_VIEW_LISTE = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdClmNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdClmMusteriKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdClmMusteriAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManagers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_LISTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_VIEW_LISTE)).BeginInit();
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
            this.barButtonItem8});
            this.barManagers.MaxItemId = 26;
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
            this.BR_KAPAT.Id = 0;
            this.BR_KAPAT.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BR_KAPAT.ImageOptions.Image")));
            this.BR_KAPAT.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BR_KAPAT.ImageOptions.LargeImage")));
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
            this.barDockControlTop.Manager = this.barManagers;
            this.barDockControlTop.Size = new System.Drawing.Size(624, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 667);
            this.barDockControlBottom.Manager = this.barManagers;
            this.barDockControlBottom.Size = new System.Drawing.Size(624, 21);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Manager = this.barManagers;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 638);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(624, 29);
            this.barDockControlRight.Manager = this.barManagers;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 638);
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
            // GRD_LISTE
            // 
            this.GRD_LISTE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GRD_LISTE.Location = new System.Drawing.Point(0, 29);
            this.GRD_LISTE.MainView = this.GRD_VIEW_LISTE;
            this.GRD_LISTE.Name = "GRD_LISTE";
            this.GRD_LISTE.Size = new System.Drawing.Size(624, 638);
            this.GRD_LISTE.TabIndex = 202;
            this.GRD_LISTE.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GRD_VIEW_LISTE});
            this.GRD_LISTE.DoubleClick += new System.EventHandler(this.GRD_LISTE_DoubleClick);
            // 
            // GRD_VIEW_LISTE
            // 
            this.GRD_VIEW_LISTE.ColumnPanelRowHeight = 40;
            this.GRD_VIEW_LISTE.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdClmNo,
            this.grdClmMusteriKodu,
            this.grdClmMusteriAdi});
            this.GRD_VIEW_LISTE.GridControl = this.GRD_LISTE;
            this.GRD_VIEW_LISTE.Name = "GRD_VIEW_LISTE";
            this.GRD_VIEW_LISTE.OptionsBehavior.Editable = false;
            this.GRD_VIEW_LISTE.OptionsView.ShowAutoFilterRow = true;
            this.GRD_VIEW_LISTE.OptionsView.ShowGroupPanel = false;
            this.GRD_VIEW_LISTE.OptionsView.ShowIndicator = false;
            this.GRD_VIEW_LISTE.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.grdClmMusteriKodu, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // grdClmNo
            // 
            this.grdClmNo.Caption = "No";
            this.grdClmNo.FieldName = "MUSTERIAUTOID";
            this.grdClmNo.Name = "grdClmNo";
            // 
            // grdClmMusteriKodu
            // 
            this.grdClmMusteriKodu.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdClmMusteriKodu.AppearanceCell.Options.UseFont = true;
            this.grdClmMusteriKodu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdClmMusteriKodu.AppearanceHeader.Options.UseFont = true;
            this.grdClmMusteriKodu.Caption = "Pazarlama Şirketi Kodu";
            this.grdClmMusteriKodu.FieldName = "KODU";
            this.grdClmMusteriKodu.Name = "grdClmMusteriKodu";
            this.grdClmMusteriKodu.OptionsColumn.AllowIncrementalSearch = false;
            this.grdClmMusteriKodu.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.grdClmMusteriKodu.OptionsColumn.FixedWidth = true;
            this.grdClmMusteriKodu.OptionsColumn.ReadOnly = true;
            this.grdClmMusteriKodu.Visible = true;
            this.grdClmMusteriKodu.VisibleIndex = 0;
            this.grdClmMusteriKodu.Width = 223;
            // 
            // grdClmMusteriAdi
            // 
            this.grdClmMusteriAdi.Caption = "Pazarlama Şirketi Adı";
            this.grdClmMusteriAdi.FieldName = "UNVANI";
            this.grdClmMusteriAdi.Name = "grdClmMusteriAdi";
            this.grdClmMusteriAdi.OptionsColumn.ReadOnly = true;
            this.grdClmMusteriAdi.Visible = true;
            this.grdClmMusteriAdi.VisibleIndex = 1;
            this.grdClmMusteriAdi.Width = 335;
            // 
            // PAZARLAMA_SIRKETI_LISTESI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 688);
            this.Controls.Add(this.GRD_LISTE);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PAZARLAMA_SIRKETI_LISTESI";
            this.Text = "Pazarlama Şirketi Listesi";
            ((System.ComponentModel.ISupportInitialize)(this.barManagers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_LISTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_VIEW_LISTE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagers;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem BR_KAPAT;
        private DevExpress.XtraBars.Bar bar3;
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
        private DevExpress.XtraGrid.GridControl GRD_LISTE;
        private DevExpress.XtraGrid.Views.Grid.GridView GRD_VIEW_LISTE;
        private DevExpress.XtraGrid.Columns.GridColumn grdClmNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdClmMusteriKodu;
        private DevExpress.XtraGrid.Columns.GridColumn grdClmMusteriAdi;
    }
}