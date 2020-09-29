using Sonluk.BusinessLogic.OA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.API.Models
{
    public class OAModels
    {
        private Authority _Authority;
        private Pending _Pending;
        private Flow _Flow;

        public Authority Authority
        {
            get
            {
                if (_Authority == null)
                    _Authority = new Authority();
                return _Authority;
            }
            set { _Authority = value; }
        }

        public Pending Pending
        {
            get
            {
                if (_Pending == null)
                    _Pending = new Pending();
                return _Pending;
            }
            set { _Pending = value; }
        }

        public Flow Flow
        {
            get
            {
                if (_Flow == null)
                    _Flow = new Flow();
                return _Flow;
            }
            set { _Flow = value; }
        }
    }
}