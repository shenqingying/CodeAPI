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
    public class COST_TSMX : ICOST_TSMX
    {
        private const string SQL_Create = "CRM_COST_TSMX_Create";
        private const string SQL_Update = "CRM_COST_TSMX_Update";
        private const string SQL_ReadByParam = "CRM_COST_TSMX_ReadByParam";
        private const string SQL_Delete = "CRM_COST_TSMX_Delete";


        public int Create(CRM_COST_TSMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TSID", model.TSID),
                                        new SqlParameter("@CPXL", model.CPXL),
                                        new SqlParameter("@CPXH", model.CPXH),
                                        new SqlParameter("@CPXHMS", model.CPXHMS),
                                        new SqlParameter("@BLPSL", model.BLPSL),
                                        new SqlParameter("@RQM", model.RQM),
                                        new SqlParameter("@REASON", model.REASON),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR),
                                       
                                       
                                    
                                      
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_TSMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TSID", model.TSID),
                                        new SqlParameter("@CPXL", model.CPXL),
                                        new SqlParameter("@CPXH", model.CPXH),
                                        new SqlParameter("@CPXHMS", model.CPXHMS),
                                        new SqlParameter("@BLPSL", model.BLPSL),
                                        new SqlParameter("@RQM", model.RQM),
                                        new SqlParameter("@REASON", model.REASON),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@TSMXID", model.TSMXID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_TSMX> ReadByParam(CRM_COST_TSMX model)
        {
            SqlParameter[] parms = {  
                                        new SqlParameter("@TSMXID", model.TSMXID),
                                        new SqlParameter("@TSID", model.TSID),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)
                                   };
            IList<CRM_COST_TSMX> nodes = new List<CRM_COST_TSMX>();
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

        public int Delete(int TSMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TSMXID", TSMXID)
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


        private CRM_COST_TSMX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_TSMX node = new CRM_COST_TSMX();
            node.TSMXID = Convert.ToInt32(sdr["TSMXID"]);
            node.TSID = Convert.ToInt32(sdr["TSID"]);
            node.CPXL = Convert.ToInt32(sdr["CPXL"]);
            node.CPXH = Convert.ToInt32(sdr["CPXH"]);
            node.BLPSL = Convert.ToInt32(sdr["BLPSL"]);
            node.RQM = Convert.ToString(sdr["RQM"]);
            node.REASON = Convert.ToString(sdr["REASON"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.CPXLDES = Convert.ToString(sdr["CPXLDES"]);
            node.CPXHDES = Convert.ToString(sdr["CPXHDES"]);
            node.CPXHMS = Convert.ToString(sdr["CPXHMS"]);
           
            return node;
        }
    }
}
