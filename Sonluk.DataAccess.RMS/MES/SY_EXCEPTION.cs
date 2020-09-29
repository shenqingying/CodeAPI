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
    public class SY_EXCEPTION : ISY_EXCEPTION
    {
        const string SQL_INSERT = "INSERT MES_SY_EXCEPTION(EXCEPTIONINFO,EXCEPTIONTIME,EXCEPTIONMK,EXCEPTIONIN,EXCEPTIONSY) VALUES(@EXCEPTIONINFO,GETDATE(),@EXCEPTIONMK,'','')";
        const string SQL_INSERT_IN = "INSERT MES_SY_EXCEPTION(EXCEPTIONINFO,EXCEPTIONTIME,EXCEPTIONMK,EXCEPTIONIN,EXCEPTIONSY) VALUES(@EXCEPTIONINFO,GETDATE(),@EXCEPTIONMK,@EXCEPTIONIN,'')";
        const string SQL_INSERT_SY = "INSERT MES_SY_EXCEPTION(EXCEPTIONINFO,EXCEPTIONTIME,EXCEPTIONMK,EXCEPTIONIN,EXCEPTIONSY) VALUES(@EXCEPTIONINFO,GETDATE(),@EXCEPTIONMK,'',@EXCEPTIONSY)";
        const string SQL_INSERT_ALL = "INSERT MES_SY_EXCEPTION(EXCEPTIONINFO,EXCEPTIONTIME,EXCEPTIONMK,EXCEPTIONIN,EXCEPTIONSY) VALUES(@EXCEPTIONINFO,GETDATE(),@EXCEPTIONMK,@EXCEPTIONIN,@EXCEPTIONSY)";

        const string SQL_INSERT_CCGC = "MES_SY_CCGCRETRUN_INSERT";
        public MES_RETURN INSERT(string EXCEPTIONINFO, string EXCEPTIONMK)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@EXCEPTIONINFO",EXCEPTIONINFO),
                                       new SqlParameter("@EXCEPTIONMK",EXCEPTIONMK)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_INSERT, parms))
                {
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return rst;
        }
        public MES_RETURN INSERT_IN(string EXCEPTIONINFO, string EXCEPTIONMK, string EXCEPTIONIN)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@EXCEPTIONINFO",EXCEPTIONINFO),
                                       new SqlParameter("@EXCEPTIONMK",EXCEPTIONMK),
                                       new SqlParameter("@EXCEPTIONIN",EXCEPTIONIN)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_INSERT_IN, parms))
                {
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return rst;
        }
        public MES_RETURN INSERT_SY(string EXCEPTIONINFO, string EXCEPTIONMK, string EXCEPTIONSY)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@EXCEPTIONINFO",EXCEPTIONINFO),
                                       new SqlParameter("@EXCEPTIONMK",EXCEPTIONMK),
                                       new SqlParameter("@EXCEPTIONSY",EXCEPTIONSY)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_INSERT_SY, parms))
                {
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return rst;
        }
        public MES_RETURN INSERT_ALL(string EXCEPTIONINFO, string EXCEPTIONMK, string EXCEPTIONIN, string EXCEPTIONSY)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@EXCEPTIONINFO",EXCEPTIONINFO),
                                       new SqlParameter("@EXCEPTIONMK",EXCEPTIONMK),
                                       new SqlParameter("@EXCEPTIONIN",EXCEPTIONIN),
                                       new SqlParameter("@EXCEPTIONSY",EXCEPTIONSY)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_INSERT_ALL, parms))
                {
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return rst;
        }
        public MES_RETURN INSERT_CCGC(MES_SY_CCGCRETRUN model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@CCGC",model.CCGC),
                                       new SqlParameter("@TYPE",model.TYPE),
                                       new SqlParameter("@MESSAGE",model.MESSAGE)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_CCGC, parms))
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
                INSERT(e.ToString(), "SY_DCXH_COUNT");
            }
            return rst;
        }
    }
}
