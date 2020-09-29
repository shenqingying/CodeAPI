using Sonluk.BusinessLogic.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.API.Models
{
    public class PublicModel
    {
        PrintService _PrintService;

        public PrintService PrintService
        {
            get
            {
                if (_PrintService == null)
                {
                    _PrintService = new PrintService();
                } return _PrintService;
            }
            set { _PrintService = value; }
        }
    }
}