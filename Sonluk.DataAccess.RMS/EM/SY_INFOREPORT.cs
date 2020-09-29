using Sonluk.IDataAccess.EM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System.Data.SqlClient;
using System.Data;
using Sonluk.DataAccess.RMS.MES;
namespace Sonluk.DataAccess.RMS.EM
{
    public class SY_INFOREPORT : ISY_INFOREPORT
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        private const string SQL_Create = "EM_SY_INFOREPORT_Create";
        private const string SQL_Update = "EM_SY_INFOREPORT_Update";
        private const string SQL_Read = "EM_SY_INFOREPORT_Read";
        private const string SQL_Delete = "EM_SY_INFOREPORT_Delete";
        public MES_RETURN Create(EM_SY_INFOREPORT model)
        {
            MES_RETURN mr = new MES_RETURN();
            
            SqlParameter[] parms = {
                                        new SqlParameter("@ID",model.ID),
                                        new SqlParameter("@PLATFORMID",model.PLATFORMID),
                                        new SqlParameter("@PLATFORMMS",model.PLATFORMMS),
                                        new SqlParameter("@JLTIME",model.JLTIME),
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@STAFFNAME",model.STAFFNAME),
                                        new SqlParameter("@TM",model.TM),
                                        new SqlParameter("@TMTYPE",model.TMTYPE),
                                        new SqlParameter("@MANUALMS",model.MANUALMS),
                                        new SqlParameter("@TMTYPEMS",model.TMTYPEMS)

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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_INFOREPORT_Create");

            }
            return mr;           
        }

        public MES_RETURN Update(EM_SY_INFOREPORT model)
        {
            MES_RETURN mr = new MES_RETURN();
            SqlParameter[] parms = {
                                        new SqlParameter("@ID",model.ID),
                                        new SqlParameter("@PLATFORMID",model.PLATFORMID),
                                        new SqlParameter("@PLATFORMMS",model.PLATFORMMS),
                                        new SqlParameter("@JLTIME",model.JLTIME),
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@STAFFNAME",model.STAFFNAME),
                                        new SqlParameter("@TM",model.TM),
                                        new SqlParameter("@TMTYPE",model.TMTYPE),
                                        new SqlParameter("@MANUALMS",model.MANUALMS),
                                        new SqlParameter("@TMTYPEMS",model.TMTYPEMS)
                                   };
            try
            {
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Update, parms))
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
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_INFOREPORT_Update");

            }
            return mr;
        }

        public IList<EM_SY_INFOREPORT> Read(EM_SY_INFOREPORTList model)
        {
            IList<EM_SY_INFOREPORT> nodes = new List<EM_SY_INFOREPORT>();
            SqlParameter[] parms = {
                                       new SqlParameter("@ID",model.ID),
                                        new SqlParameter("@PLATFORMID",model.PLATFORMID),
                                        new SqlParameter("@PLATFORMMS",model.PLATFORMMS),
                                        new SqlParameter("@JLTIME",model.JLTIME),
                                        new SqlParameter("@STAFFID",model.STAFFID),
                                        new SqlParameter("@STAFFNAME",model.STAFFNAME),
                                        new SqlParameter("@TM",model.TM),
                                        new SqlParameter("@TMTYPE",model.TMTYPE),
                                        new SqlParameter("@MANUALMS",model.MANUALMS),
                                        new SqlParameter("@TMTYPEMS",model.TMTYPEMS),
                                        new SqlParameter("@KSTIME",model.KSTIME),
                                        new SqlParameter("@JSTIME",model.JSTIME)
                                   };
            try
            {

                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Read, parms))
                {
                    while (sdr.Read())
                    {
                        
                    }
                }
                return nodes;
            }
            catch (Exception e)
            {
                SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_INFOREPORT_READ");
                throw new ApplicationException(e.Message);
            }
        }

        public MES_RETURN Delete(int ID)
        {
            //MES_RETURN mr = new MES_RETURN();
            //SqlParameter[] parms = { 
            //                           new SqlParameter("@MANUALID",MANUALID)
            //                       };
            //try
            //{
            //    using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_Delete, parms)) { }
            //    mr.TYPE = "S";


            //}
            //catch (Exception e)
            //{
            //    mr.TYPE = "E";
            //    mr.MESSAGE = e.Message;
            //    SY_EXCEPTIONservice.INSERT(e.ToString(), "EM_SY_MANUAL_Delete");

            //}
            //return mr;
            return new MES_RETURN();
        }
    }
}
