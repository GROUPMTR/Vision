using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;

namespace VISION.FINANS
{
    public partial class WaitPrint : WaitForm
    {
        public WaitPrint(string Path, int xi)
        {
            InitializeComponent();

            progressPanel1.Caption = xi.ToString();
            webBrowsers.Url = new Uri("file:///" + Path);


            this.progressPanel1.AutoHeight = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }

        private void webBrowsers_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowsers.Print();

            Close();
        }
    }
}