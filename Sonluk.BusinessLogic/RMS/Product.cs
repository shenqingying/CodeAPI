using Sonluk.DAFactory;
using Sonluk.Entities.RMS;
using Sonluk.IDataAccess.RMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.RMS
{
    public class Product
    {
        private static readonly IProduct _DetaAccess = RMSDataAccess.CreateProduct();

        public IList<BatteryHistoryInfo> History(string code, string type)
        {
            int sum = 0;
            List<BatteryHistoryInfo> nodes = new List<BatteryHistoryInfo>();
            BatteryHistoryInfo node = new BatteryHistoryInfo();
            if (code.Trim() != "" && type.Trim() != "")
            {
                //if (code.Trim().Length == 10 || code.Trim().Length == 11)
                if (code.Trim().Length >= 10)
                {
                    if (code.Trim().Length == 11)
                    {
                        string lb1 = code.Substring(0, 2);
                        DataTable dt = _DetaAccess.getPMINFO(lb1, type.Trim(), "1");
                        if (dt.Rows.Count == 1)
                        {
                            node.ProducingLine = dt.Rows[0][0].ToString();
                        }
                        else
                        {
                            node.ProducingLine = "";
                        }
                        sum = sum + 2;
                    }
                    if (code.Trim().Length != 11)
                    {
                        string lb1 = code.Substring(0, 1);
                        DataTable dt = _DetaAccess.getPMINFO(lb1, type.Trim(), "1");
                        if (dt.Rows.Count == 1)
                        {
                            node.ProducingLine = dt.Rows[0][0].ToString();
                        }
                        else
                        {
                            node.ProducingLine = "";
                        }
                        sum = sum + 1;
                    }
                    string lb2 = code.Substring(sum, 1);
                    DateTime dtime = new DateTime();
                    string year = "";
                    string mouth = "";
                    string day = "";
                    DataTable dtyear = _DetaAccess.getPMINFO(lb2, "", "2");
                    if (dtyear.Rows.Count == 1)
                    {
                        year = dtyear.Rows[0][0].ToString();
                        sum = sum + 1;
                    }
                    else
                    {
                        year = "";
                        sum = sum + 1;
                    }
                    string lb3 = code.Substring(sum, 1);
                    DataTable dtmouth = _DetaAccess.getPMINFO(lb3, "", "3");
                    if (dtmouth.Rows.Count == 1)
                    {
                        mouth = dtmouth.Rows[0][0].ToString();
                        sum = sum + 1;
                    }
                    else
                    {
                        mouth = "";
                        sum = sum + 1;
                    }
                    string lb4 = code.Substring(sum, 1);
                    DataTable dtdcdj = _DetaAccess.getPMINFO(lb4, "", "4");
                    if (dtdcdj.Rows.Count == 1)
                    {
                        node.Level = dtdcdj.Rows[0][0].ToString();
                        sum = sum + 1;
                    }
                    else
                    {
                        node.Level = "";
                        sum = sum + 1;
                    }
                    if (code.Substring(sum, 1) == "-" || code.Substring(sum, 1) == "-" || code.Substring(sum, 1) == "_")
                    {
                        sum = sum + 3;
                    }
                    day = code.Substring(sum, 2);
                    sum = sum + 2;
                    _DetaAccess.getPMINFO(year + "-" + mouth + "-" + day, "", "4");
                    if (year != "" && mouth != "" && day != "")
                    {
                        string time = year + "-" + mouth + "-" + day;
                        dtime = Convert.ToDateTime(time);
                        node.ProducingDate = dtime.ToString("yyyy-MM-dd");
                    }
                    string SDTIME = code.Substring(sum, 2) + ":" + code.Substring(sum + 2, 2);
                    string SDZHTIME = code.Substring(sum, 4);
                    //DataTable dtTD = _DetaAccess.getYCLINFO(node.ProducingLine, "2", node.ProducingDate, SDTIME);
                    //if (dtTD.Rows.Count == 1)
                    //{
                    //    node.CopperNailVendor = dtTD.Rows[0]["TDCJName"].ToString();
                    //    node.CopperNailPlater = dtTD.Rows[0]["TDDDCJName"].ToString();
                    //    node.CopperNailBatch = dtTD.Rows[0]["TDPH"].ToString();
                    //    node.SealCircleLathe = dtTD.Rows[0]["CJCHName"].ToString();
                    //    node.SealCircleVendor = dtTD.Rows[0]["MFQCJName"].ToString();
                    //    node.SealCircleBatch = dtTD.Rows[0]["MFQPH"].ToString();
                    //}
                    //else
                    //{
                    //    node.CopperNailVendor = "";
                    //    node.CopperNailPlater = "";
                    //    node.CopperNailBatch = "";
                    //    node.SealCircleLathe = "";
                    //    node.SealCircleVendor = "";
                    //    node.SealCircleBatch = "";
                    //}

                    DataTable dtTD = _DetaAccess.getYCLINFO_new_td(node.ProducingLine, "2", node.ProducingDate, SDTIME);
                    if (dtTD.Rows.Count > 0)
                    {
                        node.CopperNailVendor = dtTD.Rows[0]["GYSMS"].ToString();
                        node.CopperNailPlater = dtTD.Rows[0]["SBHMS"].ToString();
                        node.CopperNailBatch = dtTD.Rows[0]["PC"].ToString();
                    }
                    else
                    {
                        node.CopperNailVendor = "";
                        node.CopperNailPlater = "";
                        node.CopperNailBatch = "";
                    }
                    DataTable dtMFQ = _DetaAccess.getYCLINFO_new_MFQ(node.ProducingLine, "2", node.ProducingDate, SDTIME);
                    if (dtMFQ.Rows.Count > 0)
                    {
                        node.SealCircleLathe = dtMFQ.Rows[0]["SBHMS"].ToString();
                        node.SealCircleVendor = dtMFQ.Rows[0]["GYSMS"].ToString();
                        node.SealCircleBatch = dtMFQ.Rows[0]["PC"].ToString();
                    }
                    else
                    {
                        node.SealCircleLathe = "";
                        node.SealCircleVendor = "";
                        node.SealCircleBatch = "";
                    }

                    //DataTable dtGK = _DetaAccess.getYCLINFO(node.ProducingLine, "3", node.ProducingDate, SDTIME);
                    //if (dtGK.Rows.Count == 1)
                    //{
                    //    node.SteelShellVendor = dtGK.Rows[0]["MFQCJName"].ToString();
                    //    node.SteelShellBatch = dtGK.Rows[0]["MFQPH"].ToString();
                    //    node.SteelShellLathe = dtGK.Rows[0]["CJCHName"].ToString();
                    //}
                    //else
                    //{
                    //    node.SteelShellVendor = "";
                    //    node.SteelShellBatch = "";
                    //    node.SteelShellLathe = "";
                    //}
                    DataTable dtGK = _DetaAccess.getYCLINFO_new_GK(node.ProducingLine, "3", node.ProducingDate, SDTIME);
                    if (dtGK.Rows.Count > 0)
                    {
                        node.SteelShellVendor = dtGK.Rows[0]["GYSMS"].ToString();
                        node.SteelShellBatch = dtGK.Rows[0]["PC"].ToString();
                        node.SteelShellLathe = dtGK.Rows[0]["SBHMS"].ToString();
                    }
                    else
                    {
                        node.SteelShellVendor = "";
                        node.SteelShellBatch = "";
                        node.SteelShellLathe = "";
                    }

                    //DataTable dtZJ = _DetaAccess.getYCLINFO(node.ProducingLine, "4", node.ProducingDate, SDTIME);
                    //if (dtZJ.Rows.Count == 1)
                    //{
                    //    node.PositivePole = dtZJ.Rows[0]["CJCHName"].ToString() + " " + dtZJ.Rows[0]["MFQPH"].ToString();
                    //}
                    //else
                    //{
                    //    node.PositivePole = "";
                    //}
                    DataTable dtZJ = _DetaAccess.getYCLINFO_new_ZJ(node.ProducingLine, "4", node.ProducingDate, SDTIME);
                    if (dtZJ.Rows.Count > 0)
                    {
                        node.PositivePole = dtZJ.Rows[0]["SBHMS"].ToString() + " " + dtZJ.Rows[0]["PFDH"].ToString();
                    }
                    else
                    {
                        node.PositivePole = "";
                    }

                    DataTable dtFJ = _DetaAccess.getYCLINFO_new_FJ(node.ProducingLine, "5", node.ProducingDate, SDTIME);
                    if (dtFJ.Rows.Count > 0)
                    {
                        node.NegativePole = dtFJ.Rows[0]["SBHMS"].ToString() + " " + dtFJ.Rows[0]["PFDH"].ToString();
                    }
                    else
                    {
                        node.NegativePole = "";
                    }

                    DataTable dtSDZH = _DetaAccess.getYCLINFO_new_BB(node.ProducingLine, node.ProducingDate, SDTIME);
                    //if (dtSDZH.Rows.Count > 0)
                    //{
                    //    string SDZH = dtSDZH.Rows[0]["SDZH"].ToString();
                    //    string SDDATE = dtSDZH.Rows[0]["SDDATE"].ToString();
                    //    string SCX = node.ProducingLine;
                    //    DataTable dtBBDATE = _DetaAccess.getBBDATE(SCX, SDDATE, SDZH);
                    //    if (dtBBDATE.Rows.Count > 0)
                    //    {
                    //        node.PackageDate = dtBBDATE.Rows[0]["BBDATE"].ToString();
                    //        node.Qualified = dtBBDATE.Rows[0]["FZDH"].ToString();
                    //    }
                    //    else
                    //    {
                    //        node.PackageDate = "";
                    //        node.Qualified = "";
                    //    }
                    //}
                    //else
                    //{
                    //    node.PackageDate = "";
                    //    node.Qualified = "";
                    //}
                    if (dtSDZH.Rows.Count > 0)
                    {
                        node.PackageDate = dtSDZH.Rows[0]["SCDATE"].ToString();
                        node.Qualified = dtSDZH.Rows[0]["REMARK"].ToString();
                    }
                    else
                    {
                        node.PackageDate = "";
                        node.Qualified = "";
                    }
                }
            }
            nodes.Add(node);
            return nodes;
        }

        public IList<BatteryInfo> Type()
        {
            return _DetaAccess.Type();
        }
    }
}
