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
    public class KH_HZHB : IKH_HZHB
    {
        private const string SQL_Create = @"INSERT INTO CRM_KH_HZHB(SAPSN,XSZZ,FXQD,CPZ,HZHBGN,HZHBJSQ,HZHBKHID,SFSAPSJ,ISACTIVE,BEIZ)VALUES(@SAPSN,@XSZZ,@FXQD,@CPZ,@HZHBGN,@HZHBJSQ,@HZHBKHID,@SFSAPSJ,@ISACTIVE,@BEIZ);";
        private const string SQL_Update = "CRM_KH_HZHB_UpdateDataBySap";//暂时没有修改功能
        private const string SQL_Read = "CRM_KH_HZHB_Read";//@"SELECT CRM_KH_HZHB.HZHBGN AS HZHBGN,CRM_KH_HZHB.HZHBJSQ AS HZHBJSQ,CRM_KH_HZHB.HZHBKHID AS HZHBKHID,CRM_KH_KH.MC AS MC,CRM_KH_KH.KPDZ AS KHSHDZ,CRM_KH_KH.GSLXR AS KHSHLXR,CRM_KH_KH.GSLXDH AS KHSHLXDH,(SELECT CS FROM CRM_KH_KH WHERE SAPSN = CRM_KH_HZHB.HZHBKHID) AS CS,ISNULL((SELECT DICNAME FROM CRM_HG_DICT WHERE DICID = (SELECT CS FROM CRM_KH_KH WHERE SAPSN = CRM_KH_HZHB.HZHBKHID)),0) AS CSDES FROM CRM_KH_HZHB INNER JOIN CRM_KH_KH ON CRM_KH_HZHB.HZHBKHID = CRM_KH_KH.SAPSN WHERE CRM_KH_HZHB.ISACTIVE = 1 AND CRM_KH_HZHB.SAPSN = @SAPSN AND CRM_KH_KH.ISDELETE = 0 ORDER BYCRM_KH_HZHB.HZHBGN DESC";
        private const string SQL_Delete = "DELETE FROM CRM_KH_HZHB WHERE SAPSN = @SAPSN";
        

        public int Create(CRM_KH_HZHB model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@SAPSN", model.SAPSN),
                                        new SqlParameter("@XSZZ", model.XSZZ),
                                        new SqlParameter("@FXQD", model.FXQD),
                                        new SqlParameter("@CPZ", model.CPZ),
                                        new SqlParameter("@HZHBGN", model.HZHBGN),
                                        new SqlParameter("@HZHBJSQ", model.HZHBJSQ),
                                        new SqlParameter("@HZHBKHID", model.HZHBKHID),
                                        new SqlParameter("@SFSAPSJ", model.SFSAPSJ),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@BEIZ", model.BEIZ)

                                   };
            return SQLServerHelper.ExecuteNonQuery(CommandType.Text, SQL_Create, parms);
        }


     








        public IList<CRM_KH_HZHBLIST> Read(string SAPSN)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@SAPSN",SAPSN)
                                   };

            IList<CRM_KH_HZHBLIST> nodes = new List<CRM_KH_HZHBLIST>();
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
                
                throw;
            }

            return nodes;

        }

        public int Delete(string SAPSN)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@SAPSN",SAPSN)
                                   };
            return SQLServerHelper.ExecuteNonQuery(CommandType.Text, SQL_Delete, parms);
        }





        private CRM_KH_HZHBLIST ReadDataToObject(SqlDataReader sdr)
        {
            CRM_KH_HZHBLIST node = new CRM_KH_HZHBLIST();
            node.HZHBGN = Convert.ToString(sdr["HZHBGN"]);
            node.HZHBJSQ = Convert.ToInt32(sdr["HZHBJSQ"]);
            node.HZHBKHID = Convert.ToString(sdr["HZHBKHID"]);
            node.MC = Convert.ToString(sdr["MC"]);
            node.KHSHDZ = Convert.ToString(sdr["KHSHDZ"]);
            node.KHSHLXR = Convert.ToString(sdr["KHSHLXR"]);
            node.KHSHLXDH = Convert.ToString(sdr["KHSHLXDH"]);
            node.CS = Convert.ToInt32(sdr["CS"]);
            node.CSDES = Convert.ToString(sdr["CSDES"]);


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
