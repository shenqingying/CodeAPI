using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using Sonluk.IDataAccess.CRM;

namespace Sonluk.DataAccess.RMS.CRM
{
    public class CRM_KQ_Report : ICRM_KQ_Report
    {
        string SQL_KQ_InfoCollect = "CRM_KQ_InfoCollect";
        string SQl_CRM_KQ_REPORTSUMMARY = "CRM_KQ_REPORTSUMMARY";
        string SQL_CRM_KQ_Detail_QJ = "CRM_KQ_Detail_QJ";
        string SQL_CRM_KQ_Detail_CC = "CRM_KQ_Detail_CC";
        string SQL_CRM_KQ_Detail_YC = "CRM_KQ_Detail_YC";
        string SQL_CRM_KQ_Detail_QD = "CRM_KQ_Detail_QD";
        string SQL_CRM_KQ_Detail_QQ = "CRM_KQ_Detail_QQ";

        public IList<CRM_KQ_YGQJList> CRM_KQ_Detail_QJ(int STAFFID, string Begintime, string Endtime)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@Begintime",Begintime),
                                       new SqlParameter("@Endtime",Endtime)
                                   };
            IList<CRM_KQ_YGQJList> nodes = new List<CRM_KQ_YGQJList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_CRM_KQ_Detail_QJ, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToYGQJList(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_KQ_CCTTList> CRM_KQ_Detail_CC(int STAFFID, string Begintime, string Endtime)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@Begintime",Begintime),
                                       new SqlParameter("@Endtime",Endtime)
                                   };
            IList<CRM_KQ_CCTTList> nodes = new List<CRM_KQ_CCTTList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_CRM_KQ_Detail_CC, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToCCList(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;
        }
        public IList<CRM_KQ_YCKQSM> CRM_KQ_Detail_YC(int STAFFID, string Begintime, string Endtime)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@Begintime",Begintime),
                                       new SqlParameter("@Endtime",Endtime)
                                   };
            IList<CRM_KQ_YCKQSM> nodes = new List<CRM_KQ_YCKQSM>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_CRM_KQ_Detail_YC,parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToYCList(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }



            return nodes;
        }

        public IList<CRM_KQ_QDList> CRM_KQ_Detail_QD(int STAFFID, string Begintime, string Endtime)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@Begintime",Begintime),
                                       new SqlParameter("@Endtime",Endtime)
                                   };
            IList<CRM_KQ_QDList> nodes = new List<CRM_KQ_QDList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_CRM_KQ_Detail_QD, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToQDList(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }



            return nodes;
        }

        public IList<CRM_KQ_QQList> CRM_KQ_Detail_QQ(int STAFFID, string Begintime, string Endtime)
        {
            SqlParameter[] pamrs = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@Begintime",Begintime),
                                       new SqlParameter("@Endtime",Endtime)
                                   };
            IList<CRM_KQ_QQList> nodes = new List<CRM_KQ_QQList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_CRM_KQ_Detail_QQ, pamrs))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToQQList(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }



            return nodes;

        }











        public IList<CRM_KQ_COLLECTList> KQ_InfoCollect(int STAFFLX, string STAFFNAME, string STAFFNO, string beginTime, string endTime)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFLX",STAFFLX),
                                       new SqlParameter("@STAFFNAME",STAFFNAME),
                                       new SqlParameter("@STAFFNO",STAFFNO),
                                       new SqlParameter("@beginTime",beginTime),
                                       new SqlParameter("@endTime",endTime),
                                       
                                   };
            IList<CRM_KQ_COLLECTList> nodes = new List<CRM_KQ_COLLECTList>();
            IList<CRM_STAFF_QD> nodes_QD = new List<CRM_STAFF_QD>();
            IList<CRM_STAFF_GZRLMX> nodes_gzrl = new List<CRM_STAFF_GZRLMX>();
            IList<string> nodes_staff1 = new List<string>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_KQ_InfoCollect,parms))
                {
                    while (sdr.Read())
                    {
                        nodes_staff1.Add(Convert.ToString(sdr["STAFFID"]));

                        nodes_gzrl.Add(ReadDataToObject_GZRLMX(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            List<string> nodes_staff = nodes_staff1.Distinct().ToList();

            for (int i = 0; i < nodes_staff.Count; i++)
			{
			    
			}






            for (int i = 0; i < nodes_gzrl.Count; i++)
            {
                for (int j = 0; j < nodes_staff.Count; j++)
                {
                    CRM_STAFF_QD node = new CRM_STAFF_QD();
                    node.STAFFID = nodes_gzrl[i].STAFFID;
                    node.STAFFNAME = nodes_gzrl[i].STAFFNAME;
                    node.STAFFNO = nodes_gzrl[i].STAFFNO;
                    
                    if (Convert.ToInt32(nodes_staff[j]) == nodes_gzrl[i].STAFFID)
                    {
                       
                    }
                }
            }
            


                



            return nodes;
        }


        public IList<CRM_KQ_COLLECTList> CRM_KQ_REPORT_SUMMARY(int STAFFID,int STAFFLX, string STAFFNAME, string STAFFNO, string beginTime, string endTime,int DEPID,int OnlyQQ)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@STAFFLX",STAFFLX),
                                       new SqlParameter("@STAFFNAME",STAFFNAME),
                                       new SqlParameter("@STAFFNO",STAFFNO),
                                       new SqlParameter("@beginTime",beginTime),
                                       new SqlParameter("@endTime",endTime),
                                       new SqlParameter("@DEPID",DEPID),
                                       new SqlParameter("@OnlyQQ",OnlyQQ)
                                   };
            IList<CRM_KQ_COLLECTList> nodes = new List<CRM_KQ_COLLECTList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQl_CRM_KQ_REPORTSUMMARY,parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToCollectList(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }





            return nodes;
        }


















        private CRM_KQ_COLLECTList ReadDataToCollectList(SqlDataReader sdr )
        {
            CRM_KQ_COLLECTList node = new CRM_KQ_COLLECTList();
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            node.DAYCOUNTS = Convert.ToDouble(sdr["DAYCOUNTS"]);
            node.ZCDAYCOUNTS = Convert.ToDouble(sdr["ZCDAYCOUNTS"]);
            node.CCDAYCOUNTS = Convert.ToDouble(sdr["CCDAYCOUNTS"]);
            node.QJDAYCOUNTS = Convert.ToDouble(sdr["QJDAYCOUNTS"]);
            node.YCDAYCOUNTS = Convert.ToDouble(sdr["YCDAYCOUNTS"]);
            node.QQDAYCOUNTS = Convert.ToDouble(sdr["QQDAYCOUNTS"]);
            node.DEPNAME = Convert.ToString(sdr["DEPNAME"]);
            return node;
         
        }

        private CRM_STAFF_GZRLMX ReadDataToObject_GZRLMX(SqlDataReader sdr)
        {
            CRM_STAFF_GZRLMX node = new CRM_STAFF_GZRLMX();
            node.BBMXID = Convert.ToInt32(sdr["BBMXID"]);
            node.BBID = Convert.ToInt32(sdr["BBID"]);
            node.DATE = Convert.ToString(sdr["DATE"]);
            node.SFGZR = Convert.ToBoolean(sdr["SFGZR"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            return node;
        }


        private CRM_KQ_YGQJList ReadDataToYGQJList(SqlDataReader sdr)
        {
            CRM_KQ_YGQJList node = new CRM_KQ_YGQJList();
            node.DEPNAMEDES = Convert.ToString(sdr["DEPNAMEDES"]);
            node.QJLBDES = Convert.ToString(sdr["QJLBDES"]);
            node.YGQJID = Convert.ToInt32(sdr["YGQJID"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFSEX = Convert.ToString(sdr["STAFFSEX"]);
            node.DEPNAME = Convert.ToInt32(sdr["DEPNAME"]);
            node.QJLB = Convert.ToInt32(sdr["QJLB"]);
            node.QWHC = Convert.ToString(sdr["QWHC"]);
            node.JHQJKSSJ = Convert.ToString(sdr["JHQJKSSJ"]);
            node.JHQJJSSJ = Convert.ToString(sdr["JHQJJSSJ"]);
            node.QJTS = Convert.ToDouble(sdr["QJTS"]);
            node.SJQJTS = Convert.ToDouble(sdr["SJQJTS"]);
            node.ZZ = Convert.ToString(sdr["ZZ"]);
            node.BMLD = Convert.ToString(sdr["BMLD"]);
            node.ZGLD = Convert.ToString(sdr["ZGLD"]);
            node.ZZB = Convert.ToString(sdr["ZZB"]);
            node.SJQJKSSJ = Convert.ToString(sdr["SJQJKSSJ"]);
            node.SJJSKSSJ = Convert.ToString(sdr["SJJSKSSJ"]);
            node.XJRQ = Convert.ToString(sdr["XJRQ"]);
            node.XJZZ = Convert.ToString(sdr["XJZZ"]);
            node.QJR = Convert.ToString(sdr["QJR"]);
            node.QJRQ = Convert.ToString(sdr["QJRQ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);
            node.BZ = Convert.ToString(sdr["BZ"]);
            return node;
        }

        private CRM_KQ_CCTTList ReadDataToCCList(SqlDataReader sdr)
        {
            CRM_KQ_CCTTList node = new CRM_KQ_CCTTList();
            node.CCID = Convert.ToInt32(sdr["CCID"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.CCRNAME = Convert.ToString(sdr["CCRNAME"]);
            node.CCRBM = Convert.ToString(sdr["CCRBM"]);
            node.CCDD = Convert.ToString(sdr["CCDD"]);
            node.BQYCC = Convert.ToBoolean(sdr["BQYCC"]);
            node.ZCYWCC = Convert.ToBoolean(sdr["ZCYWCC"]);
            node.JHCCKSSJ = Convert.ToString(sdr["JHCCKSSJ"]);
            node.JHCCJSSJ = Convert.ToString(sdr["JHCCJSSJ"]);
            node.JHCCTS = Convert.ToDouble(sdr["JHCCTS"]);
            node.CXFS = Convert.ToInt32(sdr["CXFS"]);
            node.YJJE = Convert.ToDecimal(sdr["YJJE"]);
            node.QTCXFS = Convert.ToInt32(sdr["QTCXFS"]);
            node.QTCXFSJE = Convert.ToDecimal(sdr["QTCXFSJE"]);
            node.SJJE = Convert.ToDecimal(sdr["SJJE"]);
            node.SJKSSJ = Convert.ToString(sdr["SJKSSJ"]);
            node.SJCCJSSJ = Convert.ToString(sdr["SJCCJSSJ"]);
            node.CCSQR = Convert.ToString(sdr["CCSQR"]);
            node.CCSQSJ = Convert.ToString(sdr["CCSQSJ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);
            node.CXFSDES = Convert.ToString(sdr["CXFSDES"]);
            node.QTCXFSDES = Convert.ToString(sdr["QTCXFSDES"]);
            node.CCLX = Convert.ToInt32(sdr["CCLX"]);
            node.CCLXDES = Convert.ToString(sdr["CCLXDES"]);
            node.SJCCTS = Convert.ToDouble(sdr["SJCCTS"]);
            return node;
        }

        private CRM_KQ_YCKQSM ReadDataToYCList(SqlDataReader sdr)
        {
            CRM_KQ_YCKQSM node = new CRM_KQ_YCKQSM();
            node.YCKQID = Convert.ToInt32(sdr["YCKQID"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.SMR = Convert.ToString(sdr["SMR"]);
            node.SMRQ = Convert.ToString(sdr["SMRQ"]);
            node.SMSXB = Convert.ToInt32(sdr["SMSXB"]);
            node.SMRBMLD = Convert.ToString(sdr["SMRBMLD"]);
            node.SMRBMZG = Convert.ToString(sdr["SMRBMZG"]);
            node.SMSX = Convert.ToString(sdr["SMSX"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);

            return node;
        }

        private CRM_KQ_QDList ReadDataToQDList(SqlDataReader sdr)
        {
            CRM_KQ_QDList node = new CRM_KQ_QDList();
            node.KQQDID = Convert.ToInt32(sdr["KQQDID"]);
            node.QDGSIDDES = Convert.ToString(sdr["QDGSIDDES"]);
            node.QDLX = Convert.ToInt32(sdr["QDLX"]);
            node.QDGSID = Convert.ToInt32(sdr["QDGSID"]);
            node.QDGSHXMID = Convert.ToInt32(sdr["QDGSHXMID"]);
            node.SXB = Convert.ToInt32(sdr["SXB"]);
            node.QDSJ = Convert.ToString(sdr["QDSJ"]);
            node.GJ = Convert.ToInt32(sdr["GJ"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.QDWZ = Convert.ToString(sdr["QDWZ"]);
            node.QDJD = Convert.ToString(sdr["QDJD"]);
            node.QDWD = Convert.ToString(sdr["QDWD"]);
            //node.KQJL = Convert.ToString(sdr["KQJL"]);
            //node.KQJL = String.Format("{0:N2}", Convert.ToDecimal(sdr["KQJL"]).ToString());
            //node.KQJL = String.Format("{0:F}", Convert.ToDouble(sdr["KQJL"]));
            node.KQJL = Convert.ToString(sdr["KQJL"]).Split('.')[0];
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.QDGSHXMIDDES = Convert.ToString(sdr["QDGSHXMIDDES"]);
            return node;

           
            

        }


        private CRM_KQ_QQList ReadDataToQQList(SqlDataReader sdr)
        {
            CRM_KQ_QQList node = new CRM_KQ_QQList();
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.SBQD = Convert.ToInt32(sdr["SBQD"]);
            node.XBQD = Convert.ToInt32(sdr["XBQD"]);
            node.RQ = Convert.ToString(sdr["RQ"]);
            return node;
        }


    }
}
