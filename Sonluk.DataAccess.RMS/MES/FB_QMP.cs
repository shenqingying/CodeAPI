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
    public class FB_QMP : IFB_QMP
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_FB_QMP_INSERT";
        const string SQL_INSERT_D = "MES_FB_QMP_D_INSERT";
        const string SQL_SELECT = "MES_FB_QMP_SELECT";
        const string SQL_SELECT_D = "MES_FB_QMP_D_SELECT";
        const string SQL_UPDATE = "MES_FB_QMP_UPDATE";
        const string SQL_INSERT_TM = "MES_FB_QMP_TM_INSERT";
        public MES_RETURN INSERT(DataTable dt, int LB)
        {
            MES_RETURN mr = new MES_RETURN();
            //try
            //{
            if (dt.Rows.Count > 0)
            {
                List<MES_FB_QMP> model_MES_FB_QMP = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MES_FB_QMP>>(Newtonsoft.Json.JsonConvert.SerializeObject(dt));
                for (int a = 0; a < model_MES_FB_QMP.Count; a++)
                {
                    SqlParameter[] parms = { 
                                       new SqlParameter("@Pid",model_MES_FB_QMP[a].Pid),
                                       new SqlParameter("@Pwcid",model_MES_FB_QMP[a].Pwcid),
                                       new SqlParameter("@Plot",model_MES_FB_QMP[a].Plot),
                                       new SqlParameter("@PQTY",model_MES_FB_QMP[a].PQTY),
                                       new SqlParameter("@PRem",model_MES_FB_QMP[a].PRem),
                                       new SqlParameter("@PUn",model_MES_FB_QMP[a].PUn),
                                       new SqlParameter("@PDesc",model_MES_FB_QMP[a].PDesc),
                                       new SqlParameter("@ExcelServerRCID",model_MES_FB_QMP[a].ExcelServerRCID),
                                       new SqlParameter("@ExcelServerRN",model_MES_FB_QMP[a].ExcelServerRN),
                                       new SqlParameter("@ExcelServerCN",model_MES_FB_QMP[a].ExcelServerCN),
                                       new SqlParameter("@ExcelServerRC1",model_MES_FB_QMP[a].ExcelServerRC1),
                                       new SqlParameter("@ExcelServerWIID",model_MES_FB_QMP[a].ExcelServerWIID),
                                       new SqlParameter("@ExcelServerRTID",model_MES_FB_QMP[a].ExcelServerRTID),
                                       new SqlParameter("@ExcelServerCHG",model_MES_FB_QMP[a].ExcelServerCHG),
                                       new SqlParameter("@Cre",model_MES_FB_QMP[a].Cre),
                                       new SqlParameter("@CDate",model_MES_FB_QMP[a].CDate),
                                       new SqlParameter("@ID",model_MES_FB_QMP[a].ID),
                                       new SqlParameter("@Type",model_MES_FB_QMP[a].Type),
                                       new SqlParameter("@PCode",model_MES_FB_QMP[a].PCode),
                                       new SqlParameter("@PDate",model_MES_FB_QMP[a].PDate),
                                       new SqlParameter("@DMark",model_MES_FB_QMP[a].DMark),
                                       new SqlParameter("@V",model_MES_FB_QMP[a].V),
                                       new SqlParameter("@LASTXGTIME",model_MES_FB_QMP[a].LASTXGTIME),
                                       new SqlParameter("@LB",LB),
                                   };

                    using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                    {
                        while (sdr.Read())
                        {
                            mr.TYPE = Convert.ToString(sdr["TYPE"]);
                            mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                        }
                    }
                    if (mr.TYPE != "S")
                    {
                        return mr;
                    }
                }
            }
            else
            {
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            //}
            //catch (Exception e)
            //{
            //    mr.TYPE = "E";
            //    mr.MESSAGE = e.ToString();
            //    SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_FB_QMP_INSERT", "MES");
            //}
            return mr;
        }
        public MES_RETURN INSERT_D(DataTable dt)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<MES_FB_QMP_D> model_MES_FB_QMP_D = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MES_FB_QMP_D>>(Newtonsoft.Json.JsonConvert.SerializeObject(dt));
                    for (int a = 0; a < model_MES_FB_QMP_D.Count; a++)
                    {
                        SqlParameter[] parms = { 
                                       new SqlParameter("@Mid",model_MES_FB_QMP_D[a].Mid),
                                       new SqlParameter("@Mwcid",model_MES_FB_QMP_D[a].Mwcid),
                                       new SqlParameter("@Mlot",model_MES_FB_QMP_D[a].Mlot),
                                       new SqlParameter("@MQTY",model_MES_FB_QMP_D[a].MQTY),
                                       new SqlParameter("@MRem",model_MES_FB_QMP_D[a].MRem),
                                       new SqlParameter("@MUn",model_MES_FB_QMP_D[a].MUn),
                                       new SqlParameter("@MDesc",model_MES_FB_QMP_D[a].MDesc),
                                       new SqlParameter("@ExcelServerRCID",model_MES_FB_QMP_D[a].ExcelServerRCID),
                                       new SqlParameter("@ExcelServerRN",model_MES_FB_QMP_D[a].ExcelServerRN),
                                       new SqlParameter("@ExcelServerCN",model_MES_FB_QMP_D[a].ExcelServerCN),
                                       new SqlParameter("@ExcelServerRC1",model_MES_FB_QMP_D[a].ExcelServerRC1),
                                       new SqlParameter("@ExcelServerWIID",model_MES_FB_QMP_D[a].ExcelServerWIID),
                                       new SqlParameter("@ExcelServerRTID",model_MES_FB_QMP_D[a].ExcelServerRTID),
                                       new SqlParameter("@ExcelServerCHG",model_MES_FB_QMP_D[a].ExcelServerCHG),
                                       new SqlParameter("@MCode",model_MES_FB_QMP_D[a].MCode),
                                       new SqlParameter("@Type",model_MES_FB_QMP_D[a].Type),
                                       new SqlParameter("@MDate",model_MES_FB_QMP_D[a].MDate),
                                       new SqlParameter("@MDate2",model_MES_FB_QMP_D[a].MDate2),
                                       new SqlParameter("@分类",model_MES_FB_QMP_D[a].分类),
                                       new SqlParameter("@分类描述",model_MES_FB_QMP_D[a].分类描述),
                                       new SqlParameter("@时间编码",model_MES_FB_QMP_D[a].时间编码),
                                       new SqlParameter("@幢号",model_MES_FB_QMP_D[a].幢号),
                                       new SqlParameter("@成品日",model_MES_FB_QMP_D[a].成品日),
                                       new SqlParameter("@托号",model_MES_FB_QMP_D[a].托号)
                                   };

                        using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_D, parms))
                        {
                            while (sdr.Read())
                            {
                                mr.TYPE = Convert.ToString(sdr["TYPE"]);
                                mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                            }
                        }
                        if (mr.TYPE != "S")
                        {
                            return mr;
                        }
                    }
                }
                else
                {
                    mr.TYPE = "S";
                    mr.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_FB_QMP_INSERT", "MES");
            }
            return mr;
        }
        public MES_RETURN INSERT_ES_REPCASE(DataTable dt)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<MES_FB_QMP_D> model_MES_FB_QMP_D = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MES_FB_QMP_D>>(Newtonsoft.Json.JsonConvert.SerializeObject(dt));
                    for (int a = 0; a < model_MES_FB_QMP_D.Count; a++)
                    {
                        SqlParameter[] parms = { 
                                       new SqlParameter("@Mid",model_MES_FB_QMP_D[a].Mid),
                                       new SqlParameter("@Mwcid",model_MES_FB_QMP_D[a].Mwcid),
                                       new SqlParameter("@Mlot",model_MES_FB_QMP_D[a].Mlot),
                                       new SqlParameter("@MQTY",model_MES_FB_QMP_D[a].MQTY),
                                       new SqlParameter("@MRem",model_MES_FB_QMP_D[a].MRem),
                                       new SqlParameter("@MUn",model_MES_FB_QMP_D[a].MUn),
                                       new SqlParameter("@MDesc",model_MES_FB_QMP_D[a].MDesc),
                                       new SqlParameter("@ExcelServerRCID",model_MES_FB_QMP_D[a].ExcelServerRCID),
                                       new SqlParameter("@ExcelServerRN",model_MES_FB_QMP_D[a].ExcelServerRN),
                                       new SqlParameter("@ExcelServerCN",model_MES_FB_QMP_D[a].ExcelServerCN),
                                       new SqlParameter("@ExcelServerRC1",model_MES_FB_QMP_D[a].ExcelServerRC1),
                                       new SqlParameter("@ExcelServerWIID",model_MES_FB_QMP_D[a].ExcelServerWIID),
                                       new SqlParameter("@ExcelServerRTID",model_MES_FB_QMP_D[a].ExcelServerRTID),
                                       new SqlParameter("@ExcelServerCHG",model_MES_FB_QMP_D[a].ExcelServerCHG),
                                       new SqlParameter("@MCode",model_MES_FB_QMP_D[a].MCode),
                                       new SqlParameter("@Type",model_MES_FB_QMP_D[a].Type),
                                       new SqlParameter("@MDate",model_MES_FB_QMP_D[a].MDate),
                                       new SqlParameter("@MDate2",model_MES_FB_QMP_D[a].MDate2),
                                       new SqlParameter("@分类",model_MES_FB_QMP_D[a].分类),
                                       new SqlParameter("@分类描述",model_MES_FB_QMP_D[a].分类描述),
                                       new SqlParameter("@时间编码",model_MES_FB_QMP_D[a].时间编码),
                                       new SqlParameter("@幢号",model_MES_FB_QMP_D[a].幢号),
                                       new SqlParameter("@成品日",model_MES_FB_QMP_D[a].成品日),
                                       new SqlParameter("@托号",model_MES_FB_QMP_D[a].托号)
                                   };

                        using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_D, parms))
                        {
                            while (sdr.Read())
                            {
                                mr.TYPE = Convert.ToString(sdr["TYPE"]);
                                mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                            }
                        }
                        if (mr.TYPE != "S")
                        {
                            return mr;
                        }
                    }
                }
                else
                {
                    mr.TYPE = "S";
                    mr.MESSAGE = "";
                }
            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_FB_QMP_INSERT", "MES");
            }
            return mr;
        }

        public MES_FB_QMP_SELECT SELECT(MES_FB_QMP model, int LB)
        {
            MES_FB_QMP_SELECT rst = new MES_FB_QMP_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@LB",LB)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_FB_QMP_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_FB_QMP_D_SELECT SELECT_D(MES_FB_QMP_D model, int LB)
        {
            MES_FB_QMP_D_SELECT rst = new MES_FB_QMP_D_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                       new SqlParameter("@LB",LB),
                                       new SqlParameter("@ExcelServerRCID",model.ExcelServerRCID)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT_D, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "MES_FB_QMP_D_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
        public MES_RETURN UPDATE(MES_FB_QMP model, int LB)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@ExcelServerRCID",model.ExcelServerRCID),
                                       new SqlParameter("@LB",LB)
                                   };

            using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms))
            {
                while (sdr.Read())
                {
                    mr.TYPE = Convert.ToString(sdr["TYPE"]);
                    mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                }
            }
            return mr;
        }
        public MES_RETURN INSERT_TM(MES_FB_QMP_TM model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = { 
                                       new SqlParameter("@ExcelServerRCID",model.ExcelServerRCID),
                                       new SqlParameter("@TM",model.TM)
                                   };

            using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_TM, parms))
            {
                while (sdr.Read())
                {
                    mr.TYPE = Convert.ToString(sdr["TYPE"]);
                    mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                }
            }
            return mr;
        }
    }
}
