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
    public class SY_GZZX_SBH : ISY_GZZX_SBH
    {
        string SQL_INSERT = "MES_SY_GZZX_SBH_INSERT";
        string SQL_DELETE = "UPDATE MES_SY_GZZX_SBH SET ISDELETE = 1 WHERE SBBH = @SBBH";
        string SQL_UPDATE = "MES_SY_GZZX_SBH_UPDATE";
        string SQL_SELECT = "MES_SY_GZZX_SBH_SELECT";
        //string SQL_SELECT_ALL = "MES_SY_GZZX_SBH_SELECT_ALL";
        string SQL_SELECT_BY_STAFFID = "MES_SY_GZZX_SBH_SELECT_BY_STAFFID";
        const string SQL_SELECT_BY_TDNO = "MES_PD_TL_TD_SELECT";
        const string SQL_INSERT_BY_TDNO = "MES_PD_TL_TD_INSERT";
        const string SQL_DELETE_BY_TDNO = "MES_PD_TL_TD_DELETE";
        const string SQL_UPDATE_BY_TDNO = "MES_PD_TL_TD_UPDATE";

        private const string SQL_SELECT_LB = "MES_SY_GZZX_SBH_SELECT_LB";

        SY_EXCEPTION SY_EXCEPTIONService = new SY_EXCEPTION();
        public MES_RETURN INSERT(MES_SY_GZZX_SBH model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBMS",model.SBMS),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@PXM",model.PXM),
                                       new SqlParameter("@SBFL",model.SBFL),
                                       new SqlParameter("@FSBBH",model.FSBBH),
                                       new SqlParameter("@MACIP",model.MACIP),
                                       new SqlParameter("@IMAGE",model.IMAGE),
                                       new SqlParameter("@JG",model.JG),
                                       new SqlParameter("@REMARK1",model.REMARK1),
                                       new SqlParameter("@REMARK2",model.REMARK2),
                                       new SqlParameter("@TXTYPE",model.TXTYPE),
                                       new SqlParameter("@SBNO",model.SBNO)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GZZX_SBH");
            }
            return mr;
        }

        public MES_RETURN DELETE(string SBBH)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@SBBH",SBBH)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE, parms)) { }
                // return true;
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GZZX_SBH");
            }
            return mr;
        }

        public MES_RETURN UPDATE(MES_SY_GZZX_SBH model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@SBMS",model.SBMS),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@PXM",model.PXM),
                                       new SqlParameter("@SBFL",model.SBFL),
                                       new SqlParameter("@FSBBH",model.FSBBH),
                                       new SqlParameter("@MACIP",model.MACIP),
                                       new SqlParameter("@IMAGE",model.IMAGE),
                                       new SqlParameter("@JG",model.JG),
                                       new SqlParameter("@REMARK1",model.REMARK1),
                                       new SqlParameter("@REMARK2",model.REMARK2),
                                       new SqlParameter("@TXTYPE",model.TXTYPE),
                                       new SqlParameter("@SBNO",model.SBNO)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
                ////return true;
                //mr.TYPE = "S";
                //mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GZZX_SBH");
            }
            return mr;
        }


        public IList<MES_SY_GZZX_SBH> SELECT(MES_SY_GZZX_SBH model)
        {
            IList<MES_SY_GZZX_SBH> rst = new List<MES_SY_GZZX_SBH>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@SBMS",model.SBMS),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@SBFL",model.SBFL),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@WLLBNAME",model.WLLBNAME),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@SBNO",model.SBNO)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_GZZX_SBH node = new MES_SY_GZZX_SBH();
                        node.GC = Convert.ToString(sdr["GC"]);
                        node.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        node.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        node.SBBH = Convert.ToString(sdr["SBBH"]);
                        node.SBMS = Convert.ToString(sdr["SBMS"]);
                        node.REMARK = Convert.ToString(sdr["REMARK"]);
                        node.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        node.PXM = Convert.ToInt32(sdr["PXM"]);
                        node.SBFL = Convert.ToInt32(sdr["SBFL"]);
                        node.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        node.FSBBH = Convert.ToString(sdr["FSBBH"]);
                        node.MACIP = Convert.ToString(sdr["MACIP"]);
                        node.IMAGE = Convert.ToString(sdr["IMAGE"]);
                        node.JG = Convert.ToInt32(sdr["JG"]);
                        node.REMARK1 = Convert.ToString(sdr["REMARK1"]);
                        node.REMARK2 = Convert.ToString(sdr["REMARK2"]);
                        node.TXTYPE = Convert.ToInt32(sdr["TXTYPE"]);
                        node.TXTYPENAME = Convert.ToString(sdr["TXTYPENAME"]);
                        node.SBNO = Convert.ToString(sdr["SBNO"]);
                        rst.Add(node);
                    }
                }
                return rst;
            }
            catch (Exception e)
            {
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GZZX_SBH");
                throw new ApplicationException(e.Message);
            }
        }

        public MES_SY_GZZX_SBH_SELECT SELECT_LB(MES_SY_GZZX_SBH model)
        {
            MES_SY_GZZX_SBH_SELECT rst = new MES_SY_GZZX_SBH_SELECT();
            List<MES_SY_GZZX_SBH> child_MES_SY_GZZX_SBH_LIST = new List<MES_SY_GZZX_SBH>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@SBMS",model.SBMS),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@SBFL",model.SBFL),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@WLLBNAME",model.WLLBNAME),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@FSBBH",model.FSBBH),
                                       new SqlParameter("@MACIP",model.MACIP),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LB, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_GZZX_SBH node = new MES_SY_GZZX_SBH();
                        node.GC = Convert.ToString(sdr["GC"]);
                        node.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        node.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        node.SBBH = Convert.ToString(sdr["SBBH"]);
                        node.SBMS = Convert.ToString(sdr["SBMS"]);
                        node.REMARK = Convert.ToString(sdr["REMARK"]);
                        node.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        node.PXM = Convert.ToInt32(sdr["PXM"]);
                        node.SBFL = Convert.ToInt32(sdr["SBFL"]);
                        node.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        node.FSBBH = Convert.ToString(sdr["FSBBH"]);
                        node.MACIP = Convert.ToString(sdr["MACIP"]);
                        node.IMAGE = Convert.ToString(sdr["IMAGE"]);
                        node.JG = Convert.ToInt32(sdr["JG"]);
                        node.REMARK1 = Convert.ToString(sdr["REMARK1"]);
                        node.REMARK2 = Convert.ToString(sdr["REMARK2"]);
                        node.TXTYPE = Convert.ToInt32(sdr["TXTYPE"]);
                        node.TXTYPENAME = Convert.ToString(sdr["TXTYPENAME"]);
                        node.SBFLNAME = Convert.ToString(sdr["SBFLNAME"]);
                        node.SBNO = Convert.ToString(sdr["SBNO"]);
                        child_MES_SY_GZZX_SBH_LIST.Add(node);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                SY_EXCEPTIONService.INSERT_SY(e.ToString(), "SY_GZZX_SBH", "MES");
                //throw new ApplicationException(e.Message);
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_GZZX_SBH = child_MES_SY_GZZX_SBH_LIST;
            return rst;
        }

        public IList<MES_SY_GZZX_SBH> SELECT_BY_STAFFID(MES_SY_GZZX_SBH model)
        {
            IList<MES_SY_GZZX_SBH> rst = new List<MES_SY_GZZX_SBH>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@WLLBNAME",model.WLLBNAME),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BY_STAFFID, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_GZZX_SBH node = new MES_SY_GZZX_SBH();
                        node.GC = Convert.ToString(sdr["GC"]);
                        node.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        node.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        node.SBBH = Convert.ToString(sdr["SBBH"]);
                        node.SBMS = Convert.ToString(sdr["SBMS"]);
                        node.REMARK = Convert.ToString(sdr["REMARK"]);
                        node.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        node.PXM = Convert.ToInt32(sdr["PXM"]);
                        node.SBFL = Convert.ToInt32(sdr["SBFL"]);
                        node.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        rst.Add(node);
                    }
                }
                return rst;
            }
            catch (Exception e)
            {
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GZZX_SBH");
                throw new ApplicationException(e.Message);
            }
        }

        public MES_PD_TL_TD_SELECT SELECT_BY_TDNO(MES_PD_TL_TD model)
        {
            MES_PD_TL_TD_SELECT rst = new MES_PD_TL_TD_SELECT();
            List<MES_PD_TL_TD> child_MES_PD_TL_TD = new List<MES_PD_TL_TD>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@TDNO",model.TDNO),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BY_TDNO, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PD_TL_TD node = new MES_PD_TL_TD();
                        node.TDNO = Convert.ToString(sdr["TDNO"]);
                        node.SBBH = Convert.ToString(sdr["SBBH"]);
                        node.TDREMARK = Convert.ToString(sdr["TDREMARK"]);
                        node.GC = Convert.ToString(sdr["GC"]);
                        node.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        node.SBMS = Convert.ToString(sdr["SBMS"]);
                        child_MES_PD_TL_TD.Add(node);
                    }
                }
                if (child_MES_PD_TL_TD.Count > 0)
                {
                    child_MES_RETURN.TYPE = "S";
                }
                else
                {
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "无数据！";
                }
            }
            catch (Exception e)
            {
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GZZX_SBH_SELECT_BY_TDNO");
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.MES_PD_TL_TD = child_MES_PD_TL_TD;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }

        public MES_RETURN INSERT_BY_TDNO(MES_PD_TL_TD model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@TDREMARK",model.TDREMARK)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_BY_TDNO, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GZZX_SBH_INSERT_BY_TDNO");
            }
            return mr;
        }
        public MES_RETURN DELETE_BY_TDNO(string TDNO)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@TDNO",TDNO)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE_BY_TDNO, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GZZX_SBH_DELETE_BY_TDNO");
            }
            return mr;
        }
        public MES_RETURN UPDATE_BY_TDNO(MES_PD_TL_TD model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@TDNO",model.TDNO),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@TDREMARK",model.TDREMARK)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_BY_TDNO, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GZZX_SBH_UPDATE_BY_TDNO");
            }
            return mr;
        }
    }
}
