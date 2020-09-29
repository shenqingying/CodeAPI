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
    public class HD_ZYCXYMX : IHD_ZYCXYMX
    {
        private const string SQL_Create = "CRM_HD_ZYCXYMX_Create";
        private const string SQL_Update = "CRM_HD_ZYCXYMX_Update";
        private const string SQL_Read = "SELECT * FROM CRM_HD_ZYCXYMX ";
        private const string SQL_Delete = "CRM_HD_ZYCXYMX_Delete";
        public int Create(CRM_HD_ZYCXYMX model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@ZYCXYMXID", model.ZYCXYMXID),
                                        new SqlParameter("@ZYCXYID", model.ZYCXYID),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CITY", model.CITY),
                                        new SqlParameter("@FZR", model.FZR),
                                        new SqlParameter("@XSE1", model.XSE1),
                                        new SqlParameter("@XSE2", model.XSE2),
                                        new SqlParameter("@XSE3", model.XSE3),
                                        new SqlParameter("@DCXSZE", model.DCXSZE),
                                        new SqlParameter("@ZYZC", model.ZYZC),
                                        new SqlParameter("@GW", model.GW),
                                        new SqlParameter("@REGH", model.REGH),
                                        new SqlParameter("@YKHJS", model.YKHJS),
                                        new SqlParameter("@SGYG", model.SGYG),
                                        new SqlParameter("@XM", model.XM),
                                        new SqlParameter("@SEX", model.SEX),
                                        new SqlParameter("@SFZHM", model.SFZHM),
                                        new SqlParameter("@TEL", model.TEL),
                                        new SqlParameter("@SGRQ", model.SGRQ),
                                        new SqlParameter("@KHYH", model.KHYH),
                                        new SqlParameter("@YHKH", model.YHKH),
                                        new SqlParameter("@QZCS", model.QZCS),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_HD_ZYCXYMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ZYCXYMXID", model.ZYCXYMXID),
                                        new SqlParameter("@ZYCXYID", model.ZYCXYID),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CITY", model.CITY),
                                        new SqlParameter("@FZR", model.FZR),
                                        new SqlParameter("@XSE1", model.XSE1),
                                        new SqlParameter("@XSE2", model.XSE2),
                                        new SqlParameter("@XSE3", model.XSE3),
                                        new SqlParameter("@DCXSZE", model.DCXSZE),
                                        new SqlParameter("@ZYZC", model.ZYZC),
                                        new SqlParameter("@GW", model.GW),
                                        new SqlParameter("@REGH", model.REGH),
                                        new SqlParameter("@YKHJS", model.YKHJS),
                                        new SqlParameter("@SGYG", model.SGYG),
                                        new SqlParameter("@XM", model.XM),
                                        new SqlParameter("@SEX", model.SEX),
                                        new SqlParameter("@SFZHM", model.SFZHM),
                                        new SqlParameter("@TEL", model.TEL),
                                        new SqlParameter("@SGRQ", model.SGRQ),
                                        new SqlParameter("@KHYH", model.KHYH),
                                        new SqlParameter("@YHKH", model.YHKH),
                                        new SqlParameter("@QZCS", model.QZCS),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public int Delete(int ZYCXYMXID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ZYCXYMXID",ZYCXYMXID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
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

        private CRM_HD_ZYCXYMX ReadDataToObj(SqlDataReader sdr)
        {
            CRM_HD_ZYCXYMX node = new CRM_HD_ZYCXYMX();
            node.ZYCXYMXID = Convert.ToInt32(sdr["ZYCXYMXID"]);
            node.ZYCXYID = Convert.ToInt32(sdr["ZYCXYID"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CITY = Convert.ToInt32(sdr["CITY"]);
            node.FZR = Convert.ToInt32(sdr["FZR"]);
            node.XSE1 = Convert.ToDecimal(sdr["XSE1"]);
            node.XSE2 = Convert.ToDecimal(sdr["XSE2"]);
            node.XSE3 = Convert.ToDecimal(sdr["XSE3"]);
            node.DCXSZE = Convert.ToInt32(sdr["DCXSZE"]);
            node.ZYZC = Convert.ToString(sdr["ZYZC"]);
            node.GW = Convert.ToString(sdr["GW"]);
            node.REGH = Convert.ToBoolean(sdr["REGH"]);
            node.YKHJS = Convert.ToString(sdr["YKHJS"]);
            node.SGYG = Convert.ToString(sdr["SGYG"]);
            node.XM = Convert.ToString(sdr["XM"]);
            node.SEX = Convert.ToString(sdr["SEX"]);
            node.SFZHM = Convert.ToString(sdr["SFZHM"]);
            node.TEL = Convert.ToString(sdr["TEL"]);
            node.SGRQ = Convert.ToString(sdr["SGRQ"]);
            node.KHYH = Convert.ToString(sdr["KHYH"]);
            node.YHKH = Convert.ToString(sdr["YHKH"]);
            node.QZCS = Convert.ToString(sdr["QZCS"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            return node;
        }

    }
}
