using Sonluk.BusinessLogic.Helper;

namespace Sonluk.API.Models
{
    public class HelperModels
    {
        private ExcelHelper _ExcelHelper;
        private XMLHelper _XMLHelper;
        private Insights _Insights;

        public ExcelHelper ExcelHelper
        {
            get
            {
                if (_ExcelHelper == null)
                    _ExcelHelper = new ExcelHelper();
                return _ExcelHelper;
            }
            set { _ExcelHelper = value; }
        }
        public XMLHelper XMLHelper
        {
            get
            {
                if (_XMLHelper == null)
                    _XMLHelper = new XMLHelper();
                return _XMLHelper;
            }
            set { _XMLHelper = value; }
        }
        public Insights Insights
        {
            get
            {
                if (_Insights == null)
                    _Insights = new Insights();
                return _Insights;
            }
            set { _Insights = value; }
        }
    }
}