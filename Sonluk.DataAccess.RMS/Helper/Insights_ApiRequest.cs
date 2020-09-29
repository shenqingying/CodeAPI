using Sonluk.Entities.API;
using Sonluk.IDataAccess.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sonluk.DataAccess.RMS.Helper
{
    class Insights_ApiRequest : IInsights_ApiRequest
    {
        const string SQL_Insights_ApiRequest_Read = "Helper_Insights_ApiRequest_Read";
        const string SQL_Insights_ApiRequest_Create = "Helper_Insights_ApiRequest_Create";
        const string SQL_Insights_ApiRequest_Update = "Helper_Insights_ApiRequest_Update";
        const string SQL_Insights_ApiRequest_ErrorMsg_Read = "Helper_Insights_ApiRequest_ErrorMsg_Read";
        const string SQL_Insights_ApiRequest_ErrorMsg_Create = "Helper_Insights_ApiRequest_ErrorMsg_Create";

        public ApiReturn Read(Helper_Insights_ApiRequest model)
        {
            ApiReturn<List<Helper_Insights_ApiRequest>> rst = new ApiReturn<List<Helper_Insights_ApiRequest>>();
            rst.data = new List<Helper_Insights_ApiRequest>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@ApiName",model.ApiName),
                                       new SqlParameter("@ApiAdress",model.ApiAdress),
                                       new SqlParameter("@Operation",model.Operation),
                                       new SqlParameter("@Host",model.Host),
                                       new SqlParameter("@Client",model.Client),
                                       new SqlParameter("@StaffID",model.StaffID),
                                       new SqlParameter("@Content",model.Content),
                                       new SqlParameter("@DateCreateS",model.DateCreate),
                                       new SqlParameter("@DateCreateE",model.DateCreateE),
                                       new SqlParameter("@DateModifyS",model.DateModify),
                                       new SqlParameter("@DateModifyE",model.DateModifyE),
                                       new SqlParameter("@Access",model.Access),
                                       new SqlParameter("@Status",model.Status),
                                       new SqlParameter("@ErrorTag",model.ErrorTag)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Insights_ApiRequest_Read, parms))
                {
                    while (sdr.Read())
                    {
                        rst.data.Add(new Helper_Insights_ApiRequest
                        {
                            ID = Convert.ToInt64(sdr["ID"]),
                            ApiName = Convert.ToString(sdr["ApiName"]),
                            ApiAdress = Convert.ToString(sdr["ApiAdress"]),
                            Operation = Convert.ToString(sdr["Operation"]),
                            Host = Convert.ToString(sdr["Host"]),
                            Client = Convert.ToString(sdr["Client"]),
                            StaffID = Convert.ToInt32(sdr["StaffID"]),
                            Content = Convert.ToString(sdr["Content"]),
                            DateCreate = (DateTime)sdr["DateCreate"],
                            DateModify = (DateTime)sdr["DateModify"],
                            Access = Convert.ToString(sdr["Access"]),
                            Status = Convert.ToString(sdr["Status"]),
                            ErrorTag = Convert.ToString(sdr["ErrorTag"])
                        });
                    }
                    rst.success = true;
                }
            }
            catch (Exception e)
            {
                rst.AddCode(false, "00005", e.Message);
            }
            return rst;
        }

        public ApiReturn Create(Helper_Insights_ApiRequest model)
        {
            ApiReturn<long> rst = new ApiReturn<long>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ApiName",model.ApiName),
                                       new SqlParameter("@ApiAdress",model.ApiAdress),
                                       new SqlParameter("@Operation",model.Operation),
                                       new SqlParameter("@Host",model.Host),
                                       new SqlParameter("@Client",model.Client),
                                       new SqlParameter("@StaffID",model.StaffID),
                                       new SqlParameter("@Content",model.Content),
                                       new SqlParameter("@Access",model.Access),
                                       new SqlParameter("@Status",model.Status),
                                       new SqlParameter("@ErrorTag",model.ErrorTag)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Insights_ApiRequest_Create, parms))
                {
                    if (sdr.Read())
                    {
                        rst.data = Convert.ToInt64(sdr["ID"]);
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

        public ApiReturn Update(Helper_Insights_ApiRequest model)
        {
            ApiReturn rst = new ApiReturn();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@ApiName",model.ApiName),
                                       new SqlParameter("@ApiAdress",model.ApiAdress),
                                       new SqlParameter("@Operation",model.Operation),
                                       new SqlParameter("@Host",model.Host),
                                       new SqlParameter("@Client",model.Client),
                                       new SqlParameter("@StaffID",model.StaffID),
                                       new SqlParameter("@Content",model.Content),
                                       new SqlParameter("@Access",model.Access),
                                       new SqlParameter("@Status",model.Status),
                                       new SqlParameter("@ErrorTag",model.ErrorTag)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Insights_ApiRequest_Update, parms))
                {
                    if (sdr.Read())
                    {
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

        public ApiReturn ReadErrorMsgs(Helper_Insights_ApiRequest_ErrorMsg model)
        {
            ApiReturn<List<Helper_Insights_ApiRequest_ErrorMsg>> rst = new ApiReturn<List<Helper_Insights_ApiRequest_ErrorMsg>>();
            rst.data = new List<Helper_Insights_ApiRequest_ErrorMsg>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@AID",model.AID),
                                       new SqlParameter("@Code",model.Code),
                                       new SqlParameter("@Type",model.Type),
                                       new SqlParameter("@Message",model.Message)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Insights_ApiRequest_ErrorMsg_Read, parms))
                {
                    while (sdr.Read())
                    {
                        rst.data.Add(new Helper_Insights_ApiRequest_ErrorMsg
                        {
                            ID = Convert.ToInt64(sdr["ID"]),
                            AID = Convert.ToInt64(sdr["AID"]),
                            Code = Convert.ToString(sdr["Code"]),
                            Type = Convert.ToString(sdr["Type"]),
                            Message = Convert.ToString(sdr["Message"])
                        });
                    }
                    rst.success = true;
                }
            }
            catch (Exception e)
            {
                rst.AddCode(false, "00005", e.Message);
            }
            return rst;
        }

        public ApiReturn CreateErrorMsg(Helper_Insights_ApiRequest_ErrorMsg model)
        {
            ApiReturn<long> rst = new ApiReturn<long>();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@AID",model.AID),
                                       new SqlParameter("@Code",model.Code),
                                       new SqlParameter("@Type",model.Type),
                                       new SqlParameter("@Message",model.Message)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Insights_ApiRequest_ErrorMsg_Create, parms))
                {
                    if (sdr.Read())
                    {
                        rst.data = Convert.ToInt64(sdr["ID"]);
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
