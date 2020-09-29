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
    public class SY_GZZX_SBH_WLLB : ISY_GZZX_SBH_WLLB
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "INSERT MES_SY_GZZX_SBH_WLLB(SBBH,WLLBID) VALUES(@SBBH,@WLLBID)";
        const string SQL_DELETE = "DELETE FROM MES_SY_GZZX_SBH_WLLB WHERE SBBH=@SBBH AND WLLBID=@WLLBID";
        const string SQL_DELETE_BYSBBH = "DELETE FROM MES_SY_GZZX_SBH_WLLB WHERE SBBH=@SBBH";
        const string SQL_SELECT = "MES_SY_GZZX_SBH_WLLB_SELECT";
        const string SQL_SELECT_LAY = "MES_SY_GZZX_SBH_WLLB_SELECT_LAY";
        public MES_RETURN INSERT(MES_SY_GZZX_SBH_WLLB model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@WLLBID",model.WLLBID)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_INSERT, parms)) { }
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_GZZX_SBH_WLLB");
            }
            return mr;
        }

        public MES_RETURN INSERT_LIST(List<MES_SY_GZZX_SBH_WLLB> model)
        {
            MES_RETURN mr = new MES_RETURN();
            if (model.Count > 0)
            {
                for (int i = 0; i < model.Count; i++)
                {
                    try
                    {
                        mr = INSERT(model[i]);
                    }
                    catch (Exception e)
                    {
                        mr.TYPE = "E";
                        mr.MESSAGE = e.Message;
                        SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_GZZX_SBH_WLLB");
                    }
                }
            }
            return mr;
        }

        public MES_RETURN DELETE(MES_SY_GZZX_SBH_WLLB model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@WLLBID",model.WLLBID)
                                   };
            try
            {
                if (model.WLLBID > 0)
                {
                    using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE, parms)) { }
                    mr.TYPE = "S";
                    mr.MESSAGE = "";
                }
                else
                {
                    using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE_BYSBBH, parms)) { }
                    mr.TYPE = "S";
                    mr.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_GZZX_SBH_WLLB");
            }
            return mr;
        }

        public MES_SY_GZZX_SBH_WLLB_SELECT SELECT(MES_SY_GZZX_SBH_WLLB model)
        {
            MES_SY_GZZX_SBH_WLLB_SELECT rst = new MES_SY_GZZX_SBH_WLLB_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_SY_GZZX_SBH_WLLB> child_MES_SY_GZZX_SBH_WLLB = new List<MES_SY_GZZX_SBH_WLLB>();
            SqlParameter[] parms = { 
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@WLLBID",model.WLLBID)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_GZZX_SBH_WLLB node = new MES_SY_GZZX_SBH_WLLB();
                        node.SBBH = Convert.ToString(sdr["SBBH"]);
                        node.WLLBID = Convert.ToInt32(sdr["WLLBID"]);
                        node.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        child_MES_SY_GZZX_SBH_WLLB.Add(node);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
                rst.MES_SY_GZZX_SBH_WLLB = child_MES_SY_GZZX_SBH_WLLB;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_GZZX_SBH_WLLB");
            }
            return rst;
        }

        public MES_SY_GZZX_SBH_WLLB_SELECT SELECT_LAY(string SBBH)
        {
            MES_SY_GZZX_SBH_WLLB_SELECT rst = new MES_SY_GZZX_SBH_WLLB_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_SY_GZZX_SBH_WLLB> child_MES_SY_GZZX_SBH_WLLB = new List<MES_SY_GZZX_SBH_WLLB>();
            SqlParameter[] parms = { 
                                       new SqlParameter("@SBBH",SBBH)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LAY, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_GZZX_SBH_WLLB node = new MES_SY_GZZX_SBH_WLLB();
                        node.SBBH = SBBH;
                        node.WLLBID = Convert.ToInt32(sdr["WLLBID"]);
                        node.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        if (Convert.ToString(sdr["SBBH"]) != "")
                        {
                            node.LAY_CHECKED = true;
                        }
                        else
                        {
                            node.LAY_CHECKED = false;
                        }
                        child_MES_SY_GZZX_SBH_WLLB.Add(node);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
                rst.MES_SY_GZZX_SBH_WLLB = child_MES_SY_GZZX_SBH_WLLB;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_GZZX_SBH_WLLB");
            }
            return rst;
        }
    }
}
