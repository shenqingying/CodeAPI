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
    public class City : ICity
    {
        private const string SQL_SELECT = "SELECT A.ZDFLID,A.FLMC,B.ZDID,B.ZDMC FROM SP_ZDFL a left join SP_TYZD B on  A.ZDFLID=B.ZDFLID and A.isDelete=0 ORDER BY A.FLMC,B.ZDMC";
        private const string SQL_SELECT_SINGLE = "SELECT ZDID,ZDMC FROM SP_TYZD WHERE ZDID=@ID";
        private const string SQL_SELECT_SINGLE_BY_NAME = "SELECT ZDID,ZDMC FROM SP_TYZD WHERE ZDMC=@name";
        private const string SQL_INSERT = "LE_TRA_City_Insert";
        private const string SQL_UPDATE = "LE_TRA_City_Update";
        private const string SQL_DELETE = "DELETE FROM SP_TYZD WHERE ZDID=@ID";
        private const string SQL_DELETE_Province = "DELETE FROM SP_ZDFL WHERE ZDFLID=@ID";

        public IList<CityInfo> ReadByExcelCity()
        {
            IList<CityInfo> nodes = new List<CityInfo>();
            using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT, null))
            {
                while (sdr.Read())
                {
                    CityInfo node = new CityInfo();
                    node.Name = Convert.ToString(sdr["FLMC"]);
                    node.Remark = Convert.ToString(sdr["ZDMC"]);
                    nodes.Add(node);
                }
            }
            return nodes;
        }
        public IList<CityInfo> Read(bool available)
        {
            int deleted = 1;
            if (available)
                deleted = 0;
            SqlParameter[] parms = { 
                new SqlParameter("@FLDeleted", deleted), 
                new SqlParameter("@ZDDeleted", deleted) };

            IList<CityInfo> nodes = new List<CityInfo>();
            int province = -1;
            int index = -1;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        if (province != (Convert.ToInt32(sdr["ZDFLID"])))
                        {
                            CityInfo node = new CityInfo();
                            node.ID = Convert.ToInt32(sdr["ZDFLID"]);
                            node.Name = Convert.ToString(sdr["FLMC"]);
                            node.Children = new List<CityInfo>();
                            nodes.Add(node);
                            province = node.ID;
                            index++;
                        }
                        if (sdr["ZDID"] != DBNull.Value)
                        {
                            CityInfo child = new CityInfo();
                            child.ID = Convert.ToInt32(sdr["ZDID"]);
                            child.Name = Convert.ToString(sdr["ZDMC"]);
                            nodes[index].Children.Add(child);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public CityInfo Read(int ID)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@ID", ID)};

            CityInfo node = new CityInfo();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_SINGLE, parms))
                {
                    if (sdr.Read())
                    {
                        node.ID = Convert.ToInt32(sdr["ZDID"]);
                        node.Name = Convert.ToString(sdr["ZDMC"]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }

        public CityInfo Read(string name)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@name", name)};

            CityInfo node = new CityInfo();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT_SINGLE_BY_NAME, parms))
                {
                    if (sdr.Read())
                    {
                        node.ID = Convert.ToInt32(sdr["ZDID"]);
                        node.Name = Convert.ToString(sdr["ZDMC"]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }

        public int Create(CityInfo node)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@ZDFLID", node.ProvinceID), 
                new SqlParameter("@ZDMC", node.Name),
                new SqlParameter("@ZDSM", node.Remark)};

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

        public int Update(CityInfo node)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@ZDID", node.ID), 
                new SqlParameter("@ZDFLID", node.ProvinceID), 
                new SqlParameter("@ZDMC", node.Name),
                new SqlParameter("@ZDSM", node.Remark)};

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
            SqlParameter[] parms = { new SqlParameter("@ID", ID) };

            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE, parms)) { }
            }
            catch (Exception e)
            {
                ID = 0;
            }

            return ID;
        }

        public int DeleteProvince(int ID)
        {
            SqlParameter[] parms = { new SqlParameter("@ID", ID) };


            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_DELETE_Province, parms)) { }
            }
            catch (Exception e)
            {
                ID = 0;
            }

            return ID;
        }
    }
}
