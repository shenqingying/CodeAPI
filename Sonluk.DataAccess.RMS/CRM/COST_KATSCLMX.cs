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
    public class COST_KATSCLMX : ICOST_KATSCLMX
    {
        private const string SQL_Create = "CRM_COST_KATSCLMX_Create";
        private const string SQL_Update = "CRM_COST_KATSCLMX_Update";
        private const string SQL_ReadByParam = "CRM_COST_KATSCLMX_ReadByParam";
        private const string SQL_Delete = "CRM_COST_KATSCLMX_Delete";
        private const string SQL_Read_Unconnected = "CRM_COST_KATSCLMX_Read_Unconnected";

        private const string SQL_Create_CONN = "CRM_COST_KATSCLMX_KAHXDJMX_Create";
        //private const string SQL_ReadByParam_CONN = "CRM_COST_KATSCLMX_KAHXDJMX_ReadByParam";
        private const string SQL_DeleteByHXDJMXID_CONN = "CRM_COST_KATSCLMX_KAHXDJMX_DeleteByHXDJMXID";
        private const string SQL_Read_Unconnected_CONN = "CRM_COST_KATSCLMX_KAHXDJMX_Read_Unconnected";

        public int Create(CRM_COST_KATSCLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KATSCLTTID", model.KATSCLTTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@CLFS", model.CLFS),
                                        new SqlParameter("@FYJE", model.FYJE),
                                        new SqlParameter("@YJXS", model.YJXS),
                                        new SqlParameter("@YJFB", model.YJFB),
                                        new SqlParameter("@RCYJXS", model.RCYJXS),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_KATSCLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KATSCLMXID", model.KATSCLMXID),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@CLFS", model.CLFS),
                                        new SqlParameter("@FYJE", model.FYJE),
                                        new SqlParameter("@YJXS", model.YJXS),
                                        new SqlParameter("@YJFB", model.YJFB),
                                        new SqlParameter("@RCYJXS", model.RCYJXS),
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

        public IList<CRM_COST_KATSCLMX> ReadByParam(CRM_COST_KATSCLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KATSCLMXID", model.KATSCLMXID),
                                        new SqlParameter("@KATSCLTTID", model.KATSCLTTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@CX_BEGIN", model.CX_BEGIN),
                                        new SqlParameter("@CX_END", model.CX_END),
                                        new SqlParameter("@CX_MC", model.CX_MC),
                                        new SqlParameter("@CX_CRMID", model.CX_CRMID),
                                        new SqlParameter("@CX_ISACTIVE", model.CX_ISACTIVE),
                                        new SqlParameter("@CX_CLFS", model.CX_CLFS),


                                   };
            IList<CRM_COST_KATSCLMX> nodes = new List<CRM_COST_KATSCLMX>();
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

        public IList<CRM_COST_KATSCLMX> Read_Unconnected(CRM_COST_KATSCLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                       new SqlParameter("@TT_HTYEAR", model.TT_HTYEAR),
                                       new SqlParameter("@TT_KHID", model.TT_KHID)


                                   };
            IList<CRM_COST_KATSCLMX> nodes = new List<CRM_COST_KATSCLMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_Unconnected, parms))
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

        public int Delete(int KATSCLMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KATSCLMXID", KATSCLMXID)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }



        public int Create_CONN(COST_KATSCLMX_KAHXDJMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJMXID", model.HXDJMXID),
                                        new SqlParameter("@KATSCLMXID", model.KATSCLMXID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create_CONN, parms);
        }

        //public IList<COST_KATSCLMX_KAHXDJMX> ReadByParam_CONN(COST_KATSCLMX_KAHXDJMX model)
        //{
        //    SqlParameter[] parms = {
        //                                new SqlParameter("@HXDJMXID", model.HXDJMXID),
        //                                new SqlParameter("@KATSCLMXID", model.KATSCLMXID)

        //                           };
        //    IList<COST_KATSCLMX_KAHXDJMX> nodes = new List<COST_KATSCLMX_KAHXDJMX>();
        //    try
        //    {
        //        using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParam_CONN, parms))
        //        {
        //            while (sdr.Read())
        //            {
        //                nodes.Add(ReadDataToObj(sdr));
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        throw new ApplicationException(e.Message);
        //    }
        //    return nodes;
        //}

        public IList<CRM_COST_KATSCLMX> Read_Unconnected_CONN(CRM_COST_KATSCLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                       new SqlParameter("@TT_HTYEAR", model.TT_HTYEAR),
                                       new SqlParameter("@TT_KHID", model.TT_KHID)


                                   };
            IList<CRM_COST_KATSCLMX> nodes = new List<CRM_COST_KATSCLMX>();
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

        public int DeleteByHXDJMXID(int HXDJMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXDJMXID", HXDJMXID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteByHXDJMXID_CONN, parms);
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

        private CRM_COST_KATSCLMX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_KATSCLMX node = new CRM_COST_KATSCLMX();
            node.KATSCLMXID = Convert.ToInt32(sdr["KATSCLMXID"]);
            node.KATSCLTTID = Convert.ToInt32(sdr["KATSCLTTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.BEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
            node.ENDDATE = Convert.ToString(sdr["ENDDATE"]);
            node.CLFS = Convert.ToInt32(sdr["CLFS"]);
            node.FYJE = Convert.ToDecimal(sdr["FYJE"]);
            node.YJXS = Convert.ToDecimal(sdr["YJXS"]);
            node.YJFB = Convert.ToDecimal(sdr["YJFB"]);
            node.RCYJXS = Convert.ToDecimal(sdr["RCYJXS"]);
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


            node.MC = Convert.ToString(sdr["MC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.CLFSDES = Convert.ToString(sdr["CLFSDES"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            return node;
        }

        private CRM_COST_KATSCLMX ReadDataToObj_Unconnected(SqlDataReader sdr)
        {
            CRM_COST_KATSCLMX node = new CRM_COST_KATSCLMX();
            node.KATSCLMXID = Convert.ToInt32(sdr["KATSCLMXID"]);
            node.KATSCLTTID = Convert.ToInt32(sdr["KATSCLTTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.BEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
            node.ENDDATE = Convert.ToString(sdr["ENDDATE"]);
            node.CLFS = Convert.ToInt32(sdr["CLFS"]);
            node.FYJE = Convert.ToDecimal(sdr["FYJE"]);
            node.YJXS = Convert.ToDecimal(sdr["YJXS"]);
            node.YJFB = Convert.ToDecimal(sdr["YJFB"]);
            node.RCYJXS = Convert.ToDecimal(sdr["RCYJXS"]);
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
            node.YHXJE = Convert.ToDecimal(sdr["YHXJE"]);


            node.MC = Convert.ToString(sdr["MC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.CLFSDES = Convert.ToString(sdr["CLFSDES"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            return node;
        }



    }
}
