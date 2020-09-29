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
    public class COST_LKAFYMXDT : ICOST_LKAFYMXDT
    {
        private const string SQL_Create = "CRM_COST_LKAFYMXDT_Create";
        private const string SQL_Update = "CRM_COST_LKAFYMXDT_Update";
        private const string SQL_ReadByParam = "CRM_COST_LKAFYMXDT_ReadByParam";
        private const string SQL_Delete = "CRM_COST_LKAFYMXDT_Delete";
        private const string SQL_Read_Unconnected = "CRM_COST_LKAFYMXDT_Read_Unconnected";

        public int Create(CRM_COST_LKAFYMXDT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAFYTTID", model.LKAFYTTID),
                                        new SqlParameter("@CXLX", model.CXLX),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@CXFY", model.CXFY),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_LKAFYMXDT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKADTMXID", model.LKADTMXID),
                                        new SqlParameter("@LKAFYTTID", model.LKAFYTTID),
                                        new SqlParameter("@CXLX", model.CXLX),
                                        new SqlParameter("@CXFY", model.CXFY),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@HXR", model.HXR)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_COST_LKAFYMXDT> ReadByParam(CRM_COST_LKAFYMXDT model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@LKAFYTTID", model.LKAFYTTID),
                                       new SqlParameter("@LKADTMXID", model.LKADTMXID),
                                       new SqlParameter("@CXLX", model.CXLX),
                                       new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                       new SqlParameter("@ISACTIVE", model.ISACTIVE)


                                   };
            IList<CRM_COST_LKAFYMXDT> nodes = new List<CRM_COST_LKAFYMXDT>();
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

        public IList<CRM_COST_LKAFYMXDT> Read_Unconnected(CRM_COST_LKAFYMXDT model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                       new SqlParameter("@TT_FYLB", model.TT_FYLB),
                                       new SqlParameter("@TT_HTYEAR", model.TT_HTYEAR),
                                       new SqlParameter("@TT_LKAID", model.TT_LKAID)

                                   };
            IList<CRM_COST_LKAFYMXDT> nodes = new List<CRM_COST_LKAFYMXDT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_Unconnected, parms))
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


        public int Delete(int LKADTMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKADTMXID", LKADTMXID)
                                       

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

        private CRM_COST_LKAFYMXDT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAFYMXDT node = new CRM_COST_LKAFYMXDT();
            node.LKADTMXID = Convert.ToInt32(sdr["LKADTMXID"]);
            node.LKAFYTTID = Convert.ToInt32(sdr["LKAFYTTID"]);
            node.CXLX = Convert.ToInt32(sdr["CXLX"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.CXFY = Convert.ToDouble(sdr["CXFY"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.HXR = Convert.ToInt32(sdr["HXR"]);
            node.HXSJ = Convert.ToDateTime(sdr["HXSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.CXLXDES = Convert.ToString(sdr["CXLXDES"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            node.HXRNAME = Convert.ToString(sdr["HXRNAME"]);
            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);

            return node;
        }


        private CRM_COST_LKAFYMXDT ReadDataToObj2(SqlDataReader sdr)
        {
            CRM_COST_LKAFYMXDT node = new CRM_COST_LKAFYMXDT();
            node.LKADTMXID = Convert.ToInt32(sdr["LKADTMXID"]);
            node.LKAFYTTID = Convert.ToInt32(sdr["LKAFYTTID"]);
            node.CXLX = Convert.ToInt32(sdr["CXLX"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.CXFY = Convert.ToDouble(sdr["CXFY"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.HXR = Convert.ToInt32(sdr["HXR"]);
            node.HXSJ = Convert.ToDateTime(sdr["HXSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            //node.CXLXDES = Convert.ToString(sdr["CXLXDES"]);
            //node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            //node.HXRNAME = Convert.ToString(sdr["HXRNAME"]);
            node.TT_HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.TT_FYLB = Convert.ToInt32(sdr["FYLB"]);

            node.CJHDMDSL = Convert.ToInt32(sdr["CJHDMDSL"]);
            node.HDBEGINDATE = Convert.ToString(sdr["HDBEGINDATE"]);
            node.HDENDDATE = Convert.ToString(sdr["HDENDDATE"]);
            node.KHTHBEGINDATE = Convert.ToString(sdr["KHTHBEGINDATE"]);
            node.KHTHENDDATE = Convert.ToString(sdr["KHTHENDDATE"]);
            node.DP1 = Convert.ToString(sdr["DP1"]);
            node.DP2 = Convert.ToString(sdr["DP2"]);
            node.CCJ = Convert.ToDouble(sdr["CCJ"]);
            node.ZCGJ = Convert.ToDouble(sdr["ZCGJ"]);
            node.CXGJ = Convert.ToDouble(sdr["CXGJ"]);
            node.ZCSJ = Convert.ToDouble(sdr["ZCSJ"]);
            node.CXSJ = Convert.ToDouble(sdr["CXSJ"]);
            node.DPYJXS = Convert.ToDouble(sdr["DPYJXS"]);
            node.YJHDQJXS = Convert.ToDouble(sdr["YJHDQJXS"]);
            node.SQZJE = Convert.ToDouble(sdr["SQZJE"]);
            node.YJFB = Convert.ToDouble(sdr["YJFB"]);
            node.HDFASM = Convert.ToString(sdr["HDFASM"]);
            return node;
        }





    }
}
