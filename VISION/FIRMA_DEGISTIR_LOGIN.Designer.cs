namespace VISION
{
    partial class FIRMA_DEGISTIR_LOGIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIRMA_DEGISTIR_LOGIN));
            this.gridLook_USERLIST = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEditViews = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label1 = new System.Windows.Forms.Label();
            this.bttn_Vazgec = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bttn_Tamam = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridLook_USERLIST.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViews)).BeginInit();
            this.SuspendLayout();
            // 
            // gridLook_USERLIST
            // 
            this.gridLook_USERLIST.EditValue = "";
            this.gridLook_USERLIST.Location = new System.Drawing.Point(111, 53);
            this.gridLook_USERLIST.Name = "gridLook_USERLIST";
            this.gridLook_USERLIST.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridLook_USERLIST.Properties.Appearance.Options.UseFont = true;
            this.gridLook_USERLIST.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLook_USERLIST.Properties.NullText = "";
            this.gridLook_USERLIST.Properties.View = this.gridLookUpEditViews;
            this.gridLook_USERLIST.Size = new System.Drawing.Size(243, 22);
            this.gridLook_USERLIST.TabIndex = 322;
            // 
            // gridLookUpEditViews
            // 
            this.gridLookUpEditViews.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn3});
            this.gridLookUpEditViews.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEditViews.Name = "gridLookUpEditViews";
            this.gridLookUpEditViews.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEditViews.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEditViews.OptionsView.ShowGroupPanel = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(110, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 324;
            this.label1.Text = "Firma";
            // 
            // bttn_Vazgec
            // 
            this.bttn_Vazgec.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_Vazgec.Appearance.Options.UseFont = true;
            this.bttn_Vazgec.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttn_Vazgec.Image = ((System.Drawing.Image)(resources.GetObject("bttn_Vazgec.Image")));
            this.bttn_Vazgec.Location = new System.Drawing.Point(153, 81);
            this.bttn_Vazgec.Name = "bttn_Vazgec";
            this.bttn_Vazgec.Size = new System.Drawing.Size(97, 32);
            this.bttn_Vazgec.TabIndex = 325;
            this.bttn_Vazgec.Text = "Vazgeç";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "No";
            this.gridColumn2.FieldName = "FIRMAID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 53;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Firma Listesi";
            this.gridColumn1.FieldName = "FIRMALAR";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 570;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Firma Kodu";
            this.gridColumn3.FieldName = "FIRMA_KODU";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 73;
            // 
            // bttn_Tamam
            // 
            this.bttn_Tamam.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bttn_Tamam.Appearance.Options.UseFont = true;
            this.bttn_Tamam.Image = ((System.Drawing.Image)(resources.GetObject("bttn_Tamam.Image")));
            this.bttn_Tamam.Location = new System.Drawing.Point(256, 81);
            this.bttn_Tamam.Name = "bttn_Tamam";
            this.bttn_Tamam.Size = new System.Drawing.Size(97, 32);
            this.bttn_Tamam.TabIndex = 323;
            this.bttn_Tamam.Text = "Tamam";
            // 
            // FIRMA_DEGISTIR_LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 141);
            this.Controls.Add(this.bttn_Vazgec);
            this.Controls.Add(this.gridLook_USERLIST);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bttn_Tamam);
            this.Name = "FIRMA_DEGISTIR_LOGIN";
            this.Text = "FIRMA_DEGISTIR_LOGIN";
            ((System.ComponentModel.ISupportInitialize)(this.gridLook_USERLIST.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditViews)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bttn_Vazgec;
        private DevExpress.XtraEditors.GridLookUpEdit gridLook_USERLIST;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEditViews;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton bttn_Tamam;
    }
}