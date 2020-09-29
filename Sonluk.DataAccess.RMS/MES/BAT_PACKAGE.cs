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
    class BAT_PACKAGE : IBAT_PACKAGE
    {
        const string SQL_BAT_PACKAGE_SELECT = "MES_PD_GD_PACKINFO_SELECT";
        const string SQL_BAT_PACKAGE_COVER = "MES_PD_GD_PACKINFO_COVER";
        const string SQL_BAT_PACKAGE_DELETE = "MES_PD_GD_PACKINFO_DELETE";
        const string SQL_MES_PD_GD_SELECT = "MES_PD_GD_SELECT_PACKINFO";

        public MES_PD_GD_PACKINFO_SELECT SELECT_ERPINFO(MES_PD_GD_PACKINFO_SEARCH model, string WLLBNAME = "")
        {
            MES_PD_GD_PACKINFO_SELECT rst = new MES_PD_GD_PACKINFO_SELECT();
            rst.MES_PD_GD_PACKINFO = new List<MES_PD_GD_PACKINFO>();
            rst.MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@ERPNO",model.ERPNO),
                                       new SqlParameter("@XSNOBILL",model.XSNOBILL),
                                       new SqlParameter("@XSNOBILLMX",model.XSNOBILLMX),
                                       new SqlParameter("@DATE",model.DATE),
                                       new SqlParameter("@DATES",model.DATES),
                                       new SqlParameter("@DATEE",model.DATEE),
                                       new SqlParameter("@WLLBNAME",WLLBNAME) 
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_MES_PD_GD_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_PD_GD_PACKINFO child = new MES_PD_GD_PACKINFO();
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.ERPNO = Convert.ToString(sdr["ERPNO"]);
                        child.XSNOBILL = Convert.ToString(sdr["XSNOBILL"]);
                        child.XSNOBILLMX = Convert.ToString(sdr["XSNOBILLMX"]);
                        child.GDDH = Convert.ToString(sdr["GDDH"]);
                        child.WLH = Convert.ToString(sdr["WLH"]);
                        child.WLMS = Convert.ToString(sdr["WLMS"]);
                        child.SL = Convert.ToInt32(sdr["SL"]);
                        child.DCXHNAME = Convert.ToString(sdr["DCXHNAME"]);
                        child.DCDJNAME = Convert.ToString(sdr["DCDJNAME"]);
                        child.JSDATE = Convert.ToString(sdr["JSDATE"]);
                        rst.MES_PD_GD_PACKINFO.Add(child);
                    }

                }
                rst.MES_RETURN.TYPE = "S";
                rst.MES_RETURN.MESSAGE = "SELECTED";
            }
            catch (Exception e)
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return rst;
        }

        public MES_PD_GD_PACKINFO SELECT_SINGLE(string GDDH)
        {
            MES_PD_GD_PACKINFO rst = new MES_PD_GD_PACKINFO();
            rst.ISPACK = false;
            rst.MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GDDH",GDDH)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_BAT_PACKAGE_SELECT, parms))
                {
                    if (sdr.Read())
                    {
                        rst.ISPACK = true;
                        rst.COUNTX = Convert.ToString(sdr["COUNTX"]);
                        rst.GDDH = Convert.ToString(sdr["GDDH"]);
                        rst.SNINFO = Convert.ToString(sdr["SNINFO"]);
                        rst.CXS = Convert.ToString(sdr["CXS"]);
                        rst.WG = Convert.ToString(sdr["WG"]);
                        rst.INSULATION = Convert.ToString(sdr["INSULATION"]);
                        rst.CODOWORD = Convert.ToString(sdr["CODOWORD"]);
                        rst.WORDSPACE = Convert.ToString(sdr["WORDSPACE"]);
                        rst.KPRQM = Convert.ToString(sdr["KPRQM"]);
                    }

                }
                rst.MES_RETURN.TYPE = "S";
                rst.MES_RETURN.MESSAGE = "SELECTED";
            }
            catch (Exception e)
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return rst;
        }

        public MES_RETURN COVER(MES_PD_GD_PACKINFO model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GDDH",model.GDDH),
                                       new SqlParameter("@COUNTX",model.COUNTX),
                                       new SqlParameter("@SNINFO",model.SNINFO),
                                       new SqlParameter("@CXS",model.CXS),
                                       new SqlParameter("@WG",model.WG),
                                       new SqlParameter("@INSULATION",model.INSULATION),
                                       new SqlParameter("@CODOWORD",model.CODOWORD),
                                       new SqlParameter("@WORDSPACE",model.WORDSPACE),
                                       new SqlParameter("@KPRQM",model.KPRQM)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_BAT_PACKAGE_COVER, parms))
                {
                    if (sdr.Read())
                    {
                        rst.TYPE = "S";
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }

                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return rst;
        }

        public MES_RETURN DELETE(string GDDH)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GDDH",GDDH)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_BAT_PACKAGE_DELETE, parms))
                {
                    if (sdr.Read())
                    {
                        rst.TYPE = "S";
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }

                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return rst;
        }
    }
}
