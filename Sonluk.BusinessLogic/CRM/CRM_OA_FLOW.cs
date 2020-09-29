using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using Sonluk.IDataAccess.OA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class CRM_OA_FLOW
    {
        private static readonly ICRM_OA_FLOW _DataAccess_FLOW = RMSDataAccess.CreateCRM_OA_FLOW();
        private static readonly IOA_TRANSMIT _DataAccess_TRANSIMIT = RMSDataAccess.CreateOA_TRANSMIT();
        //private static readonly IKQ_YGQJ _DataAccess_YGQJ = RMSDataAccess.CreateKQ_YGQJ();
        private static readonly IFlow _oaDetaAccess = OADataAccess.CreateFlow();
        private static readonly IOA_OPINION _opinionDataAccess = RMSDataAccess.CreateOA_OPINION();
        private static readonly ICOST_LKAYEARTT _LKAyearDataAccess = RMSDataAccess.CreateCOST_LKAYEARTT();
        private static readonly ICOST_LKAYEARCOST _LKAyearCostDataAccess = RMSDataAccess.CreateCOST_LKAYEARCOST();
        private static readonly ICOST_CP _CPDataAccess = RMSDataAccess.CreateCOST_CP();
        private static readonly ICOST_LKAEachYEAR _eachDataAccess = RMSDataAccess.CreateCOST_LKAEachYEAR();
        private static readonly ICOST_LKAYEARLIST _listDataAccess = RMSDataAccess.CreateCOST_LKAYEARLIST();
        private static readonly ICOST_KAYEARTT _KAyearDataAccess = RMSDataAccess.CreateCOST_KAYEARTT();
        private static readonly ICOST_KAYEARCOST _KAyearCostDataAccess = RMSDataAccess.CreateCOST_KAYEARCOST();
        private static readonly ICOST_ZZFTT _ZZFCostDataAccess = RMSDataAccess.CreateCOST_ZZFTT();
        private static readonly ICOST_CXHDPGHZ _CXHDPGHZDataAccess = RMSDataAccess.CreateCOST_CXHDPGHZ();
        private const string YGQJTABLE = "CRM_KQ_YGQJ";
        private const string YGQJID = "YGQJID";
        private const string CCTABLE = "CRM_KQ_CCTT";
        private const string CCID = "CCID";
        private const string YCTABLE = "CRM_KQ_YCKQSM";
        private const string YCID = "YCKQID";
        private const string KHTABEL = "CRM_KH_KH";
        private const string KHID = "KHID";
        private const string YCKQSMTABLE = "CRM_KQ_YCKQSM";
        private const string YCKQID = "YCKQID";
        private const string ZDFTABLE = "CRM_HD_ZDF";
        private const string ZDFID = "ZDFID";
        private const string LKAYEARTTID = "LKAYEARTTID";
        private const string LKAYEARTTTABLE = "CRM_COST_LKAYEARTT";
        private const string HaiBaoTABLE = "CRM_COST_LKAFYMXDT";
        private const string HaiBaoID = "LKADTMXID";
        private const string TSCLTABLE = "CRM_COST_LKAFYMXTSCL";
        private const string TSCLID = "LKATSCLMXID";
        private const string ZZFTABLE = "CRM_COST_ZZFTT";
        private const string ZZFID = "TTID";
        private const string KHTSTABLE = "CRM_COST_TS";
        private const string KHTSID = "TSID";
        private const string MDBSTABLE = "CRM_COST_MDBS";
        private const string MDBSID = "MDBSID";
        private const string KAYEARTTTABLE = "CRM_COST_KAYEARTT";
        private const string KAYEARTTID = "KAYEARTTID";
        private const string KADTMXTABLE = "CRM_COST_KADTMX";
        private const string KADTMXID = "KADTMXID";
        private const string KATSCLMXTABLE = "CRM_COST_KATSCLMX";
        private const string KATSCLMXID = "KATSCLMXID";
        private const string CXYTABLE = "CRM_COST_CXY";
        private const string CXYID = "CXYID";
        private const string CXHDTABLE = "CRM_COST_CXHD";
        private const string CXHDID = "CXHDID";

        public int ReadOAFinishStatus()
        {
            return _oaDetaAccess.ReadOAFinishStatus(long.Parse("-1856337538455679585"), 93, 1);
        }

        public void Aotu_UPDATE()
        {

            IList<CRM_OA_TRANSMIT> nodes_transmit = _DataAccess_FLOW.ReadOA_TRANSMIT();


            for (int i = 0; i < nodes_transmit.Count; i++)
            {
                try
                {
                    CRM_OA_TRANSMIT node = nodes_transmit[i];
                    if (node.OAZT == 1)
                    {
                        int finishstatus = _oaDetaAccess.ReadOAFinishStatus(long.Parse(node.OAID), node.OACSLB, node.OAZT);
                        if (finishstatus == 1)       //流程结束
                        {
                            #region //流程结束
                            IList<CRM_OA_OPINION> OpinionData = _oaDetaAccess.ReadOpinion(long.Parse(node.OAID));
                            for (int j = 0; j < OpinionData.Count; j++)
                            {
                                CRM_OA_OPINION model = OpinionData[j];
                                model.OAID = node.OAID;
                                model.OACSBH = node.OACSBH;
                                model.OACSLB = node.OACSLB;
                                _opinionDataAccess.Create(model);

                            }



                            node.OAZT = 2;
                            _DataAccess_TRANSIMIT.Update(node);
                            if (node.OACSLB == 92)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(YGQJTABLE, YGQJID, node.OACSBH, 3);
                            }
                            else if (node.OACSLB == 93)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(CCTABLE, CCID, node.OACSBH, 3);
                            }
                            else if (node.OACSLB == 551)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KHTABEL, KHID, node.OACSBH, 3);
                            }
                            else if (node.OACSLB == 921)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KHTABEL, KHID, node.OACSBH, 3);
                            }
                            else if (node.OACSLB == 922)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KHTABEL, KHID, node.OACSBH, 3);
                            }
                            else if (node.OACSLB == 923)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KHTABEL, KHID, node.OACSBH, 3);
                            }
                            else if (node.OACSLB == 104)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(YCKQSMTABLE, YCKQID, node.OACSBH, 3);
                            }
                            else if (node.OACSLB == 990)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(ZDFTABLE, ZDFID, node.OACSBH, 3);
                            }
                            else if (node.OACSLB == 1083)  //审核撤回
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(CCTABLE, CCID, node.OACSBH, 1);
                            }
                            else if (node.OACSLB == 1313)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(LKAYEARTTTABLE, LKAYEARTTID, node.OACSBH, 60);
                                _LKAyearDataAccess.UpdateSubmitCount(node.OACSBH);     //提交次数加1


                                //把修改的费用金额更新到已审核的金额上
                                CRM_COST_LKAYEARCOST cxmodel = new CRM_COST_LKAYEARCOST();
                                cxmodel.LKAYEARTTID = node.OACSBH;
                                List<CRM_COST_LKAYEARCOST> COSTmodel = _LKAyearCostDataAccess.ReadByParam(cxmodel).ToList();
                                for (int j = 0; j < COSTmodel.Count; j++)
                                {
                                    COSTmodel[j].THISFYYGE = COSTmodel[j].THISFYYGEXG;
                                    _LKAyearCostDataAccess.UpdateSPJE(COSTmodel[j]);
                                }

                                //把产品利润的状态都修改为已审核
                                CRM_COST_CP cxmodel2 = new CRM_COST_CP();
                                cxmodel2.LKAYEARTTID = node.OACSBH;
                                List<CRM_COST_CP> CPmodel = _CPDataAccess.ReadByParam(cxmodel2).ToList();
                                for (int j = 0; j < CPmodel.Count; j++)
                                {
                                    if (CPmodel[j].ISACTIVE != 3)
                                    {
                                        CPmodel[j].ISACTIVE = 3;
                                        _CPDataAccess.Update(CPmodel[j]);
                                    }
                                }

                                //更新年度费用每年销售的数据表
                                _eachDataAccess.UpdateByTTID(node.OACSBH);

                                //更新LKAlist的数据
                                COST_LKAYEARLIST list = new COST_LKAYEARLIST();
                                list.UpdateByTTID(node.OACSBH);

                            }
                            else if (node.OACSLB == 1360)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(HaiBaoTABLE, HaiBaoID, node.OACSBH, 30);
                                //_LKAyearDataAccess.UpdateSubmitCount(node.OACSBH);
                            }
                            else if (node.OACSLB == 1361)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(TSCLTABLE, TSCLID, node.OACSBH, 30);
                                //_LKAyearDataAccess.UpdateSubmitCount(node.OACSBH);
                            }
                            else if (node.OACSLB == 1362)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(ZZFTABLE, ZZFID, node.OACSBH, 30);
                                _ZZFCostDataAccess.UpdateTBSJ(node.OACSBH);
                                //_LKAyearDataAccess.UpdateSubmitCount(node.OACSBH);
                            }
                            else if (node.OACSLB == 2014)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KHTSTABLE, KHTSID, node.OACSBH, 30);
                            }
                            else if (node.OACSLB == 2015)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(MDBSTABLE, MDBSID, node.OACSBH, 30);
                            }
                            else if (node.OACSLB == 2022)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KAYEARTTTABLE, KAYEARTTID, node.OACSBH, 60);
                                _KAyearDataAccess.UpdateSubmitCount(node.OACSBH);     //提交次数加1

                                //把修改的费用金额更新到已审核的金额上
                                _KAyearCostDataAccess.UpdateSPJE(node.OACSBH);
                            }
                            else if (node.OACSLB == 2023)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KADTMXTABLE, KADTMXID, node.OACSBH, 30);
                            }
                            else if (node.OACSLB == 2024)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KATSCLMXTABLE, KATSCLMXID, node.OACSBH, 30);
                            }
                            else if (node.OACSLB == 2051)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KHTSTABLE, KHTSID, node.OACSBH, 60);
                            }
                            else if (node.OACSLB == 2027)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(CXYTABLE, CXYID, node.OACSBH, 30);
                            }
                            else if (node.OACSLB == 2066)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(CXHDTABLE, CXHDID, node.OACSBH, 30);
                            }
                            else if (node.OACSLB == 2079)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(CXHDTABLE, CXHDID, node.OACSBH, 60);
                                AutoUpdateCXHDPGHZ(node.OACSBH);
                            }

                            #endregion
                        }
                        int count = _oaDetaAccess.ReadOABPMStatus(long.Parse(node.OAID));
                        if (count == 0)      //找不到流程
                        {
                            #region //找不到流程
                            node.OAZT = 0;
                            node.ISDELETE = true;
                            _DataAccess_TRANSIMIT.Update(node);
                            if (node.OACSLB == 92)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(YGQJTABLE, YGQJID, node.OACSBH, 1);
                            }
                            else if (node.OACSLB == 93)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(CCTABLE, CCID, node.OACSBH, 1);
                            }
                            else if (node.OACSLB == 551)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KHTABEL, KHID, node.OACSBH, 1);
                            }
                            else if (node.OACSLB == 921)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KHTABEL, KHID, node.OACSBH, 1);
                            }
                            else if (node.OACSLB == 922)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KHTABEL, KHID, node.OACSBH, 1);
                            }
                            else if (node.OACSLB == 923)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KHTABEL, KHID, node.OACSBH, 1);
                            }
                            else if (node.OACSLB == 104)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(YCKQSMTABLE, YCKQID, node.OACSBH, 1);
                            }
                            else if (node.OACSLB == 990)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(ZDFTABLE, ZDFID, node.OACSBH, 1);
                            }
                            else if (node.OACSLB == 1083)  //审核撤回
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(CCTABLE, CCID, node.OACSBH, 3);
                            }
                            else if (node.OACSLB == 1313)
                            {
                                CRM_COST_LKAYEARTT cxmodel2 = new CRM_COST_LKAYEARTT();
                                cxmodel2.LKAYEARTTID = node.OACSBH;
                                List<CRM_COST_LKAYEARTT> lkamodel = _LKAyearDataAccess.ReadByParam(cxmodel2, 0).ToList();
                                if (lkamodel[0].SUBMITCOUNT == 0)       //第一次提交
                                {
                                    _DataAccess_FLOW.OA_FinishUpdate(LKAYEARTTTABLE, LKAYEARTTID, node.OACSBH, 40);
                                }
                                else                  //再次提交
                                {
                                    _DataAccess_FLOW.OA_FinishUpdate(LKAYEARTTTABLE, LKAYEARTTID, node.OACSBH, 55);
                                }
                            }
                            else if (node.OACSLB == 1360)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(HaiBaoTABLE, HaiBaoID, node.OACSBH, 10);
                            }
                            else if (node.OACSLB == 1361)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(TSCLTABLE, TSCLID, node.OACSBH, 10);
                            }
                            else if (node.OACSLB == 1362)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(ZZFTABLE, ZZFID, node.OACSBH, 10);
                            }
                            else if (node.OACSLB == 2014)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KHTSTABLE, KHTSID, node.OACSBH, 10);
                            }
                            else if (node.OACSLB == 2015)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(MDBSTABLE, MDBSID, node.OACSBH, 15);
                            }
                            else if (node.OACSLB == 2022)
                            {
                                CRM_COST_KAYEARTT cxmodel2 = new CRM_COST_KAYEARTT();
                                cxmodel2.KAYEARTTID = node.OACSBH;
                                List<CRM_COST_KAYEARTT> kamodel = _KAyearDataAccess.ReadByParam(cxmodel2, 0).ToList();
                                if (kamodel[0].SUBMITCOUNT == 0)       //第一次提交
                                {
                                    _DataAccess_FLOW.OA_FinishUpdate(KAYEARTTTABLE, KAYEARTTID, node.OACSBH, 10);
                                }
                                else                  //再次提交
                                {
                                    _DataAccess_FLOW.OA_FinishUpdate(KAYEARTTTABLE, KAYEARTTID, node.OACSBH, 45);
                                }

                            }
                            else if (node.OACSLB == 2023)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KADTMXTABLE, KADTMXID, node.OACSBH, 10);
                            }
                            else if (node.OACSLB == 2024)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KATSCLMXTABLE, KATSCLMXID, node.OACSBH, 10);
                            }
                            else if (node.OACSLB == 2051)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KHTSTABLE, KHTSID, node.OACSBH, 30);
                            }
                            else if (node.OACSLB == 2027)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(CXYTABLE, CXYID, node.OACSBH, 10);
                            }
                            else if (node.OACSLB == 2066)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(CXHDTABLE, CXHDID, node.OACSBH, 10);
                            }
                            else if (node.OACSLB == 2079)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(CXHDTABLE, CXHDID, node.OACSBH, 45);
                            }
                            #endregion
                        }
                    }
                    else if (node.OAZT == 3)
                    {
                        int finishstatus = _oaDetaAccess.ReadOAFinishStatus(long.Parse(node.OAID), node.OACSLB, node.OAZT);
                        if (finishstatus == 1)
                        {
                            node.OAZT = 4;
                            _DataAccess_TRANSIMIT.Update(node);
                            if (node.OACSLB == 105)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(CCTABLE, CCID, node.OACSBH, 6);
                            }
                            else if (node.OACSLB == 2021)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(MDBSTABLE, MDBSID, node.OACSBH, 60);
                            }
                            else if (node.OACSLB == 4120)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KADTMXTABLE, KADTMXID, node.OACSBH, 60);
                            }
                            else if (node.OACSLB == 4121)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KATSCLMXTABLE, KATSCLMXID, node.OACSBH, 60);
                            }


                        }
                        int count = _oaDetaAccess.ReadOABPMStatus(long.Parse(node.OAID));
                        if (count == 0)
                        {
                            node.OAZT = 0;
                            node.ISDELETE = true;
                            _DataAccess_TRANSIMIT.Update(node);
                            if (node.OACSLB == 105)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(CCTABLE, CCID, node.OACSBH, 4);
                            }
                            else if (node.OACSLB == 2021)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(MDBSTABLE, MDBSID, node.OACSBH, 45);
                            }
                            else if (node.OACSLB == 4120)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KADTMXTABLE, KADTMXID, node.OACSBH, 45);
                            }
                            else if (node.OACSLB == 4121)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KATSCLMXTABLE, KATSCLMXID, node.OACSBH, 45);
                            }


                        }

                    }
                }
                catch //(Exception e)
                {
                    //throw e;
                    continue;
                }


            }
        }



        public void Auto_UPDATE_DaiFa()           //更新处于待发状态的流程
        {

            IList<CRM_OA_TRANSMIT> nodes_transmit = _DataAccess_FLOW.ReadOA_TRANSMIT();


            for (int i = 0; i < nodes_transmit.Count; i++)
            {
                try
                {
                    CRM_OA_TRANSMIT node = nodes_transmit[i];
                    if (node.OAZT == 1 || node.OAZT == 3)
                    {
                        int status = _oaDetaAccess.ReadOADaiFaStatus(long.Parse(node.OAID));
                        if (status == 1)       //流程处于待发状态
                        {
                            #region //流程处于待发状态
                            //第一步，把OA中的审核意见存到CRM
                            //CRM_OA_OPINION cxmodel = new CRM_OA_OPINION();
                            //cxmodel.OAID = node.OAID;
                            //IList<CRM_OA_OPINION> cxdata = _opinionDataAccess.ReadByParam(cxmodel);
                            //if (cxdata.Count == 0)          //数据库中没有这条OA的审批记录才会进行新增
                            //{
                            IList<CRM_OA_OPINION> OpinionData = _oaDetaAccess.ReadOpinion(long.Parse(node.OAID));
                            for (int j = 0; j < OpinionData.Count; j++)
                            {
                                CRM_OA_OPINION model = OpinionData[j];
                                model.OAID = node.OAID;
                                model.OACSBH = node.OACSBH;
                                model.OACSLB = node.OACSLB;
                                _opinionDataAccess.Create(model);

                            }
                            //}




                            //第二步，把CRM里面的状态改回去，包扩了申请表和OA关联表
                            node.OAZT = 0;
                            node.ISDELETE = true;
                            _DataAccess_TRANSIMIT.Update(node);
                            if (node.OACSLB == 92)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(YGQJTABLE, YGQJID, node.OACSBH, 1);
                            }
                            else if (node.OACSLB == 93)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(CCTABLE, CCID, node.OACSBH, 1);
                            }
                            else if (node.OACSLB == 551)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KHTABEL, KHID, node.OACSBH, 1);
                            }
                            else if (node.OACSLB == 921)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KHTABEL, KHID, node.OACSBH, 1);
                            }
                            else if (node.OACSLB == 922)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KHTABEL, KHID, node.OACSBH, 1);
                            }
                            else if (node.OACSLB == 923)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KHTABEL, KHID, node.OACSBH, 1);
                            }
                            else if (node.OACSLB == 104)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(YCKQSMTABLE, YCKQID, node.OACSBH, 1);
                            }
                            else if (node.OACSLB == 990)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(ZDFTABLE, ZDFID, node.OACSBH, 1);
                            }
                            else if (node.OACSLB == 1083)  //审核撤回
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(CCTABLE, CCID, node.OACSBH, 3);
                            }
                            else if (node.OACSLB == 105)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(CCTABLE, CCID, node.OACSBH, 4);
                            }
                            else if (node.OACSLB == 1313)
                            {
                                CRM_COST_LKAYEARTT cxmodel2 = new CRM_COST_LKAYEARTT();
                                cxmodel2.LKAYEARTTID = node.OACSBH;
                                List<CRM_COST_LKAYEARTT> lkamodel = _LKAyearDataAccess.ReadByParam(cxmodel2, 0).ToList();
                                if (lkamodel[0].SUBMITCOUNT == 0)       //第一次提交
                                {
                                    _DataAccess_FLOW.OA_FinishUpdate(LKAYEARTTTABLE, LKAYEARTTID, node.OACSBH, 40);
                                }
                                else                  //再次提交
                                {
                                    _DataAccess_FLOW.OA_FinishUpdate(LKAYEARTTTABLE, LKAYEARTTID, node.OACSBH, 55);
                                }

                            }
                            else if (node.OACSLB == 1360)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(HaiBaoTABLE, HaiBaoID, node.OACSBH, 10);
                            }
                            else if (node.OACSLB == 1361)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(TSCLTABLE, TSCLID, node.OACSBH, 10);
                            }
                            else if (node.OACSLB == 1362)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(ZZFTABLE, ZZFID, node.OACSBH, 10);
                            }
                            else if (node.OACSLB == 2014)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KHTSTABLE, KHTSID, node.OACSBH, 10);
                            }
                            else if (node.OACSLB == 2015)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(MDBSTABLE, MDBSID, node.OACSBH, 15);
                            }
                            else if (node.OACSLB == 2021)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(MDBSTABLE, MDBSID, node.OACSBH, 45);
                            }
                            else if (node.OACSLB == 2022)
                            {
                                CRM_COST_KAYEARTT cxmodel2 = new CRM_COST_KAYEARTT();
                                cxmodel2.KAYEARTTID = node.OACSBH;
                                List<CRM_COST_KAYEARTT> kamodel = _KAyearDataAccess.ReadByParam(cxmodel2, 0).ToList();
                                if (kamodel[0].SUBMITCOUNT == 0)       //第一次提交
                                {
                                    _DataAccess_FLOW.OA_FinishUpdate(KAYEARTTTABLE, KAYEARTTID, node.OACSBH, 10);
                                }
                                else                  //再次提交
                                {
                                    _DataAccess_FLOW.OA_FinishUpdate(KAYEARTTTABLE, KAYEARTTID, node.OACSBH, 45);
                                }

                            }
                            else if (node.OACSLB == 2023)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KADTMXTABLE, KADTMXID, node.OACSBH, 10);
                            }
                            else if (node.OACSLB == 2024)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KATSCLMXTABLE, KATSCLMXID, node.OACSBH, 10);
                            }
                            else if (node.OACSLB == 2051)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KHTSTABLE, KHTSID, node.OACSBH, 30);
                            }
                            else if (node.OACSLB == 2027)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(CXYTABLE, CXYID, node.OACSBH, 10);
                            }
                            else if (node.OACSLB == 2066)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(CXHDTABLE, CXHDID, node.OACSBH, 10);
                            }
                            else if (node.OACSLB == 2079)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(CXHDTABLE, CXHDID, node.OACSBH, 45);
                            }
                            else if (node.OACSLB == 4120)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KADTMXTABLE, KADTMXID, node.OACSBH, 45);
                            }
                            else if (node.OACSLB == 4121)
                            {
                                _DataAccess_FLOW.OA_FinishUpdate(KATSCLMXTABLE, KATSCLMXID, node.OACSBH, 45);
                            }


                            //第三步，修改OA表中的数据来源
                            _oaDetaAccess.UpdateDataSource(long.Parse(node.OAID), node.OACSLB);


                            #endregion
                        }
                    }
                }
                catch //(Exception e)
                {
                    //throw e;
                    continue;
                }


            }
        }



        public void LKAYEAR_Finish(int LKAYEARTT)
        {
            _DataAccess_FLOW.OA_FinishUpdate(LKAYEARTTTABLE, LKAYEARTTID, LKAYEARTT, 60);
            _LKAyearDataAccess.UpdateSubmitCount(LKAYEARTT);     //提交次数加1


            //把修改的费用金额更新到已审核的金额上
            CRM_COST_LKAYEARCOST cxmodel = new CRM_COST_LKAYEARCOST();
            cxmodel.LKAYEARTTID = LKAYEARTT;
            List<CRM_COST_LKAYEARCOST> COSTmodel = _LKAyearCostDataAccess.ReadByParam(cxmodel).ToList();
            for (int j = 0; j < COSTmodel.Count; j++)
            {
                COSTmodel[j].THISFYYGE = COSTmodel[j].THISFYYGEXG;
                _LKAyearCostDataAccess.UpdateSPJE(COSTmodel[j]);
            }

            //把产品利润的状态都修改为已审核
            CRM_COST_CP cxmodel2 = new CRM_COST_CP();
            cxmodel2.LKAYEARTTID = LKAYEARTT;
            List<CRM_COST_CP> CPmodel = _CPDataAccess.ReadByParam(cxmodel2).ToList();
            for (int j = 0; j < CPmodel.Count; j++)
            {
                if (CPmodel[j].ISACTIVE != 3)
                {
                    CPmodel[j].ISACTIVE = 3;
                    _CPDataAccess.Update(CPmodel[j]);
                }
            }


            //更新年度费用每年销售的数据表
            _eachDataAccess.UpdateByTTID(LKAYEARTT);


            //更新LKAlist的数据
            COST_LKAYEARLIST list = new COST_LKAYEARLIST();
            list.UpdateByTTID(LKAYEARTT);


            CRM_OA_TRANSMIT nodecx = new CRM_OA_TRANSMIT();
            nodecx.OACSBH = LKAYEARTT;
            nodecx.OACSLB = 1313;
            List<CRM_OA_TRANSMIT> node = _DataAccess_TRANSIMIT.ReadByParam(nodecx).ToList();
            for (int i = 0; i < node.Count; i++)
            {
                node[i].OAZT = 2;
                _DataAccess_TRANSIMIT.Update(node[i]);
            }


        }


        public void KAYEAR_Finish(int KAYEARTT)
        {
            _DataAccess_FLOW.OA_FinishUpdate(KAYEARTTTABLE, KAYEARTTID, KAYEARTT, 60);
            _KAyearDataAccess.UpdateSubmitCount(KAYEARTT);     //提交次数加1

            //把修改的费用金额更新到已审核的金额上
            _KAyearCostDataAccess.UpdateSPJE(KAYEARTT);

            CRM_OA_TRANSMIT nodecx = new CRM_OA_TRANSMIT();
            nodecx.OACSBH = KAYEARTT;
            nodecx.OACSLB = 2022;
            List<CRM_OA_TRANSMIT> node = _DataAccess_TRANSIMIT.ReadByParam(nodecx).ToList();
            for (int i = 0; i < node.Count; i++)
            {
                node[i].OAZT = 2;
                _DataAccess_TRANSIMIT.Update(node[i]);
            }
        }


        public void CheckStatus()
        {
            CRM_COST_LKAYEARTT cxmodel = new CRM_COST_LKAYEARTT();
            cxmodel.ISACTIVE = 60;
            List<CRM_COST_LKAYEARTT> data = _LKAyearDataAccess.ReadByParam(cxmodel, 0).ToList();
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].ISACTIVE == 60)
                {
                    _LKAyearDataAccess.CheckStatus(data[i].LKAYEARTTID);
                }
            }
        }

        public int AutoUpdateCXHDPGHZ(int CXHDID)
        {
            CRM_COST_CXHDPGHZ cxmodel = new CRM_COST_CXHDPGHZ();
            cxmodel.CXHDID = CXHDID;
            IList<CRM_COST_CXHDPGHZ> data = _CXHDPGHZDataAccess.GetReport(cxmodel);
            if (data.Count != 0)
            {
                _CXHDPGHZDataAccess.DeleteByCXHDID(CXHDID);
                for (int i = 0; i < data.Count; i++)
                {
                    CRM_COST_CXHDPGHZ model = new CRM_COST_CXHDPGHZ();
                    model.CXHDID = data[i].CXHDID;
                    model.CPLXID = data[i].CPLXID;
                    model.SJHDSL = data[i].SJHDSL;
                    model.SJHDXS = data[i].SJHDXS;
                    model.FYZCFS = data[i].FYZCFS;
                    model.FYZC = data[i].FYZC;
                    model.FYZCJE = data[i].FYZCJE;
                    model.SJTHL = data[i].SJTHL;
                    model.BS = data[i].BS;
                    model.ISACTIVE = 1;
                    int PGHZID = _CXHDPGHZDataAccess.Create(model);

                }
                return 1;
            }
            return 0;
        }




    }
}
