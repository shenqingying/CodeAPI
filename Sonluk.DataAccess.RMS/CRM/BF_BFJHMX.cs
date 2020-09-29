using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
namespace Sonluk.DataAccess.RMS.CRM
{
    public class BF_BFJHMX : IBF_BFJHMX
    {
        private const string SQL_Create = "CRM_BF_BFJHMX_Create";
        private const string SQL_Update = "CRM_BF_BFJHMX_Update";
        private const string SQL_ReadbyBFJHID = "CRM_BF_BFJHMX_ReadbyBFJHID";//"SELECT A.*,ISNULL((SELECT STAFFNAME FROM CRM_HG_STAFF WHERE STAFFID = A.BFRYID),' ') AS STAFFNAME,ISNULL((SELECT STAFFNO FROM CRM_HG_STAFF WHERE STAFFID = A.BFRYID),' ') AS STAFFNO,ISNULL((SELECT CRMID FROM CRM_KH_KH WHERE KHID = A.KHID),' ') AS CRMID FROM CRM_BF_BFJHMX AS A WHERE BFJHID = @BFJHID AND ISACTIVE = 1";
        private const string SQL_Delete = "CRM_BF_BFJHMX_Delete";
        public int Create(CRM_BF_BFJHMX model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@BFJHMXID", model.BFJHMXID),
                                        new SqlParameter("@BFJHID", model.BFJHID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@KHMC", model.KHMC),
                                        new SqlParameter("@KHLX", model.KHLX),
                                        new SqlParameter("@BFRYID", model.BFRYID),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_BF_BFJHMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@BFJHMXID", model.BFJHMXID),
                                        new SqlParameter("@BFJHID", model.BFJHID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@KHMC", model.KHMC),
                                        new SqlParameter("@KHLX", model.KHLX),
                                        new SqlParameter("@BFRYID", model.BFRYID),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_BF_BFJHMXList> ReadbyBFJHID(int BFJHID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BFJHID",BFJHID)
                                   };
            IList<CRM_BF_BFJHMXList> nodes = new List<CRM_BF_BFJHMXList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadbyBFJHID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToListOBJ(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }
        public int Delete(CRM_BF_BFJHMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@BFJHMXID", model.BFJHMXID),
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }
     


        private CRM_BF_BFJHMX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_BF_BFJHMX node = new CRM_BF_BFJHMX();
            node.BFJHMXID = Convert.ToInt32(sdr["BFJHMXID"]);
            node.BFJHID = Convert.ToInt32(sdr["BFJHID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.KHMC = Convert.ToString(sdr["KHMC"]);
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);
            node.BFRYID = Convert.ToInt32(sdr["BFRYID"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);

            return node;
        }
        private CRM_BF_BFJHMXList ReadDataToListOBJ(SqlDataReader sdr)
        {
            CRM_BF_BFJHMXList node = new CRM_BF_BFJHMXList();
            node.BFJHMXID = Convert.ToInt32(sdr["BFJHMXID"]);
            node.BFJHID = Convert.ToInt32(sdr["BFJHID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.KHMC = Convert.ToString(sdr["KHMC"]);
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);
            node.BFRYID = Convert.ToInt32(sdr["BFRYID"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            return node;
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
    }
}
