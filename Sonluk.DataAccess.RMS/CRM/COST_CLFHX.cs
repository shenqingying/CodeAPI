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
    public class COST_CLFHX : ICOST_CLFHX
    {
        private const string SQL_Create = "CRM_COST_CLFHX_Create";
        private const string SQL_Update = "CRM_COST_CLFHX_Update";
        private const string SQL_ReadByParam = "CRM_COST_CLFHX_ReadByParam";
        private const string SQL_Delete = "CRM_COST_CLFHX_Delete";


        public int Create(CRM_COST_CLFHX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@HXJE", model.HXJE),
                                        new SqlParameter("@FGLD", model.FGLD),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CWHSBH", model.CWHSBH),
                                        new SqlParameter("@CBZX", model.CBZX),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@JT_JE", model.JT_JE),
                                        new SqlParameter("@ZS_DAYS", model.ZS_DAYS),
                                        new SqlParameter("@ZS_JE", model.ZS_JE),
                                        new SqlParameter("@BT_DAYS", model.BT_DAYS),
                                        new SqlParameter("@BT_JE", model.BT_JE),
                                        new SqlParameter("@QT_ITEM", model.QT_ITEM),
                                        new SqlParameter("@QT_JE", model.QT_JE),
                                        new SqlParameter("@GSNY", model.GSNY),
                                        new SqlParameter("@BXFS", model.BXFS),
                                        new SqlParameter("@PMJG", model.PMJG),
                                        new SqlParameter("@PJ", model.PJ),
                                        new SqlParameter("@SL", model.SL),
                                        new SqlParameter("@WSJE", model.WSJE),
                                        new SqlParameter("@XSSJ", model.XSSJ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR),

                                        new SqlParameter("@JT_JPJE", model.JT_JPJE),
                                        new SqlParameter("@JT_JPSL", model.JT_JPSL),
                                        new SqlParameter("@JT_JPWSJE", model.JT_JPWSJE),
                                        new SqlParameter("@JT_HCPJE", model.JT_HCPJE),
                                        new SqlParameter("@JT_HCPSL", model.JT_HCPSL),
                                        new SqlParameter("@JT_HCPWSJE", model.JT_HCPWSJE),
                                        new SqlParameter("@JT_KCPJE", model.JT_KCPJE),
                                        new SqlParameter("@JT_KCPSL", model.JT_KCPSL),
                                        new SqlParameter("@JT_KCPWSJE", model.JT_KCPWSJE),
                                        new SqlParameter("@JCJSF", model.JCJSF),
                                        new SqlParameter("@ZS_SL", model.ZS_SL),
                                        new SqlParameter("@ZS_WSJE", model.ZS_WSJE),
                                        new SqlParameter("@QT_SL", model.QT_SL),
                                        new SqlParameter("@QT_WSJE", model.QT_WSJE),
                                        new SqlParameter("@JT_JPTZJE", model.JT_JPTZJE),

                                        new SqlParameter("@JT_HCPJE2", model.JT_HCPJE2),
                                        new SqlParameter("@JT_HCPSL2", model.JT_HCPSL2),
                                        new SqlParameter("@JT_HCPWSJE2", model.JT_HCPWSJE2),
                                        new SqlParameter("@JT_KCPJE2", model.JT_KCPJE2),
                                        new SqlParameter("@JT_KCPSL2", model.JT_KCPSL2),
                                        new SqlParameter("@JT_KCPWSJE2", model.JT_KCPWSJE2),
                                        new SqlParameter("@ZS_DAYS2", model.ZS_DAYS2),
                                        new SqlParameter("@ZS_JE2", model.ZS_JE2),
                                        new SqlParameter("@ZS_SL2", model.ZS_SL2),
                                        new SqlParameter("@ZS_WSJE2", model.ZS_WSJE2),
                                      
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_CLFHX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@HXJE", model.HXJE),
                                        new SqlParameter("@FGLD", model.FGLD),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CWHSBH", model.CWHSBH),
                                        new SqlParameter("@CBZX", model.CBZX),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@JT_JE", model.JT_JE),
                                        new SqlParameter("@ZS_DAYS", model.ZS_DAYS),
                                        new SqlParameter("@ZS_JE", model.ZS_JE),
                                        new SqlParameter("@BT_DAYS", model.BT_DAYS),
                                        new SqlParameter("@BT_JE", model.BT_JE),
                                        new SqlParameter("@QT_ITEM", model.QT_ITEM),
                                        new SqlParameter("@QT_JE", model.QT_JE),
                                        new SqlParameter("@GSNY", model.GSNY),
                                        new SqlParameter("@PMJG", model.PMJG),
                                        new SqlParameter("@PJ", model.PJ),
                                        new SqlParameter("@SL", model.SL),
                                        new SqlParameter("@BXFS", model.BXFS),
                                        new SqlParameter("@WSJE", model.WSJE),
                                        new SqlParameter("@XSSJ", model.XSSJ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@CLFHXID", model.CLFHXID),

                                        new SqlParameter("@JT_JPJE", model.JT_JPJE),
                                        new SqlParameter("@JT_JPSL", model.JT_JPSL),
                                        new SqlParameter("@JT_JPWSJE", model.JT_JPWSJE),
                                        new SqlParameter("@JT_HCPJE", model.JT_HCPJE),
                                        new SqlParameter("@JT_HCPSL", model.JT_HCPSL),
                                        new SqlParameter("@JT_HCPWSJE", model.JT_HCPWSJE),
                                        new SqlParameter("@JT_KCPJE", model.JT_KCPJE),
                                        new SqlParameter("@JT_KCPSL", model.JT_KCPSL),
                                        new SqlParameter("@JT_KCPWSJE", model.JT_KCPWSJE),
                                        new SqlParameter("@JCJSF", model.JCJSF),
                                        new SqlParameter("@ZS_SL", model.ZS_SL),
                                        new SqlParameter("@ZS_WSJE", model.ZS_WSJE),
                                        new SqlParameter("@QT_SL", model.QT_SL),
                                        new SqlParameter("@QT_WSJE", model.QT_WSJE),
                                        new SqlParameter("@JT_JPTZJE", model.JT_JPTZJE),

                                        new SqlParameter("@JT_HCPJE2", model.JT_HCPJE2),
                                        new SqlParameter("@JT_HCPSL2", model.JT_HCPSL2),
                                        new SqlParameter("@JT_HCPWSJE2", model.JT_HCPWSJE2),
                                        new SqlParameter("@JT_KCPJE2", model.JT_KCPJE2),
                                        new SqlParameter("@JT_KCPSL2", model.JT_KCPSL2),
                                        new SqlParameter("@JT_KCPWSJE2", model.JT_KCPWSJE2),
                                        new SqlParameter("@ZS_DAYS2", model.ZS_DAYS2),
                                        new SqlParameter("@ZS_JE2", model.ZS_JE2),
                                        new SqlParameter("@ZS_SL2", model.ZS_SL2),
                                        new SqlParameter("@ZS_WSJE2", model.ZS_WSJE2),
                                    
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_CLFHX> ReadByParam(CRM_COST_CLFHX model)
        {
            SqlParameter[] parms = {  
                                        new SqlParameter("@CLFHXID", model.CLFHXID),
                                        new SqlParameter("@CBZX", model.CBZX),
                                        new SqlParameter("@FGLD", model.FGLD),
                                        new SqlParameter("@SF", model.SF),
                                     //   new SqlParameter("@XSSJ", model.XSSJ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@TIME_BEGIN", model.TIME_BEGIN),
                                        new SqlParameter("@TIME_END", model.TIME_END),
                                        new SqlParameter("@XSSJ_BEGIN", model.XSSJ_BEGIN),
                                        new SqlParameter("@XSSJ_END", model.XSSJ_END),
                                        new SqlParameter("@STAFFNAME", model.STAFFNAME),
                                   };
            IList<CRM_COST_CLFHX> nodes = new List<CRM_COST_CLFHX>();
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

        public int Delete(int CLFHXID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CLFHXID", CLFHXID)
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


        private CRM_COST_CLFHX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_CLFHX node = new CRM_COST_CLFHX();
            node.CLFHXID = Convert.ToInt32(sdr["CLFHXID"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.HXJE = Convert.ToDouble(sdr["HXJE"]);
            node.CBZX = Convert.ToInt32(sdr["CBZX"]);
            node.FGLD = Convert.ToInt32(sdr["FGLD"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CWHSBH = Convert.ToString(sdr["CWHSBH"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.JT_JE = Convert.ToDouble(sdr["JT_JE"]);
            node.ZS_DAYS = Convert.ToDouble(sdr["ZS_DAYS"]);
            node.ZS_JE = Convert.ToDouble(sdr["ZS_JE"]);
            node.BT_DAYS = Convert.ToDouble(sdr["BT_DAYS"]);
            node.BT_JE = Convert.ToDouble(sdr["BT_JE"]);
            node.QT_ITEM = Convert.ToInt32(sdr["QT_ITEM"]);
            node.GSNY = Convert.ToString(sdr["GSNY"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.QT_JE = Convert.ToDouble(sdr["QT_JE"]);
            // node.DEPALL = Convert.ToInt32(sdr["DEPALL"]);
            // node.DEPNAME = Convert.ToString(sdr["DEPNAME"]);
            node.CBZXDES = Convert.ToString(sdr["CBZXDES"]);
            node.FGLDDES = Convert.ToString(sdr["FGLDDES"]);
            node.COSTITEMMC = Convert.ToString(sdr["COSTITEMMC"]);
            node.BXFS = Convert.ToInt32(sdr["BXFS"]);
            node.PMJG = Convert.ToDouble(sdr["PMJG"]);
            node.PJ = Convert.ToDouble(sdr["PJ"]);
            node.SL = Convert.ToInt32(sdr["SL"]);
            node.WSJE = Convert.ToDouble(sdr["WSJE"]);
            node.XSSJ = Convert.ToString(sdr["XSSJ"]);
            node.CWHSBHDES = Convert.ToString(sdr["CWHSBHDES"]);

            node.JT_JPJE = Convert.ToDouble(sdr["JT_JPJE"]);
            node.JT_JPSL = Convert.ToInt32(sdr["JT_JPSL"]);
            node.JT_JPWSJE = Convert.ToDouble(sdr["JT_JPWSJE"]);
            node.JT_HCPJE = Convert.ToDouble(sdr["JT_HCPJE"]);
            node.JT_HCPSL = Convert.ToInt32(sdr["JT_HCPSL"]);
            node.JT_HCPWSJE = Convert.ToDouble(sdr["JT_HCPWSJE"]);
            node.JT_KCPJE = Convert.ToDouble(sdr["JT_KCPJE"]);
            node.JT_KCPSL = Convert.ToInt32(sdr["JT_KCPSL"]);
            node.JT_KCPWSJE = Convert.ToDouble(sdr["JT_KCPWSJE"]);
            node.JCJSF = Convert.ToDouble(sdr["JCJSF"]);
            node.ZS_SL = Convert.ToInt32(sdr["ZS_SL"]);
            node.ZS_WSJE = Convert.ToDouble(sdr["ZS_WSJE"]);
            node.QT_SL = Convert.ToInt32(sdr["QT_SL"]);
            node.QT_WSJE = Convert.ToDouble(sdr["QT_WSJE"]);
            node.JT_JPTZJE = Convert.ToDouble(sdr["JT_JPTZJE"]);

            node.JT_HCPJE2 = Convert.ToDouble(sdr["JT_HCPJE2"]);
            node.JT_HCPSL2 = Convert.ToInt32(sdr["JT_HCPSL2"]);
            node.JT_HCPWSJE2 = Convert.ToDouble(sdr["JT_HCPWSJE2"]);
            node.JT_KCPJE2 = Convert.ToDouble(sdr["JT_KCPJE2"]);
            node.JT_KCPSL2 = Convert.ToInt32(sdr["JT_KCPSL2"]);
            node.JT_KCPWSJE2 = Convert.ToDouble(sdr["JT_KCPWSJE2"]);
            node.ZS_DAYS2 = Convert.ToDouble(sdr["ZS_DAYS2"]);
            node.ZS_JE2 = Convert.ToDouble(sdr["ZS_JE2"]);
            node.ZS_SL2 = Convert.ToInt32(sdr["ZS_SL2"]);
            node.ZS_WSJE2 = Convert.ToDouble(sdr["ZS_WSJE2"]);

         

            return node;
        }
    }
}
