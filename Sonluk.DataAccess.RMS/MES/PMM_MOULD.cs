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
    class PMM_MOULD : IPMM_MOULD
    {
        const string SQL_PMM_MOULD_SELECT = "MES_PMM_MOULD_SELECT";
        const string SQL_PMM_MOULD_INSERT = "MES_PMM_MOULD_INSERT";
        const string SQL_PMM_MOULD_UPDATE = "MES_PMM_MOULD_UPDATE";
        const string SQL_PMM_MOULD_DELETE = "MES_PMM_MOULD_DELETE";

        public MES_PMM_MOULD_SELECT SELECT(MES_PMM_MOULD model, int STAFFID)
        {
            MES_PMM_MOULD_SELECT rst = new MES_PMM_MOULD_SELECT();
            rst.MES_PMM_MOULD = new List<MES_PMM_MOULD>();
            rst.MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@MOULD",model.MOULD),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@STATUS",model.STATUS),
                                       new SqlParameter("@MATCHCODENAME",model.MATCHCODENAME),
                                       new SqlParameter("@CAVE",model.CAVE),
                                       new SqlParameter("@MID",model.MID),
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_MOULD_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PMM_MOULD child = new MES_PMM_MOULD();
                        child.MID = Convert.ToString(sdr["MID"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GCMS = Convert.ToString(sdr["GCMS"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        child.WLLBID = Convert.ToInt32(sdr["WLLBID"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.SBBH = Convert.ToString(sdr["SBBH"]);
                        child.SBMS = Convert.ToString(sdr["SBMS"]);
                        child.TYPEID = Convert.ToInt32(sdr["TYPEID"]);
                        child.MXNAME = Convert.ToString(sdr["MXNAME"]);
                        child.MATCHCODE = Convert.ToString(sdr["MATCHCODE"]);
                        child.MATCHCODENAME = Convert.ToString(sdr["MATCHCODENAME"]);
                        child.MATCHCODEREMARK = Convert.ToString(sdr["MATCHCODEREMARK"]);
                        child.MOULD = Convert.ToString(sdr["MOULD"]);
                        child.CAVE = Convert.ToInt32(sdr["CAVE"]);
                        child.STATUS = Convert.ToString(sdr["STATUS"]);
                        child.CASENUM = Convert.ToInt32(sdr["CASENUM"]);
                        child.CASEWET = Convert.ToDecimal(sdr["CASEWET"]);
                        child.ISFIM = Convert.ToInt32(sdr["ISFIM"]);
                        child.ISNPA = Convert.ToInt32(sdr["ISNPA"]);
                        child.NOTES = Convert.ToString(sdr["NOTES"]);
                        rst.MES_PMM_MOULD.Add(child);
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

        public MES_RETURN INSERT(MES_PMM_MOULD model, int STAFFID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@WLLBID",model.WLLBID),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@TYPEID",model.TYPEID),
                                       new SqlParameter("@MATCHCODE",model.MATCHCODE),
                                       new SqlParameter("@MOULD",model.MOULD),
                                       new SqlParameter("@CAVE",model.CAVE),
                                       new SqlParameter("@STATUS",model.STATUS),
                                       new SqlParameter("@CASENUM",model.CASENUM),
                                       new SqlParameter("@CASEWET",model.CASEWET),
                                       new SqlParameter("@ISFIM",model.ISFIM),
                                       new SqlParameter("@ISNPA",model.ISNPA),
                                       new SqlParameter("@NOTES",model.NOTES),
                                       new SqlParameter("@STAFFID",STAFFID),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_MOULD_INSERT, parms))
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

        public MES_RETURN UPDATE(MES_PMM_MOULD model, int STAFFID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MID",model.MID),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@WLLBID",model.WLLBID),
                                       new SqlParameter("@WLH",model.WLH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@TYPEID",model.TYPEID),
                                       new SqlParameter("@MATCHCODE",model.MATCHCODE),
                                       new SqlParameter("@MOULD",model.MOULD),
                                       new SqlParameter("@CAVE",model.CAVE),
                                       new SqlParameter("@STATUS",model.STATUS),
                                       new SqlParameter("@CASENUM",model.CASENUM),
                                       new SqlParameter("@CASEWET",model.CASEWET),
                                       new SqlParameter("@ISFIM",model.ISFIM),
                                       new SqlParameter("@ISNPA",model.ISNPA),
                                       new SqlParameter("@NOTES",model.NOTES),
                                       new SqlParameter("@STAFFID",STAFFID),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_MOULD_UPDATE, parms))
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

        public MES_RETURN DELETE(string MID, int STAFFID)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MID",MID),
                                       new SqlParameter("@STAFFID",STAFFID),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PMM_MOULD_DELETE, parms))
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
