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
    public class PRODUCT_GROUP : IPRODUCT_GROUP
    {
        private const string SQL_Create = "CRM_PRODUCT_GROUP_Create";
        private const string SQL_Update = "CRM_PRODUCT_GROUP_Update";
        private const string SQL_Read = "CRM_PRODUCT_GROUP_Read";
        private const string SQL_Delete = "CRM_PRODUCT_GROUP_Delete";
        private const string SQL_ReadIDByGroupName = "CRM_PRODUCT_GROUP_ReadIDByGroupName";

        public int Create(CRM_PRODUCT_GROUP model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@GROUPNAME", model.GROUPNAME),
                                        new SqlParameter("@GROUPDES", model.GROUPDES),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_PRODUCT_GROUP model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@GROUPID", model.GROUPID),
                                        new SqlParameter("@GROUPNAME", model.GROUPNAME),
                                        new SqlParameter("@GROUPDES", model.GROUPDES),
                                        new SqlParameter("@BEIZ", model.BEIZ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_PRODUCT_GROUP> Read()
        {
            SqlParameter[] parms = {
                                       

                                   };
            IList<CRM_PRODUCT_GROUP> nodes = new List<CRM_PRODUCT_GROUP>();
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

        public int ReadByIDGroupName(string GROUPNAME)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@GROUPNAME", GROUPNAME)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_ReadIDByGroupName, parms);
        }

        public int Delete(int GROUPID)
        {
            SqlParameter[] parms = {
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

        private CRM_PRODUCT_GROUP ReadDataToObj(SqlDataReader sdr)
        {
            CRM_PRODUCT_GROUP node = new CRM_PRODUCT_GROUP();
            node.GROUPID = Convert.ToInt32(sdr["GROUPID"]);
            node.GROUPNAME = Convert.ToString(sdr["GROUPNAME"]);
            node.GROUPDES = Convert.ToString(sdr["GROUPDES"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.PRODUCTIDCOUNT = Convert.ToInt32(sdr["PRODUCTIDCOUNT"]);
            return node;
        }




    }
}
