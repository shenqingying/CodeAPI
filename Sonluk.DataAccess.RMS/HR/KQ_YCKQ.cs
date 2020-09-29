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
    public class KQ_YCKQ : IKQ_YCKQ
    {
        SY_EXCEPTION SY_EXCEPTIONservice = new SY_EXCEPTION();
        const string SQL_SELECT = "HR_KQ_YCKQ_SELECT";
        public HR_KQ_YCKQ_SELECT SELECT(HR_KQ_YCKQ model)
        {
            HR_KQ_YCKQ_SELECT rst = new HR_KQ_YCKQ_SELECT();
            MES_RETURN child_MES_RETURN = new MES_RETURN();
            try
            {
                SqlParameter[] paras = {
                                           new SqlParameter("@GS",model.GS),
                                           new SqlParameter("@DEPTID",model.DEPTID),
                                           new SqlParameter("@KQRQS",model.KQRQS),
                                           new SqlParameter("@KQRQE",model.KQRQE),
                                           new SqlParameter("@GH",model.GH),
                                           new SqlParameter("@STAFFID",model.STAFFID)
                                   };
                rst.DATALIST = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_SELECT, paras);
                child_MES_RETURN.TYPE = "S";
                child_MES_RETURN.MESSAGE = "";
            }
            catch (Exception e)
            {
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = e.Message;
                SY_EXCEPTIONservice.INSERT_SY(e.ToString(), "HR_KQ_YCKQ_SELECT", "HR");
            }
            rst.MES_RETURN = child_MES_RETURN;
            return rst;
        }
    }
}