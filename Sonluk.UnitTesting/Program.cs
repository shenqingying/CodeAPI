using iTextSharp.text;
using iTextSharp.text.pdf;
using SAP.Middleware.Connector;
using Sonluk.BusinessLogic.Account;
using Sonluk.BusinessLogic.BC;
using Sonluk.BusinessLogic.DEV;
using Sonluk.BusinessLogic.FI;
using Sonluk.BusinessLogic.LE;
using Sonluk.BusinessLogic.LE.TRA;
using Sonluk.BusinessLogic.Master;
using Sonluk.BusinessLogic.MM;
using Sonluk.BusinessLogic.OA;
using Sonluk.BusinessLogic.Print;
using Sonluk.BusinessLogic.QM;
using Sonluk.BusinessLogic.RMS;
using Sonluk.BusinessLogic.SD;
using Sonluk.BusinessLogic.SSO;
using Sonluk.DataAccess.OA.Utility;
using Sonluk.DataAccess.Utility.Oracle;
using Sonluk.DataAccess.Utility.SAP;
using Sonluk.Entities.BC;
using Sonluk.Entities.Common;
using Sonluk.Entities.LE;
using Sonluk.Entities.Master;
using Sonluk.Entities.MM;
using Sonluk.Entities.OA;
using Sonluk.Entities.Print;
using Sonluk.Entities.QM;
using Sonluk.Entities.RMS;
using Sonluk.Entities.SD;
using Sonluk.Entities.System;
using Sonluk.UnitTesting.OADocumentAPI;
//using Sonluk.UnitTesting.OAAuthority;
//using Sonluk.UnitTesting.OATest;
using Sonluk.Utility;
using Sonluk.Utility.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Xml;
using System.Xml.Serialization;

