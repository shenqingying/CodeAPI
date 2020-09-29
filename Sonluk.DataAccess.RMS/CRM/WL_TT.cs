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
    public class WL_TT : IWL_TT
    {
        private const string SQL_Create = "CRM_WL_TT_Create";
        private const string SQL_Update = "CRM_WL_TT_Update";
        private const string SQL_ReadByParam = "CRM_WL_TT_ReadByParam";
        private const string SQL_Delete = "CRM_WL_TT_Delete";

        public int Create(CRM_WL_TT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@NUMBER", model.NUMBER),
                                        
                                        new SqlParameter("@CJR", model.CJR),
                                        
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        
                                       
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_WL_TT model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@NUMBER", model.NUMBER),
                                        
                                        new SqlParameter("@CJR", model.CJR),
                                        new SqlParameter("@CJSJ", model.CJSJ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@TTID", model.TTID),
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_WL_TT> ReadByParam(CRM_WL_TT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TTID", model.TTID),      
                                        
                                        
                                        new SqlParameter("@NUMBER", model.NUMBER),
                                       new SqlParameter("@CJSJ_BEGIN",model.CJSJ_BEGIN),
                                       new SqlParameter("@CJSJ_END",model.CJSJ_END)
                                        
                                   };
            IList<CRM_WL_TT> nodes = new List<CRM_WL_TT>();
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
        public int Delete(int TTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TTID", TTID)
                                       

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

        private CRM_WL_TT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_WL_TT node = new CRM_WL_TT();
            node.TTID = Convert.ToInt32(sdr["TTID"]);

            node.NUMBER = Convert.ToString(sdr["NUMBER"]);
            
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            return node;
        }
    }
}
