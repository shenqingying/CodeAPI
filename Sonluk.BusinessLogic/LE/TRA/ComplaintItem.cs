using Sonluk.DAFactory;
using Sonluk.Entities.LE;
using Sonluk.IDataAccess.LE.TRA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.LE.TRA
{
    public class ComplaintItem : IComplaintItem
    {
        private static readonly IComplaintItem _DetaAccess = LETRADataAccess.CreateComplaintItem();

        public int Create(ComplaintItemInfo node)
        {
            return _DetaAccess.Create(node);
        }

        public List<ComplaintItemInfo> Read(int headerID)
        {
            return _DetaAccess.Read(headerID);
        }

        public int Delete(int headerID)
        {
            return _DetaAccess.Delete(headerID);
        }
    }
}
