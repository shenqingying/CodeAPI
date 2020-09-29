using Sonluk.DAFactory;
using Sonluk.Entities.LE;
using Sonluk.Entities.Master;
using Sonluk.IDataAccess.LE.TRA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.LE.TRA
{
    public class Route
    {
        private static readonly IRoute _DetaAccess = LETRADataAccess.CreateRoute();

        public RouteInfo Read(int source, int destination, decimal weight, string departure)
        {
            RouteInfo node = _DetaAccess.Read(source, destination, weight);
            node.Arrival = (DateTime.Parse(departure)).AddDays(node.TimeLimit).ToString("yyyy-MM-dd");
            return node;
        }

        public string ReadDJ(int source, int destination, decimal weight)
        {
            RouteInfo node = _DetaAccess.Read(source, destination, weight);
            string rst = node.Price.ToString();
            return rst;
        }


        public string Read(int SXID, decimal weight)
        {
            string rst = _DetaAccess.Read(SXID, weight);
            return rst;
        }

        public string ReadZSF(int BZDID, int EZDID)
        {
            string rst = _DetaAccess.ReadZSF(BZDID, EZDID);
            return rst;
        }

        public RouteInfo Read(int cityID)
        {
            RouteInfo node = _DetaAccess.Read(cityID);
            Price priceBL = new Price();
            node.Prices = priceBL.Read(node.ID).ToList();

            return node;
        }

        public int Create(RouteInfo node)
        {
            if (node.SourceID == 0)
            {
                Sender senderBL = new Sender();
                CompanyInfo sender = (senderBL.Read())[0];
                node.SourceID = sender.CityID;
                node.Source = sender.City;
            }
            return _DetaAccess.Create(node);
        }

        public int Update(RouteInfo node)
        {
            int ID = _DetaAccess.Update(node);
            Price priceBL = new Price();

            if (priceBL.Delete(node.ID) > 0 && node.Prices != null)
            {
                priceBL.Create(node.Prices);
            }
            return ID;
        }

        public int Delete(int cityID)
        {
            Price priceBL = new Price();
            RouteInfo node = Read(cityID);
            priceBL.Delete(node.ID);

            return _DetaAccess.Delete(cityID);
        }
    }
}
