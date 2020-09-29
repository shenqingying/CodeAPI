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
    public class SY_PFDH : ISY_PFDH
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_SY_PFDH_INSERT";
        const string SQL_SELECT_COUNT = "SELECT COUNT(*) AS MCOUNT FROM MES_SY_PFDH WHERE PFDH=@PFDH AND GC=@GC";
        const string SQL_SELECT = "MES_SY_PFDH_SELECT";
        const string SQL_UPDATE = "MES_SY_PFDH_UPDATE";
        //const string SQL_DELETE = "DELETE FROM MES_SY_PFDH WHERE GC=@GC AND LB=@LB AND PFDH=@PFDH";
        const string SQL_DELETE = "MES_SY_PFDH_DELETE";
        public MES_RETURN INSERT(MES_SY_PFDH model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJRID",model.CJRID),
                                       new SqlParameter("@CJR",model.CJR)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PFDH");
            }
            return rst;
        }

        public int SELECT_COUNT(MES_SY_PFDH model)
        {
            int rst = 0;
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@GC",model.GC)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_COUNT, parms))
                {
                    while (sdr.Read())
                    {
                        rst = Convert.ToInt32(sdr["MCOUNT"]);
                    }
                }
            }
            catch (Exception e)
            {

                //throw new ApplicationException(e.Message);
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PFDH_SELECT_COUNT");
            }
            return rst;
        }

        public MES_SY_PFDH_LIST SELECT(MES_SY_PFDH model)
        {
            MES_SY_PFDH_LIST rst = new MES_SY_PFDH_LIST();
            List<MES_SY_PFDH> child_MES_SY_PFDH = new List<MES_SY_PFDH>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@LBNAME",model.LBNAME)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_PFDH child = new MES_SY_PFDH();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.LB = Convert.ToInt32(sdr["LB"]);
                        child.LBNAME = Convert.ToString(sdr["LBNAME"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child_MES_SY_PFDH.Add(child);
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PFDH");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_PFDH = child_MES_SY_PFDH;
            return rst;
        }

        public MES_RETURN UPDATE(MES_SY_PFDH model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@XGRID",model.XGRID),
                                       new SqlParameter("@XGR",model.XGR)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PFDH");
            }
            return rst;
        }

        public MES_RETURN DELETE(MES_SY_PFDH model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@PFDH",model.PFDH)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PFDH_DELETE");
            }
            return rst;
        }
    }
}
