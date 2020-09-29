using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sonluk.BusinessLogic.QM;


namespace Sonluk.API.Models
{
    public class QMModels
    {
        private QualityNotification _QualityNotification;
        private Ingredient _Ingredient;

        public QualityNotification QualityNotification
        {
            get
            {
                if (_QualityNotification == null)
                    _QualityNotification = new QualityNotification();
                return _QualityNotification;
            }
            set { _QualityNotification = value; }
        }

        public Ingredient Ingredient
        {
            get
            {
                if (_Ingredient == null)
                    _Ingredient = new Ingredient();
                return _Ingredient;
            }
            set { _Ingredient = value; }
        }
        private ZSL_QMFG_RFC _ZSL_QMFG_RFC;

        public ZSL_QMFG_RFC ZSL_QMFG_RFC
        {
            get
            {
                if (_ZSL_QMFG_RFC == null)
                    _ZSL_QMFG_RFC = new ZSL_QMFG_RFC();
                return _ZSL_QMFG_RFC;
            }
            set { _ZSL_QMFG_RFC = value; }
        }
    }
}