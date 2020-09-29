using Sonluk.Entities.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.LE.TRA
{
    public interface IFeedback
    {
        IList<FeedbackInfo> Read(FeedbackInfo keywords);

        FeedbackInfo Read(int ID);

        int Create(FeedbackInfo node);

        int Update(FeedbackInfo node);

        int Delete(int ID);

        IList<FeedbackInfo> Report(FeedbackInfo keywords);
    }
}
