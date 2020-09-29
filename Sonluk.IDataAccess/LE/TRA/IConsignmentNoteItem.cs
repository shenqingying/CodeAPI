using Sonluk.Entities.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.LE.TRA
{
    public interface IConsignmentNoteItem
    {
        bool Create(CNItemInfo node);

        IList<CNItemInfo> Read(int headerID);

        bool Delete(int ID);
    }
}
