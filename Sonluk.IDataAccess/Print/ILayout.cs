using Sonluk.Entities.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.Print
{
    public interface ILayout
    {
        int Create(LayoutInfo node);

        bool Update(LayoutInfo node);

        IList<LayoutInfo> Read();

        LayoutInfo Read(int ID);

        LayoutInfo Read(string Doc,string Mac);

        bool Delete(int ID);
    }
}
