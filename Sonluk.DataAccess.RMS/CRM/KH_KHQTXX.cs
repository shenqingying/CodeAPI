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
    public class KH_KHQTXX : IKH_KHQTXX
    {
        private const string SQL_Create = "CRM_KH_KHQTXX_Create";
        private const string SQL_Update = "CRM_KH_KHQTXX_Update";
        private const string SQL_Read = "CRM_KH_KHQTXX_Read";//@"SELECT CRM_KH_KHQTXX.*,ISNULL((SELECT DICNAME FROM CRM_HG_DICT WHERE DICID = CLFS),0) AS CLFSDES FROM CRM_KH_KHQTXX WHERE ISACTIVE = 1 AND KHID = @KHID AND XXLB = @XXLB";
        private const string SQL_Delete = "CRM_KH_KHQTXX_Delete";
        private const string SQL_DeleteByKHID_XXLB = "UPDATE CRM_KH_KHQTXX SET ISACTIVE = 0 WHERE KHID = @KHID AND XXLB = @XXLB AND ISACTIVE = 1";

       


        public int Create(CRM_KH_KHQTXX model)
        {
            SqlParameter[] parms = {
                                       // new SqlParameter("@XXID",model.XXID),
                                        new SqlParameter("@KHID",model.KHID),
                                        new SqlParameter("@XXLB",model.XXLB),
                                        new SqlParameter("@XXMC",model.XXMC),
                                        new SqlParameter("@CLLX",model.CLLX),
                                        new SqlParameter("@CLFS",model.CLFS),
                                        new SqlParameter("@CLGSRQ",model.CLGSRQ),
                                        new SqlParameter("@CLGSJSRQ",model.CLGSJSRQ),
                                        new SqlParameter("@DISPLAYITEM",model.DISPLAYITEM),
                                        new SqlParameter("@KHYJDZ",model.KHYJDZ),
                                        new SqlParameter("@YB",model.YB),
                                        new SqlParameter("@SJR",model.SJR),
                                        new SqlParameter("@SJRLXFS",model.SJRLXFS),
                                        new SqlParameter("@CZR",model.CZR),
                                        //new SqlParameter("@CZRQ",model.CZRQ),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                        new SqlParameter("@BEIZ",model.BEIZ),
                                        new SqlParameter("@PD",model.PD)
                                    };

            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_KH_KHQTXX model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@XXID",model.XXID),
                                        new SqlParameter("@KHID",model.KHID),
                                        new SqlParameter("@XXLB",model.XXLB),
                                        new SqlParameter("@XXMC",model.XXMC),
                                        new SqlParameter("@CLLX",model.CLLX),
                                        new SqlParameter("@CLFS",model.CLFS),
                                        new SqlParameter("@CLGSRQ",model.CLGSRQ),
                                        new SqlParameter("@CLGSJSRQ",model.CLGSJSRQ),
                                        new SqlParameter("@DISPLAYITEM",model.DISPLAYITEM),
                                        new SqlParameter("@KHYJDZ",model.KHYJDZ),
                                        new SqlParameter("@YB",model.YB),
                                        new SqlParameter("@SJR",model.SJR),
                                        new SqlParameter("@SJRLXFS",model.SJRLXFS),
                                        new SqlParameter("@CZR",model.CZR),
                                        new SqlParameter("@CZRQ",model.CZRQ),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                        new SqlParameter("@BEIZ",model.BEIZ),
                                        new SqlParameter("@PD",model.PD)
                                    };

            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

      

        public IList<CRM_KH_KHQTXXList> Read(int KHID, int XXLB)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID),
                                       new SqlParameter("@XXLB",XXLB)
                                   };
            IList<CRM_KH_KHQTXXList> nodes = new List<CRM_KH_KHQTXXList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_Read,parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObjerct(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;

        }

        public int DeleteByKHID_XXLB(int KHID, int XXLB)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID),
                                       new SqlParameter("@XXLB",XXLB)
                                   };
            int count = 0;
            try
            {
               count = SQLServerHelper.ExecuteNonQuery(CommandType.Text,SQL_DeleteByKHID_XXLB,parms);
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return count;
        }
        public int Delete(int XXID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@XXID",XXID)
                                      
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }




        private CRM_KH_KHQTXXList ReadDataToObjerct(SqlDataReader sdr)
        {
            CRM_KH_KHQTXXList node = new CRM_KH_KHQTXXList();
            node.XXID = Convert.ToInt32(sdr["XXID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.XXLB = Convert.ToInt32(sdr["XXLB"]);
            node.XXMC = Convert.ToString(sdr["XXMC"]);
            node.CLLX = Convert.ToInt32(sdr["CLLX"]);
            node.CLFS = Convert.ToInt32(sdr["CLFS"]);
            node.CLGSRQ = Convert.ToString(sdr["CLGSRQ"]);
            node.CLGSJSRQ = Convert.ToString(sdr["CLGSJSRQ"]);
            node.DISPLAYITEM = Convert.ToInt32(sdr["DISPLAYITEM"]);
            node.KHYJDZ = Convert.ToString(sdr["KHYJDZ"]);
            node.YB = Convert.ToString(sdr["YB"]);
            node.SJR = Convert.ToString(sdr["SJR"]);
            node.SJRLXFS = Convert.ToString(sdr["SJRLXFS"]);
            node.CZR = Convert.ToInt32(sdr["CZR"]);
            node.CZRQ = Convert.ToDateTime(sdr["CZRQ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.CLFSDES = Convert.ToString(sdr["CLFSDES"]);
            node.PD = Convert.ToInt32(sdr["PD"]);
            node.DisplayImgCount = Convert.ToInt32(sdr["DisplayImgCount"]);
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
