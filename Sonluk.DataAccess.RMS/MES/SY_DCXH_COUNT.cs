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
    public class SY_DCXH_COUNT : ISY_DCXH_COUNT
    {
        SY_EXCEPTION SY_EXCEPTIONService = new SY_EXCEPTION();
        const string SQL_SELECT = "MES_SY_DCXH_COUNT_SELECT";
        const string SQL_INSERT = "MES_SY_DCXH_COUNT_INSERT";
        const string SQL_UPDATE = "UPDATE MES_SY_DCXH_COUNT SET SL=@SL WHERE GC=@GC AND DCXHID=@DCXHID";
        const string SQL_DELETE = "DELETE FROM MES_SY_DCXH_COUNT WHERE GC=@GC AND DCXHID=@DCXHID";
        const string SQL_SELECT_LB = "MES_SY_DCXH_COUNT_SELECT_LB";
        public MES_SY_DCXH_COUNT_SELECT SELECT(MES_SY_DCXH_COUNT model)
        {
            MES_SY_DCXH_COUNT_SELECT rst = new MES_SY_DCXH_COUNT_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_SY_DCXH_COUNT> child_MES_SY_DCXH_COUNT = new List<MES_SY_DCXH_COUNT>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@DCXHID",model.DCXHID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_DCXH_COUNT child = new MES_SY_DCXH_COUNT();
                        child.DCXHID = Convert.ToInt32(sdr["DCXHID"]);
                        child.DCXH = Convert.ToString(sdr["DCXH"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.SL = Convert.ToInt32(sdr["SL"]);
                        child_MES_SY_DCXH_COUNT.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                rst.MES_RETURN = child_MES_RETURN;
                rst.MES_SY_DCXH_COUNT = child_MES_SY_DCXH_COUNT;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_DCXH_COUNT");
            }
            return rst;
        }
        public MES_SY_DCXH_COUNT_SELECT SELECT_LB(MES_SY_DCXH_COUNT model)
        {
            MES_SY_DCXH_COUNT_SELECT rst = new MES_SY_DCXH_COUNT_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_SY_DCXH_COUNT> child_MES_SY_DCXH_COUNT = new List<MES_SY_DCXH_COUNT>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@DCXHID",model.DCXHID),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LB, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_DCXH_COUNT child = new MES_SY_DCXH_COUNT();
                        child.DCXHID = Convert.ToInt32(sdr["DCXHID"]);
                        child.DCXH = Convert.ToString(sdr["DCXH"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.SL = Convert.ToInt32(sdr["SL"]);
                        child_MES_SY_DCXH_COUNT.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                rst.MES_RETURN = child_MES_RETURN;
                rst.MES_SY_DCXH_COUNT = child_MES_SY_DCXH_COUNT;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONService.INSERT_SY(e.ToString(), "SY_DCXH_COUNT_SELECT_LB", "MES");
            }
            return rst;
        }

        public MES_RETURN INSERT(MES_SY_DCXH_COUNT model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@DCXHID",model.DCXHID),
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
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_DCXH_COUNT");
            }
            return rst;
        }

        public MES_RETURN UPDATE(MES_SY_DCXH_COUNT model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@DCXHID",model.DCXHID),
                                       new SqlParameter("@SL",model.SL)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_UPDATE, parms))
                {
                }
                rst.TYPE = "S";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_DCXH_COUNT");
            }
            return rst;
        }

        public MES_RETURN DELETE(MES_SY_DCXH_COUNT model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@DCXHID",model.DCXHID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE, parms))
                {
                }
                rst.TYPE = "S";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_DCXH_COUNT");
            }
            return rst;
        }
    }
}
