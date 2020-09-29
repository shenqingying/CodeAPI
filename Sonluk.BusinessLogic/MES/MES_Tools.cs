using Sonluk.Utility.Remote;
using System.Text.RegularExpressions;

namespace Sonluk.BusinessLogic.MES
{
    public class MES_Tools
    {
        public string GetHtmlTag(string input, string tag, string type)
        {
            string html = "";
            switch (type)
            {
                case "url":
                    if (Regex.IsMatch(input, @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$")) html = HttpHelper.HttpGet(input);
                    break;
                default:
                    html = input;
                    break;
            }
            string keyWordS = "<" + tag;
            string keyWordE = "/" + tag + ">";
            string rst = "";
            int index = 0;
            while ((index = html.IndexOf(keyWordS, index)) != -1)
            {
                int eindex = html.IndexOf(keyWordE, index);
                if (eindex == -1) break;
                rst = html.Substring(index, eindex - index + keyWordE.Length);
                index += keyWordS.Length;
            }
            return rst;
        }
    }
}
