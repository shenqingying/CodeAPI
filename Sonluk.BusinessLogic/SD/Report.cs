using Sonluk.DAFactory;
using Sonluk.Entities.SD;
using Sonluk.IDataAccess.SD;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sonluk.BusinessLogic.SD
{
    public class Report
    {
        private static readonly IReport detaAccess = SDDataAccess.CreateReport();

        public IList<ReportInfo> AC(string dateStart, string dateEnd, string customer)
        {
            dateStart = Regex.Replace(dateStart, @"[^\d]*", "");
            dateEnd = Regex.Replace(dateEnd, @"[^\d]*", ""); 
            return detaAccess.AC(dateStart, dateEnd, customer);
        }

        public IList<ReportInfo> SO(string customerPOStart, string customerPOEnd, string dateStart, string dateEnd, string materialStart, string materialEnd)
        {
            dateStart = Regex.Replace(dateStart, @"[^\d]*", "");
            dateEnd = Regex.Replace(dateEnd, @"[^\d]*", ""); 
            return detaAccess.SO(customerPOStart, customerPOEnd, dateStart, dateEnd, materialStart, materialEnd);
        }

        public IList<ReportInfo> SH(string customerPOStart, string customerPOEnd, string dateStart, string dateEnd, string materialStart, string materialEnd)
        {
            dateStart = Regex.Replace(dateStart, @"[^\d]*", "");
            dateEnd = Regex.Replace(dateEnd, @"[^\d]*", ""); 
            return detaAccess.SH(customerPOStart, customerPOEnd, dateStart, dateEnd, materialStart, materialEnd);
        }

        public IList<ReportInfo> SHFH(string customer, string dateStart, string dateEnd)
        {
            customer = Convert.ToDecimal(customer).ToString("0000000000");
            dateStart = Regex.Replace(dateStart, @"[^\d]*", "");
            dateEnd = Regex.Replace(dateEnd, @"[^\d]*", ""); 
            return detaAccess.SHFH(customer, dateStart, dateEnd);
        }

        public IList<ReportInfo> ZKMX(string customer, string dateStart, string dateEnd)
        {
            //if (dateStart.IndexOf("CTS") > 0)
            //{
            //    CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            //    string format = "ddd MMM dd HH:mm:ss CST yyyy";
            //    DateTime startDateTime = DateTime.ParseExact(dateStart, format, culture);
            //    DateTime endDateTime = DateTime.ParseExact(dateEnd, format, culture);

            //    dateStart = startDateTime.ToString("yyyyMMdd");
            //    dateEnd = endDateTime.ToString("yyyyMMdd");

            //}else {
            //    dateStart = Regex.Replace(dateStart, @"[^\d]*", "");
            //    dateEnd = Regex.Replace(dateEnd, @"[^\d]*", "");
            //}

            dateStart = Regex.Replace(dateStart, @"[^\d]*", "");
            dateEnd = Regex.Replace(dateEnd, @"[^\d]*", "");
            return detaAccess.ZKMX(customer, dateStart, dateEnd);
        }
    }
}
 