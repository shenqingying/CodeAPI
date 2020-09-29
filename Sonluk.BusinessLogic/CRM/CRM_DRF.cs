using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.Entities.DRF;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.CRM;
using Sonluk.IDataAccess.MES;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace Sonluk.BusinessLogic.CRM
{
    public class CRM_DRF
    {
        private static readonly ISY_SYSCS ISY_SYSCSdata = MESDataAccess.CreateISY_SYSCS();
        private static readonly IORDER_TT IORDER_TT_data = RMSDataAccess.CreateIORDER_TT();
        private static readonly IHG_DICT IHG_DICTdata = RMSDataAccess.CreateHG_DICT();
        private static readonly ISY_EXCEPTION ISY_EXCEPTIONdata = MESDataAccess.CreateISY_EXCEPTION();
        //const string DRFSERVICE = "http://192.168.8.53/";
        private string DRFSERVICE = AppConfig.Settings("DRFSERVICE");
        public CRM_DRF_RETURNMSG status(int account)
        {
            string str = "account=" + account.ToString();
            string result = "";
            Stream stream = apidy("api/status", str, "application/x-www-form-urlencoded");
            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(DRFSERVICE + "api/status");
            //req.Method = "POST";
            //req.ContentType = "application/x-www-form-urlencoded";
            //req.UserAgent = "PostmanRuntime/7.18.0";
            //byte[] data = Encoding.UTF8.GetBytes(str);
            //using (Stream reqStream = req.GetRequestStream()) //获取
            //{
            //    reqStream.Write(data, 0, data.Length);//向当前流中写入字节
            //    reqStream.Close(); //关闭当前流
            //}
            //HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            //Stream stream = resp.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            CRM_DRF_RETURNMSG rst = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_DRF_RETURNMSG>(result);
            return rst;
        }
        public CRM_DRF_RETURNMSG setAuth(string auth, int account)
        {
            string str = "auth=" + auth + "&account=" + account.ToString();
            string result = "";
            Stream stream = apidy("api/setAuth", str, "application/x-www-form-urlencoded");
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            CRM_DRF_RETURNMSG rst = Newtonsoft.Json.JsonConvert.DeserializeObject<CRM_DRF_RETURNMSG>(result);
            return rst;
        }
        public DRF_orders_RETURN orders(List<condition> condition)
        {
            DRF_orders_RETURN rst = new DRF_orders_RETURN();
            string result = "";
            mysql model_mysql = new mysql();
            model_mysql.columns = "*";
            model_mysql.condition = condition;
            string mysql = Newtonsoft.Json.JsonConvert.SerializeObject(model_mysql);
            mysql = "{\"mysql\":" + mysql + "}";
            Stream stream = apidy("api/orders", mysql, "application/json");
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            rst = Newtonsoft.Json.JsonConvert.DeserializeObject<DRF_orders_RETURN>(result);
            return rst;
        }
        public DRF_orders_RETURN ordersDone(List<condition> condition)
        {
            DRF_orders_RETURN rst = new DRF_orders_RETURN();
            string result = "";
            mysql model_mysql = new mysql();
            model_mysql.columns = "*";
            model_mysql.condition = condition;
            string mysql = Newtonsoft.Json.JsonConvert.SerializeObject(model_mysql);
            mysql = "{\"mysql\":" + mysql + "}";
            Stream stream = apidy("api/ordersDone", mysql, "application/json");
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            rst = Newtonsoft.Json.JsonConvert.DeserializeObject<DRF_orders_RETURN>(result);
            return rst;
        }
        public DRF_orders_RETURN ordersData(List<condition> condition)
        {
            DRF_orders_RETURN rst = new DRF_orders_RETURN();
            string result = "";
            mysql model_mysql = new mysql();
            model_mysql.columns = "*";
            model_mysql.condition = condition;
            orderby model_orderby = new orderby();
            model_orderby.name = "orderDataid";
            model_orderby.desc = false;
            model_mysql.orderby = model_orderby;
            string mysql = Newtonsoft.Json.JsonConvert.SerializeObject(model_mysql);
            mysql = "{\"mysql\":" + mysql + "}";
            Stream stream = apidy("api/ordersData", mysql, "application/json");
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            rst = Newtonsoft.Json.JsonConvert.DeserializeObject<DRF_orders_RETURN>(result);
            return rst;
        }
        public DRF_ordersHead_RETUEN ordersHead(List<condition> condition)
        {
            DRF_ordersHead_RETUEN rst = new DRF_ordersHead_RETUEN();
            string result = "";
            mysql model_mysql = new mysql();
            model_mysql.columns = "*";
            model_mysql.condition = condition;

            orderby model_orderby = new orderby();
            model_orderby.name = "ordersHeadid";
            model_orderby.desc = false;
            model_mysql.orderby = model_orderby;

            string mysql = Newtonsoft.Json.JsonConvert.SerializeObject(model_mysql);
            mysql = "{\"mysql\":" + mysql + "}";
            Stream stream = apidy("api/ordersHead", mysql, "application/json");
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            rst = Newtonsoft.Json.JsonConvert.DeserializeObject<DRF_ordersHead_RETUEN>(result);
            return rst;
        }
        public DRF_ordersItem_RETURN ordersItem(List<condition> condition)
        {
            DRF_ordersItem_RETURN rst = new DRF_ordersItem_RETURN();
            string result = "";
            mysql model_mysql = new mysql();
            model_mysql.columns = "*";
            model_mysql.condition = condition;

            orderby model_orderby = new orderby();
            model_orderby.name = "ordersItemid";
            model_orderby.desc = false;
            model_mysql.orderby = model_orderby;


            string mysql = Newtonsoft.Json.JsonConvert.SerializeObject(model_mysql);
            mysql = "{\"mysql\":" + mysql + "}";
            Stream stream = apidy("api/ordersItem", mysql, "application/json");
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            rst = Newtonsoft.Json.JsonConvert.DeserializeObject<DRF_ordersItem_RETURN>(result);
            return rst;
        }

        public DRF_orders_RETURN ordersBasic(List<condition> condition)
        {
            DRF_orders_RETURN rst = new DRF_orders_RETURN();
            string result = "";
            mysql model_mysql = new mysql();
            model_mysql.columns = "*";
            model_mysql.condition = condition;
            orderby model_orderby = new orderby();
            model_orderby.name = "ordersBasicid";
            model_orderby.desc = false;
            model_mysql.orderby = model_orderby;

            string mysql = Newtonsoft.Json.JsonConvert.SerializeObject(model_mysql);
            mysql = "{\"mysql\":" + mysql + "}";
            Stream stream = apidy("api/ordersBasic", mysql, "application/json");
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            rst = Newtonsoft.Json.JsonConvert.DeserializeObject<DRF_orders_RETURN>(result);
            return rst;
        }
        public DRF_ordersItem_RETURN ordersHeadItemJoined(List<condition> condition)
        {
            DRF_ordersItem_RETURN rst = new DRF_ordersItem_RETURN();
            string result = "";
            mysql model_mysql = new mysql();
            model_mysql.columns = "*";
            model_mysql.condition = condition;
            orderby model_orderby = new orderby();
            model_orderby.name = "ordersHeadid";
            model_orderby.desc = false;
            model_mysql.orderby = model_orderby;
            string mysql = Newtonsoft.Json.JsonConvert.SerializeObject(model_mysql);
            mysql = "{\"mysql\":" + mysql + "}";
            Stream stream = apidy("api/ordersHeadItemJoined", mysql, "application/json");
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            rst = Newtonsoft.Json.JsonConvert.DeserializeObject<DRF_ordersItem_RETURN>(result);
            return rst;
        }
        public DRF_LATEST_RETURN latest()
        {
            string str = "";
            string result = "";
            Stream stream = apidy("api/latest", str, "application/x-www-form-urlencoded");
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            DRF_LATEST_RETURN rst = Newtonsoft.Json.JsonConvert.DeserializeObject<DRF_LATEST_RETURN>(result);
            return rst;
        }
        public byte[] downloadPDF(string PDFPATH, string map)
        {
            byte[] arrFile = null;
            if (PDFPATH != "")
            {
                try
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(DRFSERVICE + "api/downloadItem");
                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded";
                    req.UserAgent = "PostmanRuntime/7.18.0";
                    string mysql = "fileName=" + PDFPATH;
                    byte[] data = Encoding.UTF8.GetBytes(mysql);
                    using (Stream reqStream = req.GetRequestStream()) //获取
                    {
                        reqStream.Write(data, 0, data.Length);//向当前流中写入字节
                        reqStream.Close(); //关闭当前流
                    }
                    HttpWebResponse response = req.GetResponse() as HttpWebResponse;
                    Stream stream = response.GetResponseStream();
                    int length = (int)response.ContentLength;
                    BinaryReader br = new BinaryReader(stream);
                    string filename = "";
                    filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + PDFPATH;
                    if (filename == "")
                    {
                        filename = "export";
                    }
                    FileStream fs = File.Create(map + "\\" + filename + ".pdf");
                    fs.Write(br.ReadBytes(length), 0, length);
                    br.Close();
                    fs.Close();

                    using (FileStream fs1 = new FileStream(map + "\\" + filename + ".pdf", FileMode.Open))
                    {
                        arrFile = new byte[fs1.Length];
                        fs1.Read(arrFile, 0, arrFile.Length);
                    }
                    File.Delete(map + "\\" + filename + ".pdf");
                }
                catch (Exception)
                {
                    throw;
                }

            }
            return arrFile;
        }

        public byte[] SCREENSHOT(int shotlb, string map)
        {
            byte[] arrFile = null;
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(DRFSERVICE + "screenshot" + shotlb.ToString() + ".png");
                req.Method = "GET";
                req.UserAgent = "PostmanRuntime/7.18.0";
                HttpWebResponse response = req.GetResponse() as HttpWebResponse;
                Stream stream = response.GetResponseStream();
                int length = (int)response.ContentLength;
                BinaryReader br = new BinaryReader(stream);
                string filename = "";
                filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + shotlb.ToString();
                if (filename == "")
                {
                    filename = "export" + shotlb.ToString();
                }
                FileStream fs = File.Create(map + "\\" + filename + ".png");
                fs.Write(br.ReadBytes(length), 0, length);
                br.Close();
                fs.Close();

                using (FileStream fs1 = new FileStream(map + "\\" + filename + ".png", FileMode.Open))
                {
                    arrFile = new byte[fs1.Length];
                    fs1.Read(arrFile, 0, arrFile.Length);
                }
                File.Delete(map + "\\" + filename + ".png");
            }
            catch (Exception)
            {
                throw;
            }
            return arrFile;
        }



        public Stream apidy(string apihsm, string mysql, string ContentType)
        {
            Thread.Sleep(20);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(DRFSERVICE + apihsm);
            req.Method = "POST";
            req.ContentType = ContentType;
            req.UserAgent = "PostmanRuntime/7.18.0";
            byte[] data = Encoding.UTF8.GetBytes(mysql);
            using (Stream reqStream = req.GetRequestStream()) //获取
            {
                reqStream.Write(data, 0, data.Length);//向当前流中写入字节
                reqStream.Close(); //关闭当前流
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            return stream;
        }




        public MES_RETURN SYNC_DRFBILL()
        {
            MES_RETURN rst = new MES_RETURN();
            try
            {
                try
                {
                    DRFBILL_AUTO_ISUSER();
                }
                catch (Exception)
                {
                }
                string rststring = "";
                CRM_ORDER_DRF_USER model_CRM_ORDER_DRF_USER = new CRM_ORDER_DRF_USER();
                model_CRM_ORDER_DRF_USER.LB = 1;
                model_CRM_ORDER_DRF_USER.USERACCOUNT = -1;
                CRM_ORDER_DRF_USER_SELECT rst_CRM_ORDER_DRF_USER_SELECT = IORDER_TT_data.SELECT_USER_SYNC(model_CRM_ORDER_DRF_USER);
                int isyx = 0;
                if (rst_CRM_ORDER_DRF_USER_SELECT.MES_RETURN.TYPE == "S")
                {
                    for (int a = 0; a < rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER.Count; a++)
                    {
                        CRM_DRF_RETURNMSG model_CRM_DRF_RETURNMSG = status(rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[a].USERACCOUNT);
                        rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[a].DATAINT = model_CRM_DRF_RETURNMSG.Data;
                        rststring = rststring + "/" + rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[a].USERACCOUNT.ToString() + model_CRM_DRF_RETURNMSG.Data.ToString();
                        if (model_CRM_DRF_RETURNMSG.Data != 0 && model_CRM_DRF_RETURNMSG.Data != 6)
                        {
                            isyx = isyx + 1;
                        }
                    }
                }
                if (rst_CRM_ORDER_DRF_USER_SELECT.MES_RETURN.TYPE != "S")
                {
                    return rst_CRM_ORDER_DRF_USER_SELECT.MES_RETURN;
                }
                for (int e = 0; e < rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER.Count; e++)
                {
                    if (rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[e].DATAINT == 0 || rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[e].DATAINT == 6)
                    {
                        string orderid = ISY_SYSCSdata.SELECT("orderid_" + rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[e].USERACCOUNT.ToString());
                        if (orderid == "0")
                        {
                            orderid = ISY_SYSCSdata.SELECT("orderid");
                        }
                        List<condition> model_condition_list = new List<condition>();
                        condition model_condition = new condition();
                        model_condition.name = "ordersHeadid";
                        model_condition.op = ">";
                        model_condition.value = orderid;
                        model_condition_list.Add(model_condition);
                        //model_condition = new condition();
                        //model_condition.name = "ordersHeadid";
                        //model_condition.op = "<=";
                        //model_condition.value = (Convert.ToInt32(orderid) + 40).ToString();
                        //model_condition_list.Add(model_condition);
                        model_condition = new condition();
                        model_condition.name = "account";
                        model_condition.op = "=";
                        model_condition.value = rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[e].USERNAME;
                        model_condition_list.Add(model_condition);
                        DRF_ordersHead_RETUEN rst_DRF_ordersHead_RETUEN = ordersHead(model_condition_list);
                        if (rst_DRF_ordersHead_RETUEN.error == false)
                        {
                            int ordersHeadid = 0;
                            for (int a = 0; a < rst_DRF_ordersHead_RETUEN.data.Count; a++)
                            {
                                if (ordersHeadid != rst_DRF_ordersHead_RETUEN.data[a].ordersHeadid)
                                {
                                    int OrderST = 0;
                                    ordersHeadid = rst_DRF_ordersHead_RETUEN.data[a].ordersHeadid;

                                    model_condition_list = new List<condition>();
                                    model_condition = new condition();
                                    model_condition.name = "OrderNum";
                                    model_condition.op = "=";
                                    model_condition.value = rst_DRF_ordersHead_RETUEN.data[a].OrderNum;
                                    model_condition_list.Add(model_condition);
                                    model_condition = new condition();
                                    model_condition.name = "StoreNum";
                                    model_condition.op = "=";
                                    model_condition.value = rst_DRF_ordersHead_RETUEN.data[a].StoreNum;
                                    model_condition_list.Add(model_condition);
                                    model_condition = new condition();
                                    model_condition.name = "account";
                                    model_condition.op = "=";
                                    model_condition.value = rst_DRF_ordersHead_RETUEN.data[a].account;
                                    model_condition_list.Add(model_condition);
                                    DRF_ordersItem_RETURN rst_DRF_ordersItem_RETURN = ordersItem(model_condition_list);

                                    if (string.IsNullOrEmpty(rst_DRF_ordersHead_RETUEN.data[a].account))
                                    {
                                        ISY_EXCEPTIONdata.INSERT_ALL("OrdersHeadid:" + rst_DRF_ordersHead_RETUEN.data[a].ordersHeadid.ToString() + " 订单数据有问题！请检查", "SYNC_DRFBILL", rst_DRF_ordersHead_RETUEN.data[a].ordersHeadid.ToString(), "DRF");
                                        ISY_SYSCSdata.UPDATE_SYNC("orderid_" + rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[e].USERACCOUNT.ToString(), ordersHeadid.ToString());
                                    }
                                    else
                                    {
                                        CRM_ORDER_TT model_CRM_ORDER_TT = new CRM_ORDER_TT();
                                        model_CRM_ORDER_TT.OrderSrc2 = 2336;
                                        model_CRM_ORDER_TT.KHPO = rst_DRF_ordersHead_RETUEN.data[a].OrderNum.ToString();
                                        model_CRM_ORDER_TT.StoreNum = Convert.ToInt32(rst_DRF_ordersHead_RETUEN.data[a].StoreNum).ToString();
                                        model_CRM_ORDER_TT.CJZH = rst_DRF_ordersHead_RETUEN.data[a].account;
                                        List<CRM_ORDER_TT> rst_CRM_ORDER_TT_LIST = IORDER_TT_data.ReadTTbyParam(model_CRM_ORDER_TT, 0, 0, 0).ToList();
                                        if (rst_CRM_ORDER_TT_LIST.Count == 0)
                                        {
                                            CRM_HG_DICT model_CRM_HG_DICT = new CRM_HG_DICT();
                                            model_CRM_HG_DICT.FID = 2336;
                                            model_CRM_HG_DICT.DICMEMO = rst_DRF_ordersHead_RETUEN.data[a].account;
                                            List<CRM_HG_DICT> rst_CRM_HG_DICT_LIST = IHG_DICTdata.ReadByParam(model_CRM_HG_DICT, 0).ToList();
                                            if (rst_CRM_HG_DICT_LIST.Count > 0)
                                            {
                                                model_CRM_ORDER_TT = new CRM_ORDER_TT();
                                                model_CRM_ORDER_TT.DDLX = 1233;
                                                model_CRM_ORDER_TT.OrderSrc = rst_CRM_HG_DICT_LIST[0].DICID;
                                                model_CRM_ORDER_TT.KHPO = rst_DRF_ordersHead_RETUEN.data[a].OrderNum;
                                                if (rst_DRF_ordersItem_RETURN.error == false)
                                                {
                                                    if (rst_DRF_ordersItem_RETURN.data.Count > 0)
                                                    {
                                                        if (rst_DRF_ordersItem_RETURN.data[0].OrderActual != "")
                                                        {
                                                            model_CRM_ORDER_TT.OrderST = 2;
                                                        }
                                                        else
                                                        {
                                                            model_CRM_ORDER_TT.OrderST = 1;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        model_CRM_ORDER_TT.OrderST = 1;
                                                    }
                                                }
                                                else
                                                {
                                                    model_CRM_ORDER_TT.OrderST = 1;
                                                }

                                                OrderST = model_CRM_ORDER_TT.OrderST;

                                                model_condition_list = new List<condition>();
                                                model_condition = new condition();
                                                model_condition.name = "orderNum";
                                                model_condition.op = "=";
                                                model_condition.value = rst_DRF_ordersHead_RETUEN.data[a].OrderNum;
                                                model_condition_list.Add(model_condition);
                                                model_condition = new condition();
                                                model_condition.name = "storeNum";
                                                model_condition.op = "=";
                                                model_condition.value = rst_DRF_ordersHead_RETUEN.data[a].StoreNum;
                                                model_condition_list.Add(model_condition);
                                                model_condition = new condition();
                                                model_condition.name = "account";
                                                model_condition.op = "=";
                                                model_condition.value = rst_DRF_ordersHead_RETUEN.data[a].account;
                                                model_condition_list.Add(model_condition);
                                                DRF_orders_RETURN rst_DRF_orders_RETURN = ordersData(model_condition_list);
                                                if (rst_DRF_orders_RETURN.error == false)
                                                {
                                                    if (rst_DRF_orders_RETURN.data.Count > 0)
                                                    {
                                                        model_CRM_ORDER_TT.PDFPATH = rst_DRF_orders_RETURN.data[rst_DRF_orders_RETURN.data.Count - 1].pdfPath;
                                                    }
                                                    else
                                                    {
                                                        model_CRM_ORDER_TT.PDFPATH = "";
                                                    }
                                                }
                                                else
                                                {
                                                    model_CRM_ORDER_TT.PDFPATH = "";
                                                }


                                                model_CRM_ORDER_TT.StoreNum = Convert.ToInt32(rst_DRF_ordersHead_RETUEN.data[a].StoreNum).ToString();
                                                model_CRM_ORDER_TT.KHNAME = rst_DRF_ordersHead_RETUEN.data[a].StoreName;
                                                model_CRM_ORDER_TT.SHIPADD = rst_DRF_ordersHead_RETUEN.data[a].StoreAddr;
                                                model_CRM_ORDER_TT.TEL = rst_DRF_ordersHead_RETUEN.data[a].StoreTel;
                                                model_CRM_ORDER_TT.StoreFax = rst_DRF_ordersHead_RETUEN.data[a].StoreFax;
                                                model_CRM_ORDER_TT.OrderDate = rst_DRF_ordersHead_RETUEN.data[a].OrderDate;
                                                model_CRM_ORDER_TT.DeliveryDate = rst_DRF_ordersHead_RETUEN.data[a].DeliveryDate;
                                                model_CRM_ORDER_TT.StoreNews = rst_DRF_ordersHead_RETUEN.data[a].StoreNews;
                                                model_CRM_ORDER_TT.BEIZ = rst_DRF_ordersHead_RETUEN.data[a].Remark;
                                                model_CRM_ORDER_TT.CJZH = rst_DRF_ordersHead_RETUEN.data[a].account;
                                                model_CRM_ORDER_TT.ISACTIVE = 10;

                                                //model_CRM_ORDER_TT.PAY = Convert.ToDouble(rst_DRF_ordersItem_RETURN.data[a].OrderAmount);

                                                model_condition_list = new List<condition>();
                                                model_condition = new condition();
                                                model_condition.name = "OrderNum";
                                                model_condition.op = "=";
                                                model_condition.value = rst_DRF_ordersHead_RETUEN.data[a].OrderNum;
                                                model_condition_list.Add(model_condition);
                                                model_condition = new condition();
                                                model_condition.name = "StoreNum";
                                                model_condition.op = "=";
                                                model_condition.value = rst_DRF_ordersHead_RETUEN.data[a].StoreNum;
                                                model_condition_list.Add(model_condition);
                                                model_condition = new condition();
                                                model_condition.name = "account";
                                                model_condition.op = "=";
                                                model_condition.value = rst_DRF_ordersHead_RETUEN.data[a].account;
                                                model_condition_list.Add(model_condition);
                                                DRF_orders_RETURN model_DRF_orders_RETURN = ordersBasic(model_condition_list);
                                                if (model_DRF_orders_RETURN.error == false)
                                                {
                                                    if (model_DRF_orders_RETURN.data.Count > 0)
                                                    {
                                                        model_CRM_ORDER_TT.PAY = Convert.ToDouble(model_DRF_orders_RETURN.data[model_DRF_orders_RETURN.data.Count - 1].OrderAmount);
                                                    }
                                                    else
                                                    {
                                                        CRM_ORDER_DRF_SYNC_TD model_CRM_ORDER_DRF_SYNC_TD = new CRM_ORDER_DRF_SYNC_TD();
                                                        model_CRM_ORDER_DRF_SYNC_TD.ACCOUNT = rst_DRF_ordersHead_RETUEN.data[a].account;
                                                        model_CRM_ORDER_DRF_SYNC_TD.ORDERNUM = rst_DRF_ordersHead_RETUEN.data[a].OrderNum;
                                                        model_CRM_ORDER_DRF_SYNC_TD.STORENUM = rst_DRF_ordersHead_RETUEN.data[a].StoreNum;
                                                        model_CRM_ORDER_DRF_SYNC_TD.LBNAME = "ORDERAMOUNT";
                                                        CRM_ORDER_DRF_SYNC_TD_SELECT rst_CRM_ORDER_DRF_SYNC_TD_SELECT = IORDER_TT_data.SELECT_DRF_SYNC_TD(model_CRM_ORDER_DRF_SYNC_TD);
                                                        if (rst_CRM_ORDER_DRF_SYNC_TD_SELECT.MES_RETURN.TYPE != "S")
                                                        {
                                                            rst.TYPE = "E";
                                                            rst.MESSAGE = "account:" + rst_DRF_ordersHead_RETUEN.data[a].account + "/OrderNum:" + rst_DRF_ordersHead_RETUEN.data[a].OrderNum + "/storeNum:" + rst_DRF_ordersHead_RETUEN.data[a].StoreNum + " OrderAmount is null";
                                                            return rst;
                                                        }
                                                        else
                                                        {
                                                            if (rst_CRM_ORDER_DRF_SYNC_TD_SELECT.CRM_ORDER_DRF_SYNC_TD.Count > 0)
                                                            {
                                                                model_CRM_ORDER_TT.PAY = Convert.ToDouble(rst_CRM_ORDER_DRF_SYNC_TD_SELECT.CRM_ORDER_DRF_SYNC_TD[0].TD);
                                                            }
                                                            else
                                                            {
                                                                //rst.TYPE = "E";
                                                                //rst.MESSAGE = "account:" + rst_DRF_ordersHead_RETUEN.data[a].account + "/OrderNum:" + rst_DRF_ordersHead_RETUEN.data[a].OrderNum + "/storeNum:" + rst_DRF_ordersHead_RETUEN.data[a].StoreNum + " OrderAmount is null";
                                                                //return rst;
                                                                ISY_EXCEPTIONdata.INSERT_ALL("account:" + rst_DRF_ordersHead_RETUEN.data[a].account + "/OrderNum:" + rst_DRF_ordersHead_RETUEN.data[a].OrderNum + "/storeNum:" + rst_DRF_ordersHead_RETUEN.data[a].StoreNum + " OrderAmount is null", "SYNC_DRFBILL", rst_DRF_ordersHead_RETUEN.data[a].ordersHeadid.ToString(), "DRF");
                                                                model_CRM_ORDER_TT.PAY = 0;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    rst.TYPE = "E";
                                                    rst.MESSAGE = "account:" + rst_DRF_ordersHead_RETUEN.data[a].account + "/OrderNum:" + rst_DRF_ordersHead_RETUEN.data[a].OrderNum + "/storeNum:" + rst_DRF_ordersHead_RETUEN.data[a].StoreNum + " OrderAmount is null";
                                                    return rst;
                                                }

                                                int ttid = IORDER_TT_data.CreateTT(model_CRM_ORDER_TT);
                                                int hxm = 0;
                                                string orderitemtime = "";

                                                if (rst_DRF_ordersItem_RETURN.data.Count > 0)
                                                {
                                                    for (int b = 0; b < rst_DRF_ordersItem_RETURN.data.Count; b++)
                                                    {
                                                        if (orderitemtime == "")
                                                        {
                                                            orderitemtime = rst_DRF_ordersItem_RETURN.data[b].itemTime;
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToDateTime(orderitemtime) < Convert.ToDateTime(rst_DRF_ordersItem_RETURN.data[b].itemTime))
                                                            {
                                                                orderitemtime = rst_DRF_ordersItem_RETURN.data[b].itemTime;
                                                            }
                                                        }
                                                    }

                                                    for (int b = 0; b < rst_DRF_ordersItem_RETURN.data.Count; b++)
                                                    {
                                                        if (orderitemtime == "")
                                                        {
                                                            orderitemtime = rst_DRF_ordersItem_RETURN.data[b].itemTime;
                                                        }
                                                        TimeSpan ts = Convert.ToDateTime(orderitemtime) - Convert.ToDateTime(rst_DRF_ordersItem_RETURN.data[b].itemTime);
                                                        if (ts.TotalSeconds <= 60)
                                                        {
                                                            CRM_ORDER_DRF_SYNC model_CRM_ORDER_DRF_SYNC = new CRM_ORDER_DRF_SYNC();
                                                            model_CRM_ORDER_DRF_SYNC.ORDERTTID = ttid;
                                                            model_CRM_ORDER_DRF_SYNC.ACCOUNT = rst_DRF_ordersItem_RETURN.data[b].account;
                                                            model_CRM_ORDER_DRF_SYNC.STORENUM = Convert.ToInt32(rst_DRF_ordersItem_RETURN.data[b].StoreNum).ToString();
                                                            model_CRM_ORDER_DRF_SYNC.ORDERNUM = rst_DRF_ordersItem_RETURN.data[b].OrderNum;
                                                            model_CRM_ORDER_DRF_SYNC.BARCODE = rst_DRF_ordersItem_RETURN.data[b].BarCode;
                                                            model_CRM_ORDER_DRF_SYNC.PRODNUM = rst_DRF_ordersItem_RETURN.data[b].ProdNum;
                                                            model_CRM_ORDER_DRF_SYNC.PRODNAME = rst_DRF_ordersItem_RETURN.data[b].ProdName;
                                                            model_CRM_ORDER_DRF_SYNC.PRODSPEC = rst_DRF_ordersItem_RETURN.data[b].ProdSpec;
                                                            model_CRM_ORDER_DRF_SYNC.ORDERUNIT = rst_DRF_ordersItem_RETURN.data[b].OrderUnit;
                                                            model_CRM_ORDER_DRF_SYNC.ORDERACTUAL = rst_DRF_ordersItem_RETURN.data[b].OrderActual;
                                                            model_CRM_ORDER_DRF_SYNC.QUANTITY = rst_DRF_ordersItem_RETURN.data[b].Quantity;
                                                            model_CRM_ORDER_DRF_SYNC.REMARK = rst_DRF_ordersItem_RETURN.data[b].Remark;
                                                            model_CRM_ORDER_DRF_SYNC.ITEMTIME = rst_DRF_ordersItem_RETURN.data[b].itemTime;
                                                            IORDER_TT_data.INSERT_DRF_SYNC(model_CRM_ORDER_DRF_SYNC);
                                                        }

                                                    }

                                                    for (int b = 0; b < rst_DRF_ordersItem_RETURN.data.Count; b++)
                                                    {
                                                        try
                                                        {


                                                            if (orderitemtime == "")
                                                            {
                                                                orderitemtime = rst_DRF_ordersItem_RETURN.data[b].itemTime;
                                                            }
                                                            TimeSpan ts = Convert.ToDateTime(orderitemtime) - Convert.ToDateTime(rst_DRF_ordersItem_RETURN.data[b].itemTime);
                                                            if (ts.TotalSeconds <= 60)
                                                            {
                                                                CRM_ORDER_MX model_CRM_ORDER_MX = new CRM_ORDER_MX();
                                                                model_CRM_ORDER_MX.ORDERTTID = ttid;
                                                                model_CRM_ORDER_MX.StoreNum = Convert.ToInt32(rst_DRF_ordersItem_RETURN.data[b].StoreNum).ToString();
                                                                model_CRM_ORDER_MX.KHPO = rst_DRF_ordersItem_RETURN.data[b].OrderNum;
                                                                model_CRM_ORDER_MX.OrderItem = ((hxm + 1) * 10).ToString();
                                                                model_CRM_ORDER_MX.BarCode = rst_DRF_ordersItem_RETURN.data[b].BarCode;
                                                                model_CRM_ORDER_MX.ProdNum = rst_DRF_ordersItem_RETURN.data[b].ProdNum;
                                                                model_CRM_ORDER_MX.ProdName = rst_DRF_ordersItem_RETURN.data[b].ProdName;
                                                                model_CRM_ORDER_MX.ProdSpec = rst_DRF_ordersItem_RETURN.data[b].ProdSpec;
                                                                model_CRM_ORDER_MX.OrderUnit = rst_DRF_ordersItem_RETURN.data[b].OrderUnit;
                                                                model_CRM_ORDER_MX.BEIZ = rst_DRF_ordersItem_RETURN.data[b].Remark;
                                                                if (OrderST == 1)
                                                                {

                                                                    string[] str = rst_DRF_ordersItem_RETURN.data[b].Quantity.Replace("（", "(").Split('(');
                                                                    if (str.Length > 0)
                                                                    {
                                                                        model_CRM_ORDER_MX.DDSL = Convert.ToInt32(str[0]);
                                                                    }
                                                                    else
                                                                    {
                                                                        model_CRM_ORDER_MX.DDSL = Convert.ToInt32(rst_DRF_ordersItem_RETURN.data[b].Quantity);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    string[] str = rst_DRF_ordersItem_RETURN.data[b].OrderActual.Replace("（", "(").Split('(');
                                                                    if (str.Length > 0)
                                                                    {
                                                                        model_CRM_ORDER_MX.DDSL = Convert.ToInt32(str[0]);
                                                                    }
                                                                    else
                                                                    {
                                                                        model_CRM_ORDER_MX.DDSL = Convert.ToInt32(rst_DRF_ordersItem_RETURN.data[b].OrderActual);
                                                                    }
                                                                }
                                                                model_CRM_ORDER_MX.ISACTIVE = 1;
                                                                int mxid = IORDER_TT_data.CreateMX(model_CRM_ORDER_MX);
                                                                hxm = hxm + 1;
                                                            }

                                                        }
                                                        catch
                                                        {
                                                            ISY_EXCEPTIONdata.INSERT_ALL("OrdersHeadid:" + rst_DRF_ordersHead_RETUEN.data[a].ordersHeadid.ToString() + " 订单数据有问题！请检查", "SYNC_DRFBILL", rst_DRF_ordersHead_RETUEN.data[a].ordersHeadid.ToString(), "DRF");
                                                            ISY_SYSCSdata.UPDATE_SYNC("orderid_" + rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[e].USERACCOUNT.ToString(), ordersHeadid.ToString());
                                                            rst.TYPE = "E";
                                                            rst.MESSAGE = "account:" + rst_DRF_ordersHead_RETUEN.data[a].account + "/OrderNum:" + rst_DRF_ordersHead_RETUEN.data[a].OrderNum + "/storeNum:" + rst_DRF_ordersHead_RETUEN.data[a].StoreNum + "  is error";
                                                            model_CRM_ORDER_TT = new CRM_ORDER_TT();
                                                            model_CRM_ORDER_TT.ORDERTTID = ttid;
                                                            rst_CRM_ORDER_TT_LIST = IORDER_TT_data.ReadTTbyParam(model_CRM_ORDER_TT, 0, 0, 0).ToList();
                                                            if (rst_CRM_ORDER_TT_LIST.Count == 1)
                                                            {
                                                                rst_CRM_ORDER_TT_LIST[0].OrderST = 5;
                                                                IORDER_TT_data.UpdateTT(rst_CRM_ORDER_TT_LIST[0]);
                                                            }
                                                            return rst;
                                                        }
                                                    }
                                                }
                                                ISY_SYSCSdata.UPDATE_SYNC("orderid_" + rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[e].USERACCOUNT.ToString(), ordersHeadid.ToString());
                                            }
                                            else
                                            {
                                                rst.TYPE = "E";
                                                rst.MESSAGE = "account:" + rst_DRF_ordersHead_RETUEN.data[a].account + "is nonentity";
                                                return rst;
                                            }
                                        }
                                        else
                                        {
                                            for (int b = 0; b < rst_CRM_ORDER_TT_LIST.Count; b++)
                                            {
                                                rst_CRM_ORDER_TT_LIST[b].StoreNews = rst_DRF_ordersHead_RETUEN.data[a].StoreNews;
                                                rst_CRM_ORDER_TT_LIST[b].BEIZ = rst_DRF_ordersHead_RETUEN.data[a].Remark;

                                                //rst_CRM_ORDER_TT_LIST[b].PAY = Convert.ToDouble(rst_DRF_ordersItem_RETURN.data[a].OrderAmount);
                                                model_condition_list = new List<condition>();
                                                model_condition = new condition();
                                                model_condition.name = "OrderNum";
                                                model_condition.op = "=";
                                                model_condition.value = rst_DRF_ordersHead_RETUEN.data[a].OrderNum;
                                                model_condition_list.Add(model_condition);
                                                model_condition = new condition();
                                                model_condition.name = "StoreNum";
                                                model_condition.op = "=";
                                                model_condition.value = rst_DRF_ordersHead_RETUEN.data[a].StoreNum;
                                                model_condition_list.Add(model_condition);
                                                model_condition = new condition();
                                                model_condition.name = "account";
                                                model_condition.op = "=";
                                                model_condition.value = rst_DRF_ordersHead_RETUEN.data[a].account;
                                                model_condition_list.Add(model_condition);
                                                DRF_orders_RETURN model_DRF_orders_RETURN = ordersBasic(model_condition_list);
                                                if (model_DRF_orders_RETURN.error == false)
                                                {
                                                    if (model_DRF_orders_RETURN.data.Count > 0)
                                                    {
                                                        rst_CRM_ORDER_TT_LIST[b].PAY = Convert.ToDouble(model_DRF_orders_RETURN.data[model_DRF_orders_RETURN.data.Count - 1].OrderAmount);
                                                    }
                                                    else
                                                    {
                                                        //rst.TYPE = "E";
                                                        //rst.MESSAGE = "account:" + rst_DRF_ordersHead_RETUEN.data[a].account + "/OrderNum:" + rst_DRF_ordersHead_RETUEN.data[a].OrderNum + "/storeNum:" + rst_DRF_ordersHead_RETUEN.data[a].StoreNum + " OrderAmount is null";
                                                        //return rst;
                                                        CRM_ORDER_DRF_SYNC_TD model_CRM_ORDER_DRF_SYNC_TD = new CRM_ORDER_DRF_SYNC_TD();
                                                        model_CRM_ORDER_DRF_SYNC_TD.ACCOUNT = rst_DRF_ordersHead_RETUEN.data[a].account;
                                                        model_CRM_ORDER_DRF_SYNC_TD.ORDERNUM = rst_DRF_ordersHead_RETUEN.data[a].OrderNum;
                                                        model_CRM_ORDER_DRF_SYNC_TD.STORENUM = rst_DRF_ordersHead_RETUEN.data[a].StoreNum;
                                                        model_CRM_ORDER_DRF_SYNC_TD.LBNAME = "ORDERAMOUNT";
                                                        CRM_ORDER_DRF_SYNC_TD_SELECT rst_CRM_ORDER_DRF_SYNC_TD_SELECT = IORDER_TT_data.SELECT_DRF_SYNC_TD(model_CRM_ORDER_DRF_SYNC_TD);
                                                        if (rst_CRM_ORDER_DRF_SYNC_TD_SELECT.MES_RETURN.TYPE != "S")
                                                        {
                                                            rst.TYPE = "E";
                                                            rst.MESSAGE = "account:" + rst_DRF_ordersHead_RETUEN.data[a].account + "/OrderNum:" + rst_DRF_ordersHead_RETUEN.data[a].OrderNum + "/storeNum:" + rst_DRF_ordersHead_RETUEN.data[a].StoreNum + " OrderAmount is null";
                                                            return rst;
                                                        }
                                                        else
                                                        {
                                                            if (rst_CRM_ORDER_DRF_SYNC_TD_SELECT.CRM_ORDER_DRF_SYNC_TD.Count > 0)
                                                            {
                                                                model_CRM_ORDER_TT.PAY = Convert.ToDouble(rst_CRM_ORDER_DRF_SYNC_TD_SELECT.CRM_ORDER_DRF_SYNC_TD[0].TD);
                                                            }
                                                            else
                                                            {
                                                                //rst.TYPE = "E";
                                                                //rst.MESSAGE = "account:" + rst_DRF_ordersHead_RETUEN.data[a].account + "/OrderNum:" + rst_DRF_ordersHead_RETUEN.data[a].OrderNum + "/storeNum:" + rst_DRF_ordersHead_RETUEN.data[a].StoreNum + " OrderAmount is null";
                                                                //return rst;
                                                                ISY_EXCEPTIONdata.INSERT_ALL("account:" + rst_DRF_ordersHead_RETUEN.data[a].account + "/OrderNum:" + rst_DRF_ordersHead_RETUEN.data[a].OrderNum + "/storeNum:" + rst_DRF_ordersHead_RETUEN.data[a].StoreNum + " OrderAmount is null", "SYNC_DRFBILL", rst_DRF_ordersHead_RETUEN.data[a].ordersHeadid.ToString(), "DRF");
                                                                model_CRM_ORDER_TT.PAY = 0;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    rst.TYPE = "E";
                                                    rst.MESSAGE = "account:" + rst_DRF_ordersHead_RETUEN.data[a].account + "/OrderNum:" + rst_DRF_ordersHead_RETUEN.data[a].OrderNum + "/storeNum:" + rst_DRF_ordersHead_RETUEN.data[a].StoreNum + " OrderAmount is null";
                                                    return rst;
                                                }

                                                int orderst = 0;
                                                model_condition_list = new List<condition>();
                                                model_condition = new condition();
                                                model_condition.name = "orderNum";
                                                model_condition.op = "=";
                                                model_condition.value = rst_DRF_ordersHead_RETUEN.data[a].OrderNum;
                                                model_condition_list.Add(model_condition);
                                                model_condition = new condition();
                                                model_condition.name = "storeNum";
                                                model_condition.op = "=";
                                                model_condition.value = rst_DRF_ordersHead_RETUEN.data[a].StoreNum;
                                                model_condition_list.Add(model_condition);
                                                model_condition = new condition();
                                                model_condition.name = "account";
                                                model_condition.op = "=";
                                                model_condition.value = rst_DRF_ordersHead_RETUEN.data[a].account;
                                                model_condition_list.Add(model_condition);
                                                DRF_orders_RETURN rst_DRF_orders_RETURN = ordersData(model_condition_list);
                                                if (rst_DRF_orders_RETURN.error == false)
                                                {
                                                    if (rst_DRF_orders_RETURN.data.Count > 0)
                                                    {
                                                        rst_CRM_ORDER_TT_LIST[b].PDFPATH = rst_DRF_orders_RETURN.data[rst_DRF_orders_RETURN.data.Count - 1].pdfPath;
                                                    }
                                                    else
                                                    {
                                                        rst_CRM_ORDER_TT_LIST[b].PDFPATH = "";
                                                    }
                                                }
                                                else
                                                {
                                                    rst_CRM_ORDER_TT_LIST[b].PDFPATH = "";
                                                }


                                                if (rst_DRF_ordersItem_RETURN.error == false)
                                                {
                                                    string orderitemtime = "";
                                                    for (int c = 0; c < rst_DRF_ordersItem_RETURN.data.Count; c++)
                                                    {
                                                        if (orderitemtime == "")
                                                        {
                                                            orderitemtime = rst_DRF_ordersItem_RETURN.data[c].itemTime;
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToDateTime(orderitemtime) < Convert.ToDateTime(rst_DRF_ordersItem_RETURN.data[c].itemTime))
                                                            {
                                                                orderitemtime = rst_DRF_ordersItem_RETURN.data[c].itemTime;
                                                            }
                                                        }
                                                    }
                                                    int hxm = 0;
                                                    int itemcount = 0;
                                                    for (int c = 0; c < rst_DRF_ordersItem_RETURN.data.Count; c++)
                                                    {
                                                        if (orderitemtime == "")
                                                        {
                                                            orderitemtime = rst_DRF_ordersItem_RETURN.data[c].itemTime;
                                                        }
                                                        TimeSpan ts = Convert.ToDateTime(orderitemtime) - Convert.ToDateTime(rst_DRF_ordersItem_RETURN.data[c].itemTime);
                                                        if (ts.TotalSeconds <= 60)
                                                        {
                                                            itemcount = itemcount + 1;
                                                        }
                                                    }


                                                    CRM_ORDER_DRF_SYNC model_CRM_ORDER_DRF_SYNC = new CRM_ORDER_DRF_SYNC();
                                                    model_CRM_ORDER_DRF_SYNC.ORDERTTID = rst_CRM_ORDER_TT_LIST[b].ORDERTTID;
                                                    CRM_ORDER_DRF_SYNC_SELECT rst_CRM_ORDER_DRF_SYNC_SELECT = IORDER_TT_data.SELECT_DRF_SYNC(model_CRM_ORDER_DRF_SYNC);
                                                    if (rst_CRM_ORDER_DRF_SYNC_SELECT.MES_RETURN.TYPE == "S")
                                                    {
                                                        if (rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC.Count == itemcount)
                                                        {
                                                            int errorcount = 0;
                                                            for (int c = 0; c < rst_DRF_ordersItem_RETURN.data.Count; c++)
                                                            {
                                                                if (orderitemtime == "")
                                                                {
                                                                    orderitemtime = rst_DRF_ordersItem_RETURN.data[c].itemTime;
                                                                }
                                                                TimeSpan ts = Convert.ToDateTime(orderitemtime) - Convert.ToDateTime(rst_DRF_ordersItem_RETURN.data[c].itemTime);
                                                                if (ts.TotalSeconds <= 60)
                                                                {
                                                                    for (int d = 0; d < rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC.Count; d++)
                                                                    {
                                                                        if (rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC[d].PRODNUM == rst_DRF_ordersItem_RETURN.data[c].ProdNum)
                                                                        {
                                                                            if (rst_DRF_ordersItem_RETURN.data[c].OrderActual == "")
                                                                            {
                                                                                if (rst_DRF_ordersItem_RETURN.data[c].Quantity != rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC[d].QUANTITY)
                                                                                {
                                                                                    errorcount = errorcount + 1;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (rst_DRF_ordersItem_RETURN.data[c].OrderActual != rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC[d].ORDERACTUAL)
                                                                                {
                                                                                    errorcount = errorcount + 1;
                                                                                }

                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            if (errorcount != 0)
                                                            {
                                                                model_CRM_ORDER_DRF_SYNC = new CRM_ORDER_DRF_SYNC();
                                                                model_CRM_ORDER_DRF_SYNC.ORDERTTID = rst_CRM_ORDER_TT_LIST[b].ORDERTTID;
                                                                model_CRM_ORDER_DRF_SYNC.LB = 1;
                                                                IORDER_TT_data.UPDATE_DRF_SYNC(model_CRM_ORDER_DRF_SYNC);
                                                                for (int c = 0; c < rst_DRF_ordersItem_RETURN.data.Count; c++)
                                                                {
                                                                    if (orderitemtime == "")
                                                                    {
                                                                        orderitemtime = rst_DRF_ordersItem_RETURN.data[c].itemTime;
                                                                    }
                                                                    TimeSpan ts = Convert.ToDateTime(orderitemtime) - Convert.ToDateTime(rst_DRF_ordersItem_RETURN.data[c].itemTime);
                                                                    if (ts.TotalSeconds <= 60)
                                                                    {


                                                                        model_CRM_ORDER_DRF_SYNC = new CRM_ORDER_DRF_SYNC();
                                                                        model_CRM_ORDER_DRF_SYNC.ORDERTTID = rst_CRM_ORDER_TT_LIST[b].ORDERTTID;
                                                                        model_CRM_ORDER_DRF_SYNC.ACCOUNT = rst_DRF_ordersItem_RETURN.data[b].account;
                                                                        model_CRM_ORDER_DRF_SYNC.STORENUM = Convert.ToInt32(rst_DRF_ordersItem_RETURN.data[b].StoreNum).ToString();
                                                                        model_CRM_ORDER_DRF_SYNC.ORDERNUM = rst_DRF_ordersItem_RETURN.data[b].OrderNum;
                                                                        model_CRM_ORDER_DRF_SYNC.BARCODE = rst_DRF_ordersItem_RETURN.data[b].BarCode;
                                                                        model_CRM_ORDER_DRF_SYNC.PRODNUM = rst_DRF_ordersItem_RETURN.data[b].ProdNum;
                                                                        model_CRM_ORDER_DRF_SYNC.PRODNAME = rst_DRF_ordersItem_RETURN.data[b].ProdName;
                                                                        model_CRM_ORDER_DRF_SYNC.PRODSPEC = rst_DRF_ordersItem_RETURN.data[b].ProdSpec;
                                                                        model_CRM_ORDER_DRF_SYNC.ORDERUNIT = rst_DRF_ordersItem_RETURN.data[b].OrderUnit;
                                                                        model_CRM_ORDER_DRF_SYNC.ORDERACTUAL = rst_DRF_ordersItem_RETURN.data[b].OrderActual;
                                                                        model_CRM_ORDER_DRF_SYNC.QUANTITY = rst_DRF_ordersItem_RETURN.data[b].Quantity;
                                                                        model_CRM_ORDER_DRF_SYNC.REMARK = rst_DRF_ordersItem_RETURN.data[b].Remark;
                                                                        model_CRM_ORDER_DRF_SYNC.ITEMTIME = rst_DRF_ordersItem_RETURN.data[b].itemTime;
                                                                        IORDER_TT_data.INSERT_DRF_SYNC(model_CRM_ORDER_DRF_SYNC);
                                                                    }
                                                                }


                                                                if (rst_CRM_ORDER_TT_LIST[b].SAPORDER != "" || rst_CRM_ORDER_TT_LIST[b].PRINTCOUNT > 0)
                                                                {
                                                                    rst_CRM_ORDER_TT_LIST[b].OrderST = 3;
                                                                }
                                                                if (rst_CRM_ORDER_TT_LIST[b].OrderST != 3 || (rst_CRM_ORDER_TT_LIST[b].OrderST == 3 && rst_CRM_ORDER_TT_LIST[b].SAPORDER == ""))
                                                                {
                                                                    CRM_ORDER_MX model_CRM_ORDER_MX_delete = new CRM_ORDER_MX();
                                                                    model_CRM_ORDER_MX_delete.ORDERTTID = rst_CRM_ORDER_TT_LIST[b].ORDERTTID;
                                                                    List<CRM_ORDER_MX> rst_CRM_ORDER_MX_list = IORDER_TT_data.ReadMXbyParam(model_CRM_ORDER_MX_delete).ToList();
                                                                    for (int c = 0; c < rst_CRM_ORDER_MX_list.Count; c++)
                                                                    {
                                                                        IORDER_TT_data.DeleteMX(rst_CRM_ORDER_MX_list[c].ORDERMXID, 0);
                                                                    }

                                                                    try
                                                                    {
                                                                        for (int c = 0; c < rst_DRF_ordersItem_RETURN.data.Count; c++)
                                                                        {
                                                                            if (orderitemtime == "")
                                                                            {
                                                                                orderitemtime = rst_DRF_ordersItem_RETURN.data[c].itemTime;
                                                                            }
                                                                            TimeSpan ts = Convert.ToDateTime(orderitemtime) - Convert.ToDateTime(rst_DRF_ordersItem_RETURN.data[c].itemTime);
                                                                            if (ts.TotalSeconds <= 60)
                                                                            {
                                                                                CRM_ORDER_MX model_CRM_ORDER_MX = new CRM_ORDER_MX();
                                                                                model_CRM_ORDER_MX.ORDERTTID = rst_CRM_ORDER_TT_LIST[b].ORDERTTID;
                                                                                model_CRM_ORDER_MX.StoreNum = Convert.ToInt32(rst_DRF_ordersItem_RETURN.data[c].StoreNum).ToString();
                                                                                model_CRM_ORDER_MX.KHPO = rst_DRF_ordersItem_RETURN.data[c].OrderNum;
                                                                                model_CRM_ORDER_MX.OrderItem = ((hxm + 1) * 10).ToString();
                                                                                model_CRM_ORDER_MX.BarCode = rst_DRF_ordersItem_RETURN.data[c].BarCode;
                                                                                model_CRM_ORDER_MX.ProdNum = rst_DRF_ordersItem_RETURN.data[c].ProdNum;
                                                                                model_CRM_ORDER_MX.ProdName = rst_DRF_ordersItem_RETURN.data[c].ProdName;
                                                                                model_CRM_ORDER_MX.ProdSpec = rst_DRF_ordersItem_RETURN.data[c].ProdSpec;
                                                                                model_CRM_ORDER_MX.OrderUnit = rst_DRF_ordersItem_RETURN.data[c].OrderUnit;
                                                                                model_CRM_ORDER_MX.BEIZ = rst_DRF_ordersItem_RETURN.data[c].Remark;
                                                                                if (rst_DRF_ordersItem_RETURN.data[c].OrderActual == "")
                                                                                {
                                                                                    model_CRM_ORDER_MX.DDSL = Convert.ToInt32(rst_DRF_ordersItem_RETURN.data[c].Quantity);
                                                                                }
                                                                                else
                                                                                {
                                                                                    model_CRM_ORDER_MX.DDSL = Convert.ToInt32(rst_DRF_ordersItem_RETURN.data[c].OrderActual);
                                                                                }
                                                                                model_CRM_ORDER_MX.ISACTIVE = 1;
                                                                                int mxid = IORDER_TT_data.CreateMX(model_CRM_ORDER_MX);
                                                                                hxm = hxm + 1;
                                                                            }


                                                                        }
                                                                    }
                                                                    catch
                                                                    {
                                                                        ISY_EXCEPTIONdata.INSERT_ALL("OrdersHeadid:" + rst_DRF_ordersHead_RETUEN.data[a].ordersHeadid.ToString() + " 订单数据有问题！请检查", "SYNC_DRFBILL", rst_DRF_ordersHead_RETUEN.data[a].ordersHeadid.ToString(), "DRF");
                                                                        ISY_SYSCSdata.UPDATE_SYNC("orderid_" + rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[e].USERACCOUNT.ToString(), ordersHeadid.ToString());
                                                                        rst.TYPE = "E";
                                                                        rst.MESSAGE = "account:" + rst_DRF_ordersHead_RETUEN.data[a].account + "/OrderNum:" + rst_DRF_ordersHead_RETUEN.data[a].OrderNum + "/storeNum:" + rst_DRF_ordersHead_RETUEN.data[a].StoreNum + "  is error";
                                                                        model_CRM_ORDER_TT = new CRM_ORDER_TT();
                                                                        model_CRM_ORDER_TT.ORDERTTID = rst_CRM_ORDER_TT_LIST[b].ORDERTTID;
                                                                        rst_CRM_ORDER_TT_LIST = IORDER_TT_data.ReadTTbyParam(model_CRM_ORDER_TT, 0, 0, 0).ToList();
                                                                        if (rst_CRM_ORDER_TT_LIST.Count == 1)
                                                                        {
                                                                            rst_CRM_ORDER_TT_LIST[0].OrderST = 5;
                                                                            IORDER_TT_data.UpdateTT(rst_CRM_ORDER_TT_LIST[0]);
                                                                        }
                                                                        return rst;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {

                                                            model_CRM_ORDER_DRF_SYNC = new CRM_ORDER_DRF_SYNC();
                                                            model_CRM_ORDER_DRF_SYNC.ORDERTTID = rst_CRM_ORDER_TT_LIST[b].ORDERTTID;
                                                            model_CRM_ORDER_DRF_SYNC.LB = 1;
                                                            IORDER_TT_data.UPDATE_DRF_SYNC(model_CRM_ORDER_DRF_SYNC);
                                                            for (int c = 0; c < rst_DRF_ordersItem_RETURN.data.Count; c++)
                                                            {
                                                                if (orderitemtime == "")
                                                                {
                                                                    orderitemtime = rst_DRF_ordersItem_RETURN.data[c].itemTime;
                                                                }
                                                                TimeSpan ts = Convert.ToDateTime(orderitemtime) - Convert.ToDateTime(rst_DRF_ordersItem_RETURN.data[c].itemTime);
                                                                if (ts.TotalSeconds <= 60)
                                                                {
                                                                    model_CRM_ORDER_DRF_SYNC = new CRM_ORDER_DRF_SYNC();
                                                                    model_CRM_ORDER_DRF_SYNC.ORDERTTID = rst_CRM_ORDER_TT_LIST[b].ORDERTTID;
                                                                    model_CRM_ORDER_DRF_SYNC.ACCOUNT = rst_DRF_ordersItem_RETURN.data[b].account;
                                                                    model_CRM_ORDER_DRF_SYNC.STORENUM = Convert.ToInt32(rst_DRF_ordersItem_RETURN.data[b].StoreNum).ToString();
                                                                    model_CRM_ORDER_DRF_SYNC.ORDERNUM = rst_DRF_ordersItem_RETURN.data[b].OrderNum;
                                                                    model_CRM_ORDER_DRF_SYNC.BARCODE = rst_DRF_ordersItem_RETURN.data[b].BarCode;
                                                                    model_CRM_ORDER_DRF_SYNC.PRODNUM = rst_DRF_ordersItem_RETURN.data[b].ProdNum;
                                                                    model_CRM_ORDER_DRF_SYNC.PRODNAME = rst_DRF_ordersItem_RETURN.data[b].ProdName;
                                                                    model_CRM_ORDER_DRF_SYNC.PRODSPEC = rst_DRF_ordersItem_RETURN.data[b].ProdSpec;
                                                                    model_CRM_ORDER_DRF_SYNC.ORDERUNIT = rst_DRF_ordersItem_RETURN.data[b].OrderUnit;
                                                                    model_CRM_ORDER_DRF_SYNC.ORDERACTUAL = rst_DRF_ordersItem_RETURN.data[b].OrderActual;
                                                                    model_CRM_ORDER_DRF_SYNC.QUANTITY = rst_DRF_ordersItem_RETURN.data[b].Quantity;
                                                                    model_CRM_ORDER_DRF_SYNC.REMARK = rst_DRF_ordersItem_RETURN.data[b].Remark;
                                                                    model_CRM_ORDER_DRF_SYNC.ITEMTIME = rst_DRF_ordersItem_RETURN.data[b].itemTime;
                                                                    IORDER_TT_data.INSERT_DRF_SYNC(model_CRM_ORDER_DRF_SYNC);
                                                                }
                                                            }


                                                            if (rst_CRM_ORDER_TT_LIST[b].SAPORDER != "" || rst_CRM_ORDER_TT_LIST[b].PRINTCOUNT > 0)
                                                            {
                                                                rst_CRM_ORDER_TT_LIST[b].OrderST = 3;
                                                            }
                                                            if (rst_CRM_ORDER_TT_LIST[b].OrderST != 3 || (rst_CRM_ORDER_TT_LIST[b].OrderST == 3 && rst_CRM_ORDER_TT_LIST[b].SAPORDER == ""))
                                                            {
                                                                CRM_ORDER_MX model_CRM_ORDER_MX_delete = new CRM_ORDER_MX();
                                                                model_CRM_ORDER_MX_delete.ORDERTTID = rst_CRM_ORDER_TT_LIST[b].ORDERTTID;
                                                                List<CRM_ORDER_MX> rst_CRM_ORDER_MX_list = IORDER_TT_data.ReadMXbyParam(model_CRM_ORDER_MX_delete).ToList();
                                                                for (int c = 0; c < rst_CRM_ORDER_MX_list.Count; c++)
                                                                {
                                                                    IORDER_TT_data.DeleteMX(rst_CRM_ORDER_MX_list[c].ORDERMXID, 0);
                                                                }

                                                                for (int c = 0; c < rst_DRF_ordersItem_RETURN.data.Count; c++)
                                                                {
                                                                    if (orderitemtime == "")
                                                                    {
                                                                        orderitemtime = rst_DRF_ordersItem_RETURN.data[c].itemTime;
                                                                    }
                                                                    TimeSpan ts = Convert.ToDateTime(orderitemtime) - Convert.ToDateTime(rst_DRF_ordersItem_RETURN.data[c].itemTime);
                                                                    if (ts.TotalSeconds <= 60)
                                                                    {
                                                                        CRM_ORDER_MX model_CRM_ORDER_MX = new CRM_ORDER_MX();
                                                                        model_CRM_ORDER_MX.ORDERTTID = rst_CRM_ORDER_TT_LIST[b].ORDERTTID;
                                                                        model_CRM_ORDER_MX.StoreNum = Convert.ToInt32(rst_DRF_ordersItem_RETURN.data[c].StoreNum).ToString();
                                                                        model_CRM_ORDER_MX.KHPO = rst_DRF_ordersItem_RETURN.data[c].OrderNum;
                                                                        model_CRM_ORDER_MX.OrderItem = ((hxm + 1) * 10).ToString();
                                                                        model_CRM_ORDER_MX.BarCode = rst_DRF_ordersItem_RETURN.data[c].BarCode;
                                                                        model_CRM_ORDER_MX.ProdNum = rst_DRF_ordersItem_RETURN.data[c].ProdNum;
                                                                        model_CRM_ORDER_MX.ProdName = rst_DRF_ordersItem_RETURN.data[c].ProdName;
                                                                        model_CRM_ORDER_MX.ProdSpec = rst_DRF_ordersItem_RETURN.data[c].ProdSpec;
                                                                        model_CRM_ORDER_MX.OrderUnit = rst_DRF_ordersItem_RETURN.data[c].OrderUnit;
                                                                        model_CRM_ORDER_MX.BEIZ = rst_DRF_ordersItem_RETURN.data[c].Remark;
                                                                        if (rst_DRF_ordersItem_RETURN.data[c].OrderActual == "")
                                                                        {
                                                                            model_CRM_ORDER_MX.DDSL = Convert.ToInt32(rst_DRF_ordersItem_RETURN.data[c].Quantity);
                                                                        }
                                                                        else
                                                                        {
                                                                            model_CRM_ORDER_MX.DDSL = Convert.ToInt32(rst_DRF_ordersItem_RETURN.data[c].OrderActual);
                                                                        }
                                                                        model_CRM_ORDER_MX.ISACTIVE = 1;
                                                                        int mxid = IORDER_TT_data.CreateMX(model_CRM_ORDER_MX);
                                                                        hxm = hxm + 1;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        return rst_CRM_ORDER_DRF_SYNC_SELECT.MES_RETURN;
                                                    }
                                                }
                                                IORDER_TT_data.UpdateTT(rst_CRM_ORDER_TT_LIST[b]);
                                            }
                                            ISY_SYSCSdata.UPDATE_SYNC("orderid_" + rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[e].USERACCOUNT.ToString(), ordersHeadid.ToString());
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            rst.TYPE = "E";
                            rst.MESSAGE = rst_DRF_ordersHead_RETUEN.msg + rst_DRF_ordersHead_RETUEN.status;
                            return rst;
                        }
                        rst.TYPE = "S";
                        rst.MESSAGE = "";
                    }
                }
                rst.TYPE = "S";
                rst.MESSAGE = rststring;
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.ToString();
            }
            return rst;
        }
        public MES_RETURN DRFBILL_UPDATEMX_AGAIN(int ORDERTTID)
        {
            MES_RETURN mr = new MES_RETURN();
            CRM_ORDER_DRF_SYNC model_CRM_ORDER_DRF_SYNC = new CRM_ORDER_DRF_SYNC();
            model_CRM_ORDER_DRF_SYNC.ORDERTTID = ORDERTTID;
            CRM_ORDER_DRF_SYNC_SELECT rst_CRM_ORDER_DRF_SYNC_SELECT = IORDER_TT_data.SELECT_DRF_SYNC(model_CRM_ORDER_DRF_SYNC);

            CRM_ORDER_MX model_CRM_ORDER_MX_delete = new CRM_ORDER_MX();
            model_CRM_ORDER_MX_delete.ORDERTTID = ORDERTTID;
            List<CRM_ORDER_MX> rst_CRM_ORDER_MX_list = IORDER_TT_data.ReadMXbyParam(model_CRM_ORDER_MX_delete).ToList();
            for (int c = 0; c < rst_CRM_ORDER_MX_list.Count; c++)
            {
                IORDER_TT_data.DeleteMX(rst_CRM_ORDER_MX_list[c].ORDERMXID, 0);
            }
            int hxm = 0;
            for (int c = 0; c < rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC.Count; c++)
            {
                try
                {
                    CRM_ORDER_MX model_CRM_ORDER_MX = new CRM_ORDER_MX();
                    model_CRM_ORDER_MX.ORDERTTID = rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC[c].ORDERTTID;
                    model_CRM_ORDER_MX.StoreNum = rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC[c].STORENUM;
                    model_CRM_ORDER_MX.KHPO = rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC[c].ORDERNUM;
                    model_CRM_ORDER_MX.OrderItem = ((hxm + 1) * 10).ToString();
                    model_CRM_ORDER_MX.BarCode = rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC[c].BARCODE;
                    model_CRM_ORDER_MX.ProdNum = rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC[c].PRODNUM;
                    model_CRM_ORDER_MX.ProdName = rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC[c].PRODNAME;
                    model_CRM_ORDER_MX.ProdSpec = rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC[c].PRODSPEC;
                    model_CRM_ORDER_MX.OrderUnit = rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC[c].ORDERUNIT;
                    model_CRM_ORDER_MX.BEIZ = rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC[c].REMARK;
                    if (rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC[c].ORDERACTUAL == "")
                    {
                        model_CRM_ORDER_MX.DDSL = Convert.ToInt32(rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC[c].QUANTITY);
                    }
                    else
                    {
                        model_CRM_ORDER_MX.DDSL = Convert.ToInt32(rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC[c].ORDERACTUAL);
                    }
                    model_CRM_ORDER_MX.ISACTIVE = 1;
                    int mxid = IORDER_TT_data.CreateMX(model_CRM_ORDER_MX);
                    hxm = hxm + 1;
                }
                catch
                {
                    CRM_ORDER_TT model_CRM_ORDER_TT = new CRM_ORDER_TT();
                    model_CRM_ORDER_TT.ORDERTTID = ORDERTTID;
                    List<CRM_ORDER_TT> rst_CRM_ORDER_TT_LIST = IORDER_TT_data.ReadTTbyParam(model_CRM_ORDER_TT, 0, 0, 0).ToList();
                    if (rst_CRM_ORDER_TT_LIST.Count > 0)
                    {
                        rst_CRM_ORDER_TT_LIST[0].OrderST = 5;
                        IORDER_TT_data.UpdateTT(rst_CRM_ORDER_TT_LIST[0]);

                        ISY_EXCEPTIONdata.INSERT_ALL("ORDERTTID:" + rst_CRM_ORDER_TT_LIST[0].ORDERTTID.ToString() + " 订单数据有问题！请检查", "SYNC_DRFBILL", rst_CRM_ORDER_TT_LIST[0].ORDERTTID.ToString(), "DRF");
                        mr.TYPE = "E";
                        mr.MESSAGE = "account:" + rst_CRM_ORDER_TT_LIST[0].CJZH + "/OrderNum:" + rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC[c].ORDERNUM + "/storeNum:" + rst_CRM_ORDER_DRF_SYNC_SELECT.CRM_ORDER_DRF_SYNC[c].STORENUM + "  is error";
                    }

                    return mr;
                }
            }
            return mr;
        }
        private MES_RETURN DRFBILL_AUTO_ISUSER()
        {
            MES_RETURN mr = new MES_RETURN();
            CRM_ORDER_DRF_USER model_CRM_ORDER_DRF_USER = new CRM_ORDER_DRF_USER();
            model_CRM_ORDER_DRF_USER.LB = 1;
            model_CRM_ORDER_DRF_USER.USERACCOUNT = -1;
            CRM_ORDER_DRF_USER_SELECT rst_CRM_ORDER_DRF_USER_SELECT = IORDER_TT_data.SELECT_USER_SYNC(model_CRM_ORDER_DRF_USER);
            if (rst_CRM_ORDER_DRF_USER_SELECT.MES_RETURN.TYPE != "S")
            {
                return rst_CRM_ORDER_DRF_USER_SELECT.MES_RETURN;
            }
            if (rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER.Count == 0)
            {
                mr.TYPE = "S";
                mr.MESSAGE = "";
                return mr;
            }
            DRF_LATEST_RETURN latest_list = latest();
            for (int a = 0; a < rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER.Count; a++)
            {
                CRM_DRF_RETURNMSG model_CRM_DRF_RETURNMSG = status(rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[a].USERACCOUNT);
                if (model_CRM_DRF_RETURNMSG.Error == false)
                {
                    if (model_CRM_DRF_RETURNMSG.Data == 6)
                    {
                        CRM_ORDER_TT model_CRM_ORDER_TT = new CRM_ORDER_TT();
                        model_CRM_ORDER_TT.OrderSrc2 = 2336;
                        model_CRM_ORDER_TT.CJZH = rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[a].USERNAME;
                        model_CRM_ORDER_TT.CJSJ_BEGIN = DateTime.Now.AddDays(-14).ToString("yyyy-MM-dd");
                        model_CRM_ORDER_TT.CJSJ_END = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                        List<CRM_ORDER_TT> rst_CRM_ORDER_TT_LIST = IORDER_TT_data.ReadTTbyParam(model_CRM_ORDER_TT, 0, 0, 0).ToList();
                        if (rst_CRM_ORDER_TT_LIST.Count > 0)
                        {
                            if (latest_list.Error == false)
                            {
                                if (latest_list.Data != null)
                                {
                                    if (latest_list.Data.Orders != null)
                                    {
                                        DataTable dt_1 = new DataTable();
                                        for (int b = 0; b < latest_list.Data.Orders.Tables.Count; b++)
                                        {
                                            if (latest_list.Data.Orders.Tables[b].TableName == rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[a].USERNAME)
                                            {
                                                dt_1 = latest_list.Data.Orders.Tables[b];
                                            }
                                        }
                                        DataTable dt_2 = new DataTable();
                                        for (int b = 0; b < latest_list.Data.OrdersDone.Tables.Count; b++)
                                        {
                                            if (latest_list.Data.OrdersDone.Tables[b].TableName == rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[a].USERNAME)
                                            {
                                                dt_2 = latest_list.Data.OrdersDone.Tables[b];
                                            }
                                        }
                                        if ((dt_1.Rows.Count + dt_2.Rows.Count) > 0)
                                        {
                                            for (int b = 0; b < rst_CRM_ORDER_TT_LIST.Count; b++)
                                            {
                                                DataRow[] dr1 = dt_1.Select("Account='" + rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[a].USERNAME + "' AND Ordernum='" + rst_CRM_ORDER_TT_LIST[b].KHPO + "' AND Storenum='" + rst_CRM_ORDER_TT_LIST[b].StoreNum.PadLeft(3, '0') + "'");
                                                DataRow[] dr2 = dt_2.Select("Account='" + rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[a].USERNAME + "' AND Ordernum='" + rst_CRM_ORDER_TT_LIST[b].KHPO + "' AND Storenum='" + rst_CRM_ORDER_TT_LIST[b].StoreNum.PadLeft(3, '0') + "'");
                                                if ((dr1.Length + dr2.Length) == 0)
                                                {
                                                    rst_CRM_ORDER_TT_LIST[b].OrderST = 4;
                                                    IORDER_TT_data.UpdateTT(rst_CRM_ORDER_TT_LIST[b]);
                                                }
                                                else
                                                {
                                                    if (rst_CRM_ORDER_TT_LIST[b].OrderST == 4)
                                                    {
                                                        rst_CRM_ORDER_TT_LIST[b].OrderST = 3;
                                                        IORDER_TT_data.UpdateTT(rst_CRM_ORDER_TT_LIST[b]);
                                                    }
                                                }
                                            }
                                        }
                                        if (dt_2.Rows.Count > 0)
                                        {
                                            for (int b = 0; b < dt_2.Rows.Count; b++)
                                            {
                                                model_CRM_ORDER_TT = new CRM_ORDER_TT();
                                                model_CRM_ORDER_TT.OrderSrc2 = 2336;
                                                //model_CRM_ORDER_TT.KHPO = rst_DRF_ordersHead_RETUEN.data[a].OrderNum.ToString();
                                                model_CRM_ORDER_TT.KHPO = dt_2.Rows[b]["Ordernum"].ToString();
                                                model_CRM_ORDER_TT.StoreNum = Convert.ToInt32(dt_2.Rows[b]["Storenum"].ToString()).ToString();
                                                model_CRM_ORDER_TT.CJZH = rst_CRM_ORDER_DRF_USER_SELECT.CRM_ORDER_DRF_USER[a].USERNAME;
                                                List<CRM_ORDER_TT> rst_CRM_ORDER_TT_LIST_SH = IORDER_TT_data.ReadTTbyParam(model_CRM_ORDER_TT, 0, 0, 0).ToList();
                                                if (rst_CRM_ORDER_TT_LIST_SH.Count > 0)
                                                {
                                                    for (int c = 0; c < rst_CRM_ORDER_TT_LIST_SH.Count; c++)
                                                    {
                                                        if (rst_CRM_ORDER_TT_LIST_SH[c].ISACTIVE != 60)
                                                        {
                                                            rst_CRM_ORDER_TT_LIST_SH[c].QRR = 1;
                                                            rst_CRM_ORDER_TT_LIST_SH[c].QRSJ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                            IORDER_TT_data.UpdateOrderIsactive(rst_CRM_ORDER_TT_LIST_SH[c].ORDERTTID, 60);
                                                            IORDER_TT_data.UpdateTT(rst_CRM_ORDER_TT_LIST_SH[c]);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return mr;
        }
        public CRM_ORDER_DRF_USER_SELECT SELECT_USER_SYNC(CRM_ORDER_DRF_USER model)
        {
            return IORDER_TT_data.SELECT_USER_SYNC(model);
        }
    }
}
