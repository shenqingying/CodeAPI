using Sonluk.DataAccess.RMS.MES;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.HR
{
    public class XZGL_TAX_TAXSLMX : IXZGL_TAX_TAXSLMX
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_XZGL_TAX_TAXSLMX_INSERT";
        const string SQL_SELECT = "HR_XZGL_TAX_TAXSLMX_SELECT";
        const string SQL_UPDATE = "HR_XZGL_TAX_TAXSLMX_UPDATE";
        public MES_RETURN INSERT(HR_XZGL_TAX_TAXSLMX model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@SWLBID",model.SWLBID),
                                       new SqlParameter("@TAXKSJE",model.TAXKSJE),
                                       new SqlParameter("@TAXJSJE",model.TAXJSJE),
                                       new SqlParameter("@TAXSL",model.TAXSL),
                                       new SqlParameter("@TAXSKS",model.TAXSKS)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_TAX_TAXSLMX_INSERT", "HR");
            }
            return rst;
        }
        public HR_XZGL_TAX_TAXSLMX_SELECT SELECT(HR_XZGL_TAX_TAXSLMX model)
        {
            HR_XZGL_TAX_TAXSLMX_SELECT rst = new HR_XZGL_TAX_TAXSLMX_SELECT();
            List<HR_XZGL_TAX_TAXSLMX> child_HR_XZGL_TAX_TAXSLMX = new List<HR_XZGL_TAX_TAXSLMX>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@SWLBID",model.SWLBID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_XZGL_TAX_TAXSLMX child = new HR_XZGL_TAX_TAXSLMX();
                        child.GSSLMXID = Convert.ToInt32(sdr["GSSLMXID"]);
                        child.SWLBID = Convert.ToInt32(sdr["SWLBID"]);
                        child.TAXKSJE = Convert.ToInt32(sdr["TAXKSJE"]);
                        child.TAXJSJE = Convert.ToInt32(sdr["TAXJSJE"]);
                        child.TAXSL = Convert.ToInt32(sdr["TAXSL"]);
                        child.TAXSKS = Convert.ToInt32(sdr["TAXSKS"]);
                        child_HR_XZGL_TAX_TAXSLMX.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_TAX_TAXSLMX_SELECT", "HR");
            }
            rst.HR_XZGL_TAX_TAXSLMX = child_HR_XZGL_TAX_TAXSLMX;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN UPDATE(HR_XZGL_TAX_TAXSLMX model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@SWLBID",model.SWLBID),
                                       new SqlParameter("@LB",LB)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_TAX_TAXSLMX_UPDATE", "HR");
            }
            return rst;
        }
    }
}
