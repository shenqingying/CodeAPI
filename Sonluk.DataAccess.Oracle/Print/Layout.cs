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
    public class Layout : ILayout
    {
        private const string SQL_INSERT = "SONLUK_PRINT_LAYOUT_INSERT";
        private const string SQL_UPDATE = "SONLUK_PRINT_LAYOUT_UPDATE";
        private const string SQL_SELECT = "SELECT * FROM SONLUK_PRINT_LAYOUT ORDER BY ID";
        private const string SQL_SELECT_ID = "SELECT * FROM SONLUK_PRINT_LAYOUT WHERE ID = :ID ORDER BY ID";
        private const string SQL_SELECT_DOC_MAC = "SELECT * FROM SONLUK_PRINT_LAYOUT WHERE DOC = :Doc AND MAC =:Mac ORDER BY ID";
        private const string SQL_DELETE = "SONLUK_PRINT_LAYOUT_DELETE";

        public int Create(LayoutInfo node)
        {
            OracleParameter[] parms = {	
                new OracleParameter("v_Doc", OracleDbType.Varchar2),
                new OracleParameter("v_Mac", OracleDbType.Varchar2),
                new OracleParameter("v_Name", OracleDbType.NVarchar2),
                new OracleParameter("v_Background", OracleDbType.NVarchar2),
                new OracleParameter("v_Style", OracleDbType.Varchar2),
                new OracleParameter("v_Remark", OracleDbType.Varchar2),
                new OracleParameter("v_ID", OracleDbType.Int32)};

            parms[0].Value = node.Doc;
            parms[1].Value = node.Mac;
            parms[2].Value = node.Name;
            parms[3].Value = node.Background;
            parms[4].Value = node.Style;
            parms[5].Value = node.Remark;
            parms[6].Direction = ParameterDirection.Output;

            int ID = 0;
            try
            {

                OracleHelper.ExecuteNonQuery(OracleHelper.connectionString, CommandType.StoredProcedure, SQL_INSERT, parms);
                ID = Convert.ToInt32(parms[6].Value.ToString());
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return ID;
        }

        public bool Update(LayoutInfo node)
        {
            OracleParameter[] parms = {	
                new OracleParameter("v_ID", OracleDbType.Int32),
                new OracleParameter("v_Doc", OracleDbType.Varchar2),
                new OracleParameter("v_Mac", OracleDbType.Varchar2),
                new OracleParameter("v_Name", OracleDbType.NVarchar2),
                new OracleParameter("v_Background", OracleDbType.NVarchar2),
                new OracleParameter("v_Style", OracleDbType.Varchar2),
                new OracleParameter("v_Remark", OracleDbType.Varchar2)};

            parms[0].Value = node.ID;
            parms[1].Value = node.Doc;
            parms[2].Value = node.Mac;
            parms[3].Value = node.Name;
            parms[4].Value = node.Background;
            parms[5].Value = node.Style;
            parms[6].Value = node.Remark;


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

        public IList<LayoutInfo> Read()
        {
            IList<LayoutInfo> nodes = new List<LayoutInfo>();

            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.connectionString, CommandType.Text, SQL_SELECT, null))
                {
                    while (odr.Read())
                    {
                        LayoutInfo node = new LayoutInfo();
                        node.ID = Convert.ToInt32(odr["ID"]);
                        node.Doc = Convert.ToString(odr["Doc"]);
                        node.Mac = Convert.ToString(odr["Mac"]);
                        node.Name = Convert.ToString(odr["Name"]);
                        node.Background = Convert.ToString(odr["Background"]);
                        node.Style = Convert.ToString(odr["Style"]);
                        node.Remark = Convert.ToString(odr["Remark"]);
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

        public LayoutInfo Read(int ID)
        {
            OracleParameter param = new OracleParameter(":ID", OracleDbType.Int32);
            param.Value = ID;

            LayoutInfo node = new LayoutInfo();

            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.connectionString, CommandType.Text, SQL_SELECT_ID, param))
                {
                    if (odr.Read())
                    {
                        node.ID = Convert.ToInt32(odr["ID"]);
                        node.Doc = Convert.ToString(odr["Doc"]);
                        node.Mac = Convert.ToString(odr["Mac"]);
                        node.Name = Convert.ToString(odr["Name"]);
                        node.Background = Convert.ToString(odr["Background"]);
                        node.Style = Convert.ToString(odr["Style"]);
                        node.Remark = Convert.ToString(odr["Remark"]);
                        node.Status = Convert.ToInt32(odr["Status"]);
                    }
                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

            return node;
        }

        public LayoutInfo Read(string Doc, string Mac)
        {
            OracleParameter[] parms = {	
                new OracleParameter("v_Doc", OracleDbType.Varchar2),
                new OracleParameter("v_Mac", OracleDbType.Varchar2)};

            parms[0].Value = Doc;
            parms[1].Value = Mac;

            LayoutInfo node = new LayoutInfo();

            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.connectionString, CommandType.Text, SQL_SELECT_DOC_MAC, parms))
                {
                    if (odr.Read())
                    {
                        node.ID = Convert.ToInt32(odr["ID"]);
                        node.Doc = Convert.ToString(odr["Doc"]);
                        node.Mac = Convert.ToString(odr["Mac"]);
                        node.Name = Convert.ToString(odr["Name"]);
                        node.Background = Convert.ToString(odr["Background"]);
                        node.Style = Convert.ToString(odr["Style"]);
                        node.Remark = Convert.ToString(odr["Remark"]);
                        node.Status = Convert.ToInt32(odr["Status"]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
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
