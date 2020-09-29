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
    public class DuiBiReport : IDuiBiReport
    {
        private const string SQL_DuiBiReport = "HGDBDOC.dbo.RuK_DuiBiReport";

        public DataTable RuK_DuiBiReport(RuK_DuiBiReport model)
        {
            SqlParameter[] parms = {  
                                        new SqlParameter("@YEAR", model.YEAR),
                                        new SqlParameter("@MONTH", model.MONTH),
                                        new SqlParameter("@LB", model.LB)
                                   };
            DataTable dt = SQLServerHelper.GetDataSet(CommandType.StoredProcedure, SQL_DuiBiReport, parms);
            return dt;
        }
    }
}
