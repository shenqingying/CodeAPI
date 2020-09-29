using Sonluk.Entities.API;
using Sonluk.IDataAccess.Helper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Sonluk.DataAccess.RMS.Helper
{
    class Insights_Config : IInsights_Config
    {
        const string SQL_Insights_Config_Read = "Helper_Insights_Config_Read";
        const string SQL_Insights_Config_Update = "Helper_Insights_Config_Update";

        public ApiReturn Read(Helper_Insights_Config model)
        {
            ApiReturn<Helper_Insights_Config> rst = new ApiReturn<Helper_Insights_Config>();
            rst.data = new Helper_Insights_Config();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@CID",model.CID),
                                       new SqlParameter("@Name",model.Name),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Insights_Config_Read, parms))
                {
                    if (sdr.Read())
                    {
                        rst.data.CID = Convert.ToInt32(sdr["CID"]);
                        rst.data.Name = Convert.ToString(sdr["Name"]);
                        rst.data.Value = Convert.ToString(sdr["Value"]);
                        rst.data.Note = Convert.ToString(sdr["Note"]);
                        rst.success = true;
                    }
                    else
                    {
                        rst.AddCode(false, "00008");
                    }
                }
            }
            catch (Exception e)
            {
                rst.AddCode(false, "00005", e.Message);
            }
            return rst;
        }

        public ApiReturn Update(Helper_Insights_Config model)
        {
            ApiReturn<int> rst = new ApiReturn<int>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@CID",model.CID),
                                       new SqlParameter("@Name",model.Name),
                                       new SqlParameter("@Value",model.Value),
                                       new SqlParameter("@Note",model.Note),
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Insights_Config_Update, parms))
                {
                    if (sdr.Read())
                    {
                        rst.data = Convert.ToInt32(sdr["ID"]);
                        rst.AddCode(Convert.ToBoolean(sdr["Success"]), Convert.ToString(sdr["Code"]));
                    }
                    else
                    {
                        rst.AddCode(false, "00008");
                    }
                }
            }
            catch (Exception e)
            {
                rst.AddCode(false, "00005", e.Message);
            }
            return rst;
        }
    }
}
