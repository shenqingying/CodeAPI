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
    public class SY_XTBB : ISY_XTBB
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_SY_XTBB_INSERT";
        const string SQL_DELETE = "UPDATE MES_SY_XTBB SET ISDELETE=1 WHERE ID=@ID";
        const string SQL_SELECT = "MES_SY_XTBB_SELECT";
        const string SQL_UPDATE = "MES_SY_XTBB_UPDATE";
        public MES_RETURN INSERT(MES_SY_XTBB model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@SYID",model.SYID),
                                       new SqlParameter("@NEWBB",model.NEWBB),
                                       new SqlParameter("@CFLJ",model.CFLJ),
                                       new SqlParameter("@BBINFO",model.BBINFO),
                                       new SqlParameter("@ISZXBB",model.ISZXBB),
                                       new SqlParameter("@ISACTION",model.ISACTION)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_XTBB_INSERT");
            }
            return rst;
        }

        public MES_RETURN DELETE(int ID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ID",ID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE, parms))
                {
                }
                rst.TYPE = "S";
                rst.MESSAGE = "";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_XTBB_DELETE");
            }
            return rst;
        }

        public MES_SY_XTBB_SELECT SELECT(MES_SY_XTBB model)
        {
            MES_SY_XTBB_SELECT rst = new MES_SY_XTBB_SELECT();
            List<MES_SY_XTBB> child_MES_SY_XTBB = new List<MES_SY_XTBB>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@SYID",model.SYID),
                                       new SqlParameter("@NEWBB",model.NEWBB),
                                       new SqlParameter("@CFLJ",model.CFLJ),
                                       new SqlParameter("@BBINFO",model.BBINFO),
                                       new SqlParameter("@ISZXBB",model.ISZXBB),
                                       new SqlParameter("@ISACTION",model.ISACTION)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_XTBB child = new MES_SY_XTBB();
                        child.ID = Convert.ToInt32(sdr["ID"]);
                        child.SYID = Convert.ToString(sdr["SYID"]);
                        child.NEWBB = Convert.ToString(sdr["NEWBB"]);
                        child.CFLJ = Convert.ToString(sdr["CFLJ"]);
                        child.BBINFO = Convert.ToString(sdr["BBINFO"]);
                        child.ISZXBB = Convert.ToInt32(sdr["ISZXBB"]);
                        //child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.ISACTION = Convert.ToInt32(sdr["FILECOUNT"]);//激活字段用于显示文件数
                        //child.FILECOUNT = Convert.ToInt32(sdr["FILECOUNT"]);
                        child_MES_SY_XTBB.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_XTBB_SELECT");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_XTBB = child_MES_SY_XTBB;
            return rst;
        }

        public MES_RETURN UPDATE(MES_SY_XTBB model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@SYID",model.SYID),
                                       new SqlParameter("@NEWBB",model.NEWBB),
                                       new SqlParameter("@CFLJ",model.CFLJ),
                                       new SqlParameter("@BBINFO",model.BBINFO),
                                       new SqlParameter("@ISZXBB",model.ISZXBB),
                                       new SqlParameter("@ISACTION",model.ISACTION)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_XTBB_INSERT");
            }
            return rst;
        }
    }
}
