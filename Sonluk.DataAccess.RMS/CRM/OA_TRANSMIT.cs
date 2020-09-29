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
    public class OA_TRANSMIT : IOA_TRANSMIT
    {
        private const string SQL_Create = "CRM_OA_TRANSMIT_Create";
        private const string SQL_Update = "CRM_OA_TRANSMIT_Update";
        private const string SQL_Delete = "UPDATE  CRM_OA_TRANSMIT SET ISDELETE = 1 WHERE ID = @ID";
        private const string SQL_Read = "CRM_OA_TRANSMIT_Read";//"SELECT * FROM CRM_OA_TRANSMIT WHERE ISDELETE = 0 AND OAZT = @Status";
        private const string SQL_ReadByParam = "CRM_OA_TRANSMIT_ReadByParam";


        public int Create(CRM_OA_TRANSMIT model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@ID", model.ID),
                                        new SqlParameter("@OAID", model.OAID),
                                        new SqlParameter("@OACSBH", model.OACSBH),
                                        new SqlParameter("@OACSLB", model.OACSLB),
                                        new SqlParameter("@OAZT", model.OAZT),
                                        new SqlParameter("@CJSJ", model.CJSJ),
                                        new SqlParameter("@ISDELETE", model.ISDELETE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_OA_TRANSMIT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ID", model.ID),
                                        new SqlParameter("@OAID", model.OAID),
                                        new SqlParameter("@OACSBH", model.OACSBH),
                                        new SqlParameter("@OACSLB", model.OACSLB),
                                        new SqlParameter("@OAZT", model.OAZT),
                                        new SqlParameter("@CJSJ", model.CJSJ),
                                        new SqlParameter("@ISDELETE", model.ISDELETE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
      



        public IList<CRM_OA_TRANSMIT> Read(int Status)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@Status",Status)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_Read,parms))
                {
                    
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            IList<CRM_OA_TRANSMIT> nodes = new List<CRM_OA_TRANSMIT>();
            return nodes;
        }

        public IList<CRM_OA_TRANSMIT> ReadByParam(CRM_OA_TRANSMIT model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ID", model.ID),
                                        new SqlParameter("@OAID", model.OAID),
                                        new SqlParameter("@OACSBH", model.OACSBH),
                                        new SqlParameter("@OACSLB", model.OACSLB),
                                   };
            IList<CRM_OA_TRANSMIT> nodes = new List<CRM_OA_TRANSMIT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToOBJ(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public int Delete(int ID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ID",ID)
                                   };
            return Binning(CommandType.Text, SQL_Delete, parms);
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

        private CRM_OA_TRANSMIT ReadDataToOBJ(SqlDataReader sdr)
        {
            CRM_OA_TRANSMIT node = new CRM_OA_TRANSMIT();
            node.ID = Convert.ToInt32(sdr["ID"]);
            node.OAID = Convert.ToString(sdr["OAID"]);
            node.OACSBH = Convert.ToInt32(sdr["OACSBH"]);
            node.OACSLB = Convert.ToInt16(sdr["OACSLB"]);
            node.OAZT = Convert.ToInt32(sdr["OAZT"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); 
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);
            return node;

        }

    }
}
