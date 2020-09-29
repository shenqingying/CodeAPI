using Sonluk.DAFactory;
using Sonluk.Entities.LE;
using Sonluk.IDataAccess.LE.TRA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.LE.TRA
{
    public class ConsignmentNoteItem
    {
        private static readonly IConsignmentNoteItem _DetaAccess = LETRADataAccess.CreateConsignmentNoteItem();

        public bool Create(CNItemInfo node)
        {
            return _DetaAccess.Create(node);
        }

        public IList<CNItemInfo> Read(int headerID)
        {
            return _DetaAccess.Read(headerID);
        }

    }
}
