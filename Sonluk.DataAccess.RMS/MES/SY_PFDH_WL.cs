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
    public class SY_PFDH_WL : ISY_PFDH_WL
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_SY_PFDH_WL_INSERT";
        const string SQL_DELETE_ALL = "DELETE FROM MES_SY_PFDH_WL WHERE GC=@GC AND PFLB=@PFLB AND PFDH=@PFDH";
        const string SQL_DELETE = "DELETE FROM MES_SY_PFDH_WL WHERE GC=@GC AND PFLB=@PFLB AND PFDH=@PFDH AND WLH=@WLH";
        const string SQL_SELECT_LAY = "MES_SY_PFDH_WL_SELECT_LAY";
        const string SQL_SELECT = "MES_SY_PFDH_WL_SELECT";

        public const string SQL_XFPC_SYNC_INSERT = "MES_SY_XFPC_SYNC_INSERT";
        public const string SQL_XFPC_SYNC_SELECT = "MES_SY_XFPC_SYNC_SELECT";
        public const string SQL_XFPC_SYNC_UPDATE = "MES_SY_XFPC_SYNC_UPDATE";
        public MES_RETURN INSERT(List<MES_SY_PFDH_WL> model)
        {
            MES_RETURN rst = new MES_RETURN();
            if (model.Count > 0)
            {
                for (int i = 0; i < model.Count; i++)
                {
                    try
                    {
                        SqlParameter[] parms = {
                                       new SqlParameter("@GC",model[i].GC),
                                       new SqlParameter("@PFLB",model[i].PFLB),
                                       new SqlParameter("@PFDH",model[i].PFDH),
                                       new SqlParameter("@WLH",model[i].WLH),
                                       new SqlParameter("@WLNAME",model[i].WLNAME)
                                   };

                        using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
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
                        SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PFDH_WL");
                    }
                }
            }
            return rst;
        }


        public MES_RETURN DELETE(MES_SY_PFDH_WL model)
        {
            string SQL = "";
            MES_RETURN rst = new MES_RETURN();
            try
            {
                if (model.WLH == "" || model.WLH == null)
                {
                    SQL = SQL_DELETE_ALL;
                    SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@PFLB",model.PFLB),
                                       new SqlParameter("@PFDH",model.PFDH),
                                   };
                    using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL, parms))
                    {
                    }
                }
                else
                {
                    SQL = SQL_DELETE;
                    SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@PFLB",model.PFLB),
                                       new SqlParameter("@PFDH",model.PFDH),
                                       new SqlParameter("@WLH",model.WLH)
                                   };
                    using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL, parms))
                    {
                    }
                }

                rst.TYPE = "S";
                rst.MESSAGE = "";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PFDH_WL");
            }
            return rst;
        }


        public MES_SY_PFDH_WL_SELECT_LAY SELECT_LAY(MES_SY_PFDH_WL model)
        {
            MES_SY_PFDH_WL_SELECT_LAY rst = new MES_SY_PFDH_WL_SELECT_LAY();
            List<MES_SY_PFDH_WL_LAY> child_MES_SY_PFDH_WL_LAY = new List<MES_SY_PFDH_WL_LAY>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@PFLB",model.PFLB),
                                       new SqlParameter("@PFDH",model.PFDH)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LAY, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_PFDH_WL_LAY child = new MES_SY_PFDH_WL_LAY();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.PFDH = model.PFDH;
                        child.PFLB = model.PFLB;
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLNAME = Convert.ToString(sdr["WLNAME"]);
                        if (Convert.ToString(sdr["PFDH"]) != "")
                        {
                            child.LAY_CHECKED = true;
                        }
                        else
                        {
                            child.LAY_CHECKED = false;
                        }
                        child_MES_SY_PFDH_WL_LAY.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PFDH_WL");
            }
            rst.MES_SY_PFDH_WL_LAY = child_MES_SY_PFDH_WL_LAY;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }

        public MES_SY_PFDH_WL_SELECT SELECT(MES_SY_PFDH_WL model)
        {
            MES_SY_PFDH_WL_SELECT rst = new MES_SY_PFDH_WL_SELECT();
            List<MES_SY_PFDH_WL> child_MES_SY_PFDH_WL = new List<MES_SY_PFDH_WL>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@PFLB",model.PFLB),
                                       new SqlParameter("@PFDH",model.PFDH)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_PFDH_WL child = new MES_SY_PFDH_WL();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.PFDH = Convert.ToString(sdr["PFDH"]);
                        child.PFLB = Convert.ToInt32(sdr["PFLB"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLNAME = Convert.ToString(sdr["WLNAME"]);
                        child_MES_SY_PFDH_WL.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "SY_PFDH_WL");
            }
            rst.MES_SY_PFDH_WL = child_MES_SY_PFDH_WL;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN XFPC_SYNC_INSERT(ZSL_BCS304 model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@CHARG",model.CHARG),
                                       new SqlParameter("@LICHA",model.LICHA),
                                       new SqlParameter("@LIFNR",model.LIFNR),
                                       new SqlParameter("@SORTL",model.SORTL),
                                       new SqlParameter("@ERSDA",model.ERSDA),
                                       new SqlParameter("@CLABS",model.CLABS),
                                       new SqlParameter("@QPLOS",model.QPLOS),
                                       new SqlParameter("@MATNR",model.MATNR),
                                       new SqlParameter("@WERKS",model.WERKS),
                                       new SqlParameter("@LGORT",model.LGORT)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_XFPC_SYNC_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_XFPC_SYNC_INSERT", "MES");
            }
            return rst;
        }
        public MES_SY_XFPC_SYNC_SELECT XFPC_SYNC_SELECT(ZSL_BCS304 model, int LB)
        {
            MES_SY_XFPC_SYNC_SELECT rst = new MES_SY_XFPC_SYNC_SELECT();
            List<ZSL_BCS304> child_ZSL_BCS304 = new List<ZSL_BCS304>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@MATNR",model.MATNR),
                                       new SqlParameter("@WERKS",model.WERKS),
                                       new SqlParameter("@LB",LB)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_XFPC_SYNC_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        ZSL_BCS304 child = new ZSL_BCS304();
                        child.CHARG = Convert.ToString(sdr["CHARG"]);
                        child.LICHA = Convert.ToString(sdr["LICHA"]);
                        child.LIFNR = Convert.ToString(sdr["LIFNR"]);
                        child.SORTL = Convert.ToString(sdr["SORTL"]);
                        child.ERSDA = Convert.ToString(sdr["ERSDA"]);
                        child.CLABS = Convert.ToString(sdr["CLABS"]);
                        child.QPLOS = Convert.ToString(sdr["QPLOS"]);
                        child.MATNR = Convert.ToString(sdr["MATNR"]);
                        child.WERKS = Convert.ToString(sdr["WERKS"]);
                        child.LGORT = Convert.ToString(sdr["LGORT"]);
                        child_ZSL_BCS304.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_XFPC_SYNC_SELECT", "MES");
            }
            rst.ZSL_BCS304 = child_ZSL_BCS304;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN XFPC_SYNC_UPDATE(ZSL_BCS304 model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@WERKS",model.WERKS)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_XFPC_SYNC_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_XFPC_SYNC_UPDATE", "MES");
            }
            return rst;
        }
    }
}
