using Sonluk.DAFactory;
using Sonluk.Entities.LE;
using Sonluk.IDataAccess.LE.TRA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.LE.TRA
{
    public class FeedbackItem
    {
        private static readonly IFeedbackItem _DetaAccess = LETRADataAccess.CreateFeedbackItem();

        public List<FeedbackItemInfo> Read(int headerID)
        {
            return _DetaAccess.Read(headerID);
        }

        public int Exists(int consignmentNote)
        {
            return _DetaAccess.Exists(consignmentNote);
        }

        public int Create(FeedbackItemInfo node)
        {
            return _DetaAccess.Create(node);
        }

        public int Update(int ID)
        {
            return _DetaAccess.Update(ID);
        }

        public int Delete(int headerID)
        {
            return _DetaAccess.Delete(headerID);
        }
    }
}
