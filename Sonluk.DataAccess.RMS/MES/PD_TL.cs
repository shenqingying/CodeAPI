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
    public class PD_TL : IPD_TL
    {
        string SQL_INSERT = "MES_PD_TL_INSERT";
        //string SQL_DELETE = "UPDATE MES_PD_TL SET ISDELETE=1 WHERE ID=@ID";
        const string SQL_DELETE = "MES_PD_TL_DELETE";
        string SQL_SELECT_FJTL = "SELECT TOP(1) * FROM MES_PD_TL WHERE RWBH=@RWBH AND ISDELETE=0 ORDER BY ID DESC";
        const string SQL_SELECT = "MES_PD_TL_SELECT";
        const string SQL_SELECT_REPORT = "MES_PD_TL_SELECT_REPORT";
        const string SQL_UPDATE_TLTMTH = "MES_PD_TL_UPDATE_TLTMTH";
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        public MES_RETURN INSERT(MES_PD_TL model)
        {
            MES_RETURN MR = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@JLR",model.JLR),
                                       new SqlParameter("@TLRQ",model.TLRQ),
                                       new SqlParameter("@TLLB",model.TLLB),
                                       new SqlParameter("@SCDATE",model.SCDATE),
                                       new SqlParameter("@REMARK",model.REMARK)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        MR.TID = Convert.ToInt32(sdr["ID"]);
                        MR.TYPE = Convert.ToString(sdr["TYPE"]);
                        MR.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }

            }
            catch (Exception e)
            {
                MR.TYPE = "E";
                MR.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_TL_INSERT");
            }
            return MR;
        }


        public MES_RETURN DELETE(MES_PD_TL_DELETE_IN model)
        {
            MES_RETURN MR = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.TMTLID),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@GH",model.GH),
                                       new SqlParameter("@GHNAME",model.GHNAME)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE, parms))
                {
                    while (sdr.Read())
                    {
                        MR.TYPE = Convert.ToString(sdr["TYPE"]);
                        MR.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                MR.TYPE = "E";
                MR.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_TL_DELETE");
            }
            return MR;
        }


        public MES_PD_TL SELECT_FJTL(string RWBH)
        {
            MES_PD_TL MR = new MES_PD_TL();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RWBH",RWBH),
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_FJTL, parms))
                {
                    while (sdr.Read())
                    {
                        MR.GC = Convert.ToString(sdr["GC"]);
                        MR.TM = Convert.ToString(sdr["TM"]);
                    }
                }
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_TL_SELECT_FJTL");
            }
            return MR;
        }

        public MES_PD_TL_SELECT SELECT(MES_PD_TL model)
        {
            int XH = 1;
            MES_PD_TL_SELECT rst = new MES_PD_TL_SELECT();
            List<MES_PD_TL_LIST> child_MES_PD_TL_LIST = new List<MES_PD_TL_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@TLLB",model.TLLB)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PD_TL_LIST child = new MES_PD_TL_LIST();
                        child.XH = XH;
                        child.ID = Convert.ToInt32(sdr["ID"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.RWBH = Convert.ToString(sdr["RWBH"]);
                        child.TM = Convert.ToString(sdr["TM"]);
                        child.TLRQ = Convert.ToDateTime(sdr["TLRQ"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.JLR = Convert.ToString(sdr["JLR"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.WLLB = Convert.ToInt32(sdr["WLLB"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.TLLB = Convert.ToInt32(sdr["TLLB"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        XH = XH + 1;

                        child_MES_PD_TL_LIST.Add(child);
                        //MR.GC = Convert.ToString(sdr["GC"]);
                        child_MES_RETURN.TYPE = "S";
                        child_MES_RETURN.MESSAGE = "";
                    }
                }
                if (child_MES_RETURN.TYPE != "S")
                {
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "无数据";
                }
                rst.MES_PD_TL_LIST = child_MES_PD_TL_LIST;
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_TL_SELECT");
            }
            return rst;
        }

        public MES_RETURN UPDATE_TLTMTH(MES_PD_TL_UPDATE_TLTMTH_IN model)
        {
            MES_RETURN MR = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.TMTLID),
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@GH",model.GH),
                                       new SqlParameter("@GHNAME",model.GHNAME)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_TLTMTH, parms))
                {
                }
                MR.TYPE = "S";
                MR.MESSAGE = "";
            }
            catch (Exception e)
            {
                MR.TYPE = "E";
                MR.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "PD_TL_UPDATE_TLTMTH");
            }
            return MR;
        }

        public MES_PD_TL_SELECT_REPORT SELECT_REPORT(MES_PD_TL_IN_SELECT_REPORT model)
        {
            MES_PD_TL_SELECT_REPORT rst = new MES_PD_TL_SELECT_REPORT();
            List<MES_PD_TL_SELECT_REPORT_LIST> child_MES_PD_TL_SELECT_REPORT_LIST = new List<MES_PD_TL_SELECT_REPORT_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@CCWLLB",model.CCWLLB),
                                       new SqlParameter("@TLWLLB",model.TLWLLB),
                                       new SqlParameter("@TLRQS",model.TLRQS),
                                       new SqlParameter("@TLRQE",model.TLRQE),
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@ZPRQS",model.ZPRQS),
                                       new SqlParameter("@ZPRQE",model.ZPRQE),
                                       new SqlParameter("@TM",model.TM),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_REPORT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PD_TL_SELECT_REPORT_LIST child = new MES_PD_TL_SELECT_REPORT_LIST();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.GZZXNAME = Convert.ToString(sdr["GZZXNAME"]);
                        child.SBH = Convert.ToString(sdr["SBH"]);
                        child.ZPRQ = Convert.ToString(sdr["ZPRQ"]);
                        child.RWBH = Convert.ToString(sdr["RWBH"]);
                        child.GDDH = Convert.ToString(sdr["GDDH"]);
                        child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child.TLTM = Convert.ToString(sdr["TLTM"]);
                        child.TLWLH = Convert.ToString(sdr["TLWLH"]);
                        child.TLWLNAME = Convert.ToString(sdr["TLWLNAME"]);
                        child.TLWLLBNAME = Convert.ToString(sdr["TLWLLBNAME"]);
                        child.TLRQ = Convert.ToDateTime(sdr["TLRQ"]).ToString("yyyy-MM-dd HH:mm:ss");
                        child.JLRNAME = Convert.ToString(sdr["JLRNAME"]);
                        child.TLTH = Convert.ToInt32(sdr["TLTH"]);
                        child.PC = Convert.ToString(sdr["PC"]);
                        child.GYSPC = Convert.ToString(sdr["GYSPC"]);
                        child.TLSBBH = Convert.ToString(sdr["TLSBBH"]);
                        child.TLSBHMS = Convert.ToString(sdr["TLSBHMS"]);
                        child.TLPFDH = Convert.ToString(sdr["TLPFDH"]);
                        child.TLPLDH = Convert.ToString(sdr["TLPLDH"]);
                        child.TLSCDATE = Convert.ToString(sdr["TLSCDATE"]);
                        child.TLBCMS = Convert.ToString(sdr["TLBCMS"]);
                        child.TLREMARK = Convert.ToString(sdr["TLREMARK"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.REMARK = Convert.ToString(sdr["REMARK"]);
                        child.TLINFOREMARK = Convert.ToString(sdr["TLINFOREMARK"]);
                        child.TLNOREMARK = Convert.ToString(sdr["TLNOREMARK"]);
                        child_MES_PD_TL_SELECT_REPORT_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_IN(e.ToString(), "PD_TL_SELECT_REPORT", model.ToString());
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_PD_TL_SELECT_REPORT_LIST = child_MES_PD_TL_SELECT_REPORT_LIST;
            return rst;
        }
    }
}
