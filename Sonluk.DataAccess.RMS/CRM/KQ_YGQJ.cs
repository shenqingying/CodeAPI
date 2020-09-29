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
    public class KQ_YGQJ : IKQ_YGQJ
    {
        private const string SQL_Create = "CRM_KQ_YGQJ_Create";
        private const string SQL_Update = "CRM_KQ_YGQJ_Update";
        private const string SQL_ReadBySTAFFID = "CRM_KQ_YGQJ_ReadBySTAFFID";//SELECT * FROM CRM_KQ_YGQJ WHERE STAFFID = @STAFFID AND ISDELETE = 0
        private const string SQL_ReadByYGQJID = "CRM_KQ_YGQJ_ReadByYGQJID";//"SELECT * FROM CRM_KQ_YGQJ WHERE YGQJID = @YGQJID AND ISDELETE = 0";
        private const string SQL_Delete = "CRM_KQ_YGQJ_Delete";
        private const string SQL_Verify_QJ = "CRM_Verify_QJ";
        private const string SQL_Read = "CRM_KQ_YGQJ_Read";
        private const string SQL_ReadByDepartRight = "CRM_KQ_YGQJ_ReadByDepartRight";      //按部门权限
        
        
        public int Create(CRM_KQ_YGQJ model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@YGQJID", model.YGQJID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@STAFFNO", model.STAFFNO),
                                        new SqlParameter("@STAFFNAME", model.STAFFNAME),
                                        new SqlParameter("@STAFFSEX", model.STAFFSEX),
                                        new SqlParameter("@DEPNAME", model.DEPNAME),
                                        new SqlParameter("@QJLB", model.QJLB),
                                        new SqlParameter("@QWHC", model.QWHC),
                                        new SqlParameter("@JHQJKSSJ", model.JHQJKSSJ),
                                        new SqlParameter("@JHQJJSSJ", model.JHQJJSSJ),
                                        new SqlParameter("@QJTS", model.QJTS),
                                        new SqlParameter("@ZZ", model.ZZ),
                                        new SqlParameter("@BMLD", model.BMLD),
                                        new SqlParameter("@ZGLD", model.ZGLD),
                                        new SqlParameter("@ZZB", model.ZZB),
                                        new SqlParameter("@SJQJKSSJ", model.SJQJKSSJ),
                                        new SqlParameter("@SJJSKSSJ", model.SJJSKSSJ),
                                        new SqlParameter("@XJRQ", model.XJRQ),
                                        new SqlParameter("@XJZZ", model.XJZZ),
                                        new SqlParameter("@QJR", model.QJR),
                                        new SqlParameter("@QJRQ", model.QJRQ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@BZ",model.BZ),
                                        new SqlParameter("@SJQJTS",model.SJQJTS)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_KQ_YGQJ model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@YGQJID", model.YGQJID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@STAFFNO", model.STAFFNO),
                                        new SqlParameter("@STAFFNAME", model.STAFFNAME),
                                        new SqlParameter("@STAFFSEX", model.STAFFSEX),
                                        new SqlParameter("@DEPNAME", model.DEPNAME),
                                        new SqlParameter("@QJLB", model.QJLB),
                                        new SqlParameter("@QWHC", model.QWHC),
                                        new SqlParameter("@JHQJKSSJ", model.JHQJKSSJ),
                                        new SqlParameter("@JHQJJSSJ", model.JHQJJSSJ),
                                        new SqlParameter("@QJTS", model.QJTS),
                                        new SqlParameter("@ZZ", model.ZZ),
                                        new SqlParameter("@BMLD", model.BMLD),
                                        new SqlParameter("@ZGLD", model.ZGLD),
                                        new SqlParameter("@ZZB", model.ZZB),
                                        new SqlParameter("@SJQJKSSJ", model.SJQJKSSJ),
                                        new SqlParameter("@SJJSKSSJ", model.SJJSKSSJ),
                                        new SqlParameter("@XJRQ", model.XJRQ),
                                        new SqlParameter("@XJZZ", model.XJZZ),
                                        new SqlParameter("@QJR", model.QJR),
                                        new SqlParameter("@QJRQ", model.QJRQ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@BZ",model.BZ),
                                        new SqlParameter("@SJQJTS",model.SJQJTS)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
      
        public IList<CRM_KQ_YGQJList> ReadBySTAFFID(int STAFFID,int STATUS)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@STATUS",STATUS)
                                   };
            IList<CRM_KQ_YGQJList> nodes = new List<CRM_KQ_YGQJList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadBySTAFFID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToYGQJList(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_KQ_YGQJList> Read(CRM_KQ_YGQJ model)
        {
            SqlParameter[] pamrs = {
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@STAFFNO", model.STAFFNO),
                                        new SqlParameter("@STAFFNAME", model.STAFFNAME),
                                        new SqlParameter("@STAFFSEX", model.STAFFSEX),
                                        new SqlParameter("@DEPNAME", model.DEPNAME),
                                        new SqlParameter("@QJLB", model.QJLB),                                       
                                        new SqlParameter("@SJQJKSSJ", model.SJQJKSSJ),
                                        new SqlParameter("@SJJSKSSJ", model.SJJSKSSJ),                                     
                                        new SqlParameter("@QJR", model.QJR),                                     
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)
                                   };
            IList<CRM_KQ_YGQJList> nodes = new List<CRM_KQ_YGQJList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, pamrs))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToYGQJList(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }



        public CRM_KQ_YGQJ ReadByYGQJID(int YGQJID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@YGQJID",YGQJID)
                                   };
            CRM_KQ_YGQJ nodes = new CRM_KQ_YGQJ();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByYGQJID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes = ReadDataToObject(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        public IList<CRM_KQ_YGQJList> ReadByDepartRight(CRM_KQ_YGQJ model)
        {
            SqlParameter[] pamrs = {
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@STAFFNO", model.STAFFNO),
                                        new SqlParameter("@STAFFNAME", model.STAFFNAME),
                                        new SqlParameter("@STAFFSEX", model.STAFFSEX),
                                        new SqlParameter("@DEPNAME", model.DEPNAME),
                                        new SqlParameter("@QJLB", model.QJLB),                                       
                                        new SqlParameter("@SJQJKSSJ", model.SJQJKSSJ),
                                        new SqlParameter("@SJJSKSSJ", model.SJJSKSSJ),                                     
                                        new SqlParameter("@QJR", model.QJR),                                     
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE)
                                   };
            IList<CRM_KQ_YGQJList> nodes = new List<CRM_KQ_YGQJList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByDepartRight, pamrs))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToYGQJList(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        public int Verify_QJ(string beginTime, string endTime, int STAFFID, int YGQJID, int CCID)
        {
            // parms[0].Value = name;
            //parms[1].Value = password;
            //parms[2].Direction = ParameterDirection.Output;
            //parms[3].Direction = ParameterDirection.Output;
            //parms[4].Direction = ParameterDirection.Output;
            SqlParameter[] parms = {
                                       new SqlParameter("@beginTime",SqlDbType.VarChar),
                                       new SqlParameter("@endTime",SqlDbType.VarChar),
                                       new SqlParameter("@STAFFID",SqlDbType.Int),
                                       new SqlParameter("@COUNT_QJ",SqlDbType.Int),
                                       new SqlParameter("@COUNT_CC",SqlDbType.Int),
                                       new SqlParameter("@YGQJID",SqlDbType.Int),
                                       new SqlParameter("@CCID",SqlDbType.Int)
                                   };
            parms[0].Value = beginTime;
            parms[1].Value = endTime;
            parms[2].Value = STAFFID;
            parms[3].Direction = ParameterDirection.Output;
            parms[4].Direction = ParameterDirection.Output;
            parms[5].Value = YGQJID;
            parms[6].Value = CCID;
            int COUNT_QJ = 0, COUNT_CC = 0;
            try
            {
                SQLServerHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_Verify_QJ, parms);
                COUNT_QJ = Convert.ToInt32(parms[3].Value);
                COUNT_CC = Convert.ToInt32(parms[4].Value);
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message); ;
            }
            if (COUNT_CC > 0 && COUNT_QJ > 0)
            {
                return 3;
            }
            if (COUNT_QJ > 0)
            {
                return 1;
            }
            if (COUNT_CC > 0)
            {
                return 2;
            }
            

            return 0;
            

           
        }

        public int Delete(int YGQJID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@YGQJID",YGQJID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }




        private CRM_KQ_YGQJ ReadDataToObject(SqlDataReader sdr)
        {
            CRM_KQ_YGQJ node = new CRM_KQ_YGQJ();
            node.YGQJID = Convert.ToInt32(sdr["YGQJID"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFSEX = Convert.ToString(sdr["STAFFSEX"]);
            node.DEPNAME = Convert.ToInt32(sdr["DEPNAME"]);
            node.QJLB = Convert.ToInt32(sdr["QJLB"]);
            node.QWHC = Convert.ToString(sdr["QWHC"]);
            node.JHQJKSSJ = Convert.ToDateTime(sdr["JHQJKSSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.JHQJJSSJ = Convert.ToDateTime(sdr["JHQJJSSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.QJTS = Convert.ToDouble(sdr["QJTS"]);
            node.SJQJTS = Convert.ToDouble(sdr["SJQJTS"]);
            node.ZZ = Convert.ToString(sdr["ZZ"]);
            node.BMLD = Convert.ToString(sdr["BMLD"]);
            node.ZGLD = Convert.ToString(sdr["ZGLD"]);
            node.ZZB = Convert.ToString(sdr["ZZB"]);
            node.SJQJKSSJ = Convert.ToDateTime(sdr["SJQJKSSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.SJJSKSSJ = Convert.ToDateTime(sdr["SJJSKSSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.XJRQ = Convert.ToString(sdr["XJRQ"]);
            node.XJZZ = Convert.ToString(sdr["XJZZ"]);
            node.QJR = Convert.ToString(sdr["QJR"]);
            node.QJRQ = Convert.ToDateTime(sdr["QJRQ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);
            node.BZ = Convert.ToString(sdr["BZ"]);
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

        private CRM_KQ_YGQJList ReadDataToYGQJList(SqlDataReader sdr)
        {
            CRM_KQ_YGQJList node = new CRM_KQ_YGQJList();
            node.DEPNAMEDES = Convert.ToString(sdr["DEPNAMEDES"]);
            node.QJLBDES = Convert.ToString(sdr["QJLBDES"]);
            node.YGQJID = Convert.ToInt32(sdr["YGQJID"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFSEX = Convert.ToString(sdr["STAFFSEX"]);
            node.DEPNAME = Convert.ToInt32(sdr["DEPNAME"]);
            node.QJLB = Convert.ToInt32(sdr["QJLB"]);
            node.QWHC = Convert.ToString(sdr["QWHC"]);
            node.JHQJKSSJ = Convert.ToDateTime(sdr["JHQJKSSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.JHQJJSSJ = Convert.ToDateTime(sdr["JHQJJSSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.QJTS = Convert.ToDouble(sdr["QJTS"]);
            node.SJQJTS = Convert.ToDouble(sdr["SJQJTS"]);
            node.ZZ = Convert.ToString(sdr["ZZ"]);
            node.BMLD = Convert.ToString(sdr["BMLD"]);
            node.ZGLD = Convert.ToString(sdr["ZGLD"]);
            node.ZZB = Convert.ToString(sdr["ZZB"]);
            node.SJQJKSSJ = Convert.ToDateTime(sdr["SJQJKSSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.SJJSKSSJ = Convert.ToDateTime(sdr["SJJSKSSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.XJRQ = Convert.ToString(sdr["XJRQ"]);
            node.XJZZ = Convert.ToString(sdr["XJZZ"]);
            node.QJR = Convert.ToString(sdr["QJR"]);
            node.QJRQ = Convert.ToDateTime(sdr["QJRQ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);
            node.BZ = Convert.ToString(sdr["BZ"]);
            return node;
        }
    }
}
