using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.Master;
using Sonluk.IDataAccess.FI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.FI
{
    public class Company:ICompany
    {
        public CompanyInfo Read(string serialNumber)
        {
            IRfcFunction func = RFC.Function("BAPI_COMPANYCODE_GETDETAIL");
            func.SetValue("COMPANYCODEID", serialNumber);

            CompanyInfo node = new CompanyInfo();
            try
            {
                RFC.Invoke(func, false);
                IRfcStructure struc = func.GetStructure("COMPANYCODE_DETAIL");
                node.SerialNumber = struc.GetString("COMP_CODE");
                node.Name = struc.GetString("COMP_NAME");
                node.City = struc.GetString("CITY");

                IRfcStructure add = func.GetStructure("COMPANYCODE_ADDRESS");
                node.PostCode = add.GetString("POSTL_COD1");
                node.Address = add.GetString("STREET");

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node; 
        }
    }
}
