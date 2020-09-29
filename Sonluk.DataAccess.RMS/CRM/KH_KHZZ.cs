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
    public class KH_KHZZ : IKH_KHZZ
    {
        private const string SQL_Create = "CRM_KH_KHZZ_Create";
        private const string SQL_Update = "CRM_KH_KHZZ_Update";
        private const string SQL_Delete = "CRM_KH_KHZZ_Delete";
        private const string SQL_ReadByKHID = "CRM_KH_KHZZ_ReadByKHID";
        private const string SQL_ReadByID = "CRM_KH_KHZZ_ReadByID";
        private const string SQL_DeleteByKHID = "CRM_KH_KHZZ_DeleteByKHID";
        private const string SQL_ReadByParam = "CRM_KH_KHZZ_ReadByParam";

        public int Create(CRM_KH_KHZZ model)
        {
            SqlParameter[] parms = {
                                       
                                        new SqlParameter("@KHID",model.KHID),
                                        new SqlParameter("@ZZMCID",model.ZZMCID),
                                        new SqlParameter("@INFO1",model.INFO1),
                                        new SqlParameter("@INFO2",model.INFO2),
                                        new SqlParameter("@INFO3",model.INFO3),
                                        new SqlParameter("@CZR",model.CZR),
                                        new SqlParameter("@CZSJ",model.CZSJ),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                        new SqlParameter("@BEIZ",model.BEIZ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }


        public int Update(CRM_KH_KHZZ model)
        {
            SqlParameter[] parms = {
                                         new SqlParameter("@ZZID",model.ZZID),
                                        new SqlParameter("@KHID",model.KHID),
                                        new SqlParameter("@ZZMCID",model.ZZMCID),
                                        new SqlParameter("@INFO1",model.INFO1),
                                        new SqlParameter("@INFO2",model.INFO2),
                                        new SqlParameter("@INFO3",model.INFO3),
                                        new SqlParameter("@CZR",model.CZR),
                                        new SqlParameter("@CZSJ",model.CZSJ),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                        new SqlParameter("@BEIZ",model.BEIZ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public int Delete(int ZZID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ZZID",ZZID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }

        public int DeleteByKHID(int KHID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_DeleteByKHID, parms);
        }

        public IList<CRM_KH_KHZZList> ReadByKHID(int KHID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID)
                                   };
            IList<CRM_KH_KHZZList> nodes = new List<CRM_KH_KHZZList>();
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


        public IList<CRM_KH_KHZZ> ReadByParam(CRM_KH_KHZZ model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",model.KHID),
                                       new SqlParameter("@ZZMCID",model.ZZMCID),
                                       new SqlParameter("@INFO1",model.INFO1),
                                       new SqlParameter("@INFO2",model.INFO2),
                                       new SqlParameter("@INFO3",model.INFO3)
                                   };
            IList<CRM_KH_KHZZ> nodes = new List<CRM_KH_KHZZ>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObject(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public CRM_KH_KHZZ ReadByID(int ZZID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ZZID",ZZID)
                                   };
            CRM_KH_KHZZ nodes = new CRM_KH_KHZZ();
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



        private CRM_KH_KHZZList ReadDataToObjectList(SqlDataReader sdr)
        {
            CRM_KH_KHZZList node = new CRM_KH_KHZZList();
            node.ZZID = Convert.ToInt32(sdr["ZZID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.KHMC = Convert.ToString(sdr["KHMC"]);
            node.ZZMCID = Convert.ToInt32(sdr["ZZMCID"]);
            node.ZZMCIDDES = Convert.ToString(sdr["ZZMCIDDES"]);
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

        private CRM_KH_KHZZ ReadDataToObject(SqlDataReader sdr)
        {
            CRM_KH_KHZZ node = new CRM_KH_KHZZ();
            node.ZZID = Convert.ToInt32(sdr["ZZID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.ZZMCID = Convert.ToInt32(sdr["ZZMCID"]);
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
