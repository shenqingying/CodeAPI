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
    public class KH_XSYWJZ : IKH_XSYWJZ
    {
        private const string SQL_Create = "CRM_KH_XSYWJZ_Create";
        private const string SQL_Update = "CRM_KH_XSYWJZ_Update";
        private const string SQL_Delete = "CRM_KH_XSYWJZ_Delete";
        private const string SQL_ReadByKHID = "CRM_KH_XSYWJZ_ReadByKHID";
        private const string SQL_ReadByID = "CRM_KH_XSYWJZ_ReadByID";


        public int Create(CRM_KH_XSYWJZ model)
        {
            SqlParameter[] parms = {
                                       
                                        new SqlParameter("@KHID",model.KHID),
                                        new SqlParameter("@JZID",model.JZID),
                                        new SqlParameter("@INFO1",model.INFO1),
                                        new SqlParameter("@INFO2",model.INFO2),
                                        new SqlParameter("@INFO3",model.INFO3),
                                        new SqlParameter("@CZR",model.CZR),
                                        new SqlParameter("@CZSJ",model.CZSJ),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@BEIZ",model.BEIZ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }


        public int Update(CRM_KH_XSYWJZ model)
        {
            SqlParameter[] parms = {
                                         new SqlParameter("@XSYWJZID",model.XSYWJZID),
                                        new SqlParameter("@KHID",model.KHID),
                                        new SqlParameter("@JZID",model.JZID),
                                        new SqlParameter("@INFO1",model.INFO1),
                                        new SqlParameter("@INFO2",model.INFO2),
                                        new SqlParameter("@INFO3",model.INFO3),
                                        new SqlParameter("@CZR",model.CZR),
                                        new SqlParameter("@CZSJ",model.CZSJ),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@BEIZ",model.BEIZ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }


        public int Delete(int XSYWJZID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@XSYWJZID",XSYWJZID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }


        public IList<CRM_KH_XSYWJZList> ReadByKHID(int KHID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID)
                                   };
            IList<CRM_KH_XSYWJZList> nodes = new List<CRM_KH_XSYWJZList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByKHID, parms))
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


        public CRM_KH_XSYWJZ ReadByID(int XSYWJZID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@XSYWJZID",XSYWJZID)
                                   };
            CRM_KH_XSYWJZ nodes = new CRM_KH_XSYWJZ();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByID, parms))
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



        private CRM_KH_XSYWJZList ReadDataToObjectList(SqlDataReader sdr)
        {
            CRM_KH_XSYWJZList node = new CRM_KH_XSYWJZList();
            node.XSYWJZID = Convert.ToInt32(sdr["XSYWJZID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.JZID = Convert.ToInt32(sdr["JZID"]);
            node.JZIDDES = Convert.ToString(sdr["JZIDDES"]);
            node.INFO1 = Convert.ToString(sdr["INFO1"]);
            node.INFO2 = Convert.ToString(sdr["INFO2"]);
            node.INFO3 = Convert.ToString(sdr["INFO3"]);
            node.CZR = Convert.ToInt32(sdr["CZR"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.CZSJ = Convert.ToString(sdr["CZSJ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            return node;
        }

        private CRM_KH_XSYWJZ ReadDataToObject(SqlDataReader sdr)
        {
            CRM_KH_XSYWJZ node = new CRM_KH_XSYWJZ();
            node.XSYWJZID = Convert.ToInt32(sdr["XSYWJZID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.JZID = Convert.ToInt32(sdr["JZID"]);
            node.INFO1 = Convert.ToString(sdr["INFO1"]);
            node.INFO2 = Convert.ToString(sdr["INFO2"]);
            node.INFO3 = Convert.ToString(sdr["INFO3"]);
            node.CZR = Convert.ToInt32(sdr["CZR"]);
            node.CZSJ = Convert.ToString(sdr["CZSJ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);
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
