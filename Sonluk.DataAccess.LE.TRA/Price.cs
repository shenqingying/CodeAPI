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
    public class Price : IPrice
    {
        private const string SQL_SELECT = "SELECT * FROM SP_TYJG WHERE SXID=@SXID ORDER BY BJL";
        private const string SQL_INSERT = "LE_TRA_Price_Insert";
        private const string SQL_DELETE = "DELETE FROM SP_TYJG WHERE SXID=@SXID";

        public IList<PriceInfo> Read(int routeID)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@SXID", routeID)};
            IList<PriceInfo> nodes = new List<PriceInfo>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        PriceInfo node = new PriceInfo();
                        node.ID = Convert.ToInt32(sdr["TYJGID"]);
                        node.Route = Convert.ToInt32(sdr["SXID"]);
                        node.Unit = Convert.ToString(sdr["DWMC"]);
                        node.UnitID = Convert.ToInt32(sdr["JLDWID"]);
                        node.LowerWeightLimit = Convert.ToDecimal(sdr["BJL"]);
                        node.UpperWeightLimit = Convert.ToDecimal(sdr["EJL"]);
                        node.Value = Convert.ToDecimal(sdr["DJ"]);
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

        public int Create(PriceInfo node)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@SXID", node.Route), 
                new SqlParameter("@DWMC", node.Unit),
                new SqlParameter("@JLDWID", node.UnitID),
                new SqlParameter("@BJL", node.LowerWeightLimit), 
                new SqlParameter("@EJL", node.UpperWeightLimit),
                new SqlParameter("@DJ", node.Value)};

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

        public int Delete(int routeID)
        {
            SqlParameter[] parms = { new SqlParameter("SXID", routeID) };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE, parms)) { }
            }
            catch (Exception e)
            {
                routeID = 0;
            }
            return routeID;
        }
    }
}
