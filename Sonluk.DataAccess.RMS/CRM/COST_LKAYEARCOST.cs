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
    public class COST_LKAYEARCOST : ICOST_LKAYEARCOST
    {
        private const string SQL_Create = "CRM_COST_LKAYEARCOST_Create";
        private const string SQL_Update = "CRM_COST_LKAYEARCOST_Update";
        private const string SQL_ReadByParam = "CRM_COST_LKAYEARCOST_ReadByParam";
        private const string SQL_Delete = "CRM_COST_LKAYEARCOST_Delete";
        private const string SQL_ReadCOSTByKHID = "CRM_COST_LKAYEARCOST_ReadCOSTByKHID";
        private const string SQL_GetCost = "CRM_COST_GetCost";
        private const string SQL_UpdateSPJE = "CRM_COST_LKAYEARCOST_UpdateSPJE";

        public int Create(CRM_COST_LKAYEARCOST model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAYEARTTID", model.LKAYEARTTID),
                                        new SqlParameter("@HXZLMXID", model.HXZLMXID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@COSTITEMYEAR", model.COSTITEMYEAR),
                                        new SqlParameter("@LASTHTTKNR", model.LASTHTTKNR),
                                        new SqlParameter("@LASTFYYGE", model.LASTFYYGE),
                                        new SqlParameter("@THISHTTKNR", model.THISHTTKNR),
                                        new SqlParameter("@THISFYYGE", model.THISFYYGE),
                                        new SqlParameter("@THISFYYGEXG", model.THISFYYGEXG),
                                        new SqlParameter("@TBZJ", model.TBZJ),
                                        new SqlParameter("@FYZJYY", model.FYZJYY),
                                        new SqlParameter("@HTTKSFTX", model.HTTKSFTX),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@SHR", model.SHR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_LKAYEARCOST model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTID", model.COSTID),
                                        //new SqlParameter("@LKAYEARTTID", model.LKAYEARTTID),
                                        //new SqlParameter("@HXZLMXID", model.HXZLMXID),
                                        //new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        //new SqlParameter("@COSTITEMYEAR", model.COSTITEMYEAR),
                                        new SqlParameter("@LASTHTTKNR", model.LASTHTTKNR),
                                        new SqlParameter("@LASTFYYGE", model.LASTFYYGE),
                                        new SqlParameter("@THISHTTKNR", model.THISHTTKNR),
                                        //new SqlParameter("@THISFYYGE", model.THISFYYGE),
                                        new SqlParameter("@THISFYYGEXG", model.THISFYYGEXG),
                                        new SqlParameter("@TBZJ", model.TBZJ),
                                        new SqlParameter("@FYZJYY", model.FYZJYY),
                                        new SqlParameter("@HTTKSFTX", model.HTTKSFTX),
                                        //new SqlParameter("@BEIZ", model.BEIZ),
                                        //new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        //new SqlParameter("@SHR", model.SHR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public int UpdateSPJE(CRM_COST_LKAYEARCOST model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTID", model.COSTID),
                                        new SqlParameter("@THISFYYGE", model.THISFYYGE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateSPJE, parms);
        }

        public IList<CRM_COST_LKAYEARCOST> ReadByParam(CRM_COST_LKAYEARCOST model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@COSTID", model.COSTID),
                                        new SqlParameter("@LKAYEARTTID", model.LKAYEARTTID),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)
                                   };
            IList<CRM_COST_LKAYEARCOST> nodes = new List<CRM_COST_LKAYEARCOST>();
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

        public IList<CRM_COST_LKAYEARCOST> ReadCOSTByKHID(int KHID, string YEAR)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID", KHID),
                                        new SqlParameter("@YEAR", YEAR)
                                   };
            IList<CRM_COST_LKAYEARCOST> nodes = new List<CRM_COST_LKAYEARCOST>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadCOSTByKHID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj2(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public CRM_COST_GETCOST GetCost(int LKAID, string HTYEAR)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@LKAID", LKAID),
                                        new SqlParameter("@HTYEAR", HTYEAR)
                                   };
            CRM_COST_GETCOST nodes = new CRM_COST_GETCOST();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_GetCost, parms))
                {
                    if (sdr.Read())
                    {
                        nodes = ReadCostDataToObj(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public int Delete(int COSTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTID", COSTID)
                                       

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

        private CRM_COST_LKAYEARCOST ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAYEARCOST node = new CRM_COST_LKAYEARCOST();
            node.COSTID = Convert.ToInt32(sdr["COSTID"]);
            node.LKAYEARTTID = Convert.ToInt32(sdr["LKAYEARTTID"]);
            node.HXZLMXID = Convert.ToInt32(sdr["HXZLMXID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.COSTITEMYEAR = Convert.ToString(sdr["COSTITEMYEAR"]);
            node.LASTHTTKNR = Convert.ToString(sdr["LASTHTTKNR"]);
            node.LASTFYYGE = Convert.ToDouble(sdr["LASTFYYGE"]);
            node.THISHTTKNR = Convert.ToString(sdr["THISHTTKNR"]);
            node.THISFYYGE = Convert.ToDouble(sdr["THISFYYGE"]);
            node.THISFYYGEXG = Convert.ToDouble(sdr["THISFYYGEXG"]);
            node.TBZJ = Convert.ToDouble(sdr["TBZJ"]);
            node.FYZJYY = Convert.ToString(sdr["FYZJYY"]);
            node.HTTKSFTX = Convert.ToInt32(sdr["HTTKSFTX"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.SHR = Convert.ToInt32(sdr["SHR"]);
            node.SHSJ = Convert.ToDateTime(sdr["SHSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.SHRDES = Convert.ToString(sdr["SHRDES"]);
            node.COSTITEMMC = Convert.ToString(sdr["COSTITEMMC"]);

            return node;
        }

        private CRM_COST_LKAYEARCOST ReadDataToObj2(SqlDataReader sdr)
        {
            CRM_COST_LKAYEARCOST node = new CRM_COST_LKAYEARCOST();
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.LASTHTTKNR = Convert.ToString(sdr["LASTHTTKNR"]);
            node.LASTFYYGE = Convert.ToDouble(sdr["LASTFYYGE"]);
            return node;
        }

        private CRM_COST_GETCOST ReadCostDataToObj(SqlDataReader sdr)
        {
            CRM_COST_GETCOST node = new CRM_COST_GETCOST();
            node.HB_SP = Convert.ToDecimal(sdr["HB_SP"]);
            node.HB_SQ = Convert.ToDecimal(sdr["HB_SQ"]);
            node.DT_SP = Convert.ToDecimal(sdr["DT_SP"]);
            node.DT_SQ = Convert.ToDecimal(sdr["DT_SQ"]);
            node.TSCL_SP = Convert.ToDecimal(sdr["TSCL_SP"]);
            node.TSCL_SQ = Convert.ToDecimal(sdr["TSCL_SQ"]);
            node.ZZF_SP = Convert.ToDecimal(sdr["ZZF_SP"]);
            node.ZZF_SQ = Convert.ToDecimal(sdr["ZZF_SQ"]);
            node.OTHER_SP = Convert.ToDecimal(sdr["OTHER_SP"]);
            node.OTHER_SQ = Convert.ToDecimal(sdr["OTHER_SQ"]);
            return node;
        }


    }
}
