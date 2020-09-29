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
    public class MSG_TYPE : IMSG_TYPE
    {
        private const string SQL_Create = "MSG_MSG_TYPE_Create";
        private const string SQL_Update = "MSG_MSG_TYPE_Update";
        private const string SQL_ReadByParam = "MSG_MSG_TYPE_ReadByParam";
        private const string SQL_Delete = "MSG_MSG_TYPE_Delete";




        public int Create(MSG_MSG_TYPE model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@TYPENAME", model.TYPENAME),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@CJR", model.CJR),




                                 };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);

        }

        public int Update(MSG_MSG_TYPE model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@MSGTYPEID", model.MSGTYPEID),
                                        new SqlParameter("@TYPENAME", model.TYPENAME),
                                        new SqlParameter("@BEIZ", model.BEIZ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),





                                 };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);

        }

        public IList<MSG_MSG_TYPE> ReadByParam(MSG_MSG_TYPE model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@MSGTYPEID", model.MSGTYPEID),
                                        new SqlParameter("@TYPENAME", model.TYPENAME),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),




                                   };
            IList<MSG_MSG_TYPE> nodes = new List<MSG_MSG_TYPE>();
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

        public int Delete(int MSGTYPEID)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@MSGTYPEID", MSGTYPEID)
                                 };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);

        }


        private MSG_MSG_TYPE ReadDataToObj(SqlDataReader sdr)
        {
            MSG_MSG_TYPE node = new MSG_MSG_TYPE();
            node.MSGTYPEID = Convert.ToInt32(sdr["MSGTYPEID"]);
            node.TYPENAME = Convert.ToString(sdr["TYPENAME"]);
            node.BEIZ = Convert.ToString(sdr["BEIZ"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.CJR = Convert.ToInt32(sdr["CJR"]);
            node.CJSJ = Convert.ToDateTime(sdr["CJSJ"]).ToString("yyyy-MM-dd HH:mm:ss");

            node.CJRNAME = Convert.ToString(sdr["CJRNAME"]);

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
