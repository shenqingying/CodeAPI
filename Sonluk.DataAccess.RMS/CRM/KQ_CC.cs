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
    public class KQ_CC : IKQ_CC
    {
        private const string SQL_Create_TT = "CRM_KQ_CCTT_Create";
        private const string SQL_Update_TT = "CRM_KQ_CCTT_Update";
        private const string SQL_Read_TTbySTAFFID = @"CRM_KQ_CCTT_TTbySTAFFID";//SELECT *,ISNULL((SELECT DICNAME FROM CRM_HG_DICT WHERE DICID = CXFS),0) AS CXFSDES,ISNULL((SELECT DICNAME FROM CRM_HG_DICT WHERE DICID = QTCXFS),0) AS QTCXFSDES FROM CRM_KQ_CCTT  WHERE ISACTIVE <> 3 AND STAFFID = @STAFFID AND ISDELETE = 0
        private const string SQL_Delete_TT = "CRM_KQ_CCTT_Delete";
        private const string SQLRead_TTByCCID = "CRM_KQ_CC_ReadTTByCCID";//"SELECT * FROM  CRM_KQ_CCTT  WHERE  CCID = @CCID AND ISDELETE = 0";//ISACTIVE <> 3 AND
        private const string SQLRead_TTByParam = "CRM_KQ_CC_ReadTTByParam";

        private const string SQL_Create_MX = "CRM_KQ_CCMX_Create";
        private const string SQL_Update_MX = "CRM_KQ_CCMX_Update";
        private const string SQL_Read_MXbyCCID = "SELECT * FROM CRM_KQ_CCMX WHERE  CCID = @CCID ";//ISACTIVE <> 3 AND
        private const string SQL_Delete_MX = "CRM_KQ_CCMX_Delete";
        private const string SQL_Read_MXQDbyCCID = "CRM_KQ_CCMX_ReadMXQD";


        public int Create_MX(CRM_KQ_CCMX model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@ID", model.ID),
                                        new SqlParameter("@CCID", model.CCID),
                                        new SqlParameter("@DATE", model.DATE),
                                        new SqlParameter("@DD", model.DD),
                                        new SqlParameter("@GZMB", model.GZMB),
                                        new SqlParameter("@MBWCQK", model.MBWCQK),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CCSJLX", model.CCSJLX),
                                        new SqlParameter("@ISQD",model.ISQD)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create_MX, parms);
        }
        public int Update_MX(CRM_KQ_CCMX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@ID", model.ID),
                                        new SqlParameter("@CCID", model.CCID),
                                        new SqlParameter("@DATE", model.DATE),
                                        new SqlParameter("@DD", model.DD),
                                        new SqlParameter("@GZMB", model.GZMB),
                                        new SqlParameter("@MBWCQK", model.MBWCQK),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CCSJLX", model.CCSJLX),
                                        new SqlParameter("@ISQD",model.ISQD)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update_MX, parms);
        }
     
        public IList<CRM_KQ_CCMX> Read_MXbyCCID(int CCID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@CCID",CCID)
                                   };
            IList<CRM_KQ_CCMX> nodes = new List<CRM_KQ_CCMX>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Read_MXbyCCID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToMx(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_KQ_CCMXList> Read_MXQDbyCCID(int CCID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@CCID",CCID)
                                   };
            IList<CRM_KQ_CCMXList> nodes = new List<CRM_KQ_CCMXList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_MXQDbyCCID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToMxQD(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public int Delete_MX(int ID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ID",ID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete_MX, parms);
        }






//-------------------TT-------------------------

        public int Create_TT(CRM_KQ_CCTT model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@CCID", model.CCID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@CCRNAME", model.CCRNAME),
                                        new SqlParameter("@CCRBM", model.CCRBM),
                                        new SqlParameter("@CCDD", model.CCDD),
                                        new SqlParameter("@BQYCC", model.BQYCC),
                                        new SqlParameter("@ZCYWCC", model.ZCYWCC),
                                        new SqlParameter("@JHCCKSSJ", model.JHCCKSSJ),
                                        new SqlParameter("@JHCCJSSJ", model.JHCCJSSJ),
                                        new SqlParameter("@JHCCTS", model.JHCCTS),
                                        new SqlParameter("@CXFS", model.CXFS),
                                        new SqlParameter("@YJJE", model.YJJE),
                                        new SqlParameter("@QTCXFS", model.QTCXFS),
                                        new SqlParameter("@QTCXFSJE", model.QTCXFSJE),
                                        new SqlParameter("@SJJE", model.SJJE),
                                        new SqlParameter("@SJKSSJ", model.SJKSSJ),
                                        new SqlParameter("@SJCCJSSJ", model.SJCCJSSJ),
                                        new SqlParameter("@SJCCTS", model.SJCCTS),
                                        new SqlParameter("@CCSQR", model.CCSQR),
                                        new SqlParameter("@CCSQSJ", model.CCSQSJ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@CCLX",model.CCLX),
                                        new SqlParameter("@BEIZ",model.BEIZ)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create_TT, parms);
        }

        public int Update_TT(CRM_KQ_CCTT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@CCID", model.CCID),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@CCRNAME", model.CCRNAME),
                                        new SqlParameter("@CCRBM", model.CCRBM),
                                        new SqlParameter("@CCDD", model.CCDD),
                                        new SqlParameter("@BQYCC", model.BQYCC),
                                        new SqlParameter("@ZCYWCC", model.ZCYWCC),
                                        new SqlParameter("@JHCCKSSJ", model.JHCCKSSJ),
                                        new SqlParameter("@JHCCJSSJ", model.JHCCJSSJ),
                                        new SqlParameter("@JHCCTS", model.JHCCTS),
                                        new SqlParameter("@CXFS", model.CXFS),
                                        new SqlParameter("@YJJE", model.YJJE),
                                        new SqlParameter("@QTCXFS", model.QTCXFS),
                                        new SqlParameter("@QTCXFSJE", model.QTCXFSJE),
                                        new SqlParameter("@SJJE", model.SJJE),
                                        new SqlParameter("@SJKSSJ", model.SJKSSJ),
                                        new SqlParameter("@SJCCJSSJ", model.SJCCJSSJ),
                                        new SqlParameter("@SJCCTS", model.SJCCTS),
                                        new SqlParameter("@CCSQR", model.CCSQR),
                                        new SqlParameter("@CCSQSJ", model.CCSQSJ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@ISDELETE",model.ISDELETE),
                                        new SqlParameter("@CCLX",model.CCLX),
                                        new SqlParameter("@BEIZ",model.BEIZ)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update_TT, parms);
        }
       
        public IList<CRM_KQ_CCTTList> Read_TTbySTAFFID(int STAFFID,int Status)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID),
                                       new SqlParameter("@STATUS",Status)
                                   };
            IList<CRM_KQ_CCTTList> nodes = new List<CRM_KQ_CCTTList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_TTbySTAFFID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToTTobjList(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public CRM_KQ_CCTT Read_TTbyCCID(int CCID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@CCID",CCID)
                                   };
            CRM_KQ_CCTT nodes = new CRM_KQ_CCTT();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQLRead_TTByCCID, parms))
                {
                    if (sdr.Read())
                    {
                        nodes = ReadDataToTTobj(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_KQ_CCTTList> Read_TTbyParam(CRM_KQ_CCTT model,int STATUS)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@SJKSSJ",model.SJKSSJ),
                                       new SqlParameter("@SJCCJSSJ",model.SJCCJSSJ),
                                       new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                       new SqlParameter("@STAFFID",model.STAFFID),
                                       new SqlParameter("@STATUS",STATUS)
                                   };
            IList<CRM_KQ_CCTTList> nodes = new List<CRM_KQ_CCTTList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQLRead_TTByParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToTTobjList(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public int Delete_TT(int CCID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@CCID",CCID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete_TT, parms);

        }






        private CRM_KQ_CCMX ReadDataToMx(SqlDataReader sdr)
        {
            CRM_KQ_CCMX node = new CRM_KQ_CCMX();
            node.ID = Convert.ToInt32(sdr["ID"]);
            node.CCID = Convert.ToInt32(sdr["CCID"]);
            node.DATE = Convert.ToString(sdr["DATE"]);
            node.DD = Convert.ToString(sdr["DD"]);
            node.GZMB = Convert.ToString(sdr["GZMB"]);
            node.MBWCQK = Convert.ToString(sdr["MBWCQK"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CCSJLX = Convert.ToInt32(sdr["CCSJLX"]);
            node.ISQD = Convert.ToBoolean(sdr["ISQD"]);
            return node;    
        }

        private CRM_KQ_CCMXList ReadDataToMxQD(SqlDataReader sdr)
        {
            CRM_KQ_CCMXList node = new CRM_KQ_CCMXList();
            node.ID = Convert.ToInt32(sdr["ID"]);
            node.CCID = Convert.ToInt32(sdr["CCID"]);
            node.DATE = Convert.ToString(sdr["DATE"]);
            node.DD = Convert.ToString(sdr["DD"]);
            node.GZMB = Convert.ToString(sdr["GZMB"]);
            node.MBWCQK = Convert.ToString(sdr["MBWCQK"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CCSJLX = Convert.ToInt32(sdr["CCSJLX"]);
            node.ISQD = Convert.ToBoolean(sdr["ISQD"]);

            //node.KQQDID = Convert.ToInt32(sdr["KQQDID"]);
            //node.QDLX = Convert.ToInt32(sdr["QDLX"]);
            //node.QDGSID = Convert.ToInt32(sdr["QDGSID"]);
            //node.QDGSHXMID = Convert.ToInt32(sdr["QDGSHXMID"]);
            //node.SXB = Convert.ToInt32(sdr["SXB"]);
            node.QDSJ = Convert.ToDateTime(sdr["QDSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            //node.GJ = Convert.ToInt32(sdr["GJ"]);
            //node.SF = Convert.ToInt32(sdr["SF"]);
            //node.SFDES = Convert.ToString(sdr["SFDES"]);
            //node.CS = Convert.ToInt32(sdr["CS"]);
            //node.CSDES = Convert.ToString(sdr["CSDES"]);
            node.QDWZ = Convert.ToString(sdr["QDWZ"]);
            //node.QDJD = Convert.ToString(sdr["QDJD"]);
            //node.QDWD = Convert.ToString(sdr["QDWD"]);
            //node.KQJL = Convert.ToString(sdr["KQJL"]);
            //node.QDISACTIVE = Convert.ToInt32(sdr["QDISACTIVE"]);
            //node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            return node;
        }





        private CRM_KQ_CCTT ReadDataToTTobj(SqlDataReader sdr)
        {
            CRM_KQ_CCTT node = new CRM_KQ_CCTT();
            node.CCID = Convert.ToInt32(sdr["CCID"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.CCRNAME = Convert.ToString(sdr["CCRNAME"]);
            node.CCRBM = Convert.ToString(sdr["CCRBM"]);
            node.CCDD = Convert.ToString(sdr["CCDD"]);
            node.BQYCC = Convert.ToBoolean(sdr["BQYCC"]);
            node.ZCYWCC = Convert.ToBoolean(sdr["ZCYWCC"]);
            node.JHCCKSSJ = Convert.ToDateTime(sdr["JHCCKSSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.JHCCJSSJ = Convert.ToDateTime(sdr["JHCCJSSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.JHCCTS = Convert.ToDouble(sdr["JHCCTS"]);
            node.CXFS = Convert.ToInt32(sdr["CXFS"]);
            node.YJJE = Convert.ToDecimal(sdr["YJJE"]);
            node.QTCXFS = Convert.ToInt32(sdr["QTCXFS"]);
            node.QTCXFSJE = Convert.ToDecimal(sdr["QTCXFSJE"]);
            node.SJJE = Convert.ToDecimal(sdr["SJJE"]);
            node.SJKSSJ = Convert.ToDateTime(sdr["SJKSSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.SJCCJSSJ = Convert.ToDateTime(sdr["SJCCJSSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.SJCCTS = Convert.ToDouble(sdr["SJCCTS"]);
            node.CCSQR = Convert.ToString(sdr["CCSQR"]);
            node.CCSQSJ = Convert.ToDateTime(sdr["CCSQSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);
            node.CCLX = Convert.ToInt32(sdr["CCLX"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            return node;
        }

        private CRM_KQ_CCTTList ReadDataToTTobjList(SqlDataReader sdr)
        {
            CRM_KQ_CCTTList node = new CRM_KQ_CCTTList();
            node.CCID = Convert.ToInt32(sdr["CCID"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.CCRNAME = Convert.ToString(sdr["CCRNAME"]);
            node.CCRBM = Convert.ToString(sdr["CCRBM"]);
            node.CCDD = Convert.ToString(sdr["CCDD"]);
            node.BQYCC = Convert.ToBoolean(sdr["BQYCC"]);
            node.ZCYWCC = Convert.ToBoolean(sdr["ZCYWCC"]);
            node.JHCCKSSJ = Convert.ToDateTime(sdr["JHCCKSSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.JHCCJSSJ = Convert.ToDateTime(sdr["JHCCJSSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.JHCCTS = Convert.ToDouble(sdr["JHCCTS"]);
            node.CXFS = Convert.ToInt32(sdr["CXFS"]);
            node.YJJE = Convert.ToDecimal(sdr["YJJE"]);
            node.QTCXFS = Convert.ToInt32(sdr["QTCXFS"]);
            node.QTCXFSJE = Convert.ToDecimal(sdr["QTCXFSJE"]);
            node.SJJE = Convert.ToDecimal(sdr["SJJE"]);
            node.SJKSSJ = Convert.ToDateTime(sdr["SJKSSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.SJCCJSSJ = Convert.ToDateTime(sdr["SJCCJSSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.SJCCTS = Convert.ToDouble(sdr["SJCCTS"]);
            node.CCSQR = Convert.ToString(sdr["CCSQR"]);
            node.CCSQSJ = Convert.ToDateTime(sdr["CCSQSJ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);
            node.CXFSDES = Convert.ToString(sdr["CXFSDES"]);
            node.QTCXFSDES = Convert.ToString(sdr["QTCXFSDES"]);
            node.CCLX = Convert.ToInt32(sdr["CCLX"]);
            node.CCLXDES = Convert.ToString(sdr["CCLXDES"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
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
