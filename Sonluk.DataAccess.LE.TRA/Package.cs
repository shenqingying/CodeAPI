using Sonluk.Entities.LE;
using Sonluk.IDataAccess.LE.TRA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.LE.TRA
{
    public class Package : IPackage
    {
        private const string SQL_SELECT = "SELECT XSID, XSMC FROM SP_BZXS WHERE isDelete=@deleted";
        private const string SQL_SELECT_SINGLE = "SELECT XSID, XSMC FROM SP_BZXS WHERE XSID=@ID";

        public IList<PackageInfo> Type(bool available)
        {
            int deleted = 1;
            if (available)
                deleted = 0;
            SqlParameter[] parms = { new SqlParameter("@deleted", deleted) };

            IList<PackageInfo> nodes = new List<PackageInfo>();

            try
            {
                using (SqlDataReader odr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT, parms))
                {
                    while (odr.Read())
                    {
                        PackageInfo node = new PackageInfo();
                        node.TypeID = Convert.ToInt32(odr["XSID"]);
                        node.Type = Convert.ToString(odr["XSMC"]);
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

        public PackageInfo Type(int ID)
        {
            SqlParameter[] parms = { new SqlParameter("@ID", ID) };

            PackageInfo node = new PackageInfo();

            try
            {
                using (SqlDataReader odr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_SINGLE, parms))
                {
                    if (odr.Read())
                    {
                        node.TypeID = Convert.ToInt32(odr["XSID"]);
                        node.Type = Convert.ToString(odr["XSMC"]);
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
