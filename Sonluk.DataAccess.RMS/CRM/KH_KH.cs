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
    public class KH_KH : IKH_KH
    {
        private const string SQL_Create = @"CRM_KH_KH_Create";
        private const string SQL_Update = @"CRM_KH_KH_Update";
        private const string SQL_UpdateSFCS = @"CRM_KH_KH_UpdateSFCS";
        private const string SQL_UpdateSapsn = @"CRM_KH_KH_UpdateSAPSN";
        private const string SQL_ReadByKHID = "CRM_KH_KH_ReadByKHID";//@"SELECT A.* ,ISNULL((SELECT MC FROM CRM_KH_KH  AS B WHERE B.CRMID = A.PKHID),' ') AS PKHIDDES,(SELECT DICNAME FROM CRM_HG_DICT WHERE DICID = A.CS) AS CSDES,(SELECT DICNAME FROM CRM_HG_DICT WHERE DICID = A.SF) AS SFDES FROM CRM_KH_KH AS A WHERE ISDELETE = 0 AND KHID = @KHID";
        private const string SQL_ReadByPARMS = @"CRM_KH_KH_ReaddByParms";
        private const string SQL_Read = "CRM_KH_KH_Read";//@"SELECT SAPSN FROM CRM_KH_KH WHERE SAPSN <> '' AND SAPKHLX = 1 AND ISACTIVE = 3 AND CRMID IS NOT NULL";
        private const string SQL_ReadByCRMID = "CRM_KH_KH_ReadByCRMID";//@"SELECT * FROM CRM_KH_KH WHERE  CRMID = @CRMID  AND ISACTIVE = 3";
        private const string SQL_Delete = @"CRM_KH_KH_Delete";
        private const string SQL_Report = @"CRM_KH_KH_Report";
        private const string SQL_Report_PLUS = @"CRM_KH_KH_Report_PLUS";
        private const string SQL_Verify = @"CRM_KH_KH_Verify";
        private const string SQL_Modify = @"CRM_KH_KH_Modify";
        private const string SQL_DeleteSDF = @"DELETE FROM CRM_KH_KH WHERE CRM_KH_KH.SAPSN IN (SELECT HZHBKHID FROM CRM_KH_HZHB WHERE SAPSN = @SAPSN AND CRM_KH_HZHB.HZHBGN = 'WE' AND SAPSN <> HZHBKHID and SAPKHLX is null)";
        private const string SQL_ReadXSZZ = "CRM_KH_KH_ReadXSZZ";//@"SELECT distinct XSZZ FROM CRM_KH_XSQYSJ WHERE ISACTIVE = 1";
        private const string SQL_KH_Blank_Report = @"CRM_KH_Blank_Report";
        private const string SQL_ReadXDByKHID = "CRM_KH_KH_ReadXDByKHID";//"SELECT ISNULL(XXMC,' ') AS XXMC FROM  CRM_KH_KHQTXX WHERE ISACTIVE = 1 AND KHID = @KHID AND XXLB = 1";
        private const string SQL_ReadKH_ForBF = "CRM_KH_KH_ReadForBF";
        private const string SQL_Report_ZDWD = @"CRM_KH_KH_Report_ZDWD";
        private const string SQL_Report_LKA = @"CRM_KH_KH_Report_LKA";
        private const string SQL_ReadBySTAFFID = "CRM_KH_KH_ReadBySTAFFID";
        private const string SQL_ReadJXSByKHID = "CRM_KH_KH_ReadJXSByKHID";
        private const string SQL_ReadByJXS = "CRM_KH_KH_ReadByJXS";
        private const double FIXED = 0.0044915764205976;

        private const string SQL_ReadKH_ForSAP = "CRM_KH_KH_ReadByStaffForSAP";

        //USER
        private const string SQL_ReadUser_KH = "CRM_HG_STAFF_ReadUser_KH";

        //ORDER
        private const string SQL_ReadSDFbyPKH = "CRM_KH_KH_ReadSDFbyPKH";
        private const string SQL_ReadBySAPSN = "CRM_KH_KH_ReadBySAPSN";
        private const string SQL_ReadKHAcount = "CRM_KH_KH_ReadKHAcount";

        public IList<SAP_KH> ReadKHForSap(int STAFFID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
            IList<SAP_KH> nodes = new List<SAP_KH>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadKH_ForSAP, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadSapsnToInfoObject(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }






        public int Create(CRM_KH_KH KH_S)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@KHID",KH_S.KHID),
                                        new SqlParameter("@CRMID",string.IsNullOrEmpty(KH_S.CRMID)?"":KH_S.CRMID),
                                        new SqlParameter("@KHLX",KH_S.KHLX),
                                        new SqlParameter("@PKHID",KH_S.PKHID),
                                        new SqlParameter("@SAPSN",string.IsNullOrEmpty(KH_S.SAPSN)?"":KH_S.SAPSN),
                                        new SqlParameter("@SAPKHLX",string.IsNullOrEmpty(KH_S.SAPKHLX)?"":KH_S.SAPKHLX),
                                        new SqlParameter("@SAPSJ",string.IsNullOrEmpty(KH_S.SAPSJ)?"":KH_S.SAPSJ),
                                        new SqlParameter("@MC",string.IsNullOrEmpty(KH_S.MC)?"":KH_S.MC),
                                        new SqlParameter("@GJ",KH_S.GJ),
                                        new SqlParameter("@SF",KH_S.SF),
                                        new SqlParameter("@CS",KH_S.CS),
                                        new SqlParameter("@COUNTY",KH_S.COUNTY),
                                        new SqlParameter("@KHZZSJ",string.IsNullOrEmpty(KH_S.KHZZSJ)?"":KH_S.KHZZSJ),
                                        new SqlParameter("@SFZXS",KH_S.SFZXS),
                                        new SqlParameter("@GSLXR",string.IsNullOrEmpty(KH_S.GSLXR)?"":KH_S.GSLXR),
                                        new SqlParameter("@GSLXDH",string.IsNullOrEmpty(KH_S.GSLXDH)?"":KH_S.GSLXDH),
                                        new SqlParameter("@KPXZ",KH_S.KPXZ),
                                        new SqlParameter("@KPDZ",string.IsNullOrEmpty(KH_S.KPDZ)?"":KH_S.KPDZ),
                                        new SqlParameter("@KPDH",string.IsNullOrEmpty(KH_S.KPDH)?"":KH_S.KPDH),
                                        new SqlParameter("@NSRSBH",string.IsNullOrEmpty(KH_S.NSRSBH)?"":KH_S.NSRSBH),
                                        new SqlParameter("@YHZH",string.IsNullOrEmpty(KH_S.YHZH)?"":KH_S.YHZH),
                                        new SqlParameter("@YHMC",string.IsNullOrEmpty(KH_S.YHMC)?"":KH_S.YHMC),
                                        new SqlParameter("@FKTJ",string.IsNullOrEmpty(KH_S.FKTJ)?"":KH_S.FKTJ),
                                        new SqlParameter("@FR",string.IsNullOrEmpty(KH_S.FR)?"":KH_S.FR),
                                        new SqlParameter("@FRLXFS",string.IsNullOrEmpty(KH_S.FRLXFS)?"":KH_S.FRLXFS),
                                        new SqlParameter("@GSFRGX",string.IsNullOrEmpty(KH_S.GSFRGX)?"":KH_S.GSFRGX),
                                        new SqlParameter("@HTXSRW",string.IsNullOrEmpty(KH_S.HTXSRW)?"":KH_S.HTXSRW),
                                        new SqlParameter("@HTJXXSRW",string.IsNullOrEmpty(KH_S.HTJXXSRW)?"":KH_S.HTJXXSRW),
                                        new SqlParameter("@XSSJSM",string.IsNullOrEmpty(KH_S.XSSJSM)?"":KH_S.XSSJSM),
                                        new SqlParameter("@SFCCJ",KH_S.SFCCJ),
                                        new SqlParameter("@TSQKSM",string.IsNullOrEmpty(KH_S.TSQKSM)?"":KH_S.TSQKSM),
                                        new SqlParameter("@JXSYX",KH_S.JXSYX),
                                        new SqlParameter("@YXSM",string.IsNullOrEmpty(KH_S.YXSM)?"":KH_S.YXSM),
                                        new SqlParameter("@WDLX",KH_S.WDLX),
                                        new SqlParameter("@SFBZWD",KH_S.SFBZWD),
                                        new SqlParameter("@MDJCSL",string.IsNullOrEmpty(KH_S.MDJCSL)?"":KH_S.MDJCSL),
                                        new SqlParameter("@ZBDZ",string.IsNullOrEmpty(KH_S.ZBDZ)?"":KH_S.ZBDZ),
                                        new SqlParameter("@MCLC",KH_S.MCLC),
                                        new SqlParameter("@MDDZ",string.IsNullOrEmpty(KH_S.MDDZ)?"":KH_S.MDDZ),
                                        new SqlParameter("@JCDPSL",string.IsNullOrEmpty(KH_S.JCDPSL)?"":KH_S.JCDPSL),
                                        new SqlParameter("@FID",KH_S.FID),
                                        new SqlParameter("@FDATE",string.IsNullOrEmpty(KH_S.FDATE)?"":KH_S.FDATE),
                                        new SqlParameter("@FTID",string.IsNullOrEmpty(KH_S.FTID)?"":KH_S.FTID),
                                        new SqlParameter("@FGLDYJ",string.IsNullOrEmpty(KH_S.FGLDYJ)?"":KH_S.FGLDYJ),
                                        new SqlParameter("@XSZJYJ",string.IsNullOrEmpty(KH_S.XSZJYJ)?"":KH_S.XSZJYJ),
                                        new SqlParameter("@ISACTIVE",KH_S.ISACTIVE),
                                        new SqlParameter("@BEIZ",string.IsNullOrEmpty(KH_S.BEIZ)?"":KH_S.BEIZ),
                                        new SqlParameter("@XYDJ",string.IsNullOrEmpty(KH_S.XYDJ)?"":KH_S.XYDJ),
                                        new SqlParameter("@KHGM",string.IsNullOrEmpty(KH_S.KHGM)?"":KH_S.KHGM),
                                        new SqlParameter("@DZ",string.IsNullOrEmpty(KH_S.DZ)?"":KH_S.DZ),
                                        new SqlParameter("@KDJSDZ",string.IsNullOrEmpty(KH_S.KDJSDZ)?"":KH_S.KDJSDZ),
                                        new SqlParameter("@KDLXR",string.IsNullOrEmpty(KH_S.KDLXR)?"":KH_S.KDLXR),
                                        new SqlParameter("@KDLXDH",string.IsNullOrEmpty(KH_S.KDLXDH)?"":KH_S.KDLXDH),
                                        new SqlParameter("@KHSHDZ",string.IsNullOrEmpty(KH_S.KHSHDZ)?"":KH_S.KHSHDZ),
                                        new SqlParameter("@KHSHLXR",string.IsNullOrEmpty(KH_S.KHSHLXR)?"":KH_S.KHSHLXR),
                                        new SqlParameter("@KHSHLXDH",string.IsNullOrEmpty(KH_S.KHSHLXDH)?"":KH_S.KHSHLXDH),
                                        new SqlParameter("@SFCCJSM",string.IsNullOrEmpty(KH_S.SFCCJSM)?"":KH_S.SFCCJSM),
                                        new SqlParameter("@MCSX",KH_S.MCSX),
                                        new SqlParameter("@ISDELETE",KH_S.ISDELETE),
                                        new SqlParameter("@IsOfficial",KH_S.IsOfficial),
                                        new SqlParameter("@FLSJSM",KH_S.FLSJSM),
                                        new SqlParameter("@KHLX2",KH_S.KHLX2),
                                        new SqlParameter("@KHSOURCE",KH_S.KHSOURCE),
                                        new SqlParameter("@KHJS",KH_S.KHJS),
                                        new SqlParameter("@PP",KH_S.PP),
                                        new SqlParameter("@PPOWNER",KH_S.PPOWNER),
                                        new SqlParameter("@FACTORY",KH_S.FACTORY),
                                        new SqlParameter("@FIRSTAMOUNT",KH_S.FIRSTAMOUNT),
                                        new SqlParameter("@JOINACTIVITY",KH_S.JOINACTIVITY),
                                        new SqlParameter("@FIRSTTIME",KH_S.FIRSTTIME),
                                        new SqlParameter("@PSQK",KH_S.PSQK),
                                        new SqlParameter("@FSFW",KH_S.FSFW),
                                        new SqlParameter("@MANAGEWAY",KH_S.MANAGEWAY),
                                        new SqlParameter("@PAYWAY",KH_S.PAYWAY),
                                        new SqlParameter("@GSLXRZW",KH_S.GSLXRZW),
                                        new SqlParameter("@SUPPORTOTHER",KH_S.SUPPORTOTHER),
                                        new SqlParameter("@ISNEW",KH_S.ISNEW),
                                        new SqlParameter("@PACT",KH_S.PACT),
                                        new SqlParameter("@BELONGKA",KH_S.BELONGKA),
                                        new SqlParameter("@WEBSITE",KH_S.WEBSITE),
                                        new SqlParameter("@ACCOUNT",KH_S.ACCOUNT),
                                        new SqlParameter("@YYZT",KH_S.YYZT),
                                        new SqlParameter("@GDSJ",KH_S.GDSJ),
                                        new SqlParameter("@GC",KH_S.GC),
                                        new SqlParameter("@KCDD",KH_S.KCDD)
                                   };
            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Create, parms))
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
        public int Update(CRM_KH_KH KH_S, bool isKHID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KHID",KH_S.KHID),
                                        new SqlParameter("@CRMID",string.IsNullOrEmpty(KH_S.CRMID)?"":KH_S.CRMID),
                                        new SqlParameter("@KHLX",KH_S.KHLX),
                                        new SqlParameter("@PKHID",KH_S.PKHID),
                                        new SqlParameter("@SAPSN",string.IsNullOrEmpty(KH_S.SAPSN)?"":KH_S.SAPSN),
                                        new SqlParameter("@SAPKHLX",string.IsNullOrEmpty(KH_S.SAPKHLX)?"":KH_S.SAPKHLX),
                                        new SqlParameter("@SAPSJ",string.IsNullOrEmpty(KH_S.SAPSJ)?"":KH_S.SAPSJ),
                                        new SqlParameter("@MC",string.IsNullOrEmpty(KH_S.MC)?"":KH_S.MC),
                                        new SqlParameter("@GJ",KH_S.GJ),
                                        new SqlParameter("@SF",KH_S.SF),
                                        new SqlParameter("@CS",KH_S.CS),
                                        new SqlParameter("@COUNTY",KH_S.COUNTY),
                                        new SqlParameter("@KHZZSJ",string.IsNullOrEmpty(KH_S.KHZZSJ)?"":KH_S.KHZZSJ),
                                        new SqlParameter("@SFZXS",KH_S.SFZXS),
                                        new SqlParameter("@GSLXR",string.IsNullOrEmpty(KH_S.GSLXR)?"":KH_S.GSLXR),
                                        new SqlParameter("@GSLXDH",string.IsNullOrEmpty(KH_S.GSLXDH)?"":KH_S.GSLXDH),
                                        new SqlParameter("@KPXZ",KH_S.KPXZ),
                                        new SqlParameter("@KPDZ",string.IsNullOrEmpty(KH_S.KPDZ)?"":KH_S.KPDZ),
                                        new SqlParameter("@KPDH",string.IsNullOrEmpty(KH_S.KPDH)?"":KH_S.KPDH),
                                        new SqlParameter("@NSRSBH",string.IsNullOrEmpty(KH_S.NSRSBH)?"":KH_S.NSRSBH),
                                        new SqlParameter("@YHZH",string.IsNullOrEmpty(KH_S.YHZH)?"":KH_S.YHZH),
                                        new SqlParameter("@YHMC",string.IsNullOrEmpty(KH_S.YHMC)?"":KH_S.YHMC),
                                        new SqlParameter("@FKTJ",string.IsNullOrEmpty(KH_S.FKTJ)?"":KH_S.FKTJ),
                                        new SqlParameter("@FR",string.IsNullOrEmpty(KH_S.FR)?"":KH_S.FR),
                                        new SqlParameter("@FRLXFS",string.IsNullOrEmpty(KH_S.FRLXFS)?"":KH_S.FRLXFS),
                                        new SqlParameter("@GSFRGX",string.IsNullOrEmpty(KH_S.GSFRGX)?"":KH_S.GSFRGX),
                                        new SqlParameter("@HTXSRW",string.IsNullOrEmpty(KH_S.HTXSRW)?"":KH_S.HTXSRW),
                                        new SqlParameter("@HTJXXSRW",string.IsNullOrEmpty(KH_S.HTJXXSRW)?"":KH_S.HTJXXSRW),
                                        new SqlParameter("@XSSJSM",string.IsNullOrEmpty(KH_S.XSSJSM)?"":KH_S.XSSJSM),
                                        new SqlParameter("@SFCCJ",KH_S.SFCCJ),
                                        new SqlParameter("@TSQKSM",string.IsNullOrEmpty(KH_S.TSQKSM)?"":KH_S.TSQKSM),
                                        new SqlParameter("@JXSYX",KH_S.JXSYX),
                                        new SqlParameter("@YXSM",string.IsNullOrEmpty(KH_S.YXSM)?"":KH_S.YXSM),
                                        new SqlParameter("@WDLX",KH_S.WDLX),
                                        new SqlParameter("@SFBZWD",KH_S.SFBZWD),
                                        new SqlParameter("@MDJCSL",string.IsNullOrEmpty(KH_S.MDJCSL)?"":KH_S.MDJCSL),
                                        new SqlParameter("@ZBDZ",string.IsNullOrEmpty(KH_S.ZBDZ)?"":KH_S.ZBDZ),
                                        new SqlParameter("@MCLC",KH_S.MCLC),
                                        new SqlParameter("@MDDZ",string.IsNullOrEmpty(KH_S.MDDZ)?"":KH_S.MDDZ),
                                        new SqlParameter("@JCDPSL",string.IsNullOrEmpty(KH_S.JCDPSL)?"":KH_S.JCDPSL),
                                        new SqlParameter("@FID",KH_S.FID),
                                        new SqlParameter("@FDATE",string.IsNullOrEmpty(KH_S.FDATE)?"":KH_S.FDATE),
                                        new SqlParameter("@FTID",string.IsNullOrEmpty(KH_S.FTID)?"":KH_S.FTID),
                                        new SqlParameter("@FGLDYJ",string.IsNullOrEmpty(KH_S.FGLDYJ)?"":KH_S.FGLDYJ),
                                        new SqlParameter("@XSZJYJ",string.IsNullOrEmpty(KH_S.XSZJYJ)?"":KH_S.XSZJYJ),
                                        new SqlParameter("@ISACTIVE",KH_S.ISACTIVE),
                                        new SqlParameter("@BEIZ",string.IsNullOrEmpty(KH_S.BEIZ)?"":KH_S.BEIZ),
                                        new SqlParameter("@XYDJ",string.IsNullOrEmpty(KH_S.XYDJ)?"":KH_S.XYDJ),
                                        new SqlParameter("@KHGM",string.IsNullOrEmpty(KH_S.KHGM)?"":KH_S.KHGM),
                                        new SqlParameter("@DZ",string.IsNullOrEmpty(KH_S.DZ)?"":KH_S.DZ),
                                        new SqlParameter("@KDJSDZ",string.IsNullOrEmpty(KH_S.KDJSDZ)?"":KH_S.KDJSDZ),
                                        new SqlParameter("@KDLXR",string.IsNullOrEmpty(KH_S.KDLXR)?"":KH_S.KDLXR),
                                        new SqlParameter("@KDLXDH",string.IsNullOrEmpty(KH_S.KDLXDH)?"":KH_S.KDLXDH),
                                        new SqlParameter("@KHSHDZ",string.IsNullOrEmpty(KH_S.KHSHDZ)?"":KH_S.KHSHDZ),
                                        new SqlParameter("@KHSHLXR",string.IsNullOrEmpty(KH_S.KHSHLXR)?"":KH_S.KHSHLXR),
                                        new SqlParameter("@KHSHLXDH",string.IsNullOrEmpty(KH_S.KHSHLXDH)?"":KH_S.KHSHLXDH),
                                        new SqlParameter("@SFCCJSM",string.IsNullOrEmpty(KH_S.SFCCJSM)?"":KH_S.SFCCJSM),
                                        new SqlParameter("@ISDELETE",KH_S.ISDELETE),
                                        new SqlParameter("@isKHID",isKHID),
                                        new SqlParameter("@IsOfficial",KH_S.IsOfficial),
                                        new SqlParameter("@FLSJSM",KH_S.FLSJSM),
                                        new SqlParameter("@KHLX2",KH_S.KHLX2),
                                        new SqlParameter("@KHSOURCE",KH_S.KHSOURCE),
                                        new SqlParameter("@KHJS",KH_S.KHJS),
                                        new SqlParameter("@PP",KH_S.PP),
                                        new SqlParameter("@PPOWNER",KH_S.PPOWNER),
                                        new SqlParameter("@FACTORY",KH_S.FACTORY),
                                        new SqlParameter("@FIRSTAMOUNT",KH_S.FIRSTAMOUNT),
                                        new SqlParameter("@JOINACTIVITY",KH_S.JOINACTIVITY),
                                        new SqlParameter("@FIRSTTIME",KH_S.FIRSTTIME),
                                        new SqlParameter("@PSQK",KH_S.PSQK),
                                        new SqlParameter("@FSFW",KH_S.FSFW),
                                        new SqlParameter("@MANAGEWAY",KH_S.MANAGEWAY),
                                        new SqlParameter("@PAYWAY",KH_S.PAYWAY),
                                        new SqlParameter("@GSLXRZW",KH_S.GSLXRZW),
                                        new SqlParameter("@SUPPORTOTHER",KH_S.SUPPORTOTHER),
                                        new SqlParameter("@ISNEW",KH_S.ISNEW),
                                        new SqlParameter("@PACT",KH_S.PACT),
                                        new SqlParameter("@BELONGKA",KH_S.BELONGKA),
                                        new SqlParameter("@WEBSITE",KH_S.WEBSITE),
                                        new SqlParameter("@ACCOUNT",KH_S.ACCOUNT),
                                        new SqlParameter("@YYZT",KH_S.YYZT),
                                        new SqlParameter("@GDSJ",KH_S.GDSJ),
                                        new SqlParameter("@GC",KH_S.GC),
                                        new SqlParameter("@KCDD",KH_S.KCDD)
                                   };
            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Update, parms))
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

        public int UpdateSFCS(CRM_KH_KH KH)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KHID",KH.KHID),
                                        new SqlParameter("@SF",KH.SF),
                                        new SqlParameter("@CS",KH.CS),
                                        new SqlParameter("@COUNTY",KH.COUNTY)
                                   };
            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UpdateSFCS, parms))
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

        public IList<CRM_KH_KH> Read(CRM_KH_KH keywords)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHLX",keywords.KHLX),
                                       new SqlParameter("@MC",keywords.MC),
                                       new SqlParameter("@MCSX",keywords.MCSX),
                                       new SqlParameter("@ISACTIVE",keywords.ISACTIVE),
                                       new SqlParameter("@MC_ALL",keywords.MC_ALL),
                                       new SqlParameter("@MDDZ",keywords.MDDZ),
                                       new SqlParameter("@GSLXDH",keywords.GSLXDH)
                                   };
            IList<CRM_KH_KH> nodes = new List<CRM_KH_KH>();

            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByPARMS, parms))
                {
                    while (sdr.Read())
                    {


                        nodes.Add(ReadDataToObject(sdr));
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public CRM_KH_KHList Read(int KHID)
        {

            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID)
                                   };
            CRM_KH_KHList node = new CRM_KH_KHList();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByKHID, parms))
                {
                    if (sdr.Read())
                    {
                        node = ReadDataToObjectList(sdr, 1);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return node;
        }

        public CRM_KH_KH ReadBySAPSN(string SAPSN)
        {

            SqlParameter[] parms = {
                                       new SqlParameter("@SAPSN",SAPSN)
                                   };
            CRM_KH_KH node = new CRM_KH_KH();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadBySAPSN, parms))
                {
                    if (sdr.Read())
                    {
                        node = ReadDataToObject(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return node;
        }

        public CRM_KH_KH ReadByCRMID(string CRMID)
        {
            SqlParameter[] parm = {
                                      new SqlParameter("@CRMID",CRMID)
                                  };
            CRM_KH_KH node = new CRM_KH_KH();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByCRMID, parm))
                {
                    if (sdr.Read())
                    {
                        node = ReadDataToObject(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return node;
        }
        public IList<CRM_KH_KH_INFO> ReadBF_KHList(CRM_KH_KH_PARAM model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHLX",model.KHLX),
                                       new SqlParameter("@KHID",model.KHID),
                                       new SqlParameter("@MC",model.MC),
                                       new SqlParameter("@SAPSN",model.SAPSN),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@JD",model.JD),
                                       new SqlParameter("@WD",model.WD),
                                       new SqlParameter("@DISTANCE",model.MULTIPLE*FIXED)
                                   };
            IList<CRM_KH_KH_INFO> nodes = new List<CRM_KH_KH_INFO>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadKH_ForBF, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToInfoObject(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }




        public IList<string> ReadXSZZ()
        {
            IList<string> nodes = new List<string>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadXSZZ, null))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(Convert.ToString(sdr["XSZZ"]));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }



        public IList<CRM_KH_BankList> Blank_Report(int SFID, int CSID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@DICID",CSID),
                                       new SqlParameter("@FID",SFID)
            
                                   };
            SqlParameter[] parmsQD = {
                                         new SqlParameter("@KHID",SqlDbType.Int)
                                     };

            IList<CRM_KH_BankList> nodes = new List<CRM_KH_BankList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_KH_Blank_Report, parms))
                {
                    while (sdr.Read())
                    {
                        CRM_KH_BankList node = new CRM_KH_BankList();
                        node.FID = Convert.ToInt32(sdr["FID"]);
                        node.FIDDES = Convert.ToString(sdr["FIDDES"]);
                        node.MC = Convert.ToString(sdr["MC"]);
                        node.CRMID = Convert.ToString(sdr["CRMID"]);
                        node.HTXSRW = Convert.ToString(sdr["HTXSRW"]);
                        node.DICID = Convert.ToInt32(sdr["DICID"]);
                        node.DICIDDES = Convert.ToString(sdr["DICIDDES"]);
                        node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
                        int KHID = Convert.ToInt32(sdr["KHID"]);
                        parmsQD[0].Value = KHID;
                        string strArr;

                        int del1 = Convert.ToInt32(sdr["del1"]);
                        int del2 = Convert.ToInt32(sdr["del2"]);
                        int del3 = Convert.ToInt32(sdr["del3"]);
                        node.XXMC = "";

                        if (del1 == 3 && del2 == 0 && del3 == 1)
                        {

                            using (SqlDataReader sdrQD = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadXDByKHID, parmsQD))
                            {
                                while (sdrQD.Read())
                                {
                                    node.XXMC = node.XXMC + Convert.ToString(sdrQD["XXMC"]) + "|";
                                }
                            }
                            strArr = node.XXMC;
                            if (strArr.Length > 0)
                            {
                                node.XXMC = strArr.Substring(0, strArr.Length - 1);
                            }


                        }
                        else
                        {

                        }

                        if ((del1 == 3 && del2 == 0 && del3 == 1) || (del1 == -1 && del2 == 1 && del3 == -1))
                        {
                            nodes.Add(node);
                        }


                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public IList<string> Read()
        {
            IList<string> nodes = new List<string>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, null))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(Convert.ToString(sdr["SAPSN"]));

                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        public IList<CRM_KH_KHList> Report(CRM_Report_KHModel model, int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KHLX",model.KHLX),
                                        new SqlParameter("@CRMID",model.CRMID),
                                        new SqlParameter("@MC",model.MC),
                                        new SqlParameter("@SAPSN",model.SAPSN),
                                        new SqlParameter("@GID",model.GID),
                                        new SqlParameter("@SF",model.SF),
                                        new SqlParameter("@CS",model.CS),
                                        new SqlParameter("@XSZZ",model.XSZZ),
                                        new SqlParameter("@FID",model.FID),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                        new SqlParameter("@STAFFID",STAFFID),
                                        new SqlParameter("@PMC",model.PMC),
                                        new SqlParameter("@PCRMID",model.PCRMID),
                                        new SqlParameter("@IsOfficial",model.IsOfficial),
                                        new SqlParameter("@MCSX",model.MCSX),
                                        new SqlParameter("@STARTTIME",model.STARTTIME),
                                        new SqlParameter("@ENDTIME",model.ENDTIME),
                                        new SqlParameter("@IsDZS",model.IsDZS),
                                        new SqlParameter("@IsZXS",model.IsZXS),
                                        new SqlParameter("@HDMC",model.HDMC),
                                        new SqlParameter("@BEIZ",model.BEIZ),
                                        new SqlParameter("@DISPLAY_STATUS",model.DISPLAY_STATUS),
                                        new SqlParameter("@DISPLAYITEM",model.DISPLAYITEM),
                                        new SqlParameter("@HUODONG_STATUS",model.HUODONG_STATUS),
                                        new SqlParameter("@IncludePKH",model.IncludePKH)
                                   };

            IList<CRM_KH_KHList> nodes = new List<CRM_KH_KHList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObjectList(sdr, 10));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return nodes;
        }
        public IList<CRM_KH_KHList> Report_PLUS(CRM_Report_KHModel model, int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KHLX",model.KHLX),
                                        new SqlParameter("@CRMID",model.CRMID),
                                        new SqlParameter("@MC",model.MC),
                                        new SqlParameter("@SAPSN",model.SAPSN),
                                        new SqlParameter("@GID",model.GID),
                                        new SqlParameter("@SF",model.SF),
                                        new SqlParameter("@CS",model.CS),
                                        new SqlParameter("@XSZZ",model.XSZZ),
                                        new SqlParameter("@FID",model.FID),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                        new SqlParameter("@STAFFID",STAFFID),
                                        new SqlParameter("@PMC",model.PMC),
                                        new SqlParameter("@IsOfficial",model.IsOfficial)
                                   };

            IList<CRM_KH_KHList> nodes = new List<CRM_KH_KHList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report_PLUS, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObjectList(sdr, 100));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return nodes;
        }


        public IList<CRM_KH_KH_Report_ZDWDList> Report_ZDWD(CRM_KH_KH_Report_ZDWD model, int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CZSJ_BEGIN",model.CZSJ_BEGIN),
                                        new SqlParameter("@CZSJ_END",model.CZSJ_END),
                                        new SqlParameter("@KHZZSJ_BEGIN",model.KHZZSJ_BEGIN),
                                        new SqlParameter("@KHZZSJ_END",model.KHZZSJ_END),
                                        new SqlParameter("@STAFF",model.STAFF),
                                        new SqlParameter("@FGLD",model.FGLD),
                                        new SqlParameter("@SF",model.SF),
                                        new SqlParameter("@CS",model.CS),
                                        new SqlParameter("@JXSID",model.JXSID),
                                        new SqlParameter("@JXSNAME",model.JXSNAME),
                                        new SqlParameter("@JXSSAPSN",model.JXSSAPSN),
                                        new SqlParameter("@CRMID",model.CRMID),
                                        new SqlParameter("@MC",model.MC),
                                        new SqlParameter("@WDLX",model.WDLX),
                                        new SqlParameter("@PKHMC",model.PKHMC),
                                        new SqlParameter("@YOUXIAO",model.ISYX),
                                        new SqlParameter("@DZS",model.ISDZS),
                                        new SqlParameter("@HDMC",model.HDMC),
                                        new SqlParameter("@STAFFID",STAFFID),
                                        new SqlParameter("@DISPLAY_STATUS",model.DISPLAY_STATUS),
                                        new SqlParameter("@DISPLAYITEM",model.DISPLAYITEM),
                                        new SqlParameter("@HUODONG_STATUS",model.HUODONG_STATUS)
                                   };

            IList<CRM_KH_KH_Report_ZDWDList> nodes = new List<CRM_KH_KH_Report_ZDWDList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report_ZDWD, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToZDWDList(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return nodes;
        }


        public IList<CRM_KH_KH_Report_LKAList> Report_LKA(CRM_KH_KH_Report_LKA model, int STAFFID,int RightOn)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SF",model.SF),
                                        new SqlParameter("@CS",model.CS),
                                        new SqlParameter("@CZSJ_BEGIN",model.CZSJ_BEGIN),
                                        new SqlParameter("@CZSJ_END",model.CZSJ_END),
                                        new SqlParameter("@KHZZSJ_BEGIN",model.KHZZSJ_BEGIN),
                                        new SqlParameter("@KHZZSJ_END",model.KHZZSJ_END),
                                        new SqlParameter("@STAFF",model.STAFF),
                                        new SqlParameter("@JXSID",model.JXSID),
                                        new SqlParameter("@JXSNAME",model.JXSNAME),
                                        new SqlParameter("@JXSSAPSN",model.JXSSAPSN),
                                        new SqlParameter("@PKHCRMID",model.PKHCRMID),
                                        new SqlParameter("@PKHMC",model.PKHMC),
                                        new SqlParameter("@MDJCSL",model.MDJCSL),
                                        new SqlParameter("@PKHMDDZ",model.PKHMDDZ),
                                        new SqlParameter("@CRMID",model.CRMID),
                                        new SqlParameter("@MC",model.MC),
                                        new SqlParameter("@ISYX",model.ISYX),
                                        new SqlParameter("@STAFFID",STAFFID),
                                        new SqlParameter("@RightOn",RightOn),
                                        new SqlParameter("@DISPLAY_STATUS",model.DISPLAY_STATUS),
                                        new SqlParameter("@DISPLAYITEM",model.DISPLAYITEM)
                                   };

            IList<CRM_KH_KH_Report_LKAList> nodes = new List<CRM_KH_KH_Report_LKAList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report_LKA, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToLKAList(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return nodes;
        }


        public int Delete(int KHID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID)
                                   };
            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Delete, parms))
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




        public int DeleteSDF(string SAPSN)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@SAPSN",SAPSN)
                                   };
            return SQLServerHelper.ExecuteNonQuery(CommandType.Text, SQL_DeleteSDF, parms);
        }

        public IList<CRM_KH_KHList> ReadBySTAFFID(int STAFFID)
        {

            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
            IList<CRM_KH_KHList> nodes = new List<CRM_KH_KHList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadBySTAFFID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObjectList(sdr,1));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public CRM_KH_KH ReadJXSByKHID(int KHID)
        {

            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID)
                                   };
            CRM_KH_KH node = new CRM_KH_KH();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadJXSByKHID, parms))
                {
                    while (sdr.Read())
                    {
                        node = ReadDataToObject(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return node;
        }

        public IList<CRM_KH_KH> ReadByJXS(CRM_KH_KH model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHLX",model.KHLX),
                                       new SqlParameter("@KHID",model.KHID),
                                   };

            IList<CRM_KH_KH> nodes = new List<CRM_KH_KH>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByJXS, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObject(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        public IList<CRM_KH_KHList> ReadUser_KH(CRM_Report_KHModel model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHLX",model.KHLX),
                                       new SqlParameter("@CRMID",model.CRMID),
                                       new SqlParameter("@MC",model.MC),
                                       new SqlParameter("@SAPSN",model.SAPSN),
                                       new SqlParameter("@GID",model.GID)
                                   };

            IList<CRM_KH_KHList> nodes = new List<CRM_KH_KHList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadUser_KH, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObjectList(sdr,1));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_KH_KH> ReadSDFbyPKH(string SAPSN)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@SAPSN",SAPSN)
                                   };

            IList<CRM_KH_KH> nodes = new List<CRM_KH_KH>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadSDFbyPKH, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObject(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_KH_KHList> ReadKHAcount(CRM_Report_KHModel model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KHLX",model.KHLX),
                                        new SqlParameter("@CRMID",model.CRMID),
                                        new SqlParameter("@MC",model.MC),
                                        new SqlParameter("@SAPSN",model.SAPSN),
                                        new SqlParameter("@GID",model.GID),
                                        new SqlParameter("@PMC",model.PMC),
                                        new SqlParameter("@PCRMID",model.PCRMID),
                                        new SqlParameter("@IsOfficial",model.IsOfficial)
                                   };

            IList<CRM_KH_KHList> nodes = new List<CRM_KH_KHList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadKHAcount, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadAccountDataToObjectList(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return nodes;
        }




        private CRM_KH_KH ReadDataToObject(SqlDataReader sdr)
        {
            CRM_KH_KH node = new CRM_KH_KH();
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);
            node.PKHID = Convert.ToInt32(sdr["PKHID"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.SAPKHLX = Convert.ToString(sdr["SAPKHLX"]);
            //  node.SAPSJ = (Convert.ToDateTime(sdr["SAPSJ"])).ToString("yyyy-MM-dd");
            node.SAPSJ = Convert.ToString(sdr["SAPSJ"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.GJ = Convert.ToInt32(sdr["GJ"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.COUNTY = Convert.ToInt32(sdr["COUNTY"]);
            //node.KHZZSJ = (Convert.ToDateTime(sdr["KHZZSJ"])).ToString("yyyy-MM-dd");
            node.KHZZSJ = Convert.ToString(sdr["KHZZSJ"]);
            node.SFZXS = Convert.ToBoolean(sdr["SFZXS"]);
            node.GSLXR = Convert.ToString(sdr["GSLXR"]);
            node.GSLXDH = Convert.ToString(sdr["GSLXDH"]);
            node.KPXZ = Convert.ToInt32(sdr["KPXZ"]);
            node.KPDZ = Convert.ToString(sdr["KPDZ"]);
            node.KPDH = Convert.ToString(sdr["KPDH"]);
            node.NSRSBH = Convert.ToString(sdr["NSRSBH"]);
            node.YHZH = Convert.ToString(sdr["YHZH"]);
            node.YHMC = Convert.ToString(sdr["YHMC"]);
            node.FKTJ = Convert.ToString(sdr["FKTJ"]);
            node.FR = Convert.ToString(sdr["FR"]);
            node.FRLXFS = Convert.ToString(sdr["FRLXFS"]);
            node.GSFRGX = Convert.ToString(sdr["GSFRGX"]);
            node.HTXSRW = Convert.ToString(sdr["HTXSRW"]);
            node.HTJXXSRW = Convert.ToString(sdr["HTJXXSRW"]);
            node.XSSJSM = Convert.ToString(sdr["XSSJSM"]);
            node.SFCCJ = Convert.ToBoolean(sdr["SFCCJ"]);
            node.SFCCJSM = Convert.ToString(sdr["SFCCJSM"]);
            node.TSQKSM = Convert.ToString(sdr["TSQKSM"]);
            node.JXSYX = Convert.ToBoolean(sdr["JXSYX"]);
            node.YXSM = Convert.ToString(sdr["YXSM"]);
            node.WDLX = Convert.ToInt32(sdr["WDLX"]);
            node.SFBZWD = Convert.ToBoolean(sdr["SFBZWD"]);
            node.MDJCSL = Convert.ToString(sdr["MDJCSL"]);
            node.ZBDZ = Convert.ToString(sdr["ZBDZ"]);
            node.MCLC = Convert.ToInt32(sdr["MCLC"]);
            node.MCSX = Convert.ToInt32(sdr["MCSX"]);
            node.MDDZ = Convert.ToString(sdr["MDDZ"]);
            node.JCDPSL = Convert.ToString(sdr["JCDPSL"]);
            node.FID = Convert.ToInt32(sdr["FID"]);
            node.FDATE = (Convert.ToDateTime(sdr["FDATE"])).ToString("yyyy-MM-dd");
            node.FTID = Convert.ToString(sdr["FTID"]);
            node.FGLDYJ = Convert.ToString(sdr["FGLDYJ"]);
            node.XSZJYJ = Convert.ToString(sdr["XSZJYJ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.XYDJ = Convert.ToString(sdr["XYDJ"]);
            node.KHGM = Convert.ToString(sdr["KHGM"]);
            node.DZ = Convert.ToString(sdr["DZ"]);
            node.KDJSDZ = Convert.ToString(sdr["KDJSDZ"]);
            node.KDLXR = Convert.ToString(sdr["KDLXR"]);
            node.KDLXDH = Convert.ToString(sdr["KDLXDH"]);
            node.KHSHDZ = Convert.ToString(sdr["KHSHDZ"]);
            node.KHSHLXR = Convert.ToString(sdr["KHSHLXR"]);
            node.KHSHLXDH = Convert.ToString(sdr["KHSHLXDH"]);
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);
            node.FLSJSM = Convert.ToString(sdr["FLSJSM"]);
            node.IsOfficial = Convert.ToInt32(sdr["IsOfficial"]);
            node.KHLX2 = Convert.ToInt32(sdr["KHLX2"]);
            node.KHSOURCE = Convert.ToInt32(sdr["KHSOURCE"]);
            node.KHJS = Convert.ToString(sdr["KHJS"]);
            node.PP = Convert.ToString(sdr["PP"]);
            node.PPOWNER = Convert.ToString(sdr["PPOWNER"]);
            node.FACTORY = Convert.ToString(sdr["FACTORY"]);
            node.FIRSTAMOUNT = Convert.ToString(sdr["FIRSTAMOUNT"]);
            node.JOINACTIVITY = Convert.ToInt32(sdr["JOINACTIVITY"]);
            node.FIRSTTIME = Convert.ToString(sdr["FIRSTTIME"]);
            node.PSQK = Convert.ToString(sdr["PSQK"]);
            node.FSFW = Convert.ToString(sdr["FSFW"]);
            node.MANAGEWAY = Convert.ToInt32(sdr["MANAGEWAY"]);
            node.PAYWAY = Convert.ToInt32(sdr["PAYWAY"]);
            node.GSLXRZW = Convert.ToInt32(sdr["GSLXRZW"]);
            node.SUPPORTOTHER = Convert.ToInt32(sdr["SUPPORTOTHER"]);
            node.ISNEW = Convert.ToInt32(sdr["ISNEW"]);
            node.PACT = Convert.ToInt32(sdr["PACT"]);
            node.BELONGKA = Convert.ToInt32(sdr["BELONGKA"]);
            node.WEBSITE = Convert.ToString(sdr["WEBSITE"]);
            node.ACCOUNT = Convert.ToString(sdr["ACCOUNT"]);
            node.YYZT = Convert.ToInt32(sdr["YYZT"]);
            node.GDSJ = Convert.ToString(sdr["GDSJ"]);
            node.GC = Convert.ToString(sdr["GC"]);
            node.KCDD = Convert.ToString(sdr["KCDD"]);
            return node;
        }

        private CRM_KH_KHList ReadDataToObjectList(SqlDataReader sdr, int isR)
        {
            CRM_KH_KHList node = new CRM_KH_KHList();

            node.PKHIDDES = string.IsNullOrEmpty(Convert.ToString(sdr["PKHIDDES"])) == true ? "" : Convert.ToString(sdr["PKHIDDES"]);

            node.CSDES = Convert.ToString(sdr["CSDES"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.COUNTYDES = Convert.ToString(sdr["COUNTYDES"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);
            node.PKHID = Convert.ToInt32(sdr["PKHID"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.SAPKHLX = Convert.ToString(sdr["SAPKHLX"]);
            //  node.SAPSJ = (Convert.ToDateTime(sdr["SAPSJ"])).ToString("yyyy-MM-dd");
            node.SAPSJ = Convert.ToString(sdr["SAPSJ"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.GJ = Convert.ToInt32(sdr["GJ"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.COUNTY = Convert.ToInt32(sdr["COUNTY"]);
            //node.KHZZSJ = (Convert.ToDateTime(sdr["KHZZSJ"])).ToString("yyyy-MM-dd");
            node.KHZZSJ = Convert.ToString(sdr["KHZZSJ"]);
            node.SFZXS = Convert.ToBoolean(sdr["SFZXS"]);
            node.GSLXR = Convert.ToString(sdr["GSLXR"]);
            node.GSLXDH = Convert.ToString(sdr["GSLXDH"]);
            node.KPXZ = Convert.ToInt32(sdr["KPXZ"]);
            node.KPDZ = Convert.ToString(sdr["KPDZ"]);
            node.KPDH = Convert.ToString(sdr["KPDH"]);
            node.NSRSBH = Convert.ToString(sdr["NSRSBH"]);
            node.YHZH = Convert.ToString(sdr["YHZH"]);
            node.YHMC = Convert.ToString(sdr["YHMC"]);
            node.FKTJ = Convert.ToString(sdr["FKTJ"]);
            node.FR = Convert.ToString(sdr["FR"]);
            node.FRLXFS = Convert.ToString(sdr["FRLXFS"]);
            node.GSFRGX = Convert.ToString(sdr["GSFRGX"]);
            node.HTXSRW = Convert.ToString(sdr["HTXSRW"]);
            node.HTJXXSRW = Convert.ToString(sdr["HTJXXSRW"]);
            node.XSSJSM = Convert.ToString(sdr["XSSJSM"]);
            node.SFCCJ = Convert.ToBoolean(sdr["SFCCJ"]);
            node.SFCCJSM = Convert.ToString(sdr["SFCCJSM"]);
            node.TSQKSM = Convert.ToString(sdr["TSQKSM"]);
            node.JXSYX = Convert.ToBoolean(sdr["JXSYX"]);
            node.YXSM = Convert.ToString(sdr["YXSM"]);
            node.WDLX = Convert.ToInt32(sdr["WDLX"]);
            node.SFBZWD = Convert.ToBoolean(sdr["SFBZWD"]);
            node.MDJCSL = Convert.ToString(sdr["MDJCSL"]);
            node.ZBDZ = Convert.ToString(sdr["ZBDZ"]);
            node.MCLC = Convert.ToInt32(sdr["MCLC"]);
            node.MCSX = Convert.ToInt32(sdr["MCSX"]);
            node.MDDZ = Convert.ToString(sdr["MDDZ"]);
            node.JCDPSL = Convert.ToString(sdr["JCDPSL"]);
            node.FID = Convert.ToInt32(sdr["FID"]);
            node.FDATE = (Convert.ToDateTime(sdr["FDATE"])).ToString("yyyy-MM-dd");
            node.FTID = Convert.ToString(sdr["FTID"]);
            node.FGLDYJ = Convert.ToString(sdr["FGLDYJ"]);
            node.XSZJYJ = Convert.ToString(sdr["XSZJYJ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.XYDJ = Convert.ToString(sdr["XYDJ"]);
            node.KHGM = Convert.ToString(sdr["KHGM"]);
            node.DZ = Convert.ToString(sdr["DZ"]);
            node.KDJSDZ = Convert.ToString(sdr["KDJSDZ"]);
            node.KDLXR = Convert.ToString(sdr["KDLXR"]);
            node.KDLXDH = Convert.ToString(sdr["KDLXDH"]);
            node.KHSHDZ = Convert.ToString(sdr["KHSHDZ"]);
            node.KHSHLXR = Convert.ToString(sdr["KHSHLXR"]);
            node.KHSHLXDH = Convert.ToString(sdr["KHSHLXDH"]);
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);
            node.GIDSTATUS = 0;
            node.GIDSTATUS = 0;
            node.YWYList = "";
            node.PSAPSN = "";
            node.FLSJSM = Convert.ToString(sdr["FLSJSM"]);
            node.IsOfficial = Convert.ToInt32(sdr["IsOfficial"]);
            node.CZR = Convert.ToInt32(sdr["CZR"]);
            node.CZSJ = Convert.ToDateTime(sdr["CZSJ"]).ToString("yyyy-MM-dd");
            node.KHLX2 = Convert.ToInt32(sdr["KHLX2"]);
            node.KHSOURCE = Convert.ToInt32(sdr["KHSOURCE"]);
            node.KHJS = Convert.ToString(sdr["KHJS"]);
            node.PP = Convert.ToString(sdr["PP"]);
            node.PPOWNER = Convert.ToString(sdr["PPOWNER"]);
            node.FACTORY = Convert.ToString(sdr["FACTORY"]);
            node.FIRSTAMOUNT = Convert.ToString(sdr["FIRSTAMOUNT"]);
            node.JOINACTIVITY = Convert.ToInt32(sdr["JOINACTIVITY"]);
            node.FIRSTTIME = Convert.ToString(sdr["FIRSTTIME"]);
            node.PSQK = Convert.ToString(sdr["PSQK"]);
            node.FSFW = Convert.ToString(sdr["FSFW"]);
            node.MANAGEWAY = Convert.ToInt32(sdr["MANAGEWAY"]);
            node.PAYWAY = Convert.ToInt32(sdr["PAYWAY"]);
            node.GSLXRZW = Convert.ToInt32(sdr["GSLXRZW"]);
            node.SUPPORTOTHER = Convert.ToInt32(sdr["SUPPORTOTHER"]);
            node.ISNEW = Convert.ToInt32(sdr["ISNEW"]);
            node.PACT = Convert.ToInt32(sdr["PACT"]);
            node.BELONGKA = Convert.ToInt32(sdr["BELONGKA"]);
            node.WEBSITE = Convert.ToString(sdr["WEBSITE"]);
            node.ACCOUNT = Convert.ToString(sdr["ACCOUNT"]);
            node.YYZT = Convert.ToInt32(sdr["YYZT"]);
            node.GDSJ = Convert.ToString(sdr["GDSJ"]);
            node.GC = Convert.ToString(sdr["GC"]);
            node.KCDD = Convert.ToString(sdr["KCDD"]);
            if (isR == 10)
            {
                node.GIDSTATUS = Convert.ToInt32(sdr["GIDSTATUS"]);
                //node.JD = Convert.ToString(sdr["JD"]);
                //node.ED = Convert.ToString(sdr["ED"]);
                node.PSAPSN = Convert.ToString(sdr["PSAPSN"]);
                node.CZRDES = Convert.ToString(sdr["CZRDES"]);
                node.KHLX2DES = Convert.ToString(sdr["KHLX2DES"]);
                node.KHSOURCEDES = Convert.ToString(sdr["KHSOURCEDES"]);
                node.MANAGEWAYDES = Convert.ToString(sdr["MANAGEWAYDES"]);
                node.PAYWAYDES = Convert.ToString(sdr["PAYWAYDES"]);
                node.GSLXRZWDES = Convert.ToString(sdr["GSLXRZWDES"]);
                node.KHLXDES = Convert.ToString(sdr["KHLXDES"]);
            }
            if (isR == 100)
            {
                node.GIDSTATUS = Convert.ToInt32(sdr["GIDSTATUS"]);
                node.YWYList = Convert.ToString(sdr["YWYList"]);

            }

            return node;
        }

        private CRM_KH_KH_Report_ZDWDList ReadDataToZDWDList(SqlDataReader sdr)
        {
            CRM_KH_KH_Report_ZDWDList node = new CRM_KH_KH_Report_ZDWDList();
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.CZSJ = (Convert.ToDateTime(sdr["CZSJ"])).ToString("yyyy-MM-dd");
            node.KHZZSJ = Convert.ToString(sdr["KHZZSJ"]);
            node.STAFF = Convert.ToString(sdr["STAFFNAME"]);
            node.FGLD = Convert.ToString(sdr["FGLDNAME"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);
            node.JXSID = Convert.ToString(sdr["JXSID"]);
            node.JXSNAME = Convert.ToString(sdr["JXSNAME"]);
            node.JXSSAPSN = Convert.ToString(sdr["JXSSAPSN"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.MDDZ = Convert.ToString(sdr["MDDZ"]);
            node.QDDZ = Convert.ToString(sdr["QDDZ"]);
            node.QDDZSOURCE = Convert.ToString(sdr["QDDZSOURCE"]);
            node.GSLXR = Convert.ToString(sdr["GSLXR"]);
            node.GSLXDH = Convert.ToString(sdr["GSLXDH"]);
            node.WDLX = Convert.ToInt32(sdr["WDLX"]);
            node.WDLXDES = Convert.ToString(sdr["WDLXDES"]);
            node.CZR = Convert.ToInt32(sdr["CZR"]);
            node.CZRDES = Convert.ToString(sdr["CZRDES"]);
            node.PKHMC = Convert.ToString(sdr["PKHMC"]);
            node.IMG_MT = Convert.ToInt32(sdr["IMG_MT"]);
            node.MT_SOURCE = Convert.ToString(sdr["MT_SOURCE"]);
            node.DISPLAY = Convert.ToString(sdr["DISPLAY"]);
            node.XSPZ = Convert.ToString(sdr["XSPZ"]);
            node.JINGPIN = Convert.ToString(sdr["JINGPIN"]);
            node.ISBZ = Convert.ToInt32(sdr["ISBZ"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISYX = Convert.ToInt32(sdr["ISYX"]);
            node.XL = Convert.ToString(sdr["XL"]);
            node.SM = Convert.ToString(sdr["SM"]);
            node.ISDZS = Convert.ToInt32(sdr["ISDZS"]);
            node.XYPP = Convert.ToString(sdr["XYPP"]);
            node.HDMC = Convert.ToString(sdr["HD"]);
            node.BFCS = Convert.ToInt32(sdr["BFCS"]);
            node.ISYC = Convert.ToString(sdr["ISYC"]);
            node.BF_MT = Convert.ToInt32(sdr["BF_MT"]);
            node.BFMT_SOURCE = Convert.ToString(sdr["BFMT_SOURCE"]);
            node.BF_DISPLAY = Convert.ToInt32(sdr["BF_DISPLAY"]);
            node.BFDISPLAY_SOURCE = Convert.ToString(sdr["BFDISPLAY_SOURCE"]);
            node.ImgSPcount = Convert.ToInt32(sdr["ImgSPcount"]);
            node.DisplayItemCount = Convert.ToInt32(sdr["DisplayItemCount"]);
            return node;
        }


        private CRM_KH_KH_Report_LKAList ReadDataToLKAList(SqlDataReader sdr)
        {
            CRM_KH_KH_Report_LKAList node = new CRM_KH_KH_Report_LKAList();
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);
            node.CZSJ = (Convert.ToDateTime(sdr["CZSJ"])).ToString("yyyy-MM-dd");
            node.KHZZSJ = Convert.ToString(sdr["KHZZSJ"]);
            node.STAFF = Convert.ToString(sdr["STAFFNAME"]);
            node.JXSID = Convert.ToString(sdr["JXSID"]);
            node.JXSNAME = Convert.ToString(sdr["JXSNAME"]);
            node.JXSSAPSN = Convert.ToString(sdr["JXSSAPSN"]);
            node.PKHCRMID = Convert.ToString(sdr["PKHCRMID"]);
            node.PKHMC = Convert.ToString(sdr["PKHMC"]);
            node.MDJCSL = Convert.ToString(sdr["MDJCSL"]);
            node.PKHMDDZ = Convert.ToString(sdr["PKHMDDZ"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.MCLC = Convert.ToInt32(sdr["MCLC"]);
            node.MCLCDES = Convert.ToString(sdr["MCLCDES"]);
            node.MDDZ = Convert.ToString(sdr["MDDZ"]);
            node.CZR = Convert.ToInt32(sdr["CZR"]);
            node.CZRDES = Convert.ToString(sdr["CZRDES"]);
            node.QDDZ = Convert.ToString(sdr["QDDZ"]);
            node.QDDZSOURCE = Convert.ToString(sdr["QDDZSOURCE"]);
            node.JCDPSL = Convert.ToString(sdr["JCDPSL"]);
            node.XSSJSM = Convert.ToString(sdr["XSSJSM"]);
            node.JINGPIN = Convert.ToString(sdr["JINGPIN"]);
            node.IMG_MT = Convert.ToInt32(sdr["IMG_MT"]);
            node.MT_SOURCE = Convert.ToString(sdr["MT_SOURCE"]);
            node.DISPLAY = Convert.ToString(sdr["DISPLAY"]);
            node.DISPLAY2 = Convert.ToString(sdr["DISPLAY2"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISYX = Convert.ToInt32(sdr["ISYX"]);
            node.XL = Convert.ToString(sdr["XL"]);
            node.SM = Convert.ToString(sdr["SM"]);
            node.BFCS = Convert.ToInt32(sdr["BFCS"]);
            node.ISYC = Convert.ToString(sdr["ISYC"]);
            node.BF_MT = Convert.ToInt32(sdr["BF_MT"]);
            node.BFMT_SOURCE = Convert.ToString(sdr["BFMT_SOURCE"]);
            node.BF_DISPLAY = Convert.ToInt32(sdr["BF_DISPLAY"]);
            node.BFDISPLAY_SOURCE = Convert.ToString(sdr["BFDISPLAY_SOURCE"]);
            node.ImgSPcount = Convert.ToInt32(sdr["ImgSPcount"]);
            node.DisplayItemCount = Convert.ToInt32(sdr["DisplayItemCount"]);
            return node;
        }

        private CRM_KH_KHList ReadAccountDataToObjectList(SqlDataReader sdr)
        {
            CRM_KH_KHList node = new CRM_KH_KHList();

            node.PKHIDDES = string.IsNullOrEmpty(Convert.ToString(sdr["PKHIDDES"])) == true ? "" : Convert.ToString(sdr["PKHIDDES"]);

            node.CSDES = Convert.ToString(sdr["CSDES"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.COUNTYDES = Convert.ToString(sdr["COUNTYDES"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);
            node.PKHID = Convert.ToInt32(sdr["PKHID"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.SAPKHLX = Convert.ToString(sdr["SAPKHLX"]);
            //  node.SAPSJ = (Convert.ToDateTime(sdr["SAPSJ"])).ToString("yyyy-MM-dd");
            node.SAPSJ = Convert.ToString(sdr["SAPSJ"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.GJ = Convert.ToInt32(sdr["GJ"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.COUNTY = Convert.ToInt32(sdr["COUNTY"]);
            //node.KHZZSJ = (Convert.ToDateTime(sdr["KHZZSJ"])).ToString("yyyy-MM-dd");
            node.KHZZSJ = Convert.ToString(sdr["KHZZSJ"]);
            node.SFZXS = Convert.ToBoolean(sdr["SFZXS"]);
            node.GSLXR = Convert.ToString(sdr["GSLXR"]);
            node.GSLXDH = Convert.ToString(sdr["GSLXDH"]);
            node.KPXZ = Convert.ToInt32(sdr["KPXZ"]);
            node.KPDZ = Convert.ToString(sdr["KPDZ"]);
            node.KPDH = Convert.ToString(sdr["KPDH"]);
            node.NSRSBH = Convert.ToString(sdr["NSRSBH"]);
            node.YHZH = Convert.ToString(sdr["YHZH"]);
            node.YHMC = Convert.ToString(sdr["YHMC"]);
            node.FKTJ = Convert.ToString(sdr["FKTJ"]);
            node.FR = Convert.ToString(sdr["FR"]);
            node.FRLXFS = Convert.ToString(sdr["FRLXFS"]);
            node.GSFRGX = Convert.ToString(sdr["GSFRGX"]);
            node.HTXSRW = Convert.ToString(sdr["HTXSRW"]);
            node.HTJXXSRW = Convert.ToString(sdr["HTJXXSRW"]);
            node.XSSJSM = Convert.ToString(sdr["XSSJSM"]);
            node.SFCCJ = Convert.ToBoolean(sdr["SFCCJ"]);
            node.SFCCJSM = Convert.ToString(sdr["SFCCJSM"]);
            node.TSQKSM = Convert.ToString(sdr["TSQKSM"]);
            node.JXSYX = Convert.ToBoolean(sdr["JXSYX"]);
            node.YXSM = Convert.ToString(sdr["YXSM"]);
            node.WDLX = Convert.ToInt32(sdr["WDLX"]);
            node.SFBZWD = Convert.ToBoolean(sdr["SFBZWD"]);
            node.MDJCSL = Convert.ToString(sdr["MDJCSL"]);
            node.ZBDZ = Convert.ToString(sdr["ZBDZ"]);
            node.MCLC = Convert.ToInt32(sdr["MCLC"]);
            node.MCSX = Convert.ToInt32(sdr["MCSX"]);
            node.MDDZ = Convert.ToString(sdr["MDDZ"]);
            node.JCDPSL = Convert.ToString(sdr["JCDPSL"]);
            node.FID = Convert.ToInt32(sdr["FID"]);
            node.FDATE = (Convert.ToDateTime(sdr["FDATE"])).ToString("yyyy-MM-dd");
            node.FTID = Convert.ToString(sdr["FTID"]);
            node.FGLDYJ = Convert.ToString(sdr["FGLDYJ"]);
            node.XSZJYJ = Convert.ToString(sdr["XSZJYJ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.XYDJ = Convert.ToString(sdr["XYDJ"]);
            node.KHGM = Convert.ToString(sdr["KHGM"]);
            node.DZ = Convert.ToString(sdr["DZ"]);
            node.KDJSDZ = Convert.ToString(sdr["KDJSDZ"]);
            node.KDLXR = Convert.ToString(sdr["KDLXR"]);
            node.KDLXDH = Convert.ToString(sdr["KDLXDH"]);
            node.KHSHDZ = Convert.ToString(sdr["KHSHDZ"]);
            node.KHSHLXR = Convert.ToString(sdr["KHSHLXR"]);
            node.KHSHLXDH = Convert.ToString(sdr["KHSHLXDH"]);
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);
            node.GIDSTATUS = 0;
            node.GIDSTATUS = 0;
            node.YWYList = "";
            node.PSAPSN = "";
            node.FLSJSM = Convert.ToString(sdr["FLSJSM"]);
            node.IsOfficial = Convert.ToInt32(sdr["IsOfficial"]);
            node.CZR = Convert.ToInt32(sdr["CZR"]);
            node.CZSJ = Convert.ToDateTime(sdr["CZSJ"]).ToString("yyyy-MM-dd");
            node.KHLX2 = Convert.ToInt32(sdr["KHLX2"]);
            node.KHSOURCE = Convert.ToInt32(sdr["KHSOURCE"]);
            node.KHJS = Convert.ToString(sdr["KHJS"]);
            node.PP = Convert.ToString(sdr["PP"]);
            node.PPOWNER = Convert.ToString(sdr["PPOWNER"]);
            node.FACTORY = Convert.ToString(sdr["FACTORY"]);
            node.FIRSTAMOUNT = Convert.ToString(sdr["FIRSTAMOUNT"]);
            node.JOINACTIVITY = Convert.ToInt32(sdr["JOINACTIVITY"]);
            node.FIRSTTIME = Convert.ToString(sdr["FIRSTTIME"]);
            node.PSQK = Convert.ToString(sdr["PSQK"]);
            node.FSFW = Convert.ToString(sdr["FSFW"]);
            node.MANAGEWAY = Convert.ToInt32(sdr["MANAGEWAY"]);
            node.PAYWAY = Convert.ToInt32(sdr["PAYWAY"]);
            node.GSLXRZW = Convert.ToInt32(sdr["GSLXRZW"]);
            node.SUPPORTOTHER = Convert.ToInt32(sdr["SUPPORTOTHER"]);
            node.ISNEW = Convert.ToInt32(sdr["ISNEW"]);
            node.PACT = Convert.ToInt32(sdr["PACT"]);
            node.BELONGKA = Convert.ToInt32(sdr["BELONGKA"]);
            node.WEBSITE = Convert.ToString(sdr["WEBSITE"]);
            node.ACCOUNT = Convert.ToString(sdr["ACCOUNT"]);
            node.USERCOUNT = Convert.ToInt32(sdr["USERCOUNT"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            node.STAFFUSER = Convert.ToString(sdr["STAFFUSER"]);

            return node;
        }



        public int UpdateSAPSN(string CRMID, string SAPSN)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@CRMID",CRMID),
                                       new SqlParameter("@SAPSN",SAPSN)
                                   };
            try
            {
                return SQLServerHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_UpdateSapsn, parms);
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }



        }

        private SAP_KH ReadSapsnToInfoObject(SqlDataReader sdr)
        {
            SAP_KH node = new SAP_KH();
            node.KUNNR = Convert.ToString(sdr["SAPSN"]);
            //node.DISTANCE = Convert.ToDouble(sdr["DISTANCE"]);
            return node;
        }
        public int Verify(string SAPSN, string CRMID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@SAPSN",SAPSN),
                                       new SqlParameter("@CRMID",CRMID)
                                   };
            int no = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Verify, parms))
                {
                    if (sdr.Read())
                    {
                        no = Convert.ToInt32(sdr["ID"]);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return no;
        }



        public int Modify(SAP_KH model)
        {
            SqlParameter[] parms ={
                                        new SqlParameter("@SAPSN", model.KUNNR),
                                        new SqlParameter("@MC", model.NAME1),
                                        new SqlParameter("@SF", model.BEZEI),
                                        new SqlParameter("@CS", model.ORT01),
                                        new SqlParameter("@KPDZ", model.STREET),
                                        new SqlParameter("@KPDH", model.TEL_NUMBER),
                                        new SqlParameter("@NSRSBH", model.STCEG),
                                        new SqlParameter("@YHZH", model.YHZH),
                                        new SqlParameter("@YHMC", model.BANKA),
                                        new SqlParameter("@GSLXR", model.NAME2),
                                        new SqlParameter("@GSLXDH",model.TELF1)

                                  };
            int row = 0;
            try
            {
                row = SQLServerHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_Modify, parms);
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return row;

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

        private CRM_KH_KH_INFO ReadDataToInfoObject(SqlDataReader sdr)
        {
            CRM_KH_KH_INFO node = new CRM_KH_KH_INFO();
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.PKHID = Convert.ToInt32(sdr["PKHID"]);
            node.PKHIDDES = Convert.ToString(sdr["PKHIDDES"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);
            node.ED = Convert.ToDouble(sdr["ED"]);
            node.JD = Convert.ToDouble(sdr["JD"]);
            //node.DISTANCE = Convert.ToDouble(sdr["DISTANCE"]);
            return node;
        }



    }
}
