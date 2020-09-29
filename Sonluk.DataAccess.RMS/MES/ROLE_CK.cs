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
    public class ROLE_CK : IROLE_CK
    {
        const string SQL_INSERT = "INSERT MES_ROLE_CK(ROLEID,GC,CKDM) VALUES(@ROLEID,@GC,@CKDM)";
        const string SQL_DELETE = "DELETE FROM MES_ROLE_CK WHERE ROLEID=@ROLEID";
        const string SQL_SELECT_BYROLEID = "MES_ROLE_CK_SELECT_BYROLEID";
        const string SQL_SELECT_COUNT_BY_STAFFID = "SELECT COUNT(*) AS ROLECOUNT FROM MES_ROLE_RY_ASSEMBLE AS A INNER JOIN MES_ROLE_ASSEMBLE AS C ON A.ROLEID=C.ID INNER JOIN MES_ROLE_CK AS B ON C.ID=B.ROLEID WHERE B.GC=@GC AND B.CKDM=@CKDM AND A.STAFFID=@STAFFID AND C.ISDELETE=0";
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        public MES_RETURN INSERT(List<MES_ROLE_CK> model)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                if (model.Count > 0)
                {
                    for (int i = 0; i < model.Count; i++)
                    {
                        SqlParameter[] parms = {
                                       new SqlParameter("@ROLEID",model[i].ROLEID),
                                       new SqlParameter("@GC",model[i].GC),
                                       new SqlParameter("@CKDM",model[i].CKDM)
                                   };

                        using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_INSERT, parms)) { }
                        mr.TYPE = "S";
                        mr.MESSAGE = "";
                    }
                }
                else
                {
                    mr.TYPE = "E";
                    mr.MESSAGE = "传入数据为空";
                }
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ROLE_CK");
            }
            return mr;
        }

        public MES_RETURN DELETE(int ROLEID)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ROLEID",ROLEID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE, parms)) { }
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ROLE_CK");
            }
            return mr;
        }

        public MES_ROLE_CK_LIST SELECT(int ROLEID)
        {
            MES_ROLE_CK_LIST rst = new MES_ROLE_CK_LIST();
            List<MES_ROLE_CK_LAY> child_MES_ROLE_CK_LAY = new List<MES_ROLE_CK_LAY>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {

                SqlParameter[] parms = {
                                       new SqlParameter("@ROLEID",ROLEID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BYROLEID, parms))
                {
                    while (sdr.Read())
                    {
                        MES_ROLE_CK_LAY child = new MES_ROLE_CK_LAY();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.CKDM = Convert.ToString(sdr["CKDM"]);
                        child.CKMS = Convert.ToString(sdr["CKMS"]);
                        child.ROLEID = ROLEID;
                        if (Convert.ToInt32(sdr["ROLEID"]) > 0)
                        {
                            child.LAY_CHECKED = true;
                        }
                        else
                        {
                            child.LAY_CHECKED = false;
                        }
                        child_MES_ROLE_CK_LAY.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
                rst.MES_ROLE_CK_LAY = child_MES_ROLE_CK_LAY;
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ROLE_CK");
            }
            return rst;
        }
        public int SELECT_COUNT_BY_STAFFID(string GC, string CKDM, int STAFFID)
        {
            int rst = 0;
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",GC),
                                       new SqlParameter("@CKDM",CKDM),
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_COUNT_BY_STAFFID, parms))
                {
                    while (sdr.Read())
                    {
                        rst = Convert.ToInt32(sdr["ROLECOUNT"]);
                    }
                }
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ROLE_GZZX_SELECT_COUNT_BY_STAFFID");
            }
            return rst;
        }
    }
}
