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
    public class PMM_MTC : IPMM_MTC
    {
        const string SQL_PMM_MTC_SELECT = "MES_PMM_MTC_SELECT";
        const string SQL_PMM_MTC_INSERT = "MES_PMM_MTC_INSERT";
        const string SQL_PMM_MTC_UPDATE = "MES_PMM_MTC_UPDATE";
        const string SQL_PMM_MTC_UPDATE_CFMBACK = "MES_PMM_MTC_UPDATE_CFMBACK";
        const string SQL_PMM_MTC_DELETE = "MES_PMM_MTC_DELETE";

        public MES_PMM_MTC_SELECT SELECT(MES_PMM_MTC model)
        {
            MES_PMM_MTC_SELECT rst = new MES_PMM_MTC_SELECT();
            rst.MES_PMM_MTC = new List<MES_PMM_MTC>();
            rst.MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.MES_PMM_MOULD.GC),
                                       new SqlParameter("@GZZXBH",model.MES_PMM_MOULD.GZZXBH),
                                       new SqlParameter("@MID",model.MID),
                                       new SqlParameter("@MOULD",model.MES_PMM_MOULD.MOULD),
                                       new SqlParameter("@QID",model.QID),
                                       new SqlParameter("@RID",model.RID),
                                       new SqlParameter("@DATESS",model.DATESS),
                                       new SqlParameter("@DATESE",model.DATESE),
                                       new SqlParameter("@DATEES",model.DATEES),
                                       new SqlParameter("@DATEEE",model.DATEEE),
                                       new SqlParameter("@STATUS",model.STATUS),
                                       new SqlParameter("@OPERATE",model.OPERATE),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_MTC_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PMM_MTC child = new MES_PMM_MTC();
                        child.MES_PMM_MOULD = new MES_PMM_MOULD();
                        child.MTCID = Convert.ToInt32(sdr["MTCID"]);
                        child.MID = Convert.ToString(sdr["MID"]);
                        child.MES_PMM_MOULD.GC = Convert.ToString(sdr["GC"]);
                        child.MES_PMM_MOULD.GCMS = Convert.ToString(sdr["GCMS"]);
                        child.MES_PMM_MOULD.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.MES_PMM_MOULD.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        child.MES_PMM_MOULD.MOULD = Convert.ToString(sdr["MOULD"]);
                        child.QID = Convert.ToInt32(sdr["QID"]);
                        child.QCODE = Convert.ToString(sdr["QCODE"]);
                        child.QNAME = Convert.ToString(sdr["QNAME"]);
                        if (sdr["DATES"] != DBNull.Value) child.DATES = Convert.ToDateTime(sdr["DATES"]);
                        if (sdr["DATEE"] != DBNull.Value) child.DATEE = Convert.ToDateTime(sdr["DATEE"]);

                        child.MMSTAFF = Convert.ToInt32(sdr["MMSTAFF"]);
                        child.MMSTAFFNAME = Convert.ToString(sdr["MMSTAFFNAME"]);
                        child.MMCFM = Convert.ToInt32(sdr["MMCFM"]);
                        if (sdr["MMDATE"] != DBNull.Value) child.MMDATE = Convert.ToDateTime(sdr["MMDATE"]);

                        child.WTSTAFF = Convert.ToInt32(sdr["WTSTAFF"]);
                        child.WTSTAFFNAME = Convert.ToString(sdr["WTSTAFFNAME"]);
                        child.WTCFM = Convert.ToInt32(sdr["WTCFM"]);
                        if (sdr["WTDATE"] != DBNull.Value) child.WTDATE = Convert.ToDateTime(sdr["WTDATE"]);
                        child.WTNOTES = Convert.ToString(sdr["WTNOTES"]);

                        child.QCSTAFF = Convert.ToInt32(sdr["QCSTAFF"]);
                        child.QCSTAFFNAME = Convert.ToString(sdr["QCSTAFFNAME"]);
                        child.QCCFM = Convert.ToInt32(sdr["QCCFM"]);
                        if (sdr["QCDATE"] != DBNull.Value) child.QCDATE = Convert.ToDateTime(sdr["QCDATE"]);
                        child.QCNOTES = Convert.ToString(sdr["QCNOTES"]);

                        child.TECSTAFF = Convert.ToInt32(sdr["TECSTAFF"]);
                        child.TECSTAFFNAME = Convert.ToString(sdr["TECSTAFFNAME"]);
                        child.TECCFM = Convert.ToInt32(sdr["TECCFM"]);
                        if (sdr["TECDATE"] != DBNull.Value) child.TECDATE = Convert.ToDateTime(sdr["TECDATE"]);
                        child.TECNOTES = Convert.ToString(sdr["TECNOTES"]);

                        child.STATUS = Convert.ToString(sdr["STATUS"]);
                        rst.MES_PMM_MTC.Add(child);
                    }
                }
                rst.MES_RETURN.TYPE = "S";
                rst.MES_RETURN.MESSAGE = "无";
            }
            catch (Exception e)
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = e.Message;
            }
            return rst;
        }

        public MES_RETURN INSERT(MES_PMM_MTC model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MID",model.MID),
                                       new SqlParameter("@QID",model.QID),
                                       new SqlParameter("@MMSTAFF",model.MMSTAFF),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@WTCFM",model.WTCFM),
                                       new SqlParameter("@QCCFM",model.QCCFM),
                                       new SqlParameter("@TECCFM",model.TECCFM)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_MTC_INSERT, parms))
                {
                    if (sdr.Read())
                    {
                        rst.TID = Convert.ToInt32(sdr["ID"]);
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

        public MES_RETURN UPDATE(MES_PMM_MTC model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MTCID",model.MTCID),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@OPERATE",model.OPERATE),

                                       new SqlParameter("@MID",model.MID),
                                       new SqlParameter("@QID",model.QID),

                                       new SqlParameter("@STAFF",model.TECSTAFF),
                                       new SqlParameter("@CFM",model.TECCFM),
                                       new SqlParameter("@NOTES",model.TECNOTES)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_MTC_UPDATE, parms))
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

        public MES_RETURN UPDATE_CFMBACK(MES_PMM_MTC model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MTCID",model.MTCID),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@WTCFM",model.WTCFM),
                                       new SqlParameter("@QCCFM",model.QCCFM),
                                       new SqlParameter("@TECCFM",model.TECCFM),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_MTC_UPDATE_CFMBACK, parms))
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

        public MES_RETURN DELETE(MES_PMM_MTC model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MTCID",model.MTCID),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_MTC_DELETE, parms))
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
