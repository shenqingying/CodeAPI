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
    public class KH_LXR : IKH_LXR
    {
        private const string SQL_Create = "CRM_KH_LXR_Create";
        private const string SQL_Update = "CRM_KH_LXR_Update";
        private const string SQL_Read = "CRM_KH_LXR_Read";//@"SELECT CRM_KH_LXR.*,ISNULL((SELECT DICNAME FROM CRM_HG_DICT WHERE DICID = MZ),' ') AS MZDES,ISNULL((SELECT DICNAME FROM CRM_HG_DICT WHERE DICID = ZW),' ') AS ZWDES FROM CRM_KH_LXR WHERE ISACTIVE = 1 AND KHID = @KHID";
        private const string SQL_Delete = "CRM_KH_LXR_Delete";
        private const string SQL_DeleteByKHID = "CRM_KH_LXR_DeleteByKHID";

         
        public int Create(CRM_KH_LXR model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@LB",model.LB),
                                        new SqlParameter("@KHID",model.KHID),
                                        new SqlParameter("@LXR",model.LXR),
                                        new SqlParameter("@SEX",model.SEX),
                                        new SqlParameter("@JTDZ",model.JTDZ),
                                        new SqlParameter("@JG",model.JG),
                                        new SqlParameter("@MZ",model.MZ),
                                        new SqlParameter("@ZW",model.ZW),
                                        new SqlParameter("@AH",model.AH),
                                        new SqlParameter("@HYZK",model.HYZK),
                                        new SqlParameter("@YDDH",model.YDDH),
                                        new SqlParameter("@GDDH",model.GDDH),
                                        new SqlParameter("@TEL",model.TEL),
                                        new SqlParameter("@EMAIL",model.EMAIL),
                                        new SqlParameter("@WXH",model.WXH),
                                        new SqlParameter("@SR",model.SR),
                                        new SqlParameter("@TXDZ",model.TXDZ),
                                        new SqlParameter("@YZBM",model.YZBM),
                                        new SqlParameter("@XGMS",model.XGMS),
                                        new SqlParameter("@PHOTO",model.PHOTO),
                                        new SqlParameter("@SFZYLXR",model.SFZYLXR),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                        new SqlParameter("@BEIZ",model.BEIZ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_KH_LXR model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KHLXRID",model.KHLXRID),
                                        new SqlParameter("@KHID",model.KHID),
                                        new SqlParameter("@LXR",model.LXR),
                                        new SqlParameter("@SEX",model.SEX),
                                        new SqlParameter("@JTDZ",model.JTDZ),
                                        new SqlParameter("@JG",model.JG),
                                        new SqlParameter("@MZ",model.MZ),
                                        new SqlParameter("@ZW",model.ZW),
                                        new SqlParameter("@AH",model.AH),
                                        new SqlParameter("@HYZK",model.HYZK),
                                        new SqlParameter("@YDDH",model.YDDH),
                                        new SqlParameter("@GDDH",model.GDDH),
                                        new SqlParameter("@TEL",model.TEL),
                                        new SqlParameter("@EMAIL",model.EMAIL),
                                        new SqlParameter("@WXH",model.WXH),
                                        new SqlParameter("@SR",model.SR),
                                        new SqlParameter("@TXDZ",model.TXDZ),
                                        new SqlParameter("@YZBM",model.YZBM),
                                        new SqlParameter("@XGMS",model.XGMS),
                                        new SqlParameter("@PHOTO",model.PHOTO),
                                        new SqlParameter("@SFZYLXR",model.SFZYLXR),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                        new SqlParameter("@BEIZ",model.BEIZ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
       

      

        public IList<CRM_KH_LXRList> Read(int KHID,int LB)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID),
                                       new SqlParameter("@LB",LB)
                                   };
            IList<CRM_KH_LXRList> nodes = new List<CRM_KH_LXRList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObject(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public int Delete(int KHLXRID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHLXRID",KHLXRID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }
        public int DeleteByKHID(int KHID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID)
                                   };
            return SQLServerHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_DeleteByKHID, parms);
        }



        private CRM_KH_LXRList ReadDataToObject(SqlDataReader sdr)
        {
            CRM_KH_LXRList node = new CRM_KH_LXRList();
            node.KHLXRID = Convert.ToInt32(sdr["KHLXRID"]);
            node.LB = Convert.ToInt32(sdr["LB"]);
            node.LBDES = Convert.ToString(sdr["LBDES"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.LXR = Convert.ToString(sdr["LXR"]);
            node.SEX = Convert.ToString(sdr["SEX"]);
            node.JTDZ = Convert.ToString(sdr["JTDZ"]);
            node.JG = Convert.ToString(sdr["JG"]);
            node.MZ = Convert.ToInt32(sdr["MZ"]);
            node.ZW = Convert.ToInt32(sdr["ZW"]);
            node.AH = Convert.ToString(sdr["AH"]);
            node.HYZK = Convert.ToInt32(sdr["HYZK"]);
            node.HYZKDES = Convert.ToString(sdr["HYZKDES"]);
            node.YDDH = Convert.ToString(sdr["YDDH"]);
            node.GDDH = Convert.ToString(sdr["GDDH"]);
            node.TEL = Convert.ToString(sdr["TEL"]);
            node.EMAIL = Convert.ToString(sdr["EMAIL"]);
            node.WXH = Convert.ToString(sdr["WXH"]);
            node.SR = Convert.ToString(sdr["SR"]);
            node.TXDZ = Convert.ToString(sdr["TXDZ"]);
            node.YZBM = Convert.ToString(sdr["YZBM"]);
            node.XGMS = Convert.ToString(sdr["XGMS"]);
            node.PHOTO = Convert.ToString(sdr["PHOTO"]);
            node.SFZYLXR = Convert.ToInt32(sdr["SFZYLXR"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ZWDES = Convert.ToString(sdr["ZWDES"]);
            node.MZDES = Convert.ToString(sdr["MZDES"]);
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
