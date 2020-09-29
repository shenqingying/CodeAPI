using SAP.Middleware.Connector;
using Sonluk.DataAccess.SAP.Utility;
using Sonluk.Entities.BC;
using Sonluk.IDataAccess.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.SAP.BC
{
    public class Enqueue : IEnqueue
    {
        public int Read(string name, string value)
        {
            IRfcFunction func = RFC.Function("ENQUEUE_READ");
            string client = RFC.Client();
            func.SetValue("GCLIENT", client);
            func.SetValue("GNAME", name);
            func.SetValue("GUNAME", "");
            func.SetValue("GARG", client + value);
            int number = 0;
            try
            {
                RFC.Invoke(func, false);
                number = func.GetInt("NUMBER");
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return number;
        }

        public IList<EnqueueInfo> Read(string value)
        {
            IList<EnqueueInfo> nodes = new List<EnqueueInfo>();
            IRfcFunction func = RFC.Function("ENQUEUE_READ");
            string client = RFC.Client();
            func.SetValue("GCLIENT", client);
            func.SetValue("GUNAME", "");
            func.SetValue("GARG", "%" + value + "%");

            try
            {
                RFC.Invoke(func, false);
                func.GetInt("NUMBER");
                IRfcTable table = func.GetTable("ENQ");
                for (int i = 0; i < table.RowCount; i++)
                {
                    table.CurrentIndex = i;

                    EnqueueInfo node = new EnqueueInfo();
                    node.Name = table.GetString("GNAME");
                    node.Argument = table.GetString("GARG");
                    node.Mode = LockType(table.GetString("GMODE"));
                    node.Owner = table.GetString("GUSR");
                    node.OwnerVB = table.GetString("GUSRVB");
                    node.CumulativeCounter = table.GetInt("GUSE");
                    node.CumulativeCounterVB = table.GetInt("GUSEVB");
                    node.Object = table.GetString("GOBJ");
                    node.Client = table.GetString("GCLIENT");
                    node.User = table.GetString("GUNAME");
                    node.TableArgument = table.GetString("GTARG");
                    node.TCode = table.GetString("GTCODE");
                    node.BackupType = table.GetString("GBCKTYPE");
                    node.Host = table.GetString("GTHOST");
                    node.WorkProcess = table.GetInt("GTWP");
                    node.System = table.GetInt("GTSYSNR");
                    node.Date = table.GetString("GTDATE");
                    node.Time = table.GetString("GTTIME");
                    node.Microseconds = table.GetInt("GTUSEC");
                    node.Mark = table.GetString("GTMARK");
                    node.CumulativeCounterTxt = table.GetInt("GUSETXT");
                    node.CumulativeCounterVBTxt = table.GetInt("GUSEVBT");

                    nodes.Add(node);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }

            return nodes;
        }

        public string LockType(string type)
        {
            string description = type;
            switch (type)
            {
                case "S": description = "只读锁"; break;
                case "E": description = "写入锁"; break;
                case "X": description = "排他锁"; break;
            }
            return description;

        }
    }
}
