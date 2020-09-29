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
    public class PRODUCT_PRODUCTGROUP : IPRODUCT_PRODUCTGROUP
    {
        private const string SQL_Create = "CRM_PRODUCT_PRODUCTGROUP_Create";
        private const string SQL_Update = "CRM_PRODUCT_PRODUCTGROUP_Update";
        private const string SQL_Read = "CRM_PRODUCT_PRODUCTGROUP_Read";
        private const string SQL_Delete = "CRM_PRODUCT_PRODUCTGROUP_Delete";

        public int Create(int PRODUCTID, int GROUPID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PRODUCTID", PRODUCTID),
                                        new SqlParameter("@GROUPID", GROUPID)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }


        public IList<CRM_PRODUCT_PRODUCTGROUP> Read(CRM_PRODUCT_PRODUCTGROUP model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@CPMC",model.CPMC),
                                       new SqlParameter("@GROUPID",model.GROUPID)
                                   };
            IList<CRM_PRODUCT_PRODUCTGROUP> nodes = new List<CRM_PRODUCT_PRODUCTGROUP>();
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

        public int Delete(int PRODUCTID, int GROUPID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@PRODUCTID", PRODUCTID),
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

        private CRM_PRODUCT_PRODUCTGROUP ReadDataToObj(SqlDataReader sdr)
        {
            CRM_PRODUCT_PRODUCTGROUP node = new CRM_PRODUCT_PRODUCTGROUP();
            node.PRODUCTID = Convert.ToInt32(sdr["PRODUCTID"]);
            node.GROUPID = Convert.ToInt32(sdr["GROUPID"]);
            node.CPLXDES = Convert.ToString(sdr["CPLXDES"]);
            node.CPXLDES = Convert.ToString(sdr["CPXLDES"]);
            node.CPXHDES = Convert.ToString(sdr["CPXHDES"]);
            node.CPPH = Convert.ToString(sdr["CPPH"]);
            node.CPMC = Convert.ToString(sdr["CPMC"]);
            node.GROUPNAME = Convert.ToString(sdr["GROUPNAME"]);
            node.GROUPDES = Convert.ToString(sdr["GROUPDES"]);
            return node;
        }



    }
}
