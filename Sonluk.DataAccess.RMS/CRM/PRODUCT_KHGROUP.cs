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
    public class PRODUCT_KHGROUP : IPRODUCT_KHGROUP
    {
        private const string SQL_Create = "CRM_PRODUCT_KHGROUP_Create";
        private const string SQL_Update = "CRM_PRODUCT_KHGROUP_Update";
        private const string SQL_Read = "CRM_PRODUCT_KHGROUP_Read";
        private const string SQL_Delete = "CRM_PRODUCT_KHGROUP_Delete";

        public int Create(int KHID, int GROUPID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KHID", KHID),
                                        new SqlParameter("@GROUPID", GROUPID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }


        public IList<CRM_PRODUCT_KHGROUP> Read(CRM_PRODUCT_KHGROUP model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHMC",model.KHMC),
                                       new SqlParameter("@SAPSN",model.SAPSN),
                                       new SqlParameter("@GROUPID",model.GROUPID)
                                   };
            IList<CRM_PRODUCT_KHGROUP> nodes = new List<CRM_PRODUCT_KHGROUP>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public int Delete(int KHID, int GROUPID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KHID", KHID),
                                        new SqlParameter("@GROUPID", GROUPID)
                                       

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

        private CRM_PRODUCT_KHGROUP ReadDataToObj(SqlDataReader sdr)
        {
            CRM_PRODUCT_KHGROUP node = new CRM_PRODUCT_KHGROUP();
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.GROUPID = Convert.ToInt32(sdr["GROUPID"]);
            node.KHMC = Convert.ToString(sdr["KHMC"]);
            node.KHLXDES = Convert.ToString(sdr["KHLXDES"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.GROUPNAME = Convert.ToString(sdr["GROUPNAME"]);
            node.GROUPDES = Convert.ToString(sdr["GROUPDES"]);
            return node;
        }




    }
}
