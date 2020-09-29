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
    public class ADMINISTRATION_DORM : IADMINISTRATION_DORM
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "HR_ADMINISTRATION_DORM_DORM_INSERT";
        const string SQL_UPDATE = "HR_ADMINISTRATION_DORM_DORM_UPDATE";
        const string SQL_SELECT = "HR_ADMINISTRATION_DORM_DORM_SELECT";
        const string SQL_ROOM_INSERT = "HR_ADMINISTRATION_DORM_ROOM_INSERT";
        const string SQL_ROOM_UPDATE = "HR_ADMINISTRATION_DORM_ROOM_UPDATE";
        const string SQL_ROOM_SELECT = "HR_ADMINISTRATION_DORM_ROOM_SELECT";
        const string SQL_LIVE_INSERT = "HR_ADMINISTRATION_DORM_LIVE_INSERT";
        const string SQL_LIVE_UPDATE = "HR_ADMINISTRATION_DORM_LIVE_UPDATE";
        const string SQL_LIVE_SELECT = "HR_ADMINISTRATION_DORM_LIVE_SELECT";
        public MES_RETURN INSERT(HR_ADMINISTRATION_DORM_DORM model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DORMNAME",model.DORMNAME),
                                       new SqlParameter("@DORMADDRESS",model.DORMADDRESS),
                                       new SqlParameter("@DORMJG",model.DORMJG),
                                       new SqlParameter("@DORMSGY",model.DORMSGY),
                                       new SqlParameter("@DORMNUMBER",model.DORMNUMBER),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ADMINISTRATION_DORM_DORM_INSERT", "HR");
            }
            return rst;
        }

        public MES_RETURN UPDATE(HR_ADMINISTRATION_DORM_DORM model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@DORMID",model.DORMID),
                                           new SqlParameter("@DORMNAME",model.DORMNAME),
                                           new SqlParameter("@DORMADDRESS",model.DORMADDRESS),
                                           new SqlParameter("@DORMJG",model.DORMJG),
                                           new SqlParameter("@DORMSGY",model.DORMSGY),
                                           new SqlParameter("@DORMNUMBER",model.DORMNUMBER),
                                           new SqlParameter("@REMARK",model.REMARK),
                                           new SqlParameter("@XGR",model.XGR),
                                           new SqlParameter("@LB",model.LB)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ADMINISTRATION_DORM_DORM_UPDATE", "HR");
            }
            return rst;
        }
        public HR_ADMINISTRATION_DORM_DORM_SELECT SELECT(HR_ADMINISTRATION_DORM_DORM model)
        {
            HR_ADMINISTRATION_DORM_DORM_SELECT rst = new HR_ADMINISTRATION_DORM_DORM_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@LB",model.LB),
                                           new SqlParameter("@DORMID",model.DORMID),
                                           new SqlParameter("@DORMNAME",model.DORMNAME)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ADMINISTRATION_DORM_DORM_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }

        public MES_RETURN ROOM_INSERT(HR_ADMINISTRATION_DORM_ROOM model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DORMID",model.DORMID),
                                       new SqlParameter("@ROOMNAME",model.ROOMNAME),
                                       new SqlParameter("@ROOMTYPE",model.ROOMTYPE),
                                       new SqlParameter("@ROOMRYCOUNT",model.ROOMRYCOUNT),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ROOM_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ADMINISTRATION_DORM_ROOM_INSERT", "HR");
            }
            return rst;
        }
        public HR_ADMINISTRATION_DORM_ROOM_SELECT ROOM_SELECT(HR_ADMINISTRATION_DORM_ROOM model)
        {
            HR_ADMINISTRATION_DORM_ROOM_SELECT rst = new HR_ADMINISTRATION_DORM_ROOM_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@LB",model.LB),
                                           new SqlParameter("@DORMNAME",model.DORMNAME),
                                           new SqlParameter("@LIVENAME",model.LIVENAME),
                                           new SqlParameter("@ROOMTYPELIST",model.ROOMTYPELIST),
                                           new SqlParameter("@ROOMZT",model.ROOMZT),
                                           new SqlParameter("@DORMID",model.DORMID),
                                           new SqlParameter("@ROOMNAME",model.ROOMNAME)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_ROOM_SELECT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ADMINISTRATION_DORM_ROOM_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN ROOM_UPDATE(HR_ADMINISTRATION_DORM_ROOM model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@LB",model.LB),
                                           new SqlParameter("@ROOMID",model.ROOMID),
                                           new SqlParameter("@ROOMNAME",model.ROOMNAME),
                                           new SqlParameter("@ROOMTYPE",model.ROOMTYPE),
                                           new SqlParameter("@ROOMRYCOUNT",model.ROOMRYCOUNT),
                                           new SqlParameter("@REMARK",model.REMARK),
                                           new SqlParameter("@XGR",model.XGR)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ROOM_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ADMINISTRATION_DORM_ROOM_UPDATE", "HR");
            }
            return rst;
        }
        public MES_RETURN LIVE_INSERT(HR_ADMINISTRATION_DORM_LIVE model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ROOMID",model.ROOMID),
                                       new SqlParameter("@LIVENAME",model.LIVENAME),
                                       new SqlParameter("@LIVETYPE",model.LIVETYPE),
                                       new SqlParameter("@LIVEXB",model.LIVEXB),
                                       new SqlParameter("@LIVEXL",model.LIVEXL),
                                       new SqlParameter("@GH",model.GH),
                                       new SqlParameter("@LIVEPHONENUMBER",model.LIVEPHONENUMBER),
                                       new SqlParameter("@LIVEINRQ",model.LIVEINRQ),
                                       new SqlParameter("@LIVEOUTRQ",model.LIVEOUTRQ),
                                       new SqlParameter("@LIVEJG",model.LIVEJG),
                                       new SqlParameter("@REMARK",model.REMARK),
                                       new SqlParameter("@CJR",model.CJR),
                                       new SqlParameter("@RYID",model.RYID),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@GSNAME",model.GSNAME),
                                       new SqlParameter("@GSBMNAME",model.GSBMNAME)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_LIVE_INSERT, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ADMINISTRATION_DORM_LIVE_INSERT", "HR");
            }
            return rst;
        }
        public HR_ADMINISTRATION_DORM_LIVE_SELECT LIVE_SELECT(HR_ADMINISTRATION_DORM_LIVE model)
        {
            HR_ADMINISTRATION_DORM_LIVE_SELECT rst = new HR_ADMINISTRATION_DORM_LIVE_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@LB",model.LB),
                                           new SqlParameter("@DORMNAME",model.DORMNAME),    
                                           new SqlParameter("@LIVENAME",model.LIVENAME),
                                           new SqlParameter("@ROOMTYPELIST",model.ROOMTYPELIST),
                                           new SqlParameter("@ROOMZT",model.ROOMZT),
                                           new SqlParameter("@LIVETYPE",model.LIVETYPE),
                                           new SqlParameter("@DATEKS",model.DATEKS),
                                           new SqlParameter("@DATEJS",model.DATEJS),
                                           new SqlParameter("@DATEKS2",model.DATEKS2),
                                           new SqlParameter("@DATEJS2",model.DATEJS2),
                                           new SqlParameter("@ROOMID",model.ROOMID),
                                           new SqlParameter("@ROOMNAME",model.ROOMNAME)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_LIVE_SELECT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ADMINISTRATION_DORM_LIVE_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN LIVE_UPDATE(HR_ADMINISTRATION_DORM_LIVE model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@LB",model.LB),
                                           new SqlParameter("@LIVEID",model.LIVEID),
                                           new SqlParameter("@LIVENAME",model.LIVENAME),
                                           new SqlParameter("@LIVETYPE",model.LIVETYPE),
                                           new SqlParameter("@LIVEXB",model.LIVEXB),
                                           new SqlParameter("@LIVEXL",model.LIVEXL),
                                           new SqlParameter("@GH",model.GH),
                                           new SqlParameter("@LIVEPHONENUMBER",model.LIVEPHONENUMBER),
                                           new SqlParameter("@LIVEINRQ",model.LIVEINRQ),
                                           new SqlParameter("@LIVEOUTRQ",model.LIVEOUTRQ),
                                           new SqlParameter("@LIVEJG",model.LIVEJG),
                                           new SqlParameter("@REMARK",model.REMARK),
                                           new SqlParameter("@XGR",model.XGR),
                                           new SqlParameter("@GSNAME",model.GSNAME),
                                           new SqlParameter("@GSBMNAME",model.GSBMNAME)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_LIVE_UPDATE, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_ADMINISTRATION_DORM_LIVE_UPDATE", "HR");
            }
            return rst;
        }
    }
}
