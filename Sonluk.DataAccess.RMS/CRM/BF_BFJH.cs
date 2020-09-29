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
    public class BF_BFJH : IBF_BFJH
    {
        private const string SQL_Create = "CRM_BF_BFJH_Create";
        private const string SQL_Update = "CRM_BF_BFJH_Update";
        private const string SQL_Read = "CRM_BF_BFJH_Read";
        private const string SQL_ReadByParams = "CRM_BF_BFJH_ReadByparams";
        private const string SQL_Delete = "CRM_BF_BFJH_Delete";
        private const string SQL_Report_STAFF = "CRM_BF_STAFF_REPORT";
        private const string SQL_Report_KH = "CRM_BF_KH_REPORT";
        private const string SQL_Read_KHandGroupByStaff = "CRM_KH_KHandGroupByStaff";
        private const string SQL_ReadByID = "CRM_BF_BFJH_ReadByID";//"SELECT * FROM CRM_BF_BFJH WHERE BFJHID = @BFJHID ";


        public int Create(CRM_BF_BFJH model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@BFJHID", model.BFJHID),
                                        new SqlParameter("@BFLX", model.BFLX),
                                        new SqlParameter("@BFJHMC", model.BFJHMC),
                                        new SqlParameter("@KSSJ", model.KSSJ),
                                        new SqlParameter("@JSSJ", model.JSSJ),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@CJSJ", model.CJSJ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@ISDELETE", model.ISDELETE)


                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }
        public int Update(CRM_BF_BFJH model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@BFJHID", model.BFJHID),
                                        new SqlParameter("@BFLX", model.BFLX),
                                        new SqlParameter("@BFJHMC", model.BFJHMC),
                                        new SqlParameter("@KSSJ", model.KSSJ),
                                        new SqlParameter("@JSSJ", model.JSSJ),
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@CJSJ", model.CJSJ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@ISDELETE", model.ISDELETE)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
       
        public IList<CRM_BF_BFJHList> ReadByParams(int BFLX, string BFJHMC, string FROMDATE, string TODATE,int STAFFID)
        {
            SqlParameter[] pamrs = {
                                       new SqlParameter("@BFLX",BFLX),
                                       new SqlParameter("@BFJHMC",BFJHMC),
                                       new SqlParameter("@FROMDATE",FROMDATE),
                                       new SqlParameter("@TODATE",TODATE),
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
            IList<CRM_BF_BFJHList> nodes = new List<CRM_BF_BFJHList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_ReadByParams,pamrs))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToListObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;
        }
        public CRM_BF_BFJH ReadByID(int BFJHID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BFJHID",BFJHID)
                                   };
            CRM_BF_BFJH node = new CRM_BF_BFJH();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_ReadByID,parms))
                {
                    if (sdr.Read())
                    {
                        node = ReadDataToObj(sdr);
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return node;
        }

        //public IList<CRM_BF_BFJHList> Report(CRM_BF_BFJH model)
        //{
        //    SqlParameter[] parms = {
                                     

        //                           };
        //    IList<CRM_BF_BFJHList> nodes = new List<CRM_BF_BFJHList>();
        //    try
        //    {
        //        using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
        //        {
        //            while (sdr.Read())
        //            {
        //                nodes.Add(ReadDataToObj(sdr));
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        throw new ApplicationException(e.Message);
        //    }
        //    return nodes;
        //}


        public IList<CRM_BF_STAFFList> Report_STAFF(CRM_BF_STAFFList model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@DEPID",model.DEPID),
                                       new SqlParameter("@STAFFNO",model.STAFFNO),
                                       new SqlParameter("@STAFFLX",model.STAFFLX),
                                       new SqlParameter("@STAFFNAME",model.STAFFNAME),
                                       new SqlParameter("@BFPC",model.BFPC)
                                    };
            IList<CRM_BF_STAFFList> nodes = new List<CRM_BF_STAFFList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_Report_STAFF,parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadToSTAFF(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;
        }
        public IList<CRM_BF_KHList> Report_KH(CRM_BF_KHList model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@CRMID",model.CRMID),
                                       new SqlParameter("@KHLX",model.KHLX),
                                       new SqlParameter("@CS",model.CS),
                                       new SqlParameter("@MC",model.MC),
                                       new SqlParameter("@BFPC",model.BFPC)
                                   };
            IList<CRM_BF_KHList> nodes = new List<CRM_BF_KHList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report_KH, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadToKH(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }




        public void Read_BFJHList(int STAFFID)
        {
            SqlParameter[] parms_KH = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read_KHandGroupByStaff, parms_KH))
                {
                    while (sdr.Read())
                    {
                        
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            //SQL_Read_KHandGroupByStaff
        }


        public int Delete(int BFJHID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@BFJHID",BFJHID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }











        private CRM_BF_STAFFList ReadToSTAFF(SqlDataReader sdr)
        {
            CRM_BF_STAFFList node = new CRM_BF_STAFFList();
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.DEPID = Convert.ToInt32(sdr["DEPID"]);
            node.DEPDES = Convert.ToString(sdr["DEPDES"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            node.STAFFLX = Convert.ToInt32(sdr["STAFFLX"]);
            //node.STAFFLXDES = Convert.ToString(sdr["STAFFLXDES"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.BFPC = Convert.ToInt32(sdr["BFPC"]);
            node.BFPCDES = Convert.ToString(sdr["BFPCDES"]);
            return node;
        }
        private CRM_BF_KHList ReadToKH(SqlDataReader sdr)
        {
            CRM_BF_KHList node = new CRM_BF_KHList();
            node.KHID = Convert.ToInt32(sdr["KHID"]);
            node.CRMID = Convert.ToString(sdr["CRMID"]);
            node.KHLX = Convert.ToInt32(sdr["KHLX"]);
            //node.KHLXDES = Convert.ToString(sdr["KHLXDES"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.BFPC = Convert.ToInt32(sdr["BFPC"]);
            node.BFPCDES = Convert.ToString(sdr["BFPCDES"]);
            return node;
        }






        private CRM_BF_BFJHList ReadDataToListObj(SqlDataReader sdr)
        {
            CRM_BF_BFJHList node = new CRM_BF_BFJHList();
            node.BFJHID = Convert.ToInt32(sdr["BFJHID"]);
            node.BFLX = Convert.ToInt32(sdr["BFLX"]);
            node.BFLXDES = Convert.ToString(sdr["BFLXDES"]);
            node.BFJHMC = Convert.ToString(sdr["BFJHMC"]);
            node.KSSJ = Convert.ToString(sdr["KSSJ"]);
            node.JSSJ = Convert.ToString(sdr["JSSJ"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);

            return node;
        }
        private CRM_BF_BFJH ReadDataToObj(SqlDataReader sdr)
        {
            CRM_BF_BFJH node = new CRM_BF_BFJH();
            node.BFJHID = Convert.ToInt32(sdr["BFJHID"]);
            node.BFLX = Convert.ToInt32(sdr["BFLX"]);
            //node.BFLXDES = Convert.ToString(sdr["BFLXDES"]);
            node.BFJHMC = Convert.ToString(sdr["BFJHMC"]);
            node.KSSJ = Convert.ToString(sdr["KSSJ"]);
            node.JSSJ = Convert.ToString(sdr["JSSJ"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            //node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.ISDELETE = Convert.ToBoolean(sdr["ISDELETE"]);

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
