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
    public class ZS_SY_KU : IZS_SY_KU
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_ZS_SY_KU_INSERT";
        const string SQL_SELECT = "MES_ZS_SY_KU_SELECT";
        const string SQL_UPDATE = "MES_ZS_SY_KU_UPDATE";
        public MES_RETURN INSERT(MES_ZS_SY_KU model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@KHMS",model.KHMS),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@KHNO",model.KHNO),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@GSTYPE",model.GSTYPE),
                                       new SqlParameter("@GC",model.GC)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_SY_KU_INSERT", "MES_ZS");
            }
            return rst;
        }
        public MES_RETURN UPDATE(MES_ZS_SY_KU model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@KHMS",model.KHMS),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@KHNO",model.KHNO),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@KHID",model.KHID)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_SY_KU_UPDATE", "MES_ZS");
            }
            return rst;
        }
        public MES_ZS_SY_KU_SELECT SELECT(MES_ZS_SY_KU model)
        {
            MES_ZS_SY_KU_SELECT rst = new MES_ZS_SY_KU_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_ZS_SY_KU> child_MES_ZS_SY_KU = new List<MES_ZS_SY_KU>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@KHMS",model.KHMS),
                                       new SqlParameter("@KHNO",model.KHNO),
                                       new SqlParameter("@GSTYPE",model.GSTYPE),
                                       new SqlParameter("@GC",model.GC)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_ZS_SY_KU child = new MES_ZS_SY_KU();
                        child.KHID = Convert.ToInt32(sdr["KHID"]);
                        child.KHMS = Convert.ToString(sdr["KHMS"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.KHNO = Convert.ToString(sdr["KHNO"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.GSTYPE = Convert.ToInt32(sdr["GSTYPE"]);
                        child.GSTYPENAME = Convert.ToString(sdr["GSTYPENAME"]);
                        child_MES_ZS_SY_KU.Add(child);
                    }
                    child_MES_RETURN.TYPE = "S";
                    child_MES_RETURN.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_ZS_SY_KU_SELECT", "MES_ZS");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_ZS_SY_KU = child_MES_ZS_SY_KU;
            return rst;
        }
    }
}
