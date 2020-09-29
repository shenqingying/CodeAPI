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
    public class BC_CHTT : IBC_CHTT
    {
        private const string SQL_Modify = "CRM_BC_CHTT_Modify";
        private const string SQL_SelectTTIDbyDXM = "CRM_BC_CHTT_SelectTTIDbyDXM";
        private const string SQL_SelectKUNAGbyTTID = "CRM_BC_CHTT_SelectKUNAGbyTTID";
        private const string SQL_SelectCHMXbyDXM = "CRM_BC_CHTT_SelectCHMXbyDXM";
        private const string SQL_ReadMXbyParam = "CRM_BC_CHTT_ReadMXbyParam";
        private const string SQL_ReadDXMbyTPM = "CRM_BC_CHTT_ReadDXMbyTPM";

        public int Modify()
        {
            SqlParameter[] parms = {
                                      
                                   };
            int error = new int();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Modify, parms))
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


        public int SelectMXIDbyDXM(string DXM)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@DXM", DXM)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_SelectTTIDbyDXM, parms);
        }

        public string SelectKUNAGbyTTID(int PMCHTTID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@PMCHTTID", PMCHTTID)
                                   };
            string KUNAG = "";
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SelectKUNAGbyTTID, parms))
                {
                    if (sdr.Read())
                    {
                        KUNAG = ReadDataKUNAGToInt(sdr);
                    }
                }

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return KUNAG;
        }

        public IList<CRM_BC_CHMX> SelectCHMXbyDXM(string DXM,string TPM)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@DXM", DXM),
                                        new SqlParameter("@TPM", TPM)

                                   };
            IList<CRM_BC_CHMX> nodes = new List<CRM_BC_CHMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SelectCHMXbyDXM, parms))
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

        public IList<CRM_BC_CHMX> ReadMXbyParam(CRM_BC_CHMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@VBELN", model.VBELN),
                                        new SqlParameter("@POSNR", model.POSNR),
                                        new SqlParameter("@TPM", model.TPM),
                                        new SqlParameter("@DXM", model.DXM),
                                        new SqlParameter("@NHM", model.NHM),
                                        new SqlParameter("@KUNAG", model.KUNAG)
                                        
                                   };
            IList<CRM_BC_CHMX> nodes = new List<CRM_BC_CHMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadMXbyParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToMXList2(sdr));
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_BC_CHMX> ReadDXMbyTPM(string TPM)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TPM", TPM)

                                   };
            IList<CRM_BC_CHMX> nodes = new List<CRM_BC_CHMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadDXMbyTPM, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToMXList1(sdr));
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        private int ReadDataToInt(SqlDataReader sdr)
        {
            int error = new int();
            error = Convert.ToInt32(sdr["error"]);
            return error;
        }

        private string ReadDataKUNAGToInt(SqlDataReader sdr)
        {
            string error = "";
            error = Convert.ToString(sdr["KUNAG"]);
            return error;
        }

        private CRM_BC_CHTT ReadDataToList(SqlDataReader sdr)
        {
            CRM_BC_CHTT node = new CRM_BC_CHTT();
            node.PMCHTTID = Convert.ToInt32(sdr["PMCHTTID"]);
            node.VBELN = Convert.ToString(sdr["VBELN"]);
            node.WERKS = Convert.ToString(sdr["WERKS"]);
            node.POSNR = Convert.ToString(sdr["POSNR"]);
            node.MATNR = Convert.ToString(sdr["MATNR"]);
            node.KUNAG = Convert.ToString(sdr["KUNAG"]);
            node.LGORT = Convert.ToString(sdr["LGORT"]);
            node.WADAT_IST = Convert.ToString(sdr["WADAT_IST"]);
            node.XGR = Convert.ToString(sdr["XGR"]);
            return node;
        }

        private CRM_BC_CHMX ReadDataToMXList(SqlDataReader sdr)
        {
            CRM_BC_CHMX node = new CRM_BC_CHMX();
            node.PMCHMXID = Convert.ToInt32(sdr["PMCHMXID"]);
            node.PMCHTTID = Convert.ToInt32(sdr["PMCHTTID"]);
            node.VBELN = Convert.ToString(sdr["VBELN"]);
            node.POSNR = Convert.ToString(sdr["POSNR"]);
            node.TPM = Convert.ToString(sdr["TPM"]);
            node.DXM = Convert.ToString(sdr["DXM"]);
            node.NHM = Convert.ToString(sdr["NHM"]);
            node.CHARG = Convert.ToString(sdr["CHARG"]);
            node.LWEDT = Convert.ToString(sdr["LWEDT"]);
            return node;
        }

        private CRM_BC_CHMX ReadDataToMXList2(SqlDataReader sdr)
        {
            CRM_BC_CHMX node = new CRM_BC_CHMX();
            node.PMCHMXID = Convert.ToInt32(sdr["PMCHMXID"]);
            node.PMCHTTID = Convert.ToInt32(sdr["PMCHTTID"]);
            node.VBELN = Convert.ToString(sdr["VBELN"]);
            node.POSNR = Convert.ToString(sdr["POSNR"]);
            node.TPM = Convert.ToString(sdr["TPM"]);
            node.DXM = Convert.ToString(sdr["DXM"]);
            node.NHM = Convert.ToString(sdr["NHM"]);
            node.CHARG = Convert.ToString(sdr["CHARG"]);
            node.LWEDT = Convert.ToString(sdr["LWEDT"]);
            node.MATNR = Convert.ToString(sdr["MATNR"]);
            return node;
        }

        private CRM_BC_CHMX ReadDataToMXList1(SqlDataReader sdr)
        {
            CRM_BC_CHMX node = new CRM_BC_CHMX();
            node.DXM = Convert.ToString(sdr["DXM"]);
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
