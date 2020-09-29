using Sonluk.Entities.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.BC
{
    public interface IEnqueue
    {
        int Read(string name, string value);

        IList<EnqueueInfo> Read(string value);
    }
}
