using Sonluk.DataAccess.Utility.Oracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.DataAccess.OA.Utility
{
    public sealed class Connection
    {
        public static readonly string connectionString = ConnectionStringBuilder.Build("OA", "OA.DB.User", "OA.DB.Password", "sMrqqC}+");
    }
}
