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
    public class BF_BFDJ : IBF_BFDJ
    {
        enum TYPEEnum
        {
            KHBF = 1,
            BFJH = 2,
            QT = 3
        }
        private const string SQL_Create = "CRM_BF_BFDJ_Create";
        private const string SQL_Update = "CRM_BF_BFDJ_Update";
        private const string SQL_ReadByBFDJID = "CRM_BF_BFDJ_ReadByBFDJID";//"SELECT * FROM CRM_BF_BFDJ WHERE BFDJID = @BFDJID";
        private const string SQL_Delete = "CRM_BF_BFDJ_Delete";
        private const string SQL_Report = "CRM_BF_BFDJ_Report";
        private const string SQL_Report_Summary = "CRM_BF_BFDJ_Report_Summary";
        private const string SQL_Report_Detail = "CRM_BF_BFDJ_Report_Detail";
        private const string SQL_Read = "CRM_BF_BFDJ_Read";
      
        private const string SQL_ReadKHBF_BFDJ_SUMMARY = "CRM_BF_BFDJ_ReadBFDJ_SUMMARY";
        private const string SQL_ReadKHBF_BFDJ_DETAIL = "CRM_BF_BFDJ_ReadBFDJ_DETAIL";
        private const string SQL_ReadKHBF_ReportByStaff_SummaryTotal = "CRM_BF_BFDJ_ReportByStaff_SummaryTotal";
        private const string SQL_ReadKHBF_ReportByStaff_Summary = "CRM_BF_BFDJ_ReportByStaff_Summary";
        private const string SQL_ReadKHBF_ReportByStaff_Detail = "CRM_BF_BFDJ_ReportByStaff_Detail";
        private const string SQL_ReadKHBF_ReportByDate_Summary = "CRM_BF_BFDJ_ReportByDate_Summary";

      


        public int Create(CRM_BF_BFDJ model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@BFDJID", model.BFDJID),
                                        new SqlParameter("@BFJHID", model.BFJHID),
                                        new SqlParameter("@BFRYID", model.BFRYID),
                                        new SqlParameter("@BFKH", model.BFKH),
                                        new SqlParameter("@BFID", model.BFID),
                                        new SqlParameter("@BFLX", model.BFLX),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@KHMC", model.KHMC),
                                        new SqlParameter("@KHLX", model.KHLX),
                                        new SqlParameter("@XSQD", model.XSQD),
                                        new SqlParameter("@JHBFKSSJ", model.JHBFKSSJ),
                                        new SqlParameter("@JHBFJSSJ", model.JHBFJSSJ),
                                        new SqlParameter("@BFDZ", model.BFDZ),
                                        new SqlParameter("@LXR", model.LXR),
                                        new SqlParameter("@LXRTEL", model.LXRTEL),
                                        new SqlParameter("@LXRZW", model.LXRZW),
                                        new SqlParameter("@BFMD", model.BFMD),
                                        new SqlParameter("@BFJG", model.BFJG),
                                        new SqlParameter("@XCBFSJ", model.XCBFSJ),
                                        new SqlParameter("@XCBFJH", model.XCBFJH),
                                        new SqlParameter("@QTXX", model.QTXX),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@ISDELETE", model.ISDELETE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_BF_BFDJ model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@BFDJID", model.BFDJID),
                                        new SqlParameter("@BFJHID", model.BFJHID),
                                        new SqlParameter("@BFRYID", model.BFRYID),
                                        new SqlParameter("@BFKH", model.BFKH),
                                        new SqlParameter("@BFID", model.BFID),
                                        new SqlParameter("@BFLX", model.BFLX),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@KHMC", model.KHMC),
                                        new SqlParameter("@KHLX", model.KHLX),
                                        new SqlParameter("@XSQD", model.XSQD),
                                        new SqlParameter("@JHBFKSSJ", model.JHBFKSSJ),
                                        new SqlParameter("@JHBFJSSJ", model.JHBFJSSJ),
                                        new SqlParameter("@BFDZ", model.BFDZ),
                                        new SqlParameter("@LXR", model.LXR),
                                        new SqlParameter("@LXRTEL", model.LXRTEL),
                                        new SqlParameter("@LXRZW", model.LXRZW),
                                        new SqlParameter("@BFMD", model.BFMD),
                                        new SqlParameter("@BFJG", model.BFJG),
                                        new SqlParameter("@XCBFSJ", model.XCBFSJ),
                                        new SqlParameter("@XCBFJH", model.XCBFJH),
                                        new SqlParameter("@QTXX", model.QTXX),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@ISDELETE", model.ISDELETE)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_BF_BFDJList> Read(CRM_BF_BFDJ_PARAMS model,int isGun)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@BFRYID", model.BFRYID),
                                        new SqlParameter("@BFJHID", model.BFJHID),
                                        new SqlParameter("@BFLX", model.BFLX),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@KHMC", model.KHMC),
                                        new SqlParameter("@KHLX", model.KHLX),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                        new SqlParameter("@ISGUN",isGun),
                                        new SqlParameter("@BEGINTIME", model.BEGINTIME),
                                        new SqlParameter("@ENDTIME",model.ENDTIME)
                                    };
            IList<CRM_BF_BFDJList> nodes = new List<CRM_BF_BFDJList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_Read,parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToListObject(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;
        }
        public IList<CRM_BF_REPORTSUMMARY> Report_Summary(CRM_BF_ReportParam model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@BFRYID", model.BFRYID),
                                        new SqlParameter("@BFLX", model.BFLX),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@KHMC", model.KHMC),
                                        new SqlParameter("@KHLX", model.KHLX),
                                        new SqlParameter("@STAFFNAME", model.STAFFNAME),
                                        new SqlParameter("@STAFFNO", model.SFAFFNO),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@BFDZ", model.BFDZ),
                                        new SqlParameter("@BEGINTIME", model.BEGINTIME),
                                        new SqlParameter("@ENDTIME", model.ENDTIME),
                                        new SqlParameter("@LXR", model.LXR),
                                        new SqlParameter("@LXRTEL", model.LXRTEL),
                                        new SqlParameter("@BFMD", model.BFMD),
                                        new SqlParameter("@BFJG", model.BFJG),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            IList<CRM_BF_REPORTSUMMARY> nodes = new List<CRM_BF_REPORTSUMMARY>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report_Summary, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToSUMMARYOBJ(sdr));
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }
        public IList<CRM_BF_REPORTDETAIL> Report_Detail(CRM_BF_ReportParam model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@BFRYID", model.BFRYID),
                                        new SqlParameter("@BFLX", model.BFLX),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@KHMC", model.KHMC),
                                        new SqlParameter("@KHLX", model.KHLX),
                                        new SqlParameter("@STAFFNAME", model.STAFFNAME),
                                        new SqlParameter("@STAFFNO", model.SFAFFNO),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@BFDZ", model.BFDZ),
                                        new SqlParameter("@BEGINTIME", model.BEGINTIME),
                                        new SqlParameter("@ENDTIME", model.ENDTIME),
                                        new SqlParameter("@LXR", model.LXR),
                                        new SqlParameter("@LXRTEL", model.LXRTEL),
                                        new SqlParameter("@BFMD", model.BFMD),
                                        new SqlParameter("@BFJG", model.BFJG),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)
                                   };
            IList<CRM_BF_REPORTDETAIL> nodes = new List<CRM_BF_REPORTDETAIL>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report_Detail, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataTODetailOBJ(sdr));
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_KHDJ_REPORT_SUMMARY> ReadKHBF_BFDJ_SUMMARY(CRM_KHDJ_REPORT_PARAMS model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BEGINDATE",model.BEGINDATE),
                                       new SqlParameter("@BFLX",model.BFLX),
                                       new SqlParameter("@BFZQ",model.BFZQ),
                                       new SqlParameter("@ENDDATE",model.ENDDATE),
                                       new SqlParameter("@GID",model.GID),
                                       new SqlParameter("@HDMC",model.HDMC),
                                       new SqlParameter("@KHID",model.KHID),
                                       new SqlParameter("@KHLX",model.KHLX),
                                       new SqlParameter("@KHMC",model.KHMC),
                                       new SqlParameter("@STAFFNAME",model.STAFFNAME),
                                       new SqlParameter("@TYPE",model.TYPE),
                                       new SqlParameter("@BFJHID_TEMP",model.BFJHID),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
            IList<CRM_KHDJ_REPORT_SUMMARY> nodes = new List<CRM_KHDJ_REPORT_SUMMARY>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadKHBF_BFDJ_SUMMARY, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToSummary(sdr, model.TYPE));
                    }
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }
        public IList<CRM_KHDJ_REPORT_DETAIL> ReadKHBF_BFDJ_DETAIL(CRM_KHDJ_REPORT_PARAMS model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BEGINDATE",model.BEGINDATE),
                                       new SqlParameter("@BFLX",model.BFLX),
                                       new SqlParameter("@BFZQ",model.BFZQ),
                                       new SqlParameter("@ENDDATE",model.ENDDATE),
                                       new SqlParameter("@GID",model.GID),
                                       new SqlParameter("@HDMC",model.HDMC),
                                       new SqlParameter("@KHID",model.KHID),
                                       new SqlParameter("@KHLX",model.KHLX),
                                       new SqlParameter("@KHMC",model.KHMC),
                                       new SqlParameter("@STAFFNAME",model.STAFFNAME),
                                       new SqlParameter("@TYPE",model.TYPE),
                                       new SqlParameter("@BFJHID",model.BFJHID),

                                   };
            IList<CRM_KHDJ_REPORT_DETAIL> nodes = new List<CRM_KHDJ_REPORT_DETAIL>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadKHBF_BFDJ_DETAIL, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToDetail(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_BF_REPORT_BYSTAFF_SUMMARYTOTAL> ReadKHBF_ReportByStaff_SummaryTotal(CRM_BF_REPORT_BYSTAFF_PARAMS model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BEGINDATE",model.BEGINDATE),
                                       new SqlParameter("@ENDDATE",model.ENDDATE),
                                       new SqlParameter("@DEPID",model.DEPID),
                                       new SqlParameter("@STAFFLX",model.STAFFLX),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
            IList<CRM_BF_REPORT_BYSTAFF_SUMMARYTOTAL> nodes = new List<CRM_BF_REPORT_BYSTAFF_SUMMARYTOTAL>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadKHBF_ReportByStaff_SummaryTotal, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToSummaryTotal(sdr));
                    }
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_BF_REPORT_BYSTAFF_SUMMARY> ReadKHBF_ReportByStaff_Summary(CRM_BF_REPORT_BYSTAFF_PARAMS model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BEGINDATE",model.BEGINDATE),
                                       new SqlParameter("@ENDDATE",model.ENDDATE),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
            IList<CRM_BF_REPORT_BYSTAFF_SUMMARY> nodes = new List<CRM_BF_REPORT_BYSTAFF_SUMMARY>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadKHBF_ReportByStaff_Summary, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToSummaryList(sdr));
                    }
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public DataTable ReadKHBF_ReportByDate_Summary(CRM_BF_REPORT_BYSTAFF_PARAMS model)
        {
            DataTable RES = new DataTable();
            SqlParameter[] parms = {
                                       new SqlParameter("@BEGINDATE",model.BEGINDATE),
                                       new SqlParameter("@ENDDATE",model.ENDDATE),
                                       new SqlParameter("@DEPID",model.DEPID),
                                       new SqlParameter("@STAFFLX",model.STAFFLX),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
            
            try
            {
                RES = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_ReadKHBF_ReportByDate_Summary, parms);

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return RES;
        }

        public IList<CRM_BF_BFDJList> ReadKHBF_ReportByStaff_Detail(CRM_BF_REPORT_BYSTAFF_PARAMS model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BEGINDATE",model.BEGINDATE),
                                       new SqlParameter("@ENDDATE",model.ENDDATE),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@BFLX",model.BFLX)
                                   };
            IList<CRM_BF_BFDJList> nodes = new List<CRM_BF_BFDJList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadKHBF_ReportByStaff_Detail, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToDetailList(sdr));
                    }
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        public int Delete(int BFDJID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BFDJID",BFDJID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }
        public CRM_BF_BFDJ ReadByBFDJID(int BFDJID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BFDJID",BFDJID)
                                   };
            CRM_BF_BFDJ node = new CRM_BF_BFDJ();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_ReadByBFDJID,parms))
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

        public IList<CRM_BF_BFDJList> Report(CRM_BF_BFDJList model)
        {
            SqlParameter[] parms = {
                                      
                                   };
            IList<CRM_BF_BFDJList> nodes = new List<CRM_BF_BFDJList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToList(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }

            return nodes;    
        }

        private CRM_BF_BFDJList ReadDataToList(SqlDataReader sdr)
        {
            CRM_BF_BFDJList node = new CRM_BF_BFDJList();
          
            return node;
        }

        private CRM_BF_BFDJ ReadDataToObject(SqlDataReader sdr)
        {
            CRM_BF_BFDJ node = new CRM_BF_BFDJ();
            node.BFDJID = Convert.ToInt32(sdr["BFDJID"]);
            node.BFJHID = Convert.ToInt32(sdr["BFJHID"]);
            node.BFRYID = Convert.ToInt32(sdr["BFRYID"]);
            node.BFKH = Convert.ToInt32(sdr["BFKH"]);
            node.BFID = Convert.ToInt32(sdr["BFID"]);
            node.BFLX = Convert.ToInt32(sdr["BFLX"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.KHMC = Convert.ToString(sdr["KHMC"]);
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);
            node.XSQD = Convert.ToString(sdr["XSQD"]);
            node.JHBFKSSJ = Convert.ToString(sdr["JHBFKSSJ"]);
            node.JHBFJSSJ = Convert.ToString(sdr["JHBFJSSJ"]);
            node.BFDZ = Convert.ToString(sdr["BFDZ"]);
            node.LXR = Convert.ToString(sdr["LXR"]);
            node.LXRTEL = Convert.ToString(sdr["LXRTEL"]);
            node.LXRZW = Convert.ToInt32(sdr["LXRZW"]);
            node.BFMD = Convert.ToInt32(sdr["BFMD"]);
            node.BFJG = Convert.ToInt32(sdr["BFJG"]);
            node.XCBFSJ = Convert.ToString(sdr["XCBFSJ"]);
            node.XCBFJH = Convert.ToString(sdr["XCBFJH"]);
            node.QTXX = Convert.ToString(sdr["QTXX"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);

            return node;
        }
        private CRM_BF_BFDJList ReadDataToListObject(SqlDataReader sdr)
        {
            CRM_BF_BFDJList node = new CRM_BF_BFDJList();
            node.BFDJID = Convert.ToInt32(sdr["BFDJID"]);
            node.BFJHID = Convert.ToInt32(sdr["BFJHID"]);
            node.BFRYID = Convert.ToInt32(sdr["BFRYID"]);
            node.BFKH = Convert.ToInt32(sdr["BFKH"]);
            node.BFID = Convert.ToInt32(sdr["BFID"]);
            node.BFLX = Convert.ToInt32(sdr["BFLX"]);
            node.KHLXDES = Convert.ToString(sdr["KHLXDES"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.KHMC = Convert.ToString(sdr["KHMC"]);
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);
            node.XSQD = Convert.ToString(sdr["XSQD"]);
            node.JHBFKSSJ = Convert.ToString(sdr["JHBFKSSJ"]);
            node.JHBFJSSJ = Convert.ToString(sdr["JHBFJSSJ"]);
            node.BFDZ = Convert.ToString(sdr["BFDZ"]);
            node.LXR = Convert.ToString(sdr["LXR"]);
            node.LXRTEL = Convert.ToString(sdr["LXRTEL"]);
            node.LXRZW = Convert.ToInt32(sdr["LXRZW"]);
            node.BFMD = Convert.ToInt32(sdr["BFMD"]);
            node.BFJG = Convert.ToInt32(sdr["BFJG"]);
            node.XCBFSJ = Convert.ToString(sdr["XCBFSJ"]);
            node.XCBFJH = Convert.ToString(sdr["XCBFJH"]);
            node.QTXX = Convert.ToString(sdr["QTXX"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);

            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            node.BFCS = Convert.ToInt16(sdr["BFCS"]);
            node.BFZQDES = Convert.ToString(sdr["BFZQDES"]);
            node.BFLXDES = Convert.ToString(sdr["BFLXDES"]);
            node.LXRZWDES = Convert.ToString(sdr["LXRZWDES"]);
            node.BFMDDES = Convert.ToString(sdr["BFMDDES"]);
            node.BFJGDES = Convert.ToString(sdr["BFJGDES"]);
            node.BFJHMC = Convert.ToString(sdr["BFJHMC"]);

            node.KQJL = Convert.ToString(sdr["KQJL"]).Split('.')[0];
            if (node.KQJL == "")
                node.KQJL = "0";
            node.KQISACTIVE = Convert.ToInt32(sdr["KQISACTIVE"]);
            return node;
        }

        private CRM_KHDJ_REPORT_DETAIL ReadDataToDetail(SqlDataReader sdr)
        {
            CRM_KHDJ_REPORT_DETAIL node = new CRM_KHDJ_REPORT_DETAIL();
            node.BFDJID = Convert.ToInt32(sdr["BFDJID"]);
            node.BFDZ = Convert.ToString(sdr["BFDZ"]);
            node.BFJGDES = Convert.ToString(sdr["BFJGDES"]);

            node.BFJSRQ = Convert.ToString(sdr["JHBFJSSJ"]);
            node.BFLXDES = Convert.ToString(sdr["BFLXDES"]);
            node.BFMDDES = Convert.ToString(sdr["BFMDDES"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            //node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.KHLXDES = Convert.ToString(sdr["KHLXDES"]);
            node.LXR = Convert.ToString(sdr["LXR"]);
            node.LXRTEL = Convert.ToString(sdr["LXRTEL"]);
            node.LXRZWDES = Convert.ToString(sdr["LXRZWDES"]);
            node.MC = Convert.ToString(sdr["KHMC"]);
            node.QTXX = Convert.ToString(sdr["QTXX"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.BFJHMC = Convert.ToString(sdr["BFJHMC"]);
            node.KQJL = Convert.ToString(sdr["KQJL"]).Split('.')[0];
            if (node.KQJL == "")
                node.KQJL = "0";
            node.KQISACTIVE = Convert.ToInt32(sdr["KQISACTIVE"]);
            return node;
        }
        private CRM_KHDJ_REPORT_SUMMARY ReadDataToSummary(SqlDataReader sdr, int type)
        {
            CRM_KHDJ_REPORT_SUMMARY node = new CRM_KHDJ_REPORT_SUMMARY();

            node.FINISHCOUNTS = Convert.ToInt32(sdr["FINISHCOUNTS"]);
            switch (type)
            {
                case 1:
                    node.KHMC = Convert.ToString(sdr["KHMC"]);
                    node.BFLX = Convert.ToInt32(sdr["BFLX"]);
                    node.JHMS = Convert.ToString(sdr["JHMS"]);
                    node.KHID = Convert.ToInt32(sdr["KHID"]);
                    node.REQUIRECOUNTS = Convert.ToInt32(sdr["REQUIRECOUNTS"]);
                    node.UNFINISHEDCOUNTS = Convert.ToInt32(sdr["UNFINISHEDCOUNTS"]);
                    break;
                case 2:
                    node.BFJHID = Convert.ToInt32(sdr["BFJHID"]);
                    node.JHMS = Convert.ToString(sdr["JHMS"]);
                    node.REQUIRECOUNTS = Convert.ToInt32(sdr["REQUIRECOUNTS"]);
                    node.UNFINISHEDCOUNTS = Convert.ToInt32(sdr["UNFINISHEDCOUNTS"]);
                    node.BFLX = Convert.ToInt32(sdr["BFLX"]);
                    node.BFLXDES = Convert.ToString(sdr["BFLXDES"]);
                    break;
                case 3:
                    node.BFLXDES = Convert.ToString(sdr["BFLXDES"]);
                    node.BFLX = Convert.ToInt32(sdr["BFLX"]);
                    break;
                default:
                    break;
            }
            return node;
        }


        private CRM_BF_REPORT_BYSTAFF_SUMMARYTOTAL ReadDataToSummaryTotal(SqlDataReader sdr)
        {
            CRM_BF_REPORT_BYSTAFF_SUMMARYTOTAL node = new CRM_BF_REPORT_BYSTAFF_SUMMARYTOTAL();
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            node.DEPNAME = Convert.ToString(sdr["DEPNAME"]);
            node.TOTAL_COUNT = Convert.ToInt32(sdr["TOTAL_COUNT"]);
            return node;
        }

        private CRM_BF_REPORT_BYSTAFF_SUMMARY ReadDataToSummaryList(SqlDataReader sdr)
        {
            CRM_BF_REPORT_BYSTAFF_SUMMARY node = new CRM_BF_REPORT_BYSTAFF_SUMMARY();
            node.BFLX = Convert.ToInt32(sdr["BFLX"]);
            node.BFLXDES = Convert.ToString(sdr["BFLXDES"]);
            node.FINISHCOUNTS = Convert.ToInt32(sdr["FINISHCOUNTS"]);
            return node;
        }

        private CRM_BF_BFDJList ReadDataToDetailList(SqlDataReader sdr)
        {
            CRM_BF_BFDJList node = new CRM_BF_BFDJList();
            node.BFDJID = Convert.ToInt32(sdr["BFDJID"]);
            node.BFJHID = Convert.ToInt32(sdr["BFJHID"]);
            node.BFRYID = Convert.ToInt32(sdr["BFRYID"]);
            node.BFKH = Convert.ToInt32(sdr["BFKH"]);
            node.BFID = Convert.ToInt32(sdr["BFID"]);
            node.BFLX = Convert.ToInt32(sdr["BFLX"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.KHMC = Convert.ToString(sdr["KHMC"]);
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);
            node.JHBFKSSJ = Convert.ToString(sdr["JHBFKSSJ"]);
            node.JHBFJSSJ = Convert.ToString(sdr["JHBFJSSJ"]);
            node.BFDZ = Convert.ToString(sdr["BFDZ"]);
            node.LXR = Convert.ToString(sdr["LXR"]);
            node.LXRTEL = Convert.ToString(sdr["LXRTEL"]);
            node.LXRZW = Convert.ToInt32(sdr["LXRZW"]);
            node.BFMD = Convert.ToInt32(sdr["BFMD"]);
            node.BFJG = Convert.ToInt32(sdr["BFJG"]);
            node.QTXX = Convert.ToString(sdr["QTXX"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BFJHMC = Convert.ToString(sdr["BFJHMC"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.BFLXDES = Convert.ToString(sdr["BFLXDES"]);
            node.KHLXDES = Convert.ToString(sdr["KHLXDES"]);
            node.LXRZWDES = Convert.ToString(sdr["LXRZWDES"]);
            node.BFMDDES = Convert.ToString(sdr["BFMDDES"]);
            node.BFJGDES = Convert.ToString(sdr["BFJGDES"]);
            node.KQJL = Convert.ToString(sdr["KQJL"]).Split('.')[0];
            if (node.KQJL == "")
                node.KQJL = "0";
            node.KQISACTIVE = Convert.ToInt32(sdr["KQISACTIVE"]);
            return node;
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

        private CRM_BF_REPORTDETAIL ReadDataTODetailOBJ(SqlDataReader sdr)
        {
            CRM_BF_REPORTDETAIL node = new CRM_BF_REPORTDETAIL();
            node.BFDJID = Convert.ToInt32(sdr["BFDJID"]);
            node.BFRYID = Convert.ToInt32(sdr["BFRYID"]);
            node.BFKH = Convert.ToInt32(sdr["BFKH"]);
            node.BFLX = Convert.ToInt32(sdr["BFLX"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.KHMC = Convert.ToString(sdr["KHMC"]);
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            node.BFDZ = Convert.ToString(sdr["BFDZ"]);
            node.BFSJ = Convert.ToString(sdr["BFSJ"]);
            node.LXR = Convert.ToString(sdr["LXR"]);
            node.LXRTEL = Convert.ToString(sdr["LXRTEL"]);
            node.LXRZW = Convert.ToInt32(sdr["LXRZW"]);
            node.LXRZWDES = Convert.ToString(sdr["LXRZWDES"]);
            node.BFMD = Convert.ToInt32(sdr["BFMD"]);
            node.BFJG = Convert.ToInt32(sdr["BFJG"]);
            node.BFMDDES = Convert.ToString(sdr["BFMDDES"]);
            node.BFJGDES = Convert.ToString(sdr["BFJGDES"]);
            node.QTXX = Convert.ToString(sdr["QTXX"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);

            return node;
        }
        private CRM_BF_REPORTSUMMARY ReadDataToSUMMARYOBJ(SqlDataReader sdr)
        {
            CRM_BF_REPORTSUMMARY node = new CRM_BF_REPORTSUMMARY();
            node.BFCS = Convert.ToInt16(sdr["BFCS"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.KHMC = Convert.ToString(sdr["KHMC"]);
            node.BFKH = Convert.ToInt32(sdr["BFKH"]);
            return node;
        }



    }
}
