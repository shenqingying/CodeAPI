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
    class BAT_QLTY_STAFF : IBAT_QLTY_STAFF
    {
        const string SQL_SELECT = "MES_ZLRBB_STAFF_SELECT";
        const string SQL_COVER = "MES_ZLRBB_STAFF_COVER";
        const string SQL_DELETE = "MES_ZLRBB_STAFF_DELETE";

        public MES_SELECT<MES_ZLRBB_STAFF> SELECT(MES_ZLRBB_STAFF model)
        {
            MES_SELECT<MES_ZLRBB_STAFF> rst = new MES_SELECT<MES_ZLRBB_STAFF>();
            rst.TList = new List<MES_ZLRBB_STAFF>();
            rst.MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@ID", model.ID),
                                           new SqlParameter("@STAFFNO", model.STAFFNO),
                                           new SqlParameter("@STAFFNAME", model.STAFFNAME),
                                           new SqlParameter("@ISACTION", model.ISACTION),
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_ZLRBB_STAFF child = new MES_ZLRBB_STAFF();
                        child.ID = Convert.ToInt32(sdr["ID"]);
                        child.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
                        child.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        rst.TList.Add(child);
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

        public MES_RETURN COVER(MES_ZLRBB_STAFF model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@ID", model.ID),
                                           new SqlParameter("@STAFFNO", model.STAFFNO),
                                           new SqlParameter("@STAFFNAME", model.STAFFNAME),
                                           new SqlParameter("@ISACTION", model.ISACTION),
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_COVER, parms))
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

        public MES_RETURN DELETE(int ID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@ID", ID),
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE, parms))
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
