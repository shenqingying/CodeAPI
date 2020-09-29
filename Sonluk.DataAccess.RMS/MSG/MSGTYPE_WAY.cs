using Sonluk.Entities.MSG;
using Sonluk.IDataAccess.MSG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.MSG
{
    public class MSGTYPE_WAY : IMSGTYPE_WAY
    {
        private const string SQL_Create = "MSG_MSGTYPE_WAY_Create";
        //private const string SQL_Update = "MSG_MSGTYPE_WAY_Update";
        private const string SQL_ReadByParam = "MSG_MSGTYPE_WAY_ReadByParam";
        private const string SQL_Delete = "MSG_MSGTYPE_WAY_Delete";
        private const string SQL_DeleteByTYPEID = "MSG_MSGTYPE_WAY_DeleteByTYPEID";




        public int Create(MSG_MSGTYPE_WAY model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SENDWAYID", model.SENDWAYID),
                                        new SqlParameter("@TYPEID", model.TYPEID),



                                 };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);

        }

        //public int Update(MSG_MSGTYPE_WAY model)
        //{
        //    SqlParameter[] parms = {
        //                                new SqlParameter("@SENDWAYID", model.SENDWAYID),
        //                                new SqlParameter("@TYPEID", model.TYPEID),



        //                         };
        //    return Binning(CommandType.StoredProcedure, SQL_Update, parms);

        //}

        public IList<MSG_MSGTYPE_WAY> ReadByParam(MSG_MSGTYPE_WAY model)
        {
            SqlParameter[] parms = {
                                        
                                        new SqlParameter("@SENDWAYID", model.SENDWAYID),
                                        new SqlParameter("@TYPEID", model.TYPEID),



                                   };
            IList<MSG_MSGTYPE_WAY> nodes = new List<MSG_MSGTYPE_WAY>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByParam, parms))
                {
                    while (sdr.Read())
                    {
                        nodes.Add(ReadDataToObj(sdr));
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
            return nodes;
        }

        public int Delete(MSG_MSGTYPE_WAY model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SENDWAYID", model.SENDWAYID),
                                        new SqlParameter("@TYPEID", model.TYPEID),
                                 };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);

        }

        public int DeleteByTYPEID(int TYPEID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TYPEID", TYPEID)
                                 };
            return Binning(CommandType.StoredProcedure, SQL_DeleteByTYPEID, parms);

        }

        private MSG_MSGTYPE_WAY ReadDataToObj(SqlDataReader sdr)
        {
            MSG_MSGTYPE_WAY node = new MSG_MSGTYPE_WAY();
            node.SENDWAYID = Convert.ToInt32(sdr["SENDWAYID"]);
            node.TYPEID = Convert.ToInt32(sdr["TYPEID"]);
            node.SENDWAYSIGN = Convert.ToInt32(sdr["SENDWAYSIGN"]);
            node.WAYNAME = Convert.ToString(sdr["WAYNAME"]);
            node.MEDIUM = Convert.ToInt32(sdr["MEDIUM"]);
            node.MODEL = Convert.ToInt32(sdr["MODEL"]);
            node.SIGN = Convert.ToString(sdr["SIGN"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.MEDIUMDES = Convert.ToString(sdr["MEDIUMDES"]);

            node.SENDWAYSIGNDES = Convert.ToString(sdr["SENDWAYSIGNDES"]);
            node.MODELDES = Convert.ToString(sdr["MODELDES"]);
            return node;
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
