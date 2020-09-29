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
    public class COST_CJHDWD : ICOST_CJHDWD
    {
        private const string SQL_Create = "CRM_COST_CJHDWD_Create";
        private const string SQL_Update = "CRM_COST_CJHDWD_Update";
        private const string SQL_ReadByParam = "CRM_COST_CJHDWD_ReadByParam";
        private const string SQL_Delete = "CRM_COST_CJHDWD_Delete";

        public int Create(CRM_COST_CJHDWD model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CXHDID", model.CXHDID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_CJHDWD model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CJHDWDID", model.CJHDWDID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_CJHDWD> ReadByParam(CRM_COST_CJHDWD model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CJHDWDID", model.CJHDWDID),
                                        new SqlParameter("@CXHDID", model.CXHDID),
                                        new SqlParameter("@KHID", model.KHID)

                                   };
            IList<CRM_COST_CJHDWD> nodes = new List<CRM_COST_CJHDWD>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParam, parms))
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
        public int Delete(int CJHDWDID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CJHDWDID", CJHDWDID)
                                       

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

        private CRM_COST_CJHDWD ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_CJHDWD node = new CRM_COST_CJHDWD();
            node.CJHDWDID = Convert.ToInt32(sdr["CJHDWDID"]);
            node.CXHDID = Convert.ToInt32(sdr["CXHDID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);


            node.HDBH = Convert.ToString(sdr["HDBH"]);
            node.KHZZSJ = Convert.ToString(sdr["KHZZSJ"]);
            //node.JXSNAME = Convert.ToString(sdr["JXSNAME"]);
            //node.JXSCRMID = Convert.ToString(sdr["JXSCRMID"]);
            //node.JXSSAPSN = Convert.ToString(sdr["JXSSAPSN"]);
            node.WDMC = Convert.ToString(sdr["WDMC"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.GSLXDZ = Convert.ToString(sdr["GSLXDZ"]);
            node.GSLXR = Convert.ToString(sdr["GSLXR"]);
            node.GSLXDH = Convert.ToString(sdr["GSLXDH"]);
            node.WDLXDES = Convert.ToString(sdr["WDLXDES"]);

            return node;
        }




    }
}
