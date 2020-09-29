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
    public class BC_CHTT_FAKE : IBC_CHTT_FAKE
    {
        private const string SQL_TTCreate = "CRM_BC_CHTT_FAKE_Create";
        private const string SQL_MXCreate = "CRM_BC_CHMX_FAKE_Create";
        private const string SQL_TTMXDelete = "CRM_BC_TTMX_FAKE_Delete";

        public int TTCreate(CRM_BC_CHTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@VBELN", model.VBELN),
                                        new SqlParameter("@WERKS", model.WERKS),
                                        new SqlParameter("@POSNR", model.POSNR),
                                        new SqlParameter("@MATNR", model.MATNR),
                                        new SqlParameter("@KUNAG", model.KUNAG),
                                        new SqlParameter("@LGORT", model.LGORT),
                                        new SqlParameter("@WADAT_IST", model.WADAT_IST),
                                        new SqlParameter("@XGR", model.XGR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_TTCreate, parms);
        }

        public int MXCreate(CRM_BC_CHMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@VBELN", model.VBELN),
                                        new SqlParameter("@POSNR", model.POSNR),
                                        new SqlParameter("@TPM", model.TPM),
                                        new SqlParameter("@DXM", model.DXM),
                                        new SqlParameter("@NHM", model.NHM),
                                        new SqlParameter("@CHARG", model.CHARG),
                                        new SqlParameter("@LWEDT", model.LWEDT),
                                        new SqlParameter("@QXBS", model.QXBS)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_MXCreate, parms);
        }


        public int TTMXDelete()
        {
            SqlParameter[] parms = {
                                       
                                   };
            return Binning(CommandType.StoredProcedure, SQL_TTMXDelete, parms);
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
