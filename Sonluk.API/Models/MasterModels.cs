using Sonluk.BusinessLogic.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.API.Models
{
    public class MasterModels
    {
        private Material _Material;
        private Customer _Customer;
        private Vendor _Vendor;

        public Material Material
        {
            get
            {
                if (_Material == null)
                    _Material = new Material();
                return _Material;
            }
            set { _Material = value; }
        }
        public Customer Customer
        {
            get
            {
                if (_Customer == null)
                    _Customer = new Customer();
                return _Customer;
            }
            set { _Customer = value; }
        }
        public Vendor Vendor
        {
            get
            {
                if (_Vendor == null)
                    _Vendor = new Vendor();
                return _Vendor;
            }
            set { _Vendor = value; }
        }
    }
}