using Newtonsoft.Json;
using Sonluk.BusinessLogic.OA;
using Sonluk.DAFactory;
using Sonluk.Entities.Account;
using Sonluk.IDataAccess.Account;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace Sonluk.BusinessLogic.Account
{
    public class Access
    {

        private static readonly IAccess detaAccess = AccountDataAccess.CreateAccess();

        public AccountInfo SignIn(string signInName, string password)
        {
            int group = 2;
            Regex regex = new Regex(@"^[0-9]*$");
            if (regex.IsMatch(signInName))
            {
                group = 1;//Vendor
            }
            else
            {
                group = 2;//Purchaser
            }
            AccountInfo account;

            try
            {
                account = SignIn(group, signInName, password);
                if (account.Name.Equals(""))
                {
                    account.SignIn = false;
                    account.Message = "用户名和密码不匹配";
                    account.Group = 0;
                }
                else
                {
                    account.SignIn = true;
                    account.ID = signInName;
                }
                Authorization auth = new Authorization();
                account.SAPAuthorization = auth.Read(account.ID);

            }
            catch (Exception e)
            {
                account = new AccountInfo();
                account.SignIn = false;
                account.Message = "服务异常！请联系管理员";
                account.MessageDetails = e.ToString();
            }

            account.Menu = Menu(account.Group);
            account.Route = Route(account.Group, signInName);
            account.Authorization = Authorization(account.Group);
            return account;
        }
        public AccountInfo SignInSS0(string signInName, string password,string url)
        {
            int group = 2;
            Regex regex = new Regex(@"^[0-9]*$");
            if (regex.IsMatch(signInName))
            {
                group = 1;//Vendor
            }
            else
            {
                group = 2;//Purchaser
            }
            AccountInfo account;

            try
            {
                account = SignIn(group, signInName, password);
                if (account.Name.Equals(""))
                {
                    account.SignIn = false;
                    account.Message = "用户名和密码不匹配";
                    account.Group = 0;
                }
                else
                {
                    account.SignIn = true;
                    account.ID = signInName;
                }
                Authorization auth = new Authorization();
                account.SAPAuthorization = auth.Read(account.ID);

            }
            catch (Exception e)
            {
                account = new AccountInfo();
                account.SignIn = false;
                account.Message = "服务异常！请联系管理员";
                account.MessageDetails = e.ToString();
            }

            account.Menu = MenuSS0(account.Group,url);
            account.Route = Route(account.Group, signInName);
            account.Authorization = Authorization(account.Group);
            return account;
        }


        
        private AccountInfo SignIn(int group, string signInName, string password)
        {
            AccountInfo account = new AccountInfo();
            switch (group)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        Vendor vendor = new Vendor();
                        account = vendor.SignIn(signInName, password);
                        account.Group = 1;
                        break;
                    }
                default:
                    {
                        Purchaser purchaser = new Purchaser();
                        account = purchaser.SignIn(signInName, password);
                        break;
                    }
            }
            return account;
        }

        private RouteInfo Route(int Group, string signInName)
        {
            RouteInfo route = new RouteInfo();
            switch (Group)
            {
                case 0:
                    {
                        route.Controller = "Access";
                        route.Action = "SignIn";
                        break;
                    }
                case 1:
                    {
                        route.Area = "Vendor";
                        route.Controller = "PurchaseOrder";
                        route.Action = "Index";

                        Pending pending = new Pending();
                        if (pending.Count("V" + signInName) > 0)
                        {
                            route.Controller = "QualityNotification";
                        }
                        break;
                    }
                case 2:
                case 3:
                case 4:
                    {
                        route.Area = "MM";
                        route.Controller = "PurchaseOrder";
                        route.Action = "Index";
                        break;
                    }
                case 5:
                    {
                        route.Area = "MM";
                        route.Controller = "ScheduleRequisition";
                        route.Action = "Index";
                        route.Auth = "PP";
                        break;
                    }
                case 6:
                    {
                        route.Area = "MM";
                        route.Controller = "ScheduleRequisition";
                        route.Action = "Index";
                        route.Auth = "PPCtrl";
                        break;
                    }
                case 7:
                    {
                        route.Area = "MM";
                        route.Controller = "ScheduleRequisition";
                        route.Action = "Index";
                        route.Auth = "OP";
                        break;
                    }
                case 8:
                    {
                        route.Area = "MM";
                        route.Controller = "ScheduleRequisition";
                        route.Action = "Index";
                        route.Auth = "PurCtrl";
                        break;
                    }
                case 20:
                    {
                        route.Area = "LE";
                        route.Controller = "OutboundDelivery";
                        route.Action = "Index";
                        route.Auth = "";
                        break;
                    }
                case 21:
                    {
                        route.Area = "LE";
                        route.Controller = "OutboundDelivery";
                        route.Action = "Index";
                        route.Auth = "";
                        break;
                    }
                case 22:
                    {
                        route.Area = "MM";
                        route.Controller = "PurchaseOrder";
                        route.Action = "Index";
                        route.Auth = "ZNB9";
                        break;
                    }
                case 23:
                    {
                        route.Area = "MM";
                        route.Controller = "PurchaseOrder";
                        route.Action = "Index";
                        route.Auth = "ZUB";
                        break;
                    }
                case 254:
                    {
                        route.Controller = "Help";
                        route.Action = "About";
                        break;
                    }
                case 255:
                    {
                        route.Area = "DEV";
                        route.Controller = "Log";
                        route.Action = "OA";
                        break;
                    }
            }
            return route;

        }
        private string MenuSS0(int type,string url)
        {
            string xiugaiurl = "";
            if (url.IndexOf("192.168") != -1 || url.IndexOf("localhost") != -1)
            {
                xiugaiurl = ConfigurationManager.AppSettings["SSOURLDROPOUTIN"];
            }
            else
            {
                xiugaiurl = ConfigurationManager.AppSettings["SSOURLDROPOUTOUT"];
            }
            MenuInfo menu = new MenuInfo();
            switch (type)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        //供应商
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/Vendor/PurchaseOrder"));
                        menu.Children[0].Children.Add(new MenuInfo("条码管理", "/Sonluk/BC/BarCode/BarCodeMgr"));
                        menu.Children.Add(new MenuInfo("质量通知单"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/Vendor/QualityNotification"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children.Add(new MenuInfo("修改密码", xiugaiurl));
                        menu.Children[2].Children.Add(new MenuInfo("打印纸张", "/Sonluk/MM/Report/Config"));
                        menu.Children[2].Children.Add(new MenuInfo("操作手册", "/Sonluk/Help/OperationManual"));
                        menu.Children[2].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 2:
                    {
                        //采购员A
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/MM/PurchaseOrder"));
                        menu.Children[0].Children.Add(new MenuInfo("交货计划申请"));
                        menu.Children[0].Children[1].Children = new List<MenuInfo>();
                        menu.Children[0].Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/MM/ScheduleRequisition?Auth=Pur"));
                        menu.Children[0].Children.Add(new MenuInfo("更新交货日期", "/Sonluk/MM/PurchaseOrder/UpdateDeliveryDate"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("修改密码", xiugaiurl));
                        menu.Children[1].Children.Add(new MenuInfo("打印纸张", "/Sonluk/MM/Report/Config"));
                        menu.Children[1].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 3:
                    {
                        //采购员B
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/MM/PurchaseOrder"));
                        menu.Children[0].Children.Add(new MenuInfo("交货计划申请"));
                        menu.Children[0].Children[1].Children = new List<MenuInfo>();
                        menu.Children[0].Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/MM/ScheduleRequisition?Auth=Pur"));
                        menu.Children[0].Children.Add(new MenuInfo("更新交货日期", "/Sonluk/MM/PurchaseOrder/UpdateDeliveryDate"));
                        menu.Children.Add(new MenuInfo("销售订单"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/SD/SalesOrder"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children.Add(new MenuInfo("修改密码", xiugaiurl));
                        menu.Children[2].Children.Add(new MenuInfo("打印纸张", "/Sonluk/MM/Report/Config"));
                        menu.Children[2].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 4:
                    {
                        //采购经理
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/MM/PurchaseOrder"));
                        menu.Children[0].Children.Add(new MenuInfo("交货计划申请"));
                        menu.Children[0].Children[1].Children = new List<MenuInfo>();
                        menu.Children[0].Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/MM/ScheduleRequisition?Auth=Pur"));
                        menu.Children[0].Children.Add(new MenuInfo("更新交货日期", "/Sonluk/MM/PurchaseOrder/UpdateDeliveryDate"));
                        menu.Children.Add(new MenuInfo("销售订单"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/SD/SalesOrder"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children.Add(new MenuInfo("修改密码", xiugaiurl));
                        menu.Children[2].Children.Add(new MenuInfo("打印纸张", "/Sonluk/MM/Report/Config"));
                        menu.Children[2].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 5:
                    {
                        //生产计划员
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("交货计划申请"));
                        menu.Children[0].Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children[0].Children.Add(new MenuInfo("新建", "/Sonluk/MM/ScheduleRequisition/Edit?Auth=PP&SN=0"));
                        menu.Children[0].Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/MM/ScheduleRequisition?Auth=PP"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("修改密码", xiugaiurl));
                        menu.Children[1].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 6:
                    {
                        //生产计划经理
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("交货计划申请"));
                        menu.Children[0].Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/MM/ScheduleRequisition?Auth=PPCtrl"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("修改密码", xiugaiurl));
                        menu.Children[1].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 7:
                    {
                        //采购委外
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("交货计划申请"));
                        menu.Children[0].Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children[0].Children.Add(new MenuInfo("新建", "/Sonluk/MM/ScheduleRequisition/Edit?Auth=OP&SN=0"));
                        menu.Children[0].Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/MM/ScheduleRequisition?Auth=OP"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("修改密码", xiugaiurl));
                        menu.Children[1].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 8:
                    {
                        //采购控制员
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("交货计划申请"));
                        menu.Children[0].Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/MM/ScheduleRequisition?Auth=PurCtrl"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("修改密码", xiugaiurl));
                        menu.Children[1].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 20:
                    {
                        //物流经理
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("队列锁"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/BC/Enqueue"));
                        menu.Children.Add(new MenuInfo("交货单"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/LE/OutboundDelivery"));
                        menu.Children.Add(new MenuInfo("托运单"));
                        menu.Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children.Add(new MenuInfo("查询", "/Sonluk/LE/ConsignmentNote"));
                        menu.Children[2].Children.Add(new MenuInfo("反馈"));
                        menu.Children[2].Children[1].Children = new List<MenuInfo>();
                        menu.Children[2].Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/LE/Feedback"));
                        menu.Children[2].Children.Add(new MenuInfo("投诉"));
                        menu.Children[2].Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children[2].Children.Add(new MenuInfo("查询", "/Sonluk/LE/Complaint"));
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[3].Children = new List<MenuInfo>();
                        menu.Children[3].Children.Add(new MenuInfo("调拨单", "/Sonluk/MM/PurchaseOrder?Auth=ZUB"));
                        menu.Children[3].Children.Add(new MenuInfo("公司间采购", "/Sonluk/MM/PurchaseOrder?Auth=ZNB9"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[4].Children = new List<MenuInfo>();
                        menu.Children[4].Children.Add(new MenuInfo("修改密码", xiugaiurl));
                        menu.Children[4].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        menu.Children.Add(new MenuInfo("拣配"));
                        menu.Children[5].Children = new List<MenuInfo>();
                        menu.Children[5].Children.Add(new MenuInfo("喷码打印", "/Sonluk/BC/BarCode/Picking"));
                        menu.Children[5].Children.Add(new MenuInfo("大屏显示", "/Sonluk/BC/BarCode/PickingtaskConfig"));
                        menu.Children[5].Children.Add(new MenuInfo("大屏消息", "/Sonluk/BC/BarCode/ScreenMsg"));
                        break;
                    }
                case 21:
                    {
                        //托运单管理
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("队列锁"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/BC/Enqueue"));
                        menu.Children.Add(new MenuInfo("交货单"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/LE/OutboundDelivery"));
                        menu.Children[1].Children.Add(new MenuInfo("回单确认", "/Sonluk/LE/OutboundDelivery/Back"));
                        menu.Children.Add(new MenuInfo("托运单"));
                        menu.Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children.Add(new MenuInfo("查询", "/Sonluk/LE/ConsignmentNote"));
                        menu.Children[2].Children.Add(new MenuInfo("新建", "/Sonluk/LE/ConsignmentNote/Edit/0"));
                        menu.Children[2].Children.Add(new MenuInfo("反馈"));
                        menu.Children[2].Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children[2].Children.Add(new MenuInfo("确认", "/Sonluk/LE/Feedback/Edit/0"));
                        menu.Children[2].Children[2].Children.Add(new MenuInfo("查询", "/Sonluk/LE/Feedback"));
                        menu.Children[2].Children.Add(new MenuInfo("投诉"));
                        menu.Children[2].Children[3].Children = new List<MenuInfo>();
                        menu.Children[2].Children[3].Children.Add(new MenuInfo("查询", "/Sonluk/LE/Complaint"));
                        menu.Children[2].Children.Add(new MenuInfo("站点", "/Sonluk/LE/City"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[3].Children = new List<MenuInfo>();
                        menu.Children[3].Children.Add(new MenuInfo("套打模板", "/Sonluk/Print/Layout"));
                        menu.Children[3].Children.Add(new MenuInfo("修改密码", xiugaiurl));
                        menu.Children[3].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        menu.Children.Add(new MenuInfo("拣配"));
                        menu.Children[4].Children = new List<MenuInfo>();
                        menu.Children[4].Children.Add(new MenuInfo("喷码打印", "/Sonluk/BC/BarCode/Picking"));
                        menu.Children[4].Children.Add(new MenuInfo("大屏显示", "/Sonluk/BC/BarCode/PickingtaskConfig"));
                        menu.Children[4].Children.Add(new MenuInfo("大屏消息", "/Sonluk/BC/BarCode/ScreenMsg"));
                        break;
                    }
                case 22:
                    {
                        //外销公司间采购查询
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("公司间采购", "/Sonluk/MM/PurchaseOrder?Auth=ZNB9"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("修改密码", xiugaiurl));
                        menu.Children[1].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 23:
                    {
                        //中转库及托运单查询
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("托运单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/LE/ConsignmentNote"));
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("调拨单", "/Sonluk/MM/PurchaseOrder?Auth=ZUB"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children.Add(new MenuInfo("修改密码", xiugaiurl));
                        menu.Children[2].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 254:
                    {
                        //测试员
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("销售订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/SD/SalesOrder"));
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/Vendor/PurchaseOrder"));
                        menu.Children[1].Children.Add(new MenuInfo("调拨单", "/Sonluk/MM/PurchaseOrder?Auth=ZUB"));
                        menu.Children[1].Children.Add(new MenuInfo("公司间采购", "/Sonluk/MM/PurchaseOrder?Auth=ZNB9"));
                        menu.Children[1].Children.Add(new MenuInfo("交货计划申请"));
                        menu.Children[1].Children[3].Children = new List<MenuInfo>();
                        menu.Children[1].Children[3].Children.Add(new MenuInfo("新建", "/Sonluk/MM/ScheduleRequisition/Edit?Auth=PP&SN=0"));
                        menu.Children[1].Children[3].Children.Add(new MenuInfo("查询", "/Sonluk/MM/ScheduleRequisition?Auth=PP"));
                        menu.Children[1].Children.Add(new MenuInfo("更新交货日期", "/Sonluk/MM/PurchaseOrder/UpdateDeliveryDate"));
                        menu.Children.Add(new MenuInfo("质量通知单"));
                        menu.Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children.Add(new MenuInfo("查询", "/Sonluk/Vendor/QualityNotification"));
                        menu.Children.Add(new MenuInfo("交货单"));
                        menu.Children[3].Children = new List<MenuInfo>();
                        menu.Children[3].Children.Add(new MenuInfo("查询", "/Sonluk/LE/OutboundDelivery"));
                        menu.Children.Add(new MenuInfo("托运单"));
                        menu.Children[4].Children = new List<MenuInfo>();
                        menu.Children[4].Children.Add(new MenuInfo("查询", "/Sonluk/LE/ConsignmentNote"));
                        menu.Children[4].Children.Add(new MenuInfo("新建", "/Sonluk/LE/ConsignmentNote/Edit/0"));
                        menu.Children[4].Children.Add(new MenuInfo("反馈"));
                        menu.Children[4].Children[2].Children = new List<MenuInfo>();
                        menu.Children[4].Children[2].Children.Add(new MenuInfo("确认", "/Sonluk/LE/Feedback/Edit/0"));
                        menu.Children[4].Children[2].Children.Add(new MenuInfo("查询", "/Sonluk/LE/Feedback"));
                        menu.Children[4].Children.Add(new MenuInfo("投诉"));
                        menu.Children[4].Children[3].Children = new List<MenuInfo>();
                        menu.Children[4].Children[3].Children.Add(new MenuInfo("登记", "/Sonluk/LE/Complaint/Edit/0"));
                        menu.Children[4].Children[3].Children.Add(new MenuInfo("查询", "/Sonluk/LE/Complaint"));
                        menu.Children.Add(new MenuInfo("队列锁"));
                        menu.Children[5].Children = new List<MenuInfo>();
                        menu.Children[5].Children.Add(new MenuInfo("查询", "/Sonluk/BC/Enqueue"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[6].Children = new List<MenuInfo>();
                        menu.Children[6].Children.Add(new MenuInfo("打印纸张", "/Sonluk/MM/Report/Config"));
                        menu.Children[6].Children.Add(new MenuInfo("操作手册", "/Sonluk/Help/OperationManual"));
                        menu.Children[6].Children.Add(new MenuInfo("套打模板", "/Sonluk/Print/Layout"));
                        menu.Children[6].Children.Add(new MenuInfo("修改密码", xiugaiurl));
                        menu.Children[6].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 255:
                    {
                        //管理员
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("维护"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("采购订单临时文件", "/Sonluk/MM/PurchaseOrder/Temp"));
                        menu.Children.Add(new MenuInfo("日志"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("读取", "/Sonluk/DEV/Log"));
                        menu.Children[1].Children.Add(new MenuInfo("OA", "/Sonluk/DEV/Log/OA"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children.Add(new MenuInfo("修改密码", xiugaiurl));
                        menu.Children[2].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
            }

            JsonSerializerSettings jsonSetting = new JsonSerializerSettings();
            jsonSetting.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(menu, jsonSetting);
        }
        private string Menu(int type)
        {
            MenuInfo menu = new MenuInfo();
            switch (type)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        //供应商
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/Vendor/PurchaseOrder"));
                        menu.Children[0].Children.Add(new MenuInfo("条码管理", "/Sonluk/BC/BarCode/BarCodeMgr"));
                        menu.Children.Add(new MenuInfo("质量通知单"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/Vendor/QualityNotification"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children.Add(new MenuInfo("修改密码", "/Sonluk/Access/UpdatePassword"));
                        menu.Children[2].Children.Add(new MenuInfo("打印纸张", "/Sonluk/MM/Report/Config"));
                        menu.Children[2].Children.Add(new MenuInfo("操作手册", "/Sonluk/Help/OperationManual"));
                        menu.Children[2].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 2:
                    {
                        //采购员A
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/MM/PurchaseOrder"));
                        menu.Children[0].Children.Add(new MenuInfo("交货计划申请"));
                        menu.Children[0].Children[1].Children = new List<MenuInfo>();
                        menu.Children[0].Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/MM/ScheduleRequisition?Auth=Pur"));
                        menu.Children[0].Children.Add(new MenuInfo("更新交货日期", "/Sonluk/MM/PurchaseOrder/UpdateDeliveryDate"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("修改密码", "/Sonluk/Access/UpdatePassword"));
                        menu.Children[1].Children.Add(new MenuInfo("打印纸张", "/Sonluk/MM/Report/Config"));
                        menu.Children[1].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 3:
                    {
                        //采购员B
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/MM/PurchaseOrder"));
                        menu.Children[0].Children.Add(new MenuInfo("交货计划申请"));
                        menu.Children[0].Children[1].Children = new List<MenuInfo>();
                        menu.Children[0].Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/MM/ScheduleRequisition?Auth=Pur"));
                        menu.Children[0].Children.Add(new MenuInfo("更新交货日期", "/Sonluk/MM/PurchaseOrder/UpdateDeliveryDate"));
                        menu.Children.Add(new MenuInfo("销售订单"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/SD/SalesOrder"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children.Add(new MenuInfo("修改密码", "/Sonluk/Access/UpdatePassword"));
                        menu.Children[2].Children.Add(new MenuInfo("打印纸张", "/Sonluk/MM/Report/Config"));
                        menu.Children[2].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 4:
                    {
                        //采购经理
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/MM/PurchaseOrder"));
                        menu.Children[0].Children.Add(new MenuInfo("交货计划申请"));
                        menu.Children[0].Children[1].Children = new List<MenuInfo>();
                        menu.Children[0].Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/MM/ScheduleRequisition?Auth=Pur"));
                        menu.Children[0].Children.Add(new MenuInfo("更新交货日期", "/Sonluk/MM/PurchaseOrder/UpdateDeliveryDate"));
                        menu.Children.Add(new MenuInfo("销售订单"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/SD/SalesOrder"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children.Add(new MenuInfo("修改密码", "/Sonluk/Access/UpdatePassword"));
                        menu.Children[2].Children.Add(new MenuInfo("打印纸张", "/Sonluk/MM/Report/Config"));
                        menu.Children[2].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 5:
                    {
                        //生产计划员
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("交货计划申请"));
                        menu.Children[0].Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children[0].Children.Add(new MenuInfo("新建", "/Sonluk/MM/ScheduleRequisition/Edit?Auth=PP&SN=0"));
                        menu.Children[0].Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/MM/ScheduleRequisition?Auth=PP"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("修改密码", "/Sonluk/Access/UpdatePassword"));
                        menu.Children[1].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 6:
                    {
                        //生产计划经理
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("交货计划申请"));
                        menu.Children[0].Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/MM/ScheduleRequisition?Auth=PPCtrl"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("修改密码", "/Sonluk/Access/UpdatePassword"));
                        menu.Children[1].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 7:
                    {
                        //采购委外
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("交货计划申请"));
                        menu.Children[0].Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children[0].Children.Add(new MenuInfo("新建", "/Sonluk/MM/ScheduleRequisition/Edit?Auth=OP&SN=0"));
                        menu.Children[0].Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/MM/ScheduleRequisition?Auth=OP"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("修改密码", "/Sonluk/Access/UpdatePassword"));
                        menu.Children[1].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 8:
                    {
                        //采购控制员
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("交货计划申请"));
                        menu.Children[0].Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/MM/ScheduleRequisition?Auth=PurCtrl"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("修改密码", "/Sonluk/Access/UpdatePassword"));
                        menu.Children[1].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 20:
                    {
                        //物流经理
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("队列锁"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/BC/Enqueue"));
                        menu.Children.Add(new MenuInfo("交货单"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/LE/OutboundDelivery"));
                        menu.Children.Add(new MenuInfo("托运单"));
                        menu.Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children.Add(new MenuInfo("查询", "/Sonluk/LE/ConsignmentNote"));
                        menu.Children[2].Children.Add(new MenuInfo("反馈"));
                        menu.Children[2].Children[1].Children = new List<MenuInfo>();
                        menu.Children[2].Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/LE/Feedback"));
                        menu.Children[2].Children.Add(new MenuInfo("投诉"));
                        menu.Children[2].Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children[2].Children.Add(new MenuInfo("查询", "/Sonluk/LE/Complaint"));
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[3].Children = new List<MenuInfo>();
                        menu.Children[3].Children.Add(new MenuInfo("调拨单", "/Sonluk/MM/PurchaseOrder?Auth=ZUB"));
                        menu.Children[3].Children.Add(new MenuInfo("公司间采购", "/Sonluk/MM/PurchaseOrder?Auth=ZNB9"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[4].Children = new List<MenuInfo>();
                        menu.Children[4].Children.Add(new MenuInfo("修改密码", "/Sonluk/Access/UpdatePassword"));
                        menu.Children[4].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        menu.Children.Add(new MenuInfo("拣配"));
                        menu.Children[5].Children = new List<MenuInfo>();
                        menu.Children[5].Children.Add(new MenuInfo("喷码打印", "/Sonluk/BC/BarCode/Picking"));
                        menu.Children[5].Children.Add(new MenuInfo("大屏显示", "/Sonluk/BC/BarCode/PickingtaskConfig"));
                        menu.Children[5].Children.Add(new MenuInfo("大屏消息", "/Sonluk/BC/BarCode/ScreenMsg"));
                        break;
                    }
                case 21:
                    {
                        //托运单管理
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("队列锁"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/BC/Enqueue"));
                        menu.Children.Add(new MenuInfo("交货单"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/LE/OutboundDelivery"));
                        menu.Children[1].Children.Add(new MenuInfo("回单确认", "/Sonluk/LE/OutboundDelivery/Back"));
                        menu.Children.Add(new MenuInfo("托运单"));
                        menu.Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children.Add(new MenuInfo("查询", "/Sonluk/LE/ConsignmentNote"));
                        menu.Children[2].Children.Add(new MenuInfo("新建", "/Sonluk/LE/ConsignmentNote/Edit/0"));
                        menu.Children[2].Children.Add(new MenuInfo("反馈"));
                        menu.Children[2].Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children[2].Children.Add(new MenuInfo("确认", "/Sonluk/LE/Feedback/Edit/0"));
                        menu.Children[2].Children[2].Children.Add(new MenuInfo("查询", "/Sonluk/LE/Feedback"));
                        menu.Children[2].Children.Add(new MenuInfo("投诉"));
                        menu.Children[2].Children[3].Children = new List<MenuInfo>();
                        menu.Children[2].Children[3].Children.Add(new MenuInfo("查询", "/Sonluk/LE/Complaint"));
                        menu.Children[2].Children.Add(new MenuInfo("站点","/Sonluk/LE/City"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[3].Children = new List<MenuInfo>();
                        menu.Children[3].Children.Add(new MenuInfo("套打模板", "/Sonluk/Print/Layout"));
                        menu.Children[3].Children.Add(new MenuInfo("修改密码", "/Sonluk/Access/UpdatePassword"));
                        menu.Children[3].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        menu.Children.Add(new MenuInfo("拣配"));
                        menu.Children[4].Children = new List<MenuInfo>();
                        menu.Children[4].Children.Add(new MenuInfo("喷码打印", "/Sonluk/BC/BarCode/Picking"));
                        menu.Children[4].Children.Add(new MenuInfo("大屏显示", "/Sonluk/BC/BarCode/PickingtaskConfig"));
                        menu.Children[4].Children.Add(new MenuInfo("大屏消息", "/Sonluk/BC/BarCode/ScreenMsg"));
                        break;
                    }
                case 22:
                    {
                        //外销公司间采购查询
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("公司间采购", "/Sonluk/MM/PurchaseOrder?Auth=ZNB9"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("修改密码", "/Sonluk/Access/UpdatePassword"));
                        menu.Children[1].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 23:
                    {
                        //中转库及托运单查询
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("托运单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/LE/ConsignmentNote"));
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("调拨单", "/Sonluk/MM/PurchaseOrder?Auth=ZUB"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children.Add(new MenuInfo("修改密码", "/Sonluk/Access/UpdatePassword"));
                        menu.Children[2].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 254:
                    {
                        //测试员
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("销售订单"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("查询", "/Sonluk/SD/SalesOrder"));
                        menu.Children.Add(new MenuInfo("采购订单"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("查询", "/Sonluk/Vendor/PurchaseOrder"));
                        menu.Children[1].Children.Add(new MenuInfo("调拨单", "/Sonluk/MM/PurchaseOrder?Auth=ZUB"));
                        menu.Children[1].Children.Add(new MenuInfo("公司间采购", "/Sonluk/MM/PurchaseOrder?Auth=ZNB9"));
                        menu.Children[1].Children.Add(new MenuInfo("交货计划申请"));
                        menu.Children[1].Children[3].Children = new List<MenuInfo>();
                        menu.Children[1].Children[3].Children.Add(new MenuInfo("新建", "/Sonluk/MM/ScheduleRequisition/Edit?Auth=PP&SN=0"));
                        menu.Children[1].Children[3].Children.Add(new MenuInfo("查询", "/Sonluk/MM/ScheduleRequisition?Auth=PP"));
                        menu.Children[1].Children.Add(new MenuInfo("更新交货日期", "/Sonluk/MM/PurchaseOrder/UpdateDeliveryDate"));
                        menu.Children.Add(new MenuInfo("质量通知单"));
                        menu.Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children.Add(new MenuInfo("查询", "/Sonluk/Vendor/QualityNotification"));
                        menu.Children.Add(new MenuInfo("交货单"));
                        menu.Children[3].Children = new List<MenuInfo>();
                        menu.Children[3].Children.Add(new MenuInfo("查询", "/Sonluk/LE/OutboundDelivery"));
                        menu.Children.Add(new MenuInfo("托运单"));
                        menu.Children[4].Children = new List<MenuInfo>();
                        menu.Children[4].Children.Add(new MenuInfo("查询", "/Sonluk/LE/ConsignmentNote"));
                        menu.Children[4].Children.Add(new MenuInfo("新建", "/Sonluk/LE/ConsignmentNote/Edit/0"));
                        menu.Children[4].Children.Add(new MenuInfo("反馈"));
                        menu.Children[4].Children[2].Children = new List<MenuInfo>();
                        menu.Children[4].Children[2].Children.Add(new MenuInfo("确认", "/Sonluk/LE/Feedback/Edit/0"));
                        menu.Children[4].Children[2].Children.Add(new MenuInfo("查询", "/Sonluk/LE/Feedback"));
                        menu.Children[4].Children.Add(new MenuInfo("投诉"));
                        menu.Children[4].Children[3].Children = new List<MenuInfo>();
                        menu.Children[4].Children[3].Children.Add(new MenuInfo("登记", "/Sonluk/LE/Complaint/Edit/0"));
                        menu.Children[4].Children[3].Children.Add(new MenuInfo("查询", "/Sonluk/LE/Complaint"));
                        menu.Children.Add(new MenuInfo("队列锁"));
                        menu.Children[5].Children = new List<MenuInfo>();
                        menu.Children[5].Children.Add(new MenuInfo("查询", "/Sonluk/BC/Enqueue"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[6].Children = new List<MenuInfo>();
                        menu.Children[6].Children.Add(new MenuInfo("打印纸张", "/Sonluk/MM/Report/Config"));
                        menu.Children[6].Children.Add(new MenuInfo("操作手册", "/Sonluk/Help/OperationManual"));
                        menu.Children[6].Children.Add(new MenuInfo("套打模板", "/Sonluk/Print/Layout"));
                        menu.Children[6].Children.Add(new MenuInfo("修改密码", "/Sonluk/Access/UpdatePassword"));
                        menu.Children[6].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
                case 255:
                    {
                        //管理员
                        menu.Children = new List<MenuInfo>();
                        menu.Children.Add(new MenuInfo("维护"));
                        menu.Children[0].Children = new List<MenuInfo>();
                        menu.Children[0].Children.Add(new MenuInfo("采购订单临时文件", "/Sonluk/MM/PurchaseOrder/Temp"));
                        menu.Children.Add(new MenuInfo("日志"));
                        menu.Children[1].Children = new List<MenuInfo>();
                        menu.Children[1].Children.Add(new MenuInfo("读取", "/Sonluk/DEV/Log"));
                        menu.Children[1].Children.Add(new MenuInfo("OA", "/Sonluk/DEV/Log/OA"));
                        menu.Children.Add(new MenuInfo("设置"));
                        menu.Children[2].Children = new List<MenuInfo>();
                        menu.Children[2].Children.Add(new MenuInfo("修改密码", "/Sonluk/Access/UpdatePassword"));
                        menu.Children[2].Children.Add(new MenuInfo("关于", "/Sonluk/Help/About"));
                        break;
                    }
            }

            JsonSerializerSettings jsonSetting = new JsonSerializerSettings();
            jsonSetting.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(menu, jsonSetting);
        }

        public List<string> Authorization(int type)
        {
            List<string> auths = new List<string>();
            switch (type)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        //供应商
                        auths.Add("Vendor/PurchaseOrder/Index");
                        auths.Add("Access/UpdatePassword");
                        break;
                    }
                case 2:
                    {
                        //采购员A
                        auths.Add("MM/PurchaseOrder/Index");
                        auths.Add("MM/ScheduleRequisition/Index?Auth=Pur");
                        auths.Add("MM/ScheduleRequisition/Release?Auth=Pur");
                        auths.Add("MM/PurchaseOrder/UpdateDeliveryDate");
                        auths.Add("Access/UpdatePassword");
                        break;
                    }
                case 3:
                    {
                        //采购员B
                        auths.Add("MM/PurchaseOrder/Index");
                        auths.Add("MM/ScheduleRequisition/Index?Auth=Pur");
                        auths.Add("MM/ScheduleRequisition/Release?Auth=Pur");
                        auths.Add("MM/PurchaseOrder/UpdateDeliveryDate");
                        auths.Add("SD/SalesOrder/Index");
                        auths.Add("Access/UpdatePassword");
                        break;
                    }
                case 4:
                    {
                        //采购经理
                        auths.Add("MM/PurchaseOrder/Index");
                        auths.Add("MM/ScheduleRequisition/Index?Auth=Pur");
                        auths.Add("MM/ScheduleRequisition/Release?Auth=Pur");
                        auths.Add("MM/PurchaseOrder/UpdateDeliveryDate");
                        auths.Add("SD/SalesOrder/Index");
                        auths.Add("Access/UpdatePassword");
                        break;
                    }
                case 5:
                    {
                        //生产计划员
                        auths.Add("MM/ScheduleRequisition/Edit?Auth=PP");
                        auths.Add("MM/ScheduleRequisition/Index?Auth=PP");
                        auths.Add("Access/UpdatePassword");
                        break;
                    }
                case 6:
                    {
                        //生产计划经理
                        auths.Add("MM/ScheduleRequisition/Index?Auth=PPCtrl");
                        auths.Add("MM/ScheduleRequisition/Release?Auth=PPCtrl");
                        auths.Add("Access/UpdatePassword");
                        break;
                    }
                case 7:
                    {
                        //采购委外
                        auths.Add("MM/ScheduleRequisition/Edit?Auth=OP");
                        auths.Add("MM/ScheduleRequisition/Index?Auth=OP");
                        auths.Add("Access/UpdatePassword");
                        break;
                    }
                case 8:
                    {
                        //采购控制员
                        auths.Add("MM/ScheduleRequisition/Index?Auth=PurCtrl");
                        auths.Add("MM/ScheduleRequisition/Release?Auth=PurCtrl");
                        auths.Add("Access/UpdatePassword");
                        break;
                    }
                case 20:
                    {
                        //物流经理
                        auths.Add("BC/Enqueue/Index");
                        auths.Add("LE/OutboundDelivery/Index");
                        auths.Add("LE/ConsignmentNote/Index");
                        auths.Add("LE/Complaint/Index");
                        auths.Add("LE/Feedback/Index");
                        auths.Add("MM/PurchaseOrder/Index?Auth=ZUB");
                        auths.Add("MM/PurchaseOrder/Index?Auth=ZNB9");
                        break;
                    }
                case 21:
                    {
                        //托运单管理
                        auths.Add("BC/Enqueue/Index");
                        auths.Add("LE/OutboundDelivery/Index");
                        auths.Add("LE/OutboundDelivery/Back");
                        auths.Add("LE/ConsignmentNote/Index");
                        auths.Add("LE/Complaint/Index");
                        auths.Add("LE/Feedback/Index");
                        auths.Add("Print/Layout/Index");
                        break;
                    }
                case 22:
                    {
                        //外销公司间采购查询
                        auths.Add("MM/PurchaseOrder/Index?Auth=ZNB9");
                        break;
                    }
                case 23:
                    {
                        //中转库及托运单查询
                        auths.Add("LE/ConsignmentNote/Index");
                        auths.Add("MM/PurchaseOrder/Index?Auth=ZUB");
                        break;
                    }
                case 254:
                    {
                        //测试员
                        //auths.Add("BC/Enqueue/Index");
                        //auths.Add("LE/OutboundDelivery/Index");
                        //auths.Add("MM/PurchaseOrder/Index?Auth=ZUB");
                        //auths.Add("MM/PurchaseOrder/Index?Auth=ZNB9");

                        auths.Add("SD/SalesOrder/Index");
                        auths.Add("Vendor/PurchaseOrder/Index");
                        auths.Add("MM/PurchaseOrder/Index?Auth=ZUB");
                        auths.Add("MM/PurchaseOrder/Index?Auth=ZNB9");        
                        auths.Add("MM/ScheduleRequisition/Edit?Auth=PP");
                        auths.Add("MM/ScheduleRequisition/Index?Auth=PP");
                        auths.Add("MM/PurchaseOrder/UpdateDeliveryDate/Index");
                        auths.Add("Vendor/QualityNotification/Index");
                        auths.Add("LE/OutboundDelivery/Index");
                        auths.Add("LE/ConsignmentNote/Index");
                        auths.Add("LE/ConsignmentNote/Edit/0");                        
                        auths.Add("LE/Feedback/Edit/0");
                        auths.Add("LE/Feedback/Index");                        
                        auths.Add("LE/Complaint/Edit/0");
                        auths.Add("LE/Complaint/Index");
                        auths.Add("BC/Enqueue/Index");
                        auths.Add("MM/Report/Config");
                        //auths.Add("Help/OperationManual/Index");
                        auths.Add("Print/Layout/Index");
                        auths.Add("Access/UpdatePassword");
                        auths.Add("Help/About");
                        break;
    
                    }
                case 255:
                    {
                        //管理员
                        auths.Add("MM/PurchaseOrder/Temp");
                        auths.Add("MM/PurchaseOrder/RemoveTemp");
                        auths.Add("Print/Layout/Index");
                        auths.Add("Access/UpdatePassword");
                        break;
                    }
            }
            return auths;

        }

        public bool ChangePassword(string signInName, string password, string newPassword)
        {

            Regex regex = new Regex(@"^[0-9]*$");

            bool success = false;
            if (regex.IsMatch(signInName))
            {
                Vendor account = new Vendor();
                success = account.ChangePassword(signInName, password, newPassword);
            }
            else
            {
                Purchaser account = new Purchaser();
                success = account.ChangePassword(signInName, password, newPassword);
            }

            return success;
        }

    }
}
