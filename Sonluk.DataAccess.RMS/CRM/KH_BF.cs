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
    public class KH_BF : IKH_BF
    {
        private const string SQL_Create = "CRM_KH_BF_Create";
        private const string SQL_Update = "CRM_KH_BF_Update";
        private const string SQL_Read = "CRM_KH_BF_Read";//"SELECT A.*,ISNULL((SELECT DUTYNAME FROM CRM_HG_DUTY WHERE DUTYID = A.DUTYID),' ') AS DUTYIDDES,ISNULL((SELECT DICNAME FROM CRM_HG_DICT WHERE DICID = A.BFZQ),' ') AS BFZQDES FROM CRM_KH_BF AS A WHERE ISACTIVE = 1";
        private const string SQL_Delete = "CRM_KH_BF_Delete";
        


        public int Create(CRM_KH_BF model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@BFID", model.BFID),
                                        new SqlParameter("@DUTYID", model.DUTYID),
                                        new SqlParameter("@BFZQ", model.BFZQ),
                                        new SqlParameter("@BFCS", model.BFCS),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@CJSJ", model.CJSJ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_KH_BF model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@BFID", model.BFID),
                                        new SqlParameter("@DUTYID", model.DUTYID),
                                        new SqlParameter("@BFZQ", model.BFZQ),
                                        new SqlParameter("@BFCS", model.BFCS),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@CJSJ", model.CJSJ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_KH_BFList> Read(CRM_KH_BF model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@BFID", model.BFID),
                                        new SqlParameter("@DUTYID", model.DUTYID),
                                        new SqlParameter("@BFZQ", model.BFZQ),
                                        new SqlParameter("@BFCS", model.BFCS),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@CJSJ", model.CJSJ)

                                   };
            IList<CRM_KH_BFList> nodes = new List<CRM_KH_BFList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObjList(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public int Delete(int BFID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@BFID", BFID),
                                       

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }

        private CRM_KH_BFList ReadDataToObjList(SqlDataReader sdr)
        {
            CRM_KH_BFList node = new CRM_KH_BFList();
            node.BFID = Convert.ToInt32(sdr["BFID"]);
            node.DUTYID = Convert.ToInt32(sdr["DUTYID"]);
            node.BFZQ = Convert.ToInt32(sdr["BFZQ"]);
            node.BFCS = Convert.ToInt32(sdr["BFCS"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.DUTYIDDES = Convert.ToString(sdr["DUTYIDDES"]);
            node.BFZQDES = Convert.ToString(sdr["BFZQDES"]);
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
        public CRM_KH_BF ReadDatoToObj(SqlDataReader sdr)
        {
            CRM_KH_BF node = new CRM_KH_BF();
            node.BFID = Convert.ToInt32(sdr["BFID"]);
            node.DUTYID = Convert.ToInt32(sdr["DUTYID"]);
            node.BFZQ = Convert.ToInt32(sdr["BFZQ"]);
            node.BFCS = Convert.ToInt32(sdr["BFCS"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.CJSJ = Convert.ToString(sdr["CJSJ"]);
            return node;
        }
    }
}
