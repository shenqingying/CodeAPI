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
    public class KH_DZ : IKH_DZ
    {
        private const string SQL_Create = "CRM_KH_DZ_Create";
        private const string SQL_Update = "CRM_KH_DZ_Update";
        private const string SQL_ReadByKHID = "CRM_KH_DZ_ReadByKHID";//"SELECT A.*,ISNULL((SELECT DICNAME FROM CRM_HG_DICT WHERE DICID = A.CS),' ') AS CSDES,ISNULL((SELECT DICNAME FROM CRM_HG_DICT WHERE DICID = A.SF),' ') AS SFDES FROM CRM_KH_DZ AS A WHERE A.KHID = @KHID AND ISACTIVE = 1";
        private const string SQL_Delete = "CRM_KH_DZ_Delete";

        public int Create(CRM_KH_DZ model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@DZID", model.DZID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@DZMS", model.DZMS),
                                        new SqlParameter("@GJ", model.GJ),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@ED", model.ED),
                                        new SqlParameter("@JD", model.JD),
                                        new SqlParameter("@DZRC", model.DZRC),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@DWDZMS",model.DWDZMS),
                                        new SqlParameter("@DZSOURCE",model.DZSOURCE)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_KH_DZ model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@DZID", model.DZID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@DZMS", model.DZMS),
                                        new SqlParameter("@GJ", model.GJ),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@CS", model.CS),
                                        new SqlParameter("@ED", model.ED),
                                        new SqlParameter("@JD", model.JD),
                                        new SqlParameter("@DZRC", model.DZRC),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@DWDZMS",model.DWDZMS)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
     
        public IList<CRM_KH_DZList> ReadByKHID(int KHID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID)
                                   };
            IList<CRM_KH_DZList> nodes = new List<CRM_KH_DZList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_ReadByKHID,parms))
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


        public int Delete(int DZID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@DZID",DZID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }


        private CRM_KH_DZ ReadDataToObject(SqlDataReader sdr)
        {
            CRM_KH_DZ node = new CRM_KH_DZ();
            node.DZID = Convert.ToInt32(sdr["DZID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.DZMS = Convert.ToString(sdr["DZMS"]);
            node.GJ = Convert.ToInt32(sdr["GJ"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.ED = Convert.ToString(sdr["ED"]);
            node.JD = Convert.ToString(sdr["JD"]);
            node.DZRC = Convert.ToInt32(sdr["DZRC"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.DWDZMS = Convert.ToString(sdr["DWDZMS"]);
            node.DZSOURCE = Convert.ToInt32(sdr["DZSOURCE"]);

            return node;
        }
        private CRM_KH_DZList ReadDataToObjectList(SqlDataReader sdr)
        {
            CRM_KH_DZList node = new CRM_KH_DZList();
            node.DZID = Convert.ToInt32(sdr["DZID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.DZMS = Convert.ToString(sdr["DZMS"]);
            node.GJ = Convert.ToInt32(sdr["GJ"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.ED = Convert.ToString(sdr["ED"]);
            node.JD = Convert.ToString(sdr["JD"]);
            node.DZRC = Convert.ToInt32(sdr["DZRC"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);
            node.DWDZMS = Convert.ToString(sdr["DWDZMS"]);
            node.DZSOURCE = Convert.ToString(sdr["DZSOURCE"]);
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
