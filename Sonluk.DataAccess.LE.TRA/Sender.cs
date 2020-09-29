using Sonluk.Entities.Master;
using Sonluk.IDataAccess.LE.TRA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.LE.TRA
{
    public class Sender : ISender
    {
        private const string SQL_SELECT_LIST = "SELECT TYRID, TYRJC, TYRDW,TYRDZ,LXR,LXDH,SJ,ZDID,ZDMC,isDef FROM SP_TYR WHERE isDef=@default";
        private const string SQL_SELECT_SINGLE = "SELECT TYRID, TYRJC, TYRDW,TYRDZ,LXR,LXDH,SJ,ZDID,ZDMC,isDef FROM SP_TYR WHERE TYRID=@ID";

        public IList<CompanyInfo> Read(bool available)
        {
            int deleted = 0;
            if (available)
                deleted = 1;
            SqlParameter[] parms = { new SqlParameter("@default", deleted) };

            IList<CompanyInfo> nodes = new List<CompanyInfo>();

            try
            {
                using (SqlDataReader odr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_LIST, parms))
                {
                    while (odr.Read())
                    {
                        CompanyInfo node = new CompanyInfo();
                        node.ID = Convert.ToInt32(odr["TYRID"]);
                        node.Name = Convert.ToString(odr["TYRDW"]);
                        node.ShortName = Convert.ToString(odr["TYRJC"]);
                        node.Address = Convert.ToString(odr["TYRDZ"]);
                        node.City = Convert.ToString(odr["ZDMC"]);
                        node.CityID = Convert.ToInt32(odr["ZDID"]);
                        node.Contact = Convert.ToString(odr["LXR"]);
                        node.Telephone = Convert.ToString(odr["LXDH"]);
                        node.Cellphone = Convert.ToString(odr["SJ"]);
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

        public CompanyInfo Read(string serialNumber)
        {

            SqlParameter[] parms = { new SqlParameter("@ID", serialNumber) };

            CompanyInfo node= new CompanyInfo();

            try
            {
                using (SqlDataReader odr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_SINGLE, parms))
                {
                    while (odr.Read())
                    {
                        node.SerialNumber = Convert.ToString(odr["TYRID"]);
                        node.Name = Convert.ToString(odr["TYRDW"]);
                        node.ShortName = Convert.ToString(odr["TYRJC"]);
                        node.Address = Convert.ToString(odr["TYRDZ"]);
                        node.City = Convert.ToString(odr["ZDMC"]);
                        node.CityID = Convert.ToInt32(odr["ZDID"]);
                        node.Contact = Convert.ToString(odr["LXR"]);
                        node.Telephone = Convert.ToString(odr["LXDH"]);
                        node.Cellphone = Convert.ToString(odr["SJ"]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }
    }
}
