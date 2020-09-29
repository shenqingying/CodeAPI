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
    public class Route : IRoute
    {

        private const string SQL_SELECT = "SELECT * FROM SP_SXB a LEFT JOIN SP_TYJG b ON a.SXID = b.SXID WHERE BJL<=@leftWeight AND EJL>@rightWeight AND BZDID=@source AND EZDID=@destination";
        private const string SQL_SELECT_CITY_ID = "SELECT * FROM SP_SXB WHERE EZDID=@cityID";
        private const string SQL_INSERT = "LE_TRA_Route_Insert";
        private const string SQL_UPDATE = "LE_TRA_Route_Update";
        private const string SQL_DELETE = "DELETE FROM SP_SXB WHERE EZDID=@cityID";
        private const string SQL_SELECT_SP_TYJG = "SELECT DJ FROM SP_TYJG WHERE SXID = @SXID AND BJL<=@leftWeight AND EJL>@rightWeight";
        private const string SQL_SELECT_SP_SXB_ZSF = "SELECT ZSF FROM SP_SXB WHERE BZDID = @BZDID and EZDID = @EZDID";
        //private const string SQL_SELECT_SP_SXB_ZSF = "SELECT ZSF FROM SP_SXB WHERE SXID = @SXID";

        public RouteInfo Read(int source, int destination, decimal weight)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@leftWeight", weight),
                new SqlParameter("@rightWeight", weight),
                new SqlParameter("@source", source), 
                new SqlParameter("@destination", destination)};

            RouteInfo node = new RouteInfo();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT, parms))
                {
                    if (sdr.Read())
                    {
                        node.ID = Convert.ToInt32(sdr["SXID"]);
                        node.TimeLimit = Convert.ToInt32(sdr["SX"]);
                        node.Price = Convert.ToDecimal(sdr["DJ"]);
                        if (sdr["GSID"] != DBNull.Value)
                            node.CarrierID = Convert.ToInt32(sdr["GSID"]);
                        if (sdr["GSJC"] != DBNull.Value)
                            node.Carrier = sdr["GSJC"].ToString();
                        node.UnitID = Convert.ToInt32(sdr["JLDWID"]);
                        node.Unit = Convert.ToString(sdr["DWMC"]);
                    }
                    else
                    {
                        node.Price = -1;
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return node;
        }

        public string Read(int SXID, decimal weight)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@leftWeight", weight),
                new SqlParameter("@rightWeight", weight),
                new SqlParameter("@SXID", SXID)};
            double rst = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_SP_TYJG, parms))
                {
                    if (sdr.Read())
                    {
                        rst = Convert.ToDouble(sdr["DJ"]);
                    }
                    else
                    {
                        rst = 0;
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return rst.ToString();
        }


        public string ReadZSF(int BZDID, int EZDID)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@BZDID", BZDID),
                new SqlParameter("@EZDID", EZDID)
                                   };
            double rst = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_SP_SXB_ZSF, parms))
                {
                    if (sdr.Read())
                    {
                        rst = Convert.ToDouble(sdr["ZSF"]);
                    }
                    else
                    {
                        rst = 0;
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return rst.ToString();
        }

        //public decimal ReadZSF(int SXID)
        //{
        //    SqlParameter[] parms = { 
        //        new SqlParameter("@SXID", SXID)};
        //    decimal rst = 0;
        //    try
        //    {
        //        using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_SP_SXB_ZSF, parms))
        //        {
        //            if (sdr.Read())
        //            {
        //                rst = Convert.ToDecimal(sdr["ZSF"]);
        //            }
        //            else
        //            {
        //                rst = 0;
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new ApplicationException(e.Message);
        //    }
        //    return rst;
        //}


        public RouteInfo Read(int cityID)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@cityID", cityID)};

            RouteInfo node = new RouteInfo();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_CITY_ID, parms))
                {
                    if (sdr.Read())
                    {
                        node.ID = Convert.ToInt32(sdr["SXID"]);
                        node.SourceID = Convert.ToInt32(sdr["BZDID"]);
                        node.Source = Convert.ToString(sdr["BZDMC"]);
                        node.DestinationID = Convert.ToInt32(sdr["EZDID"]);
                        node.Destination = Convert.ToString(sdr["EZDMC"]);
                        node.Distance = Convert.ToInt32(sdr["LIC"]);
                        node.TimeLimit = Convert.ToInt32(sdr["SX"]);
                        if (sdr["GSID"] != DBNull.Value)
                        {
                            node.CarrierID = Convert.ToInt32(sdr["GSID"]);
                            node.Carrier = Convert.ToString(sdr["GSJC"]);
                        }
                        node.Zsf = Convert.ToInt32(sdr["ZSF"]);

                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return node;
        }

        public int Create(RouteInfo node)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@BZDID", node.SourceID), 
                new SqlParameter("@BZDMC", node.Source),
                new SqlParameter("@EZDID", node.DestinationID),
                new SqlParameter("@EZDMC", node.Destination), 
                new SqlParameter("@LIC", node.Distance),
                new SqlParameter("@SX", node.TimeLimit),
                new SqlParameter("@GSID", node.CarrierID), 
                new SqlParameter("@GSJC", node.Carrier),
                new SqlParameter("@ZSF", node.Zsf)};

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

        public int Update(RouteInfo node)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@SXID", node.ID), 
                new SqlParameter("@BZDID", node.SourceID), 
                new SqlParameter("@BZDMC", node.Source),
                new SqlParameter("@EZDID", node.DestinationID),
                new SqlParameter("@EZDMC", node.Destination), 
                new SqlParameter("@LIC", node.Distance),
                new SqlParameter("@SX", node.TimeLimit),
                new SqlParameter("@GSID", node.CarrierID), 
                new SqlParameter("@GSJC", node.Carrier),
                new SqlParameter("@ZSF", node.Zsf)};

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

        public int Delete(int cityID)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@cityID", cityID)};
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE, parms))
                {
                }
            }
            catch (Exception e)
            {
                cityID = 0;
                throw new ApplicationException(e.Message);
            }
            return cityID;
        }
    }
}
