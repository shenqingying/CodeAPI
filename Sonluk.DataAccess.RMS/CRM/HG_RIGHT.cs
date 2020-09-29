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
    public class HG_RIGHT : IHG_RIGHT
    {
        private const string SQL_Create = "CRM_HG_RIGHT_Create";
        private const string SQL_Update = "CRM_HG_RIGHT_Update";
        private const string SQL_ReadByRGROUPID = "CRM_HG_RIGHT_ReadByRGROUPID";//"SELECT * FROM CRM_HG_RIGHT WHERE ISACTIVE = 1 AND RGROUPID = @RGROUPID";
        private const string SQL_Delete = "CRM_HG_RIGHT_Delete";
        private const string SQL_Read = "CRM_HG_RIGHT_Read";//"SELECT A.*,ISNULL((SELECT RGROUPNAME FROM CRM_HG_RIGHTGROUP WHERE RGROUPID = A.RGROUPID),' ') AS RGROUPIDDES FROM CRM_HG_RIGHT AS A  WHERE ISACTIVE = 1";
        public int Create(CRM_HG_RIGHT model)
        {
            SqlParameter[] parms = {
                                        //new SqlParameter("@RIGHTID", model.RIGHTID),
                                        new SqlParameter("@RGROUPID", model.RGROUPID),
                                        new SqlParameter("@RIGHTNAME", model.RIGHTNAME),
                                        new SqlParameter("@RIGHTNO", model.RIGHTNO),
                                        new SqlParameter("@RIGHTADD", model.RIGHTADD),
                                        new SqlParameter("@RIGHTMEMO", model.RIGHTMEMO),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@IMAGELJ",model.IMAGELJ),
                                        new SqlParameter("@WX",model.WX),
                                        new SqlParameter("@PC",model.PC)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Create, parms);
        }

        public int Update(CRM_HG_RIGHT model)
        {
            SqlParameter[] parms = {
                                        new SqlParameter("@RIGHTID", model.RIGHTID),
                                        new SqlParameter("@RGROUPID", model.RGROUPID),
                                        new SqlParameter("@RIGHTNAME", model.RIGHTNAME),
                                        new SqlParameter("@RIGHTNO", model.RIGHTNO),
                                        new SqlParameter("@RIGHTADD", model.RIGHTADD),
                                        new SqlParameter("@RIGHTMEMO", model.RIGHTMEMO),
                                        new SqlParameter("@ISACTIVE", model.ISACTIVE),
                                        new SqlParameter("@IMAGELJ",model.IMAGELJ),
                                        new SqlParameter("@WX",model.WX),
                                        new SqlParameter("@PC",model.PC)

                                   };
            return Binning(CommandType.StoredProcedure, SQL_Update, parms);
        }
      
        public IList<CRM_HG_RIGHT> ReadByRGROUPID(int RGROUPID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@RGROUPID",RGROUPID)
                                   };
            IList<CRM_HG_RIGHT> nodes = new List<CRM_HG_RIGHT>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_ReadByRGROUPID, parms))
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
        public IList<CRM_HG_RIGHTList> Read()
        {
            IList<CRM_HG_RIGHTList> node = new List<CRM_HG_RIGHTList>();
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_Read,null))
                {
                    while (sdr.Read())
                    {
                        node.Add(ReadDataToObjectList(sdr));
                    }
                }
            }
            catch (Exception E)
            {
                
                throw new ApplicationException(E.Message);
            }
            return node;
        }

        public int Delete(int RIGHTID)
        {
            SqlParameter[] parms = {
                                       new SqlParameter("@RIGHTID",RIGHTID)
                                   };
            return Binning(CommandType.StoredProcedure, SQL_Delete, parms);
        }
        private CRM_HG_RIGHT ReadDataToObject(SqlDataReader sdr)
        {
            CRM_HG_RIGHT node = new CRM_HG_RIGHT();
            node.RIGHTID = Convert.ToInt32(sdr["RIGHTID"]);
            node.RGROUPID = Convert.ToInt32(sdr["RGROUPID"]);
            node.RIGHTNAME = Convert.ToString(sdr["RIGHTNAME"]);
            node.RIGHTNO = Convert.ToInt32(sdr["RIGHTNO"]);
            node.RIGHTADD = Convert.ToString(sdr["RIGHTADD"]);
            node.RIGHTMEMO = Convert.ToString(sdr["RIGHTMEMO"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.IMAGELJ = Convert.ToString(sdr["IMAGELJ"]);
            node.PC = Convert.ToInt32(sdr["PC"]);
            node.WX = Convert.ToInt32(sdr["WX"]);
            return node;
        }
        private CRM_HG_RIGHTList ReadDataToObjectList(SqlDataReader sdr)
        {
            CRM_HG_RIGHTList node = new CRM_HG_RIGHTList();
            node.RIGHTID = Convert.ToInt32(sdr["RIGHTID"]);
            node.RGROUPID = Convert.ToInt32(sdr["RGROUPID"]);
            node.RIGHTNAME = Convert.ToString(sdr["RIGHTNAME"]);
            node.RIGHTNO = Convert.ToInt32(sdr["RIGHTNO"]);
            node.RIGHTADD = Convert.ToString(sdr["RIGHTADD"]);
            node.RIGHTMEMO = Convert.ToString(sdr["RIGHTMEMO"]);
            node.ISACTIVE = Convert.ToInt32(sdr["ISACTIVE"]);
            node.IMAGELJ = Convert.ToString(sdr["IMAGELJ"]);
            node.RGROUPIDDES = Convert.ToString(sdr["RGROUPIDDES"]);
            node.PC = Convert.ToInt32(sdr["PC"]);
            node.WX = Convert.ToInt32(sdr["WX"]);
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
