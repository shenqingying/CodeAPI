using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using Sonluk.Utility.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.CRM
{
    public class HG_STAFF : IHG_STAFF
    {
        private const string SQL_Create = "CRM_HG_STAFF_Create";
        private const string SQL_Update = "CRM_HG_STAFF_Update";
        private const string SQL_Report = "CRM_HG_STAFF_Report";
        private const string SQL_Delete = "CRM_HG_STAFF_Delete";
        private const string SQL_RaedBySTAFFID = "CRM_HG_STAFF_RaedBySTAFFID";//"SELECT * FROM CRM_HG_STAFF WHERE  STAFFID = @STAFFID AND SCANCEL = 0 AND STAFFLX <> 100";
        private const string SQL_ReadBySTAFFNO = "CRM_HG_STAFF_ReadBySTAFFNO";
        private const string SQL_ReadByROLEID = "CRM_HG_STAFF_ReadByROLEID";//@"SELECT A.* FROM CRM_HG_STAFF AS A INNER JOIN CRM_HG_STAFFROLE ON A.STAFFID = CRM_HG_STAFFROLE.STAFFID AND SCANCEL = 0 AND STAFFLX <> 100 AND CRM_HG_STAFFROLE.ROLEID = @ROLEID";
        private const string SQL_ReadByDUTYID = "CRM_HG_STAFF_ReadByDUTYID";//@"SELECT A.* FROM CRM_HG_STAFF AS A INNER JOIN CRM_HG_STAFFDUTY ON A.STAFFID = CRM_HG_STAFFDUTY.STAFFID AND SCANCEL = 0 AND STAFFLX <> 100 AND CRM_HG_STAFFDUTY.DUTYID = @DUTYID";
        private const string SQL_ReadByParam = "CRM_HG_STAFF_ReadByParam";
        //DUTYID
        private const string SQL_ReadUser = "CRM_HG_STAFF_ReadUser";//"select a.*,ISNULL((select depname from CRM_HG_DEPT where DEPID = a.depid),' ') as DEPIDDES from CRM_HG_STAFF as a  where a.STAFFUSER <> '' and a.STAFFPW <> '' and a.SCANCEL = 0 and a.ISACTIVE = 1";
        private const string SQL_ReadSTAFFBYKHIDANDDUTY = "CRM_HG_STAFF_ReadSTAFFBYKHIDANDDUTY";
        private const string SQL_ReadSTAFF_KHGOURPBYSTAFFID = "CRM_HG_STAFF_ReadSTAFF_KHGOURPBYSTAFFID";
        private const string SQL_ReadStaff_BYDEPID = "CRM_HG_Staff_BYDEPID";
        private const string SQL_ReadSTAFF_KHGroupByStaffidAndDuty = "CRM_HG_STAFF_ReadSTAFF_KHGroupByStaffidAndDuty";


        //USER
        
        private const string SQL_ReadUser_STAFF = "CRM_HG_STAFF_ReadUser_STAFF";

        public int Create(CRM_HG_STAFF model)
        {
            if (string.IsNullOrEmpty(model.STAFFPW) == false)
            {
                string pwdhash = MD5Hash.GetMd5Hash(model.STAFFPW).ToUpper();
            }
            
            SqlParameter[] parms = {
                                        //new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@DEPID", model.DEPID),
                                        new SqlParameter("@STAFFNAME", model.STAFFNAME),
                                        new SqlParameter("@STAFFNO", model.STAFFNO),
                                        new SqlParameter("@STAFFUSER", model.STAFFUSER),
                                        new SqlParameter("@STAFFPW", model.STAFFPW),
                                        new SqlParameter("@STAFFLX", model.STAFFLX),
                                        new SqlParameter("@STAFFRZSJ", model.STAFFRZSJ),
                                        new SqlParameter("@STAFFMPSJ", model.STAFFMPSJ),
                                        new SqlParameter("@STAFFSEX", model.STAFFSEX),
                                        new SqlParameter("@STAFFJG", model.STAFFJG),
                                        new SqlParameter("@STAFFSFZH", model.STAFFSFZH),
                                        new SqlParameter("@STAFFSR", model.STAFFSR),
                                        new SqlParameter("@STAFFZZMM", model.STAFFZZMM),
                                        new SqlParameter("@STAFFXL", model.STAFFXL),
                                        new SqlParameter("@STAFFBYYX", model.STAFFBYYX),
                                        new SqlParameter("@STAFFHYZK", model.STAFFHYZK),
                                        new SqlParameter("@STAFFCZDZ", model.STAFFCZDZ),
                                        new SqlParameter("@STAFFZWJB", model.STAFFZWJB),
                                        new SqlParameter("@STAFFGW", model.STAFFGW),
                                        new SqlParameter("@STAFFWORK", model.STAFFWORK),
                                        new SqlParameter("@STAFFMOBILE", model.STAFFMOBILE),
                                        new SqlParameter("@STAFFTEL", model.STAFFTEL),
                                        new SqlParameter("@STAFFEMAIL", model.STAFFEMAIL),
                                        new SqlParameter("@GJ", model.GJ),
                                        new SqlParameter("@STAFFSF", model.STAFFSF),
                                        new SqlParameter("@STAFFCITY", model.STAFFCITY),
                                        new SqlParameter("@BBID", model.BBID),
                                        new SqlParameter("@STAFFMEMO", model.STAFFMEMO),
                                        new SqlParameter("@JLRQ", model.JLRQ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BZID",model.BZID),
                                        new SqlParameter("@SISLOCK", model.SISLOCK),
                                        new SqlParameter("@SCANCEL", model.SCANCEL),
                                        new SqlParameter("@ISSUPER", model.ISSUPER),
                                        new SqlParameter("@XH", model.XH),
                                        new SqlParameter("@E_COUNT", model.E_COUNT),
                                        new SqlParameter("@STAFFKHLXID",model.STAFFKHLXID),
                                        new SqlParameter("@USERLX",model.USERLX),
                                        new SqlParameter("@ISINIT",model.ISINIT),
                                        new SqlParameter("@UPDATEPWDATE",model.UPDATEPWDATE)
                                       };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_HG_STAFF model)
        {

            if (string.IsNullOrEmpty(model.STAFFPW) == false)
            {
                string pwdhash = MD5Hash.GetMd5Hash(model.STAFFPW).ToUpper();
            }
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFID", model.STAFFID),
                                        new SqlParameter("@DEPID", model.DEPID),
                                        new SqlParameter("@STAFFNAME", model.STAFFNAME),
                                        new SqlParameter("@STAFFNO", model.STAFFNO),
                                        new SqlParameter("@STAFFUSER", model.STAFFUSER),
                                        new SqlParameter("@STAFFPW", model.STAFFPW),
                                        new SqlParameter("@STAFFLX", model.STAFFLX),
                                        new SqlParameter("@STAFFRZSJ", model.STAFFRZSJ),
                                        new SqlParameter("@STAFFMPSJ", model.STAFFMPSJ),
                                        new SqlParameter("@STAFFSEX", model.STAFFSEX),
                                        new SqlParameter("@STAFFJG", model.STAFFJG),
                                        new SqlParameter("@STAFFSFZH", model.STAFFSFZH),
                                        new SqlParameter("@STAFFSR", model.STAFFSR),
                                        new SqlParameter("@STAFFZZMM", model.STAFFZZMM),
                                        new SqlParameter("@STAFFXL", model.STAFFXL),
                                        new SqlParameter("@STAFFBYYX", model.STAFFBYYX),
                                        new SqlParameter("@STAFFHYZK", model.STAFFHYZK),
                                        new SqlParameter("@STAFFCZDZ", model.STAFFCZDZ),
                                        new SqlParameter("@STAFFZWJB", model.STAFFZWJB),
                                        new SqlParameter("@STAFFGW", model.STAFFGW),
                                        new SqlParameter("@STAFFWORK", model.STAFFWORK),
                                        new SqlParameter("@STAFFMOBILE", model.STAFFMOBILE),
                                        new SqlParameter("@STAFFTEL", model.STAFFTEL),
                                        new SqlParameter("@STAFFEMAIL", model.STAFFEMAIL),
                                        new SqlParameter("@GJ", model.GJ),
                                        new SqlParameter("@STAFFSF", model.STAFFSF),
                                        new SqlParameter("@STAFFCITY", model.STAFFCITY),
                                        new SqlParameter("@BBID", model.BBID),
                                        new SqlParameter("@STAFFMEMO", model.STAFFMEMO),
                                        new SqlParameter("@JLRQ", model.JLRQ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BZID",model.BZID),
                                        new SqlParameter("@SISLOCK", model.SISLOCK),
                                        new SqlParameter("@SCANCEL", model.SCANCEL),
                                        new SqlParameter("@ISSUPER", model.ISSUPER),
                                        new SqlParameter("@XH", model.XH),
                                        new SqlParameter("@E_COUNT", model.E_COUNT),
                                        new SqlParameter("@STAFFKHLXID", model.STAFFKHLXID),
                                        new SqlParameter("@USERLX", model.USERLX)
                                       };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
        public IList<CRM_HG_STAFFList> ReadUser()
        {

            IList<CRM_HG_STAFFList> nodes = new List<CRM_HG_STAFFList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadUser, null))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObject(sdr, 1));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<STAFFDUTY_KH> ReadSTAFFBYKHIDANDDUTY(int KHID, int DUTYID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@KHID",KHID),
                                       new SqlParameter("@DUTYID",DUTYID)
                                   };
            IList<STAFFDUTY_KH> nodes = new List<STAFFDUTY_KH>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadSTAFFBYKHIDANDDUTY, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToDutyObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        public IList<CRM_HG_STAFFList> Report(CRM_Report_STAFFModel model, string TYPE)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@STAFFLX", model.STAFFLX),
                                        new SqlParameter("@STAFFNAME", model.STAFFNAME),
                                        new SqlParameter("@STAFFUSER", model.STAFFUSER),
                                        new SqlParameter("@STAFFNO", model.STAFFNO),
                                        new SqlParameter("@FROMSTAFFMPSJ", model.FROMSTAFFMPSJ),
                                        new SqlParameter("@TOSTAFFMPSJ", model.TOSTAFFMPSJ),
                                        new SqlParameter("@STAFFSEX", model.STAFFSEX),
                                        new SqlParameter("@STAFFZZMM", model.STAFFZZMM),
                                        new SqlParameter("@STAFFXL", model.STAFFXL),
                                        new SqlParameter("@STAFFZWJB", model.STAFFZWJB),
                                        new SqlParameter("@STAFFGW", model.STAFFGW),
                                        new SqlParameter("@ISACTIVE",model.ISACTIVE),
                                        new SqlParameter("@DEPID",model.DEPID),
                                        new SqlParameter("@TYPE",TYPE),
                                        new SqlParameter("@AllSYS",model.AllSYS),
                                        new SqlParameter("@STAFFID",model.STAFFID)
                                   };
            IList<CRM_HG_STAFFList> nodes = new List<CRM_HG_STAFFList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Report, parms))
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

        public CRM_HG_STAFF RaedBySTAFFID(int STAFFID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };

            CRM_HG_STAFF node = new CRM_HG_STAFF();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_RaedBySTAFFID, parms))
                {
                    if (sdr.Read())
                    {
                        node = ReadToSturct(sdr);
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return node;
        }

        public CRM_HG_STAFF ReadBySTAFFNO(string STAFFNO)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFNO",STAFFNO)
                                   };

            CRM_HG_STAFF node = new CRM_HG_STAFF();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadBySTAFFNO, parms))
                {
                    if (sdr.Read())
                    {
                        node = ReadToSturct(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return node;
        }

        public CRM_HG_STAFF ReadByROLEID(int ROLEID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@ROLEID",ROLEID)
                                   };

            CRM_HG_STAFF node = new CRM_HG_STAFF();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByROLEID, parms))
                {
                    if (sdr.Read())
                    {
                        node = ReadToSturct(sdr);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return node;
        }
        public  IList<CRM_HG_STAFF> ReadByDUTYID(int DUTYID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@DUTYID",DUTYID)
                                   };

            //CRM_HG_STAFF node = new CRM_HG_STAFF();
            IList<CRM_HG_STAFF> nodes = new List<CRM_HG_STAFF>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByDUTYID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadToSturct(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_HG_STAFFList> ReadByParam(CRM_HG_STAFF model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFNO",model.STAFFNO),
                                       new SqlParameter("@STAFFNAME",model.STAFFNAME),
                                       new SqlParameter("@DEPID",model.DEPID),
                                       new SqlParameter("@STAFFSTR",model.STAFFSTR)
                                   };

            //CRM_HG_STAFF node = new CRM_HG_STAFF();
            IList<CRM_HG_STAFFList> nodes = new List<CRM_HG_STAFFList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParam, parms))
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

        public IList<CRM_HG_STAFF> ReadSTAFF_KHGOURPBYSTAFFID(int STAFFID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter(@"STAFFID",STAFFID)
                                   };
            IList<CRM_HG_STAFF> nodes = new List<CRM_HG_STAFF>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_ReadSTAFF_KHGOURPBYSTAFFID,parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadToSturct(sdr));
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_HG_STAFF> ReadSTAFF_KHGroupByStaffidAndDuty(int STAFFID,int DUTYID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter(@"STAFFID",STAFFID),
                                       new SqlParameter(@"DUTYID",DUTYID)
                                   };
            IList<CRM_HG_STAFF> nodes = new List<CRM_HG_STAFF>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadSTAFF_KHGroupByStaffidAndDuty, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadToSturct(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public IList<CRM_HG_STAFF> ReadStaff_BYDEPID(int STAFFID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
            IList<CRM_HG_STAFF> nodes = new List<CRM_HG_STAFF>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadStaff_BYDEPID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadToSturct(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        public int Delete(int STAFFID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }



        

        public IList<CRM_HG_STAFFList> ReadUser_STAFF(CRM_Report_STAFFModel model)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@STAFFLX",model.STAFFLX),
                                       new SqlParameter("@STAFFNO",model.STAFFNO),
                                       new SqlParameter("@STAFFNAME",model.STAFFNAME),
                                       new SqlParameter("@DEPID",model.DEPID),
                                       new SqlParameter("@DEPStr",model.DEPStr)
                                   };

            IList<CRM_HG_STAFFList> nodes = new List<CRM_HG_STAFFList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadUser_STAFF, parms))
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


        private CRM_HG_STAFF ReadToSturct(SqlDataReader sdr)
        {
            CRM_HG_STAFF node = new CRM_HG_STAFF();
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.DEPID = Convert.ToInt32(sdr["DEPID"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            node.STAFFUSER = Convert.ToString(sdr["STAFFUSER"]);
            node.STAFFPW = Convert.ToString(sdr["STAFFPW"]);
            node.STAFFLX = Convert.ToInt32(sdr["STAFFLX"]);
            node.STAFFRZSJ = Convert.ToString(sdr["STAFFRZSJ"]);
            node.STAFFMPSJ = Convert.ToString(sdr["STAFFMPSJ"]);
            node.STAFFSEX = Convert.ToInt16(sdr["STAFFSEX"]);
            node.STAFFJG = Convert.ToString(sdr["STAFFJG"]);
            node.STAFFSFZH = Convert.ToString(sdr["STAFFSFZH"]);
            node.STAFFSR = Convert.ToString(sdr["STAFFSR"]);
            node.STAFFZZMM = Convert.ToInt32(sdr["STAFFZZMM"]);
            node.STAFFXL = Convert.ToInt32(sdr["STAFFXL"]);
            node.STAFFBYYX = Convert.ToString(sdr["STAFFBYYX"]);
            node.STAFFHYZK = Convert.ToInt32(sdr["STAFFHYZK"]);
            node.STAFFCZDZ = Convert.ToString(sdr["STAFFCZDZ"]);
            node.STAFFZWJB = Convert.ToInt32(sdr["STAFFZWJB"]);
            node.STAFFGW = Convert.ToInt32(sdr["STAFFGW"]);
            node.STAFFWORK = Convert.ToString(sdr["STAFFWORK"]);
            node.STAFFMOBILE = Convert.ToString(sdr["STAFFMOBILE"]);
            node.STAFFTEL = Convert.ToString(sdr["STAFFTEL"]);
            node.STAFFEMAIL = Convert.ToString(sdr["STAFFEMAIL"]);
            node.GJ = Convert.ToInt32(sdr["GJ"]);
            node.STAFFSF = Convert.ToInt32(sdr["STAFFSF"]);
            node.STAFFCITY = Convert.ToInt32(sdr["STAFFCITY"]);
            node.STAFFMEMO = Convert.ToString(sdr["STAFFMEMO"]);
            node.JLRQ = Convert.ToDateTime(sdr["JLRQ"]).ToString("yyyy-MM-dd HH:mm:ss"); ;
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BZID = Convert.ToInt32(sdr["BZID"]);
            node.BBID = Convert.ToInt32(sdr["BBID"]);
            node.SISLOCK = Convert.ToBoolean(sdr["SISLOCK"]);
            node.SCANCEL = Convert.ToBoolean(sdr["SCANCEL"]);
            node.ISSUPER = Convert.ToBoolean(sdr["ISSUPER"]);
            node.XH = Convert.ToString(sdr["XH"]);
            node.E_COUNT = Convert.ToInt32(sdr["E_COUNT"]);
            node.STAFFKHLXID = Convert.ToInt32(sdr["STAFFKHLXID"]);
            node.USERLX = Convert.ToInt32(sdr["USERLX"]);
            return node;

        }
        private CRM_HG_STAFFList ReadDataToObject(SqlDataReader sdr, int user)
        {
            CRM_HG_STAFFList node = new CRM_HG_STAFFList();
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.DEPID = Convert.ToInt32(sdr["DEPID"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            node.STAFFUSER = Convert.ToString(sdr["STAFFUSER"]);
            node.STAFFPW = Convert.ToString(sdr["STAFFPW"]);
            node.STAFFLX = Convert.ToInt32(sdr["STAFFLX"]);
            node.STAFFRZSJ = Convert.ToString(sdr["STAFFRZSJ"]);
            node.STAFFMPSJ = Convert.ToString(sdr["STAFFMPSJ"]);
            node.STAFFSEX = Convert.ToInt16(sdr["STAFFSEX"]);
            node.STAFFJG = Convert.ToString(sdr["STAFFJG"]);
            node.STAFFSFZH = Convert.ToString(sdr["STAFFSFZH"]);
            node.STAFFSR = Convert.ToString(sdr["STAFFSR"]);
            node.STAFFZZMM = Convert.ToInt32(sdr["STAFFZZMM"]);
            node.STAFFXL = Convert.ToInt32(sdr["STAFFXL"]);
            node.STAFFBYYX = Convert.ToString(sdr["STAFFBYYX"]);
            node.STAFFHYZK = Convert.ToInt32(sdr["STAFFHYZK"]);
            node.STAFFCZDZ = Convert.ToString(sdr["STAFFCZDZ"]);
            node.STAFFZWJB = Convert.ToInt32(sdr["STAFFZWJB"]);
            node.STAFFGW = Convert.ToInt32(sdr["STAFFGW"]);
            node.STAFFWORK = Convert.ToString(sdr["STAFFWORK"]);
            node.STAFFMOBILE = Convert.ToString(sdr["STAFFMOBILE"]);
            node.STAFFTEL = Convert.ToString(sdr["STAFFTEL"]);
            node.STAFFEMAIL = Convert.ToString(sdr["STAFFEMAIL"]);
            node.GJ = Convert.ToInt32(sdr["GJ"]);
            node.STAFFSF = Convert.ToInt32(sdr["STAFFSF"]);
            node.STAFFCITY = Convert.ToInt32(sdr["STAFFCITY"]);
            node.STAFFMEMO = Convert.ToString(sdr["STAFFMEMO"]);
            node.JLRQ = Convert.ToDateTime(sdr["JLRQ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BZID = Convert.ToInt32(sdr["BZID"]);
            node.BBID = Convert.ToInt32(sdr["BBID"]);
            node.SISLOCK = Convert.ToBoolean(sdr["SISLOCK"]);
            node.SCANCEL = Convert.ToBoolean(sdr["SCANCEL"]);
            node.ISSUPER = Convert.ToBoolean(sdr["ISSUPER"]);
            node.XH = Convert.ToString(sdr["XH"]);
            node.E_COUNT = Convert.ToInt32(sdr["E_COUNT"]);
            node.DEPIDDES = Convert.ToString(sdr["DEPIDDES"]);
            
            return node;
        }
        private CRM_HG_STAFFList ReadDataToObject(SqlDataReader sdr)
        {
            CRM_HG_STAFFList node = new CRM_HG_STAFFList();
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
            node.DEPID = Convert.ToInt32(sdr["DEPID"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFNO = Convert.ToString(sdr["STAFFNO"]);
            node.STAFFUSER = Convert.ToString(sdr["STAFFUSER"]);
            node.STAFFPW = Convert.ToString(sdr["STAFFPW"]);
            node.STAFFLX = Convert.ToInt32(sdr["STAFFLX"]);
            node.STAFFRZSJ = Convert.ToString(sdr["STAFFRZSJ"]);
            node.STAFFMPSJ = Convert.ToString(sdr["STAFFMPSJ"]);
            node.STAFFSEX = Convert.ToInt32(sdr["STAFFSEX"]);
            node.STAFFJG = Convert.ToString(sdr["STAFFJG"]);
            node.STAFFSFZH = Convert.ToString(sdr["STAFFSFZH"]);
            node.STAFFSR = Convert.ToString(sdr["STAFFSR"]);
            node.STAFFZZMM = Convert.ToInt32(sdr["STAFFZZMM"]);
            node.STAFFXL = Convert.ToInt32(sdr["STAFFXL"]);
            node.STAFFBYYX = Convert.ToString(sdr["STAFFBYYX"]);
            node.STAFFHYZK = Convert.ToInt32(sdr["STAFFHYZK"]);
            node.STAFFCZDZ = Convert.ToString(sdr["STAFFCZDZ"]);
            node.STAFFZWJB = Convert.ToInt32(sdr["STAFFZWJB"]);
            node.STAFFGW = Convert.ToInt32(sdr["STAFFGW"]);
            node.STAFFWORK = Convert.ToString(sdr["STAFFWORK"]);
            node.STAFFMOBILE = Convert.ToString(sdr["STAFFMOBILE"]);
            node.STAFFTEL = Convert.ToString(sdr["STAFFTEL"]);
            node.STAFFEMAIL = Convert.ToString(sdr["STAFFEMAIL"]);
            node.GJ = Convert.ToInt32(sdr["GJ"]);
            node.STAFFSF = Convert.ToInt32(sdr["STAFFSF"]);
            node.STAFFCITY = Convert.ToInt32(sdr["STAFFCITY"]);
            node.STAFFMEMO = Convert.ToString(sdr["STAFFMEMO"]);
            node.JLRQ = Convert.ToDateTime(sdr["JLRQ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.BZID = Convert.ToInt32(sdr["BZID"]);
            node.BBID = Convert.ToInt32(sdr["BBID"]);
            node.STAFFLXDES = Convert.ToString(sdr["STAFFLXDES"]);
            node.BZIDDES = Convert.ToString(sdr["BZIDDES"]);
            node.BBIDDES = Convert.ToString(sdr["BBIDDES"]);
            //node.STAFFLXDES = Convert.ToString(sdr["STAFFLXDES"]);
            node.DEPIDDES = Convert.ToString(sdr["DEPIDDES"]);
            node.STAFFZZMMDES = Convert.ToString(sdr["STAFFZZMMDES"]);
            //node.STAFFSEXDES = Convert.ToInt32(sdr["STAFFSEXDES"]);
            node.STAFFXLDES = Convert.ToString(sdr["STAFFXLDES"]);
            //node.STAFFHYZKDES = Convert.ToInt32(sdr["STAFFHYZKDES"]);
            node.STAFFZWJBDES = Convert.ToString(sdr["STAFFZWJBDES"]);
            node.STAFFGWDES = Convert.ToString(sdr["STAFFGWDES"]);
            node.SISLOCK =  Convert.ToBoolean(sdr["SISLOCK"]);
            node.SCANCEL = Convert.ToBoolean(sdr["SCANCEL"]);
            node.ISSUPER = Convert.ToBoolean(sdr["ISSUPER"]);
            node.XH =  Convert.ToString(sdr["XH"]);
            node.E_COUNT =  Convert.ToInt32(sdr["E_COUNT"]);
            node.STAFFKHLXID = Convert.ToInt32(sdr["STAFFKHLXID"]);
            return node;
        }
        private STAFFDUTY_KH ReadDataToDutyObj(SqlDataReader sdr)
        {
            STAFFDUTY_KH node = new STAFFDUTY_KH();
            node.DUTYNAME = Convert.ToString(sdr["DUTYNAME"]);
            node.GNAME = Convert.ToString(sdr["GNAME"]);
            node.STAFFNAME = Convert.ToString(sdr["STAFFNAME"]);
            node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);
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
