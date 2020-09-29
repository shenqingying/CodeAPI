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
    public class ROLR_GZZX_GW : IROLR_GZZX_GW
    {
        const string SQL_INSERT = "INSERT MES_ROLR_GZZX_GW(ROLEID,GWID) VALUES(@ROLEID,@GWID)";
        const string SQL_DELETE = "DELETE FROM MES_ROLR_GZZX_GW WHERE ROLEID=@ROLEID";
        const string SQL_SELECT_BYROLEID = "MES_ROLR_GZZX_GW_SELECT_BYROLEID";
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        public MES_RETURN INSERT(List<MES_ROLR_GZZX_GW> model)
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
                                       new SqlParameter("@GWID",model[i].GWID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ROLR_GZZX_GW");
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ROLR_GZZX_GW");
            }
            return mr;
        }

        public MES_ROLR_GZZX_GW_LIST SELECT(int ROLEID)
        {
            MES_ROLR_GZZX_GW_LIST rst = new MES_ROLR_GZZX_GW_LIST();
            List<MES_ROLR_GZZX_GW> child_MES_ROLR_GZZX_GW = new List<MES_ROLR_GZZX_GW>();
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
                        MES_ROLR_GZZX_GW child = new MES_ROLR_GZZX_GW();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GWID = Convert.ToInt32(sdr["ID"]);
                        child.GWNAME = Convert.ToString(sdr["MXNAME"]);
                        child.ROLEID = ROLEID;
                        if (Convert.ToInt32(sdr["ROLEID"]) > 0)
                        {
                            child.LAY_CHECKED = true;
                        }
                        else
                        {
                            child.LAY_CHECKED = false;
                        }
                        child_MES_ROLR_GZZX_GW.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
                rst.MES_ROLR_GZZX_GW = child_MES_ROLR_GZZX_GW;
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ROLR_GZZX_GW");
            }
            return rst;
        }
    }
}
