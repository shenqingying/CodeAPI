using Sonluk.DAFactory;
using Sonluk.Entities.BC;
using Sonluk.IDataAccess.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sonluk.BusinessLogic.BC
{
    public class Enqueue
    {
        private static readonly IEnqueue detaAccess = BCDataAccess.CreateEnqueue();

        public int Read(string name, string value)
        {
            return detaAccess.Read(name, value);
        }

        public IList<EnqueueInfo> Read(string value)
        {
            return detaAccess.Read(value);
        }

        public bool Wait(string name, string value)
        {
            bool enqueue = true;
            for (int i = 0; i <= 20; i++)
            {
                Thread.Sleep(i * 30);
                if (Read(name, value) == 0)
                {
                    enqueue = false;
                    break;
                }
            }

            return !enqueue;       
        }
    }
}
