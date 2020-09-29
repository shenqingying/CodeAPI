using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sonluk.BusinessLogic.MM;

namespace Sonluk.API.Models
{
    public class MMModels
    {
        private PurchaseOrder _PurchaseOrder;
        private ScheduleRequisition _ScheduleRequisition;

        public PurchaseOrder PurchaseOrder
        {
            get
            {
                if (_PurchaseOrder == null)
                    _PurchaseOrder = new PurchaseOrder();
                return _PurchaseOrder;
            }
            set { _PurchaseOrder = value; }
        }

        public ScheduleRequisition ScheduleRequisition
        {
            get
            {
                if (_ScheduleRequisition == null)
                    _ScheduleRequisition = new ScheduleRequisition();
                return _ScheduleRequisition;
            }
            set { _ScheduleRequisition = value; }
        }
        private MATERIALINFO _MATERIALINFO;

        public MATERIALINFO MATERIALINFO
        {
            get
            {
                if (_MATERIALINFO == null)
                    _MATERIALINFO = new MATERIALINFO();
                return _MATERIALINFO;
            }
            set { _MATERIALINFO = value; }
        }
    }
}