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
    public class SY_TYPEMX : ISY_TYPEMX
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_SY_TYPEMX_INSERT";
        const string SQL_SELECT = "HR_SY_TYPEMX_SELECT";
        const string SQL_UPDATE = "HR_SY_TYPEMX_UPDATE";
        const string SQL_DELETE = "HR_SY_TYPEMX_DELETE";
        public MES_RETURN INSERT(HR_SY_TYPEMX model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TYPEID",model.TYPEID),
                                       new SqlParameter("@MXNAME",model.MXNAME),
                                       new SqlParameter("@MXREMARK",model.MXREMARK),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@MXNO",model.MXNO),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@MXID",model.MXID),
                                       new SqlParameter("@FID",model.FID)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_TYPEMX_INSERT", "HR");
            }
            return rst;
        }

        public MES_RETURN DELETE(HR_SY_TYPEMX model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_TYPEMX_DELETE", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_SY_TYPEMX model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@MXNAME",model.MXNAME),
                                       new SqlParameter("@MXREMARK",model.MXREMARK),
                                       new SqlParameter("@MXNO",model.MXNO),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@MXID",model.MXID),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@FID",model.FID)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_TYPEMX_UPDATE", "HR");
            }
            return rst;
        }

        public HR_SY_TYPEMX_SELECT SELECT(HR_SY_TYPEMX model)
        {
            HR_SY_TYPEMX_SELECT rst = new HR_SY_TYPEMX_SELECT();
            List<HR_SY_TYPEMX> child_HR_SY_TYPEMX = new List<HR_SY_TYPEMX>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@TYPEID",model.TYPEID),
                                       new SqlParameter("@MXNAME",model.MXNAME),
                                       new SqlParameter("@FID",model.FID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        HR_SY_TYPEMX child = new HR_SY_TYPEMX();
                        child.ID = Convert.ToInt32(sdr["ID"]);
                        child.TYPEID = Convert.ToInt32(sdr["TYPEID"]);
                        child.MXNAME = Convert.ToString(sdr["MXNAME"]);
                        child.MXREMARK = Convert.ToString(sdr["MXREMARK"]);
                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.GS = Convert.ToString(sdr["GS"]);
                        child.MXNO = Convert.ToInt32(sdr["MXNO"]);
                        child.TYPENAME = Convert.ToString(sdr["TYPENAME"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.MXID = Convert.ToInt32(sdr["MXID"]);
                        child.FID = Convert.ToInt32(sdr["FID"]);
                        child.FTYPEID = Convert.ToInt32(sdr["FTYPEID"]);
                        child_HR_SY_TYPEMX.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_SY_TYPEMX_SELECT", "HR");
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.HR_SY_TYPEMX = child_HR_SY_TYPEMX;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}
