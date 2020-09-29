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
    public class TM_CZR : ITM_CZR
    {
        string SQL_INSERT = "MES_TM_CZR_INSERT";
        string SQL_SELECT_CZR_NOW = "MES_TM_CZR_SELECT_CZR_NOW";
        string SQL_UPDATE_LEAVE = "MES_TM_CZR_UPDATE_LEAVE";
        string SQL_UPDATE_GW = "UPDATE MES_TM_CZR SET GWID=@GWID WHERE ID=@ID";
        public MES_RETURN INSERT(MES_TM_CZR model)
        {
            int count = 0;
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@CZLB",model.CZLB),
                                       new SqlParameter("@CZRGH",model.CZRGH),
                                       new SqlParameter("@CZRNAME",model.CZRNAME),
                                       new SqlParameter("@GWID",model.GWID),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@ISREPLACE",model.ISREPLACE)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        count = Convert.ToInt32(sdr["RYCOUNT"]);
                    }
                }
                if (count == 0)
                {
                    mr.TYPE = "S";
                    mr.MESSAGE = "";
                }
                else
                {
                    mr.TYPE = "E";
                    mr.MESSAGE = "该操作人已存在！";
                }
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
            }
            return mr;
        }

        public MES_TM_CZR_SELECT_CZR_NOW SELECT_CZR_NOW(MES_TM_CZR model)
        {
            MES_TM_CZR_SELECT_CZR_NOW rst = new MES_TM_CZR_SELECT_CZR_NOW();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            List<MES_TM_CZR> child_MES_TM_CZR = new List<MES_TM_CZR>();
            string czr = "";
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@GC",model.GC),
                                       new SqlParameter("@RWBH",model.RWBH),
                                       new SqlParameter("@CZLB",model.CZLB),
                                       new SqlParameter("@GZZXBH",model.GZZXBH),
                                       new SqlParameter("@SBBH",model.SBBH),
                                       new SqlParameter("@CZSJ",model.CZSJ)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_CZR_NOW, parms))
                {
                    while (sdr.Read())
                    {
                        MES_TM_CZR child = new MES_TM_CZR();
                        child.ID = Convert.ToInt32(sdr["ID"]);
                        child.GC = Convert.ToString(sdr["GC"]);
                        child.RWBH = Convert.ToString(sdr["RWBH"]);
                        child.CZLB = Convert.ToInt32(sdr["CZLB"]);
                        child.CZRGH = Convert.ToString(sdr["CZRGH"]);
                        child.CZRNAME = Convert.ToString(sdr["CZRNAME"]);
                        child.GWID = Convert.ToInt32(sdr["GWID"]);
                        child.GWNAME = Convert.ToString(sdr["GWNAME"]);
                        child.GZZXBH = Convert.ToString(sdr["GZZXBH"]);
                        child.SBBH = Convert.ToString(sdr["SBBH"]);
                        child_MES_TM_CZR.Add(child);
                    }
                }
                if (child_MES_TM_CZR.Count > 0)
                {
                    for (int i = 0; i < child_MES_TM_CZR.Count; i++)
                    {
                        if (czr == "")
                        {
                            czr = child_MES_TM_CZR[i].CZRNAME;
                        }
                        else
                        {
                            czr = czr + "," + child_MES_TM_CZR[i].CZRNAME;
                        }
                    }
                }
                rst.MES_TM_CZR = child_MES_TM_CZR;
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
                rst.MES_RETURN = child_MES_RETURN;
                rst.CZR = czr;
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = e.Message;
                rst.MES_RETURN = child_MES_RETURN;
            }
            return rst;
        }

        public MES_RETURN UPDATE_LEAVE(int ID)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ID",ID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_LEAVE, parms)) { }
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
            }
            return mr;
        }

        public MES_RETURN UPDATE_GW(MES_TM_CZR model)
        {
            MES_RETURN mr = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                       new SqlParameter("@GWID",model.GWID)
                                   };

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_UPDATE_GW, parms)) { }
                mr.TYPE = "S";
                mr.MESSAGE = "";
            }
            catch (Exception e)
            {
                //throw new ApplicationException(e.Message);
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
            }
            return mr;
        }
    }
}
