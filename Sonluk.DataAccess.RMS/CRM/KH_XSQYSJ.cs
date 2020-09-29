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
    public class KH_XSQYSJ : IKH_XSQYSJ
    {
        private const string SQL_Create = @"INSERT INTO CRM_KH_XSQYSJ(SAPSN,XSZZ,FXQD,CPZ,XSDQ,XSBM,XSZ,ISACTIVE,BEIZ) VALUES(@SAPSN,@XSZZ,@FXQD,@CPZ,@XSDQ,@XSBM,@XSZ,@ISACTIVE,@BEIZ)";
        private const string SQL_Delete = "DELETE FROM CRM_KH_XSQYSJ WHERE SAPSN = @SAPSN";

        private const string SQL_ReadBySAPSN = "CRM_KH_XSQYSJ_ReadBySAPSN";

        public int Create(CRM_KH_XSQYSJ model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SAPSN", model.SAPSN),
                                        new SqlParameter("@XSZZ", model.XSZZ),
                                        new SqlParameter("@FXQD", model.FXQD),
                                        new SqlParameter("@CPZ", model.CPZ),
                                        new SqlParameter("@XSDQ", model.XSDQ),
                                        new SqlParameter("@XSBM", model.XSBM),
                                        new SqlParameter("@XSZ", model.XSZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ)

                                   };
            return SQLServerHelper.ExecuteNonQuery(CommandType.Text, SQL_Create, parms);
            //new SqlParameter("@SAPSN",string.IsNullOrEmpty(model.SAPSN)?"":model.SAPSN),
            //                           new SqlParameter("@XSZZ",string.IsNullOrEmpty(model.XSZZ)?"":model.XSZZ),
            //                           new SqlParameter("@FXQD", string.IsNullOrEmpty(model.FXQD)?"":model.FXQD),
            //                           new SqlParameter("@CPZ", string.IsNullOrEmpty(model.CPZ)?"":model.CPZ),
            //                           new SqlParameter("@XSDQ", string.IsNullOrEmpty(model.XSDQ)?"":model.XSDQ),
            //                           new SqlParameter("@XSBM", string.IsNullOrEmpty(model.XSBM)?"":model.XSBM),
            //                           new SqlParameter("@XSZ", string.IsNullOrEmpty(model.XSZ)?"":model.XSZ),
            //                           new SqlParameter("@ISACTIVE", model.ISACTIVE),
            //                           new SqlParameter("@BEIZ", string.IsNullOrEmpty(model.BEIZ)?"":model.BEIZ)
        }

        public int Delete(string SAPSN)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@SAPSN",SAPSN)
                                   };
            return SQLServerHelper.ExecuteNonQuery(CommandType.Text, SQL_Delete, parms);
        }

        public CRM_KH_XSQYSJ ReadBySAPSN(string SAPSN)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@SAPSN",SAPSN)
                                   };

            CRM_KH_XSQYSJ nodes = new CRM_KH_XSQYSJ();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadBySAPSN, parms))
                {
                    while (sdr.Read())
                    {
                        nodes = ReadDataToObject(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }









        private CRM_KH_XSQYSJ ReadDataToObject(SqlDataReader sdr)
        {
            CRM_KH_XSQYSJ node = new CRM_KH_XSQYSJ();
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.XSZZ = Convert.ToString(sdr["XSZZ"]);
            node.FXQD = Convert.ToString(sdr["FXQD"]);
            node.CPZ = Convert.ToString(sdr["CPZ"]);
            node.XSDQ = Convert.ToString(sdr["XSDQ"]);
            node.XSBM = Convert.ToString(sdr["XSBM"]);
            node.XSZ = Convert.ToString(sdr["XSZ"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
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
