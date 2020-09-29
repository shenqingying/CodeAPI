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
    public class MSG_SENDWAY : IMSG_SENDWAY
    {
        private const string SQL_Create = "MSG_MSG_SENDWAY_Create";
        private const string SQL_Update = "MSG_MSG_SENDWAY_Update";
        private const string SQL_ReadByParam = "MSG_MSG_SENDWAY_ReadByParam";
        private const string SQL_Delete = "MSG_MSG_SENDWAY_Delete";




        public int Create(MSG_MSG_SENDWAY model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SENDWAYSIGN", model.SENDWAYSIGN),
                                        new SqlParameter("@WAYNAME", model.WAYNAME),
                                        new SqlParameter("@MEDIUM", model.MEDIUM),
                                        new SqlParameter("@MODEL", model.MODEL),
                                        new SqlParameter("@SIGN", model.SIGN),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR)




                                 };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);

        }

        public int Update(MSG_MSG_SENDWAY model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SENDWAYID", model.SENDWAYID),
                                        new SqlParameter("@SENDWAYSIGN", model.SENDWAYSIGN),
                                        new SqlParameter("@WAYNAME", model.WAYNAME),
                                        new SqlParameter("@MEDIUM", model.MEDIUM),
                                        new SqlParameter("@MODEL", model.MODEL),
                                        new SqlParameter("@SIGN", model.SIGN),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@XGR", model.XGR)




                                 };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);

        }

        public IList<MSG_MSG_SENDWAY> ReadByParam(MSG_MSG_SENDWAY model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SENDWAYID", model.SENDWAYID),
                                        new SqlParameter("@SENDWAYSIGN", model.SENDWAYSIGN),
                                        new SqlParameter("@WAYNAME", model.WAYNAME),
                                        new SqlParameter("@MEDIUM", model.MEDIUM),
                                        new SqlParameter("@SIGN", model.SIGN),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),




                                   };
            IList<MSG_MSG_SENDWAY> nodes = new List<MSG_MSG_SENDWAY>();
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

        public int Delete(int SENDWAYID, int XGR)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SENDWAYID", SENDWAYID),
                                        new SqlParameter("@XGR", XGR)
                                 };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);

        }


        private MSG_MSG_SENDWAY ReadDataToObj(SqlDataReader sdr)
        {
            MSG_MSG_SENDWAY node = new MSG_MSG_SENDWAY();
            node.SENDWAYID = Convert.ToInt32(sdr["SENDWAYID"]);
            node.SENDWAYSIGN = Convert.ToInt32(sdr["SENDWAYSIGN"]);
            node.WAYNAME = Convert.ToString(sdr["WAYNAME"]);
            node.MEDIUM = Convert.ToInt32(sdr["MEDIUM"]);
            node.MODEL = Convert.ToInt32(sdr["MODEL"]);
            node.SIGN = Convert.ToString(sdr["SIGN"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");
            node.XGR = Convert.ToInt32(sdr["XGR"]);
            node.XGSJ = Convert.ToDateTime(sdr["XGSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);
            node.XGRNAME = Convert.ToString(sdr["XGRNAME"]);
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
