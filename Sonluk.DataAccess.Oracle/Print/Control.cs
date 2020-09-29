using Oracle.DataAccess.Client;
using Sonluk.DataAccess.Utility.Oracle;
using Sonluk.Entities.Print;
using Sonluk.IDataAccess.Print;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.Oracle.Print
{
    public class Control : IControl
    {
        private const string SQL_INSERT = "SONLUK_PRINT_CONTROL_INSERT";
        private const string SQL_UPDATE = "SONLUK_PRINT_CONTROL_UPDATE";
        private const string SQL_SELECT = "SELECT * FROM SONLUK_PRINT_CONTROL WHERE Layout = :Parent";
        private const string SQL_DELETE = "SONLUK_PRINT_CONTROL_DELETE";

        public int Create(ControlInfo node)
        {
            OracleParameter[] parms = {	
                new OracleParameter("v_Type", OracleDbType.Varchar2),
                new OracleParameter("v_Layout", OracleDbType.Int32),
                new OracleParameter("v_Value", OracleDbType.Varchar2),
                new OracleParameter("v_Style", OracleDbType.Varchar2),
                new OracleParameter("v_ID", OracleDbType.Int32)};

            parms[0].Value = node.Type;
            parms[1].Value = node.Layout;
            parms[2].Value = node.Value;
            parms[3].Value = node.Style;
            parms[4].Direction = ParameterDirection.Output;

            int ID = 0;
            try
            {

                OracleHelper.ExecuteNonQuery(OracleHelper.connectionString, CommandType.StoredProcedure, SQL_INSERT, parms);
                ID = Convert.ToInt32(parms[4].Value.ToString());
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return ID;
        }

        public bool Update(ControlInfo node)
        {
            OracleParameter[] parms = {	
                new OracleParameter("v_ID", OracleDbType.Int32),
                new OracleParameter("v_Value", OracleDbType.Varchar2),
                new OracleParameter("v_Style", OracleDbType.NVarchar2)};

            parms[0].Value = node.ID;
            parms[1].Value = node.Value;
            parms[2].Value = node.Style;

            bool achieve = false;
            try
            {

                OracleHelper.ExecuteNonQuery(OracleHelper.connectionString, CommandType.StoredProcedure, SQL_UPDATE, parms);
                achieve = true;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return achieve;
        }

        public IList<ControlInfo> Read(int parent)
        {
            OracleParameter param = new OracleParameter(":Parent", OracleDbType.Int32);
            param.Value = parent;

            IList<ControlInfo> nodes = new List<ControlInfo>();

            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.connectionString, CommandType.Text, SQL_SELECT, param))
                {
                    while (odr.Read())
                    {
                        ControlInfo node = new ControlInfo();
                        node.ID = Convert.ToInt32(odr["ID"]);
                        node.Type = Convert.ToString(odr["Type"]);
                        node.Value = Convert.ToString(odr["Value"]);
                        node.Style = Convert.ToString(odr["Style"]);
                        node.Status = Convert.ToInt32(odr["Status"]);

                        nodes.Add(node);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public bool Delete(int ID)
        {
            OracleParameter param = new OracleParameter("v_ID", OracleDbType.Int32);
            param.Value = ID;

            bool achieve = false;
            try
            {

                OracleHelper.ExecuteNonQuery(OracleHelper.connectionString, CommandType.StoredProcedure, SQL_DELETE, param);

                achieve = true;

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return achieve;
        }
    }
}
