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
    class BAT_QLTY_TMARK : IBAT_QLTY_TMARK
    {
        const string SQL_SELECT_SUM = "MES_ZLRBB_TMARK_SELECT_SUM";
        const string SQL_COVER = "MES_ZLRBB_TMARK_COVER";

        public MES_ZLRBB_SELECT SELECT_SUM(MES_ZLRBB_SEARCH model)
        {
            MES_ZLRBB_SELECT rst = new MES_ZLRBB_SELECT();
            rst.MES_ZLRBB = new List<MES_ZLRBB>();
            rst.MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@SDLINE", model.SDLINE),
                                           new SqlParameter("@DATEM", model.DATEM)
                                       };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_SUM, parms))
                {
                    while (sdr.Read())
                    {
                        MES_ZLRBB child = new MES_ZLRBB();
                        child.DATE = Convert.ToString(sdr["DATE"]);
                        child.SDLINE = Convert.ToString(sdr["SDLINE"]);
                        child.LB = Convert.ToInt32(sdr["LB"]);

                        if (sdr["VYX"] != DBNull.Value) child.VYX = Convert.ToInt32(sdr["VYX"]);
                        if (sdr["VZ"] != DBNull.Value) child.VZ = Convert.ToInt32(sdr["VZ"]);
                        if (sdr["VYS"] != DBNull.Value) child.VYS = Convert.ToInt32(sdr["VYS"]);
                        if (sdr["SDZYXCCD"] != DBNull.Value) child.SDZYXCCD = Convert.ToInt32(sdr["SDZYXCCD"]);
                        if (sdr["WGBL"] != DBNull.Value) child.WGBL = Convert.ToInt32(sdr["WGBL"]);

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
                        rst.MES_ZLRBB.Add(child);
                    }
                    rst.MES_RETURN.TYPE = "S";
                    rst.MES_RETURN.MESSAGE = "SELECT_ZLRBB_SUM";
                }
            }
            catch (Exception e)
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = e.Message;
            }
            return rst;
        }

        public MES_RETURN COVER(MES_ZLRBB model)
        {
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                    new SqlParameter("@ID",model.ID),
                                    new SqlParameter("@RI",model.RI),
                                    new SqlParameter("@HD",model.HD),
                                    new SqlParameter("@TTBL",model.TTBL),
                                    new SqlParameter("@LKCK",model.LKCK),
                                    new SqlParameter("@TTP",model.TTP),
                                    new SqlParameter("@CP",model.CP),
                                    new SqlParameter("@CXBL",model.CXBL),
                                    new SqlParameter("@HT",model.HT),
                                    new SqlParameter("@WXG",model.WXG),
                                    new SqlParameter("@YC",model.YC),
                                    new SqlParameter("@TDXC",model.TDXC),
                                    new SqlParameter("@TPLS",model.TPLS),
                                    new SqlParameter("@KXBL",model.KXBL),
                                    new SqlParameter("@DGX",model.DGX),
                                    new SqlParameter("@TDTH",model.TDTH),
                                    new SqlParameter("@RJZRBL",model.RJZRBL),
                                    new SqlParameter("@WBDL",model.WBDL),
                                    new SqlParameter("@YYBM",model.YYBM),
                                    new SqlParameter("@QT",model.QT),
                                };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_COVER, parms))
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
