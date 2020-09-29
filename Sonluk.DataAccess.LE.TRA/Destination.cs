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
    public class Destination : IDestination
    {
        private const string SQL_SELECT = "SELECT * FROM SP_SHRDZ WHERE SHRID=@parentID";
        private const string SQL_SELECT_SINGLE = "SELECT * FROM SP_SHRDZ WHERE SHRDZID=@ID";
        private const string SQL_INSERT = "LE_TRA_Destination_Insert";
        private const string SQL_UPDATE = "LE_TRA_Destination_Update";

        public IList<DestinationInfo> Read(int parentID)
        {

            SqlParameter[] parms = { 
                new SqlParameter("@SHRID", parentID)};

            IList<DestinationInfo> nodes = new List<DestinationInfo>();

            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        DestinationInfo child = new DestinationInfo();
                        child.ID = Convert.ToInt32(sdr["SHRDZID"]);
                        child.Address = Convert.ToString(sdr["DZMC"]);
                        child.Contact = Convert.ToString(sdr["LXR"]);
                        child.City = new CityInfo();
                        child.City.ID = Convert.ToInt32(sdr["ZDMC"]);
                        child.City.Name = Convert.ToString(sdr["ZDMC"]);
                        child.Telephone = Convert.ToString(sdr["LXDH"]);
                        child.Cellphone = Convert.ToString(sdr["SJ"]);
                        child.Default = Convert.ToBoolean(sdr["isDef"]);
                        nodes.Add(child);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public DestinationInfo ReadSingle(int ID)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@SHRDZID", ID)};

            DestinationInfo node = new DestinationInfo();

            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_SINGLE, parms))
                {
                    if (sdr.Read())
                    {
                        node.ID = Convert.ToInt32(sdr["SHRDZID"]);
                        node.Address = Convert.ToString(sdr["DZMC"]);
                        node.Contact = Convert.ToString(sdr["LXR"]);
                        node.City = new CityInfo();
                        node.City.ID = Convert.ToInt32(sdr["ZDMC"]);
                        node.City.Name = Convert.ToString(sdr["ZDMC"]);
                        node.Telephone = Convert.ToString(sdr["LXDH"]);
                        node.Cellphone = Convert.ToString(sdr["SJ"]);
                        node.Default = Convert.ToBoolean(sdr["isDef"]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return node;
        }

        public int Create(DestinationInfo node)
        {
            SqlParameter[] parms = { 
                        new SqlParameter("@SHRID", node.ReceiverID),
                        new SqlParameter("@DZMC", node.Address ),
                        new SqlParameter("@LXR", node.Contact),
                        new SqlParameter("@ZDID", node.City.ID),
                        new SqlParameter("@ZDMC", node.City.Name),
                        new SqlParameter("@LXDH", node.Telephone),
                        new SqlParameter("@SJ", node.Cellphone),
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

        public int Update(DestinationInfo node)
        {
            SqlParameter[] parms = { 
                        new SqlParameter("@SHRDZID", node.ID),
                        new SqlParameter("@SHRID", node.ReceiverID),
                        new SqlParameter("@DZMC", node.Address ),
                        new SqlParameter("@LXR", node.Contact),
                        new SqlParameter("@ZDID", node.City.ID),
                        new SqlParameter("@ZDMC", node.City.Name),
                        new SqlParameter("@LXDH", node.Telephone),
                        new SqlParameter("@SJ", node.Cellphone),
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
