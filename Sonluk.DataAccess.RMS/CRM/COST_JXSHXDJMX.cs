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
    public class COST_JXSHXDJMX : ICOST_JXSHXDJMX
    {
        private const string SQL_Create = "CRM_COST_JXSHXDJMX_Create";
        private const string SQL_Update = "CRM_COST_JXSHXDJMX_Update";
        private const string SQL_ReadByParam = "CRM_COST_JXSHXDJMX_ReadByParam";
        private const string SQL_Delete = "CRM_COST_JXSHXDJMX_Delete";



        public int Create(CRM_COST_JXSHXDJMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJTTID", model.HXDJTTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@FYHXXS", model.FYHXXS),
                                        new SqlParameter("@CWHSBH", model.CWHSBH),
                                        new SqlParameter("@CBZXBH", model.CBZXBH),
                                        new SqlParameter("@HXJE", model.HXJE),
                                        new SqlParameter("@SL", model.SL),
                                        new SqlParameter("@WSJE", model.WSJE),
                                        new SqlParameter("@HXRQ", model.HXRQ),
                                  
                                       
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR),
                                
                                    
                                      
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_JXSHXDJMX model)
        {
            SqlParameter[] parms = {
                                          new SqlParameter("@HXDJTTID", model.HXDJTTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@FYHXXS", model.FYHXXS),
                                        new SqlParameter("@CWHSBH", model.CWHSBH),
                                        new SqlParameter("@CBZXBH", model.CBZXBH),
                                        new SqlParameter("@HXJE", model.HXJE),
                                        new SqlParameter("@SL", model.SL),
                                        new SqlParameter("@WSJE", model.WSJE),
                                        new SqlParameter("@HXRQ", model.HXRQ),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE), 
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@HXDJMXID", model.HXDJMXID),
                                   };
                                  
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }



        public IList<CRM_COST_JXSHXDJMX> ReadByParam(CRM_COST_JXSHXDJMX model)
        {
            SqlParameter[] parms = {  
                                       new SqlParameter("@HXDJMXID", model.HXDJMXID),
                                        new SqlParameter("@HXDJTTID", model.HXDJTTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                      
                                        
                                   };
            IList<CRM_COST_JXSHXDJMX> nodes = new List<CRM_COST_JXSHXDJMX>();
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



        public int Delete(int HXDJMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJMXID", HXDJMXID)
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


        private CRM_COST_JXSHXDJMX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_JXSHXDJMX node = new CRM_COST_JXSHXDJMX();
            node.HXDJMXID = Convert.ToInt32(sdr["HXDJMXID"]);
            node.HXDJTTID = Convert.ToInt32(sdr["HXDJTTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.BEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
            node.ENDDATE = Convert.ToString(sdr["ENDDATE"]);
            node.FYHXXS = Convert.ToInt32(sdr["FYHXXS"]);
            node.CWHSBH = Convert.ToString(sdr["CWHSBH"]);
            node.CBZXBH = Convert.ToString(sdr["CBZXBH"]);
            node.HXJE = Convert.ToDouble(sdr["HXJE"]);
            node.SL = Convert.ToInt32(sdr["SL"]);
            node.WSJE = Convert.ToDouble(sdr["WSJE"]);
            node.HXRQ = Convert.ToString(sdr["HXRQ"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.FYHXXSDES = Convert.ToString(sdr["FYHXXSDES"]);
            node.CWHSBHDES = Convert.ToString(sdr["CWHSBHDES"]);
            node.CBZXBHDES = Convert.ToString(sdr["CBZXBHDES"]);
            node.SLDES = Convert.ToString(sdr["SLDES"]);
      
            return node;
        }
    }
}
