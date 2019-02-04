namespace VISION.TIMESHEET
{
    partial class TIME_SHEET
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
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TIME_SHEET));
            this.cntxtMnStp_Plan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CNTXT_MUSTERI_SEC = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CNTXT_DIGER_SEC = new System.Windows.Forms.ToolStripMenuItem();
            this.CNTXT_REFRESH = new System.Windows.Forms.ToolStripMenuItem();
            this.schedulerControls = new DevExpress.XtraScheduler.SchedulerControl();
            this.barManagers = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.BR_KAPAT = new DevExpress.XtraBars.BarButtonItem();
            this.CMBX_DIREKTOR_LIST = new DevExpress.XtraBars.BarEditItem();
            this.re_CMBX_DIREKTROR_LIST = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.lbID = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.BR_ID = new DevExpress.XtraBars.BarStaticItem();
            this.BR_PARENT_ID = new DevExpress.XtraBars.BarStaticItem();
            this.BR_GUI = new DevExpress.XtraBars.BarStaticItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.schedulerStorages = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.dateNavigators = new DevExpress.XtraScheduler.DateNavigator();
            this.cntxtMnStp_Plan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_CMBX_DIREKTROR_LIST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigators)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigators.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // cntxtMnStp_Plan
            // 
            this.cntxtMnStp_Plan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cntxtMnStp_Plan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CNTXT_MUSTERI_SEC,
            this.toolStripSeparator3,
            this.CNTXT_DIGER_SEC,
            this.CNTXT_REFRESH});
            this.cntxtMnStp_Plan.Name = "cntxtMnStp_Plan";
            this.cntxtMnStp_Plan.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cntxtMnStp_Plan.Size = new System.Drawing.Size(162, 76);
            this.cntxtMnStp_Plan.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cntxtMnStp_Plan_ItemClicked);
            // 
            // CNTXT_MUSTERI_SEC
            // 
            this.CNTXT_MUSTERI_SEC.Name = "CNTXT_MUSTERI_SEC";
            this.CNTXT_MUSTERI_SEC.Size = new System.Drawing.Size(161, 22);
            this.CNTXT_MUSTERI_SEC.Text = "Müşteri Seç";
            this.CNTXT_MUSTERI_SEC.Click += new System.EventHandler(this.CNTXT_MUSTERI_SEC_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(158, 6);
            // 
            // CNTXT_DIGER_SEC
            // 
            this.CNTXT_DIGER_SEC.Name = "CNTXT_DIGER_SEC";
            this.CNTXT_DIGER_SEC.Size = new System.Drawing.Size(161, 22);
            this.CNTXT_DIGER_SEC.Text = "Diğer";
            this.CNTXT_DIGER_SEC.Click += new System.EventHandler(this.CNTXT_DIGER_SEC_Click);
            // 
            // CNTXT_REFRESH
            // 
            this.CNTXT_REFRESH.Name = "CNTXT_REFRESH";
            this.CNTXT_REFRESH.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.CNTXT_REFRESH.Size = new System.Drawing.Size(161, 22);
            this.CNTXT_REFRESH.Text = "Güncelle";
            // 
            // schedulerControls
            // 
            this.schedulerControls.ContextMenuStrip = this.cntxtMnStp_Plan;
            this.schedulerControls.DataStorage = this.schedulerStorages;
            this.schedulerControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControls.Location = new System.Drawing.Point(0, 33);
            this.schedulerControls.LookAndFeel.UseDefaultLookAndFeel = false;
            this.schedulerControls.MenuManager = this.barManagers;
            this.schedulerControls.Name = "schedulerControls";
            this.schedulerControls.OptionsCustomization.AllowAppointmentCopy = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControls.OptionsCustomization.AllowAppointmentCreate = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControls.OptionsCustomization.AllowAppointmentDelete = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControls.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControls.OptionsCustomization.AllowAppointmentDragBetweenResources = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControls.OptionsCustomization.AllowAppointmentEdit = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControls.OptionsCustomization.AllowAppointmentResize = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControls.OptionsCustomization.AllowDisplayAppointmentDependencyForm = DevExpress.XtraScheduler.AllowDisplayAppointmentDependencyForm.Never;
            this.schedulerControls.OptionsCustomization.AllowDisplayAppointmentForm = DevExpress.XtraScheduler.AllowDisplayAppointmentForm.Never;
            this.schedulerControls.OptionsCustomization.AllowInplaceEditor = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControls.OptionsView.NavigationButtons.Visibility = DevExpress.XtraScheduler.NavigationButtonVisibility.Never;
            this.schedulerControls.Size = new System.Drawing.Size(935, 525);
            this.schedulerControls.Start = new System.DateTime(2012, 12, 25, 0, 0, 0, 0);
            this.schedulerControls.TabIndex = 21;
            this.schedulerControls.Views.DayView.DayCount = 5;
            this.schedulerControls.Views.DayView.NavigationButtonVisibility = DevExpress.XtraScheduler.NavigationButtonVisibility.Never;
            this.schedulerControls.Views.DayView.ShowWorkTimeOnly = true;
            timeRuler1.TimeZoneId = "GTB Standard Time";
            timeRuler1.UseClientTimeZone = false;
            this.schedulerControls.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControls.Views.GanttView.Enabled = false;
            this.schedulerControls.Views.MonthView.Enabled = false;
            this.schedulerControls.Views.TimelineView.Enabled = false;
            this.schedulerControls.Views.WeekView.Enabled = false;
            this.schedulerControls.Views.WorkWeekView.Enabled = false;
            timeRuler2.TimeZoneId = "GTB Standard Time";
            timeRuler2.UseClientTimeZone = false;
            this.schedulerControls.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControls.PopupMenuShowing += new DevExpress.XtraScheduler.PopupMenuShowingEventHandler(this.schedulerControls_PopupMenuShowing);
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
            this.lbID,
            this.CMBX_DIREKTOR_LIST});
            this.barManagers.MaxItemId = 28;
            this.barManagers.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.re_CMBX_DIREKTROR_LIST});
            this.barManagers.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(352, 131);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BR_KAPAT, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.CMBX_DIREKTOR_LIST, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            // CMBX_DIREKTOR_LIST
            // 
            this.CMBX_DIREKTOR_LIST.Border = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.CMBX_DIREKTOR_LIST.Caption = "Direktör";
            this.CMBX_DIREKTOR_LIST.Edit = this.re_CMBX_DIREKTROR_LIST;
            this.CMBX_DIREKTOR_LIST.EditWidth = 244;
            this.CMBX_DIREKTOR_LIST.Id = 27;
            this.CMBX_DIREKTOR_LIST.Name = "CMBX_DIREKTOR_LIST";
            // 
            // re_CMBX_DIREKTROR_LIST
            // 
            this.re_CMBX_DIREKTROR_LIST.AutoHeight = false;
            this.re_CMBX_DIREKTROR_LIST.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.re_CMBX_DIREKTROR_LIST.Name = "re_CMBX_DIREKTROR_LIST";
            this.re_CMBX_DIREKTROR_LIST.NullText = "Seçiniz";
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
            this.barDockControlTop.Manager = this.barManagers;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.barDockControlTop.Size = new System.Drawing.Size(1112, 33);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 558);
            this.barDockControlBottom.Manager = this.barManagers;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.barDockControlBottom.Size = new System.Drawing.Size(1112, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 33);
            this.barDockControlLeft.Manager = this.barManagers;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 525);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1112, 33);
            this.barDockControlRight.Manager = this.barManagers;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 525);
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
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // schedulerStorages
            // 
            this.schedulerStorages.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("MAIL_ADRESI", "", DevExpress.XtraScheduler.FieldValueType.String));
            this.schedulerStorages.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStorages.Appointments.Mappings.Description = "Description";
            this.schedulerStorages.Appointments.Mappings.End = "EndDate";
            this.schedulerStorages.Appointments.Mappings.Label = "Label";
            this.schedulerStorages.Appointments.Mappings.Location = "Location";
            this.schedulerStorages.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            this.schedulerStorages.Appointments.Mappings.ReminderInfo = "ReminderInfo";
            this.schedulerStorages.Appointments.Mappings.ResourceId = "ResourceID";
            this.schedulerStorages.Appointments.Mappings.Start = "StartDate";
            this.schedulerStorages.Appointments.Mappings.Status = "Status";
            this.schedulerStorages.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorages.Appointments.Mappings.Type = "EventType";
            this.schedulerStorages.Resources.Mappings.Caption = "ResourceName";
            this.schedulerStorages.Resources.Mappings.Id = "ResourceID";
            // 
            // dateNavigators
            // 
            this.dateNavigators.AllowAnimatedContentChange = true;
            this.dateNavigators.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNavigators.CellPadding = new System.Windows.Forms.Padding(2);
            this.dateNavigators.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateNavigators.Dock = System.Windows.Forms.DockStyle.Right;
            this.dateNavigators.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dateNavigators.Location = new System.Drawing.Point(935, 33);
            this.dateNavigators.Name = "dateNavigators";
            this.dateNavigators.SchedulerControl = this.schedulerControls;
            this.dateNavigators.Size = new System.Drawing.Size(177, 525);
            this.dateNavigators.TabIndex = 22;
            // 
            // TIME_SHEET
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 583);
            this.Controls.Add(this.schedulerControls);
            this.Controls.Add(this.dateNavigators);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "TIME_SHEET";
            this.Text = "TIME_SHEET";
            this.cntxtMnStp_Plan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.re_CMBX_DIREKTROR_LIST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigators.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigators)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cntxtMnStp_Plan;
        private System.Windows.Forms.ToolStripMenuItem CNTXT_REFRESH;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem CNTXT_MUSTERI_SEC;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControls;
        private DevExpress.XtraScheduler.DateNavigator dateNavigators;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorages;
        private System.Windows.Forms.ToolStripMenuItem CNTXT_DIGER_SEC;
        private DevExpress.XtraBars.BarManager barManagers;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem BR_KAPAT;
        private DevExpress.XtraBars.BarEditItem CMBX_DIREKTOR_LIST;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox re_CMBX_DIREKTROR_LIST;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem lbID;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem BR_ID;
        private DevExpress.XtraBars.BarStaticItem BR_PARENT_ID;
        private DevExpress.XtraBars.BarStaticItem BR_GUI;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
    }
}