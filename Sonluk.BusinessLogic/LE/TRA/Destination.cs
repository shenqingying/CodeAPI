using Sonluk.DAFactory;
using Sonluk.Entities.LE;
using Sonluk.IDataAccess.LE.TRA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.LE.TRA
{
    public class Destination
    {
        private static readonly IDestination _DetaAccess = LETRADataAccess.CreateDestination();

        public IList<DestinationInfo> Read(int parentID)
        {
            return _DetaAccess.Read(parentID);
        }

        public DestinationInfo ReadSingle(int ID)
        {
            return _DetaAccess.ReadSingle(ID);
        }

        public int Create(DestinationInfo node)
        {
            return _DetaAccess.Create(node);
        }

        public int Update(DestinationInfo node)
        {
            return _DetaAccess.Update(node);
        }

        public int Modify(DestinationInfo node)
        {
            int ID=0;
            if(node.ID>0)
                ID = Update(node);
            else
                ID = Create(node);
            return ID;
        }

        public int Delete(int ID)
        {
            return _DetaAccess.Delete(ID);
        }
    }
}
