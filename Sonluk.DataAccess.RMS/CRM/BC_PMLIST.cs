using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.CRM
{
    public class BC_PMLIST : IBC_PMLIST
    {
        private const string SQL_Create = "CRM_BC_PMLIST_Create";
        private const string SQL_Select = "CRM_BC_PMLIST_Select";
        private const string SQL_SelectGD = "CRM_BC_PMLIST_SelectGD";
        private const string SQL_SelectByGD = "CRM_BC_PMLIST_SelectByGD";
        private const string SQL_SelectByGDandParam = "CRM_BC_PMLIST_SelectByGDandParam";
        private const string SQL_SelectByDXM = "CRM_BC_PMLIST_SelectByDXM";
        private const string SQL_SelectOtherBigByDXM = "CRM_BC_PMLIST_SelectOtherBigByDXM";
        private const string SQL_Delete = "CRM_BC_PMLIST_Delete";
        private const string SQL_DeleteByGD = "CRM_BC_PMLIST_DeleteByGD";
        private const string SQL_UpdatePM = "CRM_BC_PMLIST_UpdatePM";

        private const string SQL_SelectMATNRbyCHARGandPM = "CRM_BC_PMLIST_SelectMATNRbyCHARGandPM";
        private const string SQL_SelectKHbyMCP = "CRM_BC_PMLIST_SelectKHbyMCP";    //MCP = MATNR + CHARG + PM
        private const string SQL_SelectKHbyDXM = "CRM_BC_PMLIST_SelectKHbyDXM";
        private const string SQL_SelectKHbyNHM = "CRM_BC_PMLIST_SelectKHbyNHM";

        private const string SQL_WLM_Create = "CRM_BC_WLM_TEMP_Create";
        private const string SQL_WLM_Delete = "CRM_BC_WLM_TEMP_Delete";
        private const string SQL_WLM_Modify = "CRM_BC_WLM_TEMP_Modify";

        public int Create(CRM_BC_PMLIST model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PMTYPE", model.PMTYPE),
                                        new SqlParameter("@AUFNR", model.AUFNR),
                                        new SqlParameter("@MATNR", model.MATNR),
                                        new SqlParameter("@MAKTX", model.MAKTX),
                                        new SqlParameter("@CHARG", model.CHARG),
                                        new SqlParameter("@ZBON", model.ZBON),
                                        new SqlParameter("@ZPKS", model.ZPKS),
                                        new SqlParameter("@DXM", model.DXM),
                                        new SqlParameter("@TPM", model.TPM),
                                        new SqlParameter("@PM", model.PM),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@CJR", model.CJR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }


        public IList<CRM_BC_PMLIST> SelectByModel(CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@PMTYPE",model.PMTYPE),
                                       new SqlParameter("@AUFNR",model.AUFNR),
                                       new SqlParameter("@MATNR",model.MATNR),
                                       new SqlParameter("@MAKTX",model.MAKTX),
                                       new SqlParameter("@BEGIN_DATE",BEGIN_DATE),
                                       new SqlParameter("@END_DATE",END_DATE),
                                       new SqlParameter("@DXM",model.DXM),
                                       new SqlParameter("@TPM",model.TPM)
                                   };
            IList<CRM_BC_PMLIST> nodes = new List<CRM_BC_PMLIST>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Select, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToList(sdr));
                    }
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_BC_PMLISTList> SelectGD(CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@PMTYPE",model.PMTYPE),
                                       new SqlParameter("@AUFNR",model.AUFNR),
                                       new SqlParameter("@MATNR",model.MATNR),
                                       new SqlParameter("@MAKTX",model.MAKTX),
                                       new SqlParameter("@BEGIN_DATE",BEGIN_DATE),
                                       new SqlParameter("@END_DATE",END_DATE),
                                       new SqlParameter("@DXM",model.DXM),
                                       new SqlParameter("@TPM",model.TPM),
                                       new SqlParameter("@PM",model.PM)
                                   };
            IList<CRM_BC_PMLISTList> nodes = new List<CRM_BC_PMLISTList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SelectGD, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToGDList(sdr));
                    }
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_BC_PMLISTList> SelectByGD(string AUFNR)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@AUFNR",AUFNR)
                                   };
            IList<CRM_BC_PMLISTList> nodes = new List<CRM_BC_PMLISTList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SelectByGD, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToByGDList(sdr));
                    }
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_BC_PMLISTList> SelectByGDandParam(CRM_BC_PMLIST model, string BEGIN_DATE, string END_DATE)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@AUFNR",model.AUFNR),
                                       new SqlParameter("@MATNR",model.MATNR),
                                       new SqlParameter("@MAKTX",model.MAKTX),
                                       new SqlParameter("@BEGIN_DATE",BEGIN_DATE),
                                       new SqlParameter("@END_DATE",END_DATE),
                                       new SqlParameter("@DXM",model.DXM),
                                       new SqlParameter("@TPM",model.TPM)
                                   };
            IList<CRM_BC_PMLISTList> nodes = new List<CRM_BC_PMLISTList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SelectByGDandParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToByGDList(sdr));
                    }
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public CRM_BC_PMLISTList SelectByDXM(string DXM)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@DXM",DXM)
                                   };
            CRM_BC_PMLISTList node = new CRM_BC_PMLISTList();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SelectByDXM, parms))
                {
                    if (sdr.Read())
                    {
                        node = ReadDataToList2(sdr);
                    }
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return node;
        }

        public IList<CRM_BC_PMLISTList> SelectOtherBigByDXM(string DXM)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@DXM",DXM)
                                   };
            IList<CRM_BC_PMLISTList> nodes = new List<CRM_BC_PMLISTList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SelectOtherBigByDXM, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToList2(sdr));
                    }
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        public int Delete(int PMID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@PMID",PMID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }

        public int DeleteByGD(string AUFNR)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@AUFNR",AUFNR)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteByGD, parms);
        }

        public int UpdatePM()
        {
            SqlParameter[] parms = {
                                      
                                   };
            int error = new int();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UpdatePM, parms))
                {
                    if (sdr.Read())
                    {
                        error = ReadDataToInt(sdr);
                    }
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return error;
        }

        public IList<CRM_BC_PMLIST> SelectMATNRbyCHARGandPM(CRM_BC_PMLIST model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@CHARG",model.CHARG),
                                       new SqlParameter("@PM",model.PM)
                                   };
            IList<CRM_BC_PMLIST> nodes = new List<CRM_BC_PMLIST>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SelectMATNRbyCHARGandPM, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataMATNRToList(sdr));
                    }
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_BC_KH> SelectKHbyMCP(CRM_BC_PMLIST model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@MATNR",model.MATNR),
                                       new SqlParameter("@CHARG",model.CHARG),
                                       new SqlParameter("@PM",model.PM)
                                   };
            IList<CRM_BC_KH> nodes = new List<CRM_BC_KH>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SelectKHbyMCP, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObjectList(sdr));
                    }
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_BC_KH> SelectKHbyDXM(CRM_BC_PMLIST model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@DXM",model.DXM)
                                   };
            IList<CRM_BC_KH> nodes = new List<CRM_BC_KH>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SelectKHbyDXM, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObjectList(sdr));
                    }
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_BC_KH> SelectKHbyNHM(CRM_BC_CHMX model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@NHM",model.NHM)
                                   };
            IList<CRM_BC_KH> nodes = new List<CRM_BC_KH>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SelectKHbyNHM, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObjectList(sdr));
                    }
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public int Create_WLM(CRM_BC_WLM_TEMP model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@MANDT", model.MANDT),
                                        new SqlParameter("@TGWLM", model.TGWLM),
                                        new SqlParameter("@SRWLM", model.SRWLM),
                                        new SqlParameter("@CJRQ", model.CJRQ),
                                        new SqlParameter("@CJSJ", model.CJSJ),
                                        new SqlParameter("@CJR", model.CJR),
                                        new SqlParameter("@XGRQ", model.XGRQ),
                                        new SqlParameter("@XGSJ", model.XGSJ),
                                        new SqlParameter("@XGR", model.XGR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_WLM_Create, parms);
        }

        public int Delete_WLM()
        {
            SqlParameter[] parms = {
                                       
                                   };
            return Binning(CommandType.StoredProcedure, SQL_WLM_Delete, parms);
        }

        public int Modify_WLM()
        {
            SqlParameter[] parms = {
                                       
                                   };
            return Binning(CommandType.StoredProcedure, SQL_WLM_Modify, parms);
        }


        private CRM_BC_PMLIST ReadDataToList(SqlDataReader sdr)
        {
            CRM_BC_PMLIST node = new CRM_BC_PMLIST();
            node.PMID = Convert.ToInt32(sdr["PMID"]);
            node.AUFNR = Convert.ToString(sdr["AUFNR"]);
            node.MATNR = Convert.ToString(sdr["MATNR"]);
            node.MAKTX = Convert.ToString(sdr["MAKTX"]);
            node.CHARG = Convert.ToString(sdr["CHARG"]);
            node.DXM = Convert.ToString(sdr["DXM"]);
            node.TPM = Convert.ToString(sdr["TPM"]);
            node.ZBON = Convert.ToInt32(sdr["ZBON"]);
            node.ZPKS = Convert.ToInt32(sdr["ZPKS"]);
            node.PM = Convert.ToString(sdr["PM"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJRQ = Convert.ToDateTime(sdr["CJRQ"]).ToString("yyyy-MM-dd HH:mm");
            node.PMTYPE = Convert.ToInt32(sdr["PMTYPE"]);
            return node;
        }

        private CRM_BC_PMLISTList ReadDataToList2(SqlDataReader sdr)
        {
            CRM_BC_PMLISTList node = new CRM_BC_PMLISTList();
            node.PMID = Convert.ToInt32(sdr["PMID"]);
            node.AUFNR = Convert.ToString(sdr["AUFNR"]);
            node.MATNR = Convert.ToString(sdr["MATNR"]);
            node.MAKTX = Convert.ToString(sdr["MAKTX"]);
            node.CHARG = Convert.ToString(sdr["CHARG"]);
            node.DXM = Convert.ToString(sdr["DXM"]);
            node.TPM = Convert.ToString(sdr["TPM"]);
            node.ZBON = Convert.ToInt32(sdr["ZBON"]);
            node.ZPKS = Convert.ToInt32(sdr["ZPKS"]);
            node.PM = Convert.ToString(sdr["PM"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJRQ = Convert.ToDateTime(sdr["CJRQ"]).ToString("yyyy-MM-dd HH:mm");
            node.PMTYPE = Convert.ToInt32(sdr["PMTYPE"]);
            return node;
        }

        private CRM_BC_PMLISTList ReadDataToGDList(SqlDataReader sdr)
        {
            CRM_BC_PMLISTList node = new CRM_BC_PMLISTList();
            node.AUFNR = Convert.ToString(sdr["AUFNR"]);
            node.MATNR = Convert.ToString(sdr["MATNR"]);
            node.MAKTX = Convert.ToString(sdr["MAKTX"]);
            node.CHARG = Convert.ToString(sdr["CHARG"]);
            node.ZBON = Convert.ToInt32(sdr["ZBON"]);
            node.ZPKS = Convert.ToInt32(sdr["ZPKS"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.SUOSHU = Convert.ToInt32(sdr["SUOSHU"]);
            return node;
        }

        private CRM_BC_PMLISTList ReadDataToByGDList(SqlDataReader sdr)
        {
            CRM_BC_PMLISTList node = new CRM_BC_PMLISTList();
            node.PMID = Convert.ToInt32(sdr["PMID"]);
            node.AUFNR = Convert.ToString(sdr["AUFNR"]);
            node.MATNR = Convert.ToString(sdr["MATNR"]);
            node.MAKTX = Convert.ToString(sdr["MAKTX"]);
            node.CHARG = Convert.ToString(sdr["CHARG"]);
            node.DXM = Convert.ToString(sdr["DXM"]);
            node.TPM = Convert.ToString(sdr["TPM"]);
            node.ZBON = Convert.ToInt32(sdr["ZBON"]);
            node.ZPKS = Convert.ToInt32(sdr["ZPKS"]);
            node.PM = Convert.ToString(sdr["PM"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJRQ = Convert.ToDateTime(sdr["CJRQ"]).ToString("yyyy-MM-dd HH:mm");
            node.SUOSHU = Convert.ToInt32(sdr["SUOSHU"]);
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            return node;
        }

        private CRM_BC_PMLIST ReadDataMATNRToList(SqlDataReader sdr)
        {
            CRM_BC_PMLIST node = new CRM_BC_PMLIST();
            node.MATNR = Convert.ToString(sdr["MATNR"]);
            node.MAKTX = Convert.ToString(sdr["MAKTX"]);
            return node;
        }

        private CRM_BC_KH ReadDataToObjectList(SqlDataReader sdr)
        {
            CRM_BC_KH node = new CRM_BC_KH();
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.DXM = Convert.ToString(sdr["DXM"]);
            node.VBELN = Convert.ToString(sdr["VBELN"]);
            node.WADAT_IST = Convert.ToString(sdr["WADAT_IST"]);
            node.AREA = Convert.ToString(sdr["AREA"]);
            return node;
        }

        private int ReadDataToInt(SqlDataReader sdr)
        {
            int error = new int();
            error = Convert.ToInt32(sdr["error"]);
            return error;
        }

        private int Binning(CommandType type, string sql, SqlParameter[] parms)
        {
            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(type, sql, parms))
                {
                    if (sdr.Read())
                    {
                        ID = Convert.ToInt32(sdr["ID"]);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return ID;
        }


    }
}