namespace Sonluk.UnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Route routeBL = new Route();
            //RouteInfo node = routeBL.Read(2);
            //int ID = routeBL.Update(node);
            //Console.WriteLine(ID.ToString());
            //Console.ReadLine();


            PurchaseOrder po = new PurchaseOrder();
            //POKeywordInfo key = new POKeywordInfo();
            //key.Number = "4000047063";
            //IList<POItemInfo> nodes = po.Read(key);
            //Console.ReadLine();

            //Sonluk.UI.Model.MM.PurchaseOrder po = new UI.Model.MM.PurchaseOrder();
            //241600000051
             //po.GetRKBSPrint("400004709200020", "", "8003", 1, 0, 0);
            //Sonluk.UI.Model.MM.PurchaseOrderService.PurchaseOrderSoapClient client = new Sonluk.UI.Model.MM.PurchaseOrderService.PurchaseOrderSoapClient("PurchaseOrderSoap", AppConfig.Settings("RemoteAddress") + "MM/PurchaseOrder.asmx");
            //IList<Sonluk.UI.Model.MM.PurchaseOrderService.FileStreamInfo> files = client.GetRKBSPrint("400004709200020", "", "8003", 1, 0, 0);
            //int filesLength = files.Count();

            //for (int i = 0; i < filesLength; i++)
            //{
            //    MemoryStream memoryStream = new MemoryStream(files[i].Bytes);
            //    string fileName = files[i].Name + "_" + files[i].TattedCode + "." + files[i].Extension;
            //    string path = "G:/Temp/PO/" + fileName;
            //    try
            //    {
            //        FileStream file = new FileStream(path, FileMode.Create);
            //        file.Write(memoryStream.ToArray(), 0, (memoryStream.ToArray()).GetLength(0));
            //        file.Close();
            //    }
            //    catch (System.Exception e)
            //    {
            //        Logger.Write("UI.Model.MM.PurchaseOrder.GetRKBSPrint", e.ToString());
            //    }
            //    files[i].Bytes = null;
            //}

            //IList<FileStreamInfo> fs = po.GetStorageIdentificationPDF("400004743500010","","8003",0,0,0,"Q","");
            po.GetStorageIdentificationList("400004743500010", "", "8003", 0, 0, 0, "Q", "");
            //Sonluk.BusinessLogic.BC.BarCode bc = new BusinessLogic.BC.BarCode();
            //bc.SFLTBS("1000002503");
            Console.ReadLine();

            //ConsignmentNote cm = new ConsignmentNote();
            //CNInfo cn = new CNInfo();
            //CompanyInfo cmi = new CompanyInfo();

            //cmi.ID = 9;
            //cn.Carrier = cmi;
            //cn.Destination = new CityInfo();
            //cn.Receiver = new CompanyInfo();
            //cn.Date = "2013-01-25";
            //cn.DateEnd = "2013-01-25";
            //cn.Status = 3;
            //IList<CNInfo> nodes = cm.Read(cn);
            //Console.ReadLine();

            //Sonluk.UI.Model.LE.TRA.ConsignmentNote cm = new UI.Model.LE.TRA.ConsignmentNote();
            //UI.Model.LE.TRA.ConsignmentNoteService.CNInfo cn = new UI.Model.LE.TRA.ConsignmentNoteService.CNInfo();
            //UI.Model.LE.TRA.ConsignmentNoteService.CompanyInfo cmi = new UI.Model.LE.TRA.ConsignmentNoteService.CompanyInfo();

            //cmi.ID = 9;
            //cn.Carrier = cmi;
            //cn.Destination = new UI.Model.LE.TRA.ConsignmentNoteService.CityInfo();
            //cn.Receiver = new UI.Model.LE.TRA.ConsignmentNoteService.CompanyInfo();
            //cn.Date = "2013-01-25";
            //cn.DateEnd = "2013-01-25";
            //cn.Status = 3;
            //IList<UI.Model.LE.TRA.ConsignmentNoteService.CNInfo> nodes = cm.Read(cn);
            //Console.ReadLine();

            //Sonluk.UI.Model.BC.User cuser = new UI.Model.BC.User();
            //UI.Model.BC.UserService.UserInfo objuser = cuser.Read("DML");
            //Console.ReadLine();

            //Sonluk.BusinessLogic.LE.TRA.ConsignmentNote objnote = new BusinessLogic.LE.TRA.ConsignmentNote();
            //IList<Sonluk.Entities.LE.CNDeliveryInfo> nodes = objnote.CNDeliveryUPDATE("81001022",0,1,"xsw","");
            //Console.ReadLine();


            //documentServicePortTypeClient _Client = new documentServicePortTypeClient("documentServiceHttpSoap11Endpoint");
            //Authority auth = new Authority();
            //auth.Authenticate();
            //string xml = _Client.exportFlow2(auth.Authenticate(), 7192707883170831303);
            //Console.WriteLine(xml);
            //BPM bpm = new BPM();
            //string[] result = bpm.Template("11");
            //Console.Write(result.ToString());
            //Console.ReadLine();
            //Regex reg = new Regex(@"^8[0-9]{7}$");
            //Console.WriteLine(reg.IsMatch("81324123333"));
            //Console.WriteLine(reg.IsMatch("81324123"));
            //Console.ReadLine();
                                   
            //IList<int> numbers = {1,2,3,4,5,6,7 };

            //numbers.m

            //IList<string> serialNumberSet = new List<string>();
            //serialNumberSet.Add("81229753");
            //serialNumberSet.Add("84006525");
            //serialNumberSet.Add("81229753");
            //serialNumberSet.Add("84006525");
            //serialNumberSet.Add("81229752");
            //HashSet<string> serialNumberHashSet = new HashSet<string>(serialNumberSet);
            //foreach (string serialNumber in serialNumberHashSet)
            //{
            //    Console.WriteLine(serialNumber);
                
            //}
            //Console.ReadLine();
            //FeedbackInfo node = new FeedbackInfo();
            //FeedbackItemInfo item = new FeedbackItemInfo();
            //item.ConsignmentNote = 20428;
            //node.Items = new List<FeedbackItemInfo>();
            //node.Items.Add(item);
            //Feedback fbBL = new Feedback();
            //Console.WriteLine(fbBL.Verify(node));
            //Console.ReadLine();
            //string city = "杭州市";
            //Regex reg = new Regex(@"^.*[市区县]{1}$");
            //if (reg.IsMatch("杭州市"))
            //    city = city.Substring(0, city.Length-1);
            //Console.WriteLine(city);
            //Console.WriteLine(reg.IsMatch("杭州市"));
            //Console.WriteLine(reg.IsMatch("杭市市"));
            //Console.WriteLine(reg.IsMatch("杭市州"));
            //Message messageBL = new Message();
            //Console.WriteLine(messageBL.Send("[SAP][OA]触发流程异常："));
            
            //Console.ReadLine();
            //ConsignmentNote cnBL = new ConsignmentNote();
            //CNInfo key = new CNInfo();
            //key.Date = "2016-02-01";
            //key.DateEnd = "2016-02-29";
            //key.Receiver = new CompanyInfo();
            //key.Carrier = new CompanyInfo();
            //key.Destination = new CityInfo();
            //cnBL.Read(key);
            //cnBL.Read(20413);
            //ConsignmentNote cnBL = new ConsignmentNote();
            //List<string> cns = new List<string>();
            //cns.Add("81229691");
            //cnBL.Generate(cns,1,false);

            //Console.ReadLine();
            //decimal max = Convert.ToDecimal(Console.ReadLine());

            //DateTime startTime = DateTime.Now;
            //decimal sum = 0;
            //for (decimal i = 1; i < max; i++)
            //{
            //    sum = sum + 1 / i;
            //}
            //DateTime endTime = DateTime.Now;
            //Console.WriteLine(sum);
            //Console.WriteLine(max);
            //Console.WriteLine(endTime - startTime);

            //string raw = "GG99A";
            //Console.WriteLine(raw);
            //int count = raw.Length;
            //string code = "";
            //string tempString = "";
            //int temp = 0;
            //bool finish = false;
            //bool carry = false;
            //Regex reg = new Regex(@"^[0-9]*$");
            //for (int i = count - 1; i >= 0; i--)
            //{
            //    if (finish)
            //        break;
            //    tempString = raw.Substring(i, 1);
            //    raw = raw.Substring(0, i);
            //    if (Int32.TryParse(tempString, out temp))
            //    {
            //        if (temp == 9)
            //        {
            //            temp = 0;
            //            carry = true;
            //        }
            //        else
            //        {
            //            temp++;
            //            finish = true;
            //        }
            //        tempString = temp.ToString();
            //    }
            //    else
            //    {
            //        if (carry)
            //            finish = true;
            //    }
            //    code = tempString + code;  
            //}
            //code = raw + code;
            //Console.WriteLine(code);

            //string x = @"/Sonluk/MM/PurchaseOrder/Index?Auth=ZUB";
            //x = Regex.Replace(x, @"[^a-zA-Z0-9]*", "");
            //Console.WriteLine(x);
            //decimal a = 0.000m;
            //decimal b = 0.000m;
            //Console.WriteLine(a*b);
            //Table tableBL = new Table();
            //string name = tableBL.Read("EKKO");
            //Console.WriteLine(name);
            //Receiver receiverBL = new Receiver();
            //IList<CompanyInfo> nodes = receiverBL.Select("江东区");
            //Console.WriteLine(nodes.Count);

            //Flow flow = new Flow();
            //flow.Push();
            //Console.Read();
            //string filePath = "托运单反馈2.xlsx";

            //FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            //int length = (int)fs.Length;
            //byte[] data = new byte[length];
            //fs.Position = 0;
            //fs.Read(data, 0, length);
            //MemoryStream ms = new MemoryStream(data);

            //Feedback fBL = new Feedback();
            //IList<FeedbackItemInfo> nodes = fBL.Import(ms);

            //Console.WriteLine("s");
            //Console.WriteLine(nodes.Count);
            //Console.ReadLine();


            //20413
            //decimal number = 0.111000m;
            //decimal number1 = 1.111m;
            //Console.WriteLine(number);
            //Console.WriteLine(number.ToString().TrimEnd('0'));
            //Console.WriteLine(number.ToString("0.#####"));
            //Console.WriteLine(number.ToString("0.0"));
            //Console.WriteLine(number1.ToString("0.#"));
            //number1.
            //Console.ReadLine();


            //Feedback cBL = new Feedback();
            //FeedbackInfo key = new FeedbackInfo();
            //key.Carrier = new CompanyInfo();
            //key.Carrier.ID = 3;
            //IList<FeedbackInfo> nodes = cBL.Report(key);
            //Console.ReadLine();
            //Flow flow = new Flow();
            ////flow.Launch();
            //flow.Sync();
            //Feedback cBL = new Feedback();
            //FeedbackInfo key = new FeedbackInfo();
            //key.Carrier = new CompanyInfo();
            //key.Carrier.ID = 3;
            //IList<FeedbackInfo> nodes = cBL.Read(key);
            //Access accessBL = new Access();
            //AccountInfo account = accessBL.SignIn("1000035","123");

            //Pending pdBL = new Pending();
            //int count = pdBL.Count("V1000035");
            //Console.WriteLine(count);
            //Console.ReadLine();
            //ConsignmentNote cnBL = new ConsignmentNote();
            //List<string> sns = new List<string>();
            //sns.Add("81260192");
            //sns.Add("81229710");
            //sns.Add("81229711");
            //sns.Add("81229713");
            //sns.Add("82022528");
            //CNInfo node = cnBL.Generate(sns, 1, false);
            //Console.Write(node.DeliveryCount);
            //Console.ReadLine();
            //decimal a = 200m;
            //decimal b = 120m;
            //Console.WriteLine(a \ b);
            //Console.WriteLine(Convert.ToInt32(a/b));
            //OutboundDelivery odbl = new OutboundDelivery();
            //odbl.ItemRead("81229710");
            //ConsignmentNote cnbl = new ConsignmentNote();
            //CNInfo node = new CNInfo();
            //node.SerialNumber = "20151222";
            //node.Number = "20151223";
            //node.Carrier = new CompanyInfo();
            //node.Carrier.ID = 1;
            //node.Carrier.ShortName = "UPS";
            //node.Carrier.Name = "UPS";
            //node.Date = "2015-12-22";
            //node.Source = new CityInfo();
            //node.Source.Name = "";
            //cnbl.Create(node);
            //cnbl.Read(node);
            //Layout layout = new Layout();
            //layout.Read();
            //DateTime arrival = DateTime.Parse("2015-12-18");
            //Console.WriteLine(arrival.ToString("yyyy-MM-dd"));
            //arrival.AddDays(-2);
            //Console.WriteLine(arrival.ToString("yyyy-MM-dd"));
            //Access accessbl = new Access();
            //AccountInfo account = accessbl.SignIn("DEP-SZ","666666");
            //Console.WriteLine(account.SignIn);
            //Console.WriteLine("DEP-SZ".Trim());
            ////City citybl = new City();
            //citybl.Read();
            //Pending pBL = new Pending();
            //IList<PendingInfo> nodes = pBL.Read("V1000061", 0, 10, "101.101.101.101");
            //Console.WriteLine(nodes.Count);
            //Product probl = new Product();
            //probl.History("KBMH121212", "LR03");
            //Carrier cbl = new Carrier();
            //cbl.Read();
            //decimal price = 85000m / 117;
            //Console.WriteLine(price + ";" + price.ToString("###,###,###,##0.00"));
            //decimal tax = price * (170m/1000);
            //Console.WriteLine(tax+ ";" + tax.ToString("###,###,###,##0.00"));
            //decimal totlePrice = tax + price;
            //Console.WriteLine(totlePrice + ";" + (price * 1.17m));
            //PurchaseOrder pobl = new PurchaseOrder();
            //POInfo po = pobl.Read("4913004762");
            //Console.WriteLine("S");
            //Regex reg = new Regex(@"^[\d]{4}-[\d]{2}-[\d]{2} [\d]{2}:[\d]{2}:[\d]{2} [\d]{7}");
            //Console.WriteLine(reg.IsMatch("2015-12-08 7:45:17 6444540"));
            //IList<LogInfo> nodes = new List<LogInfo>();
            //FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/Logs/2015-12-08.log", FileMode.Open, FileAccess.Read);
            //if (fs.CanRead)
            //{
            //    StreamReader sr = new StreamReader(fs);
            //    //String line = sr.ReadLine();
            //    Regex reg = new Regex(@"^[\d]{4}-[\d]{2}-[\d]{2} [\d]{2}:[\d]{2}:[\d]{2} [\d]{7}");
            //    LogInfo node = new LogInfo();
            //    //2015-12-08 07:46:18 0979094

            //    string str = sr.ReadToEnd(); 
            //    sr.Close();
            //    fs.Close();
            //    string[] aryStr = Regex.Split(str, "\r\n");

            //    foreach (string line in aryStr)
            //    {
            //        if (line.Length > 27 && reg.IsMatch(line.Substring(0, 27)))
            //        {
            //            if (node.Content != null)
            //                nodes.Add(node);
            //            node = new LogInfo();
            //            node.Date = line.Substring(0, 27);
            //            node.Title = line.Substring(28, line.Length - 28);
            //        }
            //        else
            //        {
            //                node.Content = node.Content + line;
            //        }
            //    }
            //}


            //foreach (LogInfo node in nodes)
            //{
            //    Console.WriteLine(node.Title);
            //    Console.WriteLine(node.Content);
            //}

            //Log log = new Log();
            //log.Read(0);

            //Enqueue e = new Enqueue();
            //IList<EnqueueInfo> nodes = e.Read("");
            //foreach(EnqueueInfo node in nodes)
            //{
            //    Console.WriteLine(node.Mode+";"+node.Name);
            //}
            //Console.WriteLine(nodes.Count);
            //ScheduleRequisition srbl = new ScheduleRequisition();
            //ScheReqInfo node = srbl.Read("7000000056");
            //Console.WriteLine(node.Date);
            //7000000056

            //PurchaseOrder pobl = new PurchaseOrder();
            //POInfo node = pobl.Read("4000048564");
            //Console.WriteLine(node.Header.Number);
            //Ingredient i = new Ingredient();
            //i.Material();
            //UserSoapClient client = new UserSoapClient("UserSoap");
            //client.SignIn("23434", "23424");
            //Console.WriteLine(Sonluk.DataAccess.OA.Utility.Connection.connectionString);
            //DESE.Decrypt("23423423", "34253453");
            //Battery battery = new Battery();
            //IList<BatteryHistoryInfo> nodes1 = battery.History("PALA210600", "LR6");
            //Product product = new Product();
            //IList<BatteryHistoryInfo> nodes2 = product.History("PALA210600", "LR6");
            //Console.WriteLine("S");
            //for (int i = 0; i < 1000; i++)
            //{
            //    Logger.Write("x",i.ToString());
            //    //Record.Insert("x", i.ToString());
            //}
            //Sonluk.DataAccess.Utility

            //var dm = new LogX2Manager();

            //ProcessLogX2.Start(dm);

            //// Create documents and add them to the DocumentManager
            //for (int i = 0; i < 1000; i++)
            //{
            //    Wrox.ProCSharp.Collections.LogX2 doc = new Wrox.ProCSharp.Collections.LogX2("Doc " + i.ToString(), "content");
            //    dm.AddDocument(doc);
            //    Console.WriteLine("Added document {0}", doc.Title);
            //    Thread.Sleep(new Random().Next(20));
            //}
            //string x = ConnectionString.Create("OA", "OA.DB.User", "OA.DB.Password", "sMrqqC}+");
            //byte k = 0;
            //int temp;
            //const int SHIFT = sizeof(int) * 8 - 1;
            //char[] OutString = new char[SHIFT + 1];
            //const int Mask = (int)1 << SHIFT;
            //temp = 333333;
            //for (int j = 0; j <= SHIFT; j++)
            //{
            //    OutString[k++] = ((temp & Mask) == 0 ? '0' : '1');
            //    temp <<= 1;
            //}
            //Console.WriteLine(OutString);
            //decimal qty = 123456789112.333M;
            //IRfcFunction func = RFC.Function("ZSL_QMFM_003");
            //func.SetValue("I_MGEIG", qty);


            //Message message = new Message();
            //Console.WriteLine(message.Send("[双鹿主机]请假单同步失败！"));
            //Console.WriteLine("S");
            //Flow flow = new Flow();
            //flow.SyncLog();

            //Flow flow = new Flow();
            //flow.UpdateQ1("8266144241672057252", "20151114");
            //string sn = "01";
            //Console.WriteLine(Regex.Replace(sn, @"^[0]*", ""));
            //Flow flow = new Flow();
            //flow.Launch();
            //documentServicePortTypeClient _Client = new documentServicePortTypeClient("documentServiceHttpSoap11Endpoint");
            //Authority auth = new Authority();
            //auth.Authenticate();
            //string xml = _Client.exportFlow2(auth.Authenticate(), -642120897417951426);
            //Console.WriteLine(xml);

            //string xml = "";
            //xml = xml + @"<formExport version=""2.0"">";
            //xml = xml + @"<summary id="""" name=""formmain_0106""/>";
            //xml = xml + @"<definitions>";
            //xml = xml + @"<column id=""field0001"" type=""0"" name=""质量通知单编号"" length=""255""/>";
            //xml = xml + @"<column id=""field0002"" type=""0"" name=""品号"" length=""255""/>";
            //xml = xml + @"<column id=""field0003"" type=""0"" name=""不合格批数量"" length=""255""/>";
            //xml = xml + @"<column id=""field0004"" type=""0"" name=""品名"" length=""255""/>";
            //xml = xml + @"<column id=""field0005"" type=""0"" name=""设备号"" length=""255""/>";
            //xml = xml + @"<column id=""field0006"" type=""0"" name=""不合格数量"" length=""255""/>";
            //xml = xml + @"<column id=""field0008"" type=""0"" name=""供应商"" length=""255""/>";
            //xml = xml + @"<column id=""field0009"" type=""0"" name=""抽样数量"" length=""255""/>";
            //xml = xml + @"<column id=""field0010"" type=""0"" name=""批号"" length=""255""/>";
            //xml = xml + @"<column id=""field0016"" type=""3"" name=""发现时间"" length=""255""/>";
            //xml = xml + @"<column id=""field0018"" type=""0"" name=""不合格描述"" length=""4000""/>";
            //xml = xml + @"<column id=""field0019"" type=""0"" name=""填写人"" length=""255""/>";
            //xml = xml + @"</definitions>";
            //xml = xml + @"<values>";
            //xml = xml + @"<column name=""质量通知单编号"">";
            //xml = xml + @"<value><![CDATA[200000242]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""品号"">";
            //xml = xml + @"<value><![CDATA[1000006819]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""不合格批数量"">";
            //xml = xml + @"<value><![CDATA[6.000]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""品名"">";
            //xml = xml + @"<value><![CDATA[双鹿蓝骑士碳性5号4粒缩打字]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""设备号"">";
            //xml = xml + @"<value><![CDATA[2#]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""不合格数量"">";
            //xml = xml + @"<value><![CDATA[6.000]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""供应商"">";
            //xml = xml + @"<value><![CDATA[宁波丰银电池有限公司]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""抽样数量"">";
            //xml = xml + @"<value><![CDATA[5.000]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""批号"">";
            //xml = xml + @"<value><![CDATA[15110202]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""发现时间"">";
            //xml = xml + @"<value><![CDATA[2015-11-03]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""不合格描述"">";
            //xml = xml + @"<value><![CDATA[尺寸不合格，钢壳上口破]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""填写人"">";
            //xml = xml + @"<value/>";
            ////xml = xml + @"<value/><![CDATA[2559316557750091802]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"</values>";
            //xml = xml + @"<subForms>";
            //xml = xml + @"<subForm>";
            //xml = xml + @"<definitions>";
            //xml = xml + @"<column id=""field0065"" type=""0"" name=""缺陷类型"" length=""255""/>";
            //xml = xml + @"<column id=""field0066"" type=""0"" name=""缺陷"" length=""255""/>";
            //xml = xml + @"<column id=""field0067"" type=""0"" name=""缺陷数量"" length=""255""/>";
            //xml = xml + @"</definitions>";
            //xml = xml + @"<values>";
            //xml = xml + @"<row>";
            //xml = xml + @"<column name=""缺陷类型"">";
            //xml = xml + @"<value><![CDATA[尺寸错]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""缺陷"">";
            //xml = xml + @"<value><![CDATA[包装材料原因]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""缺陷数量"">";
            //xml = xml + @"<value><![CDATA[2]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"</row>";
            //xml = xml + @"<row>";
            //xml = xml + @"<column name=""缺陷类型"">";
            //xml = xml + @"<value><![CDATA[尺寸错]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""缺陷"">";
            //xml = xml + @"<value><![CDATA[包装材料原因]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"<column name=""缺陷数量"">";
            //xml = xml + @"<value><![CDATA[2]]></value>";
            //xml = xml + @"</column>";
            //xml = xml + @"</row>";
            //xml = xml + @"</values>";
            //xml = xml + @"</subForm>";
            //xml = xml + @"</subForms>";
            //xml = xml + @"</formExport>";
            //string xml11 = "";
            //xml11 = xml11 + @"<formExport version=""2.0"">";
            //xml11 = xml11 + @"<summary id="""" name=""formmain_0393""/><definitions>";
            //xml11 = xml11 + @"<column id=""field0001"" type=""0"" name=""质量通知单编号"" length=""255""/>";
            //xml11 = xml11 + @"<column id=""field0004"" type=""0"" name=""品号"" length=""255""/>";
            //xml11 = xml11 + @"<column id=""field0007"" type=""0"" name=""品名"" length=""255""/>";
            //xml11 = xml11 + @"<column id=""field0009"" type=""0"" name=""供应商"" length=""255""/>";
            //xml11 = xml11 + @"<column id=""field0010"" type=""0"" name=""设备"" length=""255""/>";
            //xml11 = xml11 + @"<column id=""field0014"" type=""3"" name=""发现时间"" length=""255""/>";
            //xml11 = xml11 + @"<column id=""field0016"" type=""3"" name=""素电池日期-起"" length=""255""/>";
            //xml11 = xml11 + @"<column id=""field0017"" type=""3"" name=""素电池日期-止"" length=""255""/>";
            //xml11 = xml11 + @"<column id=""field0024"" type=""0"" name=""填写人"" length=""255""/>";
            //xml11 = xml11 + @"</definitions>";
            //xml11 = xml11 + @"<values>";
            //xml11 = xml11 + @"<column name=""质量通知单编号"">";
            //xml11 = xml11 + @"<value><![CDATA[200000246]]></value>";
            //xml11 = xml11 + @"</column>";
            //xml11 = xml11 + @"<column name=""品号"">";
            //xml11 = xml11 + @"<value><![CDATA[3000002025]]></value>";
            //xml11 = xml11 + @"</column>";
            //xml11 = xml11 + @"<column name=""品名"">";
            //xml11 = xml11 + @"<value><![CDATA[LR03普通素电池]]></value>";
            //xml11 = xml11 + @"</column>";
            //xml11 = xml11 + @"<column name=""供应商"">";
            //xml11 = xml11 + @"<value><![CDATA[8002]]></value>";
            //xml11 = xml11 + @"</column>";
            //xml11 = xml11 + @"<column name=""设备"">";
            //xml11 = xml11 + @"<value/>";
            //xml11 = xml11 + @"</column>";
            //xml11 = xml11 + @"<column name=""发现时间"">";
            //xml11 = xml11 + @"<value><![CDATA[2015-11-16]]></value>";
            //xml11 = xml11 + @"</column>";
            //xml11 = xml11 + @"<column name=""素电池日期-起"">";
            //xml11 = xml11 + @"<value><![CDATA[2015-11-15]]></value>";
            //xml11 = xml11 + @"</column>";
            //xml11 = xml11 + @"<column name=""素电池日期-止"">";
            //xml11 = xml11 + @"<value><![CDATA[2015-11-17]]></value>";
            //xml11 = xml11 + @"</column>";
            //xml11 = xml11 + @"<column name=""填写人"">";
            //xml11 = xml11 + @"<value/>";
            //xml11 = xml11 + @"</column>";
            //xml11 = xml11 + @"</values>";
            //xml11 = xml11 + @"</formExport>";
            //BPM bpm = new BPM();
            //long[] att = new long[3];
            //MessageInfo message = bpm.Launch("01520", "11", "过程流程测试", xml11, att, "0", "");
            //Console.WriteLine(message.Status + message.Value+ message.Key);

            //Message messageBL = new Message();
            //if (message.Key.Length > 10)
            //{
            //    message.Value = message.Value + "已发起流程";
            //}
            //else
            //{
            //    messageBL.Send("[OA]通知单200000242无法触发QM001流程！" + message.Value);
            //}
            //string[] result = bpm.Template("11");


            //User user = new User();
            //user.SignIn("CZ","123456");
            //string strURL = @"http://192.168.0.13/seeyon/login/sso?from=fuyaosso&ticket=02299";
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            //request.Method = "GET";
            //request.Timeout = 100;

            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //QualityNotification qnbl = new QualityNotification();
            //QNInfo qn = new QNInfo();
            //qnbl.Update(qn);

            //SAPSync sync = new SAPSync();
            //Console.WriteLine(sync.Sync("5204774333296756082"));


            //Flow flow = new Flow();
            //flow.Sync();
            //Console.WriteLine("s");
            //Message message = new Message();
            //IList<string> names = new List<string>();
            //names.Add("02299");
            //IList<string> url = new List<string>();
            //url.Add("");
            //bool success = message.Send(names, "质量通知单20000002132同步失败，请处理！", url);
            //Console.WriteLine(success);
            //Flow flow = new Flow();
            //FlowLogInfo log = new FlowLogInfo();
            //log.ID = "46464656565656";
            //DateTime now = DateTime.Now;
            //log.Date = now.ToString("yyyy-MM-dd HH:mm:ss");
            //log.Status = 1;
            //Console.WriteLine(flow.SyncLog(log));

            //string strURL = @"http://192.168.0.13/seeyon/login/sso?from=fuyaosso&ticket=02299";
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            //request.Method = "GET";
            //request.Timeout = 100;

            //string StrDate = "";
            //string strValue = "";

            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Stream s = response.GetResponseStream(); ;

            //StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            //while ((StrDate = Reader.ReadLine()) != null)
            //{
            //    strValue += StrDate + "\r\n";
            //}

            //Console.Write(strValue);

            //Console.ReadLine();
            //string dateStart = "Tue Nov 10 00:00:00 CST 2015";
            //DateTime startDateTime = Convert.ToDateTime(dateStart);


            //string x = "2015.08-01";
            //Console.WriteLine(x.Replace(@"[^\d]*", ""));
            //Console.WriteLine(Regex.Replace(x, @"[^\d]*", ""));
            ////Battery b = new Battery();
            ////b.History("","");
            //////Material m = new Material();
            //////Console.WriteLine(m.Price("1000002418","100000","1100","20"));

            //authorityServicePortTypeClient auth = new authorityServicePortTypeClient("authorityServiceHttpSoap12Endpoint");
            //UserToken token = auth.authenticate("service-admin", "123456");

            //affairServicePortTypeClient asptc = new affairServicePortTypeClient("affairServiceHttpSoap12Endpoint");
            //string xml = asptc.exportPendingList(token.id.ToString(), "V8002", 0, 10);

            //Pending pending = new Pending();

            //string xml2 = asptc.exportTrackList(token.id.ToString(), "00676", 0, 10);
            //string returnString = bpm.receiveThirdpartyForm(token.id.ToString(), "");
            //IList<PendingInfo> nodes = pending.Read("8007", "V8007", 0, 10);
            //Console.WriteLine(nodes.Count);

            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.LoadXml(xml);
            //XmlNode root = xmlDoc.SelectSingleNode("/B/P/L");
            //XmlNodeList nodeList = root.ChildNodes;
            //foreach (XmlNode xmlNode in nodeList)
            //{
            //    PendingInfo node = new PendingInfo();
            //    int index = 0;
            //    node.Subject = xmlNode.ChildNodes[index++].InnerText;
            //    node.ApplicationCategoryKey = xmlNode.ChildNodes[index++].InnerText;
            //    node.CreateMemberName = xmlNode.ChildNodes[index++].InnerText;
            //    node.Distinct = xmlNode.ChildNodes[index++].InnerText;
            //    node.BodyType = xmlNode.ChildNodes[index++].InnerText;
            //    node.ID = xmlNode.ChildNodes[index++].InnerText;
            //    node.ObjectId = xmlNode.ChildNodes[index++].InnerText;
            //    node.HasAttachments = xmlNode.ChildNodes[index++].InnerText;
            //    node.CreateDate = xmlNode.ChildNodes[index++].InnerText;
            //    node.SubObjectId = xmlNode.ChildNodes[index++].InnerText;
            //    node.MportantLevel = xmlNode.ChildNodes[index++].InnerText;
            //    nodes.Add(node);

            //}
            //Pending p = new Pending();

            //p.Read("","seeyon",0,8);

            //Console.WriteLine(xml);
            //Console.WriteLine(xml2);

            //string title = "测试";
            //MatchCollection matches = Regex.Matches(title, "[1-9][0-9]*");
            //if (matches.Count > 0)
            //{ 
            //    Console.WriteLine(matches[0]); 
            //}

            //foreach (Match mch in Regex.Matches(title, "[1-9][0-9]*"))
            //{
            //    string x = mch.Value.Trim();
            //    Console.WriteLine("2" + x);
            //}
            //int titleIndex = title.IndexOf("^([1-9][0-9]*)");
            //string vendor = title.Substring(0, titleIndex);
            //Console.WriteLine(vendor);
            //Console.ReadLine();


            //DirectoryInfo di = new DirectoryInfo(@"D:\APP\Sonluk\Temp\PO");
            //FileInfo[] files = di.GetFiles();
            //foreach (FileInfo file in files)
            //{
            //    //Console.WriteLine(file.Name+","+file.LastWriteTime);
            //    if (file.LastWriteTime < DateTime.Now.AddHours(-1))
            //    {
            //        file.Delete();
            //        //Console.WriteLine("删除");             
            //    }
            //}
            //DateTime startTime1 = DateTime.Now;
            //IList<Language> languages = Unicode();
            //Console.WriteLine(AnalyseLanguage(languages, "测试语言种类识别测试輸入簡體字한국어"));
            //DateTime endTime1 = DateTime.Now;
            //Console.WriteLine(endTime1 - startTime1);

            //string longlongstring = "w11111111222q333333335，55555ee 12한자34567890yyy111111111yyy000000AK123456Me123456tttt12345678汉字";
            //foreach (Match mch in Regex.Matches(longlongstring, "([^\uac00-\ud7ff]+)|([\uac00-\ud7ff]+)"))
            //{
            //    string x = mch.Value.Trim();
            //    Console.WriteLine("2" + x);
            //}
            //Console.ReadLine();

            //PurchaseOrder pobl = new PurchaseOrder();
            //Console.WriteLine("0");
            //MemoryStream memoryStream = pobl.Export("4914004499", 1);
            //Console.WriteLine("1");
            //try
            //{
            //    FileStream file = new FileStream("Sonluk_PO.pdf", FileMode.Create);
            //    Console.WriteLine("文件流打开成功");
            //    file.Write(memoryStream.ToArray(), 0, (memoryStream.ToArray()).GetLength(0));
            //    Console.WriteLine("文件流写入成功");
            //    file.Close();
            //    Console.WriteLine("文件保存成功");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("文件流异常");
            //}
            //Console.ReadLine();

            //BaseFont BF_Light = BaseFont.CreateFont(@"C:\Windows\Fonts\simsun.ttc,0", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            //MemoryStream memoryStream = CreatePDF("4000045432", 2);

            //try
            //{
            //    FileStream file = new FileStream("Sonluk_PO.pdf", FileMode.Create);
            //    Console.WriteLine("文件流打开成功");
            //    file.Write(memoryStream1.ToArray(), 0, (memoryStream1.ToArray()).GetLength(0));
            //    Console.WriteLine("文件流写入成功");
            //    file.Close();
            //    Console.WriteLine("文件保存成功");

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("文件流异常");

            //}



            //string text = "是不是汉字，ABC";
            //for (int i = 0; i < text.Length; i++)
            //{
            //    if (Regex.IsMatch(text[i].ToString(), @"[\u4e00-\u9fbb]+{1}"))
            //        Console.WriteLine("是汉字");
            //    else
            //        Console.WriteLine("不是汉字");
            //}

            //string content = "123ab测试AB한자";
            //if (Regex.IsMatch(content, @"^[\u4e00-\u9fa50-9a-bA-B]+$")) // 如果是中文  
            //{
            //    Console.WriteLine(content);
            //}
            //Console.WriteLine(content.IndexOf("[\uac00-\ud7ff]").ToString());






            ////创建销售订单
            //SalesOrder sobl = new SalesOrder();
            //SOInfo so = new SOInfo();
            //SOHeaderInfo header = new SOHeaderInfo();
            //header.SalesOrganization = "1100";
            //header.DistributionChannel = "20";
            //header.Division = "00";
            //header.SoldToParty = "100000";
            //header.ShipToParty = "300905";
            //header.CustomerPO = "";
            //header.CustomerPODate = "20150910";
            //so.Header = header;
            //so.Items = new List<SOItemInfo>();
            //SOItemInfo item1 = new SOItemInfo();
            //item1.Material = "1000002483";
            //item1.Quantity = 6000;
            //item1.SalesUnit = "PCS";

            //so.Items.Add(item1);
            //Console.WriteLine(sobl.Create(so));
            //Console.ReadLine();

            //读取客户数据
            //Customer cbl = new Customer();
            //Console.WriteLine((cbl.Read("20150801","170000")).General.Count);
            //Console.ReadLine();
            //
            //Access access = new Access();
            //AccountInfo account = access.SignIn("8002","123");
            //Console.WriteLine(account.Name);
            //////采购订单查询
            //POKeywordInfo kw = new POKeywordInfo();
            //kw.Vendor = "8002";
            //PurchaseOrder pobl = new PurchaseOrder();
            //Console.WriteLine(pobl.Read(kw).Count);

            //读取送达方
            //Customer cbl = new Customer();
            //Console.WriteLine((cbl.ShipToParty("100000","1100","20","00")).Count);
            //Console.ReadLine();

            ////读取折扣
            //Customer cbl = new Customer();
            //Console.WriteLine((cbl.Discount("100000")).Rate);
            //Console.ReadLine();

            //权限读取
            //Sonluk.BusinessLogic.Account.Authorization auth = new Sonluk.BusinessLogic.Account.Authorization();
            //Console.WriteLine(auth.Read("PUZL").ReleaseGroup);
            //Console.ReadLine();

            //销售报表
            //Report report = new Report();
            //report.ZKMX("100000","20150701","20150731");
            //Console.ReadLine();

            //Access access = new Access();
            //access.SignIn("BZB","666666");

            //ScheduleRequisition sr = new ScheduleRequisition();
            //Console.WriteLine(sr.Update("7000000137", "TEST", 2));
            //string resultStr;
            //for (int i = 1; i < 255; i++)
            //{
            //    resultStr = Utility.Remote.WebAPI.Request("http://192.168.0." + i, "cityname=宁波");
            //    if (!resultStr.Equals(""))
            //        Console.WriteLine(i);

            //}
            //Console.WriteLine(i+":"+Utility.Remote.WebAPI.Request("http://192.168.0."+i, "cityname=宁波"));
            //string resultStr;
            // for(int i =1;i<255;i++)
            // string resultStr = Utility.Remote.WebAPI.Request("http://192.168.5.5", "cityname=宁波");
            // Console.WriteLine(resultStr);
            //APIResult result = JsonConvert.DeserializeObject<APIResult>(resultStr);
            //string xmlStr = "";
            //string jsonStr = "";
            //APIResult resultXml, resultJson;
            ////Console.WriteLine(JsonConvert.SerializeXmlNode<APIResult>(result));



            //DateTime startTime1 = DateTime.Now;
            //StringWriter sw = new StringWriter();
            //XmlSerializer xz = new XmlSerializer(result.GetType());
            //xz.Serialize(sw, result);
            //xmlStr = sw.ToString();
            //StringReader sr = new StringReader(xmlStr);
            //resultXml = (APIResult)xz.Deserialize(sr);
            //DateTime endTime1 = DateTime.Now;
            //Console.WriteLine(endTime1 - startTime1);

            //DateTime startTime2 = DateTime.Now;
            //jsonStr = JsonConvert.SerializeObject(result);
            //resultJson = JsonConvert.DeserializeObject<APIResult>(jsonStr);
            //DateTime endTime2 = DateTime.Now;
            //Console.WriteLine(endTime2 - startTime2);

            //Console.WriteLine(xmlStr.Length + ";" + jsonStr.Length);
            //Console.WriteLine(xmlStr);
            //Console.WriteLine(jsonStr);
            //Console.WriteLine(sw.ToString());




            //采购订单查询
            //POKeywordInfo kw = new POKeywordInfo();
            //kw.SDDoc = "20016247";
            //PurchaseOrder pobl = new PurchaseOrder();
            //Console.WriteLine(pobl.Read(kw).Count);

            //List<POItemInfo> nodes = new List<POItemInfo>();
            //for (int i = 0; i < 30; i++)
            //{
            //    POItemInfo node = new POItemInfo();
            //    node.PONumber = "4919000094"+i;
            //    node.Number = i;
            //    node.ReleaseCode = "A1";
            //    node.DelivDate = "2015-05-11";
            //    nodes.Add(node);

            //}

            //采购订单打印逻辑
            //PurchaseOrder pobl = new PurchaseOrder();
            //List<POItemInfo> itemNodes = new List<POItemInfo>();
            //POItemInfo node = new POItemInfo();
            //node.PONumber = "4000024453";
            //node.Number = 10;
            //itemNodes.Add(node);
            //POItemInfo node2 = new POItemInfo();
            //node2.PONumber = "4000024425";
            //node2.Number = 10;
            //itemNodes.Add(node2);
            //POItemInfo node3 = new POItemInfo();
            //node3.PONumber = "4000012516";
            //node3.Number = 10;
            //itemNodes.Add(node3);
            //POItemInfo node4 = new POItemInfo();
            //node4.PONumber = "4000012516";
            //node4.Number = 20;
            //itemNodes.Add(node4);
            //POItemInfo node5 = new POItemInfo();
            //node5.PONumber = "4000012516";
            //node5.Number = 30;
            //itemNodes.Add(node5);
            //POItemInfo node6 = new POItemInfo();
            //node6.PONumber = "4000012511";
            //node6.Number = 10;
            //itemNodes.Add(node6);
            //IList<PageInfo<POInfo>> nodes = pobl.AnalysePrintData("IQCPM", 1, "241-280", itemNodes);
            //Console.WriteLine(nodes.Count);

            ////采购订单按单查询
            //PurchaseOrder pobl = new PurchaseOrder();
            //SOKeywordInfo SOnode = new SOKeywordInfo();
            //SOnode.Number = "20014650";
            //SOnode.Item= 10;
            //SOnode.Material = "2000012369";
            //IList<POItemInfo> itemNodes = pobl.Read(SOnode);
            //Console.WriteLine(itemNodes.Count);


            //采购订单交货计划请求新建
            //ScheduleRequisition srbl = new ScheduleRequisition();
            //ScheReqInfo sr = new ScheReqInfo();
            //sr.SalesOrder = "20014650";
            //sr.SOItem = 10;
            //sr.Material = "2000002220";
            //sr.Remark = "新建测试";
            //sr.Creator = "ysj";
            //sr.Items = new List<ScheduleLineInfo>();
            //ScheduleLineInfo item = new ScheduleLineInfo();
            //item.Number = "4000021623";
            //item.Item = 10;
            //item.Line = 1;
            //item.Quantity = 4752;
            //item.Date = "20150720";
            //item.Destination = "第二能源";
            //item.PurGroup = "103";
            //item.Status = 1;
            //sr.Items.Add(item);

            //ScheduleLineInfo item1 = new ScheduleLineInfo();
            //item1.Number = "4000021623";
            //item1.Item = 10;
            //item1.Line = 2;
            //item1.Quantity = 3000;
            //item1.Date = "20150720";
            //item1.Destination = "第二能源";
            //item1.PurGroup = "104";
            //item1.Status = 1;
            //sr.Items.Add(item1);
            //Console.WriteLine(srbl.Create(sr));

            ////采购订单交货计划请求读取
            //ScheduleRequisition srbl = new ScheduleRequisition();
            //ScheReqInfo sr = srbl.Read("7000000013");
            //Console.WriteLine(sr.SalesOrder);


            ////采购订单交货计划请求修改
            //ScheduleRequisition srbl = new ScheduleRequisition();
            //ScheReqInfo sr = srbl.Read("7000000016");
            //Console.WriteLine(sr.SalesOrder);
            //sr.Releaser = "ysj";
            //sr.Items[0].Quantity = 3000;
            //ScheduleLineInfo item = new ScheduleLineInfo();
            //item.Number = "4000021622";
            //item.Item = 10;
            //item.Line = 3;
            //item.SerialNumber = "7000000016";
            //item.Quantity = 1752;
            //item.Date = "20150720";
            //item.Destination = "可控核聚变研发";
            //item.Status = 1;
            //sr.Items.Add(item);
            //Console.WriteLine(srbl.Update(sr));

            //采购订单交货计划请求状态
            //ScheduleRequisition srbl = new ScheduleRequisition();
            //Console.WriteLine(srbl.Update("7000000034","测试",1));

            ////采购订单交货计划请求同步
            //POInfo po = new POInfo();
            //POHeaderInfo poHeader = new POHeaderInfo();
            //poHeader.Number = "4000024402";

            //POItemInfo poItem = new POItemInfo();
            //poItem.Number = 10;

            //ScheduleLineInfo schedule01 = new ScheduleLineInfo();
            //schedule01.Line = 1;
            //schedule01.Quantity = 3000;
            //schedule01.Date = "20150802";
            //ScheduleLineInfo schedule02 = new ScheduleLineInfo();
            //schedule02.Line = 2;
            //schedule02.Quantity = 1000;
            //schedule02.Date = "20150803";
            //schedule02.Delete = "X";

            //poItem.Schedule = new List<ScheduleLineInfo>();
            //poItem.Schedule.Add(schedule01);
            //poItem.Schedule.Add(schedule02);

            //po.Header = poHeader;
            //po.Items = new List<POItemInfo>();
            //po.Items.Add(poItem);

            //PurchaseOrder pobl = new PurchaseOrder();
            //Console.WriteLine(pobl.UpdateSchedule(po));
            //ScheduleRequisition srbl = new ScheduleRequisition();
            //Console.WriteLine(srbl.Sync("7000000045"));

            //采购订单交货计划请求查询
            //ScheduleRequisition srbl = new ScheduleRequisition();
            //ScheReqInfo sr = new ScheReqInfo();
            ////sr.SalesOrder = "20014650";
            ////sr.SOItem = 10;
            ////sr.Material = "2000002220";
            ////sr.Remark = "新建测试";
            //sr.Creator = "YSJ";
            //IList<ScheReqInfo> nodes = srbl.Read(sr);
            //Console.WriteLine(nodes.Count());

            //登录测试
            //Access access = new Access();
            //AccountInfo user = access.SignIn("YUSJ", "66666");
            //Console.WriteLine(user.Name);
            ////采购订单交货计划请求修改状态
            //ScheduleRequisition srbl = new ScheduleRequisition();
            //srbl.Update("7000000012","yusj",-1);

            ////采购订单交货计划请求删除
            //ScheduleRequisition srbl = new ScheduleRequisition();
            //Console.WriteLine(srbl.Delete("7000000014"));

            //采购订单交货计划请求
            //ScheduleRequisition srbl = new ScheduleRequisition();
            //ScheReqInfo sr = srbl.Read("7000000008");
            //sr.Items = new List<ScheduleLineInfo>();

            //Console.WriteLine(sr.SalesOrder);
            //sr.Remark = "测试";


            //srbl.Update("7000000008", "TEST", -2);


            //DateTime startTime = DateTime.Now;
            //POInfo po = pobl.Read("4000023520");
            //POInfo po2 = pobl.Read("4000023521");
            //POInfo po3 = pobl.Read("4000023522");
            //DateTime endTime = DateTime.Now;
            //Console.WriteLine(endTime - startTime);
            //Console.WriteLine(nodes.Count);

            //List<IndexInfo> t = new List<IndexInfo>(); //original

            //t.Add(new IndexInfo(1, 2));


            //List<IndexInfo> t2 = new List<IndexInfo>(); // copy of t
            //t.CopyTo(t2);
            //t2[0].Start = 9;
            //Console.WriteLine(t[0].Start);


            //SalesOrder po = new SalesOrder();
            //IList<CustomTextInfo> ct = po.CustomText("20015323",10,"20010000");
            //Console.WriteLine(ct.Count);

            //Tax tax = new Tax();
            //Console.WriteLine(tax.Rate("J2"));

            //PurchasingGroup pg = new PurchasingGroup();
            //Console.WriteLine((pg.Read("116")).Description);

            //Vendor vendor = new Vendor();
            //CompanyInfo com = vendor.Read("8002");
            //Console.WriteLine(com.Name);

            //Company company = new Company();
            //CompanyInfo com1 = company.Read("3000");
            //Console.WriteLine(com1.Name);


            //List<PageInfo<POTitleInfo>> pages = po.AnalysePrintData("IQCPM", nodes, 20);
            //Console.WriteLine("page:" + pages.Count);
            //foreach (PageInfo<POTitleInfo> page in pages)
            //{

            //    Console.WriteLine("nodes:" + page.Children.Count);

            //}
            //Node node = new Node();
            //node.a = "a";
            //node.b = "b";

            //Layout layout = new Layout();
            //LayoutInfo node = layout.Read("ConsignmentNote5","0");
            //Console.WriteLine(node.Controls.Count);
            //string x = node["a"];

            //CreateContainer();
            //DP();

            //Console.WriteLine(KnapSack());
            //List<POItemInfo> nodes = new List<POItemInfo>();
            //POItemInfo node1 = new POItemInfo();
            //node1.PONumber = "4919000094";
            //node1.Number = 20;
            //node1.ReleaseCode = "A1";
            //node1.DelivDate = "2015-05-11";

            //POItemInfo node2 = new POItemInfo();
            //node2.PONumber = "4919000094";
            //node2.Number = 30;
            //node2.ReleaseCode = "A1";
            //node2.DelivDate = "2015-05-11";

            //POItemInfo node3 = new POItemInfo();
            //node3.PONumber = "4919000094";
            //node3.Number = 40;
            //node3.ReleaseCode = "A1";
            //node3.DelivDate = "2015-05-11";

            //POItemInfo node4 = new POItemInfo();
            //node4.PONumber = "4919000094";
            //node4.Number = 50;
            //node4.ReleaseCode = "A1";
            //node4.DelivDate = "2015-05-11";

            //POItemInfo node5 = new POItemInfo();
            //node5.PONumber = "4000011234";
            //node5.Number = 10;
            //node5.ReleaseCode = "A1";
            //node5.DelivDate = "2015-05-11";

            //POItemInfo node6 = new POItemInfo();
            //node6.PONumber = "4000012511";
            //node6.Number = 10;
            //node6.ReleaseCode = "A1";
            //node6.DelivDate = "2015-05-11";

            //POItemInfo node7 = new POItemInfo();
            //node7.PONumber = "4000012516";
            //node7.Number = 10;
            //node7.ReleaseCode = "A1";
            //node7.DelivDate = "2015-05-11";

            //POItemInfo node8 = new POItemInfo();
            //node8.PONumber = "4000014402";
            //node8.Number = 10;
            //node8.ReleaseCode = "A1";
            //node8.DelivDate = "2015-05-11";

            //POItemInfo node9 = new POItemInfo();
            //node9.PONumber = "4000023520";
            //node9.Number = 10;
            //node9.ReleaseCode = "A1";
            //node9.DelivDate = "2015-05-11";

            //POItemInfo node10 = new POItemInfo();
            //node10.PONumber = "4000023905";
            //node10.Number = 10;
            //node10.ReleaseCode = "A1";
            //node10.DelivDate = "2015-05-11";

            //POItemInfo node11 = new POItemInfo();
            //node11.PONumber = "4000024012";
            //node11.Number = 10;
            //node11.ReleaseCode = "A1";
            //node11.DelivDate = "2015-05-11";

            //POItemInfo node12 = new POItemInfo();
            //node12.PONumber = "4919000094";
            //node12.Number = 20;
            //node12.ReleaseCode = "A1";
            //node12.DelivDate = "2015-05-11";

            //nodes.Add(node1);
            //nodes.Add(node2);
            //nodes.Add(node3);
            //nodes.Add(node4);
            //nodes.Add(node5);
            //nodes.Add(node6);
            //nodes.Add(node7);
            //nodes.Add(node8);
            //nodes.Add(node9);

            //nodes.Add(node10);
            //nodes.Add(node11);
            //nodes.Add(node12);
            //DateTime startTime1 = DateTime.Now;
            //PurchaseOrder po1 = new PurchaseOrder();
            //po1.UpdateDeliveryDate(nodes);
            //DateTime endTime1 = DateTime.Now;
            //Console.WriteLine(endTime1 - startTime1);

            //DateTime startTime = DateTime.Now;
            //PurchaseOrder po = new PurchaseOrder();
            //po.UpdateDeliveryDateParallel(nodes);
            //DateTime endTime = DateTime.Now;
            //Console.WriteLine(endTime - startTime);

            // Console.WriteLine("构成背包的最大价值的物品是: " );
            // int totcap = 0;
            // while (totcap <= capacity)
            // {
            //  Console.WriteLine("物品的大小是：" + size[best[capacity - totcap]]);
            //  for (i = 0; i <= n-1; i++)
            //  totcap += size[best[i]];
            // }

            //User user = new User();
            //AccountInfo account = user.SignIn("test", "C4CA4238A0B923820DCC509A6F75849B");
            //Console.WriteLine(account.SignIn);
            //Enqueue enqueue = new Enqueue();
            //IList<EnqueueInfo> node = enqueue.Read();
            //Console.WriteLine(node.Count);
            //Console.WriteLine(enqueue.Read("EKKO", "4000024350"));


            //Func<int, Func<int, int>> Creator = x => y => y + 1;

            //var plus = OPCreator("+");

            //Console.WriteLine(plus(2, 3));

            //List<POItemInfo> nodes = new List<POItemInfo>();


            //RandomString rs = new RandomString();
            //Console.WriteLine(rs.Create(8));
            //Console.WriteLine(rs.Create(8));
            //Console.WriteLine(rs.Create(8));
            //Console.WriteLine(rs.Create(8));
            //Console.WriteLine(rs.Create(8));

            //string str = string.Empty;
            //long num2 = 635676376299090834 + 1;
            //Random random = new Random(Convert.ToInt32(DateTime.Now.ToString("yyyyMMddHH")));
            //for (int i = 0; i < 8; i++)
            //{
            //    char ch;
            //    int num = random.Next();
            //    if ((num % 2) == 0)
            //    {
            //        ch = (char)(0x30 + ((ushort)(num % 10)));
            //    }
            //    else
            //    {
            //        ch = (char)(0x41 + ((ushort)(num % 0x1a)));
            //    }
            //    str = str + ch.ToString();
            //}
            //Console.WriteLine(str);
            //str = string.Empty;
            //DateTime.Now.Minute
            //Random random1 = new Random(Convert.ToInt32(DateTime.Now.ToString("yyyyMMddHH")));
            //for (int i = 0; i < 8; i++)
            //{
            //    char ch;
            //    int num = random1.Next();
            //    if ((num % 2) == 0)
            //    {
            //        ch = (char)(0x30 + ((ushort)(num % 10)));
            //    }
            //    else
            //    {
            //        ch = (char)(0x41 + ((ushort)(num % 0x1a)));
            //    }
            //    str = str + ch.ToString();
            //}
            //Console.WriteLine(str);
            //Console.WriteLine(Convert.ToInt32(DateTime.Now.ToString("yyyyMMddHH")));
            //Console.WriteLine(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> 1)));
            //for (int i = 0; i < 20; i++)
            //{
            //    string key = Membership.GeneratePassword(12, 1);
            //    Console.WriteLine(key);
            //    Console.WriteLine(DES.Encrypt("1" + i, key));

            //    Console.WriteLine(DES.Decrypt(DES.Encrypt("1" + i, key), key));
            //}
            //string filePath = "so.xlsx";

            //FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            //int length = (int)fs.Length;

            //byte[] data = new byte[length];

            //fs.Position = 0;

            //fs.Read(data, 0, length);

            //MemoryStream ms = new MemoryStream(data);

            //PurchaseOrder po = new PurchaseOrder();

            //Console.WriteLine(po.Read(ms).Count);





            //SalesOrder so = new SalesOrder();
            //SOTitleInfo node = new SOTitleInfo();
            //node.Number = "10057922";
            //node.ProcessingRecordsStatus = "1";
            //Console.WriteLine(so.Read(node).Count);
            //81200361-1/81200313-1/81200503-1/
            //Access access = new Access();
            //string node = access.Menu("8002");
            //Console.WriteLine(node);


            //PurchaseOrder po = new PurchaseOrder();

            //DateTime startTime = DateTime.Now;
            //po.UpdateDeliveryDate(nodes);
            ////Console.WriteLine(po.UpdateDeliveryDate(node1));
            //DateTime endTime = DateTime.Now;
            //Console.WriteLine(endTime - startTime);






            //var jSetting = new JsonSerializerSettings();
            ////忽略值为null的
            //jSetting.NullValueHandling = NullValueHandling.Ignore;
            //string json = JsonConvert.SerializeObject(node, jSetting);
            //Console.WriteLine(json);
            //DateTime startTime = DateTime.Now;
            //PurchaseOrder po = new PurchaseOrder();
            //POTitleInfo node = new POTitleInfo();
            //node.Vendor = "1000058";
            //node.StartDate = "20110824";
            //node.Date = "20110831";
            //node.DisplayGRDate = "0";
            //node.DisplayMRDate = "0";
            //node.Status = 1;
            //Console.WriteLine(po.Read(node).Count);
            //DateTime endTime = DateTime.Now;
            //Console.WriteLine(endTime - startTime);


            //title.Status = 2;
            //IList<POItemInfo> node = po.Read(title);
            //OutboundDelivery od = new OutboundDelivery();

            //Console.WriteLine(od.UnLoad(40000, "81096727-1/","1100/10"));
            //RfcDestination _Dest = Destination.Create("SonlukPrd", "30970345");
            //IRfcFunction func = _Dest.Repository.CreateFunction("ZMMLOGIN");
            //Access access = new Access();
            //Console.WriteLine(access.SignIn("8003","123"));
            //string s = DES.Encrypt("18605743937", "30970345");
            //Console.WriteLine(s);
            //Console.WriteLine(DES.Decrypt(s, "30970345"));
            //string docName = "x.xls";


            //int i = 0;
            //i = 29 / 10;

            //List<POItemInfo> itemNodes = new List<POItemInfo>();
            //for (int i = 0; i < 26; i++)
            //{
            //    POItemInfo node = new POItemInfo();
            //    node.PONumber = "400009";
            //    node.Number = i*10;
            //    itemNodes.Add(node);
            //}


            //
            //中文：/[\u4e00-\u9fa5]/
            //日文：/[\u0800-\u4e00]/
            //韩文：/[\uac00-\ud7ff]/

            //Regex ConnoteA = new Regex("^[a-zA-Z]\\d{8}$");
            //Regex ConnoteAA = new Regex("^[a-zA-Z]{2}\\d{7,10}$");
            //Regex ConnoteAAA = new Regex("^[a-zA-Z]{3}\\d{5,9}$");
            //Regex ConnoteAAAA = new Regex("^[a-zA-Z]{4}[a-zA-Z0-9]{8}$");
            //string haha = "w11111111";
            //string xixi = "ww1111111";
            //string hehe = "w111111111";
            //string lala = "W11111111";

            //string longlongstring = "w11111111222q333333335，55555ee 12한자34567890yyy111111111yyy000000AK123456Me123456tttt12345678汉字";

            //bool result = ConnoteA.IsMatch(haha);
            //result = ConnoteA.IsMatch(xixi);
            //result = ConnoteA.IsMatch(hehe);
            //result = ConnoteA.IsMatch(lala);

            //foreach (Match mch in ConnoteA.Matches(longlongstring))
            //{
            //    string x = mch.Value.Trim();
            //    Console.WriteLine("1" + x);
            //}

            //foreach (Match mch in Regex.Matches(longlongstring, "([^\uac00-\ud7ff]+)|([\uac00-\ud7ff]+)"))
            //{
            //    string x = mch.Value.Trim();
            //    Console.WriteLine("2" + x);
            //}
            Console.ReadLine();
        }



        class Updatex
        {

            private IList<POItemInfo> _Nodes;
            private AutoResetEvent[] _Events;


            public void UpdateDeliveryDateParallel(IList<POItemInfo> nodes)
            {
                _Nodes = nodes;

                int POCount = AnalyseDeliveryDateData();

                foreach (POItemInfo node in _Nodes)
                {
                    Console.WriteLine(node.Prev + ";" + node.Next + ";" + node.Status);
                }


                Thread[] threads = new Thread[POCount];
                _Events = new AutoResetEvent[POCount];
                int threadsIndex = 0;
                int length = _Nodes.Count;


                for (int i = 0; i < length; i++)
                {
                    if (_Nodes[i].Prev == -1)
                    {
                        threads[threadsIndex] = new Thread(UpdateDeliveryDate);
                        _Events[threadsIndex] = new AutoResetEvent(false);
                        _Nodes[i].Thread = threadsIndex;
                        threads[threadsIndex].Start(i);
                        threadsIndex++;
                    }
                }

                WaitHandle.WaitAll(_Events);

                foreach (POItemInfo node in _Nodes)
                {
                    Console.WriteLine(node.Prev + ";" + node.Next + ";" + node.Status);
                }

            }

            private void UpdateDeliveryDate(object index)
            {

                int i = (int)index;
                Console.WriteLine(i + ";" + _Nodes[i].Thread + ":s:" + DateTime.Now.ToString("ss.fffffff"));
                PurchaseOrder po = new PurchaseOrder();


                _Nodes[i].Status = po.UpdateDeliveryDate(_Nodes[i]);


                if (_Nodes[i].Next > 0)
                {
                    _Nodes[_Nodes[i].Next].Thread = _Nodes[i].Thread;
                    UpdateDeliveryDate(_Nodes[i].Next);
                }
                else
                {
                    _Events[_Nodes[i].Thread].Set();
                }

                Console.WriteLine(i + ";" + _Nodes[i].Thread + ":e:" + DateTime.Now.ToString("ss.fffffff"));
            }


            private int AnalyseDeliveryDateData()
            {
                IDictionary<string, int> POSet = new Dictionary<string, int>();
                int length = _Nodes.Count;
                for (int i = 0; i < length; i++)
                {
                    if (!POSet.ContainsKey(_Nodes[i].PONumber))
                    {
                        POSet.Add(_Nodes[i].PONumber, i);
                        _Nodes[i].Prev = -1;
                    }
                    else
                    {
                        _Nodes[i].Prev = POSet[_Nodes[i].PONumber];
                        POSet[_Nodes[i].PONumber] = i;
                        _Nodes[_Nodes[i].Prev].Next = i;
                    }
                }
                return POSet.Count;
            }
        }

        private int numCalls = 0;


        static Func<int, int, int> OPCreator(string symbol)
        {
            Func<int, int, int> func = (x, y) => 0;
            switch (symbol)
            {
                case "+": func = (x, y) => x + y; break;
                case "-": func = (x, y) => x - y; break;
                case "*": func = (x, y) => x * y; break;
                case "/": func = (x, y) => x / y; break;
            }

            return func;
        }

        private static void DP()
        {
            int i;
            int capacity = 16;
            int[] size = new int[] { 3, 4, 7, 8, 9 };
            // 5件物品每件大小分别为3, 4, 7, 8, 9 
            //且是不可分割的 0-1 背包问题
            int[] values = new int[] { 4, 5, 10, 11, 13 };
            // 5件物品每件的价值分别为4, 5, 10, 11, 13
            int[] totval = new int[capacity + 1];
            // 数组totval用来存贮最大的总价值
            int[] best = new int[capacity + 1];
            // best 存贮的是当前价值最高的物品
            int n = values.Length;
            for (int j = 0; j <= n - 1; j++)
                for (i = 0; i <= capacity; i++)
                    if (i >= size[j])
                        if (totval[i] < (totval[i - size[j]] + values[j]))
                        // 如果当前的容量减去J的容量再加上J的价值比原来的价值大，
                        //就将这个值传给当前的值
                        {
                            totval[i] = totval[i - size[j]] + values[j];
                            best[i] = j; // 并把j传给best
                        }
            Console.WriteLine("背包的最大价值: " + totval[capacity]);
            Console.WriteLine("构成背包的最大价值的物品是: ");
            int totcap = 0;

            while (totcap <= capacity)
            {
                Console.WriteLine("物品的大小是：" + size[best[capacity - totcap]]);
                for (i = 0; i <= n - 1; i++)
                    totcap += size[best[i]];
            }
        }

        private static int KnapSack()
        {
            int capacity = 10;
            int n = 5;
            int[] w = new int[] { 0, 2, 2, 6, 5, 4 };
            int[] v = new int[] { 0, 6, 3, 5, 4, 6 };
            int[] x = new int[n + 1];
            int[,] V = new int[n + 1, capacity + 1];
            int i, j;

            for (i = 0; i <= n; i++)
            {
                for (j = 0; j <= capacity; j++)
                {
                    V[i, j] = 0;
                }
            }

            for (i = 1; i <= n; i++)
            {
                //计算第i行，进行第i次迭代
                for (j = 1; j <= capacity; j++)
                {
                    if (j < w[i])
                        V[i, j] = V[i - 1, j];
                    else
                        V[i, j] = Max(V[i - 1, j], V[i - 1, j - w[i]] + v[i]);
                }
            }

            j = capacity;    //求装入背包的物品
            for (i = n; i > 0; i--)
            {
                if (V[i, j] > V[i - 1, j])
                {
                    x[i] = 1;
                    j = j - w[i];
                }
                else x[i] = 0;
            }

            for (i = 0; i <= n; i++)
            {

                for (j = 0; j <= capacity; j++)
                {
                    Console.Write(string.Format("{0:D2} ", V[i, j]));
                }
                Console.Write("\n");
            }
            foreach (int load in x)
            {
                Console.Write(string.Format("{0:D1} ", load));

            }
            Console.Write("\n");
            return V[n, capacity];    //返回背包取得的最大价值
        }

        private static int Max(int a, int b)
        {
            if (a > b)
                return a;
            else
                return b;

        }

        private int FastFib(int n, Dictionary<int, int> memo)
        {
            numCalls++;
            Console.WriteLine("Fib调用 {0}", n);
            if (!memo.ContainsKey(n))
            {
                memo.Add(n, FastFib(n - 1, memo) + FastFib(n - 2, memo));
            }
            return memo[n];

        }

        private int FibL(int n)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>();
            memo.Add(0, 1);
            memo.Add(1, 1);
            return FastFib(n, memo);
        }

        private int Fib(int n)
        {
            numCalls++;
            Console.WriteLine("Fib调用 {0}", n);
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return Fib(n - 1) + Fib(n - 2);
            }
        }

        static void CreateContainer()
        {
            //实例化CspParameters对象  
            CspParameters cspPara = new CspParameters();
            //指定CspParameters对象实例的名称  
            cspPara.KeyContainerName = "key_container_test";
            //设置密钥类型为Exchange  
            cspPara.KeyNumber = 1;
            cspPara.KeyNumber = (int)KeyNumber.Exchange;
            //设置密钥容器保存到计算机密钥库（默认为用户密钥库）  
            cspPara.Flags = CspProviderFlags.UseMachineKeyStore;
            //实例化RSA对象的时候，将CspParameters对象作为构造函数的参数传递给RSA对象，  
            //如果名称为key_container_test的密钥容器不存在，RSA对象会创建这个密钥容器；  
            //如果名称为key_container_test的密钥容器已经存在，RSA对象会使用这个密钥容器中的密钥进行实例化  
            RSACryptoServiceProvider rsaPro = new RSACryptoServiceProvider(cspPara);

            Console.Write(rsaPro.ToXmlString(false));
        }

        class Node
        {
            public string a;
            public string b;

        }

        private static MemoryStream CreatePDF(string sn, int type)
        {
            MemoryStream memoryStream = new MemoryStream();
            PurchaseOrder pobl = new PurchaseOrder();
            POInfo po = pobl.Read(sn);


            BaseFont BF_Light = BaseFont.CreateFont(@"C:\Windows\Fonts\simsun.ttc,0", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            FontSelector selector = Fonts(9);
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();
            document.OpenDocument();
            document.AddTitle("采购订单");
            document.AddSubject(po.Header.Number);
            document.AddAuthor("Sonluk");
            document.AddCreator("Sonluk");

            //PageNumber pageNumber = new PageNumber();
            //writer.PageEvent = pageNumber;

            float[] headerwidths = { 5, 11, 48, 5, 10, 11, 10 };
            string[] tableTitle = { "序号", "物料号码", "物料描述", "单位", "数量", "交货日期", "备注" };
            int tableWidth = 7;
            switch (type)
            {
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                        tableWidth = 10;
                        headerwidths = new float[] { 5, 11, 18, 5, 10, 11, 11, 10, 11, 8 };
                        tableTitle = new string[] { "序号", "物料号码", "物料描述", "单位", "数量", "不含税单价", "不含税金额", "税额", "交货日期", "备注" };
                        break;
                    }
                case 3:
                    {
                        tableWidth = 10;
                        headerwidths = new float[] { 5, 11, 18, 5, 10, 11, 11, 10, 11, 8 };
                        tableTitle = new string[] { "序号", "物料号码", "物料描述", "单位", "数量", "含税单价", "不含税金额", "税额", "交货日期", "备注" };
                        break;
                    }
            }

            PdfPTable header = new PdfPTable(4);
            header.DefaultCell.Border = Rectangle.NO_BORDER;
            float[] headerCellWidth = { 35, 20, 5, 30 };
            header.SetWidths(headerCellWidth);
            float headerFontSize = 10f;


            header.AddCell(new Paragraph(po.CustomText[0].Content, new Font(BF_Light, headerFontSize)));
            header.AddCell("");
            header.AddCell("");
            PdfPCell docSN = new PdfPCell(new Paragraph("编号：CG4010A", new Font(BF_Light, headerFontSize)));
            docSN.Border = Rectangle.NO_BORDER;
            docSN.HorizontalAlignment = Element.ALIGN_RIGHT;
            header.AddCell(docSN);

            Image logo = Image.GetInstance(@"logo-po.png");
            logo.ScaleAbsolute(72, 57);
            PdfPCell logoCell = new PdfPCell(logo);
            logoCell.Border = Rectangle.NO_BORDER;
            logoCell.PaddingBottom = 5;
            header.AddCell(logoCell);

            PdfPCell title = new PdfPCell(new Paragraph("采 购 订 单", new Font(BF_Light, 20, Font.BOLD)));
            title.Border = Rectangle.NO_BORDER;
            title.HorizontalAlignment = Element.ALIGN_CENTER;
            header.AddCell(title);
            header.AddCell("  ");

            PdfPTable company = new PdfPTable(1);
            company.DefaultCell.Border = Rectangle.NO_BORDER;
            company.AddCell(new Paragraph(po.Company.Name, new Font(BF_Light, headerFontSize)));
            company.AddCell(new Paragraph("中国浙江宁波市高新区星光路128号", new Font(BF_Light, headerFontSize)));
            company.AddCell(new Paragraph("联系电话:0574-87916666", new Font(BF_Light, headerFontSize)));
            company.AddCell(new Paragraph("邮政编码:" + po.Company.PostCode, new Font(BF_Light, headerFontSize)));
            PdfPCell companyCell = new PdfPCell(company);
            companyCell.Border = Rectangle.NO_BORDER;
            header.AddCell(companyCell);

            PdfPTable vendor = new PdfPTable(2);
            vendor.DefaultCell.Border = Rectangle.NO_BORDER;
            float[] vendorCellWidth = { 9, 49 };
            vendor.SetWidths(vendorCellWidth);
            vendor.AddCell(new Paragraph("订单号:", new Font(BF_Light, headerFontSize)));
            vendor.AddCell(new Paragraph(po.Header.Number, new Font(BF_Light, headerFontSize)));
            vendor.AddCell(new Paragraph("供应商:", new Font(BF_Light, headerFontSize)));
            vendor.AddCell(new Paragraph(Convert.ToInt32(po.Vendor.SerialNumber) + "/" + po.Vendor.Name, new Font(BF_Light, headerFontSize)));
            vendor.AddCell(new Paragraph("联系人:", new Font(BF_Light, headerFontSize)));
            vendor.AddCell(new Paragraph(po.Header.VendorSales, new Font(BF_Light, headerFontSize)));
            vendor.AddCell(new Paragraph("联系方式:", new Font(BF_Light, headerFontSize)));
            vendor.AddCell(new Paragraph(po.Header.VendorTelephone, new Font(BF_Light, headerFontSize)));

            if (type > 1)
            {
                vendor.AddCell(new Paragraph("订单币种:", new Font(BF_Light, headerFontSize)));
                vendor.AddCell(new Paragraph(po.Header.Currency, new Font(BF_Light, headerFontSize)));
            }
            else
            {
                vendor.AddCell(" ");
                vendor.AddCell(" ");
            }

            PdfPCell vendorCell = new PdfPCell(vendor);
            vendorCell.Border = Rectangle.NO_BORDER;
            vendorCell.Colspan = 3;
            header.AddCell(vendorCell);


            PdfPTable purchaser = new PdfPTable(2);
            purchaser.DefaultCell.Border = Rectangle.NO_BORDER;
            float[] purchaserCellWidth = { 9, 21 };
            purchaser.SetWidths(purchaserCellWidth);
            purchaser.AddCell(new Paragraph("订单日期:", new Font(BF_Light, headerFontSize)));
            purchaser.AddCell(new Paragraph(po.Header.Date, new Font(BF_Light, headerFontSize)));
            purchaser.AddCell(new Paragraph("采购员:", new Font(BF_Light, headerFontSize)));
            purchaser.AddCell(new Paragraph(po.PurGroup.Description, new Font(BF_Light, headerFontSize)));
            purchaser.AddCell(new Paragraph("联系方式:", new Font(BF_Light, headerFontSize)));
            purchaser.AddCell(new Paragraph(po.PurGroup.TelephoneDiallingCode, new Font(BF_Light, headerFontSize)));
            purchaser.AddCell(new Paragraph("交货地点:", new Font(BF_Light, headerFontSize)));
            purchaser.AddCell(new Paragraph("宁波市高新区星光路128号", new Font(BF_Light, headerFontSize)));
            purchaser.AddCell(new Paragraph("页码:", new Font(BF_Light, headerFontSize)));
            purchaser.AddCell(new Paragraph("  "));
            PdfPCell purchaserCell = new PdfPCell(purchaser);
            purchaserCell.Border = Rectangle.NO_BORDER;
            header.AddCell(purchaserCell);


            PdfPCell headerCell = new PdfPCell(header);
            headerCell.Border = Rectangle.NO_BORDER;
            headerCell.Colspan = tableWidth;


            PdfPTable aTable = new PdfPTable(tableWidth);

            aTable.SetWidths(headerwidths);
            aTable.WidthPercentage = 100;

            aTable.HeaderRows = 2;
            aTable.AddCell(headerCell);




            for (int i = 0; i < tableTitle.Length; i++)
            {
                Paragraph p = new Paragraph(tableTitle[i], new Font(BF_Light, 10, Font.BOLD));
                PdfPCell cell = new PdfPCell(p);

                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                aTable.AddCell(cell);
            }

            for (int i = 0; i < po.Items.Count; i++)
            {
                PdfPCell indexCell = new PdfPCell(new Paragraph(po.Items[i].Number.ToString(), new Font(BF_Light, 10)));
                indexCell.HorizontalAlignment = Element.ALIGN_CENTER;
                aTable.AddCell(indexCell);
                PdfPCell materiaCell = new PdfPCell(new Paragraph(Convert.ToInt64(po.Items[i].Material).ToString(), new Font(BF_Light, 10)));
                materiaCell.HorizontalAlignment = Element.ALIGN_CENTER;
                aTable.AddCell(materiaCell);
                aTable.AddCell(new Paragraph(po.Items[i].MaterialDescription, new Font(BF_Light, 10)));
                PdfPCell unitCell = new PdfPCell(new Paragraph(po.Items[i].BaseUOM, new Font(BF_Light, 10)));
                unitCell.HorizontalAlignment = Element.ALIGN_CENTER;
                aTable.AddCell(unitCell);
                PdfPCell qtyCell = new PdfPCell(new Paragraph(po.Items[i].Quantity.ToString("###,###,###,##0.###"), new Font(BF_Light, 10)));
                qtyCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                aTable.AddCell(qtyCell);

                if (type > 1)
                {
                    if (type == 2)
                    {
                        PdfPCell unitPriceCell = new PdfPCell(new Paragraph(po.Items[i].UnitPrice.ToString("###,###,###,##0.000000"), new Font(BF_Light, 10)));
                        unitPriceCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        aTable.AddCell(unitPriceCell);
                    }
                    else
                    {
                        PdfPCell unitPriceWidthTaxCell = new PdfPCell(new Paragraph(po.Items[i].UnitPriceWidthTax.ToString("###,###,###,##0.000000"), new Font(BF_Light, 10)));
                        unitPriceWidthTaxCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        aTable.AddCell(unitPriceWidthTaxCell);
                    }
                    PdfPCell netValueCell = new PdfPCell(new Paragraph(po.Items[i].NetValue.ToString("###,###,###,##0.00"), new Font(BF_Light, 10)));
                    netValueCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    aTable.AddCell(netValueCell);
                    PdfPCell taxCell = new PdfPCell(new Paragraph(po.Items[i].Tax.ToString("###,###,###,##0.00"), new Font(BF_Light, 10)));
                    taxCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    aTable.AddCell(taxCell);
                }
                PdfPCell dateCell = new PdfPCell(new Paragraph(po.Items[i].Schedule[0].Date, new Font(BF_Light, 10)));
                dateCell.HorizontalAlignment = Element.ALIGN_CENTER;
                aTable.AddCell(dateCell);
                aTable.AddCell(new Paragraph(po.Items[i].Remarks, new Font(BF_Light, 10)));


                PdfPTable textTable = new PdfPTable(1);
                textTable.DefaultCell.Border = Rectangle.NO_BORDER;
                string so = "";
                if (po.Items[i].SDocItem != 0)
                    so = Convert.ToInt64(po.Items[i].SDDoc) + "/" + po.Items[i].SDocItem;
                textTable.AddCell(new Paragraph("作业单：" + so + "   要求：", new Font(BF_Light, 10)));
                string prevSDTextID = "";
                foreach (CustomTextInfo text in po.Items[i].SDCustomText)
                {
                    if (text.Content.Length > 0)
                    {
                        if (!prevSDTextID.Equals(text.ID))
                        {
                            prevSDTextID = text.ID;
                            textTable.AddCell(new Paragraph("【" + text.Title + "】", new Font(BF_Light, 10)));

                        }
                        textTable.AddCell(new Paragraph(text.Content, new Font(BF_Light, 10)));

                    }
                }
                foreach (CustomTextInfo text in po.Items[i].CustomText)
                {
                    if (text.Content.Length > 0)
                    {
                        textTable.AddCell(new Paragraph(text.Content, new Font(BF_Light, 10)));
                    }
                }
                textTable.AddCell(" ");
                PdfPCell textCell = new PdfPCell(textTable);
                textCell.Colspan = tableWidth;
                aTable.AddCell(textCell);

            }


            if (type > 1)
            {
                PdfPTable sumPriceTable = new PdfPTable(2);
                float[] sumPriceTableCellWidth = { 17, 83 };
                sumPriceTable.SetWidths(sumPriceTableCellWidth);
                sumPriceTable.AddCell(new Paragraph("不含税金额合计：", new Font(BF_Light, 10)));
                PdfPCell amountWithoutTaxCell = new PdfPCell(new Paragraph(po.Header.AmountWithoutTax.ToString("###,###,###,##0.00"), new Font(BF_Light, 10)));
                amountWithoutTaxCell.HorizontalAlignment = Element.ALIGN_CENTER;
                sumPriceTable.AddCell(amountWithoutTaxCell);
                sumPriceTable.AddCell(new Paragraph("税额合计：", new Font(BF_Light, 10)));
                PdfPCell taxCell = new PdfPCell(new Paragraph(po.Header.Tax.ToString("###,###,###,##0.00"), new Font(BF_Light, 10)));
                taxCell.HorizontalAlignment = Element.ALIGN_CENTER;
                sumPriceTable.AddCell(taxCell);
                sumPriceTable.AddCell(new Paragraph("总计：", new Font(BF_Light, 10)));
                PdfPCell amountCell = new PdfPCell(new Paragraph(po.Header.Amount.ToString("###,###,###,##0.00"), new Font(BF_Light, 10)));
                amountCell.HorizontalAlignment = Element.ALIGN_CENTER;
                sumPriceTable.AddCell(amountCell);

                PdfPCell sumPriceCell = new PdfPCell(sumPriceTable);
                sumPriceCell.Colspan = tableWidth;
                aTable.AddCell(sumPriceCell);

            }






            PdfPTable remarkTable = new PdfPTable(1);
            remarkTable.DefaultCell.Border = Rectangle.NO_BORDER;
            remarkTable.AddCell(" ");
            remarkTable.AddCell(new Paragraph("1.以上订单内容参照相关合同或协议执行；", new Font(BF_Light, 9)));
            remarkTable.AddCell(new Paragraph("2.请按交货日期及时交货，若无法及时交货请提前与本公司取得联系，否则造成损失由供方承担；", new Font(BF_Light, 9)));
            remarkTable.AddCell(new Paragraph("3.交货检验时须提供交货单，交货单信息满足本公司需求，如质量检验不合格则拒收；", new Font(BF_Light, 9)));
            remarkTable.AddCell(new Paragraph("4.备注：" + po.CustomText[0].Content, new Font(BF_Light, 9)));
            remarkTable.AddCell(" ");
            remarkTable.AddCell(new Paragraph("供应商收到订单后请确认签字并回传，谢谢！", new Font(BF_Light, 9)));
            remarkTable.AddCell(" ");

            PdfPCell footerCell = new PdfPCell(remarkTable);
            footerCell.Colspan = tableWidth;
            aTable.AddCell(footerCell);





            PdfPTable signTable = new PdfPTable(4);
            signTable.DefaultCell.Border = Rectangle.NO_BORDER;
            signTable.DefaultCell.PaddingTop = 15;
            signTable.DefaultCell.PaddingBottom = 15;
            float[] signCellWidth = { 15, 35, 15, 35 };

            signTable.SetWidths(signCellWidth);
            signTable.AddCell(new Paragraph("采购工程师：", new Font(BF_Light, 10)));
            signTable.AddCell(" ");
            signTable.AddCell(new Paragraph("供应商确认：", new Font(BF_Light, 10)));
            signTable.AddCell(" ");
            signTable.AddCell(new Paragraph("订单确认日期：", new Font(BF_Light, 10)));
            signTable.AddCell(" ");
            signTable.AddCell(new Paragraph("确认日期：", new Font(BF_Light, 10)));
            signTable.AddCell(" ");

            PdfPCell signCellCell = new PdfPCell(signTable);
            signCellCell.Colspan = tableWidth;
            signCellCell.Border = Rectangle.NO_BORDER;
            aTable.AddCell(signCellCell);


            //for (int i = 0; i < 1000; i++)
            //{
            //    aTable.AddCell(i.ToString());
            //    aTable.AddCell("200005819");
            //    aTable.AddCell("200005819");
            //    aTable.AddCell("200005819");
            //    aTable.AddCell("200005819");
            //    aTable.AddCell("200005819");
            //    aTable.AddCell("200005819");

            //}

            document.Add(aTable);






            //HeaderFooter footer = new HeaderFooter(new Phrase("This is page: "), true); 
            //footer.Border = Rectangle.NO_BORDER; 
            //document.Footer = footer;


            document.Close();


            //Phrase ph = selector.Process(TEXT);
            //document.add(new Paragraph(ph));




            return memoryStream;

        }

        private static FontSelector Fonts(int fontSize)
        {
            string fontsFilePath = @"C:\Windows\Fonts\";
            string[] fonts = (AppConfig.Settings("Fonts")).Split(';');

            FontSelector selector = new FontSelector();
            selector.AddFont(FontFactory.GetFont(FontFactory.TIMES_ROMAN, fontSize));
            foreach (string font in fonts)
            {
                BaseFont baseFont = BaseFont.CreateFont(fontsFilePath + font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                selector.AddFont(new Font(baseFont, fontSize));
            }
            return selector;
        }

        private static IList<Language> Unicode()
        {
            IList<Language> languages = new List<Language>();
            languages.Add(new Language(@"\u0000-\u007F", "C0控制符及基本拉丁文"));
            languages.Add(new Language(@"\u0080-\u00FF", "C1控制符及拉丁文补充"));
            languages.Add(new Language(@"\u0100-\u017F", "拉丁文扩展-A"));
            languages.Add(new Language(@"\u0180-\u024F", "拉丁文扩展-B"));
            languages.Add(new Language(@"\u0250-\u02AF", "国际音标扩展"));
            languages.Add(new Language(@"\u02B0-\u02FF", "空白修饰字母"));
            languages.Add(new Language(@"\u0300-\u036F", "结合用读音符号"));
            languages.Add(new Language(@"\u0370-\u03FF", "希腊文及科普特文"));
            languages.Add(new Language(@"\u0400-\u04FF", "西里尔字母"));
            languages.Add(new Language(@"\u0500-\u052F", "西里尔字母补充"));
            languages.Add(new Language(@"\u0530-\u058F", "亚美尼亚语"));
            languages.Add(new Language(@"\u0590-\u05FF", "希伯来文"));
            languages.Add(new Language(@"\u0600-\u06FF", "阿拉伯文"));
            languages.Add(new Language(@"\u0700-\u074F", "叙利亚文"));
            languages.Add(new Language(@"\u0750-\u077F", "阿拉伯文补充"));
            languages.Add(new Language(@"\u0780-\u07BF", "马尔代夫语"));
            languages.Add(new Language(@"\u07C0-\u07FF", "西非書面語言"));
            languages.Add(new Language(@"\u0800-\u085F", "阿维斯塔语及巴列维语"));
            languages.Add(new Language(@"\u0860-\u087F", "Mandaic	Mandaic"));
            languages.Add(new Language(@"\u0880-\u08AF", "撒马利亚语"));
            languages.Add(new Language(@"\u0900-\u097F", "天城文书"));
            languages.Add(new Language(@"\u0980-\u09FF", "孟加拉语"));
            languages.Add(new Language(@"\u0A00-\u0A7F", "锡克教文"));
            languages.Add(new Language(@"\u0A80-\u0AFF", "古吉拉特文"));
            languages.Add(new Language(@"\u0B00-\u0B7F", "奥里亚文"));
            languages.Add(new Language(@"\u0B80-\u0BFF", "泰米尔文"));
            languages.Add(new Language(@"\u0C00-\u0C7F", "泰卢固文"));
            languages.Add(new Language(@"\u0C80-\u0CFF", "卡纳达文"));
            languages.Add(new Language(@"\u0D00-\u0D7F", "德拉维族语"));
            languages.Add(new Language(@"\u0D80-\u0DFF", "僧伽罗语"));
            languages.Add(new Language(@"\u0E00-\u0E7F", "泰文"));
            languages.Add(new Language(@"\u0E80-\u0EFF", "老挝文"));
            languages.Add(new Language(@"\u0F00-\u0FFF", "藏文"));
            languages.Add(new Language(@"\u1000-\u109F", "缅甸语"));
            languages.Add(new Language(@"\u10A0-\u10FF", "格鲁吉亚语"));
            languages.Add(new Language(@"\u1100-\u11FF", "朝鲜文"));
            languages.Add(new Language(@"\u1200-\u137F", "埃塞俄比亚语"));
            languages.Add(new Language(@"\u1380-\u139F", "埃塞俄比亚语补充"));
            languages.Add(new Language(@"\u13A0-\u13FF", "切罗基语"));
            languages.Add(new Language(@"\u1400-\u167F", "统一加拿大土著语音节"));
            languages.Add(new Language(@"\u1680-\u169F", "欧甘字母"));
            languages.Add(new Language(@"\u16A0-\u16FF", "如尼文"));
            languages.Add(new Language(@"\u1700-\u171F", "塔加拉语"));
            languages.Add(new Language(@"\u1720-\u173F", "Hanunóo"));
            languages.Add(new Language(@"\u1740-\u175F", "Buhid"));
            languages.Add(new Language(@"\u1760-\u177F", "Tagbanwa"));
            languages.Add(new Language(@"\u1780-\u17FF", "高棉语"));
            languages.Add(new Language(@"\u1800-\u18AF", "蒙古文"));
            languages.Add(new Language(@"\u18B0-\u18FF", "Cham"));
            languages.Add(new Language(@"\u1900-\u194F", "Limbu"));
            languages.Add(new Language(@"\u1950-\u197F", "德宏泰语"));
            languages.Add(new Language(@"\u1980-\u19DF", "新傣仂语"));
            languages.Add(new Language(@"\u19E0-\u19FF", "高棉语记号"));
            languages.Add(new Language(@"\u1A00-\u1A1F", "Buginese"));
            languages.Add(new Language(@"\u1A20-\u1A5F", "Batak"));
            languages.Add(new Language(@"\u1A80-\u1AEF", "Lanna"));
            languages.Add(new Language(@"\u1B00-\u1B7F", "巴厘语"));
            languages.Add(new Language(@"\u1B80-\u1BB0", "巽他语"));
            languages.Add(new Language(@"\u1BC0-\u1BFF", "Pahawh Hmong"));
            languages.Add(new Language(@"\u1C00-\u1C4F", "雷布查语"));
            languages.Add(new Language(@"\u1C50-\u1C7F", "Ol Chiki"));
            languages.Add(new Language(@"\u1C80-\u1CDF", "曼尼普尔语"));
            languages.Add(new Language(@"\u1D00-\u1D7F", "语音学扩展"));
            languages.Add(new Language(@"\u1D80-\u1DBF", "语音学扩展补充"));
            languages.Add(new Language(@"\u1DC0-\u1DFF", "结合用读音符号补充"));
            languages.Add(new Language(@"\u1E00-\u1EFF", "拉丁文扩充附加"));
            languages.Add(new Language(@"\u1F00-\u1FFF", "希腊语扩充"));
            languages.Add(new Language(@"\u2000-\u206F", "常用标点"));
            languages.Add(new Language(@"\u2070-\u209F", "上标及下标"));
            languages.Add(new Language(@"\u20A0-\u20CF", "货币符号"));
            languages.Add(new Language(@"\u20D0-\u20FF", "组合用记号"));
            languages.Add(new Language(@"\u2100-\u214F", "字母式符号"));
            languages.Add(new Language(@"\u2150-\u218F", "数字形式"));
            languages.Add(new Language(@"\u2190-\u21FF", "箭头"));
            languages.Add(new Language(@"\u2200-\u22FF", "数学运算符"));
            languages.Add(new Language(@"\u2300-\u23FF", "杂项工业符号"));
            languages.Add(new Language(@"\u2400-\u243F", "控制图片"));
            languages.Add(new Language(@"\u2440-\u245F", "光学识别符"));
            languages.Add(new Language(@"\u2460-\u24FF", "封闭式字母数字"));
            languages.Add(new Language(@"\u2500-\u257F", "制表符"));
            languages.Add(new Language(@"\u2580-\u259F", "方块元素"));
            languages.Add(new Language(@"\u25A0-\u25FF", "几何图形"));
            languages.Add(new Language(@"\u2600-\u26FF", "杂项符号"));
            languages.Add(new Language(@"\u2700-\u27BF", "印刷符号"));
            languages.Add(new Language(@"\u27C0-\u27EF", "杂项数学符号-A"));
            languages.Add(new Language(@"\u27F0-\u27FF", "追加箭头-A"));
            languages.Add(new Language(@"\u2800-\u28FF", "盲文点字模型"));
            languages.Add(new Language(@"\u2900-\u297F", "追加箭头-B"));
            languages.Add(new Language(@"\u2980-\u29FF", "杂项数学符号-B"));
            languages.Add(new Language(@"\u2A00-\u2AFF", "追加数学运算符"));
            languages.Add(new Language(@"\u2B00-\u2BFF", "杂项符号和箭头"));
            languages.Add(new Language(@"\u2C00-\u2C5F", "格拉哥里字母"));
            languages.Add(new Language(@"\u2C60-\u2C7F", "拉丁文扩展-C"));
            languages.Add(new Language(@"\u2C80-\u2CFF", "古埃及语"));
            languages.Add(new Language(@"\u2D00-\u2D2F", "格鲁吉亚语补充"));
            languages.Add(new Language(@"\u2D30-\u2D7F", "提非纳文"));
            languages.Add(new Language(@"\u2D80-\u2DDF", "埃塞俄比亚语扩展"));
            languages.Add(new Language(@"\u2E00-\u2E7F", "追加标点"));
            languages.Add(new Language(@"\u2E80-\u2EFF", "CJK 部首补充"));
            languages.Add(new Language(@"\u2F00-\u2FDF", "康熙字典部首"));
            languages.Add(new Language(@"\u2FF0-\u2FFF", "表意文字描述符"));
            languages.Add(new Language(@"\u3000-\u303F", "CJK 符号和标点"));
            languages.Add(new Language(@"\u3040-\u309F", "日文平假名"));
            languages.Add(new Language(@"\u30A0-\u30FF", "日文片假名"));
            languages.Add(new Language(@"\u3100-\u312F", "注音字母"));
            languages.Add(new Language(@"\u3130-\u318F", "朝鲜文兼容字母"));
            languages.Add(new Language(@"\u3190-\u319F", "象形字注释标志"));
            languages.Add(new Language(@"\u31A0-\u31BF", "注音字母扩展"));
            languages.Add(new Language(@"\u31C0-\u31EF", "CJK 笔画"));
            languages.Add(new Language(@"\u31F0-\u31FF", "日文片假名语音扩展"));
            languages.Add(new Language(@"\u3200-\u32FF", "封闭式 CJK 文字和月份"));
            languages.Add(new Language(@"\u3300-\u33FF", "CJK 兼容"));
            languages.Add(new Language(@"\u3400-\u4DBF", "CJK 统一表意符号扩展 A"));
            languages.Add(new Language(@"\u4DC0-\u4DFF", "易经六十四卦符号"));
            languages.Add(new Language(@"\u4E00-\u9FBF", "CJK 统一表意符号"));
            languages.Add(new Language(@"\uA000-\uA48F", "彝文音节"));
            languages.Add(new Language(@"\uA490-\uA4CF", "彝文字根"));
            languages.Add(new Language(@"\uA500-\uA61F", "Vai"));
            languages.Add(new Language(@"\uA660-\uA6FF", "统一加拿大土著语音节补充"));
            languages.Add(new Language(@"\uA700-\uA71F", "声调修饰字母"));
            languages.Add(new Language(@"\uA720-\uA7FF", "拉丁文扩展-D"));
            languages.Add(new Language(@"\uA800-\uA82F", "Syloti Nagri"));
            languages.Add(new Language(@"\uA840-\uA87F", "八思巴字"));
            languages.Add(new Language(@"\uA880-\uA8DF", "Saurashtra"));
            languages.Add(new Language(@"\uA900-\uA97F", "爪哇语"));
            languages.Add(new Language(@"\uA980-\uA9DF", "Chakma"));
            languages.Add(new Language(@"\uAA00-\uAA3F", "Varang Kshiti"));
            languages.Add(new Language(@"\uAA40-\uAA6F", "Sorang Sompeng"));
            languages.Add(new Language(@"\uAA80-\uAADF", "Newari"));
            languages.Add(new Language(@"\uAB00-\uAB5F", "越南傣语"));
            languages.Add(new Language(@"\uAB80-\uABA0", "Kayah Li"));
            languages.Add(new Language(@"\uAC00-\uD7AF", "朝鲜文音节"));
            languages.Add(new Language(@"\uD800-\uDBFF", "High-half zone of UTF-16"));
            languages.Add(new Language(@"\uDC00-\uDFFF", "Low-half zone of UTF-16"));
            languages.Add(new Language(@"\uE000-\uF8FF", "自行使用區域"));
            languages.Add(new Language(@"\uF900-\uFAFF", "CJK 兼容象形文字"));
            languages.Add(new Language(@"\uFB00-\uFB4F", "字母表達形式"));
            languages.Add(new Language(@"\uFB50-\uFDFF", "阿拉伯表達形式A"));
            languages.Add(new Language(@"\uFE00-\uFE0F", "变量选择符"));
            languages.Add(new Language(@"\uFE10-\uFE1F", "竖排形式"));
            languages.Add(new Language(@"\uFE20-\uFE2F", "组合用半符号"));
            languages.Add(new Language(@"\uFE30-\uFE4F", "CJK 兼容形式"));
            languages.Add(new Language(@"\uFE50-\uFE6F", "小型变体形式"));
            languages.Add(new Language(@"\uFE70-\uFEFF", "阿拉伯表達形式B"));
            languages.Add(new Language(@"\uFF00-\uFFEF", "半型及全型形式"));
            languages.Add(new Language(@"\uFFF0-\uFFFF", "特殊"));
            return languages;
        }

        private static string AnalyseLanguage(IList<Language> languages, string content)
        {
            foreach (Match mch in Regex.Matches(content, "[^\u4e00-\u9fa50-9a-bA-B]+"))
            {
                string x = mch.Value.Trim();
                Console.WriteLine("2" + x);
            }

            string languageCategory = "";
            foreach (Language language in languages)
            {
                if (Regex.IsMatch(content, @"^[" + language.Unicode + "]+$"))
                {
                    languageCategory = language.Name;
                    break;
                }
            }
            return languageCategory;


        }
    }

    public class Language
    {
        private string _Name;
        private string _Unicode;

        public Language(string unicode, string name)
        {
            _Name = name;
            _Unicode = unicode;
        }

        public string Unicode
        {
            get { return _Unicode; }
            set { _Unicode = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }

    public class APIResult
    {
        public int errNum;
        public string errMsg;
        //public List<City> retData;

    }

    //public class City
    //{
    //    public string province_cn;
    //    public string district_cn;
    //    public string name_cn;
    //    public string name_en;
    //    public string area_id;

    //}
}
