using Oracle.DataAccess.Client;
using Sonluk.Entities.Account;
using Sonluk.IDataAccess.SSO;
using Sonluk.DataAccess.Utility.Oracle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.Oracle.SSO
{
    public class Authorization : IAuthorization
    {   
        private const string SQL_SELECT = "SELECT DISTINCT(HG_RIGHT.RIGHTADD) Accesses FROM HG_RIGHT,HG_ROLERIGHT,(SELECT HG_ROLE.ROLEID,HG_STAFF.STAFFID FROM HG_ROLE,HG_STAFFROLE,HG_STAFF WHERE HG_STAFF.STAFFID=HG_STAFFROLE.STAFFID AND HG_STAFFROLE.ROLEID=HG_ROLE.ROLEID AND HG_ROLE.ISACTIVE=1) T WHERE T.ROLEID=HG_ROLERIGHT.ROLEID AND HG_ROLERIGHT.RIGHTID=HG_RIGHT.RIGHTID AND STAFFID=:ID";

        public IList<string> Read(int USN)
        {
            OracleParameter parm = new OracleParameter(":ID", OracleDbType.Int32);
            parm.Value = USN;

            IList<string> nodes = new List<string>();

            try
            {
                using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.connectionString, CommandType.Text, SQL_SELECT, parm))
                {
                    while (odr.Read())
                    {
                        string node = Convert.ToString(odr["Accesses"]);

                        nodes.Add(node);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            parm.Dispose();

            return nodes;
        }


        //直接复制自iCRM，仅改动实体类和部分语句，未改动逻辑。
        public IList<MenuInfo> Menu(int USN,int parent)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT DISTINCT HG_RIGHT.RIGHTNAME,HG_RIGHT.RIGHTADD,HG_RIGHT.RIGHTNO ");
            strSql.Append(" FROM HG_STAFFROLE,HG_ROLE,HG_ROLERIGHT,HG_RIGHT WHERE ");
            strSql.Append(" HG_STAFFROLE.STAFFID=:STAFFID AND HG_STAFFROLE.ROLEID=HG_ROLE.ROLEID AND  ");
            strSql.Append(" HG_ROLE.ROLEID = HG_ROLERIGHT.ROLEID AND HG_ROLE.ISACTIVE=1 AND ");
            strSql.Append(" HG_ROLERIGHT.RIGHTID = HG_RIGHT.RIGHTID AND HG_RIGHT.ISACTIVE=1 AND ");
            strSql.Append(" HG_RIGHT.RGROUPID = :RGROUPID ");
            strSql.Append(" ORDER BY HG_RIGHT.RIGHTNO ");

            OracleParameter[] parameters = {
                    new OracleParameter(":STAFFID", OracleDbType.Decimal,22),
                    new OracleParameter(":RGROUPID", OracleDbType.Decimal,22)	};
            parameters[0].Value = USN;
            parameters[1].Value = parent;
            IList<MenuInfo> list = new List<MenuInfo>();

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.connectionString, CommandType.Text, strSql.ToString(), parameters))
            {
                
                //功能
                while (odr.Read())
                {
                    MenuInfo model = new MenuInfo();

                    if (odr["RIGHTNO"] != null && odr["RIGHTNO"].ToString() != "")
                    {
                        model.ID = Convert.ToInt32(odr["RIGHTNO"].ToString());
                    }
                    if (odr["RIGHTADD"] != null && odr["RIGHTADD"].ToString() != "")
                    {
                        model.Uri = odr["RIGHTADD"].ToString();
                    }
                    if (odr["RIGHTNAME"] != null && odr["RIGHTNAME"].ToString() != "")
                    {
                        model.Node = odr["RIGHTNAME"].ToString();
                    }
                    list.Add(model);
                }
           
            }

            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("SELECT RGROUPID,RGROUPNAME ");
            strSql1.Append(" FROM HG_RIGHTGROUP WHERE ");
            strSql1.Append(" HG_RIGHTGROUP.PRGROUPID = :RGROUPID ");
            strSql1.Append(" ORDER BY HG_RIGHTGROUP.PRIGHTNO ");

            OracleParameter[] parameters1 = {new OracleParameter(":RGROUPID", OracleDbType.Decimal,22)};
            parameters1[0].Value = parent;

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.connectionString, CommandType.Text, strSql1.ToString(), parameters1))
            {
                while (odr.Read())
                {
                    MenuInfo model = new MenuInfo();

                    if (odr["RGROUPID"] != null && odr["RGROUPID"].ToString() != "")
                    {
                        model.ID = Convert.ToInt16(odr["RGROUPID"]);
                    }
                    if (odr["RGROUPNAME"] != null && odr["RGROUPNAME"].ToString() != "")
                    {
                        model.Node = odr["RGROUPNAME"].ToString();
                    }

                    model.Children = Menu(USN, model.ID).ToList();
                    if (model.Children.Count == 0)
                    {

                    }
                    else
                    {
                        list.Add(model);
                    }
                }
            }
            //功能组
          
            return list; 
        }

    }
}
