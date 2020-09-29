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
    public class KH_GROUP_XSQY : IKH_GROUP_XSQY
    {
        private const string SQL_Create = "CRM_KH_GROUP_XSQY_Create";
        private const string SQL_Update = "CRM_KH_GROUP_XSQY_Update";
        private const string SQL_Read = "CRM_KH_GROUP_XSQY_Read";//"SELECT * FROM  CRM_KH_GROUP_XSQY WHERE ISACTIVE = 1";
        private const string SQL_Delete = "CRM_KH_GROUP_XSQY_Delete";


        public int Create(CRM_KH_GROUP_XSQY model)
        {
            SqlParameter[] parms = {
                                       //new SqlParameter("@XSQYID", model.XSQYID),
                                        new SqlParameter("@XSZZ", model.XSZZ),
                                        new SqlParameter("@FXQD", model.FXQD),
                                        new SqlParameter("@CPZ", model.CPZ),
                                        new SqlParameter("@XSDQ", model.XSDQ),
                                        new SqlParameter("@XSBM", model.XSBM),
                                        new SqlParameter("@XSZ", model.XSZ),
                                        new SqlParameter("@XSQY", model.XSQY),
                                        new SqlParameter("@SJSFTB", model.SJSFTB),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@XSQYMS",model.XSQYMS)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_KH_GROUP_XSQY model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@XSQYID", model.XSQYID),
                                        new SqlParameter("@XSZZ", model.XSZZ),
                                        new SqlParameter("@FXQD", model.FXQD),
                                        new SqlParameter("@CPZ", model.CPZ),
                                        new SqlParameter("@XSDQ", model.XSDQ),
                                        new SqlParameter("@XSBM", model.XSBM),
                                        new SqlParameter("@XSZ", model.XSZ),
                                        new SqlParameter("@XSQY", model.XSQY),
                                        new SqlParameter("@SJSFTB", model.SJSFTB),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@XSQYMS",model.XSQYMS)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

       




        public IList<CRM_KH_GROUP_XSQY> Read()
        {
            IList<CRM_KH_GROUP_XSQY> node = new List<CRM_KH_GROUP_XSQY>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, null))
                {
                    while (sdr.Read())
                    {
                        node.Add(ReadDataToObject(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }



            return node;
        }
        public int Delete(int XSQYID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@XSQYID",XSQYID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }


        private CRM_KH_GROUP_XSQY ReadDataToObject(SqlDataReader sdr)
        {
            CRM_KH_GROUP_XSQY node = new CRM_KH_GROUP_XSQY();
            node.XSQYID = Convert.ToInt32(sdr["XSQYID"]);
            node.XSZZ = Convert.ToString(sdr["XSZZ"]);
            node.FXQD = Convert.ToString(sdr["FXQD"]);
            node.CPZ = Convert.ToString(sdr["CPZ"]);
            node.XSDQ = Convert.ToString(sdr["XSDQ"]);
            node.XSBM = Convert.ToString(sdr["XSBM"]);
            node.XSZ = Convert.ToString(sdr["XSZ"]);
            node.XSQY = Convert.ToInt32(sdr["XSQY"]);
            node.SJSFTB = Convert.ToBoolean(sdr["SJSFTB"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.XSQYMS = Convert.ToString(sdr["XSQYMS"]);
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


                        //if (sql == SQL_Delete)
                        //{
                        //    ID = Convert.ToInt32(sdr["Return Value"]);
                        //}
                        //else
                        //{
                            ID = Convert.ToInt32(sdr["ID"]);
                        //}


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
