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
    public class KH_KHXS : IKH_KHXS
    {
        private const string SQL_Create = "CRM_KH_KHXS_Create";
        private const string SQL_Update = "CRM_KH_KHXS_Update";
        private const string SQL_Read = "CRM_KH_KHXS_Read";
        private const string SQL_Delete = "CRM_KH_KHXS_Delete";
        private const string SQL_DZSreport = "CRM_KH_KHXS_DZSreport";

        public int Create(CRM_KH_KHXS model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@XSID", model.XSID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@XSLB", model.XSLB),
                                        new SqlParameter("@XSMC", model.XSMC),
                                        new SqlParameter("@XSSL", model.XSSL),
                                        new SqlParameter("@XSJE", model.XSJE),
                                        new SqlParameter("@GSRQ", model.GSRQ),
                                        new SqlParameter("@CZR", model.CZR),
                                        new SqlParameter("@CZRQ", model.CZRQ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ) 

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_KH_KHXS model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@XSID", model.XSID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@XSLB", model.XSLB),
                                        new SqlParameter("@XSMC", model.XSMC),
                                        new SqlParameter("@XSSL", model.XSSL),
                                        new SqlParameter("@XSJE", model.XSJE),
                                        new SqlParameter("@GSRQ", model.GSRQ),
                                        new SqlParameter("@CZR", model.CZR),
                                        new SqlParameter("@CZRQ", model.CZRQ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ) 

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public int Delete(CRM_KH_KHXS model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@XSID", model.XSID),
                                        new SqlParameter("@KHID", model.KHID)
                                        

                                   };
            return SQLServerHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_Delete, parms);
        }
        public IList<CRM_KH_KHXSList> Read(CRM_KH_KHXS model)
        {
            

            SqlParameter[] parms = {
                                        new SqlParameter("@XSID", model.XSID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@XSLB", model.XSLB),
                                        new SqlParameter("@XSMC", model.XSMC),
                                        new SqlParameter("@GSRQ", model.GSRQ)
                                       
                                      
                                   };
            IList<CRM_KH_KHXSList> nodes = new List<CRM_KH_KHXSList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
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

        public IList<CRM_KH_KHXS_DZSreportList> DZSreport(CRM_KH_KHXS_DZSreport model,int STAFFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CZSJ_BEGIN", model.CZSJ_BEGIN),
                                        new SqlParameter("@CZSJ_END", model.CZSJ_END),
                                        new SqlParameter("@STAFF", model.STAFF),
                                        new SqlParameter("@FGLD", model.FGLD),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@JXSID", model.JXSID),
                                        new SqlParameter("@JXSNAME", model.JXSNAME),
                                        new SqlParameter("@JXSSAPSN", model.JXSSAPSN),
                                        new SqlParameter("@MC", model.MC),
                                        new SqlParameter("@SHSJ_BEGIN", model.SHSJ_BEGIN),
                                        new SqlParameter("@SHSJ_END", model.SHSJ_END),
                                        new SqlParameter("@WDLX", model.WDLX),
                                        new SqlParameter("@STAFFID", STAFFID),
                                        new SqlParameter("@CZRQ_BEGIN", model.CZRQ_BEGIN),
                                        new SqlParameter("@CZRQ_END", model.CZRQ_END)
                                       
                                      
                                   };
            IList<CRM_KH_KHXS_DZSreportList> nodes = new List<CRM_KH_KHXS_DZSreportList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DZSreport, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDZSreportToListObject(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }



        private CRM_KH_KHXSList ReadDataToListObject(SqlDataReader sdr)
        {
            CRM_KH_KHXSList node = new CRM_KH_KHXSList();
            node.XSID = Convert.ToInt32(sdr["XSID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.XSLB = Convert.ToInt32(sdr["XSLB"]);
            node.XSMC = Convert.ToString(sdr["XSMC"]);
            node.XSJE = Convert.ToDouble(sdr["XSJE"]);
            node.XSSL = Convert.ToInt32(sdr["XSSL"]);
            node.GSRQ = Convert.ToString(sdr["GSRQ"]);
            node.CZR = Convert.ToInt32(sdr["CZR"]);
            node.CZRQ = Convert.ToDateTime(sdr["CZRQ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            //node.XSLBDES = Convert.ToString(sdr["XSLBDES"]);
            node.KHMC = Convert.ToString(sdr["KHMC"]);
            //node.XSLBDES = Convert.ToString(sdr["XSLBDES"]);

            return node;
        }

        private CRM_KH_KHXS_DZSreportList ReadDZSreportToListObject(SqlDataReader sdr)
        {
            CRM_KH_KHXS_DZSreportList node = new CRM_KH_KHXS_DZSreportList();
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.CZSJ = Convert.ToDateTime(sdr["CZSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.FGLDNAME = Convert.ToString(sdr["FGLDNAME"]);
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
            node.GSLXR = Convert.ToString(sdr["GSLXR"]);
            node.GSLXDH = Convert.ToString(sdr["GSLXDH"]);
            node.FID = Convert.ToInt32(sdr["FID"]);
            node.FIDDES = Convert.ToString(sdr["FIDDES"]);
            node.WDLX = Convert.ToInt32(sdr["WDLX"]);
            node.WDLXDES = Convert.ToString(sdr["WDLXDES"]);
            node.CZR = Convert.ToInt32(sdr["CZR"]);
            node.CZRDES = Convert.ToString(sdr["CZRDES"]);
            node.XYPP = Convert.ToString(sdr["XYPP"]);
            node.SH_CS = Convert.ToString(sdr["SH_CS"]);
            node.SH_SL = Convert.ToInt32(sdr["SH_SL"]);
            node.SH_SJ = Convert.ToString(sdr["SH_SJ"]);
            node.CZRQ = Convert.ToDateTime(sdr["CZRQ"]).ToString("yyyy-MM-dd HH:mm:ss");

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

    }
}
