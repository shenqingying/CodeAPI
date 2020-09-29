using Sonluk.BusinessLogic.QM;
using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.Entities.OA;
using Sonluk.Entities.PP;
using Sonluk.Entities.QM;
using Sonluk.Entities.System;
using Sonluk.IDataAccess.OA;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sonluk.BusinessLogic.OA
{
    public class Flow
    {
        private static readonly IFlow _DetaAccess = OADataAccess.CreateFlow();
        private static readonly FlowLock _Pull = new FlowLock(0);
        private static readonly FlowLock _Push = new FlowLock(0);


        public bool Pull()
        {

            Logger.Write("BusinessLogic.OA.Flow.Pull", "Init");
            bool success = false;
            if (LockPull())
            {
                try
                {
                    string z2 = "-9024522862981855135";
                    string z3 = "-642120897417951426";
                    PullZ2(z2);
                    PullZ3(z3);
                    success = true;
                }
                catch (Exception e)
                {
                    Logger.Write("BusinessLogic.OA.Flow.Pull", e.Message);
                    Message messageBL = new Message();
                    messageBL.Send("[SAP][OA]触发流程异常：" + e.Message);
                }
                UnlockPull();
                Logger.Write("BusinessLogic.OA.Flow.Pull", "Finish");
            }
            else
            {
                Message messageBL = new Message();
                messageBL.Send("[SAP][OA]触发流程异常：阻塞");
                Logger.Write("BusinessLogic.OA.Flow.Pull", "Block");
            }
            return success;
        }

        private void PullZ2(string template)
        {
            QualityNotification qnbl = new QualityNotification();
            IList<QNInfo> nodeZ2 = qnbl.Read("Z2");
            foreach (QNInfo node in nodeZ2)
            {
                Console.WriteLine(node.SerialNumber);
                string xml = "";
                xml = xml + @"<formExport version=""2.0"">";
                xml = xml + @"<summary id="""" name=""formmain_0106""/>";
                xml = xml + @"<definitions>";
                xml = xml + @"<column id=""field0082"" type=""0"" name=""质量通知单编号-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0076"" type=""0"" name=""品号-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0071"" type=""0"" name=""不合格批数量-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0083"" type=""0"" name=""品名-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0080"" type=""0"" name=""设备号-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0081"" type=""0"" name=""不合格数量-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0078"" type=""0"" name=""供应商-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0074"" type=""0"" name=""抽样数量-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0069"" type=""0"" name=""批号-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0077"" type=""3"" name=""发现时间-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0073"" type=""0"" name=""不合格描述-映射"" length=""4000""/>";
                xml = xml + @"<column id=""field0019"" type=""0"" name=""填写人"" length=""255""/>";
                xml = xml + @"<column id=""field0064"" type=""0"" name=""单位"" length=""255""/>";
                xml = xml + @"</definitions>";
                xml = xml + @"<values>";
                xml = xml + @"<column name=""质量通知单编号-映射"">";
                xml = xml + @"<value><![CDATA[" + node.SerialNumber + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""品号-映射"">";
                xml = xml + @"<value><![CDATA[" + node.Material + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""不合格批数量-映射"">";
                xml = xml + @"<value><![CDATA[" + node.Quantity + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""品名-映射"">";
                xml = xml + @"<value><![CDATA[" + node.MaterialDescription + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""设备号-映射"">";
                xml = xml + @"<value><![CDATA[" + node.VendorDevice + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""不合格数量-映射"">";
                xml = xml + @"<value><![CDATA[" + node.DisqualifiedQty + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""供应商-映射"">";
                xml = xml + @"<value><![CDATA[" + node.Vendor + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""抽样数量-映射"">";
                xml = xml + @"<value><![CDATA[" + node.Sampling + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""批号-映射"">";
                xml = xml + @"<value><![CDATA[" + node.Batch + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""发现时间-映射"">";
                if (node.Date.Equals("") || node.Date.Equals("0000-00-00"))
                    xml = xml + @"<value/>";
                else
                    xml = xml + @"<value><![CDATA[" + node.Date + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""不合格描述-映射"">";
                xml = xml + @"<value><![CDATA[" + node.Disqualification + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""填写人"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""单位"">";
                xml = xml + @"<value><![CDATA[" + node.Unit + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</values>";
                xml = xml + @"<subForms>";
                xml = xml + @"<subForm>";
                xml = xml + @"<definitions>";
                xml = xml + @"<column id=""field0075"" type=""0"" name=""缺陷类型-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0072"" type=""0"" name=""缺陷-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0079"" type=""0"" name=""缺陷数量-映射"" length=""255""/>";
                xml = xml + @"</definitions>";
                xml = xml + @"<values>";

                foreach (QNItemInfo item in node.Items)
                {
                    xml = xml + @"<row>";
                    xml = xml + @"<column name=""缺陷类型-映射"">";
                    xml = xml + @"<value><![CDATA[" + item.DefectType + "]]></value>";
                    xml = xml + @"</column>";
                    xml = xml + @"<column name=""缺陷-映射"">";
                    xml = xml + @"<value><![CDATA[" + item.DefectReason + "]]></value>";
                    xml = xml + @"</column>";
                    xml = xml + @"<column name=""缺陷数量-映射"">";
                    xml = xml + @"<value><![CDATA[" + item.DefectQty + "]]></value>";
                    xml = xml + @"</column>";
                    xml = xml + @"</row>";
                }

                xml = xml + @"</values>";
                xml = xml + @"</subForm>";
                xml = xml + @"</subForms>";
                xml = xml + @"</formExport>";
                BPM bpm = new BPM();
                long[] att = new long[3];
                MessageInfo message = bpm.Launch(node.Creator, "589", "QM002-进货不合格发生处理和评审单", xml, att, "1", "");
                Console.WriteLine(message.Key);
                Logger.Write("BusinessLogic.OA.Flow.PullZ2", node.SerialNumber + ";" + node.Creator);
                Message messageBL = new Message();
                if (message.Key.Length > 10)
                {
                    MessageInfo updateMessage = qnbl.Update(node.SerialNumber, node.Creator);
                    if (updateMessage.Status < 2)
                        messageBL.Send("[SAP]无法将质量通知单" + node.SerialNumber + "状态更改为已传输！");

                    message.Value = message.Value + "已发起流程";
                }
                else
                {
                    messageBL.Send("[OA]质量通知单" + node.SerialNumber + "无法触发QM002流程！" + message.Value);
                }

                FlowLogInfo log = new FlowLogInfo();
                log.ID = message.Key;
                log.QualityNotification = node.SerialNumber;
                log.TemplateID = template;
                log.Type = "Pull";
                log.Status = -1;
                log.Remark = message.Value;
                SyncLog(log);
            }
        }

        private void PullZ3(string template)
        {
            QualityNotification qnbl = new QualityNotification();
            IList<QNInfo> nodeZ3 = qnbl.Read("Z3");
            foreach (QNInfo node in nodeZ3)
            {
                Console.WriteLine(node.SerialNumber);
                string xml = "";
                xml = xml + @"<formExport version=""2.0"">";
                xml = xml + @"<summary id="""" name=""formmain_0393""/>";
                xml = xml + @"<definitions>";
                xml = xml + @"<column id=""field0079"" type=""0"" name=""质量通知单编号-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0076"" type=""0"" name=""品号-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0083"" type=""0"" name=""品名-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0077"" type=""0"" name=""供应商-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0074"" type=""0"" name=""设备-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0075"" type=""3"" name=""发现时间-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0080"" type=""3"" name=""素电池日期起-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0082"" type=""3"" name=""素电池日期止-映射"" length=""255""/>";
                xml = xml + @"<column id=""field0018"" type=""0"" name=""缺陷类型"" length=""255""/>";
                xml = xml + @"<column id=""field0024"" type=""0"" name=""填写人"" length=""255""/>";
                xml = xml + @"<column id=""field0036"" type=""0"" name=""单位"" length=""255""/>";
                xml = xml + @"</definitions>";
                xml = xml + @"<values>";
                xml = xml + @"<column name=""质量通知单编号-映射"">";
                xml = xml + @"<value><![CDATA[" + node.SerialNumber + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""品号-映射"">";
                xml = xml + @"<value><![CDATA[" + node.Material + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""品名-映射"">";
                xml = xml + @"<value><![CDATA[" + node.MaterialDescription + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""供应商-映射"">";
                xml = xml + @"<value><![CDATA[" + node.Vendor + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""设备-映射"">";
                xml = xml + @"<value><![CDATA[" + node.VendorDevice + "]]></value>"; ;
                xml = xml + @"</column>";
                xml = xml + @"<column name=""发现时间-映射"">";
                if (node.Date.Equals("") || node.Date.Equals("0000-00-00"))
                    xml = xml + @"<value/>";
                else
                    xml = xml + @"<value><![CDATA[" + node.Date + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""素电池日期起-映射"">";
                if (node.SemiFinishedStartingDate.Equals("") || node.SemiFinishedStartingDate.Equals("0000-00-00"))
                    xml = xml + @"<value/>";
                else
                    xml = xml + @"<value><![CDATA[" + node.SemiFinishedStartingDate + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""素电池日期止-映射"">";
                if (node.SemiFinishedEndDate.Equals("") || node.SemiFinishedEndDate.Equals("0000-00-00"))
                    xml = xml + @"<value/>";
                else
                    xml = xml + @"<value><![CDATA[" + node.SemiFinishedEndDate + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""缺陷类型"">";
                xml = xml + @"<value><![CDATA[" + node.DefectType + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""填写人"">";
                xml = xml + @"<value/>";
                xml = xml + @"</column>";
                xml = xml + @"<column name=""单位"">";
                xml = xml + @"<value><![CDATA[" + node.Unit + "]]></value>";
                xml = xml + @"</column>";
                xml = xml + @"</values>";
                xml = xml + @"</formExport>";
                BPM bpm = new BPM();
                long[] att = new long[3];
                MessageInfo message = bpm.Launch(node.Creator, "11", "QM001-过程及出货检验不合格发生处理和评审单", xml, att, "1", "");
                Console.WriteLine(message.Key);

                Message messageBL = new Message();
                if (message.Key.Length > 10)
                {
                    MessageInfo updateMessage = qnbl.Update(node.SerialNumber, node.Creator);
                    if (updateMessage.Status < 2)
                        messageBL.Send("[SAP]无法将质量通知单" + node.SerialNumber + "状态更改为已传输！");

                    message.Value = message.Value + "已发起流程";
                }
                else
                {
                    messageBL.Send("[OA]质量通知单" + node.SerialNumber + "无法触发QM001流程！" + message.Value);
                }

                FlowLogInfo log = new FlowLogInfo();
                log.ID = message.Key;
                log.QualityNotification = node.SerialNumber;
                log.TemplateID = template;
                log.Status = -1;
                log.Type = "Pull";
                log.Remark = message.Value;
                SyncLog(log);

            }

        }

        public bool Push()
        {
            Logger.Write("BusinessLogic.OA.Flow.Push", "Init");
            bool success = false;
            if (LockPush())
            {
                try
                {
                    string q1 = "4321618695115786394";
                    string z2 = "-9024522862981855135";
                    string z3 = "-642120897417951426";
                    PushQ1(q1);
                    PushZ2(z2);
                    PushZ3(z3);
                    success = true;
                }
                catch (Exception e)
                {
                    Logger.Write("BusinessLogic.OA.Flow.Push", e.Message);
                    Message messageBL = new Message();
                    messageBL.Send("[OA][SAP]推送通知单异常：" + e.Message);
                }
                UnlockPush();
                Logger.Write("BusinessLogic.OA.Flow.Push", "Finish");
            }
            else
            {
                Message messageBL = new Message();
                messageBL.Send("[OA][SAP]推送通知单异常：阻塞");
                Logger.Write("BusinessLogic.OA.Flow.Push", "Block");
            }
            return success;
        }

        private void PushQ1(string template)
        {
            //投诉Q1
            QualityNotification qnbl = new QualityNotification();
            IList<FlowInfo> nodes = Read(template, 3);
            foreach (FlowInfo node in nodes)
            {
                try
                {
                    QNInfo qn = ReadQ1(node.ID);
                    qn.Type = "Q1";
                    MessageInfo message = qnbl.Create(qn);
                    message.Key = Regex.Replace(message.Key, @"^[0]*", "");

                    if (message.Status == 2)
                    {
                        //messageBL.Send(qn.CreatorCode, "[SAP]已将投诉" + qn.SerialNumber + "创建为通知单" + message.Key + "！");
                        UpdateQ1(node.ID, message.Key);
                    }
                    else
                    {
                        Message messageBL = new Message();
                        //messageBL.Send(qn.CreatorCode, "[SAP]无法将投诉" + qn.SerialNumber + "创建为通知单！" + message.Value);
                        messageBL.Send("[SAP]无法根据流程" + qn.FlowSerialNumber + "创建质量通知单！" + message.Value);
                    }

                    FlowLogInfo log = new FlowLogInfo();
                    log.ID = node.ID;
                    log.QualityNotification = message.Key;
                    log.TemplateID = template;
                    log.Status = message.Status;
                    log.SerialNumber = qn.FlowSerialNumber;
                    log.Type = "Push";
                    log.Remark = message.Value;
                    SyncLog(log);
                }
                catch (Exception e)
                {
                    Logger.Write("BusinessLogic.OA.Flow.PushQ1", e.Message);
                    Message messageBL = new Message();
                    messageBL.Send("[OA][SAP]推送Q1通知单异常：" + e.Message);
                }
            }
        }

        private void PushZ2(string template)
        {
            //进货Z2
            QualityNotification qnbl = new QualityNotification();
            IList<FlowInfo> nodes = Read(template, 3);
            foreach (FlowInfo node in nodes)
            {
                try
                {
                    QNInfo qn = ReadZ2(node.ID);
                    qn.Type = "Z2";
                    MessageInfo message = qnbl.Update(qn);


                    if (message.Status == 2)
                    {
                        //messageBL.Send(qn.CreatorCode, "[SAP]已更新质量通知单" + qn.SerialNumber + "！" + message.Value);
                    }
                    else
                    {
                        Message messageBL = new Message();
                        messageBL.Send("[SAP]无法根据流程" + qn.FlowSerialNumber + "更新质量通知单" + qn.SerialNumber + "！" + message.Value);
                        //messageBL.Send(qn.CreatorCode, "[SAP]无法将流程"+qn.FlowSerialNumber+"更新质量通知单" + qn.SerialNumber + "！" + message.Value);
                        if (qn.SerialNumber.Equals(""))
                            qn.SerialNumber = "0";
                    }

                    FlowLogInfo log = new FlowLogInfo();
                    log.ID = node.ID;
                    log.QualityNotification = qn.SerialNumber;
                    log.TemplateID = template;
                    log.Type = "Push";
                    log.SerialNumber = qn.FlowSerialNumber;
                    log.Status = message.Status;
                    log.Remark = message.Value;
                    SyncLog(log);
                }
                catch (Exception e)
                {
                    Logger.Write("BusinessLogic.OA.Flow.PushZ2", e.Message);
                    Message messageBL = new Message();
                    messageBL.Send("[OA][SAP]推送Z2通知单异常：" + e.Message);
                }
            }
        }

        private void PushZ3(string template)
        {
            //过程审批Z3
            QualityNotification qnbl = new QualityNotification();
            IList<FlowInfo> nodes = Read(template, 3);
            foreach (FlowInfo node in nodes)
            {
                try
                {
                    QNInfo qn = ReadZ3(node.ID);
                    qn.Type = "Z3";
                    MessageInfo message = qnbl.Update(qn);
                    if (message.Status == 2)
                    {
                        //messageBL.Send(qn.CreatorCode, "[SAP]已更新质量通知单" + qn.SerialNumber + "！" + message.Value);
                    }
                    else
                    {
                        Message messageBL = new Message();
                        messageBL.Send("[SAP]无法根据流程" + qn.FlowSerialNumber + "更新质量通知单" + qn.SerialNumber + "！" + message.Value);
                        //messageBL.Send(qn.CreatorCode, "[SAP]无法更新质量通知单" + qn.SerialNumber + "！" + message.Value);
                        if (qn.SerialNumber.Equals(""))
                            qn.SerialNumber = "0";
                    }
                    FlowLogInfo log = new FlowLogInfo();
                    log.ID = node.ID;
                    log.QualityNotification = qn.SerialNumber;
                    log.TemplateID = template;
                    log.Type = "Push";
                    log.SerialNumber = qn.FlowSerialNumber;
                    log.Status = message.Status;
                    log.Remark = message.Value;
                    SyncLog(log);
                }
                catch (Exception e)
                {
                    Logger.Write("BusinessLogic.OA.Flow.PushZ3", e.Message);
                    Message messageBL = new Message();
                    messageBL.Send("[OA][SAP]推送Z3通知单异常：" + e.Message);
                }

            }
        }

        public bool SyncLog(FlowLogInfo node)
        {
            DateTime now = DateTime.Now;
            node.Date = now.ToString("yyyy-MM-dd HH:mm:ss ffffff");
            return _DetaAccess.SyncLog(node);
        }

        public IList<FlowLogInfo> SyncLog(string startDate, string endDate, string keyword)
        {
            IList<FlowLogInfo> node;
            if (keyword != null && !keyword.Equals(""))
            {
                node = SyncLog(keyword);
            }
            else
            {
                node = SyncLog(startDate, endDate);
            }

            return node;
        }

        public IList<FlowLogInfo> SyncLog(string startDate, string endDate)
        {
            return _DetaAccess.SyncLog(startDate, endDate);
        }

        public IList<FlowLogInfo> SyncLog(string keyword)
        {
            return _DetaAccess.SyncLog(keyword);
        }

        public IList<FlowInfo> Read(string templateID, int status)
        {
            return _DetaAccess.Read(templateID, status);
        }

        public IList<FlowInfo> Read(FlowInfo keywords)
        {
            return null;
        }

        public QNInfo ReadZ3(string ID)
        {
            QNInfo node = _DetaAccess.ReadZ3(ID);
            node.Items = ReadZ3Item(ID);
            return node;
        }

        private IList<QNItemInfo> ReadZ3Item(string ID)
        {
            return _DetaAccess.ReadZ3Item(ID);
        }

        public QNInfo ReadQ1(string ID)
        {
            QNInfo node = _DetaAccess.ReadQ1(ID);

            if (node.Outsourcing.Equals("是"))
            {
                node.Products = new List<ProductInfo>();
                node.Outsourcings = ReadQ1Outsourcing(ID);
            }

            if (node.Outsourcing.Equals("否"))
            {
                node.Products = ReadQ1Product(ID);
                node.Outsourcings = new List<ProductInfo>();
            }

            return node;
        }

        public bool UpdateQ1(string ID, string QualityNotification)
        {
            return _DetaAccess.UpdateQ1(ID, QualityNotification);
        }

        private IList<ProductInfo> ReadQ1Product(string ID)
        {
            return _DetaAccess.ReadQ1Product(ID);
        }

        private IList<ProductInfo> ReadQ1Outsourcing(string ID)
        {
            return _DetaAccess.ReadQ1Outsourcing(ID);
        }

        public QNInfo ReadZ2(string ID)
        {
            return _DetaAccess.ReadZ2(ID);
        }

        private bool LockPull()
        {
            bool unlocked = false;
            lock (_Pull)
            {
                if (_Pull.Lock == 0)
                {
                    Logger.Write("BusinessLogic.OA.Flow.Pull", "Lock");
                    _Pull.Lock = 1;
                    unlocked = true;
                }
            }
            return unlocked;
        }

        private void UnlockPull()
        {
            lock (_Pull)
            {
                Logger.Write("BusinessLogic.OA.Flow.Pull", "Unlock");
                _Pull.Lock = 0;
            }
        }

        private bool LockPush()
        {
            bool unlocked = false;
            lock (_Push)
            {
                if (_Push.Lock == 0)
                {
                    Logger.Write("BusinessLogic.OA.Flow.Push", "Lock");
                    _Push.Lock = 1;
                    unlocked = true;
                }
            }
            return unlocked;
        }

        private void UnlockPush()
        {
            lock (_Push)
            {
                Logger.Write("BusinessLogic.OA.Flow.Push", "Unlock");
                _Push.Lock = 0;
            }
        }



        //CRM
        //public IList<OA_QJ_INFO> ReadFROMMAIN_1801(long ID)
        //{
        //    return _DetaAccess.ReadFROMMAIN_1801(ID);
        //}

        //public int ReadOAFinishStatus(long ID, int OACSLB)
        //{
        //    return _DetaAccess.ReadOAFinishStatus(long.Parse("-730795971312267924"), 92);
        //}


    }
}
