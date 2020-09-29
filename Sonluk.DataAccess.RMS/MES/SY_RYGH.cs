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
    public class SY_RYGH : ISY_RYGH
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT_GS = "MES_SY_RYGH_GS_INSERT";
        const string SQL_SELECT_GS = "MES_SY_RYGH_GS_SELECT";

        const string SQL_INSERT = "MES_SY_RYGH_INSERT";
        const string SQL_SELECT = "MES_SY_RYGH_SELECT";
        const string SQL_UPDATE = "MES_SY_RYGH_UPDATE";
        public MES_RETURN INSERT_GS(MES_SY_RYGH_GS model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYGSDM",model.RYGSDM),
                                       new SqlParameter("@RYGSSM",model.RYGSSM),
                                       new SqlParameter("@RYGSREMARK",model.RYGSREMARK),
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@CJRID",model.CJRID),
                                       new SqlParameter("@GHWS",model.GHWS)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_GS, parms))
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_RYGH_GS_INSERT", "MES");
            }
            return rst;
        }
        public MES_SY_RYGH_GS_SELECT SELECT_GS(MES_SY_RYGH_GS model)
        {
            MES_SY_RYGH_GS_SELECT rst = new MES_SY_RYGH_GS_SELECT();
            List<MES_SY_RYGH_GS> child_MES_SY_RYGH_GS = new List<MES_SY_RYGH_GS>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ISACTION",model.ISACTION),
                                       new SqlParameter("@LB",model.LB)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_GS, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_RYGH_GS child = new MES_SY_RYGH_GS();
                        child.RYGSDM = Convert.ToString(sdr["RYGSDM"]);
                        child.RYGSSM = Convert.ToString(sdr["RYGSSM"]);
                        child.RYGSREMARK = Convert.ToString(sdr["RYGSREMARK"]);
                        child.ISACTION = Convert.ToInt32(sdr["ISACTION"]);
                        child.GHWS = Convert.ToInt32(sdr["GHWS"]);
                        child_MES_SY_RYGH_GS.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_RYGH_GS_SELECT", "MES");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_RYGH_GS = child_MES_SY_RYGH_GS;
            return rst;
        }

        public MES_RETURN INSERT(MES_SY_RYGH model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYGSDM",model.RYGSDM),
                                       new SqlParameter("@RYGH",model.RYGH),
                                       new SqlParameter("@RYNAME",model.RYNAME),
                                       new SqlParameter("@CJRID",model.CJRID)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_RYGH_INSERT", "MES");
            }
            return rst;
        }
        public MES_SY_RYGH_SELECT SELECT(MES_SY_RYGH model)
        {
            MES_SY_RYGH_SELECT rst = new MES_SY_RYGH_SELECT();
            List<MES_SY_RYGH> child_MES_SY_RYGH = new List<MES_SY_RYGH>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RYGSDM",model.RYGSDM),
                                       new SqlParameter("@RYGH",model.RYGH),
                                       new SqlParameter("@RYNAME",model.RYNAME),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@RYSCGH",model.RYSCGH),
                                       new SqlParameter("@RYGHALL",model.RYGHALL)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_RYGH child = new MES_SY_RYGH();
                        child.RI = Convert.ToInt32(sdr["RI"]);
                        child.RYGSDM = Convert.ToString(sdr["RYGSDM"]);
                        child.RYGH = Convert.ToString(sdr["RYGH"]);
                        child.RYNAME = Convert.ToString(sdr["RYNAME"]);
                        child.RYSCGH = Convert.ToString(sdr["RYSCGH"]);
                        child_MES_SY_RYGH.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_RYGH_GS_SELECT", "MES");
            }
            rst.MES_RETURN = child_MES_RETURN;
            rst.MES_SY_RYGH = child_MES_SY_RYGH;
            return rst;
        }
        public MES_RETURN UPDATE(MES_SY_RYGH model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RI",model.RI),
                                       new SqlParameter("@RYNAME",model.RYNAME),
                                       new SqlParameter("@LB",model.LB),
                                       new SqlParameter("@XGRID",model.XGRID)
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
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_SY_RYGH_UPDATE", "MES");
            }
            return rst;
        }
    }
}
