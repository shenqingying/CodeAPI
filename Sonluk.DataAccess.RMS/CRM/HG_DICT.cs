using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.CRM
{
    public class HG_DICT : IHG_DICT
    {
        private const string SQL_Create = "CRM_HG_DICT_Create";
        private const string SQL_Update = "CRM_HG_DICT_Update";
        private const string SQL_Read = "CRM_HG_DICT_Read";
        private const string SQL_Delete = "CRM_HG_DICT_Delete";
        private const string SQL_ReadTypeID = "CRM_HG_DICT_ReadTypeID";//"SELECT DICID FROM CRM_HG_DICT WHERE ISACTIVE = 1 AND DICNAME LIKE @DICNAME";
        private const string SQL_ReadByDICNAME = "CRM_HG_DICT_ReadByDICNAME";//"SELECT DICID FROM CRM_HG_DICT WHERE ISACTIVE = 1 AND DICNAME LIKE @DICNAME AND TYPEID = @TYPEID";
        private const string SQL_ReadByDICID = "CRM_HG_DICT_ReadByDICID";//"SELECT DICNAME FROM CRM_HG_DICT WHERE ISACTIVE = 1 AND DICID = @DICID";
        private const string SQL_ReadDICIDandType = "CRM_HG_DICT_ReadDICIDandType";
        private const string SQL_ReadByDICNAMEandFID = "CRM_HG_DICT_ReadByDICNAMEandFID";
        private const string SQL_ReadByParam = "CRM_HG_DICT_ReadByParam";
        public int Create(CRM_HG_DICT model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@DICID", model.DICID),
                                        new SqlParameter("@TYPEID", model.TYPEID),
                                        new SqlParameter("@DICNAME", model.DICNAME),
                                        new SqlParameter("@PP", model.PP),
                                        new SqlParameter("@DICMEMO", model.DICMEMO),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@FID", model.FID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_HG_DICT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@DICID", model.DICID),
                                        new SqlParameter("@TYPEID", model.TYPEID),
                                        new SqlParameter("@DICNAME", model.DICNAME),
                                        new SqlParameter("@PP", model.PP),
                                        new SqlParameter("@DICMEMO", model.DICMEMO),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@FID", model.FID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }

        public IList<CRM_HG_DICT> Read(int TYPEID, int FID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@TYPEID",TYPEID),
                                       new SqlParameter("@FID",FID)
                                   };
            IList<CRM_HG_DICT> nodes = new List<CRM_HG_DICT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObject(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;

        }
        
        public IList<CRM_HG_DICT> ReadByParam(CRM_HG_DICT model,int STAFFID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@DICID",model.DICID),
                                       new SqlParameter("@TYPEID",model.TYPEID),
                                       new SqlParameter("@DICNAME",model.DICNAME),
                                       new SqlParameter("@DICMEMO",model.DICMEMO),
                                       new SqlParameter("@FID",model.FID),
                                       new SqlParameter("@PP",model.PP),
                                       new SqlParameter("@STAFFID",STAFFID)
                                   };
            IList<CRM_HG_DICT> nodes = new List<CRM_HG_DICT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObject(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;

        }

        public int ReadDICID(string DICNAME)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@DICNAME", DICNAME)
                                   };
            return Convert.ToInt32(SQLServerHelper.ExecuteScalar(CommandType.StoredProcedure, SQL_ReadTypeID, parms));
        }

        public CRM_HG_DICT ReadByDICID(int DICID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@DICID",DICID)
                                   };
            CRM_HG_DICT nodes = new CRM_HG_DICT();
            try
            {
                //object obj = SQLServerHelper.ExecuteScalar(CommandType.StoredProcedure, SQL_ReadByDICID, parms);
                //res = obj.ToString();

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByDICID, parms))
                {
                    while (sdr.Read())
                    {
                        nodes = (ReadDataToObject(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }


        public int ReadDICIDandType(string DICNAME, int TYPEID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@DICNAME", DICNAME),
                                       new SqlParameter("@TYPEID",TYPEID)
                                   };
            return Convert.ToInt32(SQLServerHelper.ExecuteScalar(CommandType.StoredProcedure, SQL_ReadDICIDandType, parms));
        }


        public int ReadByDICNAME(string DICNAME, int typeID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@DICNAME","%"+DICNAME+"%"),
                                       new SqlParameter("@TYPEID",typeID)
                                   };
            return Convert.ToInt32(SQLServerHelper.ExecuteScalar(CommandType.StoredProcedure, SQL_ReadByDICNAME, parms));
        }

        public int ReadByDICNAMEandFID(string DICNAME, int typeID, int FID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@DICNAME","%"+DICNAME+"%"),
                                       new SqlParameter("@TYPEID",typeID),
                                       new SqlParameter("@FID",FID)
                                   };
            return Convert.ToInt32(SQLServerHelper.ExecuteScalar(CommandType.StoredProcedure, SQL_ReadByDICNAMEandFID, parms));
        }

        private CRM_HG_DICT ReadDataToObject(SqlDataReader sdr)
        {
            CRM_HG_DICT node = new CRM_HG_DICT();
            node.DICID = Convert.ToInt32(sdr["DICID"]);
            node.TYPEID = Convert.ToInt32(sdr["TYPEID"]);
            node.DICNAME = Convert.ToString(sdr["DICNAME"]);
            node.PP = Convert.ToString(sdr["PP"]);
            node.DICMEMO = Convert.ToString(sdr["DICMEMO"]);
            node.ISACTIVE = Convert.ToBoolean(sdr["ISACTIVE"]);
            node.FID = Convert.ToInt32(sdr["FID"]);

            return node;
        }

        public int Delete(int DICID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@DICID",DICID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }


        private int Binning(CommandType type, string sql, SqlParameter[] parms)
        {
            int ID = 0;
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(type, sql, parms))
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

    }
}
