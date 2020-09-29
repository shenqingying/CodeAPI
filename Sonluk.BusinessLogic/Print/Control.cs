using Sonluk.DAFactory;
using Sonluk.Entities.Print;
using Sonluk.IDataAccess.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.Print
{

    public class Control
    {
        private static readonly IControl detaAccess = PrintDataAccess.CreateControl();

        public int Create(ControlInfo node)
        {
            return detaAccess.Create(node);
        }

        public bool Update(ControlInfo node)
        {
            return detaAccess.Update(node);
        }

        public IList<ControlInfo> Read(int ID)
        {
            return detaAccess.Read(ID);
        }

        public bool Delete(int ID)
        {
            return detaAccess.Delete(ID);
        }
    }
}
