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
    public class COST_KAYEARCOST : ICOST_KAYEARCOST
    {
        private const string SQL_Create = "CRM_COST_KAYEARCOST_Create";
        private const string SQL_Update = "CRM_COST_KAYEARCOST_Update";
        private const string SQL_ReadByParam = "CRM_COST_KAYEARCOST_ReadByParam";
        private const string SQL_Delete = "CRM_COST_KAYEARCOST_Delete";
        private const string SQL_UpdateSPJE = "CRM_COST_KAYEARCOST_UpdateSPJE";
        private const string SQL_Read_Unconnected = "CRM_COST_KAYEARCOST_Read_Unconnected";

        public int Create(CRM_COST_KAYEARCOST model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KAYEARTTID", model.KAYEARTTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@HTTK_LAST", model.HTTK_LAST),
                                        new SqlParameter("@JE_LAST", model.JE_LAST),
                                        new SqlParameter("@FYL_LAST", model.FYL_LAST),
                                        new SqlParameter("@WSJE_LAST", model.WSJE_LAST),
                                        new SqlParameter("@SL_LAST", model.SL_LAST),
                                        new SqlParameter("@HTTK_THIS", model.HTTK_THIS),
                                        new SqlParameter("@JE_THIS", model.JE_THIS),
                                        new SqlParameter("@JEXG_THIS", model.JEXG_THIS),
                                        new SqlParameter("@FYL_THIS", model.FYL_THIS),
                                        new SqlParameter("@WSJE_THIS", model.WSJE_THIS),
                                        new SqlParameter("@WSJEXG_THIS", model.WSJEXG_THIS),
                                        new SqlParameter("@SL_THIS", model.SL_THIS),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_KAYEARCOST model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTID", model.COSTID),
                                        new SqlParameter("@HTTK_LAST", model.HTTK_LAST),
                                        new SqlParameter("@JE_LAST", model.JE_LAST),
                                        new SqlParameter("@FYL_LAST", model.FYL_LAST),
                                        new SqlParameter("@WSJE_LAST", model.WSJE_LAST),
                                        new SqlParameter("@SL_LAST", model.SL_LAST),
                                        new SqlParameter("@HTTK_THIS", model.HTTK_THIS),
                                        new SqlParameter("@JEXG_THIS", model.JEXG_THIS),
                                        new SqlParameter("@FYL_THIS", model.FYL_THIS),
                                        new SqlParameter("@WSJEXG_THIS", model.WSJEXG_THIS),
                                        new SqlParameter("@SL_THIS", model.SL_THIS),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public int UpdateSPJE(int KAYEARTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KAYEARTTID", KAYEARTTID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateSPJE, parms);
        }

        public IList<CRM_COST_KAYEARCOST> ReadByParam(CRM_COST_KAYEARCOST model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTID", model.COSTID),
                                        new SqlParameter("@KAYEARTTID", model.KAYEARTTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@TT_KHID", model.TT_KHID),
                                        new SqlParameter("@TT_HTYEAR", model.TT_HTYEAR)
                                   };
            IList<CRM_COST_KAYEARCOST> nodes = new List<CRM_COST_KAYEARCOST>();
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

        public IList<CRM_COST_KAYEARCOST> Read_Unconnected(CRM_COST_KAYEARCOST model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@TT_KHID", model.TT_KHID),
                                        new SqlParameter("@TT_HTYEAR", model.TT_HTYEAR)
                                   };
            IList<CRM_COST_KAYEARCOST> nodes = new List<CRM_COST_KAYEARCOST>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_Unconnected, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadUnConnDataToObj(sdr));
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

        private CRM_COST_KAYEARCOST ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_KAYEARCOST node = new CRM_COST_KAYEARCOST();
            node.COSTID = Convert.ToInt32(sdr["COSTID"]);
            node.KAYEARTTID = Convert.ToInt32(sdr["KAYEARTTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.HTTK_LAST = Convert.ToString(sdr["HTTK_LAST"]);
            node.JE_LAST = Convert.ToDecimal(sdr["JE_LAST"]);
            node.FYL_LAST = Convert.ToDecimal(sdr["FYL_LAST"]);
            node.WSJE_LAST = Convert.ToDecimal(sdr["WSJE_LAST"]);
            node.SL_LAST = Convert.ToInt32(sdr["SL_LAST"]);
            node.HTTK_THIS = Convert.ToString(sdr["HTTK_THIS"]);
            node.JE_THIS = Convert.ToDecimal(sdr["JE_THIS"]);
            node.JEXG_THIS = Convert.ToDecimal(sdr["JEXG_THIS"]);
            node.FYL_THIS = Convert.ToDecimal(sdr["FYL_THIS"]);
            node.WSJE_THIS = Convert.ToDecimal(sdr["WSJE_THIS"]);
            node.WSJEXG_THIS = Convert.ToDecimal(sdr["WSJEXG_THIS"]);
            node.SL_THIS = Convert.ToInt32(sdr["SL_THIS"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            node.SL_LASTDES = Convert.ToString(sdr["SL_LASTDES"]);
            node.SL_THISDES = Convert.ToString(sdr["SL_THISDES"]);
            return node;
        }

        private CRM_COST_KAYEARCOST ReadUnConnDataToObj(SqlDataReader sdr)
        {
            CRM_COST_KAYEARCOST node = new CRM_COST_KAYEARCOST();
            node.COSTID = Convert.ToInt32(sdr["COSTID"]);
            node.KAYEARTTID = Convert.ToInt32(sdr["KAYEARTTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.HTTK_LAST = Convert.ToString(sdr["HTTK_LAST"]);
            node.JE_LAST = Convert.ToDecimal(sdr["JE_LAST"]);
            node.FYL_LAST = Convert.ToDecimal(sdr["FYL_LAST"]);
            node.WSJE_LAST = Convert.ToDecimal(sdr["WSJE_LAST"]);
            node.SL_LAST = Convert.ToInt32(sdr["SL_LAST"]);
            node.HTTK_THIS = Convert.ToString(sdr["HTTK_THIS"]);
            node.JE_THIS = Convert.ToDecimal(sdr["JE_THIS"]);
            node.JEXG_THIS = Convert.ToDecimal(sdr["JEXG_THIS"]);
            node.FYL_THIS = Convert.ToDecimal(sdr["FYL_THIS"]);
            node.WSJE_THIS = Convert.ToDecimal(sdr["WSJE_THIS"]);
            node.WSJEXG_THIS = Convert.ToDecimal(sdr["WSJEXG_THIS"]);
            node.SL_THIS = Convert.ToInt32(sdr["SL_THIS"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");


            node.YHXJE = Convert.ToDecimal(sdr["YHXJE"]);

            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            node.SL_LASTDES = Convert.ToString(sdr["SL_LASTDES"]);
            node.SL_THISDES = Convert.ToString(sdr["SL_THISDES"]);
            return node;
        }


    }
}
