using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace VISION.FINANS.UBL
{


    public class ERP_CREATE_XML_PRINT
    {

        public bool Temp { get; set; }
        public bool ReSend { get; set; }
        public string UUID { get; set; }

        public DataSet _GLOBAL_CODE_KONTROL(string FIRMA_KODU, string _LOGICALREF)
        {
            DataSet dataset = new DataSet();
            string queryString = "SELECT * from dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_NO + "_01_PAYTRANS WHERE (FICHEREF='" + _LOGICALREF + "') AND  (MODULENR='4')";
            using (SqlConnection connection = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP.ToString()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(
                    queryString, connection);
                adapter.Fill(dataset);

            }
            return dataset;
        }


        public DataSet _GLOBALxc_CODE_KONTROL(string FIRMA_KODU, string _LOGICALREF)
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection con = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB.ToString()))
                {
                    con.Open();
                    string QueryString = "SELECT * from dbo.LG_" + _GLOBAL_PARAMETERS._SIRKET_KODU + "_01_PAYTRANS WHERE (FICHEREF='" + _LOGICALREF + "') AND  (MODULENR='4')";
                    SqlDataAdapter da = new SqlDataAdapter(QueryString, con);


                    da.Fill(dataSet, "dbo_MecraList");
                    //DataViewManager dvManager = new DataViewManager(dataSet);
                    //DataView dv = dvManager.CreateDataView(dataSet.Tables[0]);

                    con.Close();
                }
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message);
            }






            return dataSet;

            //DataTable vCURR_TABLE = new DataTable(); 
            //SqlConnection sqlConn = new SqlConnection(Masters._CONNECTIONSTRING_MDB); 
            //sqlConn.Open();
            //string QueryString = "SELECT  *  dbo.LG_" + Masters._SIRKET_NO + "_01_PAYTRANS WHERE (FICHEREF='" + _LOGICALREF + "') AND  (MODULENR='4')";
            //SqlDataAdapter dataAdapter = new SqlDataAdapter(QueryString, sqlConn);
            //DataSet ds=new DataSet ();

            //dataAdapter.Fill(vCURR_TABLE);
            //sqlConn.Close(); 

            //return vCURR_TABLE;

            //DataRow[] DATAROW = dty.Select("DEDUCTIONPART1=> 0.001");
            //SqlConnection ConnLine_DEFAULT = new SqlConnection(Masters._CONNECTIONSTRING_ERP);
            //SqlCommand myCommand_DEFAULT = new SqlCommand();
            //string QueryString = "SELECT  *  dbo.LG_" + Masters._SIRKET_NO + "_01_PAYTRANS WHERE (FICHEREF='" + _LOGICALREF + "') AND  (MODULENR='4')";
            //myCommand_DEFAULT.CommandText = QueryString;
            //myCommand_DEFAULT.CommandType = System.Data.CommandType.Text;
            //myCommand_DEFAULT.Connection = ConnLine_DEFAULT;
            //ConnLine_DEFAULT.Open();
            //SqlDataReader drd = myCommand_DEFAULT.ExecuteReader(CommandBehavior.CloseConnection);
            //while (drd.Read())
            //{
            //    if (drd["GLOBALCODE"] == DBNull.Value)
            //    {
            //        _GLOBAL_CODE = 42;
            //    }
            //    else
            //    {
            //        if (drd["GLOBALCODE"].ToString() == "1")
            //        {
            //            _GLOBAL_CODE = 20;
            //        }
            //        else
            //        {
            //            _GLOBAL_CODE = 42;
            //        }
            //    }
            //}
            //  return DATAROW;
        }

        public string Create(string FIRMA_KODU, DataRow Cfg, DataRow F, string BOX)
        {
            //F.Session.Reload(F);         

            FINANS.ERP._ERP_CLASS cls = new FINANS.ERP._ERP_CLASS();
            DataTable vCURR_TABLE = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP))
            {
                sqlConn.Open();
                string vCURRSQL = string.Format(cls.vCURRSQL, _GLOBAL_PARAMETERS._DBONAME);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(vCURRSQL, sqlConn);
                dataAdapter.Fill(vCURR_TABLE);
                sqlConn.Close();
            }



            string GIBFNO = F["FICHENO"].ToString();
            //if (GIBFNO.Length < 16)
            //{
            //    int xd = Convert.ToInt32(IZIBIZ_CLASS.Cfg["FSIRANO"].ToString());
            //    xd += 1;
            //    GIBFNO = IZIBIZ_CLASS.Cfg["PREF"] + DateTime.Now.ToString("yyyy") + xd.ToString().PadLeft(9, '0');

            //    using (SqlConnection sqlConn = new SqlConnection(Masters._CONNECTIONSTRING_MDB))
            //    {
            //        sqlConn.Open();
            //        SqlCommand myCmd = new SqlCommand();
            //        myCmd.CommandText = " UPDATE dbo.ADM_LGN_CAPIFIRM SET FSIRANO=@FSIRANO  WHERE (OID = @OID) and FIRMAID='" + Masters._SIRKET_NO + "'";
            //        myCmd.Parameters.Add("@FSIRANO", IZIBIZ_CLASS.Cfg["FSIRANO"]);
            //        myCmd.Parameters.Add("@OID", IZIBIZ_CLASS.Cfg["OID"]);
            //        myCmd.Connection = sqlConn;
            //        myCmd.ExecuteNonQuery();
            //        myCmd.Connection.Close();
            //    }
            //}

            UBL.InvoiceType Inv = new UBL.InvoiceType();

            Inv.UBLExtensions = new UBLExtensionsType[1];
            Inv.UBLExtensions[0] = new UBLExtensionsType();
            Inv.UBLExtensions[0].UBLExtension = new UBLExtensionType();
            Inv.UBLExtensions[0].UBLExtension.ExtensionContent = new ExtensionContentType();
            Inv.UBLVersionID = new UBLVersionIDType() { Value = "2.0" };
            Inv.CustomizationID = new CustomizationIDType() { Value = "TR1.0" };
            if (F["PROFILEID"] == DBNull.Value) F["PROFILEID"] = 1;
            if (Convert.ToInt16(F["PROFILEID"].ToString()) > 1)
                Inv.ProfileID = new ProfileIDType() { Value = "TICARIFATURA" };
            else
                Inv.ProfileID = new ProfileIDType() { Value = "TEMELFATURA" };

            Inv.ID = new IDType() { Value = GIBFNO };
            Inv.CopyIndicator = new CopyIndicatorType() { Value = false };

            if (ReSend)
            {
                string xstr = Guid.NewGuid().ToString();
                Inv.UUID = new UUIDType() { Value = xstr };
                this.UUID = xstr;
            }
            else
                Inv.UUID = new UUIDType() { Value = F["GUID"].ToString() };

            Inv.IssueDate = new IssueDateType() { Value = (DateTime)F["DATE_"] };

            if (Convert.ToInt16(F["TRCODE"].ToString()) == 6)
                Inv.InvoiceTypeCode = new InvoiceTypeCodeType() { Value = "IADE" };
            else
                Inv.InvoiceTypeCode = new InvoiceTypeCodeType() { Value = "SATIS" };
            string xNote = "";

            List<NoteType> notList = new List<NoteType>();
            if ((bool)IZIBIZ_CLASS.Cfg["OZEL_TASARIM"])
            {
                notList.Add(new NoteType() { Value = F["GENEXP1"] == null ? "" : F["GENEXP1"].ToString() });
                notList.Add(new NoteType() { Value = F["GENEXP2"] == null ? "" : F["GENEXP2"].ToString() });
                notList.Add(new NoteType() { Value = F["GENEXP3"] == null ? "" : F["GENEXP3"].ToString() });
                notList.Add(new NoteType() { Value = F["GENEXP4"] == null ? "" : F["GENEXP4"].ToString() });
            }
            else
            {
                if (F["GENEXP1"] != null && F["GENEXP1"].ToString().Trim() != "")
                    notList.Add(new NoteType() { Value = F["GENEXP1"].ToString() });
                if (F["GENEXP2"] != null && F["GENEXP2"].ToString().Trim() != "")
                    notList.Add(new NoteType() { Value = F["GENEXP2"].ToString() });
                if (F["GENEXP3"] != null && F["GENEXP3"].ToString().Trim() != "")
                    notList.Add(new NoteType() { Value = F["GENEXP3"].ToString() });
                if (F["GENEXP4"] != null && F["GENEXP4"].ToString().Trim() != "")
                    notList.Add(new NoteType() { Value = F["GENEXP4"].ToString() });
            }

            /// 
            /// BİRDEN ÇOK İRSALİYE BİLGİSİNİ VAR İSE NOT ALANINA YAZ STFİCHE İRSALİYE 
            ///  
            DataTable tblSTFICHE = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP))
            {
                sqlConn.Open();
                string sql = string.Format(" Select DISTINCT FICHENO,DATE_ From   {0}.dbo.LG_{1}_{2}_STFICHE Where INVOICEREF = {3} ", _GLOBAL_PARAMETERS._DBONAME, _GLOBAL_PARAMETERS._SIRKET_NO.ToString(), "01", F["LOGICALREF"]);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConn);
                dataAdapter.Fill(tblSTFICHE);
                sqlConn.Close();
            }

            for (int i = 0; i <= tblSTFICHE.Rows.Count - 1; i++)
            {
                DateTime DATE_ = Convert.ToDateTime(tblSTFICHE.Rows[i]["DATE_"].ToString());
                xNote += " " + tblSTFICHE.Rows[i]["FICHENO"] + " / " + DATE_.ToString("dd/MM/yyyy") + " ; ";
            }


            #region eknot
            if ((bool)FINANS.UBL.IZIBIZ_CLASS.Cfg["EkNot"])
            {
                try
                {
                    string xnxNOTE = "";
                    using (SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP))
                    {
                        string xSql = string.Format(" Select {0} From {1} Where PARLOGREF = {2} ", FINANS.UBL.IZIBIZ_CLASS.Cfg["EkNotAlanAdi"].ToString(), _GLOBAL_PARAMETERS._DBONAME + ".dbo." + FINANS.UBL.IZIBIZ_CLASS.Cfg["EkNotTabloAdi"], F["LOGICALREF"]);
                        SqlCommand myCommandSub = new SqlCommand(xSql, Conn);
                        Conn.Open();
                        SqlDataReader stf = myCommandSub.ExecuteReader(CommandBehavior.CloseConnection);
                        while (stf.Read())
                        {
                            xnxNOTE = stf["NOTE99"].ToString();
                        }
                        foreach (string sstr in xnxNOTE.Split('|'))
                            notList.Add(new NoteType() { Value = sstr });
                    }

                    //string xSql = string.Format(" Select {0} From {1} Where PARLOGREF = {2} ", Cfg["EkNotAlanAdi"].ToString(), Cfg["ERP_DB"] + ".." + Cfg["EkNotTabloAdi"], F["LOGICALREF"]);
                    //object nSnc = Data.XP.Crs.ExecuteScalar(xSql);
                    //string xnxNOTE = nSnc == null ? "" : nSnc.ToString();
                    //foreach (string sstr in xnxNOTE.Split('|'))
                    //    notList.Add(new NoteType() { Value = sstr });
                }
                catch (Exception)
                {

                }
            }
            #endregion
            notList.Add(new NoteType() { Value = xNote });

            #region DocumentCurrencyCode parabirimi
            Inv.DocumentCurrencyCode = new DocumentCurrencyCodeType();
            Inv.DocumentCurrencyCode.listAgencyName = "United Nations Economic Commission for Europe";
            Inv.DocumentCurrencyCode.listID = "ISO 4217 Alpha";
            Inv.DocumentCurrencyCode.listName = "Currency";
            Inv.DocumentCurrencyCode.listVersionID = "2001";

            string CURCODES = "TRL";
            using (SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP))
            {
                string sqlCurr = "  SELECT * FROM dbo.L_CURRENCYLIST WHERE    (CURTYPE='" + F["TRCURR"] + "') and FIRMNR=" + _GLOBAL_PARAMETERS._SIRKET_NO + "";
                SqlCommand myCommandSub = new SqlCommand(sqlCurr, Conn);
                Conn.Open();
                SqlDataReader stf = myCommandSub.ExecuteReader(CommandBehavior.CloseConnection);
                while (stf.Read())
                {
                    CURCODES = stf["CURCODE"].ToString();
                }
            }



            if (F["TRCURR"] != null)
                Inv.DocumentCurrencyCode.Value = (CurrencyCodeContentType)Enum.Parse(typeof(CurrencyCodeContentType), CURCODES);// F.CURRENCY.CURCODE
            else
                Inv.DocumentCurrencyCode.Value = CurrencyCodeContentType.TRY;

            bool Dovizli = (Convert.ToInt16(F["TRCURR"].ToString()) != 0 && Convert.ToInt16(F["TRCURR"].ToString()) != 160);

            #endregion

            #region AllowanceCharge
            if (Convert.ToDouble(F["ADDDISCOUNTS"].ToString()) > 0)
            {
                Inv.AllowanceCharge = new AllowanceChargeType();
                Inv.AllowanceCharge.ChargeIndicator = new ChargeIndicatorType() { Value = false };
                Inv.AllowanceCharge.Amount = new AmountType1();
                Inv.AllowanceCharge.Amount.currencyID = Inv.DocumentCurrencyCode.Value;

                decimal adddisc = Dovizli ? Convert.ToDecimal(F["ADDDISCOUNTS"].ToString()) / Convert.ToDecimal(F["TRRATE"].ToString()) : Convert.ToDecimal(F["ADDDISCOUNTS"].ToString());
                decimal grostot = Dovizli ? Convert.ToDecimal(F["GROSSTOTAL"].ToString()) / Convert.ToDecimal(F["TRRATE"].ToString()) : Convert.ToDecimal(F["GROSSTOTAL"].ToString());
                decimal totdisc = Dovizli ? Convert.ToDecimal(F["TOTALDISCOUNTS"].ToString()) / Convert.ToDecimal(F["TRRATE"].ToString()) : Convert.ToDecimal(F["TOTALDISCOUNTS"].ToString());

                decimal d = totdisc - (totdisc - adddisc);
                decimal oran = adddisc / d;

                Inv.AllowanceCharge.Amount.Value = Math.Round(adddisc, 2);
                Inv.AllowanceCharge.MultiplierFactorNumeric = new MultiplierFactorNumericType() { Value = Math.Round(oran, 2) };
            }
            #endregion


            DataTable dty_FTRROW = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP))
            {
                sqlConn.Open();
                ERP._ERP_CLASS sql = new ERP._ERP_CLASS();
                string LINE_TABLE_SQL = string.Format(sql.LINE_TABLE_SQL, _GLOBAL_PARAMETERS._DBONAME, _GLOBAL_PARAMETERS._SIRKET_NO.ToString(), "01");
                LINE_TABLE_SQL += " AND  (ln.INVOICEREF='" + F["LOGICALREF"] + "')";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(LINE_TABLE_SQL, sqlConn);
                dataAdapter.Fill(dty_FTRROW);
                sqlConn.Close();
            }


            //using (SqlConnection sqlConn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_MDB))
            //{
            //    sqlConn.Open();
            //    string sql = "  SELECT * FROM dbo.vLOGO_FATURASATIR_" + _GLOBAL_PARAMETERS._SIRKET_NO + "_01 WHERE    (INVOICEREF='" + F["LOGICALREF"] + "') ";
            //    SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConn);
            //    dataAdapter.Fill(dty_FTRROW);
            //    sqlConn.Close();
            //}


            if (dty_FTRROW.Rows.Count > 0)
            {
                Inv.LineCountNumeric = new LineCountNumericType() { Value = dty_FTRROW.Rows.Count };
            }

            FINANS.ERP._ERP_CLASS sqlx = new FINANS.ERP._ERP_CLASS();

            bool IsTevkifatVergi = false;
            bool IsKdv = false;
            using (SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP))
            {
                string xSql = string.Format(sqlx.IsCalcTevkKdv, _GLOBAL_PARAMETERS._DBONAME, _GLOBAL_PARAMETERS._SIRKET_NO.ToString(), "01", F["LOGICALREF"]);
                SqlCommand myCommandSub = new SqlCommand(xSql, Conn);
                Conn.Open();
                SqlDataReader stf = myCommandSub.ExecuteReader(CommandBehavior.CloseConnection);
                while (stf.Read())
                {
                    IsTevkifatVergi = Convert.ToBoolean(stf[0]);
                }
            }

            using (SqlConnection Conn = new SqlConnection(_GLOBAL_PARAMETERS._CONNECTIONSTRING_ERP))
            {
                string xSql = string.Format(sqlx.IsCalcKdv, _GLOBAL_PARAMETERS._DBONAME, _GLOBAL_PARAMETERS._SIRKET_NO.ToString(), "01", F["LOGICALREF"]);
                SqlCommand myCommandSub = new SqlCommand(xSql, Conn);
                Conn.Open();
                SqlDataReader stf = myCommandSub.ExecuteReader(CommandBehavior.CloseConnection);
                while (stf.Read())
                {
                    IsKdv = Convert.ToBoolean(stf[0]);
                }
            }


            #region odeme bilgileri
            //if (F["GLOBALCODE"] != null && F["GLOBALCODE"].ToString().Trim() != "")
            //{
            DataSet ds = new DataSet();
            ds = _GLOBAL_CODE_KONTROL(_GLOBAL_PARAMETERS._SIRKET_NO, F["LOGICALREF"].ToString());
            if (ds != null)
            {
                Inv.PaymentMeans = new PaymentMeansType[1];
                Inv.PaymentMeans[0] = new PaymentMeansType();
                Inv.PaymentMeans[0].PaymentMeansCode = new PaymentMeansCodeType1();
                Inv.PaymentMeans[0].PaymentMeansCode.Value = ds.Tables[0].Rows[0]["GLOBALCODE"].ToString();
                Inv.PaymentMeans[0].PaymentDueDate = new PaymentDueDateType();
                Inv.PaymentMeans[0].PaymentDueDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DATE_"]);

                //Inv.PaymentMeans[0].InstructionNote = new InstructionNoteType();
                //Inv.PaymentMeans[0].InstructionNote.Value = F["GLOBALCODE"].ToString();
                //Inv.PaymentTerms = new PaymentTermsType();
                //Inv.PaymentTerms.Note = new NoteType();
                //Inv.PaymentTerms.Note.Value = pys.First().DEFINITION_;
                //Inv.PaymentTerms.Note.Value += " " + pys.First().CODE;
                //if (F.PAYDETAYLAR != null || F.PAYDETAYLAR.Count > 0)
                //{
                //    List<Data.Views.PAYMENT> pys = F.PAYDETAYLAR;
                //    Inv.PaymentTerms = new PaymentTermsType();
                //    Inv.PaymentTerms.Note = new NoteType();
                //    Inv.PaymentTerms.Note.Value = pys.First().DEFINITION_;
                //    Inv.PaymentTerms.Note.Value += " " + pys.First().CODE;
                //}
            }
            else
            {
                Inv.PaymentMeans = new PaymentMeansType[1];
                Inv.PaymentMeans[0] = new PaymentMeansType();
                Inv.PaymentMeans[0].PaymentMeansCode = new PaymentMeansCodeType1();
                Inv.PaymentMeans[0].PaymentMeansCode.Value = "42";
            }
            #endregion



            //#region odeme bilgileri
            //if (F["GLOBALCODE"] != null && F["GLOBALCODE"].ToString().Trim() != "")
            //{
            //    Inv.PaymentMeans = new PaymentMeansType[1];
            //    Inv.PaymentMeans[0] = new PaymentMeansType();
            //    Inv.PaymentMeans[0].PaymentMeansCode = new PaymentMeansCodeType1();
            //    Inv.PaymentMeans[0].PaymentMeansCode.Value = F["GLOBALCODE"].ToString();

            //    Inv.PaymentMeans[0].PaymentDueDate = new PaymentDueDateType();
            //    Inv.PaymentMeans[0].PaymentDueDate.Value = Convert.ToDateTime(F["PAYMENT_DATE"].ToString());

            //    //Inv.PaymentMeans[0].InstructionNote = new InstructionNoteType();
            //    //Inv.PaymentMeans[0].InstructionNote.Value = F["GLOBALCODE"].ToString();

            //    //Inv.PaymentTerms = new PaymentTermsType();
            //    //Inv.PaymentTerms.Note = new NoteType();
            //    //Inv.PaymentTerms.Note.Value = pys.First().DEFINITION_;
            //    //Inv.PaymentTerms.Note.Value += " " + pys.First().CODE;


            //    //if (F.PAYDETAYLAR != null || F.PAYDETAYLAR.Count > 0)
            //    //{
            //    //    List<Data.Views.PAYMENT> pys = F.PAYDETAYLAR;
            //    //    Inv.PaymentTerms = new PaymentTermsType();
            //    //    Inv.PaymentTerms.Note = new NoteType();
            //    //    Inv.PaymentTerms.Note.Value = pys.First().DEFINITION_;
            //    //    Inv.PaymentTerms.Note.Value += " " + pys.First().CODE;
            //    //}
            //}
            //else
            //{

            //    Inv.PaymentMeans = new PaymentMeansType[1];
            //    Inv.PaymentMeans[0] = new PaymentMeansType();
            //    Inv.PaymentMeans[0].PaymentMeansCode = new PaymentMeansCodeType1();              
            //    Inv.PaymentMeans[0].PaymentMeansCode.Value = "42";
            //}
            //#endregion


            ///
            ///  SİPARİŞ NOSUNU VE TARİHİNİ GÖNDERİYORUZ.
            ///
            #region OrderReference sipariş

            if (dty_FTRROW != null && dty_FTRROW.Rows.Count > 0)
            {

                var ord = dty_FTRROW.Select("ORDFICHENO IS NOT NULL").Distinct();

                if (ord != null && ord.Count() > 0)
                {
                    DateTime trh = DateTime.Now;
                    try
                    {
                        trh = Convert.ToDateTime(dty_FTRROW.Select("ORDTARIH=MAX(ORDTARIH)"));

                    }
                    catch
                    {

                    }
                    Inv.OrderReference = new OrderReferenceType();
                    Inv.OrderReference.ID = new IDType() { Value = "" };
                    Inv.OrderReference.IssueDate = new IssueDateType() { Value = trh };
                    Inv.OrderReference.DocumentReference = new DocumentReferenceType()
                    {
                        ID = new IDType() { Value = "0012" },
                        IssueDate = new IssueDateType() { Value = DateTime.Now }
                    };

                    string ordL = "";
                    int sx = -1;
                    foreach (var ln in ord)
                    {
                        sx++;
                        if (ordL == ln.Table.Rows[sx]["ORDFICHENO"].ToString())
                            continue;

                        Inv.OrderReference.ID.Value += ln.Table.Rows[sx]["ORDFICHENO"] + " ; ";
                        ordL = ln.Table.Rows[sx]["ORDFICHENO"].ToString();
                    }
                }
            }
            #endregion

            #region DespatchDocumentReference sevk belge

            if (tblSTFICHE.Rows.Count > 0 && ((bool)FINANS.UBL.IZIBIZ_CLASS.Cfg["IRSALIYE"] == false))
            {
                Inv.DespatchDocumentReference = new DocumentReferenceType[1];
                Inv.DespatchDocumentReference[0] = new DocumentReferenceType();
                Inv.DespatchDocumentReference[0].ID = new IDType() { Value = tblSTFICHE.Rows[0]["FICHENO"].ToString() };
                Inv.DespatchDocumentReference[0].IssueDate = new IssueDateType() { Value = (DateTime)tblSTFICHE.Rows[0]["DATE_"] };
            }
            #endregion

            #region AdditionalDocumentReference ek belgeler
            Inv.AdditionalDocumentReference = new DocumentReferenceType[1];
            Inv.AdditionalDocumentReference[0] = new DocumentReferenceType();
            Inv.AdditionalDocumentReference[0].ID = new IDType() { Value = GIBFNO };
            Inv.AdditionalDocumentReference[0].IssueDate = new IssueDateType() { Value = DateTime.Now };
            Inv.AdditionalDocumentReference[0].Attachment = new AttachmentType();
            Inv.AdditionalDocumentReference[0].Attachment.EmbeddedDocumentBinaryObject = new EmbeddedDocumentBinaryObjectType();
            Inv.AdditionalDocumentReference[0].Attachment.EmbeddedDocumentBinaryObject.characterSetCode = "UTF-8";
            Inv.AdditionalDocumentReference[0].Attachment.EmbeddedDocumentBinaryObject.encodingCode = "Base64";
            Inv.AdditionalDocumentReference[0].Attachment.EmbeddedDocumentBinaryObject.filename = GIBFNO + ".xslt";
            Inv.AdditionalDocumentReference[0].Attachment.EmbeddedDocumentBinaryObject.mimeCode = BinaryObjectMimeCodeContentType.applicationxml;

            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            //  byte[] binarydata = File.ReadAllBytes(appPath + "\\_XSLT\\" + FIRMA_KODU + "\\GENERIC_TEMPLATE.xslt");
            byte[] binarydata = File.ReadAllBytes(appPath + "\\_TEMPLATE\\_XSLT\\" + FIRMA_KODU + "\\GENERIC_TEMPLATE.xslt");
            string base64 = System.Convert.ToBase64String(binarydata, 0, binarydata.Length);
            Inv.AdditionalDocumentReference[0].Attachment.EmbeddedDocumentBinaryObject.Value = Convert.FromBase64String(base64);

            #endregion

            #region Signature İmza bilgileri
            Inv.Signature = new SignatureType[1];
            Inv.Signature[0] = new SignatureType();
            Inv.Signature[0].ID = new IDType() { schemeID = "VKN_TCKN", Value = FINANS.UBL.IZIBIZ_CLASS.Cfg["VKN"].ToString() };

            Inv.Signature[0].SignatoryParty = new PartyType();
            Inv.Signature[0].SignatoryParty.PartyIdentification = new PartyIdentificationType[1];
            Inv.Signature[0].SignatoryParty.PartyIdentification[0] = new PartyIdentificationType();
            Inv.Signature[0].SignatoryParty.PartyIdentification[0].ID = new IDType() { schemeID = "VKN", Value = FINANS.UBL.IZIBIZ_CLASS.Cfg["VKN"].ToString() };

            Inv.Signature[0].SignatoryParty.PostalAddress = new AddressType();
            Inv.Signature[0].SignatoryParty.PostalAddress.Room = new RoomType() { Value = FINANS.UBL.IZIBIZ_CLASS.Cfg["Room"] == null ? "" : FINANS.UBL.IZIBIZ_CLASS.Cfg["Room"].ToString() };
            Inv.Signature[0].SignatoryParty.PostalAddress.StreetName = new StreetNameType();
            Inv.Signature[0].SignatoryParty.PostalAddress.BuildingName = new BuildingNameType();
            Inv.Signature[0].SignatoryParty.PostalAddress.BuildingNumber = new BuildingNumberType();
            Inv.Signature[0].SignatoryParty.PostalAddress.CitySubdivisionName = new CitySubdivisionNameType() { Value = FINANS.UBL.IZIBIZ_CLASS.Cfg["CitySubdivisionName"] == null ? "" : FINANS.UBL.IZIBIZ_CLASS.Cfg["CitySubdivisionName"].ToString() };
            Inv.Signature[0].SignatoryParty.PostalAddress.CityName = new CityNameType() { Value = FINANS.UBL.IZIBIZ_CLASS.Cfg["CityName"] == null ? "" : FINANS.UBL.IZIBIZ_CLASS.Cfg["CityName"].ToString() };
            Inv.Signature[0].SignatoryParty.PostalAddress.PostalZone = new PostalZoneType();
            Inv.Signature[0].SignatoryParty.PostalAddress.Region = new RegionType();
            Inv.Signature[0].SignatoryParty.PostalAddress.Country = new CountryType();
            Inv.Signature[0].SignatoryParty.PostalAddress.Country.Name = new NameType1() { Value = IZIBIZ_CLASS.Cfg["Country"] == null ? "" : IZIBIZ_CLASS.Cfg["Country"].ToString() };

            Inv.Signature[0].DigitalSignatureAttachment = new AttachmentType();
            Inv.Signature[0].DigitalSignatureAttachment.ExternalReference = new ExternalReferenceType();
            Inv.Signature[0].DigitalSignatureAttachment.ExternalReference.URI = new URIType() { Value = "#Signature_" + Inv.ID.Value };
            //_57515a13-7a8e-417c-9395-95a93cff0c56
            #endregion

            #region AccountingSupplierParty satıcı bilgileri
            Inv.AccountingSupplierParty = new SupplierPartyType();
            Inv.AccountingSupplierParty.Party = new PartyType();
            Inv.AccountingSupplierParty.Party.WebsiteURI = new WebsiteURIType() { Value = IZIBIZ_CLASS.Cfg["WebsiteURI"] == null ? "" : IZIBIZ_CLASS.Cfg["WebsiteURI"].ToString() };
            Inv.AccountingSupplierParty.Party.PartyIdentification = new PartyIdentificationType[2];
            Inv.AccountingSupplierParty.Party.PartyIdentification[0] = new PartyIdentificationType();
            Inv.AccountingSupplierParty.Party.PartyIdentification[0].ID = new IDType() { schemeID = "VKN", Value = IZIBIZ_CLASS.Cfg["VKN"].ToString() };

            Inv.AccountingSupplierParty.Party.PartyIdentification[1] = new PartyIdentificationType();
            Inv.AccountingSupplierParty.Party.PartyIdentification[1].ID = new IDType() { schemeID = "TICARETSICILNO", Value = IZIBIZ_CLASS.Cfg["SCN"] == null ? "" : IZIBIZ_CLASS.Cfg["SCN"].ToString() };//F.TAXNR


            Inv.AccountingSupplierParty.Party.PartyName = new PartyNameType();
            Inv.AccountingSupplierParty.Party.PartyName.Name = new NameType1() { Value = IZIBIZ_CLASS.Cfg["PartyName"] == null ? "" : IZIBIZ_CLASS.Cfg["PartyName"].ToString() };

            Inv.AccountingSupplierParty.Party.PostalAddress = new AddressType();
            Inv.AccountingSupplierParty.Party.PostalAddress.Room = new RoomType() { Value = IZIBIZ_CLASS.Cfg["Room"] == null ? "" : IZIBIZ_CLASS.Cfg["Room"].ToString() };
            Inv.AccountingSupplierParty.Party.PostalAddress.StreetName = new StreetNameType() { Value = IZIBIZ_CLASS.Cfg["StreetName"] == null ? "" : IZIBIZ_CLASS.Cfg["StreetName"].ToString() };
            Inv.AccountingSupplierParty.Party.PostalAddress.BuildingName = new BuildingNameType() { Value = IZIBIZ_CLASS.Cfg["BuildingName"] == null ? "" : IZIBIZ_CLASS.Cfg["BuildingName"].ToString() };
            Inv.AccountingSupplierParty.Party.PostalAddress.BuildingNumber = new BuildingNumberType() { Value = IZIBIZ_CLASS.Cfg["BuildingNumber"] == null ? "" : IZIBIZ_CLASS.Cfg["BuildingNumber"].ToString() };
            Inv.AccountingSupplierParty.Party.PostalAddress.CitySubdivisionName = new CitySubdivisionNameType() { Value = IZIBIZ_CLASS.Cfg["CitySubdivisionName"] == null ? "" : IZIBIZ_CLASS.Cfg["CitySubdivisionName"].ToString() };
            Inv.AccountingSupplierParty.Party.PostalAddress.CityName = new CityNameType() { Value = IZIBIZ_CLASS.Cfg["CityName"] == null ? "" : IZIBIZ_CLASS.Cfg["CityName"].ToString() };
            Inv.AccountingSupplierParty.Party.PostalAddress.PostalZone = new PostalZoneType();
            Inv.AccountingSupplierParty.Party.PostalAddress.Region = new RegionType();
            Inv.AccountingSupplierParty.Party.PostalAddress.Country = new CountryType();
            Inv.AccountingSupplierParty.Party.PostalAddress.Country.Name = new NameType1() { Value = IZIBIZ_CLASS.Cfg["Country"] == null ? "" : IZIBIZ_CLASS.Cfg["Country"].ToString() };

            Inv.AccountingSupplierParty.Party.PartyTaxScheme = new PartyTaxSchemeType();
            Inv.AccountingSupplierParty.Party.PartyTaxScheme.TaxScheme = new TaxSchemeType();
            Inv.AccountingSupplierParty.Party.PartyTaxScheme.TaxScheme.Name = new NameType1() { Value = IZIBIZ_CLASS.Cfg["TaxScheme"] == null ? "" : IZIBIZ_CLASS.Cfg["TaxScheme"].ToString() };

            Inv.AccountingSupplierParty.Party.Contact = new ContactType();
            Inv.AccountingSupplierParty.Party.Contact.Telephone = new TelephoneType() { Value = IZIBIZ_CLASS.Cfg["Telephone"] == null ? "" : IZIBIZ_CLASS.Cfg["Telephone"].ToString() };

            Inv.AccountingSupplierParty.Party.Contact.Telefax = new TelefaxType();
            Inv.AccountingSupplierParty.Party.Contact.Telefax.Value = "";

            Inv.AccountingSupplierParty.Party.Contact.ElectronicMail = new ElectronicMailType() { Value = IZIBIZ_CLASS.Cfg["ElectronicMail"] == null ? "" : IZIBIZ_CLASS.Cfg["ElectronicMail"].ToString() };
            #endregion

            #region AccountingCustomerParty müşteri bilgileri
            Inv.AccountingCustomerParty = new CustomerPartyType();
            Inv.AccountingCustomerParty.Party = new PartyType();

            Inv.AccountingCustomerParty.Party.PartyIdentification = new PartyIdentificationType[2];


            Inv.AccountingCustomerParty.Party.PartyIdentification[0] = new PartyIdentificationType();
            if (F["ISPERSCOMP"] == DBNull.Value) F["ISPERSCOMP"] = 0;
            Inv.AccountingCustomerParty.Party.PartyIdentification[0].ID = new IDType() { schemeID = Convert.ToInt16(F["ISPERSCOMP"]) == 1 ? "TCKN" : "VKN", Value = F["TAXNR"].ToString() };



            // gibus.IDENTIFIER 
            Inv.AccountingCustomerParty.Party.PartyIdentification[1] = new PartyIdentificationType();
            Inv.AccountingCustomerParty.Party.PartyIdentification[1].ID = new IDType() { schemeID = "TICARETSICILNO", Value = "" };//F.TAXNR

            Inv.AccountingCustomerParty.Party.PartyName = new PartyNameType();
            Inv.AccountingCustomerParty.Party.PartyName.Name = new NameType1() { Value = F["DEFINITION_"] == null ? "" : F["DEFINITION_"].ToString() };

            if (Convert.ToInt16(F["ISPERSCOMP"].ToString()) == 1)
            {
                Inv.AccountingCustomerParty.Party.Person = new PersonType();
                Inv.AccountingCustomerParty.Party.Person.FamilyName = new FamilyNameType() { Value = F["DEFINITION_"].ToString() };
                Inv.AccountingCustomerParty.Party.Person.FirstName = new FirstNameType() { Value = F["CODE"].ToString() };
            }

            if (F["TCKNO"] != null && F["TCKNO"].ToString().Trim() != "")
                Inv.AccountingCustomerParty.Party.PartyIdentification[1].ID.Value = F["TCKNO"].ToString().Trim();

            string ad1 = F["ADDR1"] == null ? "" : F["ADDR1"].ToString();
            string ad2 = F["ADDR2"] == null ? "" : F["ADDR2"].ToString();

            Inv.AccountingCustomerParty.Party.PostalAddress = new AddressType();
            Inv.AccountingCustomerParty.Party.PostalAddress.Room = new RoomType();
            Inv.AccountingCustomerParty.Party.PostalAddress.StreetName = new StreetNameType() { Value = ad1 + " - " + ad2 };
            Inv.AccountingCustomerParty.Party.PostalAddress.BuildingName = new BuildingNameType();
            Inv.AccountingCustomerParty.Party.PostalAddress.BuildingNumber = new BuildingNumberType();

            string twn = F["TOWN"] == null ? "" : F["TOWN"].ToString();
            string city = F["DISTRICT"] == null ? "" : F["DISTRICT"].ToString();

            Inv.AccountingCustomerParty.Party.PostalAddress.CitySubdivisionName = new CitySubdivisionNameType() { Value = city + " " + twn };
            Inv.AccountingCustomerParty.Party.PostalAddress.CityName = new CityNameType() { Value = F["CITY"] == null ? "" : F["CITY"].ToString() };
            Inv.AccountingCustomerParty.Party.PostalAddress.PostalZone = new PostalZoneType() { Value = "" };
            Inv.AccountingCustomerParty.Party.PostalAddress.Region = new RegionType() { Value = "" };
            Inv.AccountingCustomerParty.Party.PostalAddress.Country = new CountryType();
            Inv.AccountingCustomerParty.Party.PostalAddress.Country.Name = new NameType1() { Value = F["COUNTRY"] == null ? "" : F["COUNTRY"].ToString() };

            Inv.AccountingCustomerParty.Party.PartyTaxScheme = new PartyTaxSchemeType();
            Inv.AccountingCustomerParty.Party.PartyTaxScheme.TaxScheme = new TaxSchemeType();
            Inv.AccountingCustomerParty.Party.PartyTaxScheme.TaxScheme.Name = new NameType1() { Value = F["TAXOFFICE"] == null ? "" : F["TAXOFFICE"].ToString() };

            Inv.AccountingCustomerParty.Party.Contact = new ContactType();

            Inv.AccountingCustomerParty.Party.Contact.Telephone = new TelephoneType();

            if (F["TELNRS1"] != null)
                Inv.AccountingCustomerParty.Party.Contact.Telephone.Value = F["TELNRS1"].ToString();

            Inv.AccountingCustomerParty.Party.Contact.Telefax = new TelefaxType();

            if (F["FAXNR"] != null)
                Inv.AccountingCustomerParty.Party.Contact.Telefax.Value = F["FAXNR"].ToString();

            Inv.AccountingCustomerParty.Party.Contact.ElectronicMail = new ElectronicMailType() { Value = F["POSTLABELCODE"] == null ? "" : F["POSTLABELCODE"].ToString() };

            Inv.AccountingCustomerParty.Party.WebsiteURI = new WebsiteURIType() { Value = F["WEBADDR"] == null ? "" : F["WEBADDR"].ToString() };
            #endregion

            #region TaxTotal vergiler

            decimal ToplamVergi = Dovizli ? Convert.ToDecimal(F["TOTALVAT"]) / (Convert.ToDecimal(F["TRNET"]) == 0 ? 1 : Convert.ToDecimal(F["TRNET"])) : Convert.ToDecimal(F["TOTALVAT"]);

            Inv.TaxTotal = new TaxTotalType[1];

            TaxTotalType tx = new TaxTotalType();
            tx.TaxAmount = new TaxAmountType() { currencyID = Inv.DocumentCurrencyCode.Value, Value = Math.Round(ToplamVergi, 2) };

            List<TaxSubtotalType> subs = new List<TaxSubtotalType>();

            var dtVat = dty_FTRROW.Select("VAT IS NOT NULL").Distinct();
            foreach (decimal Oran in dtVat.GroupBy(x => Convert.ToDecimal(x["VAT"])).Select(x => x.Key))
            {
                TaxSubtotalType sub = new TaxSubtotalType();
                sub.TaxableAmount = new TaxableAmountType() { currencyID = Inv.DocumentCurrencyCode.Value };
                sub.TaxAmount = new TaxAmountType() { currencyID = Inv.DocumentCurrencyCode.Value, Value = 0 };

                sub.TaxCategory = new TaxCategoryType();
                sub.TaxCategory.TaxScheme = new TaxSchemeType();
                sub.TaxCategory.TaxScheme.Name = new NameType1() { Value = IZIBIZ_CLASS.Cfg["GIBKdvName"].ToString() };
                sub.TaxCategory.TaxScheme.TaxTypeCode = new TaxTypeCodeType() { Value = IZIBIZ_CLASS.Cfg["GIBKdvCode"].ToString() };

                if (IsKdv == false && Oran > 0)
                    sub.Percent = new PercentType() { Value = Math.Round((decimal)Oran, 2) };
                else
                {
                    /// LOGODAN KDVSİZ NEDENİ GELİMYOR İSE KDVSİZ YAZILACAK 
                    sub.Percent = new PercentType() { Value = 0 };
                    sub.TaxCategory.TaxExemptionReason = new TaxExemptionReasonType() { Value = "KDV siz" };
                }

                decimal KdvTaxAmountValue = 0;
                foreach (var lst in dtVat.Where(y => Convert.ToDecimal(y["VAT"]) == Oran))
                {
                    decimal vatMatrah = Dovizli ? Convert.ToDecimal(lst["VATMATRAH"]) / (Convert.ToDecimal(lst["TRRATE"]) == 0 ? 1 : Convert.ToDecimal(lst["TRRATE"])) : Convert.ToDecimal(lst["VATMATRAH"]);

                    sub.TaxableAmount.Value += Math.Round(vatMatrah, 2);

                    if (IsKdv == false && Oran > 0)
                    {
                        if (IsTevkifatVergi && (dtVat.Where(x => Convert.ToDouble(x["DEDUCTIONPART1"]) > 0.001).Count() > 0 && dtVat.Where(x => Convert.ToDouble(x["DEDUCTIONPART2"]) > 0.001).Count() > 0))
                            KdvTaxAmountValue += (Convert.ToDecimal(lst["VATMATRAH"]) * Convert.ToDecimal(lst["VAT"])) / 100;
                        else
                            KdvTaxAmountValue += Dovizli ? (Convert.ToDecimal(lst["VAT"]) * vatMatrah) / (decimal)100 : Convert.ToDecimal(lst["VATAMNT"]);
                    }
                    else
                    {
                        sub.TaxAmount.Value = 0;
                        sub.TaxCategory.TaxExemptionReason = new TaxExemptionReasonType() { Value = "KDV siz" };
                    }
                }
                sub.TaxAmount.Value = Math.Round(KdvTaxAmountValue, 2);
                subs.Add(sub);
            }


            if (IsTevkifatVergi)
            {
                /// STLINE DAN OKNAN ALAN
                ///   
                //foreach (var deduc in dtVat.Where(c => Convert.ToDouble(c["DEDUCTIONPART1"]) > 0 && Convert.ToDouble(c["DEDUCTIONPART2"]) > 0).GroupBy(n => new {Convert.ToDouble(n["DEDUCTIONPART2"]),Convert.ToDouble(n["DEDUCTIONPART2"])    }))
                //{ 
                //    TaxSubtotalType sub = new TaxSubtotalType();
                //    sub.TaxableAmount = new TaxableAmountType() { currencyID = Inv.DocumentCurrencyCode.Value };
                //    sub.TaxAmount = new TaxAmountType() { currencyID = Inv.DocumentCurrencyCode.Value };


                //    decimal yuzde = ((decimal)deduc.Key["DEDUCTIONPART1"] / (decimal)deduc.Key["DEDUCTIONPART2"]) * (decimal)100;
                //    sub.Percent = new PercentType() { Value = Math.Round(yuzde, 2) };

                //    sub.TaxCategory = new TaxCategoryType();
                //    sub.TaxCategory.TaxScheme = new TaxSchemeType();
                //    //sub.TaxCategory.TaxScheme.Name = new NameType1() { Value = Tools.Gnl.PARAMS.GIBVergiAd1 };
                //    //sub.TaxCategory.TaxScheme.TaxTypeCode = new TaxTypeCodeType() { Value = Tools.Gnl.PARAMS.GIBVergiKod1 };

                //    sub.TaxCategory.TaxScheme.Name = new NameType1() { Value = IZIBIZ_CLASS.Cfg["GIBKdvName"].ToString() };
                //    sub.TaxCategory.TaxScheme.TaxTypeCode = new TaxTypeCodeType() { Value = IZIBIZ_CLASS.Cfg["GIBKdvCode"].ToString() };

                //    decimal TaxAmountValue = 0;

                //    foreach (var lst in dty_FTRROW.Where(t => Convert.ToDouble(t["DEDUCTIONPART1"]) == Convert.ToDouble(deduc.Key["DEDUCTIONPART1"]) && Convert.ToDouble(t["DEDUCTIONPART2"]) == Convert.ToDouble(deduc.Key["DEDUCTIONPART2"])))
                //    {
                //        decimal vatMatrah = Dovizli ? lst.VATMATRAH / lst.TRRATE : lst.VATMATRAH;

                //        decimal nrmKdv = ((lst.VAT * vatMatrah) / (decimal)100);
                //        decimal tvkVergi = (nrmKdv * yuzde) / (decimal)100;
                //        sub.TaxableAmount.Value += nrmKdv;
                //        TaxAmountValue += tvkVergi;
                //    }

                //    sub.TaxAmount.Value = Math.Round(TaxAmountValue, 2);

                //    subs.Add(sub);
                //} 
            }

            tx.TaxSubtotal = subs.ToArray();
            Inv.TaxTotal[0] = tx;
            #endregion

            #region MonetaryTotal tutarlar


            /// SATIR TOPLAMI DOİV OLARAK LOGADA YOK O NEDENLE TOPALAMA GEREKİYOR
            decimal GrosTutar = 0;

            if (dty_FTRROW != null && dty_FTRROW.Rows.Count > 0)
            {
                for (int i = 0; i <= dty_FTRROW.Rows.Count - 1; i++)
                {
                    GrosTutar += (Convert.ToDecimal(dty_FTRROW.Rows[i]["AMOUNT"]) * Convert.ToDecimal(dty_FTRROW.Rows[i]["PRICE"]));
                }

            }

            decimal ToplamEksiInd = (GrosTutar - Convert.ToDecimal(F["TOTALDISCOUNTS"]));
            decimal ToplamKdvDahil = ToplamEksiInd + Convert.ToDecimal(F["TOTALVAT"]);
            decimal TotalDisc = Convert.ToDecimal(F["TOTALDISCOUNTS"]);

            if (Dovizli)
            {
                GrosTutar = GrosTutar / (Convert.ToDecimal(F["TRRATE"]) == 0 ? 1 : Convert.ToDecimal(F["TRRATE"]));
                ToplamEksiInd = ToplamEksiInd / (Convert.ToDecimal(F["TRRATE"]) == 0 ? 1 : Convert.ToDecimal(F["TRRATE"]));
                ToplamKdvDahil = ToplamKdvDahil / (Convert.ToDecimal(F["TRRATE"]) == 0 ? 1 : Convert.ToDecimal(F["TRRATE"]));
                TotalDisc = TotalDisc / (Convert.ToDecimal(F["TRRATE"]) == 0 ? 1 : Convert.ToDecimal(F["TRRATE"]));
            }

            Inv.LegalMonetaryTotal = new MonetaryTotalType();
            Inv.LegalMonetaryTotal.LineExtensionAmount = new LineExtensionAmountType() { currencyID = Inv.DocumentCurrencyCode.Value, Value = Math.Round(GrosTutar, 2) };
            Inv.LegalMonetaryTotal.TaxExclusiveAmount = new TaxExclusiveAmountType() { currencyID = Inv.DocumentCurrencyCode.Value, Value = Math.Round(ToplamEksiInd, 2) };
            Inv.LegalMonetaryTotal.TaxInclusiveAmount = new TaxInclusiveAmountType() { currencyID = Inv.DocumentCurrencyCode.Value, Value = Math.Round(ToplamKdvDahil, 2) };
            Inv.LegalMonetaryTotal.PayableAmount = new PayableAmountType() { currencyID = Inv.DocumentCurrencyCode.Value, Value = Math.Round(ToplamKdvDahil, 2) };
            Inv.LegalMonetaryTotal.AllowanceTotalAmount = new AllowanceTotalAmountType();
            Inv.LegalMonetaryTotal.AllowanceTotalAmount.currencyID = Inv.DocumentCurrencyCode.Value;
            Inv.LegalMonetaryTotal.AllowanceTotalAmount.Value = Math.Round(TotalDisc, 2);

            #endregion

            string underCur = "";
            string Cur = "";

            if (Inv.DocumentCurrencyCode.Value == CurrencyCodeContentType.TRY)
            {
                Cur = " TürkLirası ";
                underCur = " Kuruş ";
            }
            else
            {
                Cur = Inv.DocumentCurrencyCode.Value.ToString();
                underCur = " Cent";
            }
            notList.Add(new NoteType()
            {
                Value = "Yanlız " + _GLOBAL_PARAMETERS.PARAYI_YAZIYA_CEVIR.yaziyaCevir(ToplamKdvDahil, CURCODES, underCur).ToString()//, Cur, underCur)
            });


            string OzelparaBirim = "", OzelKur = "";
            decimal OzelKurdc = 1;

            #region InvoiceLine

            Inv.InvoiceLine = new InvoiceLineType[dty_FTRROW.Rows.Count];

            /// STLINE DAN OKUNUYOR 
            if (dty_FTRROW != null && dty_FTRROW.Rows.Count > 0)
            {
                for (int i = 0; i <= dty_FTRROW.Rows.Count - 1; i++)
                {
                    DataRow Fd = dty_FTRROW.Rows[i];
                    // Fd.Reload();
                    //Data.Views.vLOGO_FATURASATIR Fd = dty[i];
                    //Fd.Reload();

                    if (Dovizli && dty_FTRROW.Select("PRPRICE =0").Count() > 0)
                        throw new Exception(" İşlem parabirimi yerel olmayan faturalarda Dovizli Birim Fiyat alanı boş olamaz.. ");

                    UnitCodeContentType Birim = UnitCodeContentType.NIU;

                    if (Fd["GLOBALCODE"] != null && Fd["GLOBALCODE"].ToString().Trim() != "")
                        Birim = (UnitCodeContentType)Enum.Parse(typeof(UnitCodeContentType), Fd["LGLOBALCODE"].ToString().ToUpper().Trim());

                    Inv.InvoiceLine[i] = new InvoiceLineType();
                    Inv.InvoiceLine[i].ID = new IDType() { Value = (i + 1).ToString() };
                    Inv.InvoiceLine[i].InvoicedQuantity = new InvoicedQuantityType() { unitCode = Birim, Value = Math.Round(Convert.ToDecimal(Fd["AMOUNT"]), 2) };
                    Inv.InvoiceLine[i].LineExtensionAmount = new LineExtensionAmountType() { currencyID = Inv.DocumentCurrencyCode.Value, Value = Dovizli ? ((Convert.ToDecimal(Fd["AMOUNT"]) * Convert.ToDecimal(Fd["PRPRICE"]))) : ((Convert.ToDecimal(Fd["AMOUNT"]) * Convert.ToDecimal(Fd["PRICE"]))) };

                    string itmName = "";

                    if ((int)IZIBIZ_CLASS.Cfg["MalHizmetSecenegi"] == 0)
                        itmName = Fd["NAME"].ToString();
                    else if ((int)IZIBIZ_CLASS.Cfg["MalHizmetSecenegi"] == 1)
                        itmName = Fd["LINEEXP"].ToString();
                    else if ((int)IZIBIZ_CLASS.Cfg["MalHizmetSecenegi"] == 2)
                        itmName = Fd["NAME"] + " " + Fd["LINEEXP"];
                    else
                        itmName = Fd["NAME"].ToString();

                    Inv.InvoiceLine[i].Item = new ItemType() { Name = new NameType1() { Value = itmName } };

                    Inv.InvoiceLine[i].Price = new PriceType() { PriceAmount = new PriceAmountType() { currencyID = Inv.DocumentCurrencyCode.Value, Value = Dovizli ? Convert.ToDecimal(Fd["PRPRICE"]) : Convert.ToDecimal(Fd["PRICE"]) } };

                    if (Convert.ToBoolean(IZIBIZ_CLASS.Cfg["OZEL_TASARIM"]))
                    {
                        if (Convert.ToDouble(Fd["PRPRICE"]) > 0 && Convert.ToDouble(Fd["PRCURR"]) != 160 && Convert.ToDouble(Fd["PRCURR"]) != 0)
                        {
                            DataRow[] Drw = vCURR_TABLE.Select("CURTYPE = " + Fd["PRCURR"]);
                            var curl = vCURR_TABLE.Select("CURTYPE = " + Fd["PRCURR"]);
                            if (curl.Count() > 0)
                            {
                                Inv.InvoiceLine[i].Note = new NoteType() { Value = Fd["PRPRICE"].ToString() + " " + Drw[0]["CURCODE"].ToString() };//.First().CURCODE 
                                OzelparaBirim = Drw[0]["CURCODE"].ToString();//curl.ToArray[0]["CURCODE"];
                                OzelKur = Fd["TRRATE"].ToString();
                                OzelKurdc = Convert.ToDecimal(Fd["TRRATE"]) > 0 ? Convert.ToDecimal(Fd["TRRATE"]) : 1;
                            }
                        }
                    }

                    #region vergiler
                    Inv.InvoiceLine[i].TaxTotal = new TaxTotalType();
                    Inv.InvoiceLine[i].TaxTotal.TaxAmount = new TaxAmountType()
                    {
                        currencyID = Inv.DocumentCurrencyCode.Value,
                        Value = Dovizli ? Math.Round((Convert.ToDecimal(Fd["VATAMNT"]) / Convert.ToDecimal(Fd["TRRATE"])), 2) : Math.Round(Convert.ToDecimal((Fd["VATAMNT"])), 2)
                    };

                    int ln = 1;

                    if ((IsTevkifatVergi) && ((double)Fd["DEDUCTIONPART1"] > 0.001 && (double)Fd["DEDUCTIONPART2"] > 0.001))
                        ln = 2;

                    Inv.InvoiceLine[i].TaxTotal.TaxSubtotal = new TaxSubtotalType[ln];

                    decimal Tutar = 0;

                    if (Dovizli)
                        Tutar = Convert.ToDecimal(Fd["VATMATRAH"]) / Convert.ToDecimal(Fd["PRPRICE"]);
                    else
                        Tutar = Convert.ToDecimal(Fd["VATMATRAH"]);

                    decimal nrmKdv = 0;

                    if (Dovizli || IsTevkifatVergi)
                        nrmKdv = (Tutar * Convert.ToDecimal(Fd["VAT"])) / (decimal)100;
                    else
                        nrmKdv = Convert.ToDecimal(Fd["VATAMNT"]);

                    Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0] = new TaxSubtotalType();
                    Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0].TaxAmount = new TaxAmountType() { currencyID = Inv.DocumentCurrencyCode.Value, Value = Dovizli ? Math.Round((Convert.ToDecimal(Fd["VATAMNT"]) / Convert.ToDecimal(Fd["TRRATE"])), 2) : Math.Round(nrmKdv, 2) };
                    Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0].TaxableAmount = new TaxableAmountType() { currencyID = Inv.DocumentCurrencyCode.Value, Value = Math.Round(Tutar, 2) };
                    //Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0].CalculationSequenceNumeric = new CalculationSequenceNumericType() { Value = 1 };
                    Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0].Percent = new PercentType() { Value = Math.Round(Convert.ToDecimal(Fd["VAT"]), 2) };

                    Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0].TaxCategory = new TaxCategoryType();
                    //Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0].TaxCategory.TaxExemptionReason = new TaxExemptionReasonType() { Value = "Vergiden muaf." };
                    Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0].TaxCategory.TaxScheme = new TaxSchemeType();
                    Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0].TaxCategory.TaxScheme.Name = new NameType1() { Value = IZIBIZ_CLASS.Cfg["GIBKdvName"].ToString() };
                    Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0].TaxCategory.TaxScheme.TaxTypeCode = new TaxTypeCodeType() { Value = IZIBIZ_CLASS.Cfg["GIBKdvCode"].ToString() };

                    if (IsKdv != false)//|| Convert.ToDecimal(Fd["VAT"]) == 0
                    {
                        Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0].TaxAmount.Value = 0;
                        Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0].Percent.Value = 0;
                        Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0].TaxCategory.TaxExemptionReason = new TaxExemptionReasonType() { Value = "KDV siz" };
                    }

                    if (Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0].TaxAmount.Value == 0)
                        Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0].TaxCategory.TaxExemptionReason = new TaxExemptionReasonType() { Value = "KDV siz" };

                    if (ln == 2)
                    {
                        decimal yuzde = (Convert.ToDecimal(Fd["DEDUCTIONPART1"]) / Convert.ToDecimal(Fd["DEDUCTIONPART2"])) * (decimal)100;
                        decimal tkdv = 0;

                        if (nrmKdv > 0)
                            tkdv = ((decimal)nrmKdv * (decimal)yuzde) / (decimal)100;

                        Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[1] = new TaxSubtotalType();
                        Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[1].TaxAmount = new TaxAmountType() { currencyID = Inv.DocumentCurrencyCode.Value, Value = Math.Round(tkdv, 2) };
                        Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[1].TaxableAmount = new TaxableAmountType() { currencyID = Inv.DocumentCurrencyCode.Value, Value = Math.Round(Tutar, 2) };
                        //Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0].CalculationSequenceNumeric = new CalculationSequenceNumericType() { Value = 1 };
                        Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[1].Percent = new PercentType() { Value = Math.Round((decimal)yuzde, 2) };

                        Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[1].TaxCategory = new TaxCategoryType();
                        //Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0].TaxCategory.TaxExemptionReason = new TaxExemptionReasonType() { Value = "Vergiden muaf." };
                        Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[1].TaxCategory.TaxScheme = new TaxSchemeType();
                        Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[1].TaxCategory.TaxScheme.Name = new NameType1() { Value = IZIBIZ_CLASS.Cfg["GIBVergiAd1"].ToString() };
                        Inv.InvoiceLine[i].TaxTotal.TaxSubtotal[1].TaxCategory.TaxScheme.TaxTypeCode = new TaxTypeCodeType() { Value = IZIBIZ_CLASS.Cfg["GIBVergiKod1"].ToString() };
                    }

                    #endregion

                    #region indirimler
                    Inv.InvoiceLine[i].AllowanceCharge = new AllowanceChargeType();
                    Inv.InvoiceLine[i].AllowanceCharge.ChargeIndicator = new ChargeIndicatorType() { Value = false };
                    Inv.InvoiceLine[i].AllowanceCharge.Amount = new AmountType1();
                    Inv.InvoiceLine[i].AllowanceCharge.Amount.currencyID = Inv.DocumentCurrencyCode.Value;

                    decimal indTut = Dovizli ? (Convert.ToDecimal(Fd["INDTUT"]) / Convert.ToDecimal(Fd["TRRATE"])) : Convert.ToDecimal(Fd["INDTUT"]);

                    Inv.InvoiceLine[i].AllowanceCharge.Amount.Value = Math.Round(indTut, 2);

                    if (Convert.ToDecimal(Fd["INDTUT"]) > 0)
                    {
                        decimal d = Convert.ToDecimal(Fd["VATMATRAH"]) / (indTut * 100);
                        decimal dx = Math.Round(d, 2);

                        Inv.InvoiceLine[i].AllowanceCharge.MultiplierFactorNumeric = new MultiplierFactorNumericType() { Value = dx / 100 };
                    }
                    else
                        Inv.InvoiceLine[i].AllowanceCharge.MultiplierFactorNumeric = new MultiplierFactorNumericType() { Value = 0 };


                    #endregion
                }
            }
            #endregion

            if ((bool)IZIBIZ_CLASS.Cfg["OZEL_TASARIM"])
            {
                notList.Add(new NoteType() { Value = OzelparaBirim });
                notList.Add(new NoteType() { Value = OzelKur });
                notList.Add(new NoteType() { Value = OzelKurdc == 1 ? "" : (ToplamKdvDahil / OzelKurdc).ToString("n4") });
                notList.Add(new NoteType() { Value = "" });
            }
            Inv.Note = notList.ToArray();
            DateTime FILEYEAR_ = Convert.ToDateTime(F["DATE_"].ToString());
            string GIBFILE = _GLOBAL_PARAMETERS._SIRKET_KODU + FILEYEAR_.ToString("yyyy") + "_" + F["FICHENO"].ToString();

            string pppth = "";
            appPath = _GLOBAL_PARAMETERS._FILE_PATH;// Path.GetDirectoryName(Application.ExecutablePath);
            if (Temp)
            {
                pppth = System.IO.Path.GetTempPath() + "\\" + Guid.NewGuid().ToString() + ".xml";
            }
            else
            {
                //if (!Directory.Exists(appPath +  BOX))    //    Directory.CreateDirectory(appPath +BOX);  
                pppth = appPath + BOX + @"\" + _GLOBAL_PARAMETERS._SIRKET_KODU + @"\" + GIBFILE.Replace(":", "_") + ".xml";
                if (File.Exists(pppth)) File.Delete(pppth);
            }

            XmlSerializer s = new XmlSerializer(typeof(InvoiceType));
            // Writing a file requires a TextWriter.
            TextWriter txtw = new StreamWriter(pppth);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            ns.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            s.Serialize(txtw, Inv, ns);
            txtw.Close();

            return pppth;
        }
    }
}
