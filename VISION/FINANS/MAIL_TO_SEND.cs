using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace VISION.FINANS
{
    public partial class MAIL_TO_SEND : DevExpress.XtraEditors.XtraForm
    {
        public string _Button = "CANCEL";
        public string to;
        public string subject;
        public string aciklama;
        public MAIL_TO_SEND()
        {
            InitializeComponent();

            ControlBox = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        }

        private void BTN_VAZGEC_Click(object sender, EventArgs e)
        {
            _Button = "CANCEL";
            Close();
        }

        private void BTN_TAMAM_Click(object sender, EventArgs e)
        {
            _Button = "OK";
            to = txt_TO.Text;
            subject = txt_SUBJECT.Text;
            aciklama = txt_DETAIL.Text;

            Close();
        }
    }
}