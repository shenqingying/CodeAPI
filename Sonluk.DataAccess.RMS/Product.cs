using Sonluk.Entities.RMS;
using Sonluk.IDataAccess.RMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.RMS
{
    public class Product : IProduct
    {

        private const string SQL_TYPE_SELECT = "SELECT materialID,mtSpec FROM ZY_Material WHERE typeID='17' AND isDelete='0'";

        public DataTable getPMINFO(string PM, string CPGG, string LB)
        {
            string str = "SELECT OUTINFO FROM PMINFO WHERE PM=@PM AND CPGG=@CPGG AND LB=@LB";
            SqlParameter[] paras = {
                                       new SqlParameter("@PM",PM),
                                       new SqlParameter("@CPGG",CPGG),
                                       new SqlParameter("@LB",LB)
                                   };
            DataTable dt = SQLServerHelper.GetDataSet(CommandType.Text, str, paras);
            return dt;
        }

        public DataTable getYCLINFO(string SCXName, string CPID, string Date, string TLSJ)
        {
            string str = "SELECT TOP(1) * FROM YCLSY WHERE SCXName=@SCXName AND CPID=@CPID AND ((Date=@Date AND TLSJ<=@TLSJ) OR (Date<@Date)) ORDER BY Date DESC,TLSJ DESC";
            SqlParameter[] paras = {
                                       new SqlParameter("@SCXName",SCXName),
                                       new SqlParameter("@CPID",CPID),
                                       new SqlParameter("@Date",Date),
                                       new SqlParameter("@TLSJ",TLSJ)
                                   };
            DataTable dt = SQLServerHelper.GetDataSet(CommandType.Text, str, paras);
            return dt;
        }

        public DataTable getYCLINFO_new_td(string SCXName, string CPID, string Date, string TLSJ)
        {
            string str = @"
DECLARE @TLTM NVARCHAR(50)='';
SELECT TOP(1) @TLTM = TM
FROM[YCLSYB].[dbo].[V_MES_PD_TL] AS A
INNER JOIN MES_PD_SCRW AS B ON A.RWBH = B.RWBH
WHERE WLLBNAME = '集电体' AND SBH = @SCXName
AND TLRQ<=@Date AND A.ISDELETE=0
ORDER BY TLRQ DESC
with cte as
(
select XCTM from V_MES_TM_GL where SCTM = @TLTM AND GLLB = 1
union all
select A.XCTM from V_MES_TM_GL A join cte B on A.SCTM = B.XCTM AND A.GLLB = 1
)
select* from cte AS A INNER JOIN V_MES_TM_TMINFO AS B ON A.XCTM = B.TM
WHERE B.WLLBNAME = '电镀铜钉'

ORDER BY JLTIME DESC; ";
            SqlParameter[] paras = {
                                       new SqlParameter("@SCXName",SCXName),
                                       new SqlParameter("@CPID",CPID),
                                       new SqlParameter("@Date",Date+" "+TLSJ)
                                   };
            DataTable dt = SQLServerHelper.GetDataSet(CommandType.Text, str, paras);
            return dt;
        }
        public DataTable getYCLINFO_new_MFQ(string SCXName, string CPID, string Date, string TLSJ)
        {
            string str = @"
DECLARE @TLTM NVARCHAR(50)='';
SELECT TOP (1) @TLTM=TM
FROM [YCLSYB].[dbo].[V_MES_PD_TL] AS A 
INNER JOIN MES_PD_SCRW AS B ON A.RWBH=B.RWBH
WHERE WLLBNAME='集电体' AND SBH = @SCXName
AND TLRQ<=@Date AND A.ISDELETE=0
ORDER BY TLRQ DESC
with cte as
(
select XCTM from V_MES_TM_GL where SCTM = @TLTM AND GLLB=1
union all
select A.XCTM from V_MES_TM_GL A join cte B on A.SCTM = B.XCTM AND A.GLLB=1
)
select * from cte AS A INNER JOIN V_MES_TM_TMINFO AS B ON A.XCTM=B.TM
WHERE B.WLLBNAME='密封圈' AND B.GZZXBH=''
ORDER BY JLTIME DESC;";
            SqlParameter[] paras = {
                                       new SqlParameter("@SCXName",SCXName),
                                       new SqlParameter("@CPID",CPID),
                                       new SqlParameter("@Date",Date+" "+TLSJ)
                                   };
            DataTable dt = SQLServerHelper.GetDataSet(CommandType.Text, str, paras);
            return dt;
        }
        public DataTable getYCLINFO_new_GK(string SCXName, string CPID, string Date, string TLSJ)
        {
            string str = @"
DECLARE @TLTM NVARCHAR(50)='';
SELECT TOP (1) @TLTM=TM
FROM [YCLSYB].[dbo].[V_MES_PD_TL] AS A 
INNER JOIN MES_PD_SCRW AS B ON A.RWBH=B.RWBH
WHERE WLLBNAME='涂膜钢壳' AND SBH = @SCXName
AND TLRQ<=@Date AND A.ISDELETE=0
ORDER BY TLRQ DESC
with cte as
(
select XCTM from V_MES_TM_GL where SCTM = @TLTM AND GLLB=1
union all
select A.XCTM from V_MES_TM_GL A join cte B on A.SCTM = B.XCTM AND A.GLLB=1
)
select * from cte AS A INNER JOIN V_MES_TM_TMINFO AS B ON A.XCTM=B.TM
WHERE B.WLLBNAME='钢壳' AND B.GZZXBH=''
ORDER BY JLTIME DESC;";
            SqlParameter[] paras = {
                                       new SqlParameter("@SCXName",SCXName),
                                       new SqlParameter("@CPID",CPID),
                                       new SqlParameter("@Date",Date+" "+TLSJ)
                                   };
            DataTable dt = SQLServerHelper.GetDataSet(CommandType.Text, str, paras);
            return dt;
        }

        public DataTable getYCLINFO_new_ZJ(string SCXName, string CPID, string Date, string TLSJ)
        {
            string str = @"
DECLARE @TLTM NVARCHAR(50)='';
SELECT TOP (1) C.*
FROM [YCLSYB].[dbo].[V_MES_PD_TL] AS A 
INNER JOIN MES_PD_SCRW AS B ON A.RWBH=B.RWBH
INNER JOIN V_MES_TM_TMINFO AS C ON A.TM=C.TM
WHERE A.WLLBNAME='正极粉' AND A.ISDELETE=0 AND SBH=@SCXName
AND TLRQ<=@Date AND A.ISDELETE=0
ORDER BY TLRQ DESC";
            SqlParameter[] paras = {
                                       new SqlParameter("@SCXName",SCXName),
                                       new SqlParameter("@CPID",CPID),
                                       new SqlParameter("@Date",Date+" "+TLSJ)
                                   };
            DataTable dt = SQLServerHelper.GetDataSet(CommandType.Text, str, paras);
            return dt;
        }

        public DataTable getYCLINFO_new_FJ(string SCXName, string CPID, string Date, string TLSJ)
        {
            string str = @"
DECLARE @TLTM NVARCHAR(50)='';
SELECT TOP (1) C.*
FROM [YCLSYB].[dbo].[V_MES_PD_TL] AS A 
INNER JOIN MES_PD_SCRW AS B ON A.RWBH=B.RWBH
INNER JOIN V_MES_TM_TMINFO AS C ON A.TM=C.TM
WHERE A.WLLBNAME='锌膏' AND A.ISDELETE=0 AND SBH=@SCXName
AND TLRQ<=@Date AND A.ISDELETE=0
ORDER BY TLRQ DESC";
            SqlParameter[] paras = {
                                       new SqlParameter("@SCXName",SCXName),
                                       new SqlParameter("@CPID",CPID),
                                       new SqlParameter("@Date",Date+" "+TLSJ)
                                   };
            DataTable dt = SQLServerHelper.GetDataSet(CommandType.Text, str, paras);
            return dt;
        }

        public DataTable getYCLINFO_new_BB(string SCX, string SCRQ, string SCSJ)
        {
            string str = @"
DECLARE @TLTM NVARCHAR(50)=''
SELECT TOP(1) @TLTM=TM
FROM V_MES_TM_TMINFO AS A 
WHERE A.ISDELETE=0 AND SBHMS=@SCXName AND WLLBNAME='素电'
AND KSTIME<=@Date AND JSTIME>=@Date
AND ZFDCLB=0
ORDER BY JLTIME DESC
with cte as
(
select SCTM from V_MES_TM_GL where XCTM = @TLTM AND GLLB=1
union all
select A.SCTM from V_MES_TM_GL A join cte B on A.XCTM = B.SCTM AND GLLB=1
)
select * from cte AS A INNER JOIN V_MES_TM_TMINFO AS B ON A.SCTM=B.TM
WHERE B.WLLBNAME='包标电池'
ORDER BY JLTIME DESC;";
            SqlParameter[] paras = {
                                       new SqlParameter("@SCXName",SCX),
                                       new SqlParameter("@Date",SCRQ+" "+SCSJ)
                                   };
            DataTable dt = SQLServerHelper.GetDataSet(CommandType.Text, str, paras);
            return dt;
        }

        public DataTable getSDZH(string SCX, string SCRQ, string SCSJ)
        {
            string str = "SELECT materialID FROM ZY_Material WHERE mtSpec = @mtSpec";
            SqlParameter[] paras = {
                                       new SqlParameter("@mtSpec",SCX)
                                   };
            DataTable dt = SQLServerHelper.GetDataSet(CommandType.Text, str, paras);
            if (dt.Rows.Count > 0)
            {
                string scxid = dt.Rows[0][0].ToString();
                string sql = "SELECT TOP(1) SDZH,SDDATE FROM SDZHINFO WHERE SCX=@SCX AND ((DATERQE=@DATERQE AND TIMEE>@TIMEE) OR (DATERQE>@DATERQE)) ORDER BY DATERQE ASC,TIMEE ASC";
                SqlParameter[] paras1 = {
                                            new SqlParameter("@SCX",scxid),
                                            new SqlParameter("@DATERQE",SCRQ),
                                            new SqlParameter("@TIMEE",SCSJ)
                                        };
                DataTable dt1 = SQLServerHelper.GetDataSet(CommandType.Text, sql, paras1);
                if (dt1.Rows.Count > 0)
                {
                    DateTime dtime1 = Convert.ToDateTime(SCRQ);
                    DateTime dtime2 = Convert.ToDateTime(dt1.Rows[0]["SDDATE"].ToString());
                    if (dtime1.AddDays(7) < dtime2)
                    {
                        dt1.Clear();
                    }
                    return dt1;
                }
                else
                {
                    dt1.Clear();
                    return dt1;
                }
            }
            else
            {
                dt.Clear();
                return dt;
            }
        }

        public DataTable getBBDATE(string SDLINE, string SDDATE, string SDZH)
        {
            string str = "SELECT TOP(1) BBDATE,FZDH FROM SDINFO WHERE SDLINE=@SDLINE AND SDDATE=@SDDATE AND SDZH LIKE @SDZH";
            SqlParameter[] paras ={
                                      new SqlParameter("@SDLINE",SDLINE),
                                      new SqlParameter("@SDDATE",SDDATE),
                                      new SqlParameter("@SDZH","%"+SDZH+"%")
                                  };
            DataTable dt = SQLServerHelper.GetDataSet(CommandType.Text, str, paras);
            return dt;
        }

        public IList<BatteryInfo> Type()
        {
            DataTable dt = SQLServerHelper.GetDataSet(CommandType.Text, SQL_TYPE_SELECT);
            IList<BatteryInfo> nodes = new List<BatteryInfo>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BatteryInfo node = new BatteryInfo();
                    node.Type = dt.Rows[i]["mtSpec"].ToString();
                    //dt.Rows[i]["materialID"].ToString();
                    nodes.Add(node);
                }
            }
            return nodes;
        }
    }
}
