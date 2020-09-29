using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.IDataAccess.LE.TRA;
using Sonluk.DAFactory;
using Sonluk.Entities.LE;

namespace Sonluk.BusinessLogic.LE.TRA
{
    public class Screen
    {
        private static readonly IScreen _DetaAccess = LETRADataAccess.CreateScreen();

        public ScreenInfo Read(int ID)
        {
            return _DetaAccess.Read(ID);
        }

        public int Update(ScreenInfo node)
        {
            return _DetaAccess.Update(node);
        }

        public IList<ScreenInfo> Read()
        {
            return _DetaAccess.Read();
        }
    }
}
