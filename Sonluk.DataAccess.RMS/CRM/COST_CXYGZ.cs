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
    public class COST_CXYGZ : ICOST_CXYGZ
    {
        private const string SQL_Create = "CRM_COST_CXYGZ_Create";
        private const string SQL_Update = "CRM_COST_CXYGZ_Update";
        private const string SQL_ReadByParam = "CRM_COST_CXYGZ_ReadByParam";
        private const string SQL_Delete = "CRM_COST_CXYGZ_Delete";
        private const string SQL_AddPrintCount = "CRM_COST_CXYGZ_AddPrintCount";



        public int Create(CRM_COST_CXYGZ model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CXYID", model.CXYID),
                                        new SqlParameter("@CXYYEAR", model.CXYYEAR),
                                        new SqlParameter("@CXYMONTH", model.CXYMONTH),
                                        new SqlParameter("@TCJE", model.TCJE),
                                        new SqlParameter("@THCBKJ", model.THCBKJ),
                                        new SqlParameter("@YFHJ", model.YFHJ),
                                        new SqlParameter("@CXYXHJE", model.CXYXHJE),
                                        new SqlParameter("@SFGZ", model.SFGZ),
                                        new SqlParameter("@SBKC", model.SBKC),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR),
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_CXYGZ model)
        {
            SqlParameter[] parms = {
                                      
                                        new SqlParameter("@CXYYEAR", model.CXYYEAR),
                                        new SqlParameter("@CXYMONTH", model.CXYMONTH),
                                        new SqlParameter("@TCJE", model.TCJE),
                                        new SqlParameter("@THCBKJ", model.THCBKJ),
                                        new SqlParameter("@YFHJ", model.YFHJ),
                                        new SqlParameter("@CXYXHJE", model.CXYXHJE),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@SFGZ", model.SFGZ),
                                        new SqlParameter("@SBKC", model.SBKC),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@CXYID", model.CXYID),
                                        new SqlParameter("@CXYGZID", model.CXYGZID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public int AddPrintCount(int CXYGZID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CXYGZID", CXYGZID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_AddPrintCount, parms);
        }

        public IList<CRM_COST_CXYGZ> ReadByParam(CRM_COST_CXYGZ model)
        {
            SqlParameter[] parms = {  
                                        new SqlParameter("@CXYGZID", model.CXYGZID),
                                        new SqlParameter("@CXYID", model.CXYID),
                                        new SqlParameter("@CXYYEAR", model.CXYYEAR),
                                        new SqlParameter("@CXYMONTH", model.CXYMONTH),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@TIME_BEGIN", model.TIME_BEGIN),
                                        new SqlParameter("@TIME_END", model.TIME_END),
                                        new SqlParameter("@CXYGZIDSTR", model.CXYGZIDSTR),
                                        new SqlParameter("@NAME", model.NAME),
                                        new SqlParameter("@GW", model.GW),
                                        new SqlParameter("@XTMC", model.XTMC),
                                        new SqlParameter("@MDMC", model.MDMC),
                                   };
            IList<CRM_COST_CXYGZ> nodes = new List<CRM_COST_CXYGZ>();
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



        public int Delete(int CXYGZID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CXYGZID", CXYGZID)
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


        private CRM_COST_CXYGZ ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_CXYGZ node = new CRM_COST_CXYGZ();
            node.CXYID = Convert.ToInt32(sdr["CXYID"]);
            node.CXYGZID = Convert.ToInt32(sdr["CXYGZID"]);
            node.CXYYEAR = Convert.ToString(sdr["CXYYEAR"]);
            node.CXYMONTH = Convert.ToString(sdr["CXYMONTH"]);
            node.TCJE = Convert.ToDouble(sdr["TCJE"]);
            node.THCBKJ = Convert.ToDouble(sdr["THCBKJ"]);
            node.YFHJ = Convert.ToDouble(sdr["YFHJ"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.PRINTCOUNT = Convert.ToInt32(sdr["PRINTCOUNT"]);
            node.SBKC = Convert.ToDouble(sdr["SBKC"]);
            node.SFGZ = Convert.ToDouble(sdr["SFGZ"]);
            node.CXYXHJE = Convert.ToDouble(sdr["CXYXHJE"]);
            node.BASE = Convert.ToDouble(sdr["BASE"]);
            node.GW = Convert.ToInt32(sdr["GW"]);
            node.NAME = Convert.ToString(sdr["NAME"]);
            node.CODE = Convert.ToString(sdr["CODE"]);
            node.TEL = Convert.ToString(sdr["TEL"]);
            node.GWGZ = Convert.ToDouble(sdr["GWGZ"]);
            node.PKHIDDES = Convert.ToString(sdr["PKHIDDES"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.GWDES = Convert.ToString(sdr["GWDES"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);
            node.BANK = Convert.ToString(sdr["BANK"]);
            node.CARDNUM = Convert.ToString(sdr["CARDNUM"]);
            node.KAXS = Convert.ToDecimal(sdr["KAXS"]);

            return node;
        }

    }
}
