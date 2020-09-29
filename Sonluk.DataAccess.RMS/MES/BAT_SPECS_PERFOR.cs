using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.MES
{
    class BAT_SPECS_PERFOR : IBAT_SPECS_PERFOR
    {
        const string SQL_SELECT = "MES_DCDXNSZ_SELECT";
        const string SQL_UPDATE = "MES_DCDXNSZ_UPDATE";
        const string SQL_INSERT = "MES_DCDXNSZ_INSERT";
        const string SQL_DELETE = "MES_DCDXNSZ_DELETE";
        const string SQL_COVER = "MES_DCDXNSZ_COVER";
        const string SQL_MCOVER = "MES_DCDXNSZ_MCOVER";

        public MES_DCDXNSZ_SELECT SELECT(MES_DCDXNSZ_SEARCH model)
        {
            MES_DCDXNSZ_SELECT rst = new MES_DCDXNSZ_SELECT();
            rst.MES_DCDXNSZ = new List<MES_DCDXNSZ>();
            rst.MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RI",model.RI),
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@SCX",model.SCX),
                                       new SqlParameter("@SDDJ",model.SDDJ),
                                       new SqlParameter("@DATES",model.DATES),
                                       new SqlParameter("@DATEE",model.DATEE),
                                       new SqlParameter("@DATEM",model.DATEM)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parms))
                {
                    while (sdr.Read())
                    {
                        MES_DCDXNSZ child = new MES_DCDXNSZ();
                        child.RI = Convert.ToInt32(sdr["RI"]);
                        child.DCXH = Convert.ToString(sdr["DCXH"]);
                        child.DCXHRI = Convert.ToInt32(sdr["DCXHRI"]);
                        child.SCX = Convert.ToString(sdr["SCX"]);
                        child.SCXID = Convert.ToInt32(sdr["SCXID"]);
                        child.SDDJ = Convert.ToString(sdr["SDDJ"]);
                        child.SDDJRI = Convert.ToInt32(sdr["SDDJRI"]);
                        child.RQ = Convert.ToString(sdr["RQ"]);
                        child.SZ = Convert.ToString(sdr["SZ"]);
                        rst.MES_DCDXNSZ.Add(child);
                    }

                }
                rst.MES_RETURN.TYPE = "S";
                rst.MES_RETURN.MESSAGE = "SELECTED";
            }
            catch (Exception e)
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return rst;
        }

        public MES_RETURN UPDATE(MES_DCDXNSZ model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RI",model.RI),
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCXHRI",model.DCXHRI),
                                       new SqlParameter("@SCX",model.SCX),
                                       new SqlParameter("@SCXID",model.SCXID),
                                       new SqlParameter("@SDDJ",model.SDDJ),
                                       new SqlParameter("@SDDJRI",model.SDDJRI),
                                       new SqlParameter("@RQ",model.RQ),
                                       new SqlParameter("@SZ",model.SZ)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms)) { }
                rst.TYPE = "S";
                rst.MESSAGE = model.RI + "UPDATED";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return rst;
        }

        public MES_RETURN INSERT(MES_DCDXNSZ model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCXHRI",model.DCXHRI),
                                       new SqlParameter("@SCX",model.SCX),
                                       new SqlParameter("@SCXID",model.SCXID),
                                       new SqlParameter("@SDDJ",model.SDDJ),
                                       new SqlParameter("@SDDJRI",model.SDDJRI),
                                       new SqlParameter("@RQ",model.RQ),
                                       new SqlParameter("@SZ",model.SZ)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    if (sdr.Read())
                    {
                        rst.MESSAGE = Convert.ToString(sdr["RI"]) + "INSERTED";
                    }

                }
                rst.TYPE = "S";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return rst;
        }

        public MES_RETURN MCOVER(List<MES_DCDXNSZ> modelList)
        {
            MES_RETURN rst = new MES_RETURN();
            DataTable insertDT = BAT_SPECS_PERFOR_ADD.ToDataTable<MES_DCDXNSZ>(modelList);
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@table",insertDT),
                                       new SqlParameter("@NALL",insertDT.Rows.Count)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_MCOVER, parms))
                {
                    if (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return rst;
        }

        public MES_RETURN COVER(MES_DCDXNSZ model)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RI",model.RI),
                                       new SqlParameter("@DCXH",model.DCXH),
                                       new SqlParameter("@DCXHRI",model.DCXHRI),
                                       new SqlParameter("@SCX",model.SCX),
                                       new SqlParameter("@SCXID",model.SCXID),
                                       new SqlParameter("@SDDJ",model.SDDJ),
                                       new SqlParameter("@SDDJRI",model.SDDJRI),
                                       new SqlParameter("@RQ",model.RQ),
                                       new SqlParameter("@SZ",model.SZ)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_COVER, parms))
                {
                    if (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return rst;
        }

        public MES_RETURN DELETE(int RI)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@RI",RI)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_DELETE, parms)) { }
                rst.TYPE = "S";
                rst.MESSAGE = RI + "DELETED";
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                //SY_EXCEPTIONservice.INSERT(e.ToString(), "MM_CK_INSERT");
            }
            return rst;
        }
    }

    public static class BAT_SPECS_PERFOR_ADD
    {
        /// <summary>
        /// List转DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">集合</param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> list)
        {
            var type = typeof(T);

            var properties = type.GetProperties().ToList();

            var newDt = new DataTable(type.Name);

            properties.ForEach(propertie =>
            {
                Type columnType;
                if (propertie.PropertyType.IsGenericType && propertie.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    columnType = propertie.PropertyType.GetGenericArguments()[0];
                }
                else
                {
                    columnType = propertie.PropertyType;
                }

                newDt.Columns.Add(propertie.Name, columnType);
            });

            foreach (var item in list)
            {
                var newRow = newDt.NewRow();

                properties.ForEach(propertie =>
                {
                    newRow[propertie.Name] = propertie.GetValue(item, null) ?? DBNull.Value;
                });

                newDt.Rows.Add(newRow);
            }

            return newDt;
        }
    }
}
