using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.Master;
using Sonluk.Entities.MM;
using Sonluk.IDataAccess.Master;
using Sonluk.IDataAccess.MM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.Master
{
    public class Vendor : IVendor
    {
        public CompanyInfo Read(string serialNumber)
        {
            IRfcFunction func = RFC.Function("BAPI_VENDOR_GETDETAIL");
            func.SetValue("VENDORNO", String.Format("{0:D10}", Convert.ToInt32(serialNumber)));

            CompanyInfo node = new CompanyInfo();
            try
            {
                RFC.Invoke(func, false);
                IRfcStructure struc = func.GetStructure("GENERALDETAIL");
                node.SerialNumber = struc.GetString("VENDOR");
                node.Name = struc.GetString("NAME");
                node.City = struc.GetString("CITY");
                node.PostCode = struc.GetString("POSTL_CODE");
                node.Address = struc.GetString("STREET");
                node.Telephone = struc.GetString("TELEPHONE");
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }
    }
}
