using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Sonluk.BusinessLogic.Helper
{
    public class XMLHelper
    {
        /// <summary>
        /// 将数据赋到OA流程中（返回xml字符串）
        /// </summary>
        /// <param name="Flow">流程</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public string CreateOAFlowByFlow(string flow, Dictionary<string, object> data)
        {
            StringReader sr = new StringReader(flow);
            XDocument oriXml = XDocument.Load(sr);
            XDocument myXml = new XDocument(oriXml.Element("DataPojo").Elements("DataProperty").First(a => a.Attribute("propertyname").Value == "flowContent_form").Element("formExport"));
            foreach (var item in data)
            {
                if (item.Value is string)
                {
                    myXml.Element("formExport").Element("values").Elements("column").First(a => a.Attribute("name").Value == item.Key).Element("value").SetValue(item.Value);
                }
                else if (item.Value is Dictionary<string, object>)
                {
                    foreach (var itemson in (Dictionary<string, object>)item.Value)
                    {
                        if (itemson.Value is string) myXml.Element("formExport").Element("subForms").Element("subForm").Element("values").Elements("column").First(a => a.Attribute("name").Value == itemson.Key).Element("value").SetValue(itemson.Value);
                    }

                }
                else if (item.Value is List<Dictionary<string, object>>)
                {
                    foreach (var itemson in myXml.Element("formExport").Element("subForms").Elements("subForm"))
                    {
                        var list = (List<Dictionary<string, object>>)item.Value;
                        bool valid = true;
                        foreach (var itemsonson in list[0])
                        {
                            bool exists = false;
                            foreach (var attr in itemson.Element("values").Element("row").Elements("column").Attributes())
                            {
                                if (attr.Value == itemsonson.Key)
                                {
                                    exists = true;
                                    break;
                                }
                            }
                            if (!exists)
                            {
                                valid = false;
                                break;
                            }
                        }
                        if (valid)
                        {
                            XElement template = itemson.Element("values").Element("row");
                            itemson.Element("values").Element("row").Remove();
                            for (int i = 0; i < list.Count; i++)
                            {
                                XElement newRow = new XElement(template);
                                foreach (var itemsonson in list[i])
                                {
                                    newRow.Elements("column").First(a => a.Attribute("name").Value == itemsonson.Key).Element("value").SetValue(itemsonson.Value);
                                }
                                itemson.Element("values").Add(newRow);
                            }
                            break;
                        }
                    }
                }
            }
            StringWriter sw = new StringWriter();
            myXml.Save(sw);
            return sw.ToString();
        }

        /// <summary>
        /// 根据表名创建OA流程（返回xml字符串）
        /// </summary>
        /// <param name="formmain">表名</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public string CreateOAFlowByFormmain(string formmain, Dictionary<string, object> data)
        {
            XElement newXml = new XElement("formExport", new XAttribute("version", "2.0"),
                    new XElement("summary", new XAttribute("id", ""), new XAttribute("name", formmain)),
                    new XElement("definitions"),
                    new XElement("values"),
                    new XElement("subForms"));
            int subCount = 0;
            foreach (var item in data)
            {
                if (item.Value is string)
                {
                    newXml.Element("values").Add(new XElement("column", new XAttribute("name", item.Key), new XElement("value", new XCData((string)item.Value))));
                }
                else if (item.Value is Dictionary<string, object>)
                {
                    newXml.Element("subForms").Add(new XElement("subForm", new XElement("values")));
                    foreach (var itemson in ((Dictionary<string, object>)item.Value))
                    {
                        newXml.Element("subForms").Elements("subForm").ElementAt(subCount).Element("values").Add(new XElement("column", new XAttribute("name", itemson.Key), new XElement("value", new XCData((string)itemson.Value))));
                    }
                    subCount++;
                }
                else if (item.Value is List<Dictionary<string, object>>)
                {
                    newXml.Element("subForms").Add(new XElement("subForm", new XElement("values")));
                    for (int i = 0; i < ((List<Dictionary<string, object>>)item.Value).Count; i++)
                    {
                        XElement newRow = new XElement("row");
                        foreach (var itemson in ((List<Dictionary<string, object>>)item.Value)[i])
                        {
                            newRow.Add(new XElement("column", new XAttribute("name", itemson.Key), new XElement("value", new XCData(itemson.Value.ToString()))));
                        }
                        newXml.Element("subForms").Elements("subForm").ElementAt(subCount).Element("values").Add(newRow);
                    }
                    subCount++;
                }
            }
            StringWriter sw = new StringWriter();
            newXml.Save(sw);
            return sw.ToString();
        }

        /// <summary>
        /// 根据模板创建OA流程（返回xml字符串）
        /// </summary>
        /// <param name="template">模板</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public string CreateOAFlowByTemplate(string template, Dictionary<string, object> data)
        {
            StringReader sr = new StringReader(template);
            string formmain = XDocument.Load(sr)
                .Element("DataPojo")
                .Elements("DataProperty").First(a => a.Attribute("propertyname").Value == "flowContent_form")
                .Elements("DataPojo").First(a => a.Attribute("type").Value == "FormExport")
                .Elements("DataProperty").First(a => a.Attribute("propertyname").Value == "formName").Value;
            return CreateOAFlowByFormmain(formmain, data);
        }
    }
}
