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
    public class SY_PLDH_PH : ISY_PLDH_PH
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_SY_PLDH_PH_INSERT";
        const string SQL_SELECT = "MES_SY_PLDH_PH_SELECT";
        const string SQL_SELECT_LB = "MES_SY_PLDH_PH_SELECT_LB";
        public MES_RETURN INSERT(MES_SY_PLDH_PH model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@PH",model.PH),
                                       new SqlParameter("@JYP",model.JYP)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PLDH_PH_INSERT");
            }
            return rst;
        }

        public MES_SY_PLDH_PH_SELECT SELECT(MES_SY_PLDH_PH model)
        {
            MES_SY_PLDH_PH_SELECT rst = new MES_SY_PLDH_PH_SELECT();
            List<MES_SY_PLDH_PH> child_MES_SY_PLDH_PH = new List<MES_SY_PLDH_PH>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@PH",model.PH),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PFLB",model.PFLB)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_PLDH_PH child = new MES_SY_PLDH_PH();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.PLDH = Convert.ToString(sdr["PLDH"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.PH = Convert.ToString(sdr["PH"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.PFLB = Convert.ToInt32(sdr["PFLB"]);
                        child.JYP = Convert.ToString(sdr["JYP"]);
                        child_MES_SY_PLDH_PH.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PLDH_PH_SELECT");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_PLDH_PH = child_MES_SY_PLDH_PH;
            return rst;
        }
        public MES_SY_PLDH_PH_SELECT SELECT_LB(MES_SY_PLDH_PH model)
        {
            MES_SY_PLDH_PH_SELECT rst = new MES_SY_PLDH_PH_SELECT();
            List<MES_SY_PLDH_PH> child_MES_SY_PLDH_PH = new List<MES_SY_PLDH_PH>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@PFLB",model.PFLB),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@USERDATES",model.USERDATES),
                                       new SqlParameter("@USERDATEE",model.USERDATEE)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LB, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_PLDH_PH child = new MES_SY_PLDH_PH();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.PLDH = Convert.ToString(sdr["PLDH"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.PH = Convert.ToString(sdr["PH"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.PFLB = Convert.ToInt32(sdr["PFLB"]);
                        child.JYP = Convert.ToString(sdr["JYP"]);
                        child.PFLBNAME = Convert.ToString(sdr["PFLBNAME"]);
                        child_MES_SY_PLDH_PH.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "SY_PLDH_PH_SELECT_LB", "MES");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_PLDH_PH = child_MES_SY_PLDH_PH;
            return rst;
        }
    }
}
