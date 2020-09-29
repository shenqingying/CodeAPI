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
    public class XZGL_FLFAMX : IXZGL_FLFAMX
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_XZGL_FLFAMX_INSERT";
        const string SQL_SELECT = "HR_XZGL_FLFAMX_SELECT";
        const string SQL_UPDATE = "HR_XZGL_FLFAMX_UPDATE";
        public MES_RETURN INSERT(HR_XZGL_FLFAMX model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FLFAID",model.FLFAID),
                                       new SqlParameter("@FLMXXZ",model.FLMXXZ),
                                       new SqlParameter("@FLMXSX",model.FLMXSX),
                                       new SqlParameter("@FLMXXX",model.FLMXXX),
                                       new SqlParameter("@FLMXDWBL",model.FLMXDWBL),
                                       new SqlParameter("@FLMXGRBL",model.FLMXGRBL),
                                       new SqlParameter("@FLMXYXXSWS",model.FLMXYXXSWS),
                                       new SqlParameter("@FLMXXSBLGZ",model.FLMXXSBLGZ),
                                       new SqlParameter("@FLMXXSBLGZNAME",model.FLMXXSBLGZNAME),
                                       new SqlParameter("@FFJLZDID",model.FFJLZDID),
                                       new SqlParameter("@REMARK",model.REMARK)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FLFAMX_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_XZGL_FLFAMX model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@FLFAMXID",model.FLFAMXID),
                                       new SqlParameter("@FLMXSX",model.FLMXSX),
                                       new SqlParameter("@FLMXXX",model.FLMXXX),
                                       new SqlParameter("@FLMXDWBL",model.FLMXDWBL),
                                       new SqlParameter("@FLMXGRBL",model.FLMXGRBL),
                                       new SqlParameter("@FLMXYXXSWS",model.FLMXYXXSWS),
                                       new SqlParameter("@FLMXXSBLGZ",model.FLMXXSBLGZ),
                                       new SqlParameter("@FFJLZDID",model.FFJLZDID),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@REMARK",model.REMARK)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FLFAMX_UPDATE", "HR");
            }
            return rst;
        }
        public HR_XZGL_FLFAMX_SELECT SELECT(HR_XZGL_FLFAMX model)
        {
            HR_XZGL_FLFAMX_SELECT rst = new HR_XZGL_FLFAMX_SELECT();
            List<HR_XZGL_FLFAMX> child_HR_XZGL_FLFAMX = new List<HR_XZGL_FLFAMX>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@FLFAMXID",model.FLFAMXID),
                                           new SqlParameter("@FLFAID",model.FLFAID),
                                           new SqlParameter("@MXID",model.MXID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_XZGL_FLFAMX child = new HR_XZGL_FLFAMX();
                        child.FLFAMXID = Convert.ToInt32(sdr["FLFAMXID"]);
                        child.FLFAID = Convert.ToInt32(sdr["FLFAID"]);
                        child.FLMXXZ = Convert.ToInt32(sdr["FLMXXZ"]);
                        child.FLMXXZNAME = Convert.ToString(sdr["FLMXXZNAME"]);
                        child.FLMXSX = Convert.ToDecimal(sdr["FLMXSX"]);
                        child.FLMXXX = Convert.ToDecimal(sdr["FLMXXX"]);
                        child.FLMXDWBL = Convert.ToDecimal(sdr["FLMXDWBL"]);
                        child.FLMXGRBL = Convert.ToDecimal(sdr["FLMXGRBL"]);
                        child.FLMXYXXSWS = Convert.ToInt32(sdr["FLMXYXXSWS"]);
                        child.FLMXXSBLGZ = Convert.ToInt32(sdr["FLMXXSBLGZ"]);
                        child.FLMXXSBLGZNAME = Convert.ToString(sdr["FLMXXSBLGZNAME"]);
                        child.FFJLZDID = Convert.ToInt32(sdr["FFJLZDID"]);
                        child.FFJLZDNAME = Convert.ToString(sdr["FFJLZDNAME"]);
                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child_HR_XZGL_FLFAMX.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FLFA_SELECT", "HR");
            }
            rst.HR_XZGL_FLFAMX = child_HR_XZGL_FLFAMX;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}
