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
    public class COST_CLFTT : ICOST_CLFTT
    {
        private const string SQL_Create = "CRM_COST_CLFTT_Create";
        private const string SQL_Update = "CRM_COST_CLFTT_Update";
        private const string SQL_ReadByParam = "CRM_COST_CLFTT_ReadByParam";
        private const string SQL_Delete = "CRM_COST_CLFTT_Delete";
        private const string SQL_ReadByAll = "CRM_COST_CLFTT_ReadByAll";


        public int Create(CRM_COST_CLFTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@DEPID", model.DEPID),
                                        new SqlParameter("@FGLD", model.FGLD),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@BXRQ", model.BXRQ),
                                        new SqlParameter("@CBZX", model.CBZX),
                                        new SqlParameter("@CCSY", model.CCSY),
                                        new SqlParameter("@HJ", model.HJ),
                                        new SqlParameter("@ZPYZ", model.ZPYZ),
                                        new SqlParameter("@XJYZ", model.XJYZ),
                                         new SqlParameter("@BLJE", model.BLJE),
                                        new SqlParameter("@GHJE", model.GHJE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR),
                                       
                                    
                                      
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_CLFTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@DEPID", model.DEPID),
                                        new SqlParameter("@FGLD", model.FGLD),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@BXRQ", model.BXRQ),
                                        new SqlParameter("@CBZX", model.CBZX),
                                        new SqlParameter("@CCSY", model.CCSY),
                                        new SqlParameter("@HJ", model.HJ),
                                        new SqlParameter("@ZPYZ", model.ZPYZ),
                                        new SqlParameter("@XJYZ", model.XJYZ),
                                         new SqlParameter("@BLJE", model.BLJE),
                                        new SqlParameter("@GHJE", model.GHJE),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@SHR", model.SHR),
                                        new SqlParameter("@CLFTTID", model.CLFTTID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_COST_CLFTT> ReadByAll(CRM_COST_CLFTT model, int CURRENTID)
        {
            SqlParameter[] parms = {  
                                        new SqlParameter("@CLFTTID", model.CLFTTID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@DEPID", model.DEPID),
                                        new SqlParameter("@FGLD", model.FGLD),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJSJ_BEGIN",model.CJSJ_BEGIN),
                                        new SqlParameter("@CJSJ_END",model.CJSJ_END),
                                        new SqlParameter("@CURRENTID",model.CURRENTID),
                                        new SqlParameter("@NUM",model.NUM),
                                        new SqlParameter("@SELECT_NAME",model.SELECT_NAME),
                                        
                                   };
            IList<CRM_COST_CLFTT> nodes = new List<CRM_COST_CLFTT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByAll, parms))
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

        public IList<CRM_COST_CLFTT> ReadByParam(CRM_COST_CLFTT model)
        {
            SqlParameter[] parms = {  
                                        new SqlParameter("@CLFTTID", model.CLFTTID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@DEPID", model.DEPID),
                                        new SqlParameter("@FGLD", model.FGLD),
                                        new SqlParameter("@SF", model.SF),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJSJ_BEGIN",model.CJSJ_BEGIN),
                                        new SqlParameter("@CJSJ_END",model.CJSJ_END),
                                        new SqlParameter("@NAME",model.NAME),
                                        new SqlParameter("@STAFFNO",model.STAFFNO),
                                        
                                   };
            IList<CRM_COST_CLFTT> nodes = new List<CRM_COST_CLFTT>();
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

    

        public int Delete(int CLFTTID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CLFTTID", CLFTTID)
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


        private CRM_COST_CLFTT ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_CLFTT node = new CRM_COST_CLFTT();
            node.CLFTTID = Convert.ToInt32(sdr["CLFTTID"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.DEPID = Convert.ToInt32(sdr["DEPID"]);
            node.FGLD = Convert.ToInt32(sdr["FGLD"]);
            node.SF = Convert.ToInt32(sdr["SF"]);
            node.BXRQ = Convert.ToString(sdr["BXRQ"]);
            node.CBZX = Convert.ToInt32(sdr["CBZX"]);
            node.CCSY = Convert.ToString(sdr["CCSY"]);
            node.HJ = Convert.ToDouble(sdr["HJ"]);
            node.ZPYZ = Convert.ToDouble(sdr["ZPYZ"]);
            node.XJYZ = Convert.ToDouble(sdr["XJYZ"]);
            node.BLJE = Convert.ToDouble(sdr["BLJE"]);
            node.GHJE = Convert.ToDouble(sdr["GHJE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.SHR = Convert.ToInt32(sdr["SHR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.SHSJ = Convert.ToDateTime(sdr["SHSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.SHRDES = Convert.ToString(sdr["SHRDES"]);
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.XGRDES = Convert.ToString(sdr["XGRDES"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.JESUM = Convert.ToDouble(sdr["JESUM"]);
            node.DEPALL = Convert.ToInt32(sdr["DEPALL"]);
            node.DEPNAME = Convert.ToString(sdr["DEPNAME"]);
            node.CBZXDES = Convert.ToString(sdr["CBZXDES"]);
            node.FGLDDES = Convert.ToString(sdr["FGLDDES"]);
            return node;
        }
    }
}
