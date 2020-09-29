﻿using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.MES
{
    public class ROLE_RY_ASSEMBLE : IROLE_RY_ASSEMBLE
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "INSERT MES_ROLE_RY_ASSEMBLE(STAFFID,ROLEID) VALUES(@STAFFID,@ROLEID)";
        const string SQL_DELETE = "DELETE FROM MES_ROLE_RY_ASSEMBLE WHERE STAFFID=@STAFFID";
        public MES_RETURN INSERT(List<MES_ROLE_RY_ASSEMBLE> model)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ROLE_RY_ASSEMBLE_INSERT");
            }
            return mr;
        }
        public MES_RETURN DELETE(int STAFFID)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "ROLE_RY_ASSEMBLE_DELETE");
            }
            return mr;
        }
    }
}
