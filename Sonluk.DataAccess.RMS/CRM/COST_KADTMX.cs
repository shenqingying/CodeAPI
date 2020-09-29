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
    public class COST_KADTMX : ICOST_KADTMX
    {
        private const string SQL_Create = "CRM_COST_KADTMX_Create";
        private const string SQL_Update = "CRM_COST_KADTMX_Update";
        private const string SQL_ReadByParam = "CRM_COST_KADTMX_ReadByParam";
        private const string SQL_Delete = "CRM_COST_KADTMX_Delete";

        private const string SQL_Create_CONN = "CRM_COST_KADTMX_KAHXDJMX_Create";
        private const string SQL_DeleteByHXDJMXID_CONN = "CRM_COST_KADTMX_KAHXDJMX_DeleteByHXDJMXID";
        private const string SQL_Read_Unconnected_CONN = "CRM_COST_KADTMX_KAHXDJMX_Read_Unconnected";

        public int Create(CRM_COST_KADTMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KADTTTID", model.KADTTTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@CXLX", model.CXLX),
                                        new SqlParameter("@FYJE", model.FYJE),
                                        new SqlParameter("@CJHDMDSL", model.CJHDMDSL),
                                        new SqlParameter("@PROMISE", model.PROMISE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_KADTMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KADTMXID", model.KADTMXID),
                                        new SqlParameter("@CXLX", model.CXLX),
                                        new SqlParameter("@FYJE", model.FYJE),
                                        new SqlParameter("@CJHDMDSL", model.CJHDMDSL),
                                        new SqlParameter("@PROMISE", model.PROMISE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@SJXS", model.SJXS),
                                        new SqlParameter("@SJFY", model.SJFY),
                                        new SqlParameter("@HDJSZJ", model.HDJSZJ),
                                        new SqlParameter("@BEIZ2", model.BEIZ2)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_KADTMX> ReadByParam(CRM_COST_KADTMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KADTMXID", model.KADTMXID),
                                        new SqlParameter("@KADTTTID", model.KADTTTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@CXLX", model.CXLX)

                                   };
            IList<CRM_COST_KADTMX> nodes = new List<CRM_COST_KADTMX>();
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
        public int Delete(int KADTMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KADTMXID", KADTMXID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }


        public int Create_CONN(COST_KADTMX_KAHXDJMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJMXID", model.HXDJMXID),
                                        new SqlParameter("@KADTMXID", model.KADTMXID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create_CONN, parms);
        }

        public int DeleteByHXDJMXID_CONN(int HXDJMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJMXID", HXDJMXID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteByHXDJMXID_CONN, parms);
        }

        public IList<CRM_COST_KADTMX> Read_Unconnected_CONN(CRM_COST_KADTMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                       new SqlParameter("@TT_HTYEAR", model.TT_HTYEAR),
                                       new SqlParameter("@TT_KHID", model.TT_KHID)


                                   };
            IList<CRM_COST_KADTMX> nodes = new List<CRM_COST_KADTMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_Unconnected_CONN, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj_Unconnected(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
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

        private CRM_COST_KADTMX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_KADTMX node = new CRM_COST_KADTMX();
            node.KADTMXID = Convert.ToInt32(sdr["KADTMXID"]);
            node.KADTTTID = Convert.ToInt32(sdr["KADTTTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.CXLX = Convert.ToInt32(sdr["CXLX"]);
            node.FYJE = Convert.ToDecimal(sdr["FYJE"]);
            node.CJHDMDSL = Convert.ToInt32(sdr["CJHDMDSL"]);
            node.PROMISE = Convert.ToInt32(sdr["PROMISE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.SJXS = Convert.ToDecimal(sdr["SJXS"]);
            node.SJFY = Convert.ToDecimal(sdr["SJFY"]);
            node.HDJSZJ = Convert.ToString(sdr["HDJSZJ"]);
            node.BEIZ2 = Convert.ToString(sdr["BEIZ2"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.CXLXDES = Convert.ToString(sdr["CXLXDES"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);


            return node;
        }

        private CRM_COST_KADTMX ReadDataToObj_Unconnected(SqlDataReader sdr)
        {
            CRM_COST_KADTMX node = new CRM_COST_KADTMX();
            node.KADTMXID = Convert.ToInt32(sdr["KADTMXID"]);
            node.KADTTTID = Convert.ToInt32(sdr["KADTTTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.CXLX = Convert.ToInt32(sdr["CXLX"]);
            node.FYJE = Convert.ToDecimal(sdr["FYJE"]);
            node.CJHDMDSL = Convert.ToInt32(sdr["CJHDMDSL"]);
            node.PROMISE = Convert.ToInt32(sdr["PROMISE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.SJXS = Convert.ToDecimal(sdr["SJXS"]);
            node.SJFY = Convert.ToDecimal(sdr["SJFY"]);
            node.HDJSZJ = Convert.ToString(sdr["HDJSZJ"]);
            node.BEIZ2 = Convert.ToString(sdr["BEIZ2"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.HDBEGINDATE = Convert.ToString(sdr["HDBEGINDATE"]);
            node.HDENDDATE = Convert.ToString(sdr["HDENDDATE"]);
            node.DQ = Convert.ToString(sdr["DQ"]);
            node.YHXJE = Convert.ToDecimal(sdr["YHXJE"]);

            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.CXLXDES = Convert.ToString(sdr["CXLXDES"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);


            return node;
        }




    }
}
