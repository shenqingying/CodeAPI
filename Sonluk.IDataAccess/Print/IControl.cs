using Sonluk.Entities.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.Print
{
    public interface IControl
    {
        int Create(ControlInfo node);

        bool Update(ControlInfo node);

        IList<ControlInfo> Read(int parent);

        bool Delete(int ID);

    }
}
