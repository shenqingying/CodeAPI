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
    class BAT_SPECS : IBAT_SPECS
    {
        const string SQL_SELECT_ZY_Material = "MES_ZY_Material_SELECT";
        const string SQL_SELECT_LIST = "MES_DCCCBZ_SELECT_LIST";
        const string SQL_SELECT_DCCCBZ = "MES_DCCCBZ_SELECT";
        const string SQL_SELECT_DCDXN = "MES_DCDXN_SELECT";
        const string SQL_INSERT_DCCCBZ = "MES_DCCCBZ_INSERT";
        const string SQL_INSERT_DCDXN = "MES_DCDXN_INSERT";
        const string SQL_DELETE = "MES_BATSPECS_DELETE";
        const string SQL_DELETE_WITH_CHECK = "MES_BATSPECS_DELETE_WITH_CHECK";
        const string SQL_UPDATE_CHECK = "MES_BATSPECS_UPDATE_CHECK";

        public MES_DCBZ_SELECT SELECT_SPECS(MES_DCBZ model)
        {
            MES_DCBZ_SELECT rst = new MES_DCBZ_SELECT();
            rst.MES_DCBZ = new List<MES_DCBZ>();
            MES_DCBZ child_MES_DCBZ = new MES_DCBZ();
            child_MES_DCBZ.MES_DCCCBZ = new List<MES_DCCCBZ>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCXHRI",model.DCXHRI)
                                   };
                using (SqlDataReader sdr_son = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_DCCCBZ, parms))
                {
                    while (sdr_son.Read())
                    {
                        MES_DCCCBZ child = new MES_DCCCBZ();
                        child.RI = Convert.ToInt32(sdr_son["RI"]);
                        child.DCBZ = Convert.ToString(sdr_son["DCBZ"]);
                        child.DCBZRI = Convert.ToInt32(sdr_son["DCBZRI"]);
                        child.DCMAX = Convert.ToString(sdr_son["DCMAX"]);
                        child.DCMIN = Convert.ToString(sdr_son["DCMIN"]);
                        child_MES_DCBZ.DCXH = Convert.ToString(sdr_son["DCXH"]);
                        child_MES_DCBZ.DCXHRI = Convert.ToInt32(sdr_son["DCXHRI"]);
                        child_MES_DCBZ.MES_DCCCBZ.Add(child);
                    }

                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "SELECT_SPECS SELECTED";
                rst.MES_DCBZ.Add(child_MES_DCBZ);
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }

        public MES_DCBZ_SELECT SELECT_PERFOR(MES_DCBZ model)
        {
            MES_DCBZ_SELECT rst = new MES_DCBZ_SELECT();
            rst.MES_DCBZ = new List<MES_DCBZ>();
            MES_DCBZ child_MES_DCBZ = new MES_DCBZ();
            child_MES_DCBZ.MES_DCDXN = new List<MES_DCDXN>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCXHRI",model.DCXHRI)
                                   };
                using (SqlDataReader sdr_son = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_DCDXN, parms))
                {
                    while (sdr_son.Read())
                    {
                        MES_DCDXN child = new MES_DCDXN();
                        child.RI = Convert.ToInt32(sdr_son["RI"]);
                        child.DCBZ = Convert.ToString(sdr_son["DCBZ"]);
                        child.DCBZRI = Convert.ToInt32(sdr_son["DCBZRI"]);
                        child.DCFDFS = Convert.ToString(sdr_son["DCFDFS"]);
                        child.DCMAD = Convert.ToString(sdr_son["DCMAD"]);
                        child.SDLX = Convert.ToString(sdr_son["SDLX"]);
                        child.SDLXRI = Convert.ToString(sdr_son["SDLXRI"]);
                        child_MES_DCBZ.DCXH = Convert.ToString(sdr_son["DCXH"]);
                        child_MES_DCBZ.DCXHRI = Convert.ToInt32(sdr_son["DCXHRI"]);
                        child_MES_DCBZ.MES_DCDXN.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "SELECT_PERFOR SELECTED";
                rst.MES_DCBZ.Add(child_MES_DCBZ);
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }

        public MES_DCBZ_SELECT SELECT_LIST(MES_DCBZ model)
        {
            MES_DCBZ_SELECT rst = new MES_DCBZ_SELECT();
            List<MES_DCBZ> child_MES_DCBZ = new List<MES_DCBZ>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@mtSpec",model.DCXH),
                                       new SqlParameter("@materialID",model.DCXHRI),
                                       new SqlParameter("@typeID",model.RI)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_ZY_Material, parms))
                {
                    while (sdr.Read())
                    {
                        MES_DCBZ child = new MES_DCBZ();
                        child.DCXH = Convert.ToString(sdr["mtSpec"]);
                        child.DCXHRI = Convert.ToInt32(sdr["materialID"]);
                        child_MES_DCBZ.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "SELECT_LIST SELECTED";
                rst.MES_DCBZ = child_MES_DCBZ;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }

        public MES_DCBZ_SELECT SELECT_LIST_LEFT(string DCXH)
        {
            MES_DCBZ_SELECT rst = new MES_DCBZ_SELECT();
            List<MES_DCBZ> child_MES_DCBZ = new List<MES_DCBZ>();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DCXH",DCXH)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LIST, parms))
                {
                    while (sdr.Read())
                    {
                        MES_DCBZ child = new MES_DCBZ();
                        child.DCXH = Convert.ToString(sdr["DCXH"]);
                        child_MES_DCBZ.Add(child);
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "SELECT_LIST_LEFT SELECTED";
                rst.MES_DCBZ = child_MES_DCBZ;
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }

        public MES_RETURN INSERT_SPECS(MES_DCBZ model)
        {
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            child_MES_RETURN.MESSAGE = "";
            try
            {
                for (int i = 0; i < model.MES_DCCCBZ.Count; i++)
                {
                    SqlParameter[] parms = {
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCXHRI",model.DCXHRI),
                                       new SqlParameter("@DCBZ",model.MES_DCCCBZ[i].DCBZ),
                                       new SqlParameter("@DCBZRI",model.MES_DCCCBZ[i].DCBZRI),
                                       new SqlParameter("@DCMAX",model.MES_DCCCBZ[i].DCMAX),
                                       new SqlParameter("@DCMIN",model.MES_DCCCBZ[i].DCMIN)
                                   };
                    using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_DCCCBZ, parms))
                    {
                        while (sdr.Read())
                        {
                            child_MES_RETURN.MESSAGE = child_MES_RETURN.MESSAGE + "INSERT" + Convert.ToString(sdr["RI"]);
                        }
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = child_MES_RETURN.MESSAGE + "INSERT_SPECS INSERTED";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return child_MES_RETURN;
        }

        public MES_RETURN INSERT_PERFOR(MES_DCBZ model)
        {
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            child_MES_RETURN.MESSAGE = "";
            try
            {
                for (int i = 0; i < model.MES_DCDXN.Count; i++)
                {

                    SqlParameter[] parms = {
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCXHRI",model.DCXHRI),
                                       new SqlParameter("@DCBZ",model.MES_DCDXN[i].DCBZ),
                                       new SqlParameter("@DCBZRI",model.MES_DCDXN[i].DCBZRI),
                                       new SqlParameter("@DCFDFS",model.MES_DCDXN[i].DCFDFS),
                                       new SqlParameter("@DCMAD",model.MES_DCDXN[i].DCMAD),
                                       new SqlParameter("@SDLX",model.MES_DCDXN[i].SDLX),
                                       new SqlParameter("@SDLXRI",model.MES_DCDXN[i].SDLXRI),
                                   };
                    using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT_DCDXN, parms))
                    {
                        while (sdr.Read())
                        {
                            child_MES_RETURN.MESSAGE = child_MES_RETURN.MESSAGE + "INSERT" + Convert.ToString(sdr["RI"]);
                        }
                    }
                }
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = child_MES_RETURN.MESSAGE + "INSERT_PERFOR INSERTED";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return child_MES_RETURN;
        }

        public MES_RETURN DELETE(string DCXH)
        {
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DCXH",DCXH),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE, parms))
                {
                    while (sdr.Read())
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
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return child_MES_RETURN;
        }

        public MES_RETURN DELETE_WITH_CHECK(string DCXH)
        {
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DCXH",DCXH),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE_WITH_CHECK, parms))
                {
                    while (sdr.Read())
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
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return child_MES_RETURN;
        }

        public MES_RETURN UPDATE_SPECS_CHECK(MES_DCBZ model)
        {
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            child_MES_RETURN.MESSAGE = "";
            try
            {
                for (int i = 0; i < model.MES_DCCCBZ.Count; i++)
                {
                    SqlParameter[] parms = {
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCBZ",model.MES_DCCCBZ[i].DCBZ),
                                       new SqlParameter("@DCMAX",model.MES_DCCCBZ[i].DCMAX),
                                       new SqlParameter("@DCMIN",model.MES_DCCCBZ[i].DCMIN)
                                   };
                    using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_CHECK, parms))
                    {
                        while (sdr.Read())
                        {
                            child_MES_RETURN.TYPE = Convert.ToString(sdr["TYPE"]);
                            child_MES_RETURN.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                        }
                    }
                    if (child_MES_RETURN.TYPE == "E") break;
                }
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return child_MES_RETURN;
        }
    }
}
