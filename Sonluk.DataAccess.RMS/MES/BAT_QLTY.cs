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
    class BAT_QLTY : IBAT_QLTY
    {
        const string SQL_SELECT_ZLRBB = "MES_ZLRBB_SELECT";
        const string SQL_SELECT_ZLRBB_SUM = "MES_ZLRBB_SELECT_SUM";
        const string SQL_COVER_ZLRBB = "MES_ZLRBB_COVER";
        const string SQL_DELETE_ZLRBB = "MES_ZLRBB_DELETE";
        const string SQL_COVER_ZLRBB_TMARK = "MES_ZLRBB_COVER_TMARK";
        const string SQL_DELETE_ZLRBB_TMARK = "MES_ZLRBB_DELETE_TMARK";
        const string SQL_ACTION_ZLRBB = "MES_ZLRBB_ACTION";

        public MES_ZLRBB_SELECT SELECT(MES_ZLRBB_SEARCH model)
        {
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_ZLRBB> child_MES_ZLRBB = new List<MES_ZLRBB>();
            MES_ZLRBB_SELECT rst = new MES_ZLRBB_SELECT();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@RI", model.RI),
                                           new SqlParameter("@SDLINE", model.SDLINE),
                                           new SqlParameter("@DATES", model.DATES),
                                           new SqlParameter("@DATEE", model.DATEE),
                                           new SqlParameter("@LB", model.LB),
                                           new SqlParameter("@ISACTION", model.ISACTION),
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_ZLRBB, parms))
                {
                    while (sdr.Read())
                    {
                        MES_ZLRBB child = new MES_ZLRBB();
                        child.DATE = Convert.ToString(sdr["DATE"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.CJRID = Convert.ToInt32(sdr["CJRID"]);
                        child.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);
                        child.SDLINE = Convert.ToString(sdr["SDLINE"]);
                        child.JLTXR = Convert.ToString(sdr["JLTXR"]);
                        child.JLTXRID = Convert.ToInt32(sdr["JLTXRID"]);
                        child.JLTXRGH = Convert.ToString(sdr["JLTXRGH"]);
                        child.BZ = Convert.ToString(sdr["BZ"]);
                        child.LB = Convert.ToInt32(sdr["LB"]);
                        child.RI = Convert.ToInt32(sdr["RI"]);
                        switch (child.LB)
                        {
                            case 1:
                                child.BC = Convert.ToString(sdr["BC"]);
                                child.BCID = Convert.ToInt32(sdr["BCID"]);
                                child.ZJHQR = Convert.ToInt32(sdr["ZJHQR"]);
                                child.KX = Convert.ToInt32(sdr["KX"]);
                                child.FKJTB = Convert.ToInt32(sdr["FKJTB"]);
                                child.GMZCR = Convert.ToInt32(sdr["GMZCR"]);
                                child.DJYZR = Convert.ToInt32(sdr["DJYZR"]);
                                child.XGZR = Convert.ToInt32(sdr["XGZR"]);
                                child.FKCX = Convert.ToInt32(sdr["FKCX"]);
                                child.DDMTB = Convert.ToInt32(sdr["DDMTB"]);
                                child.SDCL = Convert.ToSingle(sdr["SDCL"]);
                                break;
                            case 2:
                            case 4:
                                child.VYX = Convert.ToInt32(sdr["VYX"]);
                                child.VZ = Convert.ToInt32(sdr["VZ"]);
                                child.VYS = Convert.ToInt32(sdr["VYS"]);
                                child.SDZYXCCD = Convert.ToInt32(sdr["SDZYXCCD"]);
                                child.WGBL = Convert.ToInt32(sdr["WGBL"]);
                                //VYX：
                                child.ID = Convert.ToInt32(sdr["ID"]);
                                child.HD = Convert.ToInt32(sdr["HD"]);
                                child.TTBL = Convert.ToInt32(sdr["TTBL"]);
                                child.LKCK = Convert.ToInt32(sdr["LKCK"]);
                                child.TTP = Convert.ToInt32(sdr["TTP"]);
                                child.CP = Convert.ToInt32(sdr["CP"]);
                                child.CXBL = Convert.ToInt32(sdr["CXBL"]);
                                child.HT = Convert.ToInt32(sdr["HT"]);
                                child.WXG = Convert.ToInt32(sdr["WXG"]);
                                child.YC = Convert.ToInt32(sdr["YC"]);
                                child.TDXC = Convert.ToInt32(sdr["TDXC"]);
                                child.TPLS = Convert.ToInt32(sdr["TPLS"]);
                                child.KXBL = Convert.ToInt32(sdr["KXBL"]);
                                child.DGX = Convert.ToInt32(sdr["DGX"]);
                                child.TDTH = Convert.ToInt32(sdr["TDTH"]);
                                child.RJZRBL = Convert.ToInt32(sdr["RJZRBL"]);
                                child.WBDL = Convert.ToInt32(sdr["WBDL"]);
                                child.YYBM = Convert.ToInt32(sdr["YYBM"]);
                                child.QT = Convert.ToInt32(sdr["QT"]);
                                break;
                            case 3:
                                child.VYX = Convert.ToInt32(sdr["VYX"]);
                                child.VZ = Convert.ToInt32(sdr["VZ"]);
                                child.VYS = Convert.ToInt32(sdr["VYS"]);
                                child.SDZYXCCD = Convert.ToInt32(sdr["SDZYXCCD"]);
                                child.WGBL = Convert.ToInt32(sdr["WGBL"]);
                                break;
                        }
                        child_MES_ZLRBB.Add(child);
                    }
                    child_MES_RETURN.MESSAGE = "SELECT_ZLRBB";
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.MES_ZLRBB = child_MES_ZLRBB;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }

        public MES_ZLRBB_SELECT SELECT_SUM(MES_ZLRBB_SEARCH model)
        {
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_ZLRBB> child_MES_ZLRBB = new List<MES_ZLRBB>();
            MES_ZLRBB_SELECT rst = new MES_ZLRBB_SELECT();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@SDLINE", model.SDLINE),
                                           new SqlParameter("@DATEM", model.DATEM)
                                       };
                if (model.SDLINE == "")
                {
                    using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_ZLRBB_SUM, parms))
                    {
                        while (sdr.Read())
                        {
                            MES_ZLRBB child = new MES_ZLRBB();
                            child.SDLINE = Convert.ToString(sdr["SDLINE"]);
                            child.LB = Convert.ToInt32(sdr["LB"]);
                            child.ZJHQR = Convert.ToInt32(sdr["ZJHQR"]);
                            child.KX = Convert.ToInt32(sdr["KX"]);
                            child.FKJTB = Convert.ToInt32(sdr["FKJTB"]);
                            child.GMZCR = Convert.ToInt32(sdr["GMZCR"]);
                            child.DJYZR = Convert.ToInt32(sdr["DJYZR"]);
                            child.XGZR = Convert.ToInt32(sdr["XGZR"]);
                            child.FKCX = Convert.ToInt32(sdr["FKCX"]);
                            child.DDMTB = Convert.ToInt32(sdr["DDMTB"]);
                            child.SDCL = Convert.ToSingle(sdr["SDCL"]);
                            if (sdr["VYX"] != DBNull.Value) child.VYX = Convert.ToInt32(sdr["VYX"]);
                            if (sdr["VZ"] != DBNull.Value) child.VZ = Convert.ToInt32(sdr["VZ"]);
                            if (sdr["VYS"] != DBNull.Value) child.VYS = Convert.ToInt32(sdr["VYS"]);
                            if (sdr["SDZYXCCD"] != DBNull.Value) child.SDZYXCCD = Convert.ToInt32(sdr["SDZYXCCD"]);
                            if (sdr["WGBL"] != DBNull.Value) child.WGBL = Convert.ToInt32(sdr["WGBL"]);
                            child_MES_ZLRBB.Add(child);
                        }
                        child_MES_RETURN.MESSAGE = "SELECT_ZLRBB_SUM(SDLINE is null)";
                    }
                }
                else
                {
                    using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_ZLRBB_SUM, parms))
                    {
                        while (sdr.Read())
                        {
                            MES_ZLRBB child = new MES_ZLRBB();
                            child.DATE = Convert.ToString(sdr["DATE"]);
                            child.SDLINE = Convert.ToString(sdr["SDLINE"]);
                            child.LB = Convert.ToInt32(sdr["LB"]);
                            child.RI = Convert.ToInt32(sdr["RI"]);
                            switch (child.LB)
                            {
                                case 1:
                                    child.BC = Convert.ToString(sdr["BC"]);
                                    child.BCID = Convert.ToInt32(sdr["BCID"]);
                                    child.JLTXR = Convert.ToString(sdr["JLTXR"]);
                                    child.ZJHQR = Convert.ToInt32(sdr["ZJHQR"]);
                                    child.KX = Convert.ToInt32(sdr["KX"]);
                                    child.FKJTB = Convert.ToInt32(sdr["FKJTB"]);
                                    child.GMZCR = Convert.ToInt32(sdr["GMZCR"]);
                                    child.DJYZR = Convert.ToInt32(sdr["DJYZR"]);
                                    child.XGZR = Convert.ToInt32(sdr["XGZR"]);
                                    child.FKCX = Convert.ToInt32(sdr["FKCX"]);
                                    child.DDMTB = Convert.ToInt32(sdr["DDMTB"]);
                                    child.SDCL = Convert.ToSingle(sdr["SDCL"]);
                                    child.BZ = Convert.ToString(sdr["BZ"]);
                                    break;
                                case 2:
                                    child.VYX = Convert.ToInt32(sdr["VYX"]);
                                    child.VZ = Convert.ToInt32(sdr["VZ"]);
                                    child.VYS = Convert.ToInt32(sdr["VYS"]);
                                    child.SDZYXCCD = Convert.ToInt32(sdr["SDZYXCCD"]);
                                    child.WGBL = Convert.ToInt32(sdr["WGBL"]);
                                    break;
                                case 4:
                                    child.ZJHQR = Convert.ToInt32(sdr["ZJHQR"]);
                                    child.KX = Convert.ToInt32(sdr["KX"]);
                                    child.FKJTB = Convert.ToInt32(sdr["FKJTB"]);
                                    child.GMZCR = Convert.ToInt32(sdr["GMZCR"]);
                                    child.DJYZR = Convert.ToInt32(sdr["DJYZR"]);
                                    child.XGZR = Convert.ToInt32(sdr["XGZR"]);
                                    child.FKCX = Convert.ToInt32(sdr["FKCX"]);
                                    child.DDMTB = Convert.ToInt32(sdr["DDMTB"]);
                                    child.SDCL = Convert.ToSingle(sdr["SDCL"]);

                                    if (sdr["VYX"] != DBNull.Value) child.VYX = Convert.ToInt32(sdr["VYX"]);
                                    if (sdr["VZ"] != DBNull.Value) child.VZ = Convert.ToInt32(sdr["VZ"]);
                                    if (sdr["VYS"] != DBNull.Value) child.VYS = Convert.ToInt32(sdr["VYS"]);
                                    if (sdr["SDZYXCCD"] != DBNull.Value) child.SDZYXCCD = Convert.ToInt32(sdr["SDZYXCCD"]);
                                    if (sdr["WGBL"] != DBNull.Value) child.WGBL = Convert.ToInt32(sdr["WGBL"]);
                                    break;
                                case 5:
                                    child.ZJHQR = Convert.ToInt32(sdr["ZJHQR"]);
                                    child.KX = Convert.ToInt32(sdr["KX"]);
                                    child.FKJTB = Convert.ToInt32(sdr["FKJTB"]);
                                    child.GMZCR = Convert.ToInt32(sdr["GMZCR"]);
                                    child.DJYZR = Convert.ToInt32(sdr["DJYZR"]);
                                    child.XGZR = Convert.ToInt32(sdr["XGZR"]);
                                    child.FKCX = Convert.ToInt32(sdr["FKCX"]);
                                    child.DDMTB = Convert.ToInt32(sdr["DDMTB"]);
                                    child.SDCL = Convert.ToSingle(sdr["SDCL"]);

                                    if (sdr["VYX"] != DBNull.Value) child.VYX = Convert.ToInt32(sdr["VYX"]);
                                    if (sdr["VZ"] != DBNull.Value) child.VZ = Convert.ToInt32(sdr["VZ"]);
                                    if (sdr["VYS"] != DBNull.Value) child.VYS = Convert.ToInt32(sdr["VYS"]);
                                    if (sdr["SDZYXCCD"] != DBNull.Value) child.SDZYXCCD = Convert.ToInt32(sdr["SDZYXCCD"]);
                                    if (sdr["WGBL"] != DBNull.Value) child.WGBL = Convert.ToInt32(sdr["WGBL"]);
                                    break;
                            }
                            child_MES_ZLRBB.Add(child);
                        }
                        child_MES_RETURN.MESSAGE = "SELECT_ZLRBB_SUM(SDLINE is not null)";
                    }
                }
                child_MES_RETURN.TYPE = "S";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            rst.MES_ZLRBB = child_MES_ZLRBB;
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }

        public MES_RETURN COVER(MES_ZLRBB model)
        {
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                    new SqlParameter("@RI",model.RI),
                                    new SqlParameter("@DATE",model.DATE),
                                    new SqlParameter("@SDLINE",model.SDLINE),
                                    new SqlParameter("@SDLINEID",model.SDLINEID),
                                    new SqlParameter("@LB",model.LB),
                                    new SqlParameter("@JLTXRID",model.JLTXRID),
                                    new SqlParameter("@BZ",model.BZ),
                                    new SqlParameter("@ISACTION",model.ISACTION),
                                    new SqlParameter("@CJRID",model.CJRID),

                                    new SqlParameter("@BC",model.BC),
                                    new SqlParameter("@BCID",model.BCID),
                                    new SqlParameter("@ZJHQR",model.ZJHQR),
                                    new SqlParameter("@KX",model.KX),
                                    new SqlParameter("@FKJTB",model.FKJTB),
                                    new SqlParameter("@GMZCR",model.GMZCR),
                                    new SqlParameter("@DJYZR",model.DJYZR),
                                    new SqlParameter("@XGZR",model.XGZR),
                                    new SqlParameter("@FKCX",model.FKCX),
                                    new SqlParameter("@DDMTB",model.DDMTB),
                                    new SqlParameter("@SDCL",model.SDCL),

                                    new SqlParameter("@VYX",model.VYX),
                                    new SqlParameter("@VZ",model.VZ),
                                    new SqlParameter("@VYS",model.VYS),
                                    new SqlParameter("@SDZYXCCD",model.SDZYXCCD),
                                    new SqlParameter("@WGBL",model.WGBL),
                                };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_COVER_ZLRBB, parms))
                {
                    if (sdr.Read())
                    {
                        child_MES_RETURN.TID = Convert.ToInt32(sdr["RI"]);
                        child_MES_RETURN.TYPE = Convert.ToString(sdr["TYPE"]);
                        child_MES_RETURN.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            return child_MES_RETURN;
        }

        public MES_RETURN COVER_TMARK(MES_ZLRBB model)
        {
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                    new SqlParameter("@RI",model.RI),
                                    new SqlParameter("@DATE",model.DATE),
                                    new SqlParameter("@SDLINE",model.SDLINE),
                                    new SqlParameter("@SDLINEID",model.SDLINEID),
                                    new SqlParameter("@JLTXRID",model.JLTXRID),
                                    new SqlParameter("@BZ",model.BZ),
                                    new SqlParameter("@CJRID",model.CJRID),
                                    new SqlParameter("@VYX",model.VYX),
                                    new SqlParameter("@VZ",model.VZ),
                                    new SqlParameter("@VYS",model.VYS),
                                    new SqlParameter("@SDZYXCCD",model.SDZYXCCD),
                                    new SqlParameter("@WGBL",model.WGBL)
                                };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_COVER_ZLRBB_TMARK, parms))
                {
                    if (sdr.Read())
                    {
                        child_MES_RETURN.TID = Convert.ToInt32(sdr["RI"]);
                        child_MES_RETURN.TYPE = Convert.ToString(sdr["TYPE"]);
                        child_MES_RETURN.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            return child_MES_RETURN;
        }

        public MES_RETURN ACTION(int RI)
        {
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                    new SqlParameter("@RI",RI)
                                };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ACTION_ZLRBB, parms))
                {
                    if (sdr.Read())
                    {
                        child_MES_RETURN.TYPE = Convert.ToString(sdr["TYPE"]);
                        child_MES_RETURN.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            return child_MES_RETURN;
        }

        public MES_RETURN DELETE(int RI, int STAFFID)
        {
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                    new SqlParameter("@RI",RI),
                                    new SqlParameter("@CJRID",STAFFID)
                                };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE_ZLRBB, parms))
                {
                    if (sdr.Read())
                    {
                        child_MES_RETURN.TYPE = Convert.ToString(sdr["TYPE"]);
                        child_MES_RETURN.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            return child_MES_RETURN;
        }

        public MES_RETURN DELETE_TMARK(int RI)
        {
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                    new SqlParameter("@RI",RI)
                                };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE_ZLRBB_TMARK, parms))
                {
                    if (sdr.Read())
                    {
                        child_MES_RETURN.TYPE = Convert.ToString(sdr["TYPE"]);
                        child_MES_RETURN.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
            }
            return child_MES_RETURN;
        }
    }
}
