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
    public class SY_PLDH : ISY_PLDH
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_SY_PLDH_INSERT";
        const string SQL_SELECT_COUNT = "SELECT * FROM MES_SY_PLDH WHERE GC=@GC AND PFDH=@PFDH AND PFLB=@PFLB AND ISDELETE=0 AND ISACTION=1";
        const string SQL_SELECT = "MES_SY_PLDH_SELECT";
        const string SQL_UPDATE = "MES_SY_PLDH_UPDATE";

        private const string SQL_INSERT_PLDH_SBBH = "MES_SY_PLDH_SBBH_INSERT";
        private const string SQL_UPDATE_PLDH_SBBH = "MES_SY_PLDH_SBBH_UPDATE";
        private const string SQL_SELECT_PLDH_SBBH = "MES_SY_PLDH_SBBH_SELECT";

        private const string SQL_SELECT_ZJINFO = "MES_SY_PLDH_ZJINFO_SELECT";
        private const string SQL_UPDATE_ZJINFO = "MES_SY_PLDH_ZJINFO_UPDATE";
        public MES_RETURN INSERT(MES_SY_PLDH model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PFLB",model.PFLB),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@JLRID",model.JLRID),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@USERDATES",model.USERDATES),
                                       new SqlParameter("@USERDATEE",model.USERDATEE)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                }
                rst.TYPE = "S";
                rst.MESSAGE = "";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PLDH");
            }
            return rst;
        }

        public MES_RETURN SELECT_COUNT(MES_SY_PLDH model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PFLB",model.PFLB)
                                   };
                rst.BH = "";
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_COUNT, parms))
                {
                    while (sdr.Read())
                    {
                        rst.BH = Convert.ToString(sdr["PLDH"]);
                    }
                }
                rst.TYPE = "S";
                rst.MESSAGE = "";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PLDH");
            }
            return rst;
        }

        public MES_SY_PLDH_SELECT SELECT_LIST(MES_SY_PLDH model)
        {
            MES_SY_PLDH_SELECT rst = new MES_SY_PLDH_SELECT();
            List<MES_SY_PLDH> child_MES_SY_PLDH = new List<MES_SY_PLDH>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PFLB",model.PFLB),
                                       new SqlParameter("@CXLB",1)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_PLDH child = new MES_SY_PLDH();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.PFLB = Convert.ToInt32(sdr["PFLB"]);
                        child.PLDH = Convert.ToString(sdr["PLDH"]);
                        child.JLRID = Convert.ToInt32(sdr["JLRID"]);
                        child.JLR = Convert.ToString(sdr["JLR"]);
                        child.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.USERDATES = Convert.ToString(sdr["USERDATES"]);
                        child.USERDATEE = Convert.ToString(sdr["USERDATEE"]);
                        child_MES_SY_PLDH.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PLDH_SELECT_LIST");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_PLDH = child_MES_SY_PLDH;
            return rst;
        }
        public MES_SY_PLDH_SELECT SELECT(MES_SY_PLDH model)
        {
            MES_SY_PLDH_SELECT rst = new MES_SY_PLDH_SELECT();
            List<MES_SY_PLDH> child_MES_SY_PLDH = new List<MES_SY_PLDH>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PFLB",model.PFLB),
                                       new SqlParameter("@CXLB",model.CXLB),
                                       new SqlParameter("@USERDATES",model.USERDATES),
                                       new SqlParameter("@USERDATEE",model.USERDATEE),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_PLDH child = new MES_SY_PLDH();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.PFLB = Convert.ToInt32(sdr["PFLB"]);
                        child.PLDH = Convert.ToString(sdr["PLDH"]);
                        child.JLRID = Convert.ToInt32(sdr["JLRID"]);
                        child.JLR = Convert.ToString(sdr["JLR"]);
                        child.JLTIME = Convert.ToDateTime(sdr["JLTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.USERDATES = Convert.ToString(sdr["USERDATES"]);
                        child.USERDATEE = Convert.ToString(sdr["USERDATEE"]);
                        child_MES_SY_PLDH.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PLDH_SELECT_LIST");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_PLDH = child_MES_SY_PLDH;
            return rst;
        }

        public MES_RETURN PLDH_SBBH_INSERT(MES_SY_PLDH_SBBH model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@CJR",model.CJR)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_PLDH_SBBH, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_PLDH_SBBH_INSERT", "MES");
            }
            return rst;
        }
        public MES_RETURN PLDH_SBBH_UPDATE(MES_SY_PLDH_SBBH model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@NOID",model.NOID),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@PLDH",model.PLDH)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_PLDH_SBBH, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_PLDH_SBBH_UPDATE", "MES");
            }
            return rst;
        }
        public MES_SY_PLDH_SBBH_SELECT PLDH_SBBH_SELECT(MES_SY_PLDH_SBBH model)
        {
            MES_SY_PLDH_SBBH_SELECT rst = new MES_SY_PLDH_SBBH_SELECT();
            List<MES_SY_PLDH_SBBH> child_MES_SY_PLDH_SBBH = new List<MES_SY_PLDH_SBBH>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@PFLB",model.PFLB),
                                       new SqlParameter("@PFDH",model.PFDH)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_PLDH_SBBH, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_PLDH_SBBH child = new MES_SY_PLDH_SBBH();
                        child.NOID = Convert.ToInt32(sdr["NOID"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.PLDH = Convert.ToString(sdr["PLDH"]);
                        child.SBBH = Convert.ToString(sdr["SBBH"]);
                        child.CJR = Convert.ToInt32(sdr["CJR"]);
                        child.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
                        child.CJTIME = Convert.ToDateTime(sdr["CJTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.XGR = Convert.ToInt32(sdr["XGR"]);
                        child.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
                        child.XGTIME = Convert.ToDateTime(sdr["XGTIME"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.SBMS = Convert.ToString(sdr["SBMS"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child_MES_SY_PLDH_SBBH.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_PLDH_SBBH_SELECT", "MES");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_PLDH_SBBH = child_MES_SY_PLDH_SBBH;
            return rst;
        }
        public MES_RETURN UPDATE(MES_SY_PLDH model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@REMARK",model.REMARK)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_PLDH_UPDATE", "MES");
            }
            return rst;
        }
        public MES_SY_PLDH_ZJINFO_SELECT SELECT_ZJINFO(MES_SY_PLDH_ZJINFO model)
        {
            MES_SY_PLDH_ZJINFO_SELECT rst = new MES_SY_PLDH_ZJINFO_SELECT();
            List<MES_SY_PLDH_ZJINFO> child_MES_SY_PLDH_ZJINFO = new List<MES_SY_PLDH_ZJINFO>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@PLDH",model.PLDH)
                                   };
                if (model.LB == 1 || model.LB == 6)
                {
                    using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_ZJINFO, parms))
                    {
                        while (sdr.Read())
                        {
                            MES_SY_PLDH_ZJINFO child = new MES_SY_PLDH_ZJINFO();
                            child.GC = Convert.ToString(sdr["GC"]);
                            child.PLDH = Convert.ToString(sdr["PLDH"]);
                            child.SBBH = Convert.ToString(sdr["SBBH"]);
                            child.SCDATE = Convert.ToString(sdr["SCDATE"]);
                            child.SCSLID = Convert.ToInt32(sdr["SCSLID"]);
                            child.SCSLNAME = Convert.ToString(sdr["SCSLNAME"]);
                            child.SCBZID = Convert.ToInt32(sdr["SCBZID"]);
                            child.SCBZNAME = Convert.ToString(sdr["SCBZNAME"]);
                            child.SCTH = Convert.ToInt32(sdr["SCTH"]);
                            child.PFDH = Convert.ToString(sdr["PFDH"]);
                            child.PFLB = Convert.ToInt32(sdr["PFLB"]);
                            child.GXBS = Convert.ToString(sdr["GXBS"]);
                            child.SBMS = Convert.ToString(sdr["SBMS"]);
                            child_MES_SY_PLDH_ZJINFO.Add(child);
                        }
                    }
                }
                else
                {
                    rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_ZJINFO, parms);
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_PLDH_ZJINFO_SELECT", "MES");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_PLDH_ZJINFO = child_MES_SY_PLDH_ZJINFO;
            return rst;
        }
        public MES_RETURN UPDATE_ZJINFO(MES_SY_PLDH_ZJINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@PLDH",model.PLDH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@SCSLID",model.SCSLID),
                                       new SqlParameter("@SCBZID",model.SCBZID),
                                       new SqlParameter("@SCTH",model.SCTH),
                                       new SqlParameter("@PFDH",model.PFDH)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_ZJINFO, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_ZJINFO_UPDATE", "MES");
            }
            return rst;
        }
    }
}
