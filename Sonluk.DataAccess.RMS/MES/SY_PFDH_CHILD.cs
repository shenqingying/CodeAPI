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
    public class SY_PFDH_CHILD : ISY_PFDH_CHILD
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_SY_PFDH_CHILD_INSERT";
        const string SQL_DELETE = "MES_SY_PFDH_CHILD_DELETE";
        const string SQL_SELECT = "MES_SY_PFDH_CHILD_SELECT";
        public MES_RETURN INSERT(MES_SY_PFDH_CHILD model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PFLB",model.PFLB),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@REMARK",model.REMARK)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PFDH_CHILD_INSERT");
            }
            return rst;
        }

        public MES_RETURN DELETE(MES_SY_PFDH_CHILD model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PFLB",model.PFLB),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@LB",LB)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PFDH_CHILD_DELETE");
            }
            return rst;
        }

        public MES_SY_PFDH_CHILD_SELECT SELECT(MES_SY_PFDH_CHILD model)
        {
            MES_SY_PFDH_CHILD_SELECT rst = new MES_SY_PFDH_CHILD_SELECT();
            List<MES_SY_PFDH_CHILD> child_MES_SY_PFDH_CHILD = new List<MES_SY_PFDH_CHILD>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PFLB",model.PFLB),
                                       new SqlParameter("@WLH",model.WLH),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_PFDH_CHILD child = new MES_SY_PFDH_CHILD();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.PFLB = Convert.ToInt32(sdr["PFLB"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child_MES_SY_PFDH_CHILD.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PFDH_CHILD_SELECT");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_PFDH_CHILD = child_MES_SY_PFDH_CHILD;
            return rst;
        }
    }
}
