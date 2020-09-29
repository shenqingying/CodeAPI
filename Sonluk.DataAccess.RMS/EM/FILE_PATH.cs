using Sonluk.Entities.EM;
using Sonluk.IDataAccess.EM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS.EM
{
    public class FILE_PATH : IFILE_PATH
    {
        private const string SQL_Read = "SELECT * FROM EM_FILE_PATH WHERE TYPE = @type";
        private const string SQL_ReadByID = "SELECT * FROM EM_FILE_PATH WHERE pathid = @pathid";
        
        public EM_FILE_PATH Read(string type)
        {
            EM_FILE_PATH node = new EM_FILE_PATH();
            SqlParameter[] parms = {
                                       //new SqlParameter("@BBID",model.BBID),
                                new SqlParameter("@type",type)                            
                                   };
            using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_Read, parms))
            {
                while (sdr.Read())
                {
                    node.TYPE = Convert.ToString(sdr["TYPE"]);
                    node.PATH = Convert.ToString(sdr["PATH"]);
                    node.ROLE = Convert.ToString(sdr["ROLE"]);
                    node.VIRTUALPATH = Convert.ToString(sdr["VIRTUALPATH"]);
                    node.PATHID = Convert.ToInt32(sdr["PATHID"]);
                    node.IPPATH = Convert.ToString(sdr["IPPATH"]);
                }
            }
            return node;
        }
        public EM_FILE_PATH ReadByID(int pathid)
        {
            EM_FILE_PATH node = new EM_FILE_PATH();
            SqlParameter[] parms = {
                                       //new SqlParameter("@BBID",model.BBID),
                                new SqlParameter("@pathid",pathid)                            
                                   };
            using (SqlDataReader sdr = SQLServerHelper.ExecuteReader(CommandType.Text, SQL_ReadByID, parms))
            {
                while (sdr.Read())
                {
                    node.TYPE = Convert.ToString(sdr["TYPE"]);
                    node.PATH = Convert.ToString(sdr["PATH"]);
                    node.ROLE = Convert.ToString(sdr["ROLE"]);
                    node.VIRTUALPATH = Convert.ToString(sdr["VIRTUALPATH"]);
                    node.PATHID = Convert.ToInt32(sdr["PATHID"]);
                    node.IPPATH = Convert.ToString(sdr["IPPATH"]);
                }
            }
            return node;
        }

        
    }
}
