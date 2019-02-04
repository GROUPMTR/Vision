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

namespace VISION.TIMESHEET
{
    public partial class TARIH_ARALIGI : DevExpress.XtraEditors.XtraForm
    {
        public DateTime _BAS_TARIHI, _BITIS_TARIHI;
        public bool _OGLEN_TATILI;
        public string _BUTTON_TYPE;

        public TARIH_ARALIGI()
        {
            InitializeComponent();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _BUTTON_TYPE = "CLOSE";
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _BAS_TARIHI = (DateTime)dateEdit1.EditValue;
            _BITIS_TARIHI = (DateTime)dateEdit2.EditValue;
            _BUTTON_TYPE = "TAMAM";
            _OGLEN_TATILI = CHK_OGLEN_TATILI.Checked;
            _OGLEN_TATILI = false;
            Close();
        }
    }
}