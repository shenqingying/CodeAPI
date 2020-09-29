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
    public class SY_CHANGEINFO : ISY_CHANGEINFO
    {
        SY_EXCEPTION SY_EXCEPTIONService = new SY_EXCEPTION();
        const string SQL_INSERT = "MES_SY_CHANGEINFO_INSERT";
        const string SQL_SELECT = "MES_SY_CHANGEINFO_SELECT";
        public MES_RETURN INSERT(MES_SY_CHANGEINFO model)
        {
            MES_RETURN rst_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@CHANGGELB",model.CHANGGELB),
                                       new SqlParameter("@CHANGGEDJ",model.CHANGGEDJ),
                                       new SqlParameter("@CHANGETABLE",model.CHANGETABLE),
                                       new SqlParameter("@CHANGEZD",model.CHANGEZD),
                                       new SqlParameter("@OLDINFO",model.OLDINFO),
                                       new SqlParameter("@NEWINFO",model.NEWINFO),
                                       new SqlParameter("@CHANGEPEOPLE",model.CHANGEPEOPLE),
                                       new SqlParameter("@CHANGEGH",model.CHANGEGH),
                                       new SqlParameter("@CHANGENAME",model.CHANGENAME),
                                       new SqlParameter("@CHANGESY",model.CHANGESY)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_INSERT, parms))
                {
                    while (sdr.Read())
                    {
                        rst_MES_RETURN.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst_MES_RETURN.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst_MES_RETURN.TYPE = "E";
                rst_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONService.INSERT(e.ToString(), "SY_CHANGEINFO_INSERT");
            }
            return rst_MES_RETURN;
        }
        public MES_SY_CHANGEINFO_SELECT SELECT(MES_SY_CHANGEINFOLIST model)
        {
            MES_SY_CHANGEINFO_SELECT res = new MES_SY_CHANGEINFO_SELECT();
            List<MES_SY_CHANGEINFOLIST> nodes = new List<MES_SY_CHANGEINFOLIST>();
            MES_RETURN rst_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                       new SqlParameter("@CHANGETIMEKS",model.CHANGETIMEKS),
                                       new SqlParameter("@CHANGETIMEJS",model.CHANGETIMEJS)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure,SQL_SELECT,parms))
                {
                    while (sdr.Read())
                    {
                        MES_SY_CHANGEINFOLIST node = new MES_SY_CHANGEINFOLIST();
                        node.ID = Convert.ToInt32(sdr["ID"]);
                        node.CHANGGEDJ = Convert.ToString(sdr["CHANGGEDJ"]);
                        node.CHANGETABLE = Convert.ToString(sdr["CHANGETABLE"]);
                        node.CHANGEZD = Convert.ToString(sdr["CHANGEZD"]);
                        node.OLDINFO = Convert.ToString(sdr["OLDINFO"]);

                        node.NEWINFO = Convert.ToString(sdr["NEWINFO"]);
                        node.CHANGEPEOPLE = Convert.ToString(sdr["CHANGEPEOPLE"]);
                        node.CHANGETIME = Convert.ToString(sdr["CHANGETIME"]);
                        node.CHANGEGH = Convert.ToString(sdr["CHANGEGH"]);
                        node.CHANGENAME = Convert.ToString(sdr["CHANGENAME"]);
                        node.CHANGESY = Convert.ToString(sdr["CHANGESY"]);
                        nodes.Add(node);
                    }
                }
                res.MES_SY_CHANGEINFOLIST = nodes;
                if (nodes.Count > 0)
                {
                    rst_MES_RETURN.TYPE = "S";
                    rst_MES_RETURN.MESSAGE = "";
                }
                else
                {
                    rst_MES_RETURN.TYPE = "E";
                    rst_MES_RETURN.MESSAGE = "没有查询到数据！";
                }
                res.MES_RETURN = rst_MES_RETURN;
            }
            catch (Exception e)
            {
                rst_MES_RETURN.TYPE = "E";
                rst_MES_RETURN.MESSAGE = e.Message;
                res.MES_RETURN = rst_MES_RETURN;
                SY_EXCEPTIONService.INSERT(e.ToString(), "MES_SY_CHANGEINFO_SELECT");
                
            }
            return res;
           
        }
    }
}
