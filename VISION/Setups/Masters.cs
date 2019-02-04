using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
namespace Setups
{
    public partial class Masters : DevExpress.XtraEditors.XtraForm
    {   private static string MYKEY = "456as4d6a73a2fghHJS4865a87932d(d4586qzxxiwopdGKQPGT712lsa4d4sadas8";
        public Masters()
        {
            InitializeComponent();
        }

        private void br_KAPAT_Click(object sender, EventArgs e)
        {
            Close();
        }

         private static string encrypt(string value)
        {
            try
            {
                TripleDESCryptoServiceProvider objDESCrypto =
                    new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();
                byte[] byteHash, byteBuff;
                string strTempKey = MYKEY;
                byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB
                byteBuff = ASCIIEncoding.ASCII.GetBytes(value);
                return Convert.ToBase64String(objDESCrypto.CreateEncryptor().
                    TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }
            catch (Exception ex)
            {
                return "Input was not valid. " + ex.Message;
            }
        }

        private static string decrypt(string value)
        {
            try
            {
                TripleDESCryptoServiceProvider objDESCrypto =
                    new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();
                byte[] byteHash, byteBuff;
                string strTempKey = MYKEY;
                byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB
                byteBuff = Convert.FromBase64String(value);
                string strDecrypted = ASCIIEncoding.ASCII.GetString
                (objDESCrypto.CreateDecryptor().TransformFinalBlock
                (byteBuff, 0, byteBuff.Length));
                objDESCrypto = null;
                return strDecrypted;
            }
            catch (Exception ex)
            {
                return "Wrong Input. " + ex.Message;
            }
        }

        private void br_KAYDET_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("SRVCNNT.DAT"))
            {
                writer.WriteLine(encrypt(TXT_SERVER.Text));
                writer.WriteLine(encrypt(TEXT_DB.Text));
                writer.WriteLine(encrypt(TEXT_LOGIN.Text));
                writer.WriteLine(encrypt(TEXT_PASSWORD.Text));
            }
        }
    }
    }
}
