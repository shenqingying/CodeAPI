using Sonluk.Entities.API;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sonluk.DataAccess.RMS.MES
{
    class PMM_STAFF : IPMM_STAFF
    {
        const string SQL_PMM_STAFF_SELECT = "MES_PMM_STAFF_SELECT";
        const string SQL_PMM_STAFF_COVER = "MES_PMM_STAFF_COVER";
        const string SQL_PMM_STAFF_DELETE = "MES_PMM_STAFF_DELETE";

        public MES_PMM_STAFF_SELECT SELECT(MES_PMM_STAFF model)
        {
            MES_PMM_STAFF_SELECT rst = new MES_PMM_STAFF_SELECT();
            rst.MES_PMM_STAFF = new List<MES_PMM_STAFF>();
            rst.MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@NAME",model.NAME),
                                       new SqlParameter("@ROLE",model.ROLE)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_STAFF_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PMM_STAFF child = new MES_PMM_STAFF();
                        child.SID = Convert.ToInt32(sdr["SID"]);
                        child.NAME = Convert.ToString(sdr["NAME"]);
                        child.ROLE = Convert.ToString(sdr["ROLE"]);
                        rst.MES_PMM_STAFF.Add(child);
                    }
                    rst.MES_RETURN.TYPE = "S";
                    rst.MES_RETURN.MESSAGE = "无";
                }
            }
            catch (Exception e)
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = e.Message;
            }
            return rst;
        }

        public MES_RETURN COVER(MES_PMM_STAFF model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@SID",model.SID),
                                       new SqlParameter("@NAME",model.NAME),
                                       new SqlParameter("@ROLE",model.ROLE),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_STAFF_COVER, parms))
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

        public MES_RETURN DELETE(MES_PMM_STAFF model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@SID",model.SID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_STAFF_DELETE, parms))
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

        #region API格式

        public ApiReturn Read(MES_PMM_STAFF model)
        {
            ApiReturn<List<MES_PMM_STAFF>> rst = new ApiReturn<List<MES_PMM_STAFF>>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@NAME",model.NAME),
                                       new SqlParameter("@ROLE",model.ROLE)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_STAFF_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PMM_STAFF child = new MES_PMM_STAFF();
                        child.SID = Convert.ToInt32(sdr["SID"]);
                        child.NAME = Convert.ToString(sdr["NAME"]);
                        child.ROLE = Convert.ToString(sdr["ROLE"]);
                        rst.data.Add(child);
                    }
                    rst.success = true;
                }
            }
            catch (Exception e)
            {
                //导入e，获得id
                rst.AddCode(false, "00005", "id号");
            }
            return rst;
        }

        public ApiReturn Update(MES_PMM_STAFF model)
        {
            ApiReturn rst = new ApiReturn();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@SID",model.SID),
                                       new SqlParameter("@NAME",model.NAME),
                                       new SqlParameter("@ROLE",model.ROLE),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_STAFF_COVER, parms))
                {
                    if (sdr.Read())
                    {
                        //存储过程返回
                        rst.AddCode(Convert.ToBoolean(sdr["Success"]), Convert.ToString(sdr["Code"]));
                    }
                    else
                    {
                        //存储过程逻辑缺陷
                        rst.AddCode(false, "10000");
                    }
                }
            }
            catch (Exception e)
            {
                //导入e，获得id
                rst.AddCode(false, "00005", "id号");
            }
            return rst;
        }

        public ApiReturn Delete(MES_PMM_STAFF model)
        {
            ApiReturn rst = new ApiReturn();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@SID",model.SID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_STAFF_DELETE, parms))
                {
                    if (sdr.Read())
                    {
                        //存储过程返回
                        rst.AddCode(Convert.ToBoolean(sdr["Success"]), Convert.ToString(sdr["Code"]));
                    }
                    else
                    {
                        //存储过程逻辑缺陷
                        rst.AddCode(false, "10000");
                    }
                }
            }
            catch (Exception e)
            {
                //导入e，获得id
                rst.AddCode(false, "00005", "id号");
            }
            return rst;
        }

        #endregion
    }
}
