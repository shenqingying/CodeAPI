using Sonluk.BusinessLogic.Master;
using Sonluk.DAFactory;
using Sonluk.Entities.LE;
using Sonluk.Entities.Master;
using Sonluk.IDataAccess.LE.TRA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sonluk.BusinessLogic.LE.TRA
{
    public class Receiver
    {
        private static readonly IReceiver _DetaAccess = LETRADataAccess.CreateReceiver();

        public bool Exists(string serialNumber)
        {
            bool existed = false;
            CompanyInfo node = Read(serialNumber);
            if (node.ID > 0)
                existed = true;
            return existed;
        }

        public IList<CompanyInfo> Read()
        {
            return _DetaAccess.Read();
        }

        public IList<CompanyInfo> Read(int city)
        {
            return _DetaAccess.Read(city);
        }

        public CompanyInfo Read(string serialNumber)
        {
            return _DetaAccess.Read(serialNumber);
        }

        public CompanyInfo Read(string serialNumber,int city)
        {
            return _DetaAccess.Read(serialNumber, city);
        }

        public IList<CompanyInfo> Select(string keyword)
        {
            return _DetaAccess.Select(keyword);
        }

        public int Create(string serialNumber)
        {
            Customer customerBL = new Customer();
            CompanyGeneralInfo raw = (customerBL.Read(serialNumber)).General[0];
            CompanyInfo node = new CompanyInfo();
            node.ShortName = raw.Name1;
            node.Name = raw.Name1;
            node.SerialNumber = serialNumber;
            node.Default = false;

            int ID = _DetaAccess.Create(node);

            Destination destBL = new Destination();
            City cityBL = new City();
            DestinationInfo dest = new DestinationInfo();

            dest.City = cityBL.Read(raw.City);
            dest.Address = raw.HouseNumberAndStreet;
            dest.Telephone = raw.FirstTelephoneNumber;
            dest.ReceiverID = ID;
            dest.Default = true;
            destBL.Create(dest);
            return ID;
        }

        public int Create(CompanyInfo node)
        {
            return _DetaAccess.Create(node);
        }

        public int Update(CompanyInfo node)
        {
            return _DetaAccess.Update(node);
        }
    }
}
