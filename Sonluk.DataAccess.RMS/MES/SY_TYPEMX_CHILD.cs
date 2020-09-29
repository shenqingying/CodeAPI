using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.MES
{
    public class SY_TYPEMX_CHILD : ISY_TYPEMX_CHILD
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_SELECT = "MES_SY_TYPEMX_CHILD_SELECT";
        const string SQL_INSERT = "MES_SY_TYPEMX_CHILD_INSERT";
        const string SQL_UPDATE = "MES_SY_TYPEMX_CHILD_UPDATE";
        const string SQL_DELETE = "MES_SY_TYPEMX_CHILD_DELETE";

        public MES_SY_TYPEMX_CHILD_SELECT SELECT(MES_SY_TYPEMX_CHILD model)
        {
            MES_SY_TYPEMX_CHILD_SELECT rst = new MES_SY_TYPEMX_CHILD_SELECT();
            List<MES_SY_TYPEMX_CHILD> child_MES_SY_TYPEMX_CHILD = new List<MES_SY_TYPEMX_CHILD>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@ZTYPEID",model.ZTYPEID),
                                       new SqlParameter("@ISSHOW",model.ISSHOW)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_TYPEMX_CHILD child = new MES_SY_TYPEMX_CHILD();
                        child.ID = Convert.ToInt32(sdr["ID"]);
                        child.ZTYPEID = Convert.ToInt32(sdr["ZTYPEID"]);
                        child.ISSHOW = Convert.ToInt32(sdr["ISSHOW"]);
                        child_MES_SY_TYPEMX_CHILD.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_TYPEMX_CHILD_SELECT");
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.MES_SY_TYPEMX_CHILD = child_MES_SY_TYPEMX_CHILD;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN INSERT(MES_SY_TYPEMX_CHILD model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@ZTYPEID",model.ZTYPEID),
                                       new SqlParameter("@ISSHOW",model.ISSHOW)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }

            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_TYPEMX_CHILD_INSERT");
            }
            return mr;
        }
        public MES_RETURN UPDATE(MES_SY_TYPEMX_CHILD model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@ZTYPEID",model.ZTYPEID),
                                       new SqlParameter("@ISSHOW",model.ISSHOW)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }

            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_TYPEMX_CHILD_UPDATE");
            }
            return mr;
        }
        public MES_RETURN DELETE(MES_SY_TYPEMX_CHILD model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@ZTYPEID",model.ZTYPEID),
                                       new SqlParameter("@ISSHOW",model.ISSHOW)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }

            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_TYPEMX_CHILD_DELETE");
            }
            return mr;
        }
    }
}
