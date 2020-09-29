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
    public class HG_TYPE : IHG_TYPE
    {
        private const string SQL_Create = "CRM_HG_TYPE_Create";
        private const string SQL_Update = "CRM_HG_TYPE_Update";
        private const string SQL_Read = "CRM_HG_TYPE_Read";//"SELECT * FROM CRM_HG_TYPE WHERE ISACTIVE = 1";
        private const string SQL_Delete = "CRM_HG_TYPE_Delete";

        public int Create(CRM_HG_TYPE model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@TYPEID", model.TYPEID),
                                        new SqlParameter("@TYPENAME", model.TYPENAME),
                                        new SqlParameter("@TYPEMEMO", model.TYPEMEMO),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_HG_TYPE model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TYPEID", model.TYPEID),
                                        new SqlParameter("@TYPENAME", model.TYPENAME),
                                        new SqlParameter("@TYPEMEMO", model.TYPEMEMO),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_HG_TYPE> Read()
        {
            IList<CRM_HG_TYPE> nodes = new List<CRM_HG_TYPE>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_Read,null))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObeject(sdr));
                    }
                    
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;
            
        }
        public int Delete(int TYPEID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@TYPEID",TYPEID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }


        private CRM_HG_TYPE ReadDataToObeject(SqlDataReader sdr)
        {
            CRM_HG_TYPE node = new CRM_HG_TYPE();
            node.TYPEID = Convert.ToInt32(sdr["TYPEID"]);
            node.TYPENAME = Convert.ToString(sdr["TYPENAME"]);
            node.TYPEMEMO = Convert.ToString(sdr["TYPEMEMO"]);
            node.ISACTIVE = Convert.ToBoolean(sdr["ISACTIVE"]);

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
