using Sonluk.Entities.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.LE.TRA
{
    public interface IFeedbackItem
    {       
        List<FeedbackItemInfo> Read(int headerID);

        int Exists(int consignmentNote);

        int Create(FeedbackItemInfo node);

        int Update(int ID);

        int Delete(int headerID);
    }
}
