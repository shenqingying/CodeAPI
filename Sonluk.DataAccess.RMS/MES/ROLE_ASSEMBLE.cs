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
    public class ROLE_ASSEMBLE : IROLE_ASSEMBLE
    {
        string SQL_INSERT = "MES_ROLE_ASSEMBLE_INSERT";
        string SQL_UPDATE = "UPDATE MES_ROLE_ASSEMBLE SET ROLENAME=@ROLENAME WHERE ID=@ID";
        string SQL_SELECT = "MES_ROLE_ASSEMBLE_SELECT";
        string SQL_SELECT_LB = "MES_ROLE_ASSEMBLE_SELECT_LB";
        string SQL_DELETE = "UPDATE MES_ROLE_ASSEMBLE SET ISDELETE=1 WHERE ID=@ID";
        string SQL_SELECT_JS_LAY = "SELECT A.ROLEID,A.ROLENAME,a.ROLEMEMO,ISNULL(B.STAFFID,0) AS STAFFID FROM CRM_HG_ROLE AS A LEFT JOIN CRM_HG_STAFFROLE AS B ON A.ROLEID=B.ROLEID AND B.STAFFID=@STAFFID WHERE A.ISACTIVE=1 ";
        const string SQL_SELECT_LAY = "SELECT A.*,ISNULL(B.STAFFID,0) AS STAFFID FROM MES_ROLE_ASSEMBLE AS A LEFT JOIN MES_ROLE_RY_ASSEMBLE AS B ON A.ID=B.ROLEID AND B.STAFFID=@STAFFID WHERE A.ROLELB=@ROLELB AND A.ISDELETE=0 ORDER BY A.GC,A.ID";
        const string SQL_INSERT_JS = "INSERT CRM_HG_STAFFROLE(STAFFID,ROLEID) VALUES(@STAFFID,@ROLEID)";
        const string SQL_DELETE_JS = "DELETE FROM CRM_HG_STAFFROLE WHERE STAFFID=@STAFFID";
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        public MES_RETURN INSERT(MES_ROLE_ASSEMBLE model)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ROLENAME",model.ROLENAME),
                                       new SqlParameter("@ROLELB",model.ROLELB),
                                       new SqlParameter("@GC",model.GC)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms)) { }
                mr.TYPE = "S";
                mr.MESSAGE = "";

            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ROLE_ASSEMBLE");
            }
            return mr;
        }

        public MES_RETURN UPDATE(MES_ROLE_ASSEMBLE model)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@ROLENAME",model.ROLENAME)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_UPDATE, parms)) { }
                mr.TYPE = "S";
                mr.MESSAGE = "";

            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ROLE_ASSEMBLE");
            }
            return mr;
        }

        public MES_ROLE_ASSEMBLE_SELECT SELECT(MES_ROLE_ASSEMBLE model)
        {
            MES_ROLE_ASSEMBLE_SELECT rst = new MES_ROLE_ASSEMBLE_SELECT();
            List<MES_ROLE_ASSEMBLE> child_MES_ROLE_ASSEMBLE = new List<MES_ROLE_ASSEMBLE>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@ROLENAME",model.ROLENAME),
                                       new SqlParameter("@ROLELB",model.ROLELB),
                                       new SqlParameter("@GC",model.GC)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_ROLE_ASSEMBLE child = new MES_ROLE_ASSEMBLE();
                        child.ID = Convert.ToInt32(sdr["ID"]);
                        child.ROLENAME = Convert.ToString(sdr["ROLENAME"]);
                        child.ROLELB = Convert.ToInt32(sdr["ROLELB"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child_MES_ROLE_ASSEMBLE.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_ROLE_ASSEMBLE = child_MES_ROLE_ASSEMBLE;
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ROLE_ASSEMBLE");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_ROLE_ASSEMBLE_SELECT SELECT_LB(MES_ROLE_ASSEMBLE model)
        {
            MES_ROLE_ASSEMBLE_SELECT rst = new MES_ROLE_ASSEMBLE_SELECT();
            List<MES_ROLE_ASSEMBLE> child_MES_ROLE_ASSEMBLE = new List<MES_ROLE_ASSEMBLE>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@ROLENAME",model.ROLENAME),
                                       new SqlParameter("@ROLELB",model.ROLELB),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LB, parms))
                {
                    while (sdr.Read())
                    {
                        MES_ROLE_ASSEMBLE child = new MES_ROLE_ASSEMBLE();
                        child.ID = Convert.ToInt32(sdr["ID"]);
                        child.ROLENAME = Convert.ToString(sdr["ROLENAME"]);
                        child.ROLELB = Convert.ToInt32(sdr["ROLELB"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child_MES_ROLE_ASSEMBLE.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_ROLE_ASSEMBLE = child_MES_ROLE_ASSEMBLE;
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ROLE_ASSEMBLE_SELECT_LB","MES");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }


        public MES_RETURN DELETE(int ID)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ID",ID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ROLE_ASSEMBLE");
            }
            return mr;
        }

        public MES_ROLE_ASSEMBLE_JS_LAY_SELECT SELECT_JS_LAY(int STAFFID)
        {
            MES_ROLE_ASSEMBLE_JS_LAY_SELECT rst = new MES_ROLE_ASSEMBLE_JS_LAY_SELECT();
            List<MES_ROLE_ASSEMBLE_JS_LAY> child_MES_ROLE_ASSEMBLE_JS_LAY = new List<MES_ROLE_ASSEMBLE_JS_LAY>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_JS_LAY, parms))
                {
                    while (sdr.Read())
                    {
                        MES_ROLE_ASSEMBLE_JS_LAY child = new MES_ROLE_ASSEMBLE_JS_LAY();
                        child.ROLEID = Convert.ToInt32(sdr["ROLEID"]);
                        child.ROLENAME = Convert.ToString(sdr["ROLENAME"]);
                        child.STAFFID = STAFFID;
                        child.ROLEMEMO = Convert.ToString(sdr["ROLEMEMO"]);
                        if (Convert.ToInt32(sdr["STAFFID"]) > 0)
                        {
                            child.LAY_CHECKED = true;
                        }
                        else
                        {
                            child.LAY_CHECKED = false;
                        }
                        child_MES_ROLE_ASSEMBLE_JS_LAY.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ROLE_ASSEMBLE");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_ROLE_ASSEMBLE_JS_LAY = child_MES_ROLE_ASSEMBLE_JS_LAY;
            return rst;
        }

        public MES_ROLE_ASSEMBLE_LAY_SELECT SELECT_LAY(int STAFFID, int ROLELB)
        {
            MES_ROLE_ASSEMBLE_LAY_SELECT rst = new MES_ROLE_ASSEMBLE_LAY_SELECT();
            List<MES_ROLE_ASSEMBLE_LAY> child_MES_ROLE_ASSEMBLE_LAY = new List<MES_ROLE_ASSEMBLE_LAY>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@ROLELB",ROLELB)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_LAY, parms))
                {
                    while (sdr.Read())
                    {
                        MES_ROLE_ASSEMBLE_LAY child = new MES_ROLE_ASSEMBLE_LAY();
                        child.ID = Convert.ToInt32(sdr["ID"]);
                        child.ROLENAME = Convert.ToString(sdr["ROLENAME"]);
                        child.ROLELB = Convert.ToInt32(sdr["ROLELB"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.STAFFID = STAFFID;
                        if (Convert.ToInt32(sdr["STAFFID"]) > 0)
                        {
                            child.LAY_CHECKED = true;
                        }
                        else
                        {
                            child.LAY_CHECKED = false;
                        }
                        child_MES_ROLE_ASSEMBLE_LAY.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ROLE_ASSEMBLE_SELECT_LAY");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_ROLE_ASSEMBLE_LAY = child_MES_ROLE_ASSEMBLE_LAY;
            return rst;
        }

        public MES_RETURN INSERT_JS(List<MES_ROLE_ASSEMBLE_JS_LAY> model)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                if (model.Count > 0)
                {
                    for (int i = 0; i < model.Count; i++)
                    {
                        SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",model[i].STAFFID),
                                       new SqlParameter("@ROLEID",model[i].ROLEID)
                                   };
                        using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_INSERT_JS, parms)) { }
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ROLE_ASSEMBLE_SELECT_INSERT_JS");
            }
            return mr;
        }

        public MES_RETURN DELETE_JS(int STAFFID)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE_JS, parms)) { }
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ROLE_ASSEMBLE_SELECT_DELETE_JS");
            }
            return mr;
        }
    }
}
