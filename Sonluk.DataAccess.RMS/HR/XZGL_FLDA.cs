using Sonluk.DataAccess.RMS.MES;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.HR
{
    public class XZGL_FLDA : IXZGL_FLDA
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_XZGL_FLDA_INSERT";
        const string SQL_SELECT = "HR_XZGL_FLDA_SELECT";
        const string SQL_UPDATE = "HR_XZGL_FLDA_UPDATE";
        public MES_RETURN INSERT(HR_XZGL_FLDA model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@FLFAID",model.FLFAID),
                                       new SqlParameter("@ISJS",model.ISJS),
                                       new SqlParameter("@SBJS",model.SBJS),
                                       new SqlParameter("@SBZH",model.SBZH),
                                       new SqlParameter("@SBKH",model.SBKH),
                                       new SqlParameter("@SBKSYEAR",model.SBKSYEAR),
                                       new SqlParameter("@SBKSMOUTH",model.SBKSMOUTH),
                                       new SqlParameter("@SBJSYEAR",model.SBJSYEAR),
                                       new SqlParameter("@SBJSMOUTH",model.SBJSMOUTH),
                                       new SqlParameter("@GJJJS",model.GJJJS),
                                       new SqlParameter("@GJJNO",model.GJJNO),
                                       new SqlParameter("@GJJKSYEAR",model.GJJKSYEAR),
                                       new SqlParameter("@GJJKSMOUTH",model.GJJKSMOUTH),
                                       new SqlParameter("@GJJJSYEAR",model.GJJJSYEAR),
                                       new SqlParameter("@GJJJSMOUTH",model.GJJJSMOUTH),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@MYPW",model.MYPW)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FLDA_INSERT", "HR");
            }
            return rst;
        }
        public MES_RETURN UPDATE(HR_XZGL_FLDA model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@FLFAID",model.FLFAID),
                                       new SqlParameter("@ISJS",model.ISJS),
                                       new SqlParameter("@SBJS",model.SBJS),
                                       new SqlParameter("@SBZH",model.SBZH),
                                       new SqlParameter("@SBKH",model.SBKH),
                                       new SqlParameter("@SBKSYEAR",model.SBKSYEAR),
                                       new SqlParameter("@SBKSMOUTH",model.SBKSMOUTH),
                                       new SqlParameter("@SBJSYEAR",model.SBJSYEAR),
                                       new SqlParameter("@SBJSMOUTH",model.SBJSMOUTH),
                                       new SqlParameter("@GJJJS",model.GJJJS),
                                       new SqlParameter("@GJJNO",model.GJJNO),
                                       new SqlParameter("@GJJKSYEAR",model.GJJKSYEAR),
                                       new SqlParameter("@GJJKSMOUTH",model.GJJKSMOUTH),
                                       new SqlParameter("@GJJJSYEAR",model.GJJJSYEAR),
                                       new SqlParameter("@GJJJSMOUTH",model.GJJJSMOUTH),
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@XGR",model.XGR),
                                       new SqlParameter("@MYPW",model.MYPW)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FLDA_UPDATE", "HR");
            }
            return rst;
        }
        public HR_XZGL_FLDA_SELECT SELECT(HR_XZGL_FLDA model)
        {
            HR_XZGL_FLDA_SELECT rst = new HR_XZGL_FLDA_SELECT();
            List<HR_XZGL_FLDA_LIST> child_HR_XZGL_FLDA_LIST = new List<HR_XZGL_FLDA_LIST>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@ZZZT",model.ZZZT),
                                       new SqlParameter("@MYPW",model.MYPW),
                                       new SqlParameter("@GS",model.GS),
                                       new SqlParameter("@DEPT",model.DEPT),
                                       new SqlParameter("@GH",model.GH),
                                       new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, paras))
                {
                    while (sdr.Read())
                    {
                        HR_XZGL_FLDA_LIST child = new HR_XZGL_FLDA_LIST();
                        child.RYID = Convert.ToInt32(sdr["RYID"]);
                        child.FLFAID = Convert.ToInt32(sdr["FLFAID"]);
                        child.FLFANAME = Convert.ToString(sdr["FLFANAME"]);
                        child.ISJS = Convert.ToInt32(sdr["ISJS"]);
                        child.SBJS = Convert.ToDecimal(sdr["SBJS"]);
                        child.SBZH = Convert.ToString(sdr["SBZH"]);
                        child.SBKH = Convert.ToString(sdr["SBKH"]);
                        child.SBKSYEAR = Convert.ToString(sdr["SBKSYEAR"]);
                        child.SBKSMOUTH = Convert.ToString(sdr["SBKSMOUTH"]);
                        child.SBJSYEAR = Convert.ToString(sdr["SBJSYEAR"]);
                        child.SBJSMOUTH = Convert.ToString(sdr["SBJSMOUTH"]);
                        child.GJJJS = Convert.ToDecimal(sdr["GJJJS"]);
                        child.GJJNO = Convert.ToString(sdr["GJJNO"]);
                        child.GJJKSYEAR = Convert.ToString(sdr["GJJKSYEAR"]);
                        child.GJJKSMOUTH = Convert.ToString(sdr["GJJKSMOUTH"]);
                        child.GJJJSYEAR = Convert.ToString(sdr["GJJJSYEAR"]);
                        child.GJJJSMOUTH = Convert.ToString(sdr["GJJJSMOUTH"]);
                        child.GH = Convert.ToString(sdr["GH"]);
                        child.YGNAME = Convert.ToString(sdr["YGNAME"]);
                        child.DEPTNAME = Convert.ToString(sdr["DEPTNAME"]);
                        child.ZZTYPENAME = Convert.ToString(sdr["ZZTYPENAME"]);
                        child.ZZNO = Convert.ToString(sdr["ZZNO"]);
                        child.YGTYPENAME = Convert.ToString(sdr["YGTYPENAME"]);
                        child.GSNAME = Convert.ToString(sdr["GSNAME"]);
                        child.ZZZTNAME = Convert.ToString(sdr["ZZZTNAME"]);
                        child_HR_XZGL_FLDA_LIST.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_XZGL_FLDA_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.HR_XZGL_FLDA_LIST = child_HR_XZGL_FLDA_LIST;
            return rst;
        }
    }
}
