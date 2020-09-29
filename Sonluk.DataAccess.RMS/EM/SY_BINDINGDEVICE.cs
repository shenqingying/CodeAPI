using Sonluk.DataAccess.RMS.MES;
using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.EM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.EM
{
    public class SY_BINDINGDEVICE : ISY_BINDINGDEVICE
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "EM_SY_BINDINGDEVICE_Create";
        private const string SQL_Read = "SELECT * FROM EM_SY_BINDINGDEVICE WHERE MACADRESS = @MACADRESS AND ISDELETE = 0 AND ISBIND = 1";


        public Entities.MES.MES_RETURN Create(Entities.EM.EM_SY_BINDINGDEVICE model)
        {
            MES_RETURN mr = new MES_RETURN();
            
            SqlParameter[] parms = {
                                        //new SqlParameter("@MANUALID",model.MANUALID),
                                       new SqlParameter("@MACADRESS",model.MACADRESS),
                                        new SqlParameter("@SBBH",model.SBBH),
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@ISBIND",model.ISBIND),
                                        new SqlParameter("@ISDELETE",model.ISDELETE)

                                   };
            
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Create, parms))
                {
                    while (sdr.Read())
                    {
                        mr.TYPE = Convert.ToString(sdr["TYPE"]);
                        mr.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }

            }
            catch (Exception e)
            {
                mr.TYPE = "E";
                mr.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_BINDINGDEVICE_Create");

            }
            return mr;
        }

        public IList<Entities.EM.EM_SY_BINDINGDEVICE> Read(string macadress)
        {
            IList<EM_SY_BINDINGDEVICE> nodes = new List<EM_SY_BINDINGDEVICE>();
            SqlParameter[] parms = {
                                        new SqlParameter("@MACADRESS",macadress),
                                        
                                   };
            try
            {

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Read, parms))
                {
                    while (sdr.Read())
                    {
                        EM_SY_BINDINGDEVICE node = new EM_SY_BINDINGDEVICE();
                        node.MACADRESS = Convert.ToString(sdr["MACADRESS"]);  //MACADRESS
                        node.SBBH = Convert.ToString(sdr["SBBH"]);  //SBBH
                        node.STAFFID = Convert.ToInt32(sdr["STAFFID"]);  //STAFFID
                        node.ISBIND = Convert.ToInt32(sdr["ISBIND"]);  //ISBIND
                        node.ISDELETE = Convert.ToInt32(sdr["ISDELETE"]);  //ISDELETE
                        nodes.Add(node);

                    }
                }
                return nodes;
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_BINDINGDEVICE_READ");
                throw new ApplicationException(e.Message);
            }
        }
    }
}
