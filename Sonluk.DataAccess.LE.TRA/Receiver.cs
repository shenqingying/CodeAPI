using Sonluk.Entities.Master;
using Sonluk.IDataAccess.LE.TRA;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.LE.TRA
{
    public class Receiver : IReceiver
    {
        private const string SQL_SELECT = "SELECT GSID, GSMC, GSJC,SAPNO FROM SP_SHR WHERE isDelete=@deleted";
        private const string SQL_SELECT_BY_CITY = "SELECT b.SHRID SHRID,SHRJC,SHRDW,SAPNO,b.isDef SHRisDef,SHRDZID,DZMC,LXR,LXDH,SJ,ZDID,ZDMC,a.isDef SHRDZisDef FROM SP_SHRDZ a LEFT JOIN SP_SHR b on a.SHRID= b.SHRID WHERE ZDID=@city";
        private const string SQL_SELECT_BY_SERIAL_NUMBER = "SELECT b.SHRID SHRID,SHRJC,SHRDW,SAPNO,b.isDef SHRisDef,SHRDZID,DZMC,LXR,LXDH,SJ,ZDID,ZDMC,a.isDef SHRDZisDef FROM SP_SHRDZ a LEFT JOIN SP_SHR b on a.SHRID= b.SHRID WHERE SAPNO=@serialNumber ORDER BY b.isDef DESC,a.isDef DESC,SHRDZID DESC";
        private const string SQL_SELECT_BY_SERIAL_NUMBER_CITY = "SELECT b.SHRID SHRID,SHRJC,SHRDW,SAPNO,b.isDef SHRisDef,SHRDZID,DZMC,LXR,LXDH,SJ,ZDID,ZDMC,a.isDef SHRDZisDef FROM SP_SHRDZ a LEFT JOIN SP_SHR b on a.SHRID= b.SHRID WHERE SAPNO=@serialNumber AND ZDID=@city ORDER BY b.isDef DESC,a.isDef DESC,SHRDZID DESC";
        private const string SQL_SELECT_FUZZY = "LE_TRA_Receiver_Select_Fuzzy";
        private const string SQL_INSERT = "LE_TRA_Receiver_Insert";
        private const string SQL_UPDATE = "LE_TRA_Receiver_Update";

        public CompanyInfo Read(string serialNumber)
        {
            SqlParameter[] parms = { new SqlParameter("@serialNumber", serialNumber) };

            CompanyInfo node = new CompanyInfo();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_BY_SERIAL_NUMBER, parms))
                {
                    if (sdr.Read())
                    {
                        node.ID = Convert.ToInt32(sdr["SHRID"]);
                        node.Name = Convert.ToString(sdr["SHRDW"]);
                        node.ShortName = Convert.ToString(sdr["SHRJC"]);
                        node.SerialNumber = Convert.ToString(sdr["SAPNO"]);
                        node.Address = Convert.ToString(sdr["DZMC"]);
                        node.City = Convert.ToString(sdr["ZDMC"]);
                        node.CityID = Convert.ToInt32(sdr["ZDID"]);
                        node.Contact = Convert.ToString(sdr["LXR"]);
                        node.Telephone = Convert.ToString(sdr["LXDH"]);
                        node.Cellphone = Convert.ToString(sdr["SJ"]);
                        node.Default = Convert.ToBoolean(sdr["SHRisDef"]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }

        public CompanyInfo Read(string serialNumber,int city)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@serialNumber", serialNumber),
                new SqlParameter("@city", city)};

            CompanyInfo node = new CompanyInfo();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_BY_SERIAL_NUMBER_CITY, parms))
                {
                    if (sdr.Read())
                    {
                        node.ID = Convert.ToInt32(sdr["SHRID"]);
                        node.Name = Convert.ToString(sdr["SHRDW"]);
                        node.ShortName = Convert.ToString(sdr["SHRJC"]);
                        node.SerialNumber = Convert.ToString(sdr["SAPNO"]);
                        node.Address = Convert.ToString(sdr["DZMC"]);
                        node.City = Convert.ToString(sdr["ZDMC"]);
                        node.CityID = Convert.ToInt32(sdr["ZDID"]);
                        node.Contact = Convert.ToString(sdr["LXR"]);
                        node.Telephone = Convert.ToString(sdr["LXDH"]);
                        node.Cellphone = Convert.ToString(sdr["SJ"]);
                        node.Default = Convert.ToBoolean(sdr["SHRisDef"]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }

        public IList<CompanyInfo> Read()
        {
            IList<CompanyInfo> nodes = new List<CompanyInfo>();

            try
            {
                using (SqlDataReader odr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT, null))
                {
                    while (odr.Read())
                    {
                        CompanyInfo node = new CompanyInfo();
                        node.ID = Convert.ToInt32(odr["GSID"]);
                        node.Name = Convert.ToString(odr["GSMC"]);
                        node.ShortName = Convert.ToString(odr["GSJC"]);
                        node.SerialNumber = Convert.ToString(odr["SAPNO"]);
                        nodes.Add(node);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public IList<CompanyInfo> Read(int city)
        {
            SqlParameter[] parms = { new SqlParameter("@city", city) };

            IList<CompanyInfo> nodes = new List<CompanyInfo>();
            int customer = 0;
            int index = -1;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_BY_CITY, parms))
                {
                    while (sdr.Read())
                    {
                        if (!(customer == (Convert.ToInt32(sdr["SHRID"]))))
                        {
                            CompanyInfo node = new CompanyInfo();
                            node.ID = Convert.ToInt32(sdr["SHRID"]);
                            node.SerialNumber = Convert.ToString(sdr["SAPNO"]);
                            node.ShortName = Convert.ToString(sdr["SHRJC"]);
                            node.Name = Convert.ToString(sdr["SHRDW"]);
                            node.Default = Convert.ToBoolean(sdr["SHRisDef"]);
                            node.Children = new List<CompanyInfo>();
                            nodes.Add(node);
                            customer = node.ID;
                            index++;
                        }
                        CompanyInfo child = new CompanyInfo();
                        child.ID = Convert.ToInt32(sdr["SHRDZID"]);
                        child.Name = Convert.ToString(sdr["SHRDW"]);
                        child.ShortName = Convert.ToString(sdr["SHRJC"]);
                        child.Address = Convert.ToString(sdr["DZMC"]);
                        child.City = Convert.ToString(sdr["ZDMC"]);
                        child.CityID = Convert.ToInt32(sdr["ZDID"]);
                        child.Contact = Convert.ToString(sdr["LXR"]);
                        child.Telephone = Convert.ToString(sdr["LXDH"]);
                        child.Cellphone = Convert.ToString(sdr["SJ"]);
                        child.Default = Convert.ToBoolean(sdr["SHRDZisDef"]);
                        nodes[index].Children.Add(child);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public IList<CompanyInfo> Select(string keyword)
        {
            SqlParameter[] parms = { new SqlParameter("@keyword", keyword) };
            IList<CompanyInfo> nodes = new List<CompanyInfo>();
            int customer = 0;
            int index = -1;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_FUZZY, parms))
                {
                    while (sdr.Read())
                    {
                        if (!(customer == (Convert.ToInt32(sdr["SHRID"]))))
                        {
                            CompanyInfo node = new CompanyInfo();
                            node.ID = Convert.ToInt32(sdr["SHRID"]);
                            node.SerialNumber = Convert.ToString(sdr["SAPNO"]);
                            node.ShortName = Convert.ToString(sdr["SHRJC"]);
                            node.Name = Convert.ToString(sdr["SHRDW"]);
                            node.Default = Convert.ToBoolean(sdr["SHRisDef"]);
                            node.Children = new List<CompanyInfo>();
                            nodes.Add(node);
                            customer = node.ID;
                            index++;
                        }
                        CompanyInfo child = new CompanyInfo();
                        child.ID = Convert.ToInt32(sdr["SHRDZID"]);
                        child.Name = Convert.ToString(sdr["SHRDW"]);
                        child.ShortName = Convert.ToString(sdr["SHRJC"]);
                        child.Address = Convert.ToString(sdr["DZMC"]);
                        child.City = Convert.ToString(sdr["ZDMC"]);
                        child.CityID = Convert.ToInt32(sdr["ZDID"]);
                        child.Contact = Convert.ToString(sdr["LXR"]);
                        child.Telephone = Convert.ToString(sdr["LXDH"]);
                        child.Cellphone = Convert.ToString(sdr["SJ"]);
                        child.Default = Convert.ToBoolean(sdr["SHRDZisDef"]);
                        nodes[index].Children.Add(child);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public int Create(CompanyInfo node)
        {
            SqlParameter[] parms = { 
                        new SqlParameter("@SHRJC", node.ShortName),
                        new SqlParameter("@SHRDW", node.Name ),
                        new SqlParameter("@SAPNO", node.SerialNumber),
                        new SqlParameter("@isDef", node.Default)};

            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
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

        public int Update(CompanyInfo node)
        {
            SqlParameter[] parms = { 
                        new SqlParameter("@SHRID", node.ID),
                        new SqlParameter("@SHRJC", node.ShortName),
                        new SqlParameter("@SHRDW", node.Name ),
                        new SqlParameter("@isDef", node.Default)};

            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms))
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

        public int Delete(int ID)
        {
            throw new NotImplementedException();
        }

    }
}
