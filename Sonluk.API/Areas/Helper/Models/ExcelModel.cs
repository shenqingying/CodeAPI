using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.API.Areas.Helper.Models
{
    public class ExcelModel
    {
        public List<string> data { set; get; }
        public List<string> dataName { set; get; }
        public Dictionary<int, string> title { set; get; }
        public Func<string, int, int, string, string> dataTransform { set; get; }
        public char sep { set; get; }
        public char sepChild { set; get; }
        public string sheetTitle { set; get; }
        public string downloadName { set; get; }
        public ExcelModel()
        {
            this.sep = '|';
            this.sepChild = ',';
            this.sheetTitle = "sheet1";
            this.downloadName = "export.xls";
        }
    }
}