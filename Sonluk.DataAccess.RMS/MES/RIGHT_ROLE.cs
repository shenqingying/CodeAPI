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
    public class RIGHT_ROLE : IRIGHT_ROLE
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_SELECT = "MES_RIGHT_ROLE_SELECT";
        const string SQL_SELECT_ANDROID_REOLE = "EM_RIGHT_ROLE_SELECT_ANDROID";
        const string SQL_SELECT_F = "SELECT * FROM CRM_HG_RIGHTGROUP WHERE PRGROUPID=@RGROUPID AND ISACTIVE=1";

        public MES_RIGHT_ROLE SELECT(int STAFFID, int RGROUPID, int LANGUAGEID)
        {
            MES_RIGHT_ROLE rst = new MES_RIGHT_ROLE();
            List<CRM_HG_RIGHT> child_CRM_HG_RIGHT = new List<CRM_HG_RIGHT>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] param ={
                                          new SqlParameter("@STAFFID",STAFFID),
                                          new SqlParameter("@RGROUPID",RGROUPID),
                                          new SqlParameter("@LANGUAGEID",LANGUAGEID)
                                     };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, param))
                {
                    while (sdr.Read())
                    {
                        CRM_HG_RIGHT child = new CRM_HG_RIGHT();
                        child.RIGHTID = Convert.ToInt32(sdr["RIGHTID"]);
                        child.RGROUPID = Convert.ToInt32(sdr["RGROUPID"]);
                        child.RIGHTNAME = Convert.ToString(sdr["RIGHTNAME"]);
                        child.RIGHTNO = Convert.ToInt32(sdr["RIGHTNO"]);
                        child.RIGHTADD = Convert.ToString(sdr["RIGHTADD"]);
                        child.RIGHTMEMO = Convert.ToString(sdr["RIGHTMEMO"]);
                        child.IMAGELJ = Convert.ToString(sdr["IMAGELJ"]);
                        child_CRM_HG_RIGHT.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "RIGHT_ROLE_SELECT");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.CRM_HG_RIGHT = child_CRM_HG_RIGHT;
            return rst;
        }

        public MES_RIGHT_ROLE SELECT_ALL(int STAFFID, int RGROUPID, int LANGUAGEID)
        {
            MES_RIGHT_ROLE rst = new MES_RIGHT_ROLE();
            MES_RIGHT_ROLE rst_MES_RIGHT_ROLE = new MES_RIGHT_ROLE();
            List<CRM_HG_RIGHTGROUP> child_CRM_HG_RIGHTGROUP = new List<CRM_HG_RIGHTGROUP>();
            List<CRM_HG_RIGHT> child_CRM_HG_RIGHT = new List<CRM_HG_RIGHT>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            rst_MES_RIGHT_ROLE = SELECT(STAFFID, RGROUPID, LANGUAGEID);
            if (rst_MES_RIGHT_ROLE.MES_RETURN.TYPE == "S")
            {
                if (rst_MES_RIGHT_ROLE.CRM_HG_RIGHT.Count > 0)
                {
                    child_CRM_HG_RIGHT = rst_MES_RIGHT_ROLE.CRM_HG_RIGHT;
                }
            }
            try
            {
                SqlParameter[] param ={
                                          new SqlParameter("@RGROUPID",RGROUPID)
                                     };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_F, param))
                {
                    while (sdr.Read())
                    {
                        CRM_HG_RIGHTGROUP child = new CRM_HG_RIGHTGROUP();
                        child.RGROUPID = Convert.ToInt32(sdr["RGROUPID"]);
                        child.RGROUPNAME = Convert.ToString(sdr["RGROUPNAME"]);
                        child.PRGROUPID = Convert.ToInt32(sdr["PRGROUPID"]);
                        child.PRIGHTNO = Convert.ToInt32(sdr["PRIGHTNO"]);
                        child.RGROUPMEMO = Convert.ToString(sdr["RGROUPMEMO"]);
                        child.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
                        child.IMAGELJ = Convert.ToString(sdr["IMAGELJ"]);
                        rst_MES_RIGHT_ROLE = SELECT(STAFFID, child.RGROUPID, LANGUAGEID);
                        if (rst_MES_RIGHT_ROLE.MES_RETURN.TYPE == "S")
                        {
                            if (rst_MES_RIGHT_ROLE.CRM_HG_RIGHT.Count > 0)
                            {
                                child.CRM_HG_RIGHT = rst_MES_RIGHT_ROLE.CRM_HG_RIGHT;
                            }
                        }
                        child_CRM_HG_RIGHTGROUP.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "RIGHT_ROLE_SELECT");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.CRM_HG_RIGHT = child_CRM_HG_RIGHT;
            rst.CRM_HG_RIGHTGROUP = child_CRM_HG_RIGHTGROUP;
            return rst;
        }

        public MES_RIGHT_ROLE SELECT_Android(int STAFFID)
        {
            
            MES_RIGHT_ROLE rst = new MES_RIGHT_ROLE();
            List<CRM_HG_RIGHT> child_CRM_HG_RIGHT = new List<CRM_HG_RIGHT>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
        
                 SqlParameter[] param ={
                                          new SqlParameter("@STAFFID",STAFFID),
                                     
                                     };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_ANDROID_REOLE, param))
                {
                    while (sdr.Read())
                    {
                        CRM_HG_RIGHT child = new CRM_HG_RIGHT();
                        child.RIGHTID = Convert.ToInt32(sdr["RIGHTID"]);
                        child.RGROUPID = Convert.ToInt32(sdr["RGROUPID"]);
                        child.RIGHTNAME = Convert.ToString(sdr["RIGHTNAME"]);
                        child.RIGHTNO = Convert.ToInt32(sdr["RIGHTNO"]);
                        child.RIGHTADD = Convert.ToString(sdr["RIGHTADD"]);
                        child.RIGHTMEMO = Convert.ToString(sdr["GROUPNAME"]).Split('-')[1];
                        child.IMAGELJ = Convert.ToString(sdr["IMAGELJ"]);
                        child_CRM_HG_RIGHT.Add(child);
                    }
                    child_MES_RETURN.TYPE = "S";
                    child_MES_RETURN.MESSAGE = "";
                }
                if (child_CRM_HG_RIGHT.Count == 0)
                {
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "找不到人员对应的权限";
                }

                rst.MES_RETURN = child_MES_RETURN;
                rst.CRM_HG_RIGHT = child_CRM_HG_RIGHT;
                return rst;
        }




    }
}
