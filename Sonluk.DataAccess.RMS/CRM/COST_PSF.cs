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
    public class COST_PSF : ICOST_PSF
    {
        private const string SQL_Create = "CRM_COST_PSF_Create";
        private const string SQL_Update = "CRM_COST_PSF_Update";
        private const string SQL_ReadByParam = "CRM_COST_PSF_ReadByParam";
        private const string SQL_Delete = "CRM_COST_PSF_Delete";
        private const string SQL_Read_Unconnected = "CRM_COST_PSF_Read_Unconnected";
        private const string SQL_ReportWLGS = "CRM_COST_PSF_ReportWLGS";
        private const string SQL_ReportJXS = "CRM_COST_PSF_ReportJXS";
        private const string SQL_AddPrintCount = "CRM_COST_PSF_AddPrintCount";

        public int Create(CRM_COST_PSF model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PSFTYPE", model.PSFTYPE),
                                        new SqlParameter("@GSYEAR", model.GSYEAR),
                                        new SqlParameter("@SEASON", model.SEASON),
                                        new SqlParameter("@GSMONTH", model.GSMONTH),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@JXSID", model.JXSID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@SJKPJE", model.SJKPJE),
                                        new SqlParameter("@FPKJJE", model.FPKJJE),
                                        new SqlParameter("@KPJEHJ", model.KPJEHJ),
                                        new SqlParameter("@MDSL", model.MDSL),
                                        new SqlParameter("@JHJE", model.JHJE),
                                        new SqlParameter("@YSJE", model.YSJE),
                                        new SqlParameter("@MDPSFBL", model.MDPSFBL),
                                        new SqlParameter("@MDPSF", model.MDPSF),
                                        new SqlParameter("@ZCPSFBL", model.ZCPSFBL),
                                        new SqlParameter("@ZCPSF", model.ZCPSF),
                                        new SqlParameter("@OTHER", model.OTHER),
                                        new SqlParameter("@PSFHJ", model.PSFHJ),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_PSF model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PSFID", model.PSFID),
                                        new SqlParameter("@PSFTYPE", model.PSFTYPE),
                                        new SqlParameter("@GSYEAR", model.GSYEAR),
                                        new SqlParameter("@SEASON", model.SEASON),
                                        new SqlParameter("@GSMONTH", model.GSMONTH),
                                        new SqlParameter("@JXSID", model.JXSID),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@SJKPJE", model.SJKPJE),
                                        new SqlParameter("@FPKJJE", model.FPKJJE),
                                        new SqlParameter("@KPJEHJ", model.KPJEHJ),
                                        new SqlParameter("@MDSL", model.MDSL),
                                        new SqlParameter("@JHJE", model.JHJE),
                                        new SqlParameter("@YSJE", model.YSJE),
                                        new SqlParameter("@MDPSFBL", model.MDPSFBL),
                                        new SqlParameter("@MDPSF", model.MDPSF),
                                        new SqlParameter("@ZCPSFBL", model.ZCPSFBL),
                                        new SqlParameter("@ZCPSF", model.ZCPSF),
                                        new SqlParameter("@OTHER", model.OTHER),
                                        new SqlParameter("@PSFHJ", model.PSFHJ),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public int AddPrintCount(int PSFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PSFID", PSFID)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_AddPrintCount, parms);
        }

        public IList<CRM_COST_PSF> ReadByParam(CRM_COST_PSF model,int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PSFID", model.PSFID),
                                        new SqlParameter("@PSFTYPE", model.PSFTYPE),
                                        new SqlParameter("@GSYEAR", model.GSYEAR),
                                        new SqlParameter("@SEASON", model.SEASON),
                                        new SqlParameter("@GSMONTH", model.GSMONTH),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@MC", model.MC),
                                        new SqlParameter("@SAPSN", model.SAPSN),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@STAFFID", STAFFID)

                                   };
            IList<CRM_COST_PSF> nodes = new List<CRM_COST_PSF>();
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

        public IList<CRM_COST_PSF> ReportWLGS(CRM_COST_PSF model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PSFIDSTR", model.PSFIDSTR),
                                        new SqlParameter("@GSYEAR", model.GSYEAR),
                                        new SqlParameter("@GSMONTH", model.GSMONTH)

                                   };
            IList<CRM_COST_PSF> nodes = new List<CRM_COST_PSF>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReportWLGS, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadWLGSreportToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_COST_PSF> ReportJXS(CRM_COST_PSF model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PSFIDSTR", model.PSFIDSTR),
                                        new SqlParameter("@SEASON", model.SEASON)

                                   };
            IList<CRM_COST_PSF> nodes = new List<CRM_COST_PSF>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReportJXS, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadJXSreportToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_COST_PSF> Read_Unconnected(CRM_COST_PSF model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@GSYEAR", model.GSYEAR),
                                        new SqlParameter("@KHID", model.KHID)

                                   };
            IList<CRM_COST_PSF> nodes = new List<CRM_COST_PSF>();
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

        public int Delete(int PSFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PSFID", PSFID)
                                       

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

        private CRM_COST_PSF ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_PSF node = new CRM_COST_PSF();
            node.PSFID = Convert.ToInt32(sdr["PSFID"]);
            node.PSFTYPE = Convert.ToInt32(sdr["PSFTYPE"]);
            node.GSYEAR = Convert.ToString(sdr["GSYEAR"]);
            node.SEASON = Convert.ToString(sdr["SEASON"]);
            node.GSMONTH = Convert.ToString(sdr["GSMONTH"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.JXSID = Convert.ToInt32(sdr["JXSID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.SJKPJE = Convert.ToDecimal(sdr["SJKPJE"]);
            node.FPKJJE = Convert.ToDecimal(sdr["FPKJJE"]);
            node.KPJEHJ = Convert.ToDecimal(sdr["KPJEHJ"]);
            node.MDSL = Convert.ToInt32(sdr["MDSL"]);
            node.JHJE = Convert.ToDecimal(sdr["JHJE"]);
            node.YSJE = Convert.ToDecimal(sdr["YSJE"]);
            node.MDPSFBL = Convert.ToInt32(sdr["MDPSFBL"]);
            node.MDPSF = Convert.ToDecimal(sdr["MDPSF"]);
            node.ZCPSFBL = Convert.ToInt32(sdr["ZCPSFBL"]);
            node.ZCPSF = Convert.ToDecimal(sdr["ZCPSF"]);
            node.OTHER = Convert.ToDecimal(sdr["OTHER"]);
            node.PSFHJ = Convert.ToDecimal(sdr["PSFHJ"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.PRINTCOUNT = Convert.ToInt32(sdr["PRINTCOUNT"]);



            node.JXSNAME = Convert.ToString(sdr["JXSNAME"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.PSFTYPEDES = Convert.ToString(sdr["PSFTYPEDES"]);
            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            return node;
        }


        private CRM_COST_PSF ReadUnconnectedDataToObj(SqlDataReader sdr)
        {
            CRM_COST_PSF node = new CRM_COST_PSF();
            node.PSFID = Convert.ToInt32(sdr["PSFID"]);
            node.PSFTYPE = Convert.ToInt32(sdr["PSFTYPE"]);
            node.GSYEAR = Convert.ToString(sdr["GSYEAR"]);
            node.SEASON = Convert.ToString(sdr["SEASON"]);
            node.GSMONTH = Convert.ToString(sdr["GSMONTH"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.JXSID = Convert.ToInt32(sdr["JXSID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.SJKPJE = Convert.ToDecimal(sdr["SJKPJE"]);
            node.FPKJJE = Convert.ToDecimal(sdr["FPKJJE"]);
            node.KPJEHJ = Convert.ToDecimal(sdr["KPJEHJ"]);
            node.MDSL = Convert.ToInt32(sdr["MDSL"]);
            node.JHJE = Convert.ToDecimal(sdr["JHJE"]);
            node.YSJE = Convert.ToDecimal(sdr["YSJE"]);
            node.MDPSFBL = Convert.ToInt32(sdr["MDPSFBL"]);
            node.MDPSF = Convert.ToDecimal(sdr["MDPSF"]);
            node.ZCPSFBL = Convert.ToInt32(sdr["ZCPSFBL"]);
            node.ZCPSF = Convert.ToDecimal(sdr["ZCPSF"]);
            node.OTHER = Convert.ToDecimal(sdr["OTHER"]);
            node.PSFHJ = Convert.ToDecimal(sdr["PSFHJ"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.PRINTCOUNT = Convert.ToInt32(sdr["PRINTCOUNT"]);

            node.COSTITEMIDDES = Convert.ToString(sdr["COSTITEMIDDES"]);
            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);

            node.JXSNAME = Convert.ToString(sdr["JXSNAME"]);
            node.PSFTYPEDES = Convert.ToString(sdr["PSFTYPEDES"]);
            node.MC = Convert.ToString(sdr["MC"]);
            return node;
        }


        private CRM_COST_PSF ReadWLGSreportToObj(SqlDataReader sdr)
        {
            CRM_COST_PSF node = new CRM_COST_PSF();
            node.GID = Convert.ToInt32(sdr["GID"]);
            node.GNAME = Convert.ToString(sdr["GNAME"]);
            node.GSYEAR = Convert.ToString(sdr["GSYEAR"]);
            node.GSMONTH = Convert.ToString(sdr["GSMONTH"]);
            node.PSFTYPE = Convert.ToInt32(sdr["PSFTYPE"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.SJKPJE = Convert.ToDecimal(sdr["SJKPJE"]);
            node.FPKJJE = Convert.ToDecimal(sdr["FPKJJE"]);
            node.KPJEHJ = Convert.ToDecimal(sdr["KPJEHJ"]);
            node.MDPSF = Convert.ToDecimal(sdr["MDPSF"]);
            node.ZCPSF = Convert.ToDecimal(sdr["ZCPSF"]);
            node.OTHER = Convert.ToDecimal(sdr["OTHER"]);
            node.PSFHJ = Convert.ToDecimal(sdr["PSFHJ"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            return node;
        }

        private CRM_COST_PSF ReadJXSreportToObj(SqlDataReader sdr)
        {
            CRM_COST_PSF node = new CRM_COST_PSF();
            node.JXSID = Convert.ToInt32(sdr["JXSID"]);
            node.JXSNAME = Convert.ToString(sdr["JXSNAME"]);
            node.GSYEAR = Convert.ToString(sdr["GSYEAR"]);
            node.SEASON = Convert.ToString(sdr["SEASON"]);
            node.GSMONTH = Convert.ToString(sdr["GSMONTH"]);
            //node.MC = Convert.ToString(sdr["MC"]);
            node.PSFTYPE = Convert.ToInt32(sdr["PSFTYPE"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.MDSL = Convert.ToInt32(sdr["MDSL"]);
            node.JHJE = Convert.ToDecimal(sdr["JHJE"]);
            node.YSJE = Convert.ToDecimal(sdr["YSJE"]);
            node.MDPSF = Convert.ToDecimal(sdr["MDPSF"]);
            node.ZCPSF = Convert.ToDecimal(sdr["ZCPSF"]);
            node.OTHER = Convert.ToDecimal(sdr["OTHER"]);
            node.PSFHJ = Convert.ToDecimal(sdr["PSFHJ"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            return node;
        }



    }
}
