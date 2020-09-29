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
    public class PD_GD_BOM : IPD_GD_BOM
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_PD_GD_BOM_INSERT";
        const string SQL_DELETE = "MES_PD_GD_BOM_DELETE";
        const string SQL_SELECT = "MES_PD_GD_BOM_SELECT";
        public MES_RETURN INSERT(MES_PD_GD_BOM model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GDDH",model.GDDH),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@SL",model.SL)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_GD_BOM_INSERT");
            }
            return rst;
        }

        public MES_RETURN DELETE(MES_PD_GD_BOM model, int DELETELB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GDDH",model.GDDH),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@DELETELB",DELETELB)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE, parms))
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_GD_BOM_DELETE");
            }
            return rst;
        }

        public MES_PD_GD_BOM_SELECT SELECT(MES_PD_GD_BOM model)
        {
            MES_PD_GD_BOM_SELECT rst = new MES_PD_GD_BOM_SELECT();
            List<MES_PD_GD_BOM_LIST> child_MES_PD_GD_BOM = new List<MES_PD_GD_BOM_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = { 
                                       new SqlParameter("@GDDH",model.GDDH)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PD_GD_BOM_LIST child = new MES_PD_GD_BOM_LIST();
                        child.GDDH = Convert.ToString(sdr["GDDH"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.SL = Convert.ToDecimal(sdr["SL"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.WLGROUP = Convert.ToString(sdr["WLGROUP"]);
                        child.ISTRACE = Convert.ToInt32(sdr["ISTRACE"]);
                        child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child_MES_PD_GD_BOM.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_GD_BOM_SELECT");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_PD_GD_BOM = child_MES_PD_GD_BOM;
            return rst;
        }
    }
}
