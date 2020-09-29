using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.CRM
{
    public class HD_ZDF : IHD_ZDF
    {
        private const string SQL_Create = "CRM_HD_ZDF_Create";
        private const string SQL_Update = "CRM_HD_ZDF_Update";
        private const string SQL_Read = "CRM_HD_ZDF_Read";
        private const string SQL_Delete = "CRM_HD_ZDF_Delete";
        private const string SQL_ReadByZDFID = "CRM_HD_ZDF_ReadByZDFID";
        private const string SQL_ReadBySTAFFID = "CRM_HD_ZDF_ReadBySTAFFID";

        public int Create(CRM_HD_ZDF model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@ZDFID", model.ZDFID),
                                        new SqlParameter("@SQRID", model.SQRID),
                                        new SqlParameter("@SQBMID", model.SQBMID),
                                        new SqlParameter("@SQSJ", model.SQSJ),
                                        new SqlParameter("@ZDRQ", model.ZDRQ),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@KHNAME", model.KHNAME),
                                        new SqlParameter("@KHMX", model.KHMX),
                                        new SqlParameter("@JDRS", model.JDRS),
                                        new SqlParameter("@PKRS", model.PKRS),
                                        new SqlParameter("@ZDLY", model.ZDLY),
                                        new SqlParameter("@YJJE", model.YJJE),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_HD_ZDF model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ZDFID", model.ZDFID),
                                        new SqlParameter("@SQRID", model.SQRID),
                                        new SqlParameter("@SQBMID", model.SQBMID),
                                        new SqlParameter("@SQSJ", model.SQSJ),
                                        new SqlParameter("@ZDRQ", model.ZDRQ),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@KHNAME", model.KHNAME),
                                        new SqlParameter("@KHMX", model.KHMX),
                                        new SqlParameter("@JDRS", model.JDRS),
                                        new SqlParameter("@PKRS", model.PKRS),
                                        new SqlParameter("@ZDLY", model.ZDLY),
                                        new SqlParameter("@YJJE", model.YJJE),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_HD_ZDFList> Read(CRM_HD_ZDF_PARAMS model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@FROMZDRQ",model.FROMZDRQ),
                                       new SqlParameter("@TOZDRQ",model.TOZDRQ),
                                       new SqlParameter("@KHID",model.KHID),
                                       new SqlParameter("@KHNAME",model.KHNAME),
                                       new SqlParameter("@KHMX",model.KHMX),
                                       new SqlParameter("@STAFFNAME",model.STAFFNAME),
                                       new SqlParameter("@FROMSQSJ",model.FROMSQSJ),
                                       new SqlParameter("@TOSQSJ",model.TOSQSJ),
                                       new SqlParameter("@DEPID",model.DEPID)
                                   };
            IList<CRM_HD_ZDFList> nodes = new List<CRM_HD_ZDFList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToListObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }
        public CRM_HD_ZDF ReadByZDFID(int ZDFID)
        {
            SqlParameter[] pamrs = {
                                       new SqlParameter("@ZDFID",ZDFID)
                                   };
            CRM_HD_ZDF node = new CRM_HD_ZDF();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByZDFID, pamrs))
                {
                    if (sdr.Read())
                    {
                        node = ReadDataToObj(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return node;

        }
        public IList<CRM_HD_ZDFList> ReadBySTAFFID(CRM_HD_ZDF_PARAMS model)
        {
            SqlParameter[] pamrs = {
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                       new SqlParameter("@FROMZDRQ",model.FROMZDRQ),
                                       new SqlParameter("@TOZDRQ",model.TOZDRQ),
                                       new SqlParameter("@KHID",model.KHID),
                                       new SqlParameter("@KHNAME",model.KHNAME),
                                       new SqlParameter("@KHMX",model.KHMX),
                                       new SqlParameter("@FROMSQSJ",model.FROMSQSJ),
                                       new SqlParameter("@TOSQSJ",model.TOSQSJ),
                                   };
            IList<CRM_HD_ZDFList> nodes = new List<CRM_HD_ZDFList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadBySTAFFID, pamrs))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToListObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;

        }
        public int Delete(int ZDFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ZDFID", ZDFID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }
      


        private int Binning(CommandType type, string sql, SqlParameter[] parms)
        {
            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(type, sql, parms))
                {
                    if (sdr.Read())
                    {
                        ID = Convert.ToInt32(sdr["ID"]);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return ID;
        }

        private CRM_HD_ZDF ReadDataToObj(SqlDataReader sdr)
        {
            CRM_HD_ZDF node = new CRM_HD_ZDF();
            node.ZDFID = Convert.ToInt32(sdr["ZDFID"]);
            node.SQRID = Convert.ToInt32(sdr["SQRID"]);
            node.SQBMID = Convert.ToInt32(sdr["SQBMID"]);
            node.SQSJ = Convert.ToDateTime(sdr["SQSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); 
            node.ZDRQ = Convert.ToString(sdr["ZDRQ"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.KHNAME = Convert.ToString(sdr["KHNAME"]);
            node.KHMX = Convert.ToString(sdr["KHMX"]);
            node.JDRS = Convert.ToInt32(sdr["JDRS"]);
            node.PKRS = Convert.ToInt32(sdr["PKRS"]);
            node.ZDLY = Convert.ToString(sdr["ZDLY"]);
            node.YJJE = Convert.ToDecimal(sdr["YJJE"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            return node;
        }
        private CRM_HD_ZDFList ReadDataToListObj(SqlDataReader sdr)
        {
            CRM_HD_ZDFList node = new CRM_HD_ZDFList();
            node.ZDFID = Convert.ToInt32(sdr["ZDFID"]);
            node.SQRID = Convert.ToInt32(sdr["SQRID"]);
            node.SQBMID = Convert.ToInt32(sdr["SQBMID"]);
            node.SQSJ = Convert.ToDateTime(sdr["SQSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.ZDRQ = Convert.ToString(sdr["ZDRQ"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.KHNAME = Convert.ToString(sdr["KHNAME"]);
            node.KHMX = Convert.ToString(sdr["KHMX"]);
            node.JDRS = Convert.ToInt32(sdr["JDRS"]);
            node.PKRS = Convert.ToInt32(sdr["PKRS"]);
            node.ZDLY = Convert.ToString(sdr["ZDLY"]);
            node.YJJE = Convert.ToDecimal(sdr["YJJE"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            node.DEPNAME = Convert.ToString(sdr["DEPNAME"]);
            return node;
        }





    }
}
