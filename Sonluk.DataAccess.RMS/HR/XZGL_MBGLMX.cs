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
    public class XZGL_MBGLMX : IXZGL_MBGLMX
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_XZGL_MBGLMX_INSERT";
        const string SQL_SELECT = "HR_XZGL_MBGLMX_SELECT";
        const string SQL_UPDATE = "HR_XZGL_MBGLMX_UPDATE";
        const string SQL_SELECT_LAY = "HR_XZGL_MBGLMX_SELECT_LAY";
        public MES_RETURN INSERT(HR_XZGL_MBGLMX model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MBID",model.MBID),
                                       new SqlParameter("@ZDID",model.ZDID),
                                       new SqlParameter("@PXM",model.PXM),
                                       new SqlParameter("@ISHAVEGS",model.ISHAVEGS),
                                       new SqlParameter("@FORMULA",model.FORMULA),
                                       new SqlParameter("@JSLEVEL",model.JSLEVEL),
                                       new SqlParameter("@JSORDER",model.JSORDER),
                                       new SqlParameter("@XSBLGZ",model.XSBLGZ),
                                       new SqlParameter("@YXXSW",model.YXXSW),
                                       new SqlParameter("@PRINTCD",model.PRINTCD),
                                       new SqlParameter("@ISFIXED",model.ISFIXED)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_MBGLMX_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_XZGL_MBGLMX model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@MBMXID",model.MBMXID),
                                       new SqlParameter("@MBID",model.MBID),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@PXM",model.PXM),
                                       new SqlParameter("@ISHAVEGS",model.ISHAVEGS),
                                       new SqlParameter("@FORMULA",model.FORMULA),
                                       new SqlParameter("@JSLEVEL",model.JSLEVEL),
                                       new SqlParameter("@JSORDER",model.JSORDER),
                                       new SqlParameter("@XSBLGZ",model.XSBLGZ),
                                       new SqlParameter("@YXXSW",model.YXXSW),
                                       new SqlParameter("@PRINTCD",model.PRINTCD),
                                       new SqlParameter("@ISFIXED",model.ISFIXED)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_MBGLMX_UPDATE", "HR");
            }
            return rst;
        }
        public HR_XZGL_MBGLMX_SELECT SELECT(HR_XZGL_MBGLMX model)
        {
            HR_XZGL_MBGLMX_SELECT rst = new HR_XZGL_MBGLMX_SELECT();
            List<HR_XZGL_MBGLMX> child_HR_XZGL_MBGLMX = new List<HR_XZGL_MBGLMX>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@MBID",model.MBID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, paras))
                {
                    while (sdr.Read())
                    {
                        HR_XZGL_MBGLMX child = new HR_XZGL_MBGLMX();
                        child.MBID = Convert.ToInt32(sdr["MBID"]);
                        child.ZDID = Convert.ToInt32(sdr["ZDID"]);
                        child.PXM = Convert.ToInt32(sdr["PXM"]);
                        child.FFJLZDMS = Convert.ToString(sdr["FFJLZDMS"]);
                        child.FFJLZDNAME = Convert.ToString(sdr["FFJLZDNAME"]);
                        child.ISHAVEGS = Convert.ToInt32(sdr["ISHAVEGS"]);
                        child.MXID = Convert.ToInt32(sdr["MXID"]);
                        child.MBMXID = Convert.ToInt32(sdr["MBMXID"]);
                        child.FORMULA = Convert.ToString(sdr["FORMULA"]);
                        child.JSLEVEL = Convert.ToInt32(sdr["JSLEVEL"]);
                        child.JSORDER = Convert.ToInt32(sdr["JSORDER"]);
                        child.XSBLGZ = Convert.ToInt32(sdr["XSBLGZ"]);
                        child.XSBLGZNAME = Convert.ToString(sdr["XSBLGZNAME"]);
                        child.YXXSW = Convert.ToInt32(sdr["YXXSW"]);
                        child.ISGDZD = Convert.ToInt32(sdr["ISGDZD"]);
                        child.PRINTCD = Convert.ToInt32(sdr["PRINTCD"]);
                        child.ISFIXED = Convert.ToInt32(sdr["ISFIXED"]);
                        child_HR_XZGL_MBGLMX.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_MBGLMX_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.HR_XZGL_MBGLMX = child_HR_XZGL_MBGLMX;
            return rst;
        }
        public HR_XZGL_MBGLMX_SELECT SELECT_LAY(HR_XZGL_MBGLMX model)
        {
            HR_XZGL_MBGLMX_SELECT rst = new HR_XZGL_MBGLMX_SELECT();
            List<HR_XZGL_MBGLMX> child_HR_XZGL_MBGLMX = new List<HR_XZGL_MBGLMX>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@MBID",model.MBID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LAY, paras))
                {
                    while (sdr.Read())
                    {
                        HR_XZGL_MBGLMX child = new HR_XZGL_MBGLMX();
                        child.MBID = Convert.ToInt32(sdr["MBID"]);
                        child.ZDID = Convert.ToInt32(sdr["ZDID"]);
                        child.PXM = Convert.ToInt32(sdr["PXM"]);
                        child.FFJLZDMS = Convert.ToString(sdr["FFJLZDMS"]);
                        if (child.MBID != 0)
                        {
                            child.LAY_CHECKED = true;
                        }
                        else
                        {
                            child.LAY_CHECKED = false;
                        }
                        child_HR_XZGL_MBGLMX.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_MBGLMX_SELECT_LAY", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.HR_XZGL_MBGLMX = child_HR_XZGL_MBGLMX;
            return rst;
        }
    }
}
