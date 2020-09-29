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
    public class COST_CXY : ICOST_CXY
    {
        private const string SQL_Create = "CRM_COST_CXY_Create";
        private const string SQL_Update = "CRM_COST_CXY_Update";
        private const string SQL_ReadByParam = "CRM_COST_CXY_ReadByParam";
        private const string SQL_Delete = "CRM_COST_CXY_Delete";
        private const string SQL_ReadByGZ = "CRM_COST_CXY_ReadByGZ";




        public int Create(CRM_COST_CXY model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@MDID", model.MDID),
                                        new SqlParameter("@FZR", model.FZR),
                                        new SqlParameter("@LAST3", model.LAST3),
                                        new SqlParameter("@LAST2", model.LAST2),
                                        new SqlParameter("@LAST1", model.LAST1),
                                        new SqlParameter("@XSZE", model.XSZE),
                                        new SqlParameter("@ZYZC", model.ZYZC),
                                        new SqlParameter("@GW", model.GW),
                                        new SqlParameter("@ISCHANGE", model.ISCHANGE),
                                        new SqlParameter("@BASE", model.BASE),
                                        new SqlParameter("@YGXSE", model.YGXSE),
                                        new SqlParameter("@NAME", model.NAME),
                                        new SqlParameter("@SEX", model.SEX),
                                        new SqlParameter("@ZZZT", model.ZZZT),
                                        new SqlParameter("@CODE", model.CODE),
                                        new SqlParameter("@TEL", model.TEL),
                                        new SqlParameter("@SGRQ", model.SGRQ),
                                        new SqlParameter("@BANK", model.BANK),
                                        new SqlParameter("@CARDNUM", model.CARDNUM),
                                        new SqlParameter("@QZCS", model.QZCS),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR),
                                        new SqlParameter("@GWGZ", model.GWGZ),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@CXYCOUNT", model.CXYCOUNT),
                                        new SqlParameter("@LZSJ", model.LZSJ),
                                       
                                    
                                      
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_COST_CXY model)
        {
            SqlParameter[] parms = {
                                         new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@MDID", model.MDID),
                                        new SqlParameter("@FZR", model.FZR),
                                        new SqlParameter("@LAST3", model.LAST3),
                                        new SqlParameter("@LAST2", model.LAST2),
                                        new SqlParameter("@LAST1", model.LAST1),
                                        new SqlParameter("@XSZE", model.XSZE),
                                        new SqlParameter("@ZYZC", model.ZYZC),
                                        new SqlParameter("@GW", model.GW),
                                        new SqlParameter("@ISCHANGE", model.ISCHANGE),
                                        new SqlParameter("@BASE", model.BASE),
                                        new SqlParameter("@YGXSE", model.YGXSE),
                                        new SqlParameter("@NAME", model.NAME),
                                        new SqlParameter("@SEX", model.SEX),
                                        new SqlParameter("@ZZZT", model.ZZZT),
                                        new SqlParameter("@CODE", model.CODE),
                                        new SqlParameter("@TEL", model.TEL),
                                        new SqlParameter("@SGRQ", model.SGRQ),
                                        new SqlParameter("@BANK", model.BANK),
                                        new SqlParameter("@CARDNUM", model.CARDNUM),
                                        new SqlParameter("@QZCS", model.QZCS),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        
                                        new SqlParameter("@XGR", model.XGR),
                                        new SqlParameter("@CXYID", model.CXYID),
                                        new SqlParameter("@GWGZ", model.GWGZ),
                                        new SqlParameter("@COSTITEMID", model.COSTITEMID),
                                        new SqlParameter("@CXYCOUNT", model.CXYCOUNT),
                                        new SqlParameter("@LZSJ", model.LZSJ),
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

  

        public IList<CRM_COST_CXY> ReadByParam(CRM_COST_CXY model,int STAFFID)
        {
            SqlParameter[] parms = {  
                                        new SqlParameter("@CXYID", model.CXYID),
                                        new SqlParameter("@KHID", model.KHID),
                                        new SqlParameter("@MDID", model.MDID),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@NAME", model.NAME),
                                        new SqlParameter("@SEX", model.SEX),
                                        new SqlParameter("@ZZZT", model.ZZZT),
                                        new SqlParameter("@GW", model.GW),
                                        new SqlParameter("@MDMC", model.MDMC),
                                        new SqlParameter("@XTMC", model.XTMC),
                                        new SqlParameter("@STAFFID",STAFFID),
                                        
                                        
                                   };
            IList<CRM_COST_CXY> nodes = new List<CRM_COST_CXY>();
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

        public IList<CRM_COST_CXY> ReadByGZ(CRM_COST_CXY model)
        {
            SqlParameter[] parms = {  
                                       new SqlParameter("@CXYID", model.CXYID),
                                        new SqlParameter("@NAME", model.NAME),
                                        new SqlParameter("@ZZZT", model.ZZZT),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@SALARY_MONTH", model.SALARY_MONTH),
                                        new SqlParameter("@SALARY_YEAR", model.SALARY_YEAR),
                                   };
            IList<CRM_COST_CXY> nodes = new List<CRM_COST_CXY>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByGZ, parms))
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


        public int Delete(int CXYID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CXYID", CXYID)
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


        private CRM_COST_CXY ReadDataToObj(SqlDataReader sdr)
        {
            CRM_COST_CXY node = new CRM_COST_CXY();
            node.CXYID = Convert.ToInt32(sdr["CXYID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.MDID = Convert.ToInt32(sdr["MDID"]);
            node.FZR = Convert.ToInt32(sdr["FZR"]);
            node.LAST3 = Convert.ToDouble(sdr["LAST3"]);
            node.LAST2 = Convert.ToDouble(sdr["LAST2"]);
            node.LAST1 = Convert.ToDouble(sdr["LAST1"]);
            node.XSZE = Convert.ToDouble(sdr["XSZE"]);
            node.ZYZC = Convert.ToString(sdr["ZYZC"]);
            node.GW = Convert.ToInt32(sdr["GW"]);
            node.BASE = Convert.ToDouble(sdr["BASE"]);
            node.YGXSE = Convert.ToDouble(sdr["YGXSE"]);
            node.NAME = Convert.ToString(sdr["NAME"]);
            node.SEX = Convert.ToInt32(sdr["SEX"]);
            node.ZZZT = Convert.ToInt32(sdr["ZZZT"]);
            node.CODE = Convert.ToString(sdr["CODE"]);
            node.TEL = Convert.ToString(sdr["TEL"]);
          //  node.SGRQ = Convert.ToDateTime(sdr["SGRQ"]).ToString("yyyy-MM-dd");
            node.SGRQ = Convert.ToString(sdr["SGRQ"]);
            node.BANK = Convert.ToString(sdr["BANK"]);
            node.CARDNUM = Convert.ToString(sdr["CARDNUM"]);
            node.QZCS = Convert.ToString(sdr["QZCS"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.SFDES = Convert.ToString(sdr["SFDES"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.SAPSN = Convert.ToString(sdr["SAPSN"]);
            node.GWGZ = Convert.ToDouble(sdr["GWGZ"]);
            node.PKHIDDES = Convert.ToString(sdr["PKHIDDES"]);
            node.COSTITEMID = Convert.ToInt32(sdr["COSTITEMID"]);
            node.CXYCOUNT = Convert.ToInt32(sdr["CXYCOUNT"]);
            node.GWDES = Convert.ToString(sdr["GWDES"]);
            node.CJRDES = Convert.ToString(sdr["CJRDES"]);
            node.ZZZTDES = Convert.ToString(sdr["ZZZTDES"]);
            node.ISCHANGE = Convert.ToInt32(sdr["ISCHANGE"]);
            node.LZSJ = Convert.ToString(sdr["LZSJ"]);
            return node;
        }
    }
}
