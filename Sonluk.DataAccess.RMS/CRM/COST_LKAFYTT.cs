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
    public class COST_LKAFYTT : ICOST_LKAFYTT
    {

        private const string SQL_Create = "CRM_COST_LKAFYTT_Create";
        private const string SQL_Update = "CRM_COST_LKAFYTT_Update";
        private const string SQL_ReadByParam = "CRM_COST_LKAFYTT_ReadByParam";
        private const string SQL_Delete = "CRM_COST_LKAFYTT_Delete";
        private const string SQL_UpdateCost = "CRM_COST_LKAFYTT_UpdateCost";

        public int Create(CRM_COST_LKAFYTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@FYLB", model.FYLB),
                                        new SqlParameter("@LKAID", model.LKAID),
                                        new SqlParameter("@JXSID", model.JXSID),
                                        //new SqlParameter("@MDSL", model.MDSL),
                                        //new SqlParameter("@YSPNDJE", model.YSPNDJE),
                                        //new SqlParameter("@LJSQJE", model.LJSQJE),
                                        //new SqlParameter("@YHXNDJE", model.YHXNDJE),
                                        //new SqlParameter("@YWY", model.YWY),
                                        new SqlParameter("@CJHDMDSL", model.CJHDMDSL),
                                        new SqlParameter("@HDBEGINDATE", model.HDBEGINDATE),
                                        new SqlParameter("@HDENDDATE", model.HDENDDATE),
                                        new SqlParameter("@KHTHBEGINDATE", model.KHTHBEGINDATE),
                                        new SqlParameter("@KHTHENDDATE", model.KHTHENDDATE),
                                        new SqlParameter("@DP1", model.DP1),
                                        new SqlParameter("@DP2", model.DP2),
                                        new SqlParameter("@CCJ", model.CCJ),
                                        new SqlParameter("@ZCGJ", model.ZCGJ),
                                        new SqlParameter("@CXGJ", model.CXGJ),
                                        new SqlParameter("@ZCSJ", model.ZCSJ),
                                        new SqlParameter("@CXSJ", model.CXSJ),
                                        new SqlParameter("@DPYJXS", model.DPYJXS),
                                        new SqlParameter("@YJHDQJXS", model.YJHDQJXS),
                                        new SqlParameter("@YJFB", model.YJFB),
                                        new SqlParameter("@SJXS", model.SJXS),
                                        new SqlParameter("@SJFB", model.SJFB),
                                        new SqlParameter("@HDFASM", model.HDFASM),
                                        new SqlParameter("@HDJSZJ", model.HDJSZJ),
                                        new SqlParameter("@SFYHBYJ", model.SFYHBYJ),
                                        new SqlParameter("@OPINION", model.OPINION),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_LKAFYTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAFYTTID", model.LKAFYTTID),
                                        //new SqlParameter("@MDSL", model.MDSL),
                                        //new SqlParameter("@YSPNDJE", model.YSPNDJE),
                                        //new SqlParameter("@LJSQJE", model.LJSQJE),
                                        //new SqlParameter("@YHXNDJE", model.YHXNDJE),
                                        //new SqlParameter("@YWY", model.YWY),
                                        new SqlParameter("@CJHDMDSL", model.CJHDMDSL),
                                        new SqlParameter("@HDBEGINDATE", model.HDBEGINDATE),
                                        new SqlParameter("@HDENDDATE", model.HDENDDATE),
                                        new SqlParameter("@KHTHBEGINDATE", model.KHTHBEGINDATE),
                                        new SqlParameter("@KHTHENDDATE", model.KHTHENDDATE),
                                        new SqlParameter("@DP1", model.DP1),
                                        new SqlParameter("@DP2", model.DP2),
                                        new SqlParameter("@CCJ", model.CCJ),
                                        new SqlParameter("@ZCGJ", model.ZCGJ),
                                        new SqlParameter("@CXGJ", model.CXGJ),
                                        new SqlParameter("@ZCSJ", model.ZCSJ),
                                        new SqlParameter("@CXSJ", model.CXSJ),
                                        new SqlParameter("@DPYJXS", model.DPYJXS),
                                        new SqlParameter("@YJHDQJXS", model.YJHDQJXS),
                                        new SqlParameter("@YJFB", model.YJFB),
                                        new SqlParameter("@SJXS", model.SJXS),
                                        new SqlParameter("@SJFB", model.SJFB),
                                        new SqlParameter("@HDFASM", model.HDFASM),
                                        new SqlParameter("@HDJSZJ", model.HDJSZJ),
                                        new SqlParameter("@SFYHBYJ", model.SFYHBYJ),
                                        new SqlParameter("@OPINION", model.OPINION),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public int UpdateCost(int LKAFYTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAFYTTID", LKAFYTTID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateCost, parms);
        }

        public IList<CRM_COST_LKAFYTT> ReadByParam(CRM_COST_LKAFYTT model,int STAFFID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@LKAFYTTID", model.LKAFYTTID),
                                       new SqlParameter("@HTYEAR", model.HTYEAR),
                                       new SqlParameter("@LKAID", model.LKAID),
                                       new SqlParameter("@LKANAME", model.LKANAME),
                                       new SqlParameter("@FYLB", model.FYLB),
                                       new SqlParameter("@STAFFID", STAFFID),
                                       new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                       new SqlParameter("@LKACRMID", model.LKACRMID),
                                       new SqlParameter("@JXSSAPSN", model.JXSSAPSN),
                                       new SqlParameter("@STAFFNAME", model.STAFFNAME),


                                   };
            IList<CRM_COST_LKAFYTT> nodes = new List<CRM_COST_LKAFYTT>();
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


        public int Delete(int LKAFYTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAFYTTID", LKAFYTTID)
                                       

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

        private CRM_COST_LKAFYTT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAFYTT node = new CRM_COST_LKAFYTT();
            node.LKAFYTTID = Convert.ToInt32(sdr["LKAFYTTID"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            node.FYLB = Convert.ToInt32(sdr["FYLB"]);
            node.LKAID = Convert.ToInt32(sdr["LKAID"]);
            node.JXSID = Convert.ToInt32(sdr["JXSID"]);
            node.MDSL = Convert.ToInt32(sdr["MDSL"]);
            node.YSPNDJE = Convert.ToDouble(sdr["YSPNDJE"]);
            node.LJSQJE = Convert.ToDouble(sdr["LJSQJE"]);
            node.YHXNDJE = Convert.ToDouble(sdr["YHXNDJE"]);
            node.YWY = Convert.ToInt32(sdr["YWY"]);
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
            node.YJFB = Convert.ToDouble(sdr["YJFB"]);
            node.SJXS = Convert.ToDouble(sdr["SJXS"]);
            node.SJFB = Convert.ToDouble(sdr["SJFB"]);
            node.HDFASM = Convert.ToString(sdr["HDFASM"]);
            node.HDJSZJ = Convert.ToString(sdr["HDJSZJ"]);
            node.SFYHBYJ = Convert.ToInt32(sdr["SFYHBYJ"]);
            node.OPINION = Convert.ToString(sdr["OPINION"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd");
            node.LKANAME = Convert.ToString(sdr["LKANAME"]);
            node.LKACRMID = Convert.ToString(sdr["LKACRMID"]);
            node.JXSNAME = Convert.ToString(sdr["JXSNAME"]);
            node.JXSSAPSN = Convert.ToString(sdr["JXSSAPSN"]);
            node.YWYNAME = Convert.ToString(sdr["YWYNAME"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            node.DP1DES = Convert.ToString(sdr["DP1DES"]);
            node.DP2DES = Convert.ToString(sdr["DP2DES"]);
            node.MX_SQJE = Convert.ToDecimal(sdr["MX_SQJE"]);
            node.MX_ISACTIVE = Convert.ToInt32(sdr["MX_ISACTIVE"]);

            return node;
        }




    }
}
