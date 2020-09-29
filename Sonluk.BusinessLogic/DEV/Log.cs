using Sonluk.Entities.Common;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sonluk.BusinessLogic.DEV
{
    public class Log
    {
        public void Write(string title, string content)
        {
            Logger.Write(title, content);
        }


        public IList<LogInfo> Read(int daysAgo)
        {
            IList<LogInfo> nodes = new List<LogInfo>();
            DateTime time = DateTime.Now.AddDays(-daysAgo);
            try
            {
                FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/Logs/" + time.ToString("yyyy-MM-dd") + ".log", FileMode.Open, FileAccess.Read);
                if (fs.CanRead)
                {
                    StreamReader sr = new StreamReader(fs);
                    Regex reg = new Regex(@"^[\d]{4}-[\d]{2}-[\d]{2} [\d]{2}:[\d]{2}:[\d]{2} [\d]{7}");
                    LogInfo node = new LogInfo();

                    string str = sr.ReadToEnd();
                    sr.Close();
                    fs.Close();

                    string[] aryStr = Regex.Split(str, "\r\n");
                    
                    foreach (string line in aryStr)
                    {
                        if (line.Length > 27 && reg.IsMatch(line.Substring(0, 27)))
                        {
                            if (node.Content != null)
                                nodes.Add(node);
                            node = new LogInfo();
                            node.Date = line.Substring(0, 27);
                            node.Title = line.Substring(28, line.Length - 28);
                        }
                        else
                        {
                            node.Content = node.Content + line;
                        }
                    }
                    nodes.Add(node);
                }
            }
            catch 
            { 
            }

            return nodes;

        }

    }
}
