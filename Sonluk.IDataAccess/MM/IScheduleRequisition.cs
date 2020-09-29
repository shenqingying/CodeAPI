using Sonluk.Entities.MM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MM
{
    public interface IScheduleRequisition
    {
        string Create(ScheReqInfo node);

        IList<ScheReqInfo> Read(ScheReqInfo keyword);

        ScheReqInfo Read(string serialNumber);

        bool Update(ScheReqInfo node);

        bool Delete(string serialNumber);

        IList<ScheduleLineInfo> ItemRead(ScheReqInfo keyword);

        bool ItemStatus(IList<ScheduleLineInfo> nodes, int status, string comments);

        IList<ScheDelivDestInfo> DeliveryDestination();
    }
}
