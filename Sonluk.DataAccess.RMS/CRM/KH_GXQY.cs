using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using Sonluk.IDataAccess.CRM;
namespace Sonluk.DataAccess.RMS.CRM
{
    public class KH_GXQY : IKH_GXQY
    {
        private const string SQL_Create = "CRM_KH_GXQY_Create";
        private const string SQL_Update = "CRM_KH_GXQY_Update";
        private const string SQL_Read = "CRM_KH_GXQY_Read";//@"SELECT *,ISNULL((SELECT FID FROM CRM_HG_DICT WHERE DICID = GXQYMC),0) AS FID ,ISNULL((SELECT DICNAME FROM CRM_HG_DICT WHERE DICID = GXQYMC),0) AS GXQYMCDES FROM CRM_KH_GXQY WHERE KHID = @KHID AND ISACTIVE = 1";
        private const string SQL_Delete = "CRM_KH_GXQY_Delete";
        private const string SQL_DeleteByKHID = "UPDATE CRM_KH_GXQY SET ISACTIVE = 0 WHERE KHID = @KHID";

        public int Create(CRM_KH_GXQY model)
        {
            SqlParameter[] parms = {
                                      
                                        new SqlParameter("@KHID",model.KHID),
                                        new SqlParameter("@GXQYLX",model.GXQYLX),
                                        new SqlParameter("@GXQYMC",model.GXQYMC),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                        new SqlParameter("@BEIZ",string.IsNullOrEmpty(model.BEIZ)?"":model.BEIZ)

                                   };
            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Create, parms)) 
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
        public int Update(CRM_KH_GXQY model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@GXQYID",model.GXQYID),
                                        new SqlParameter("@KHID",model.KHID),
                                        new SqlParameter("@GXQYLX",model.GXQYLX),
                                        new SqlParameter("@GXQYMC",model.GXQYMC),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                        new SqlParameter("@BEIZ",model.BEIZ)
                                   };
            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_Update,parms))
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

        public IList<CRM_KH_GXQYList> Read(int KHID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID)
                                   };
            IList<CRM_KH_GXQYList> nodes = new List<CRM_KH_GXQYList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
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
            };
            return nodes;
        }
        public int Delete(int GXQYID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@GXQYID",GXQYID)
                                   };
            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_Delete,parms))
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
        public int DeleteByKHID(int KHID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID)
                                   };
            int no = 0;
            try
            {
               no = SQLServerHelper.ExecuteNonQuery(CommandType.Text, SQL_DeleteByKHID, parms);
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return no;
            
        }



        private CRM_KH_GXQYList ReadDataToObject(SqlDataReader sdr)
        {
            CRM_KH_GXQYList node = new CRM_KH_GXQYList();
            node.GXQYID = Convert.ToInt32(sdr["GXQYID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.GXQYLX = Convert.ToInt32(sdr["GXQYLX"]);
            node.GXQYMC = Convert.ToInt32(sdr["GXQYMC"]);
            node.ISACTIVE = Convert.ToInt32(sdr["KHID"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.FID = Convert.ToInt32(sdr["FID"]);
            node.GXQYMCDES = Convert.ToString(sdr["GXQYMCDES"]);
            return node;
        }
    }
}
