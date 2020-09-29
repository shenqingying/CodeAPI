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
    public class SY_GZZX : ISY_GZZX
    {
        string SQL_INSERT = "MES_SY_GZZX_INSERT";
        string SQL_DELETE = "MES_SY_GZZX_DELETE";
        string SQL_UPDATE = "MES_SY_GZZX_UPDATE";
        string SQL_SELECT = "MES_SY_GZZX_SELECT";
        string SQL_SELECT_GZZX_GW = "MES_SY_GZZX_SELECT_GZZX_GW";
        string SQL_SELECT_COUNT = "SELECT COUNT(*) AS MCOUNT FROM MES_SY_GZZX WHERE GZZXBH=@GZZXBH AND GC=@GC";
        string SQL_SELECT_BY_ROLE = "MES_SY_GZZX_SELECT_BYROLE";
        private const string SQL_SELECT_LB = "MES_SY_GZZX_SELECT_LB";
        SY_EXCEPTION SY_EXCEPTIONService = new SY_EXCEPTION();
        public MES_RETURN INSERT(MES_SY_GZZX model, int ISAUTO)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@GZZXMS",model.GZZXMS),
                                       new SqlParameter("@CXID",model.CXID),
                                       new SqlParameter("@BZ",model.BZ),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@GWJSID",model.GWJSID),
                                       new SqlParameter("@PXM",model.PXM),
                                       new SqlParameter("@ISAUTO",ISAUTO)
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
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GZZX");
            }
            return mr;
        }

        public MES_RETURN DELETE(MES_SY_GZZX model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE, parms)) { }
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GZZX");
            }
            return mr;
        }

        public MES_RETURN UPDATE(MES_SY_GZZX model, int ISAUTO)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@GZZXMS",model.GZZXMS),
                                       new SqlParameter("@CXID",model.CXID),
                                       new SqlParameter("@BZ",model.BZ),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@GWJSID",model.GWJSID),
                                       new SqlParameter("@PXM",model.PXM),
                                       new SqlParameter("@ISAUTO",ISAUTO)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms)) { }
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GZZX");
            }
            return mr;
        }

        public IList<MES_SY_GZZX> SELECT(MES_SY_GZZX model)
        {
            IList<MES_SY_GZZX> rst = new List<MES_SY_GZZX>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@GZZXMS",model.GZZXMS),
                                       new SqlParameter("@CXID",model.CXID),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@ISACTION",model.ISACTION)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_GZZX node = new MES_SY_GZZX();
                        node.GC = Convert.ToString(sdr["GC"]);
                        node.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        node.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        node.CXID = Convert.ToInt32(sdr["CXID"]);
                        node.CX = Convert.ToString(sdr["CX"]);
                        node.BZ = Convert.ToString(sdr["BZ"]);
                        node.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        node.GWJSID = Convert.ToInt32(sdr["GWJSID"]);
                        node.GWJSNAME = Convert.ToString(sdr["GWJSNAME"]);
                        node.PXM = Convert.ToInt32(sdr["PXM"]);
                        node.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        rst.Add(node);
                    }
                }

            }
            catch (Exception e)
            {
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GZZX");
                throw new ApplicationException(e.Message);
            }
            return rst;
        }
        public List<MES_SY_GZZX> SELECT_LB(MES_SY_GZZX model)
        {
            List<MES_SY_GZZX> rst = new List<MES_SY_GZZX>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@GZZXMS",model.GZZXMS),
                                       new SqlParameter("@CXID",model.CXID),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LB, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_GZZX node = new MES_SY_GZZX();
                        node.GC = Convert.ToString(sdr["GC"]);
                        node.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        node.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        node.CXID = Convert.ToInt32(sdr["CXID"]);
                        node.CX = Convert.ToString(sdr["CX"]);
                        node.BZ = Convert.ToString(sdr["BZ"]);
                        node.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        node.GWJSID = Convert.ToInt32(sdr["GWJSID"]);
                        node.GWJSNAME = Convert.ToString(sdr["GWJSNAME"]);
                        node.PXM = Convert.ToInt32(sdr["PXM"]);
                        node.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        rst.Add(node);
                    }
                }

            }
            catch (Exception e)
            {
                SY_EXCEPTIONService.INSERT_SY(e.ToString(), "MES_SY_GZZX_SELECT_LB","MES");
                throw new ApplicationException(e.Message);
            }
            return rst;
        }

        public int SELECT_COUNT(string GZZXBH, string GC)
        {
            int rst = 0;
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GZZXBH",GZZXBH),
                                       new SqlParameter("@GC",GC)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_COUNT, parms))
                {
                    while (sdr.Read())
                    {
                        rst = Convert.ToInt32(sdr["MCOUNT"]);
                    }
                }

            }
            catch (Exception e)
            {
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GZZX");
                throw new ApplicationException(e.Message);
            }
            return rst;
        }

        public IList<MES_SY_GZZX> SELECT_BY_ROLE(MES_SY_GZZX model)
        {
            IList<MES_SY_GZZX> rst = new List<MES_SY_GZZX>();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@GZZXMS",model.GZZXMS),
                                       new SqlParameter("@CXID",model.CXID),
                                       new SqlParameter("@WLLB",model.WLLB),
                                       new SqlParameter("@WLLBNAME",model.WLLBNAME),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_BY_ROLE, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_GZZX node = new MES_SY_GZZX();
                        node.GC = Convert.ToString(sdr["GC"]);
                        node.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        node.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        node.CXID = Convert.ToInt32(sdr["CXID"]);
                        node.CX = Convert.ToString(sdr["CX"]);
                        node.BZ = Convert.ToString(sdr["BZ"]);
                        node.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        node.GWJSID = Convert.ToInt32(sdr["GWJSID"]);
                        node.PXM = Convert.ToInt32(sdr["PXM"]);
                        rst.Add(node);
                    }
                }
            }
            catch (Exception e)
            {
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GZZX");
                throw new ApplicationException(e.Message);
            }
            return rst;
        }


        public MES_SY_GZZX_GW_LIST SELECT_GZZX_GW(MES_SY_GZZX model)
        {
            MES_SY_GZZX_GW_LIST rst = new MES_SY_GZZX_GW_LIST();
            List<MES_SY_GZZX_GW> child_MES_SY_GZZX_GW = new List<MES_SY_GZZX_GW>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_GZZX_GW, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_GZZX_GW child = new MES_SY_GZZX_GW();
                        child.ID = Convert.ToInt32(sdr["ID"]);
                        child.MXNAME = Convert.ToString(sdr["MXNAME"]);
                        child_MES_SY_GZZX_GW.Add(child);
                    }
                }
                rst.MES_SY_GZZX_GW = child_MES_SY_GZZX_GW;
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_GZZX");
            }
            return rst;
        }
    }
}
