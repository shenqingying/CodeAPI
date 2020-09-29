using Sonluk.BusinessLogic.SSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.API.Models
{
    public class SSOModels
    {
        private User _User;
        private Authorization _Authorization;

        public User User
        {
            get
            {
                if (_User == null)
                    _User = new User();
                return _User;
            }
            set { _User = value; }
        }

        public Authorization Authorization
        {
            get
            {
                if (_Authorization == null)
                    _Authorization = new Authorization();
                return _Authorization;
            }
            set { _Authorization = value; }
        }
        private TOKEN_TOKENIDINFO _TOKEN_TOKENIDINFO;

        public TOKEN_TOKENIDINFO TOKEN_TOKENIDINFO
        {
            get
            {
                if (_TOKEN_TOKENIDINFO == null)
                    _TOKEN_TOKENIDINFO = new TOKEN_TOKENIDINFO();
                return _TOKEN_TOKENIDINFO;
            }
            set { _TOKEN_TOKENIDINFO = value; }
        }
    }
}