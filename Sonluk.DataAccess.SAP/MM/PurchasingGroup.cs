using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.MM;
using Sonluk.IDataAccess.MM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.MM
{
    public class PurchasingGroup : IPurchasingGroup
    {
        public PurchasingGroupInfo Read(string serialNumber)
        {

            IRfcFunction func = RFC.Function("ZPURCHASING_GROUP_READ");
            func.SetValue("EKGRP", serialNumber);

            PurchasingGroupInfo node = new PurchasingGroupInfo();
            try
            {
                RFC.Invoke(func, false);
                IRfcStructure struc = func.GetStructure("PURGROUP");
                node.Client = Convert.ToInt32(struc.GetString("MANDT"));
                node.SerialNumber = struc.GetString("EKGRP");
                node.Description = struc.GetString("EKNAM");
                node.Telephone = struc.GetString("EKTEL");
                node.OutputDevice = struc.GetString("LDEST");
                node.Fax = struc.GetString("TELFX");
                node.TelephoneDiallingCode = struc.GetString("TEL_NUMBER");
                node.TelephoneExtension = struc.GetString("TEL_EXTENS");
                node.EMail = struc.GetString("SMTP_ADDR");
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;      
        }
    }
}
