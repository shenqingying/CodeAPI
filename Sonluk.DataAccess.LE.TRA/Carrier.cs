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
    public class Carrier : ICarrier
    {

        private const string SQL_SELECT = "SELECT GSID, GSMC, GSJC FROM SP_WLGS WHERE isDelete=@deleted";
        private const string SQL_SELECT_SINGLE = "SELECT GSID, GSMC, GSJC FROM SP_WLGS WHERE GSID=@ID";

        public IList<CompanyInfo> Read(bool available)
        {
            int deleted = 1;
            if (available)
                deleted = 0;
            SqlParameter[] parms = { new SqlParameter("@deleted", deleted) };

            IList<CompanyInfo> nodes = new List<CompanyInfo>();

            try
            {
                using (SqlDataReader odr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT, parms))
                {
                    while (odr.Read())
                    {
                        CompanyInfo node = new CompanyInfo();
                        node.ID = Convert.ToInt32(odr["GSID"]);
                        node.Name = Convert.ToString(odr["GSMC"]);
                        node.ShortName = Convert.ToString(odr["GSJC"]);
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

        public CompanyInfo Read(int ID)
        {
            SqlParameter[] parms = { new SqlParameter("@ID", ID) };

            CompanyInfo node = new CompanyInfo();

            try
            {
                using (SqlDataReader odr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_SINGLE, parms))
                {
                    if (odr.Read())
                    {
                        node.ID = Convert.ToInt32(odr["GSID"]);
                        node.Name = Convert.ToString(odr["GSMC"]);
                        node.ShortName = Convert.ToString(odr["GSJC"]);
                    }
                }
            }
            catch (Exception e )
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }
    }
}
