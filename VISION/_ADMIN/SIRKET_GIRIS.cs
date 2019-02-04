using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace VISION._ADMIN
{
    public partial class SIRKET_GIRIS : DevExpress.XtraEditors.XtraForm
    {
        public SIRKET_GIRIS()
        {
            InitializeComponent();
        }

        private void BR_KAYDET_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BR_LIST_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SIRKET_LISTESI LST = new SIRKET_LISTESI();
            LST.ShowDialog();
        }

        private void BR_PARAMETRELER_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SIRKET_PARAMETRELERI PR = new SIRKET_PARAMETRELERI();
            PR.ShowDialog();
        }

        private void BR_KAPAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void BR_KAYDET_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}