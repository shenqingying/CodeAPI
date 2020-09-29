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
    public class COST_LKAHXZLMX : ICOST_LKAHXZLMX
    {
        private const string SQL_Create = "CRM_COST_LKAHXZLMX_Create";
        private const string SQL_Update = "CRM_COST_LKAHXZLMX_Update";
        private const string SQL_ReadByParam = "CRM_COST_LKAHXZLMX_ReadByParam";
        private const string SQL_ReadByTTID = "CRM_COST_LKAHXZLMX_ReadByTTID";
        private const string SQL_Delete = "CRM_COST_LKAHXZLMX_Delete";
        private const string SQL_ReadMXinfo = "CRM_COST_LKAHXZLMX_ReadMXinfo";
        private const string SQL_Read_Unconnected = "CRM_COST_LKAHXZLMX_Read_Unconnected";
        private const string SQL_DeleteByLKAFYTTID = "CRM_COST_LKAHXZLMX_DeleteByLKAFYTTID";
        private const string SQL_Read_CostTime = "CRM_COST_LKAHXZLMX_Read_CostTime";

        public int Create(CRM_COST_LKAHXZLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLTTID", model.HXZLTTID),
                                        new SqlParameter("@LKAFYTTID", model.LKAFYTTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@FYSPJE", model.FYSPJE),
                                        new SqlParameter("@FYYHXJE", model.FYYHXJE),
                                        new SqlParameter("@FYBCSQJE", model.FYBCSQJE),
                                        new SqlParameter("@SQZJE", model.SQZJE),
                                        new SqlParameter("@MCHTQK", model.MCHTQK),
                                        new SqlParameter("@MCHTTK", model.MCHTTK),
                                        new SqlParameter("@MCHTJE", model.MCHTJE),
                                        new SqlParameter("@CSKKFP", model.CSKKFP),
                                        new SqlParameter("@CSKKFPDY", model.CSKKFPDY),
                                        new SqlParameter("@SFYHBYJ", model.SFYHBYJ),
                                        new SqlParameter("@FYHXYHCNR", model.FYHXYHCNR),
                                        new SqlParameter("@SJXS", model.SJXS),
                                        new SqlParameter("@SJFB", model.SJFB),
                                        new SqlParameter("@HDJSZJ", model.HDJSZJ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@QKSM", model.QKSM),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@CJR", model.CJR),


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_LKAHXZLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLMXID", model.HXZLMXID),
                                        new SqlParameter("@FYSPJE", model.FYSPJE),
                                        new SqlParameter("@FYYHXJE", model.FYYHXJE),
                                        new SqlParameter("@FYBCSQJE", model.FYBCSQJE),
                                        new SqlParameter("@MCHTQK", model.MCHTQK),
                                        new SqlParameter("@MCHTTK", model.MCHTTK),
                                        new SqlParameter("@MCHTJE", model.MCHTJE),
                                        new SqlParameter("@CSKKFP", model.CSKKFP),
                                        new SqlParameter("@CSKKFPDY", model.CSKKFPDY),
                                        new SqlParameter("@SFYHBYJ", model.SFYHBYJ),
                                        new SqlParameter("@FYHXYHCNR", model.FYHXYHCNR),
                                        new SqlParameter("@SJXS", model.SJXS),
                                        new SqlParameter("@SJFB", model.SJFB),
                                        new SqlParameter("@HDJSZJ", model.HDJSZJ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@QKSM", model.QKSM),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@SHR", model.SHR),



                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_COST_LKAHXZLMX> ReadByParam(CRM_COST_LKAHXZLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLMXID", model.HXZLMXID),
                                        new SqlParameter("@HXZLTTID", model.HXZLTTID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@LKAFYTTID", model.LKAFYTTID),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@COSTITEMIDSTR", model.COSTITEMIDSTR)


                                   };
            IList<CRM_COST_LKAHXZLMX> nodes = new List<CRM_COST_LKAHXZLMX>();
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

        public IList<CRM_COST_LKAHXZLMX> ReadByTTID(int HXZLTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLTTID", HXZLTTID)


                                   };
            IList<CRM_COST_LKAHXZLMX> nodes = new List<CRM_COST_LKAHXZLMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByTTID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadUnconnectedDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public CRM_COST_LKAHXZLMX ReadMXinfo(CRM_COST_LKAHXZLMX model, string HTYEAR, int LKAID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@HTYEAR", HTYEAR),
                                        new SqlParameter("@LKAID", LKAID)


                                   };
            CRM_COST_LKAHXZLMX nodes = new CRM_COST_LKAHXZLMX();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadMXinfo, parms))
                {
                    if (sdr.Read())
                    {
                        nodes = ReadDataToObj2(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        public IList<CRM_COST_LKAHXZLMX> Read_Unconnected(CRM_COST_LKAHXZLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@TT_HTYEAR", model.TT_HTYEAR),
                                        new SqlParameter("@TT_LKAID", model.TT_LKAID)


                                   };
            IList<CRM_COST_LKAHXZLMX> nodes = new List<CRM_COST_LKAHXZLMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_Unconnected, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadUnconnectedDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        public CRM_COST_LKAHXZLMX Read_CostTime(CRM_COST_LKAHXZLMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLMXID", model.HXZLMXID),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID)


                                   };
            CRM_COST_LKAHXZLMX nodes = new CRM_COST_LKAHXZLMX();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_CostTime, parms))
                {
                    if (sdr.Read())
                    {
                        nodes = ReadTimeToObj(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        public int Delete(int HXZLMXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HXZLMXID", HXZLMXID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }

        public int DeleteByLKAFYTTID(int LKAFYTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAFYTTID", LKAFYTTID)
                                       
                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteByLKAFYTTID, parms);
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

        private CRM_COST_LKAHXZLMX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAHXZLMX node = new CRM_COST_LKAHXZLMX();
            node.HXZLMXID = Convert.ToInt32(sdr["HXZLMXID"]);
            node.HXZLTTID = Convert.ToInt32(sdr["HXZLTTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.LKAFYTTID = Convert.ToInt32(sdr["LKAFYTTID"]);
            node.FYSPJE = Convert.ToDouble(sdr["FYSPJE"]);
            node.FYYHXJE = Convert.ToDouble(sdr["FYYHXJE"]);
            node.FYBCSQJE = Convert.ToDouble(sdr["FYBCSQJE"]);
            node.SQZJE = Convert.ToDouble(sdr["SQZJE"]);
            node.MCHTQK = Convert.ToInt32(sdr["MCHTQK"]);
            node.MCHTTK = Convert.ToString(sdr["MCHTTK"]);
            node.MCHTJE = Convert.ToDouble(sdr["MCHTJE"]);
            node.CSKKFP = Convert.ToInt32(sdr["CSKKFP"]);
            node.CSKKFPDY = Convert.ToInt32(sdr["CSKKFPDY"]);
            node.SFYHBYJ = Convert.ToInt32(sdr["SFYHBYJ"]);
            node.FYHXYHCNR = Convert.ToString(sdr["FYHXYHCNR"]);
            node.SJXS = Convert.ToDouble(sdr["SJXS"]);
            node.SJFB = Convert.ToDouble(sdr["SJFB"]);
            node.HDJSZJ = Convert.ToString(sdr["HDJSZJ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.QKSM = Convert.ToString(sdr["QKSM"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.SHR = Convert.ToInt32(sdr["SHR"]);
            node.SHSJ = Convert.ToDateTime(sdr["SHSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.MCHTQKDES = Convert.ToString(sdr["MCHTQKDES"]);
            node.CSKKFPDES = Convert.ToString(sdr["CSKKFPDES"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            node.SHRNAME = Convert.ToString(sdr["SHRNAME"]);
            if (node.COSTITEMID == 11 || node.COSTITEMID == 12 || node.COSTITEMID == 10 || node.COSTITEMID == 14 || node.COSTITEMID == 13)
            {
                //在核销资料明细界面需要带出对应费用的具体信息
                node.COSTID = Convert.ToInt32(sdr["COSTID"]);
                node.SQJE = Convert.ToDouble(sdr["SQJE"]);


                if (node.COSTITEMID == 10)
                {
                    //特殊陈列
                    node.MDID = Convert.ToInt32(sdr["MDID"]);
                    node.MDMC = Convert.ToString(sdr["MDMC"]);
                    node.Display2ImgCount = Convert.ToInt32(sdr["Display2ImgCount"]);
                    node.HDBEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
                    node.HDENDDATE = Convert.ToString(sdr["ENDDATE"]);
                    node.CLFSDES = Convert.ToString(sdr["CLFSDES"]);
                    node.SQFYJE = Convert.ToDouble(sdr["SQFYJE"]);
                    node.YJXS = Convert.ToDouble(sdr["YJXS"]);
                    node.YJFB = Convert.ToDouble(sdr["YJFB"]);
                }
                if (node.COSTITEMID == 11 || node.COSTITEMID == 12 || node.COSTITEMID == 13)
                {
                    //海报堆头&其他费用
                    node.XSHJ = Convert.ToDouble(sdr["XSHJ"]);

                    node.CJHDMDSL = Convert.ToInt32(sdr["CJHDMDSL"]);
                    node.HDBEGINDATE = Convert.ToString(sdr["HDBEGINDATE"]);
                    node.HDENDDATE = Convert.ToString(sdr["HDENDDATE"]);
                    node.KHTHBEGINDATE = Convert.ToString(sdr["KHTHBEGINDATE"]);
                    node.KHTHENDDATE = Convert.ToString(sdr["KHTHENDDATE"]);
                    node.DP1DES = Convert.ToString(sdr["DP1DES"]);
                    node.DP2DES = Convert.ToString(sdr["DP2DES"]);
                    node.CCJ = Convert.ToDouble(sdr["CCJ"]);
                    node.ZCGJ = Convert.ToDouble(sdr["ZCGJ"]);
                    node.CXGJ = Convert.ToDouble(sdr["CXGJ"]);
                    node.ZCSJ = Convert.ToDouble(sdr["ZCSJ"]);
                    node.CXSJ = Convert.ToDouble(sdr["CXSJ"]);
                    node.DPYJXS = Convert.ToDouble(sdr["DPYJXS"]);
                    node.YJXS = Convert.ToDouble(sdr["YJHDQJXS"]);
                    node.YJFB = Convert.ToDouble(sdr["YJFB"]);
                    node.HDFASM = Convert.ToString(sdr["HDFASM"]);
                }
                if (node.COSTITEMID == 14)
                {
                    //制作费
                    node.MDMC = Convert.ToString(sdr["MDMC"]);
                    node.ZZLXDES = Convert.ToString(sdr["ZZLXDES"]);
                    node.MDCRMID = Convert.ToString(sdr["MDCRMID"]);
                }
            }

            return node;
        }


        private CRM_COST_LKAHXZLMX ReadDataToObj2(SqlDataReader sdr)
        {
            CRM_COST_LKAHXZLMX node = new CRM_COST_LKAHXZLMX();
            node.COSTID = Convert.ToInt32(sdr["COSTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.FYSPJE = Convert.ToDouble(sdr["FYSPJE"]);
            node.FYYHXJE = Convert.ToDouble(sdr["FYYHXJE"]);


            return node;
        }



        private CRM_COST_LKAHXZLMX ReadUnconnectedDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAHXZLMX node = new CRM_COST_LKAHXZLMX();
            node.HXZLMXID = Convert.ToInt32(sdr["HXZLMXID"]);
            node.HXZLTTID = Convert.ToInt32(sdr["HXZLTTID"]);
            node.LKAFYTTID = Convert.ToInt32(sdr["LKAFYTTID"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.FYSPJE = Convert.ToDouble(sdr["FYSPJE"]);
            node.FYYHXJE = Convert.ToDouble(sdr["FYYHXJE"]);
            node.FYBCSQJE = Convert.ToDouble(sdr["FYBCSQJE"]);
            node.MCHTQK = Convert.ToInt32(sdr["MCHTQK"]);
            node.MCHTTK = Convert.ToString(sdr["MCHTTK"]);
            node.MCHTJE = Convert.ToDouble(sdr["MCHTJE"]);
            node.CSKKFP = Convert.ToInt32(sdr["CSKKFP"]);
            node.CSKKFPDY = Convert.ToInt32(sdr["CSKKFPDY"]);
            node.SFYHBYJ = Convert.ToInt32(sdr["SFYHBYJ"]);
            node.FYHXYHCNR = Convert.ToString(sdr["FYHXYHCNR"]);
            node.SJXS = Convert.ToDouble(sdr["SJXS"]);
            node.SJFB = Convert.ToDouble(sdr["SJFB"]);
            node.HDJSZJ = Convert.ToString(sdr["HDJSZJ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.QKSM = Convert.ToString(sdr["QKSM"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.SHR = Convert.ToInt32(sdr["SHR"]);
            node.SHSJ = Convert.ToDateTime(sdr["SHSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.MCHTQKDES = Convert.ToString(sdr["MCHTQKDES"]);
            node.CSKKFPDES = Convert.ToString(sdr["CSKKFPDES"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            node.SHRNAME = Convert.ToString(sdr["SHRNAME"]);
            node.TT_FYHXXS = Convert.ToInt32(sdr["FYHXXS"]);

            return node;
        }


        private CRM_COST_LKAHXZLMX ReadTimeToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAHXZLMX node = new CRM_COST_LKAHXZLMX();
            node.FYBEGINDATE = Convert.ToString(sdr["FYBEGINDATE"]);
            node.FYENDDATE = Convert.ToString(sdr["FYENDDATE"]);


            return node;
        }






    }
}
