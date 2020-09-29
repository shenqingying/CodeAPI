﻿using Sonluk.DataAccess.RMS.MES;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.HR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.HR
{
    public class KQ_RYID_BZID : IKQ_RYID_BZID
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_SELECT = "HR_KQ_RYID_BZID_SELECT";
        const string SQL_UPDATE = "HR_KQ_RYID_BZID_UPDATE";
        public MES_RETURN UPDATE(HR_KQ_RYID_BZID model, int LB)
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                SqlParameter[] parms = {
                                           new SqlParameter("@RYIDOLD",model.RYIDOLD),
                                           new SqlParameter("@RYIDNEW",model.RYIDNEW),
                                           new SqlParameter("@BZID",model.BZID),
                                           new SqlParameter("@LB",LB)
                                   };
                using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE, parms))
                {
                    while (sdr.Read())
                    {
                        rst.TYPE = Convert.ToString(sdr["TYPE"]);
                        rst.MESSAGE = Convert.ToString(sdr["MESSAGE"]);
                    }
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_RYID_BZID_UPDATE", "HR");
            }
            return rst;
        }
        public HR_KQ_RYID_BZID_SELECT SELECT(HR_KQ_RYID_BZID model, int LB)
        {
            HR_KQ_RYID_BZID_SELECT rst = new HR_KQ_RYID_BZID_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@GH",model.GH),
                                           new SqlParameter("@LB",LB)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_RYID_BZID_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}
