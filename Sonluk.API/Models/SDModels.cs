using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sonluk.BusinessLogic.SD;

namespace Sonluk.API.Models
{
    public class SDModels
    {
        private SalesOrder _SalesOrder;
        private Report _Report;

        public SalesOrder SalesOrder
        {
            get
            {
                if (_SalesOrder == null)
                    _SalesOrder = new SalesOrder();
                return _SalesOrder;
            }
            set { _SalesOrder = value; }
        }
        public Report Report
        {
            get
            {
                if (_Report == null)
                    _Report = new Report();
                return _Report;
            }
            set { _Report = value; }
        }
        private CLIENTINFO _CLIENTINFO;

        public CLIENTINFO CLIENTINFO
        {
            get
            {
                if (_CLIENTINFO == null)
                    _CLIENTINFO = new CLIENTINFO();
                return _CLIENTINFO;
            }
            set { _CLIENTINFO = value; }
        }
    }
}