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
    public class WX_OPENID : IWX_OPENID
    {
        private const string SQL_Create = "CRM_WX_OPENID_Create";
        private const string SQL_Update = "CRM_WX_OPENID_Update";
        //private const string SQL_ReadBySTAFFID = "SELECT * FROM CRM_KQ_YGQJ WHERE STAFFID = @STAFFID";
        private const string SQL_Delete = "DELETE FROM CRM_WX_OPENID WHERE STAFFID = @STAFFID AND OPENID = @OPENID";
        private const string SQL_DeleteByID = "CRM_WX_OPENID_Delete";
        private const string SQL_ReadByParam = "CRM_WX_OPENID_ReadByParam";
        private const string SQL_ReadBySTAFFParam = "CRM_WX_OPENID_ReadBySTAFFParam";
        private const string SQL_ReadByORDERTTID = "CRM_WX_OPENID_ReadByORDERTTID";

        public int Create(CRM_WX_OPENID model, string USE)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@ID", model.ID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@OPENID", model.OPENID),
                                        new SqlParameter("@WXDLCS", model.WXDLCS),
                                        new SqlParameter("@USE", USE)
                                 };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);

        }

        public int Update(CRM_WX_OPENID model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ID", model.ID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@OPENID", model.OPENID),
                                        new SqlParameter("@WXDLCS", model.WXDLCS)
                                 };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);

        }

        public int DeleteByID(int ID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ID", ID)
                                 };
            return Binning(CommandType.StoredProcedure, SQL_DeleteByID, parms);

        }

        public int Delete(CRM_WX_OPENID model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@OPENID",model.OPENID)
                                   };
            return Binning(CommandType.Text, SQL_Delete, parms);
        }

        
        public IList<CRM_WX_OPENID> ReadByParam(CRM_WX_OPENID model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@OPENID",model.OPENID),
                                       new SqlParameter("@WXDLCS",model.WXDLCS)
                                   };
            IList<CRM_WX_OPENID> nodes = new List<CRM_WX_OPENID>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_WX_OPENIDList> ReadBySTAFFParam(CRM_WX_OPENIDList model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@DEPID",model.DEPID),
                                       new SqlParameter("@STAFFNO",model.STAFFNO),
                                       new SqlParameter("@STAFFNAME",model.STAFFNAME),
                                       new SqlParameter("@OPENID",model.OPENID)
                                   };
            IList<CRM_WX_OPENIDList> nodes = new List<CRM_WX_OPENIDList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadBySTAFFParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataListToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_WX_OPENIDList> ReadByORDERTTID(int ORDERTTID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ORDERTTID",ORDERTTID)
                                   };
            IList<CRM_WX_OPENIDList> nodes = new List<CRM_WX_OPENIDList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByORDERTTID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataList2ToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        private CRM_WX_OPENID ReadDataToObj(SqlDataReader sdr)
        {
            CRM_WX_OPENID node = new CRM_WX_OPENID();
            node.ID = Convert.ToInt32(sdr["ID"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.OPENID = Convert.ToString(sdr["OPENID"]);
            node.WXDLCS = Convert.ToString(sdr["WXDLCS"]);
            return node;
        }

        private CRM_WX_OPENIDList ReadDataListToObj(SqlDataReader sdr)
        {
            CRM_WX_OPENIDList node = new CRM_WX_OPENIDList();
            node.ID = Convert.ToInt32(sdr["ID"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.OPENID = Convert.ToString(sdr["OPENID"]);
            node.WXDLCS = Convert.ToString(sdr["WXDLCS"]);
            node.DEPID = Convert.ToInt32(sdr["DEPID"]);
            node.DEPIDDES = Convert.ToString(sdr["DEPIDDES"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            return node;
        }

        private CRM_WX_OPENIDList ReadDataList2ToObj(SqlDataReader sdr)
        {
            CRM_WX_OPENIDList node = new CRM_WX_OPENIDList();
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.OPENID = Convert.ToString(sdr["OPENID"]);
            node.WXDLCS = Convert.ToString(sdr["WXDLCS"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
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
