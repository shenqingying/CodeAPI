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
    public class COST_LKAYEARTT : ICOST_LKAYEARTT
    {
        private const string SQL_Create = "CRM_COST_LKAYEARTT_Create";
        private const string SQL_Update = "CRM_COST_LKAYEARTT_Update";
        private const string SQL_ReadByParam = "CRM_COST_LKAYEARTT_ReadByParam";
        private const string SQL_Delete = "CRM_COST_LKAYEARTT_Delete";
        private const string SQL_Verify = "CRM_COST_LKAYEARTT_Verify";
        private const string SQL_ReportJXS = "CRM_COST_LKAYEARTT_ReportJXS";
        private const string SQL_UpdateSubmitCount = "CRM_COST_LKAYEARTT_UpdateSubmitCount";
        private const string SQL_CheckStatus = "CRM_COST_LKAYEARTT_CheckStatus";   //暂不可用
        private const string SQL_UpdateStatus = "CRM_COST_LKAYEARTT_UpdateStatus";
       


        //费用报表
        private const string SQL_Report_TaiZhang = "CRM_COST_LKAYearReport_TaiZhang";
        //系统产品利润汇总表
        private const string SQL_Report = "CRM_COST_LKAYEARTT_Report";


        public int Create(CRM_COST_LKAYEARTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@SQR", model.SQR),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@LKAID", model.LKAID),
                                        new SqlParameter("@JXSID", model.JXSID),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@MONTHCOUNT", model.MONTHCOUNT),
                                        new SqlParameter("@MDQKBZ", model.MDQKBZ),
                                        new SqlParameter("@FIRSTTIME", model.FIRSTTIME),
                                        new SqlParameter("@PSQK", model.PSQK),
                                        new SqlParameter("@FSFW", model.FSFW),
                                        new SqlParameter("@MANAGEWAY", model.MANAGEWAY),
                                        new SqlParameter("@PAYWAY", model.PAYWAY),
                                        new SqlParameter("@JZPPNAME", model.JZPPNAME),
                                        new SqlParameter("@NFGHS", model.NFGHS),
                                        new SqlParameter("@NFCLFS", model.NFCLFS),
                                        new SqlParameter("@NFCLZB", model.NFCLZB),
                                        new SqlParameter("@GSLXR", model.GSLXR),
                                        new SqlParameter("@GSLXRZW", model.GSLXRZW),
                                        new SqlParameter("@GSLXDH", model.GSLXDH),
                                        new SqlParameter("@QTCP", model.QTCP),
                                        new SqlParameter("@SFXJMC", model.SFXJMC),
                                        new SqlParameter("@SFZJQDHT", model.SFZJQDHT),
                                        new SqlParameter("@KAGXLKA", model.KAGXLKA),
                                        new SqlParameter("@WEBSITE", model.WEBSITE),
                                        new SqlParameter("@ACCOUNT", model.ACCOUNT),
                                        new SqlParameter("@XSBHYYSM", model.XSBHYYSM),
                                        new SqlParameter("@MCXSSOURCE", model.MCXSSOURCE),
                                        new SqlParameter("@MCXSSOURCE_OTHER", model.MCXSSOURCE_OTHER),
                                        new SqlParameter("@MCFYSOURCE", model.MCFYSOURCE),
                                        new SqlParameter("@MCFYSOURCE_OTHER", model.MCFYSOURCE_OTHER),
                                        new SqlParameter("@XSRW", model.XSRW),
                                        new SqlParameter("@XSJD", model.XSJD),
                                        new SqlParameter("@AXSRW", model.AXSRW),
                                        new SqlParameter("@AXSJD", model.AXSJD),
                                        new SqlParameter("@OPINION", model.OPINION),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_LKAYEARTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAYEARTTID", model.LKAYEARTTID),
                                        //new SqlParameter("@HTYEAR", model.HTYEAR),
                                        //new SqlParameter("@SQR", model.SQR),
                                        new SqlParameter("@XGR", model.XGR),
                                        //new SqlParameter("@LKAID", model.LKAID),
                                        //new SqlParameter("@JXSID", model.JXSID),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@MONTHCOUNT", model.MONTHCOUNT),
                                        new SqlParameter("@MDQKBZ", model.MDQKBZ),
                                        new SqlParameter("@FIRSTTIME", model.FIRSTTIME),
                                        new SqlParameter("@PSQK", model.PSQK),
                                        new SqlParameter("@FSFW", model.FSFW),
                                        new SqlParameter("@MANAGEWAY", model.MANAGEWAY),
                                        new SqlParameter("@PAYWAY", model.PAYWAY),
                                        new SqlParameter("@JZPPNAME", model.JZPPNAME),
                                        new SqlParameter("@NFGHS", model.NFGHS),
                                        new SqlParameter("@NFCLFS", model.NFCLFS),
                                        new SqlParameter("@NFCLZB", model.NFCLZB),
                                        new SqlParameter("@GSLXR", model.GSLXR),
                                        new SqlParameter("@GSLXRZW", model.GSLXRZW),
                                        new SqlParameter("@GSLXDH", model.GSLXDH),
                                        new SqlParameter("@QTCP", model.QTCP),
                                        new SqlParameter("@SFXJMC", model.SFXJMC),
                                        new SqlParameter("@SFZJQDHT", model.SFZJQDHT),
                                        new SqlParameter("@KAGXLKA", model.KAGXLKA),
                                        new SqlParameter("@WEBSITE", model.WEBSITE),
                                        new SqlParameter("@ACCOUNT", model.ACCOUNT),
                                        new SqlParameter("@XSBHYYSM", model.XSBHYYSM),
                                        new SqlParameter("@MCXSSOURCE", model.MCXSSOURCE),
                                        new SqlParameter("@MCXSSOURCE_OTHER", model.MCXSSOURCE_OTHER),
                                        new SqlParameter("@MCFYSOURCE", model.MCFYSOURCE),
                                        new SqlParameter("@MCFYSOURCE_OTHER", model.MCFYSOURCE_OTHER),
                                        new SqlParameter("@XSRW", model.XSRW),
                                        new SqlParameter("@XSJD", model.XSJD),
                                        new SqlParameter("@AXSRW", model.AXSRW),
                                        new SqlParameter("@AXSJD", model.AXSJD),
                                        new SqlParameter("@OPINION", model.OPINION),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@SUBMITCOUNT", model.SUBMITCOUNT)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public int UpdateStatus(CRM_COST_LKAYEARTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAYEARTTID", model.LKAYEARTTID),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateStatus, parms);
        }

        public int UpdateSubmitCount(int LKAYEARTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAYEARTTID", LKAYEARTTID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_UpdateSubmitCount, parms);
        }

        public int CheckStatus(int LKAYEARTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAYEARTTID", LKAYEARTTID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_CheckStatus, parms);
        }

        public IList<CRM_COST_LKAYEARTT> ReadByParam(CRM_COST_LKAYEARTT model,int STAFFID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@LKAYEARTTID", model.LKAYEARTTID),
                                       new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@SQRNAME", model.SQRNAME),
                                        new SqlParameter("@LKAID", model.LKAID),
                                        new SqlParameter("@LKAMC", model.LKAMC),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@JXSSAPSN", model.JXSSAPSN),
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@STAFFID", STAFFID)
                                   };
            IList<CRM_COST_LKAYEARTT> nodes = new List<CRM_COST_LKAYEARTT>();
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

        public IList<CRM_COST_LKAYEARTT_JXS> ReportJXS(int LKAYEARTTID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@LKAYEARTTID", LKAYEARTTID)
                                   };
            IList<CRM_COST_LKAYEARTT_JXS> nodes = new List<CRM_COST_LKAYEARTT_JXS>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReportJXS, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadJXSDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }
        

        public int Delete(int LKAYEARTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@LKAYEARTTID", LKAYEARTTID)
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }

        public int Verify(CRM_COST_LKAYEARTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@BEGINDATE", model.BEGINDATE),
                                        new SqlParameter("@ENDDATE", model.ENDDATE),
                                        new SqlParameter("@LKAID", model.LKAID)
                                   };

            return Binning(CommandType.StoredProcedure, SQL_Verify, parms);
        }

        public IList<CRM_COST_LKAYearReport> Report_TaiZhang(CRM_COST_LKAYearReport model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@HTYEAR", model.HTYEAR),
                                        new SqlParameter("@JXSCRMID", model.JXSCRMID),
                                        new SqlParameter("@JXSMC", model.JXSMC),
                                        new SqlParameter("@JXSSAPSN", model.JXSSAPSN),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@MC", model.MC)
                                   };
            IList<CRM_COST_LKAYearReport> nodes = new List<CRM_COST_LKAYearReport>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report_TaiZhang, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadTZDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }
        public IList<CRM_COST_LKAYEARTT_Report> Report(CRM_COST_LKAYEARTT_Report model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@LKANAME", model.LKANAME),
                                       new SqlParameter("@JXSNAME", model.JXSNAME),
                                       new SqlParameter("@CPMC", model.CPMC),
                                       new SqlParameter("@HTYEAR", model.HTYEAR),
                                       new SqlParameter("@CRMID", model.CRMID),
                                       new SqlParameter("@JXSSAP", model.JXSSAP)

                                   };
            IList<CRM_COST_LKAYEARTT_Report> nodes = new List<CRM_COST_LKAYEARTT_Report>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj_REPORT(sdr));
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

        private CRM_COST_LKAYEARTT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAYEARTT node = new CRM_COST_LKAYEARTT();
            node.LKAYEARTTID = Convert.ToInt32(sdr["LKAYEARTTID"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            node.SQR = Convert.ToInt32(sdr["SQR"]);
            node.SQSJ = Convert.ToDateTime(sdr["SQSJ"]).ToString("yyyy-MM-dd");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.LASTXGSJ = Convert.ToDateTime(sdr["LASTXGSJ"]).ToString("yyyy-MM-dd");
            node.LKAID = Convert.ToInt32(sdr["LKAID"]);
            node.JXSID = Convert.ToInt32(sdr["JXSID"]);
            node.BEGINDATE = Convert.ToString(sdr["BEGINDATE"]);
            node.ENDDATE = Convert.ToString(sdr["ENDDATE"]);
            node.MONTHCOUNT = Convert.ToInt32(sdr["MONTHCOUNT"]);
            node.MDQKBZ = Convert.ToString(sdr["MDQKBZ"]);
            node.FIRSTTIME = Convert.ToString(sdr["FIRSTTIME"]);
            node.PSQK = Convert.ToString(sdr["PSQK"]);
            node.FSFW = Convert.ToString(sdr["FSFW"]);
            node.MANAGEWAY = Convert.ToInt32(sdr["MANAGEWAY"]);
            node.PAYWAY = Convert.ToInt32(sdr["PAYWAY"]);
            node.JZPPNAME = Convert.ToString(sdr["JZPPNAME"]);
            node.NFGHS = Convert.ToInt32(sdr["NFGHS"]);
            node.NFCLFS = Convert.ToString(sdr["NFCLFS"]);
            node.NFCLZB = Convert.ToDouble(sdr["NFCLZB"]);
            node.GSLXR = Convert.ToString(sdr["GSLXR"]);
            node.GSLXRZW = Convert.ToInt32(sdr["GSLXRZW"]);
            node.GSLXDH = Convert.ToString(sdr["GSLXDH"]);
            node.QTCP = Convert.ToInt32(sdr["QTCP"]);
            node.SFXJMC = Convert.ToInt32(sdr["SFXJMC"]);
            node.SFZJQDHT = Convert.ToInt32(sdr["SFZJQDHT"]);
            node.KAGXLKA = Convert.ToInt32(sdr["KAGXLKA"]);
            node.WEBSITE = Convert.ToString(sdr["WEBSITE"]);
            node.ACCOUNT = Convert.ToString(sdr["ACCOUNT"]);
            node.XSBHYYSM = Convert.ToString(sdr["XSBHYYSM"]);
            node.MCXSSOURCE = Convert.ToInt32(sdr["MCXSSOURCE"]);
            node.MCXSSOURCE_OTHER = Convert.ToString(sdr["MCXSSOURCE_OTHER"]);
            node.MCFYSOURCE = Convert.ToInt32(sdr["MCFYSOURCE"]);
            node.MCFYSOURCE_OTHER = Convert.ToString(sdr["MCFYSOURCE_OTHER"]);
            node.XSRW = Convert.ToDouble(sdr["XSRW"]);
            node.XSJD = Convert.ToDouble(sdr["XSJD"]);
            node.AXSRW = Convert.ToDouble(sdr["AXSRW"]);
            node.AXSJD = Convert.ToDouble(sdr["AXSJD"]);
            node.OPINION = Convert.ToString(sdr["OPINION"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.SUBMITCOUNT = Convert.ToInt32(sdr["SUBMITCOUNT"]);
            node.JXSMC = Convert.ToString(sdr["JXSMC"]);
            node.JXSSAPSN = Convert.ToString(sdr["JXSSAPSN"]);
            node.LKAMC = Convert.ToString(sdr["LKAMC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.SQRNAME = Convert.ToString(sdr["SQRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            node.MANAGEWAYDES = Convert.ToString(sdr["MANAGEWAYDES"]);
            node.PAYWAYDES = Convert.ToString(sdr["PAYWAYDES"]);
            node.NFGHSDES = Convert.ToString(sdr["NFGHSDES"]);
            node.GSLXRZWDES = Convert.ToString(sdr["GSLXRZWDES"]);
            node.MCXSSOURCEDES = Convert.ToString(sdr["MCXSSOURCEDES"]);
            node.MCFYSOURCEDES = Convert.ToString(sdr["MCFYSOURCEDES"]);
            node.YWY = Convert.ToString(sdr["YWY"]);
            node.TOTALAMOUNT = Convert.ToDouble(sdr["TOTALAMOUNT"]);
            return node;
        }

        private CRM_COST_LKAYEARTT_JXS ReadJXSDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAYEARTT_JXS node = new CRM_COST_LKAYEARTT_JXS();
            node.HTYEAR = Convert.ToInt32(sdr["HTYEAR"]);
            //node.SJXS = Convert.ToDouble(sdr["SJXS"]);
            //node.SJXS_JX = Convert.ToDouble(sdr["SJXS_JX"]);
            node.COST_HT = Convert.ToDouble(sdr["COST_HT"]);
            node.COST_GS = Convert.ToDouble(sdr["COST_GS"]);
            //node.FB_GS = Convert.ToDouble(sdr["FB_GS"]);
            node.SPSL = Convert.ToInt32(sdr["SPSL"]);
            //node.ZFY = Convert.ToDouble(sdr["ZFY"]);
            //node.ZFB = Convert.ToDouble(sdr["ZFB"]);
            return node;
        }

        private CRM_COST_LKAYearReport ReadTZDataToObj(SqlDataReader sdr)
        {
            CRM_COST_LKAYearReport node = new CRM_COST_LKAYearReport();
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            return node;
        }
        private CRM_COST_LKAYEARTT_Report ReadDataToObj_REPORT(SqlDataReader sdr)
        {
            CRM_COST_LKAYEARTT_Report node = new CRM_COST_LKAYEARTT_Report();
            node.YWY = Convert.ToString(sdr["YWY"]);
            node.JXSSAP = Convert.ToString(sdr["JXSSAP"]);
            node.JXSMC = Convert.ToString(sdr["JXSMC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.LKAMC = Convert.ToString(sdr["LKAMC"]);
            node.HTYEAR = Convert.ToString(sdr["HTYEAR"]);
            node.CPMC = Convert.ToString(sdr["CPMC"]);
            node.CPFL = Convert.ToString(sdr["CPFL"]);
            node.NUM1 = Convert.ToString(sdr["NUM1"]) == "0" ? "" : Convert.ToString(sdr["NUM1"]);
            node.NUM2 = Convert.ToString(sdr["NUM2"]) == "0" ? "" : Convert.ToString(sdr["NUM2"]);
            //node.LKANAME = Convert.ToString(sdr["LKANAME"]);
            //node.JXSNAME = Convert.ToString(sdr["JXSNAME"]);

            return node;
        }




    }
}
