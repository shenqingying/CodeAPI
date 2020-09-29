using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Entities.LE;

namespace Sonluk.IDataAccess.LE
{
    public interface IOutboundDelivery
    {

        IList<DeliveryInfo> Read(DeliveryInfo keywords);

        DeliveryInfo Read(string serialNumber, string status);

        IList<DeliveryItemInfo> ItemRead(string serialNumber);

        DeliveryInfo ReadSales(string number);

        int Update(string serialNumber, int consignmentNote,int status);


    }
}
