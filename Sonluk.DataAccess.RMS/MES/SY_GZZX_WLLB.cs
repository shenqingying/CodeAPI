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
    public class SY_GZZX_WLLB : ISY_GZZX_WLLB
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "INSERT MES_SY_GZZX_WLLB(GC,GZZXBH,WLLBID,RIGHTID) VALUES(@GC,@GZZXBH,@WLLBID,@RIGHTID)";
        const string SQL_DELETE = "DELETE FROM MES_SY_GZZX_WLLB WHERE GC=@GC AND GZZXBH=@GZZXBH AND WLLBID=@WLLBID";
        const string SQL_SELECT = "MES_SY_GZZX_WLLB_SELECT";
        const string SQL_SELECT_LAY = "MES_SY_GZZX_WLLB_SELECT_LAY";
        const string SQL_DELETE_BYGZZX = "DELETE FROM MES_SY_GZZX_WLLB WHERE GC=@GC AND GZZXBH=@GZZXBH";
        public MES_RETURN INSERT(MES_SY_GZZX_WLLB model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@WLLBID",model.WLLBID),
                                       new SqlParameter("@RIGHTID",model.RIGHTID)
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_GZZX_WLLB");
            }
            return mr;
        }


        public MES_RETURN INSERT_LIST(List<MES_SY_GZZX_WLLB> model)
        {
            MES_RETURN mr = new MES_RETURN();
            if (model.Count > 0)
            {
                for (int i = 0; i < model.Count; i++)
                {
                    SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model[i].GC),
                                       new SqlParameter("@GZZXBH",model[i].GZZXBH),
                                       new SqlParameter("@WLLBID",model[i].WLLBID),
                                       new SqlParameter("@RIGHTID",model[i].RIGHTID)
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
                        SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_GZZX_WLLB");
                    }
                }
            }
            return mr;
        }

        public MES_RETURN DELETE(MES_SY_GZZX_WLLB model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
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
                    using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE_BYGZZX, parms)) { }
                    mr.TYPE = "S";
                    mr.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_GZZX_WLLB");
            }
            return mr;
        }

        public MES_SY_GZZX_WLLB_SELECT SELECT(MES_SY_GZZX_WLLB model)
        {
            MES_SY_GZZX_WLLB_SELECT rst = new MES_SY_GZZX_WLLB_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_SY_GZZX_WLLB> child_MES_SY_GZZX_WLLB = new List<MES_SY_GZZX_WLLB>();
            SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@WLLBID",model.WLLBID)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_GZZX_WLLB node = new MES_SY_GZZX_WLLB();
                        node.GC = Convert.ToString(sdr["GC"]);
                        node.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        node.WLLBID = Convert.ToInt32(sdr["WLLBID"]);
                        node.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        node.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        node.RIGHTID = Convert.ToInt32(sdr["RIGHTID"]);
                        child_MES_SY_GZZX_WLLB.Add(node);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
                rst.MES_SY_GZZX_WLLB = child_MES_SY_GZZX_WLLB;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_GZZX_WLLB");
            }
            return rst;
        }

        public MES_SY_GZZX_WLLB_SELECT_LAY SELECT_LAY(MES_SY_GZZX_WLLB model)
        {
            MES_SY_GZZX_WLLB_SELECT_LAY rst = new MES_SY_GZZX_WLLB_SELECT_LAY();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_SY_GZZX_WLLB_LAY> child_MES_SY_GZZX_WLLB = new List<MES_SY_GZZX_WLLB_LAY>();
            SqlParameter[] parms = { 
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@GZZXBH",model.GZZXBH)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LAY, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_GZZX_WLLB_LAY node = new MES_SY_GZZX_WLLB_LAY();
                        node.GC = model.GC;
                        node.GZZXBH = model.GZZXBH;
                        node.WLLBID = Convert.ToInt32(sdr["WLLBID"]);
                        node.WLLBNAME = Convert.ToString(sdr["WLLBNAME"]);
                        node.GZZXMS = Convert.ToString(sdr["GZZXMS"]);
                        node.RIGHTID = Convert.ToInt32(sdr["RIGHTID"]);
                        if (Convert.ToString(sdr["GC"]) == "")
                        {
                            node.LAY_CHECKED = false;
                        }
                        else
                        {
                            node.LAY_CHECKED = true;
                        }
                        child_MES_SY_GZZX_WLLB.Add(node);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
                rst.MES_SY_GZZX_WLLB_LAY = child_MES_SY_GZZX_WLLB;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_GZZX_WLLB");
            }
            return rst;
        }
    }
}
