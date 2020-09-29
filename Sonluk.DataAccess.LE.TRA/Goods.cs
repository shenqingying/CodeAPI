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
    public class Goods : IGoods
    {

        private const string SQL_SELECT = "SELECT A.HWID, A.HWMC, A.SAPBH, A.LBID, A.LBMC, A.DJSL, A.SLDWID, A.SLDWMC, A.DJMZ, A.DJJZ, A.ZLDWID, A.ZLDW, A.DJTJ, A.TJDWID, A.TJDW, B.XSID, B.XSMC FROM SP_HWQD A, SP_HWLB B WHERE A.LBID = B.LBID AND A.SAPBH =@serialNumber";
        private const string SQL_INSERT = "LE_TRA_Goods_Insert";
        private const string SQL_UPDATE = "LE_TRA_Goods_Update";
        private const string SQL_TYPE_SELECT = "SELECT LBID, LBMC FROM SP_HWLB WHERE isDelete=@deleted";

        public GoodsInfo Read(string serialNumber)
        {
            SqlParameter[] parms = { new SqlParameter("@serialNumber", serialNumber) };
            GoodsInfo node = new GoodsInfo();
            try
            {
                using (SqlDataReader odr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_SELECT, parms))
                {
                    if (odr.Read())
                    {
                        node.ID = Convert.ToInt32(odr["HWID"]);
                        node.Name = Convert.ToString(odr["HWMC"]);
                        node.Material = Convert.ToString(odr["SAPBH"]);
                        node.TypeID = Convert.ToInt32(odr["LBID"]);
                        node.Type = Convert.ToString(odr["LBMC"]);
                        node.Quantity = Convert.ToDecimal(odr["DJSL"]);
                        node.UnitID = Convert.ToInt32(odr["SLDWID"]);
                        node.Unit = Convert.ToString(odr["SLDWMC"]);
                        node.GrossWeight = Convert.ToDecimal(odr["DJMZ"]);
                        node.NetWeight = Convert.ToDecimal(odr["DJJZ"]);
                        node.WeightUnitID = Convert.ToInt32(odr["ZLDWID"]);
                        node.WeightUnit = Convert.ToString(odr["ZLDW"]);
                        node.Volume = Convert.ToDecimal(odr["DJTJ"]);
                        node.VolumeUnitID = Convert.ToInt32(odr["TJDWID"]);
                        node.VolumeUnit = Convert.ToString(odr["TJDW"]);
                        node.Package = new PackageInfo();
                        node.Package.TypeID = Convert.ToInt32(odr["XSID"]);
                        node.Package.Type = Convert.ToString(odr["XSMC"]);
                        
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return node;
        }

        public int Create(GoodsInfo node)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@HWMC", node.Name),
                new SqlParameter("@SAPBH", node.Material),
                new SqlParameter("@LBID", node.TypeID),
                new SqlParameter("@LBMC", node.Type), 
                new SqlParameter("@DJSL", node.Quantity), 
                new SqlParameter("@SLDWID", node.UnitID),
                new SqlParameter("@SLDWMC", node.Unit), 
                new SqlParameter("@DJMZ", node.GrossWeight), 
                new SqlParameter("@DJJZ", node.NetWeight), 
                new SqlParameter("@ZLDWID", node.WeightUnitID),
                new SqlParameter("@ZLDW", node.WeightUnit),
                new SqlParameter("@DJTJ", node.Volume),
                new SqlParameter("@TJDWID", node.VolumeUnitID),
                new SqlParameter("@TJDW", node.VolumeUnit)};

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

        public int Update(GoodsInfo node)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@HWID", node.ID),
                new SqlParameter("@HWMC", node.Name),
                new SqlParameter("@SAPBH", node.Material),
                new SqlParameter("@LBID", node.TypeID),
                new SqlParameter("@LBMC", node.Type), 
                new SqlParameter("@DJSL", node.Quantity), 
                new SqlParameter("@SLDWID", node.UnitID),
                new SqlParameter("@SLDWMC", node.Unit), 
                new SqlParameter("@DJMZ", node.GrossWeight), 
                new SqlParameter("@DJJZ", node.NetWeight), 
                new SqlParameter("@ZLDWID", node.WeightUnitID),
                new SqlParameter("@ZLDW", node.WeightUnit),
                new SqlParameter("@DJTJ", node.Volume),
                new SqlParameter("@TJDWID", node.VolumeUnitID),
                new SqlParameter("@TJDW", node.VolumeUnit)};

            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms))
                {
                    ID = node.ID;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return ID;
        }

        public IList<GoodsInfo> Type(bool available)
        {
            int deleted = 1;
            if (available)
                deleted = 0;
            SqlParameter[] parms = { new SqlParameter("@deleted", deleted) };

            IList<GoodsInfo> nodes = new List<GoodsInfo>();

            try
            {
                using (SqlDataReader odr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_TYPE_SELECT, parms))
                {
                    while (odr.Read())
                    {
                        GoodsInfo node = new GoodsInfo();
                        node.TypeID = Convert.ToInt32(odr["LBID"]);
                        node.Type = Convert.ToString(odr["LBMC"]);
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
    }
}
