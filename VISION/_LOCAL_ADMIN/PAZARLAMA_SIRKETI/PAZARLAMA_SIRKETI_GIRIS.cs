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

namespace VISION._LOCAL_ADMIN.PAZARLAMA_SIRKETI
{
    public partial class PAZARLAMA_SIRKETI_GIRIS : DevExpress.XtraEditors.XtraForm
    {
        public PAZARLAMA_SIRKETI_GIRIS()
        {
            InitializeComponent();
        }

        private void BR_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void BR_YENI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}