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
    public class ComplaintItem : IComplaintItem
    {
        private const string SQL_READ = "SELECT * FROM SP_YCDJQD WHERE YCDJID=@ID";
        private const string SQL_INSERT = "LE_TRA_Complaint_Item_Insert";
        private const string SQL_DELETE = "LE_TRA_Complaint_Item_Delete";

        public List<ComplaintItemInfo> Read(int headerID)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@ID", headerID)};

            List<ComplaintItemInfo> nodes = new List<ComplaintItemInfo>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_READ, parms))
                {
                    while (sdr.Read())
                    {
                        ComplaintItemInfo node = new ComplaintItemInfo();
                        node.ID = Convert.ToInt32(sdr["YCQDID"]);
                        node.HeaderID = Convert.ToInt32(sdr["YCDJID"]);
                        node.Delivery = Convert.ToString(sdr["VBELN"]);
                        node.Material = Convert.ToString(sdr["WLBH"]);
                        node.MaterialDescription = Convert.ToString(sdr["WLMS"]);
                        node.ReturnWholeQty = Convert.ToInt32(sdr["THJS"]);
                        node.ReturnQty = Convert.ToDecimal(sdr["THSL"]);
                        node.ReturnReason = Convert.ToString(sdr["THYYMC"]);
                        node.UnitValue = Convert.ToDecimal(sdr["DJ"]);
                        node.DamageQty = Convert.ToDecimal(sdr["SHSL"]);
                        node.DamageValue = Convert.ToDecimal(sdr["SHJE"]);
                        node.ReworkValue = Convert.ToDecimal(sdr["CGF"]);
                        node.Sales = Convert.ToString(sdr["YWY"]);
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

        public int Create(ComplaintItemInfo node)
        {
            SqlParameter[] parms = { 
                new SqlParameter("@YCDJID", node.HeaderID),
                new SqlParameter("@VBELN", node.Delivery),
                new SqlParameter("@WLBH", node.Material),
                new SqlParameter("@WLMS", node.MaterialDescription), 
                new SqlParameter("@THJS", node.ReturnWholeQty), 
                new SqlParameter("@THSL", node.ReturnQty), 
                new SqlParameter("@THYYMC", node.ReturnReason),
                new SqlParameter("@DJ", node.UnitValue),
                new SqlParameter("@SHSL", node.DamageQty), 
                new SqlParameter("@SHJE", node.DamageValue),
                new SqlParameter("@CGF",node.ReworkValue),
                new SqlParameter("@YWY", node.Sales)};

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

        public int Delete(int headerID)
        {
            throw new NotImplementedException();
        }
    }
}
