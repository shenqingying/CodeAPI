using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sonluk.Entities.LE;
using Sonluk.IDataAccess.LE.TRA;

namespace Sonluk.DataAccess.LE.TRA
{
    public class Screen : IScreen
    {
        private const string SQL_SELECT = "SELECT * FROM SP_SCREEN";
        private const string SQL_SELECT_SINGLE = "SELECT * FROM SP_SCREEN WHERE ScreenID=@ScreenID";
        private const string SQL_UPDATE = "UPDATE SP_SCREEN SET Location=@Location,MContent=@MContent,Status=@Status WHERE ScreenID=@ScreenID";

        public IList<ScreenInfo> Read()
        {
            SqlParameter[] parms = { };
            IList<ScreenInfo> nodes = new List<ScreenInfo>();
           
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        ScreenInfo node = new ScreenInfo();
                        node.ScreenID = Convert.ToInt32(sdr["ScreenID"]);
                        node.Location = Convert.ToString(sdr["Location"]);
                        node.MContent = Convert.ToString(sdr["MContent"]);
                        node.Status = Convert.ToInt32(sdr["Status"]);
                        node.ScreenName = Convert.ToString(sdr["ScreenName"]);
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

        public ScreenInfo Read(int ID)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@ScreenID", ID)};

            ScreenInfo node = new ScreenInfo();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_SINGLE, parms))
                {
                    if (sdr.Read())
                    {
                        node.ScreenID = Convert.ToInt32(sdr["ScreenID"]);
                        node.Location = Convert.ToString(sdr["Location"]);
                        node.MContent = Convert.ToString(sdr["MContent"]);
                        node.Status = Convert.ToInt32(sdr["Status"]);
                        node.ScreenName = Convert.ToString(sdr["ScreenName"]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }

        public int Update(ScreenInfo node)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@ScreenID", node.ScreenID), 
                new SqlParameter("@Location", node.Location), 
                new SqlParameter("@MContent", node.MContent),
                new SqlParameter("@Status", node.Status),
                new SqlParameter("@ScreenName", node.ScreenName)};


            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_UPDATE, parms))
                {
                    if (sdr.Read())
                    {
                        ID = Convert.ToInt32(sdr["ScreenID"]);
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
