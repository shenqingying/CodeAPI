using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.Master;
using Sonluk.Entities.SD;
using Sonluk.IDataAccess.FI;
using Sonluk.IDataAccess.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.Master
{
    public class Customer : ICustomer
    {
        public CompanyInfo Read(string serialNumber)
        {
            IRfcFunction func = RFC.Function("ZSL_CRM002");
            func.SetValue("I_KUNNR", serialNumber);

            CompanyInfo node = new CompanyInfo();
            node.General = new List<CompanyGeneralInfo>();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("O_KNA1");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    CompanyGeneralInfo child = new CompanyGeneralInfo();
                    child.Client = table.GetString("MANDT");
                    child.Number = table.GetInt("KUNNR").ToString();
                    child.CountryKey = table.GetString("LAND1");
                    child.Name1 = table.GetString("NAME1");
                    child.Name2 = table.GetString("NAME2");
                    child.City = table.GetString("ORT01");
                    child.PostalCode = table.GetString("PSTLZ");
                    child.Region = table.GetString("REGIO");
                    child.SortField = table.GetString("SORTL");
                    child.HouseNumberAndStreet = table.GetString("STRAS");
                    child.FirstTelephoneNumber = table.GetString("TELF1");
                    child.FaxNumber = table.GetString("TELFX");
                    child.Address = table.GetString("ADRNR");
                    node.General.Add(child);
                }

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }

        public CompanyInfo Read(string date, string time)
        {
            IRfcFunction func = RFC.Function("ZSL_ZCRM002");
            func.SetValue("I_UDATE", date);
            func.SetValue("I_UTIME", time);

            CompanyInfo node = new CompanyInfo();
            node.General = new List<CompanyGeneralInfo>();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("O_KNA1");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    CompanyGeneralInfo child = new CompanyGeneralInfo();
                    child.Number = table.GetInt("KUNNR").ToString();
                    child.Name = table.GetString("NAME1");
                    child.SalesOrganization = table.GetString("VKORG");
                    child.SalesOrganizationDescription = table.GetString("VTEXT");
                    child.DistributionChannel = table.GetString("VTWEG");
                    child.DistributionChannelDescription = table.GetString("VTEXT1");
                    child.Division = table.GetString("SPART");
                    child.DivisionDescription = table.GetString("VTEXT2");
                    child.SalesGroup = table.GetString("VKGRP");
                    child.SalesGroupDescription = table.GetString("BEZEI");
                    child.Telephone = table.GetString("TELF1");
                    node.General.Add(child);
                }

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }

        public CompanyInfo Read3(string date, string time)
        {
            IRfcFunction func = RFC.Function("ZSL_ZCRM003");
            func.SetValue("I_UDATE", date);
            func.SetValue("I_UTIME", time);

            CompanyInfo node = new CompanyInfo();
            node.General = new List<CompanyGeneralInfo>();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("O_KNA1");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    CompanyGeneralInfo child = new CompanyGeneralInfo();
                    child.Number = table.GetInt("KUNNR").ToString();
                    child.Name = table.GetString("NAME1");
                    child.SalesOrganization = table.GetString("VKORG");
                    child.SalesOrganizationDescription = table.GetString("VTEXT");
                    child.DistributionChannel = table.GetString("VTWEG");
                    child.DistributionChannelDescription = table.GetString("VTEXT1");
                    child.Division = table.GetString("SPART");
                    child.DivisionDescription = table.GetString("VTEXT2");
                    child.SalesGroup = table.GetString("VKGRP");
                    child.SalesGroupDescription = table.GetString("BEZEI");
                    child.Telephone = table.GetString("TELF1");
                    node.General.Add(child);
                }

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }

        public IList<CompanyInfo> ShipToParty(string serialNumber, string salesOrganization, string distributionChannel, string division)
        {
            IRfcFunction func = RFC.Function("ZRFC_GET_ADRE");

            func.SetValue("I_KUNNR", serialNumber);
            func.SetValue("I_VKORG", salesOrganization);
            func.SetValue("I_VTWEG", distributionChannel);
            func.SetValue("I_SPART", division);

            IList<CompanyInfo> nodes = new List<CompanyInfo>();
            try
            {
                RFC.Invoke(func, false);
                string salesOffices = func.GetString("O_REGI");
                IRfcTable table = func.GetTable("O_KNVP");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    CompanyInfo node = new CompanyInfo();
                    node.SerialNumber = table.GetString("KUNN2");
                    node.Address = table.GetString("KNREF");
                    node.SalesOffices = salesOffices;

                    nodes.Add(node);
                }

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;

        }

        public IList<SDInfo> SalesRange(string serialNumber)
        {
            IRfcFunction func = RFC.Function("ZRFC_GET_CUSTDATA");
            func.SetValue("I_KUNNR", serialNumber);


            IList<SDInfo> nodes = new List<SDInfo>();
            try
            {
                RFC.Invoke(func, false);
                IRfcTable table = func.GetTable("O_KNVV");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;
                    SDInfo node = new SDInfo();
                    node.SalesOrganization = table.GetString("VKORG");
                    node.SalesOrganizationDescription = table.GetString("VTEXT");
                    node.DistributionChannel = table.GetString("VTWEG");
                    node.DistributionChannelDescription = table.GetString("VTWDE");
                    node.Division = table.GetString("SPART");
                    node.DivisionDescription = table.GetString("SPADE");
                    nodes.Add(node);
                }

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public DiscountInfo Discount(string serialNumber)
        {
            IRfcFunction func = RFC.Function("ZRFC_GET_ZK");
            func.SetValue("I_KUNNR", serialNumber);

            DiscountInfo node = new DiscountInfo();
            try
            {
                RFC.Invoke(func, false);
                node.Available = func.GetDecimal("O_KOMXWRT");
                node.Rate = func.GetDecimal("O_KBETR");

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return node;
        }
    }
}
