using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Entities;
using System.Data;
using System.Data.SqlClient;
using Sonluk.Entities.CRM;
namespace Sonluk.DataAccess.RMS.CRM
{
    public class CRM_BF_Report
    {
        enum TYPEEnum
        {
            KHBF = 1,
            BFJH = 2,
            QT = 3
        }
        private const string SQL_ReadKHBF_BFDJ_SUMMARY = "ReadBFDJ_SUMMARY";
        private const string SQL_ReadKHBF_BFDJ_DETAIL = "ReadBFDJ_DETAIL";

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
                                       new SqlParameter("@TYPE",model.TYPE)
                                   };
            IList<CRM_KHDJ_REPORT_SUMMARY> nodes = new List<CRM_KHDJ_REPORT_SUMMARY>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_ReadKHBF_BFDJ_SUMMARY,parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToSummary(sdr, (TYPEEnum)model.TYPE));
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
                                       new SqlParameter("@TYPE",model.TYPE)
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
        private CRM_KHDJ_REPORT_DETAIL ReadDataToDetail(SqlDataReader sdr)
        {
            CRM_KHDJ_REPORT_DETAIL node = new CRM_KHDJ_REPORT_DETAIL();
            node.BFDZ = Convert.ToString(sdr["BFDZ"]);
            node.BFJGDES = Convert.ToString(sdr["BFJGDES"]);
            node.BFJHMC = Convert.ToString(sdr["BFJHMC"]);
            node.BFJSRQ = Convert.ToString(sdr["BFJSRQ"]);
            node.BFLXDES = Convert.ToString(sdr["BFLXDES"]);
            node.BFMDDES = Convert.ToString(sdr["BFMDDES"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            //node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.KHLXDES = Convert.ToString(sdr["KHLXDES"]);
            node.LXR = Convert.ToString(sdr["LXR"]);
            node.LXRTEL = Convert.ToString(sdr["LXRTEL"]);
            node.LXRZWDES = Convert.ToString(sdr["LXRZWDES"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.QTXX = Convert.ToString(sdr["QTXX"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            return node;
        }
        private CRM_KHDJ_REPORT_SUMMARY ReadDataToSummary(SqlDataReader sdr,TYPEEnum type)
        {
            CRM_KHDJ_REPORT_SUMMARY node = new CRM_KHDJ_REPORT_SUMMARY();
           
            node.FINISHCOUNTS = Convert.ToInt32(sdr["FINISHCOUNTS"]);
            switch (type)
            {
                case TYPEEnum.KHBF:
                    node.KHMC = Convert.ToString(sdr["KHMC"]);
                    node.BFLX = Convert.ToInt32(sdr["BFLX"]);
                    node.JHMS = Convert.ToString(sdr["JHMS"]);
                    node.KHID = Convert.ToInt32(sdr["KHID"]);
                    node.REQUIRECOUNTS = Convert.ToInt32(sdr["REQUIRECOUNTS"]);
                    node.UNFINISHEDCOUNTS = Convert.ToInt32(sdr["UNFINISHEDCOUNTS"]);
                    break;
                case TYPEEnum.BFJH:
                    node.BFLX = Convert.ToInt32(sdr["BFLX"]);
                    node.JHMS = Convert.ToString(sdr["JHMS"]);
                    node.REQUIRECOUNTS = Convert.ToInt32(sdr["REQUIRECOUNTS"]);
                    node.UNFINISHEDCOUNTS = Convert.ToInt32(sdr["UNFINISHEDCOUNTS"]);
                    break;
                case TYPEEnum.QT:
                    node.KHMC = Convert.ToString(sdr["KHMC"]);
                    break;
                default:
                    break;
            }
            return node;
        }



    }
}
