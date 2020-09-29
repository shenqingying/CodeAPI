using Sonluk.DAFactory;
using Sonluk.Entities.LE;
using Sonluk.Entities.Master;
using Sonluk.IDataAccess.LE.TRA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sonluk.BusinessLogic.LE.TRA
{
    public class City
    {
        private static readonly ICity _DetaAccess = LETRADataAccess.CreateCity();

        public IList<CityInfo> Read()
        {
            return _DetaAccess.Read(true);
        }

        public CityInfo Read(int ID)
        {
            return _DetaAccess.Read(ID);
        }

        public CityInfo Read(string name)
        {
            Regex reg = new Regex(@"^.*[市区县]{1}$");
            if (reg.IsMatch(name))
                name = name.Substring(0, name.Length - 1);
            return _DetaAccess.Read(name);
        }

        public int Create(CityInfo node)
        {
            int ID = _DetaAccess.Create(node);
            if (ID > 0 && node.ProvinceID > 0)
            {
                Route routeBL = new Route();
                RouteInfo route = new RouteInfo();
                route.Destination = node.Name;
                route.DestinationID = ID;
                routeBL.Create(route);
            }
            return ID;
        }

        public int Update(CityInfo node)
        {
            return _DetaAccess.Update(node);
        }

        public int Modify(CityInfo node)
        {
            int ID = 0;
            if (node.ID > 0)
                ID = Update(node);
            else
                ID = Create(node);
            return ID;
        }

        public int Delete(int ID)
        {
            Route routeBL = new Route();
            routeBL.Delete(ID);
            return _DetaAccess.Delete(ID);
        }

        public int DeleteProvince(int ID)
        {
            return _DetaAccess.DeleteProvince(ID);
        }

        public int Delete(int ID, bool province)
        {
            int success = 0;
            if (province)
                success = DeleteProvince(ID);
            else
                success = Delete(ID);
            return success;
        }
    }
}
