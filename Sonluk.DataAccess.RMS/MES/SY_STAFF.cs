using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using Sonluk.Utility.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.MES
{
    public class SY_STAFF : ISY_STAFF
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_SELECT = "MES_SY_STAFF_SELECT";
        const string SQL_UPDATE_STAFFPW = "MES_SY_STAFF_UPDATE_STAFFPW";
        public MES_SY_STAFF_SELECT SELECT(MES_SY_STAFF model)
        {
            MES_SY_STAFF_SELECT rst = new MES_SY_STAFF_SELECT();
            List<MES_SY_STAFF> child_MES_SY_STAFF = new List<MES_SY_STAFF>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DEPID",model.DEPID),
                                       new SqlParameter("@STAFFNAME",model.STAFFNAME),
                                       new SqlParameter("@STAFFNO",model.STAFFNO),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@USERLX",model.USERLX)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_STAFF child = new MES_SY_STAFF();
                        child.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
                        child.DEPID = Convert.ToInt32(sdr["DEPID"]);
                        child.DEPNAME = Convert.ToString(sdr["DEPNAME"]);
                        child.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
                        child.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
                        child.STAFFUSER = Convert.ToString(sdr["STAFFUSER"]);
                        child.STAFFPW = Convert.ToString(sdr["STAFFPW"]);
                        child.STAFFSEX = Convert.ToInt32(sdr["STAFFSEX"]);
                        child.STAFFMOBILE = Convert.ToString(sdr["STAFFMOBILE"]);
                        child.STAFFTEL = Convert.ToString(sdr["STAFFTEL"]);
                        child.JLRQ = Convert.ToDateTime(sdr["JLRQ"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.SISLOCK = Convert.ToBoolean(sdr["SISLOCK"]);
                        child.SCANCEL = Convert.ToBoolean(sdr["SCANCEL"]);
                        child.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
                        child.ISINIT = Convert.ToInt32(sdr["ISINIT"]);
                        child.UPDATEPWDATE = Convert.ToString(sdr["UPDATEPWDATE"]);
                        child.USERLX = Convert.ToInt32(sdr["USERLX"]);
                        child_MES_SY_STAFF.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_STAFF_SELECT");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_STAFF = child_MES_SY_STAFF;
            return rst;
        }

        public MES_RETURN UPDATE_STAFFPW(int STAFFID, string OLDPW, string NEWPW)
        {
            OLDPW = MD5Hash.GetMd5Hash(OLDPW).ToUpper();
            NEWPW = MD5Hash.GetMd5Hash(NEWPW).ToUpper();
            MES_RETURN rst = new MES_RETURN();
            try
            {

                SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@OLDPW",OLDPW),
                                       new SqlParameter("@NEWPW",NEWPW)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_STAFFPW, parms))
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_STAFF_UPDATE_STAFFPW");
            }
            return rst;
        }
    }
}
