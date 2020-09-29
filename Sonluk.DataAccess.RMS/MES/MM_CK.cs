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
    public class MM_CK : IMM_CK
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        string SQL_INSERT = "MES_MM_CK_INSERT";
        string SQL_SELECT_COUNT = "SELECT COUNT(*) AS CKCOUNT FROM MES_MM_CK WHERE CKDM=@CKDM AND GC=@GC";
        string SQL_UPDATE = "UPDATE MES_MM_CK SET CKMS=@CKMS WHERE GC=@GC AND CKDM=@CKDM";
        const string SQL_SELECT = "MES_MM_CK_SELECT";
        const string SQL_SELECT_BY_STAFFID = "MES_MM_CK_SELECT_BY_STAFFID";

        private const string SQL_SELECT_ROLE_ASSEMBLE = "MES_MM_CK_SELECT_ROLE_ASSEMBLE";
        public MES_RETURN INSERT(MES_MM_CK model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@CKDM",model.CKDM),
                                       new SqlParameter("@CKMS",model.CKMS),
                                       new SqlParameter("@GC",model.GC),
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return rst;
        }

        public int SELECT_COUNT(MES_MM_CK model)
        {
            int rst = 0;
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@CKDM",model.CKDM),
                                       new SqlParameter("@GC",model.GC)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_COUNT, parms))
                {
                    while (sdr.Read())
                    {
                        rst = Convert.ToInt32(sdr["CKCOUNT"]);
                    }
                }
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_SELECT_COUNT");
            }
            return rst;
        }

        public MES_RETURN UPDATE_SYNC(MES_MM_CK model)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@CKDM",model.CKDM),
                                       new SqlParameter("@CKMS",model.CKMS),
                                       new SqlParameter("@GC",model.GC),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_UPDATE, parms)) { }
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_UPDATE_SYNC");
            }
            return mr;
        }

        public MES_MM_CK_SELECT SELECT(MES_MM_CK model)
        {
            MES_MM_CK_SELECT rst = new MES_MM_CK_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_MM_CK> child_MES_MM_CK = new List<MES_MM_CK>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@CKDM",model.CKDM),
                                       new SqlParameter("@CKMS",model.CKMS),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@ISACTION",model.ISACTION)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_MM_CK child = new MES_MM_CK();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.CKDM = Convert.ToString(sdr["CKDM"]);
                        child.CKMS = Convert.ToString(sdr["CKMS"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child_MES_MM_CK.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_SELECT");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_MM_CK = child_MES_MM_CK;
            return rst;
        }

        public MES_MM_CK_SELECT SELECT_BY_STAFFID(MES_MM_CK model)
        {
            MES_MM_CK_SELECT rst = new MES_MM_CK_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_MM_CK> child_MES_MM_CK = new List<MES_MM_CK>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@CKDM",model.CKDM),
                                       new SqlParameter("@CKMS",model.CKMS),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BY_STAFFID, parms))
                {
                    while (sdr.Read())
                    {
                        MES_MM_CK child = new MES_MM_CK();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.CKDM = Convert.ToString(sdr["CKDM"]);
                        child.CKMS = Convert.ToString(sdr["CKMS"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child_MES_MM_CK.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_SELECT_BY_STAFFID");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_MM_CK = child_MES_MM_CK;
            return rst;
        }
        public MES_MM_CK_SELECT SELECT_BY_ROLE_ASSEMBLE(MES_MM_CK model)
        {
            MES_MM_CK_SELECT rst = new MES_MM_CK_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_MM_CK> child_MES_MM_CK = new List<MES_MM_CK>();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@ROLENAME",model.ROLENAME)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_ROLE_ASSEMBLE, parms))
                {
                    while (sdr.Read())
                    {
                        MES_MM_CK child = new MES_MM_CK();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.CKDM = Convert.ToString(sdr["CKDM"]);
                        child.CKMS = Convert.ToString(sdr["CKMS"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child_MES_MM_CK.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_SELECT_ROLE_ASSEMBLE");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_MM_CK = child_MES_MM_CK;
            return rst;
        }
    }
}
