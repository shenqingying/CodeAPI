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
    public class BC_FXCH : IBC_FXCH
    {
        private const string SQL_TTCreate = "CRM_BC_FXCHTT_Create";
        private const string SQL_TTDelete = "CRM_BC_FXCHTT_Delete";
        private const string SQL_ReadTTbyParam = "CRM_BC_FXCH_ReadTTbyParam";
        private const string SQL_ReadTTbyTTID = "CRM_BC_FXCH_ReadTTbyTTID";
        private const string SQL_Report = "CRM_BC_FXCH_Report";



        private const string SQL_MXCreate = "CRM_BC_FXCHMX_Create";
        private const string SQL_MXDelete = "CRM_BC_FXCHMX_Delete";
        private const string SQL_MXDeleteByDXM = "CRM_BC_FXCHMX_DeleteByDXM";
        private const string SQL_ReadMXbyTTID = "CRM_BC_FXCH_ReadMXbyTTID";
        private const string SQL_ReadMXbyParam = "CRM_BC_FXCH_ReadMXbyParam";
        private const string SQL_ReadCountByDXMorTPM = "CRM_BC_FXCH_ReadCountByDXM";

        private const string SQL_Verify_IfHaveKHRight = "CRM_BC_FXCH_Verify_IfHaveKHRight";
        private const string SQL_Verify_IfHaveCHRight = "CRM_BC_FXCH_Verify_IfHaveCHRight";

        public int TTCreate(CRM_BC_FXCHTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@FXCHTTID", model.FXCHTTID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@SDFID", model.SDFID),
                                        new SqlParameter("@KUNAG", model.KUNAG),
                                        new SqlParameter("@NAMEG", model.NAMEG),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@VBELN", model.VBELN),
                                        new SqlParameter("@ZZKGGKH", model.ZZKGGKH),
                                        new SqlParameter("@CJR", model.CJR)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_TTCreate, parms);
        }

        public int MXCreate(CRM_BC_FXCHMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@FXCHMXID", model.FXCHMXID),
                                        new SqlParameter("@FXCHTTID", model.FXCHTTID),
                                        new SqlParameter("@VBELN", model.VBELN),
                                        new SqlParameter("@POSNR", model.POSNR),
                                        new SqlParameter("@TPM", model.TPM),
                                        new SqlParameter("@DXM", model.DXM),
                                        new SqlParameter("@NHM", model.NHM),
                                        new SqlParameter("@CHARG", model.CHARG),
                                        new SqlParameter("@MATNR", model.MATNR),
                                        new SqlParameter("@MAKTX", model.MAKTX),
                                        new SqlParameter("@LWEDT", model.LWEDT)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_MXCreate, parms);
        }

        public int TTDelete(int FXCHTTID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@FXCHTTID", FXCHTTID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_TTDelete, parms);
        }

        public int MXDelete(int FXCHMXID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@FXCHMXID", FXCHMXID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_MXDelete, parms);
        }

        public int MXDeleteByDXM(string DXM)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@DXM", DXM)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_MXDeleteByDXM, parms);
        }

        public IList<CRM_BC_FXCHTTList> ReadTTbyParam(CRM_BC_FXCHParam model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@DXM", model.DXM),
                                        new SqlParameter("@MC", model.MC),
                                        new SqlParameter("@CRMID", model.CRMID),
                                        new SqlParameter("@STAFFID", model.STAFFID)

                                   };
            IList<CRM_BC_FXCHTTList> nodes = new List<CRM_BC_FXCHTTList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadTTbyParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToTTListPlus(sdr));
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public CRM_BC_FXCHTTList ReadTTbyTTID(int FXCHTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@FXCHTTID", FXCHTTID)

                                   };
            CRM_BC_FXCHTTList node = new CRM_BC_FXCHTTList();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadTTbyTTID, parms))
                {
                    if (sdr.Read())
                    {
                        node = ReadDataToTTList(sdr);
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return node;
        }

        public IList<CRM_BC_FXCHTTList> Report(CRM_BC_FXCHParam model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@Barcode", model.Barcode)

                                   };
            IList<CRM_BC_FXCHTTList> node = new List<CRM_BC_FXCHTTList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report, parms))
                {
                    while (sdr.Read())
                    {
                        node.Add(ReadDataToTTList(sdr));
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return node;
        }

        public IList<CRM_BC_FXCHMX> ReadMXbyTTID(int FXCHTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@FXCHTTID", FXCHTTID)

                                   };
            IList<CRM_BC_FXCHMX> nodes = new List<CRM_BC_FXCHMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadMXbyTTID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToMXList_DXM(sdr));
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_BC_FXCHMX> ReadMXbyParam(CRM_BC_FXCHMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@FXCHTTID", model.FXCHTTID),
                                        new SqlParameter("@FXCHMXID", model.FXCHMXID),
                                        new SqlParameter("@TPM", model.TPM),
                                        new SqlParameter("@DXM", model.DXM),
                                        new SqlParameter("@NHM", model.NHM),
                                        new SqlParameter("@CHARG", model.CHARG),
                                        new SqlParameter("@VBELN", model.VBELN),
                                        new SqlParameter("@POSNR", model.POSNR),
                                        new SqlParameter("@MATNR", model.MATNR)

                                   };
            IList<CRM_BC_FXCHMX> nodes = new List<CRM_BC_FXCHMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadMXbyParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToMXList(sdr));
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

       

        public int ReadCountByDXM(string DXM,string TPM)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@DXM", DXM),
                                       new SqlParameter("@TPM", TPM)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_ReadCountByDXMorTPM, parms);
        }

        public int Verify_IfHaveKHRight(int STAFFID, string CRMID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID", STAFFID),
                                       new SqlParameter("@CRMID", CRMID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Verify_IfHaveKHRight, parms);
        }

        public int Verify_IfHaveCHRight(int STAFFID, string DXM,string TPM)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID", STAFFID),
                                       new SqlParameter("@DXM", DXM),
                                       new SqlParameter("@TPM", TPM)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Verify_IfHaveCHRight, parms);
        }








        private CRM_BC_FXCHTTList ReadDataToTTList(SqlDataReader sdr)
        {
            CRM_BC_FXCHTTList node = new CRM_BC_FXCHTTList();
            node.FXCHTTID = Convert.ToInt32(sdr["FXCHTTID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.SDFID = Convert.ToInt32(sdr["SDFID"]);
            node.SDF_MC = Convert.ToString(sdr["SDF_MC"]);
            node.KUNAG = Convert.ToString(sdr["KUNAG"]);
            node.NAMEG = Convert.ToString(sdr["NAMEG"]);
            node.ZZKGGKH = Convert.ToString(sdr["ZZKGGKH"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJRQ = Convert.ToDateTime(sdr["CJRQ"]).ToString("yyyy-MM-dd HH:mm:ss");

            return node;
        }

        private CRM_BC_FXCHTTList ReadDataToTTListPlus(SqlDataReader sdr)
        {
            CRM_BC_FXCHTTList node = new CRM_BC_FXCHTTList();
            node.FXCHTTID = Convert.ToInt32(sdr["FXCHTTID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.SDFID = Convert.ToInt32(sdr["SDFID"]);
            node.SDF_MC = Convert.ToString(sdr["SDF_MC"]);
            node.KUNAG = Convert.ToString(sdr["KUNAG"]);
            node.NAMEG = Convert.ToString(sdr["NAMEG"]);
            node.ZZKGGKH = Convert.ToString(sdr["ZZKGGKH"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJRQ = Convert.ToDateTime(sdr["CJRQ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.MXcount = Convert.ToInt32(sdr["MXcount"]);


            return node;
        }

        private CRM_BC_FXCHMX ReadDataToMXList_DXM(SqlDataReader sdr)
        {
            CRM_BC_FXCHMX node = new CRM_BC_FXCHMX();
            //node.FXCHMXID = Convert.ToInt32(sdr["FXCHMXID"]);
            node.FXCHTTID = Convert.ToInt32(sdr["FXCHTTID"]);
            node.TPM = Convert.ToString(sdr["TPM"]);
            node.DXM = Convert.ToString(sdr["DXM"]);
            //node.NHM = Convert.ToString(sdr["NHM"]);
            node.CHARG = Convert.ToString(sdr["CHARG"]);
            node.LWEDT = Convert.ToString(sdr["LWEDT"]);

            return node;
        }

        private CRM_BC_FXCHMX ReadDataToMXList(SqlDataReader sdr)
        {
            CRM_BC_FXCHMX node = new CRM_BC_FXCHMX();
            node.FXCHMXID = Convert.ToInt32(sdr["FXCHMXID"]);
            node.FXCHTTID = Convert.ToInt32(sdr["FXCHTTID"]);
            node.VBELN = Convert.ToString(sdr["VBELN"]);
            node.POSNR = Convert.ToString(sdr["POSNR"]);
            node.TPM = Convert.ToString(sdr["TPM"]);
            node.DXM = Convert.ToString(sdr["DXM"]);
            node.NHM = Convert.ToString(sdr["NHM"]);
            node.CHARG = Convert.ToString(sdr["CHARG"]);
            node.LWEDT = Convert.ToString(sdr["LWEDT"]);
            node.MATNR = Convert.ToString(sdr["MATNR"]);
            node.MAKTX = Convert.ToString(sdr["MAKTX"]);

            return node;
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
