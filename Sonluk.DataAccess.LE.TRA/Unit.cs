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
    public class Unit : IUnit
    {
        private const string SQL_SELECT = "SELECT JLDWID, DWMC, ZWMC, DWSM FROM SP_JLDW WHERE isDelete=@deleted";

        public IList<UnitInfo> Read(bool available)
        {
            int deleted = 1;
            if (available)
                deleted = 0;
            SqlParameter[] parms = { new SqlParameter("@deleted", deleted) };

            IList<UnitInfo> nodes = new List<UnitInfo>();

            try
            {
                using (SqlDataReader odr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT, parms))
                {
                    while (odr.Read())
                    {
                        UnitInfo node = new UnitInfo();
                        node.ID = Convert.ToInt32(odr["JLDWID"]);
                        node.Symbol = Convert.ToString(odr["DWMC"]);
                        node.Name = Convert.ToString(odr["ZWMC"]);
                        node.Remark = Convert.ToString(odr["DWSM"]);
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

        public UnitInfo Read(int ID)
        {
            throw new NotImplementedException();
        }

        public int Create(UnitInfo node)
        {
            throw new NotImplementedException();
        }

        public int Update(GoodsInfo node)
        {
            throw new NotImplementedException();
        }

        public int Delete(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
