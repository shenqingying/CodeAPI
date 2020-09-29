using Sonluk.DAFactory;
using Sonluk.Entities.BC;
using Sonluk.IDataAccess.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.BC
{
    public class User
    {
        private static readonly IUser detaAccess = BCDataAccess.CreateUser();

        public UserInfo Read(string signInName)
        {
            return detaAccess.Read(signInName);
        }
    }
}
