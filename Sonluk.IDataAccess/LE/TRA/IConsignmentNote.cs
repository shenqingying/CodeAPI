using Sonluk.Entities.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.LE.TRA
{
    public interface IConsignmentNote
    {
        IList<CNInfo> Read(CNInfo keywords);

        IList<CNDeliveryInfo> ReadCNDeliveryByID(int ID);

        IList<CNDeliveryInfo> ReadCNDelivery(string vbeln);

        CNInfo Read(int ID);

        IList<CNInfo> Report(CNInfo keywords);

        int Exists(int ID);

        int Exists(string serialNumber, int status);

        int Record(string serialNumber, int ID);

        bool JHDUPDATE(string serialNumber, int TYDID, int STATUS, string FILLNAME, string FILLID);

        string CurrentNumber(int carrierID);

        int Create(CNInfo node);

        bool Update(CNInfo node);

        int Delete(int ID);
    }
}
