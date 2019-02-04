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

namespace VISION.FINANS.MUHASEBE_AKTARIMI
{
    public partial class MUHASEBE_AKTARIMI : DevExpress.XtraEditors.XtraForm
    {
        public MUHASEBE_AKTARIMI()
        {
            InitializeComponent();
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}