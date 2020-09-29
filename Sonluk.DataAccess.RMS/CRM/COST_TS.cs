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
    public class COST_TS : ICOST_TS
    {
        private const string SQL_Create = "CRM_COST_TS_Create";
        private const string SQL_Update = "CRM_COST_TS_Update";
        private const string SQL_ReadByParam = "CRM_COST_TS_ReadByParam";
        private const string SQL_Delete = "CRM_COST_TS_Delete";

        public int Create(CRM_COST_TS model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SOURCE", model.SOURCE),
                                        new SqlParameter("@TSXX", model.TSXX),
                                        new SqlParameter("@DAMAGE", model.DAMAGE),
                                        new SqlParameter("@PRICE", model.PRICE),
                                        new SqlParameter("@GG", model.GG),
                                        new SqlParameter("@REASON", model.REASON),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@YWY", model.YWY),
                                        new SqlParameter("@FGLD", model.FGLD),
                                        new SqlParameter("@KHYQ", model.KHYQ),
                                        new SqlParameter("@FCSJ", model.FCSJ),
                                        new SqlParameter("@WLXX", model.WLXX),
                                        new SqlParameter("@JS", model.JS),
                                        new SqlParameter("@TSSFYX", model.TSSFYX),
                                        new SqlParameter("@TSJG", model.TSJG),
                                        new SqlParameter("@TSFKSJ", model.TSFKSJ),
                                        new SqlParameter("@KDDH", model.KDDH),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR),
                                        new SqlParameter("@KHDZ", model.KHDZ),
                                        new SqlParameter("@LXDH", model.LXDH)
                                    
                                      
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_TS model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SOURCE", model.SOURCE),
                                        new SqlParameter("@TSXX", model.TSXX),
                                        new SqlParameter("@DAMAGE", model.DAMAGE),
                                        new SqlParameter("@PRICE", model.PRICE),
                                        new SqlParameter("@GG", model.GG),
                                        new SqlParameter("@REASON", model.REASON),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@YWY", model.YWY),
                                        new SqlParameter("@FGLD", model.FGLD),
                                        new SqlParameter("@KHYQ", model.KHYQ),
                                        new SqlParameter("@FCSJ", model.FCSJ),
                                        new SqlParameter("@WLXX", model.WLXX),
                                        new SqlParameter("@JS", model.JS),
                                        new SqlParameter("@TSSFYX", model.TSSFYX),
                                        new SqlParameter("@TSJG", model.TSJG),
                                        new SqlParameter("@TSFKSJ", model.TSFKSJ),
                                        new SqlParameter("@KDDH", model.KDDH),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),                                
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@TSID", model.TSID),
                                        new SqlParameter("@KHDZ", model.KHDZ),
                                        new SqlParameter("@LXDH", model.LXDH)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_TS> ReadByParam(CRM_COST_TS model, int CURRENTID)
        {
            SqlParameter[] parms = {  
                                       new SqlParameter("@TSID", model.TSID),
                                       new SqlParameter("@SOURCE", model.SOURCE),
                                       new SqlParameter("@FGLD", model.FGLD),
                                       new SqlParameter("@MC", model.MC),
                                       new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                       new SqlParameter("@CURRENTID", model.CURRENTID),
                                       new SqlParameter("@NUM", model.NUM),
                                       new SqlParameter("@STAFFID", model.STAFFID),
                                       new SqlParameter("@NAME", model.NAME),
                                   };
            IList<CRM_COST_TS> nodes = new List<CRM_COST_TS>();
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

        public int Delete(int TSID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TSID", TSID)
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


        private CRM_COST_TS ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_TS node = new CRM_COST_TS();
            node.TSID = Convert.ToInt32(sdr["TSID"]);
            node.SOURCE = Convert.ToInt32(sdr["SOURCE"]);
            node.TSXX = Convert.ToString(sdr["TSXX"]);
            node.DAMAGE = Convert.ToInt32(sdr["DAMAGE"]);
            node.PRICE = Convert.ToDouble(sdr["PRICE"]);
            node.GG = Convert.ToString(sdr["GG"]);
            node.REASON = Convert.ToString(sdr["REASON"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.YWY = Convert.ToInt32(sdr["YWY"]);
            node.FGLD = Convert.ToInt32(sdr["FGLD"]);
            node.KHYQ = Convert.ToString(sdr["KHYQ"]);
            node.FCSJ = Convert.ToString(sdr["FCSJ"]);
            node.WLXX = Convert.ToInt32(sdr["WLXX"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.JS = Convert.ToInt32(sdr["JS"]);
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            node.TSSFYX = Convert.ToInt32(sdr["TSSFYX"]);
            node.TSJG = Convert.ToString(sdr["TSJG"]);
            node.TSFKSJ = Convert.ToString(sdr["TSFKSJ"]);
            node.KDDH = Convert.ToString(sdr["KDDH"]);
            node.MCNAME = Convert.ToString(sdr["MCNAME"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.FGLDDES = Convert.ToString(sdr["FGLDDES"]);
            node.GSLXDH = Convert.ToString(sdr["GSLXDH"]);
            node.MDDZ = Convert.ToString(sdr["MDDZ"]);
            node.SOURCEDES = Convert.ToString(sdr["SOURCEDES"]);
            node.WLXXDES = Convert.ToString(sdr["WLXXDES"]);
            node.LXDH = Convert.ToString(sdr["LXDH"]);
            node.KHDZ = Convert.ToString(sdr["KHDZ"]);
            return node;
        }
    }
}
