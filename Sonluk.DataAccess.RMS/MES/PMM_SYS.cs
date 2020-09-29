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
    class PMM_SYS : IPMM_SYS
    {
        const string SQL_PMM_SYS_SELECT = "MES_PMM_SYS_SELECT";
        const string SQL_PMM_SYS_UPDATE = "MES_PMM_SYS_UPDATE";

        public MES_PMM_SYS SELECT(MES_PMM_SYS model)
        {
            MES_PMM_SYS rst = new MES_PMM_SYS();
            rst.MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@KEY",model.KEY)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_SYS_SELECT, parms))
                {
                    if (sdr.Read())
                    {
                        rst.KEY = Convert.ToString(sdr["KEY"]);
                        rst.VALUE = Convert.ToString(sdr["VALUE"]);
                        rst.MES_RETURN.TYPE = "S";
                        rst.MES_RETURN.MESSAGE = "无";
                    }
                    else
                    {
                        rst.MES_RETURN.TYPE = "E";
                        rst.MES_RETURN.MESSAGE = "无返回值";
                    }
                }
            }
            catch (Exception e)
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = e.Message;
            }
            return rst;
        }

        public MES_RETURN UPDATE(MES_PMM_SYS model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@KEY",model.KEY),
                                       new SqlParameter("@VALUE",model.VALUE)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_SYS_UPDATE, parms))
                {
                    if (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                    else
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "无返回值";
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return rst;
        }
    }
}
