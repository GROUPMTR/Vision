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

namespace VISION.FINANS.ALIS_FATURASI
{
    public partial class ALIS_FATURASI_GIRIS_GIB : DevExpress.XtraEditors.XtraForm
    {
        public ALIS_FATURASI_GIRIS_GIB()
        {
            InitializeComponent();
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}