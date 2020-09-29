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
    public class KH_HD : IKH_HD
    {
        private const string SQL_Create = "CRM_KH_HD_Create";
        private const string SQL_Update = "CRM_KH_HD_Update";
        private const string SQL_Delete = "CRM_KH_HD_Delete";
        private const string SQL_ReadByKHID = "CRM_KH_HD_ReadByKHID";
        private const string SQL_ReadByID = "CRM_KH_HD_ReadByID";



        public int Create(CRM_KH_HD model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@KHID",model.KHID),
                                        new SqlParameter("@HDMC",model.HDMC),
                                        new SqlParameter("@HDTC",model.HDTC),
                                        new SqlParameter("@CPLX",model.CPLX),
                                        new SqlParameter("@XL",model.XL),
                                        new SqlParameter("@HDCL",model.HDCL),
                                        new SqlParameter("@BEIZ",model.BEIZ),
                                        new SqlParameter("@CZR",model.CZR),
                                        new SqlParameter("@CZSJ",model.CZSJ)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }


        public int Update(CRM_KH_HD model)
        {
            SqlParameter[] parms = {
                                         new SqlParameter("@HDID",model.HDID),
                                        new SqlParameter("@KHID",model.KHID),
                                        new SqlParameter("@HDMC",model.HDMC),
                                        new SqlParameter("@HDTC",model.HDTC),
                                        new SqlParameter("@CPLX",model.CPLX),
                                        new SqlParameter("@XL",model.XL),
                                        new SqlParameter("@HDCL",model.HDCL),
                                        new SqlParameter("@BEIZ",model.BEIZ),
                                        new SqlParameter("@CZR",model.CZR),
                                        new SqlParameter("@CZSJ",model.CZSJ),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public int Delete(int HDID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@HDID",HDID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }

        public IList<CRM_KH_HDList> ReadByKHID(int KHID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID)
                                   };
            IList<CRM_KH_HDList> nodes = new List<CRM_KH_HDList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByKHID, parms))
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


        public CRM_KH_HD ReadByID(int HDID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@HDID",HDID)
                                   };
            CRM_KH_HD nodes = new CRM_KH_HD();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByID, parms))
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



        private CRM_KH_HDList ReadDataToObjectList(SqlDataReader sdr)
        {
            CRM_KH_HDList node = new CRM_KH_HDList();
            node.HDID = Convert.ToInt32(sdr["HDID"]);
            node.KHMC = Convert.ToString(sdr["KHMC"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.HDMC = Convert.ToInt32(sdr["HDMC"]);
            node.HDMCDES = Convert.ToString(sdr["HDMCDES"]);
            node.CPLX = Convert.ToInt32(sdr["CPLX"]);
            node.CPLXDES = Convert.ToString(sdr["CPLXDES"]);
            node.XL = Convert.ToString(sdr["XL"]);
            node.CZRDES = Convert.ToString(sdr["CZRDES"]);
            node.CZR = Convert.ToInt32(sdr["CZR"]);
            node.CZSJ = Convert.ToDateTime(sdr["CZSJ"]).ToString("yyyy-MM-dd");
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);
            node.HDTC = Convert.ToInt32(sdr["HDTC"]);
            node.HDCL = Convert.ToInt32(sdr["HDCL"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.HDTCDES = Convert.ToString(sdr["HDTCDES"]);
            node.HDCLDES = Convert.ToString(sdr["HDCLDES"]);
            node.IMGCOUNT = Convert.ToInt32(sdr["IMGCOUNT"]);
            return node;
        }

        private CRM_KH_HD ReadDataToObject(SqlDataReader sdr)
        {
            CRM_KH_HD node = new CRM_KH_HD();
            node.HDID = Convert.ToInt32(sdr["HDID"]);
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.HDMC = Convert.ToInt32(sdr["HDMC"]);
            node.CPLX = Convert.ToInt32(sdr["CPLX"]);
            node.XL = Convert.ToString(sdr["XL"]);
            node.CZR = Convert.ToInt32(sdr["CZR"]);
            node.CZSJ = Convert.ToDateTime(sdr["CZSJ"]).ToString("yyyy-MM-dd");
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);
            node.HDTC = Convert.ToInt32(sdr["HDTC"]);
            node.HDCL = Convert.ToInt32(sdr["HDCL"]);
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
