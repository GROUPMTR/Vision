using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VISION.FINANS.ERP
{
 
    public class _ERP_CLASS
    {
        public string FIRMA_TABLE_SQL = @"SELECT DISTINCT RIGHT('000' + CONVERT(nvarchar(3), fr.NR), 3) AS NR, fr.NAME, fr.TITLE, fr.STREET, fr.ROAD, fr.DOORNR, fr.CITY, fr.COUNTRY, fr.ZIPCODE, fr.PHONE1, fr.FAX, 
                                             fr.TAXOFF, fr.TAXNR, fr.SITEID, fr.TAXOFFCODE, fr.WEBADDR, fr.EMAILADDR,fr.LOGICALREF,ACCEPTEINV
                                             FROM       {0}.dbo.L_CAPIFIRM AS fr INNER JOIN {0}.dbo.L_CAPIPERIOD AS per ON fr.NR = per.FIRMNR  where fr.ACCEPTEINV=1 ";

        public string ITEM_TABLE_SQL = @"select  ROW_NUMBER() OVER(ORDER BY x.LOGICALREF DESC) AS 'RowId',x.* FROM(
                                            SELECT     'MALZEME' AS STOK_TUR, it.SPECODE, it.CODE, it.STGRPCODE, it.NAME, it.NAME3, u.NAME AS UNITSETL_NAME, it.NAME2, it.LOGICALREF, it.ACTIVE, it.CARDTYPE, 
                                                                  it.VAT, it.TRACKTYPE, u.LOGICALREF AS UNITSETREF, '{1}' AS FIRMA, 0 AS T, u.GLOBALCODE
                                            FROM         {0}.dbo.LG_{1}_ITEMS it WITH (NOLOCK) LEFT OUTER JOIN {0}.dbo.LG_{1}_UNITSETL AS u ON it.UNITSETREF = u.UNITSETREF WHERE     (it.CLASSTYPE = 0) AND (it.ACTIVE = 0) AND (it.SALESBRWS = 1) and  u.MAINUNIT=1 and ACTIVE=0
                                            UNION ALL
                                            SELECT     N'HIZMET' AS STOK_TUR, srv.SPECODE, srv.CODE, CAST('' AS NVARCHAR) AS STGRPCODE, srv.DEFINITION_ AS NAME, CAST('' AS NVARCHAR) AS NAME3, 
                                                                  ul.CODE AS UNITSETL_NAME, '' AS NAME2, srv.LOGICALREF, srv.ACTIVE, srv.CARDTYPE, srv.VAT, 0 AS TRACKTYPE, ul.LOGICALREF AS UNITSETREF, 
                                                                  '{1}' AS FIRMA, 4 AS T, ul.GLOBALCODE
                                            FROM         {0}.dbo.LG_{1}_SRVCARD srv WITH (NOLOCK) LEFT OUTER JOIN
                                                                  {0}.dbo.LG_{1}_UNITSETF AS uf ON srv.UNITSETREF = uf.LOGICALREF LEFT OUTER JOIN
                                                                  {0}.dbo.LG_{1}_UNITSETL AS ul ON uf.LOGICALREF = ul.UNITSETREF
                                            WHERE     (srv.ACTIVE = 0) AND ul.MAINUNIT = 1 AND (((srv.CARDTYPE > 2) OR ((srv.ACTIVE > 0)) OR ((srv.ACTIVE = 0))) OR ((srv.ACTIVE = 0)))
                                            UNION ALL
                                            SELECT     'İNDİRİM' AS STOK_TUR, ind.SPECODE, ind.CODE, ind.CYPHCODE, ind.DEFINITION_ AS NAME, '' AS NAME3, ind.UNITSTR AS UNITSETL_NAME, '' AS NAME2, 
                                                                  ind.LOGICALREF, ind.ACTIVE, ind.CARDTYPE, ind.VAT, '' AS TRACKTYPE, 0 AS UNITSETREF, '{1}' AS FIRMA, 3 AS T, '' AS GLOBALCODE FROM         {0}.dbo.LG_{1}_DECARDS ind(NOLOCK)) as x";

        public string ERP_DB = "LOGODB";

        public string ERP_USERS_SQL = @"SELECT     LOGICALREF, NR, NAME, FIRMNR , EMAILA FROM   {0}.dbo.L_CAPIUSER WHERE  (BLOCKED = 0) AND LOGICALREF IN  (SELECT KULID FROM YETKILER)";
         
        public string INVOICE_TABLE_SQL_EFATURA = @"SELECT   CASE WHEN fat.EINVOICE = 1 THEN 'e-fatura'  END AS FATURANIN_TURU , cast('0' as bit) as  SEC,  fat.DATE_, fat.FICHENO, fat.DOCODE, cari.CODE, cari.DEFINITION_, 
                                                CASE WHEN fat.TRCODE = 1 THEN 'Satın Alma' WHEN fat.TRCODE = 2 THEN 'Parakende Satış İade' WHEN fat.TRCODE = 3 THEN 'Toptan Satış İade' WHEN fat.TRCODE
                                                = 4 THEN 'Alınan Hizmet' WHEN fat.TRCODE = 5 THEN 'Alınan Proforma' WHEN fat.TRCODE = 6 THEN 'Alş İade' WHEN fat.TRCODE = 7 THEN 'Parakende Satış' WHEN
                                                fat.TRCODE = 8 THEN 'Toptan Satış' WHEN fat.TRCODE = 9 THEN 'Verilen Hizmet' WHEN fat.TRCODE = 10 THEN 'Verilen Proforma' WHEN fat.TRCODE = 13 THEN 'Alış Fiyat Farkı'
                                                WHEN fat.TRCODE = 14 THEN 'Satış Fiyat Farkı' WHEN fat.TRCODE = 26 THEN 'Mustahsil Makbuz' ELSE 'Diğer' END AS TRCODE_, 
                                                CASE WHEN GRPCODE = 2 THEN 'Satış' ELSE 'Alış' END AS GRPCODE_, fat.GRPCODE, fat.TRCODE, fat.LOGICALREF, cari.SPECODE, cari.CYPHCODE, cari.ADDR1, 
                                                cari.ADDR2, cari.CITY, cari.COUNTRY, cari.POSTCODE, cari.TELNRS1, cari.TELNRS2, cari.FAXNR, cari.TAXNR, cari.TAXOFFICE, cari.INCHARGE, cari.DISCRATE, 
                                                cari.EXTENREF, cari.PAYMENTREF, cari.EMAILADDR, cari.WEBADDR, cari.WARNMETHOD, cari.WARNEMAILADDR, cari.WARNFAXNR, cari.CLANGUAGE, cari.VATNR, 
                                                cari.CCURRENCY, cari.SITEID, cari.CITYCODE, cari.ADRESSNO, cari.EINVOICETYPE, cari.TCKNO, cari.CITYID, cari.TAXOFFCODE, cari.PAYMENTPROC, 
                                                fat.GROSSTOTAL, cari.TOWNCODE, cari.TOWN, cari.COUNTRYCODE,'{1}' as FRM , '{2}' as DON, fat.TOTALDISCOUNTS,fat.DOCTRACKINGNR, 
                                                fat.ADDDISCOUNTS,fat.VAT,fat.TOTALVAT,  fat.NETTOTAL ,  pay.GLOBALCODE , fat.PAYDEFREF,cari.PROFILEID, fat.TRCURR, cari.POSTLABELCODE, cari.SENDERLABELCODE, fat.GUID , fat.GENEXP1 ,fat.GENEXP2 ,fat.GENEXP3 ,fat.GENEXP4, cari.DISTRICT , fat.TRNET , fat.TRRATE , cari.ISPERSCOMP , cari.EARCEMAILADDR1
                                                FROM {0}.dbo.LG_{1}_{2}_INVOICE AS fat INNER JOIN {0}.dbo.LG_{1}_CLCARD AS cari ON fat.CLIENTREF = cari.LOGICALREF LEFT OUTER JOIN {0}.dbo.LG_{1}_PAYPLANS AS pay ON fat.PAYDEFREF = pay.LOGICALREF 
                                                where  fat.CANCELLED=0 and fat.ESTATUS=0 AND (NOT (CASE WHEN fat.EINVOICE = 1 THEN 'e-fatura' END IS NULL))   ";

        //( SELECT Count(*)  FROM [dbo].INVPRINTED Where LOGICALREF=fat.LOGICALREF AND FRM='{1}' )fat.EINVOICE>0 and 
        //                        as PrintCnt



        public string INVOICE_TABLE_SQL_PRINT = @"SELECT        CASE WHEN fat.EINVOICE <> 1 THEN 'e-arşiv' END AS FATURANIN_TURU, CAST('0' AS bit) AS SEC, fat.DATE_, fat.FICHENO, fat.DOCODE, cari.CODE, cari.DEFINITION_, 
                         CASE WHEN fat.TRCODE = 1 THEN 'Satın Alma' WHEN fat.TRCODE = 2 THEN 'Parakende Satış İade' WHEN fat.TRCODE = 3 THEN 'Toptan Satış İade' WHEN fat.TRCODE = 4 THEN 'Alınan Hizmet' WHEN fat.TRCODE
                          = 5 THEN 'Alınan Proforma' WHEN fat.TRCODE = 6 THEN 'Alş İade' WHEN fat.TRCODE = 7 THEN 'Parakende Satış' WHEN fat.TRCODE = 8 THEN 'Toptan Satış' WHEN fat.TRCODE = 9 THEN 'Verilen Hizmet' WHEN
                          fat.TRCODE = 10 THEN 'Verilen Proforma' WHEN fat.TRCODE = 13 THEN 'Alış Fiyat Farkı' WHEN fat.TRCODE = 14 THEN 'Satış Fiyat Farkı' WHEN fat.TRCODE = 26 THEN 'Mustahsil Makbuz' ELSE 'Diğer' END AS TRCODE_,
                          CASE WHEN GRPCODE = 2 THEN 'Satış' ELSE 'Alış' END AS GRPCODE_, fat.GRPCODE, fat.TRCODE, fat.LOGICALREF, cari.SPECODE, cari.CYPHCODE, cari.ADDR1, cari.ADDR2, cari.CITY, cari.COUNTRY, 
                         cari.POSTCODE, cari.TELNRS1, cari.TELNRS2, cari.FAXNR, cari.TAXNR, cari.TAXOFFICE, cari.INCHARGE, cari.DISCRATE, cari.EXTENREF, cari.PAYMENTREF, cari.EMAILADDR, cari.WEBADDR, 
                         cari.WARNMETHOD, cari.WARNEMAILADDR, cari.WARNFAXNR, cari.CLANGUAGE, cari.VATNR, cari.CCURRENCY, cari.SITEID, cari.CITYCODE, cari.ADRESSNO, cari.EINVOICETYPE, cari.TCKNO, cari.CITYID, 
                         cari.TAXOFFCODE, cari.PAYMENTPROC, fat.GROSSTOTAL, cari.TOWNCODE, cari.TOWN, cari.COUNTRYCODE, '{1}' AS FRM, '01' AS DON, fat.TOTALDISCOUNTS, fat.DOCTRACKINGNR, fat.ADDDISCOUNTS, 
                         fat.VAT, fat.TOTALVAT, fat.NETTOTAL, pay.GLOBALCODE, fat.PAYDEFREF, cari.PROFILEID, fat.TRCURR, cari.POSTLABELCODE, cari.SENDERLABELCODE, fat.GUID, fat.GENEXP1, fat.GENEXP2, fat.GENEXP3, 
                         fat.GENEXP4, cari.DISTRICT, fat.TRNET, fat.TRRATE, cari.ISPERSCOMP, cari.EARCEMAILADDR1
FROM            dbo.LG_{1}_{2}_INVOICE AS fat INNER JOIN
                         dbo.LG_{1}_CLCARD AS cari ON fat.CLIENTREF = cari.LOGICALREF INNER JOIN
                         dbo.LG_{1}_{2}_EARCHIVEDET ON fat.LOGICALREF = dbo.LG_{1}_{2}_EARCHIVEDET.INVOICEREF LEFT OUTER JOIN
                         dbo.LG_{1}_PAYPLANS AS pay ON fat.PAYDEFREF = pay.LOGICALREF
WHERE        (fat.CANCELLED = 0) AND (NOT (CASE WHEN fat.EINVOICE <> 1 THEN 'e-arşiv' END IS NULL)) AND (dbo.LG_{1}_{2}_EARCHIVEDET.EARCHIVESTATUS = 0) ";



        //public string INVOICE_TABLE_SQL_PRINT = @"SELECT    cast('0' as bit) as  SEC,  fat.DATE_, fat.FICHENO, fat.DOCODE, cari.CODE, cari.DEFINITION_, 
        //                                        CASE WHEN fat.TRCODE = 1 THEN 'Satın Alma' WHEN fat.TRCODE = 2 THEN 'Parakende Satış İade' WHEN fat.TRCODE = 3 THEN 'Toptan Satış İade' WHEN fat.TRCODE
        //                                        = 4 THEN 'Alınan Hizmet' WHEN fat.TRCODE = 5 THEN 'Alınan Proforma' WHEN fat.TRCODE = 6 THEN 'Alş İade' WHEN fat.TRCODE = 7 THEN 'Parakende Satış' WHEN
        //                                        fat.TRCODE = 8 THEN 'Toptan Satış' WHEN fat.TRCODE = 9 THEN 'Verilen Hizmet' WHEN fat.TRCODE = 10 THEN 'Verilen Proforma' WHEN fat.TRCODE = 13 THEN 'Alış Fiyat Farkı'
        //                                        WHEN fat.TRCODE = 14 THEN 'Satış Fiyat Farkı' WHEN fat.TRCODE = 26 THEN 'Mustahsil Makbuz' ELSE 'Diğer' END AS TRCODE_, 
        //                                        CASE WHEN GRPCODE = 2 THEN 'Satış' ELSE 'Alış' END AS GRPCODE_, fat.GRPCODE, fat.TRCODE, fat.LOGICALREF, cari.SPECODE, cari.CYPHCODE, cari.ADDR1, 
        //                                        cari.ADDR2, cari.CITY, cari.COUNTRY, cari.POSTCODE, cari.TELNRS1, cari.TELNRS2, cari.FAXNR, cari.TAXNR, cari.TAXOFFICE, cari.INCHARGE, cari.DISCRATE, 
        //                                        cari.EXTENREF, cari.PAYMENTREF, cari.EMAILADDR, cari.WEBADDR, cari.WARNMETHOD, cari.WARNEMAILADDR, cari.WARNFAXNR, cari.CLANGUAGE, cari.VATNR, 
        //                                        cari.CCURRENCY, cari.SITEID, cari.CITYCODE, cari.ADRESSNO, cari.EINVOICETYPE, cari.TCKNO, cari.CITYID, cari.TAXOFFCODE, cari.PAYMENTPROC, 
        //                                        fat.GROSSTOTAL, cari.TOWNCODE, cari.TOWN, cari.COUNTRYCODE,'{1}' as FRM , '{2}' as DON, fat.TOTALDISCOUNTS, 
        //                                        fat.ADDDISCOUNTS,fat.VAT,fat.TOTALVAT,fat.NETTOTAL ,  pay.GLOBALCODE , fat.PAYDEFREF,cari.PROFILEID, fat.TRCURR, cari.POSTLABELCODE, cari.SENDERLABELCODE, fat.GUID , fat.GENEXP1 ,fat.GENEXP2 ,fat.GENEXP3 ,fat.GENEXP4, cari.DISTRICT , fat.TRNET , fat.TRRATE , cari.ISPERSCOMP  
        //                                        FROM {0}.dbo.LG_{1}_{2}_INVOICE AS fat INNER JOIN {0}.dbo.LG_{1}_CLCARD AS cari ON fat.CLIENTREF = cari.LOGICALREF LEFT OUTER JOIN {0}.dbo.LG_{1}_PAYPLANS AS pay ON fat.PAYDEFREF = pay.LOGICALREF 
        //                                        where  fat.EINVOICE=0 and fat.CANCELLED=0 ";
                                              //fat.LOGICALREF not in (Select INVID  From FTR_INVTRNS Where FRM='{1}') and  

        public string LINE_TABLE_SQL = @"  SELECT    itm.CODE, itm.NAME, ln.AMOUNT, ln.TOTAL, ln.VAT, ln.VATAMNT,   ln.VATMATRAH, ln.LINETYPE, ln.TRCODE, ln.DATE_, ln.PRICE, ln.PRPRICE, 
                                              ln.STOCKREF, ln.INVOICEREF, ln.LOGICALREF, '{1}' AS FRM, '{2}' AS DON, ord.FICHENO AS ORDFICHENO, ord.DATE_ AS ORDTARIH,
                                                  (SELECT     ISNULL(SUM(TOTAL), 0) AS Expr1
                                                    FROM          {0}.dbo.LG_{1}_{2}_STLINE AS l
                                                    WHERE      (INVOICEREF = ln.INVOICEREF) AND (INVOICELNNO > ln.INVOICELNNO) AND (LINETYPE = 2) AND (GLOBTRANS <> 1) AND 
                                                                           (INVOICELNNO < ISNULL
                                                                               ((SELECT     TOP (1) INVOICELNNO
                                                                                   FROM         {0}.dbo.LG_{1}_{2}_STLINE AS mh
                                                                                   WHERE     (INVOICEREF = ln.INVOICEREF) AND (LINETYPE IN (0, 4)) AND (INVOICELNNO > ln.INVOICELNNO)
                                                                                   ORDER BY INVOICELNNO), ln.INVOICELNNO + 2))) AS INDTUT, itm.GLOBALCODE, ln.DEDUCTIONPART1, ln.DEDUCTIONPART2, ln.PRCURR, 
                                              ln.TRCURR, ln.TRRATE, ln.LINEEXP, ul.GLOBALCODE AS LGLOBALCODE
                        FROM         {0}.dbo.LG_{1}_{2}_STLINE AS ln WITH (NOLOCK) LEFT OUTER JOIN
                       ( 
 
                               SELECT     ROW_NUMBER() OVER (ORDER BY x.LOGICALREF DESC) AS 'RowId', x.* FROM(SELECT     'MALZEME' AS STOK_TUR, it.SPECODE, it.CODE, it.STGRPCODE, it.NAME, it.NAME3, u.NAME AS UNITSETL_NAME, it.NAME2, it.LOGICALREF, it.ACTIVE, 
                                                              it.CARDTYPE, it.VAT, it.TRACKTYPE, u.LOGICALREF AS UNITSETREF, '{1}' AS FIRMA, 0 AS T, u.GLOBALCODE
                                       FROM          {0}.dbo.LG_{1}_ITEMS it WITH (NOLOCK) LEFT OUTER JOIN
                                                              {0}.dbo.LG_{1}_UNITSETL AS u ON it.UNITSETREF = u.UNITSETREF
                                       WHERE      (it.CLASSTYPE = 0) AND (it.ACTIVE = 0) AND (it.SALESBRWS = 1) AND u.MAINUNIT = 1 AND ACTIVE = 0
                                       UNION ALL
                                       SELECT     N'HIZMET' AS STOK_TUR, srv.SPECODE, srv.CODE, CAST('' AS NVARCHAR) AS STGRPCODE, srv.DEFINITION_ AS NAME, CAST('' AS NVARCHAR) 
                                                             AS NAME3, ul.CODE AS UNITSETL_NAME, '' AS NAME2, srv.LOGICALREF, srv.ACTIVE, srv.CARDTYPE, srv.VAT, 0 AS TRACKTYPE, 
                                                             ul.LOGICALREF AS UNITSETREF, '{1}' AS FIRMA, 4 AS T, ul.GLOBALCODE
                                       FROM         {0}.dbo.LG_{1}_SRVCARD srv WITH (NOLOCK) LEFT OUTER JOIN
                                                             {0}.dbo.LG_{1}_UNITSETF AS uf ON srv.UNITSETREF = uf.LOGICALREF LEFT OUTER JOIN
                                                             {0}.dbo.LG_{1}_UNITSETL AS ul ON uf.LOGICALREF = ul.UNITSETREF
                                       WHERE     (srv.ACTIVE = 0) AND ul.MAINUNIT = 1 AND (((srv.CARDTYPE > 2) OR
                                                             ((srv.ACTIVE > 0)) OR
                                                             ((srv.ACTIVE = 0))) OR
                                                             ((srv.ACTIVE = 0)))
                                       UNION ALL
                                       SELECT     'İNDİRİM' AS STOK_TUR, ind.SPECODE, ind.CODE, ind.CYPHCODE, ind.DEFINITION_ AS NAME, '' AS NAME3, ind.UNITSTR AS UNITSETL_NAME, 
                                                             '' AS NAME2, ind.LOGICALREF, ind.ACTIVE, ind.CARDTYPE, ind.VAT, '' AS TRACKTYPE, 0 AS UNITSETREF, '{1}' AS FIRMA, 3 AS T, '' AS GLOBALCODE
                                       FROM         {0}.dbo.LG_{1}_DECARDS ind(NOLOCK)) AS x 


                        ) AS itm ON ln.STOCKREF = itm.LOGICALREF AND ln.LINETYPE = itm.T LEFT OUTER JOIN
                                              {0}.dbo.LG_{1}_{2}_ORFICHE AS ord ON ln.ORDFICHEREF = ord.LOGICALREF LEFT OUTER JOIN
                                              {0}.dbo.LG_{1}_UNITSETL AS ul ON ln.UOMREF = ul.LOGICALREF
                        WHERE     (ln.LINETYPE IN (0, 4,8)) "; 

        public string PAY_SQL = @"SELECT     pp.LOGICALREF AS PAYPLANID, pp.CODE, pp.DEFINITION_, pp.SPECODE, pp.GLOBALCODE AS PAYPLANGLOBAL, pl.LOGICALREF, pl.PAYPLANREF, pl.LINENO_, 
                                      pl.AFTERDAYS, pl.FORMULA, pl.CONDITION, pl.DAY_, pl.MOUNTH, pl.YEAR_, pl.RNDVALUE, pl.ABSDATE, pl.DATETYPE, pl.DISCRATE, pl.PAYMENTTYPE, 
                                      pl.BANKACCREF, pl.REPAYDEFREF, pl.TRCURR, pl.GLOBALCODE
                                      FROM         {0}.dbo.LG_{1}_PAYPLANS AS pp LEFT OUTER JOIN
                                      {0}.dbo.LG_{1}_PAYLINES AS pl ON pp.LOGICALREF = pl.PAYPLANREF";

        public string CARI_KART_SQL = @"SELECT     CODE, DEFINITION_,  TAXNR, TAXOFFICE, CARDTYPE,ADDR1,LOGICALREF,ACCEPTEINV,[POSTLABELCODE],[SENDERLABELCODE],
                                        case 
                                         when PROFILEID is null then 2
                                         when PROFILEID = 0  then 2
                                        else PROFILEID end  AS PROFILEID , ISPERSCOMP , TCKNO, EMAILADDR 
                                        FROM         {0}.dbo.LG_{1}_CLCARD
                                        WHERE     (CARDTYPE <> 22) and ACCEPTEINV>0  AND (ACTIVE = 0) ";

        public string vCURRSQL = @"SELECT DISTINCT  CURCODE, CURNAME, ISNULL(GLOBALID, '') AS GLOBALID, CURSYMBOL, SUBNAME, CURTYPE FROM  {0}.dbo.L_CURRENCYLIST";

        public string vSIP_SQL = @"SELECT     ord.FICHENO, ord.DATE_, it.CODE, it.NAME, orl.AMOUNT , orl.SHIPPEDAMOUNT, orl.PRICE, orl.TOTAL, orl.VAT, orl.VATAMNT, orl.VATMATRAH, ord.TOTALVAT, ord.NETTOTAL, 
                                      ord.TOTALDISCOUNTS, ord.TOTALDISCOUNTED, ord.ADDDISCOUNTS, ord.TRCODE, ord.CLIENTREF, ord.LOGICALREF, orl.STOCKREF, orl.LINETYPE, 
                                      orl.LOGICALREF AS LINELOGICALREF, orl.TRCODE AS TRLINE, orl.GLOBTRANS, orl.DISCPER  FROM  {0}.dbo.LG_{1}_{2}_ORFICHE AS ord INNER JOIN
                                      {0}.dbo.LG_{1}_{2}_ORFLINE AS orl ON ord.LOGICALREF = orl.ORDFICHEREF INNER JOIN   dbo.vLOGO_ITEMS_{1} AS it ON orl.STOCKREF = it.LOGICALREF AND orl.LINETYPE = it.T   WHERE (ord.TRCODE = 2)";


        public string IsCalcKdv = @" Select Count(*) From {0}.dbo.L_TRADGRP as  tg with (nolock)  inner join {0}.dbo.LG_{1}_{2}_INVOICE as inv with (nolock)   ON tg.GCODE=inv.TRADINGGRP Where inv.LOGICALREF={3} and tg.GATTRIB=1 ";

        public string IsCalcTevkKdv = @" Select Count(*) From {0}.dbo.L_TRADGRP as  tg with (nolock)  inner join {0}.dbo.LG_{1}_{2}_INVOICE as inv with (nolock)  ON tg.GCODE=inv.TRADINGGRP Where inv.LOGICALREF={3} and tg.GATTRIB=32 ";


    }
}
