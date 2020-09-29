using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KH_HZHB
    {
        private static readonly IKH_HZHB _KH_HZHB_DataAccess = RMSDataAccess.CreateKH_HZHB();
        private static readonly IKH_KH _KH_KH_DataAccess = RMSDataAccess.CreateKH_KH();
        private static readonly IKH_HZHB_SAP _KH_HZHB_SAPDataAccess = RMSDataAccess.CreateKH_HZHB_SAP();
        private static readonly IKH_XSQYSJ _KH_XSQYSJ_DataAccess = RMSDataAccess.CreateKH_XSQYSJ();
        private static readonly IHG_DICT _HG_DICT_DataAccess = RMSDataAccess.CreateHG_DICT();
        public int Create(CRM_KH_HZHB model)
        {
            return _KH_HZHB_DataAccess.Create(model);
        }
        public IList<CRM_KH_HZHBLIST> Read(string SAPSN)
        {
            return _KH_HZHB_DataAccess.Read(SAPSN);
        }
        public CRM_KH_XSQYSJ ReadBySAPSN(string SAPSN)
        {
            return _KH_XSQYSJ_DataAccess.ReadBySAPSN(SAPSN);
        }

        public int SapDataSynchronization(string CRMID, string SAPSN)
        {

            //if (string.IsNullOrEmpty(SAPSN))
            //{
            //    CRM_KH_KH KH_Node = new CRM_KH_KH();

            //    IList<string> sapsnArr = _KH_KH_DataAccess.Read();
            //    MultDataSync(sapsnArr);
            //    return 0;
            //}
            //else
            //{
            if (string.IsNullOrEmpty(CRMID) == false)
            {
                int verify = _KH_KH_DataAccess.Verify(SAPSN, CRMID);
                if (verify == -2)
                {
                    return -2;
                }
                else if (verify == -3)
                {
                    return -3;
                }
                CRM_KH_KH KHmodel = _KH_KH_DataAccess.ReadByCRMID(CRMID);
                SAP_HZHBList list = ReadSAPHZHB(SAPSN, KHmodel.KHLX);

                List<SAP_KH> KH_LIST = list.ET_KH;
                if (KH_LIST.Count == 0)
                {
                    return -1;

                }
                else
                {
                    int row = _KH_KH_DataAccess.UpdateSAPSN(CRMID, SAPSN);

                    if (row > 0)
                    {
                        int row1 = Modify_KH_KH(KH_LIST);
                        if (row1 > 0)
                        {
                            SingleDataSync(SAPSN);
                        }

                    }
                    return row;
                }





            }
            else
            {
                return 0;
            }

            //}


        }
        public void SAPFlow()
        {
            CRM_KH_KH KH_Node = new CRM_KH_KH();

            IList<string> sapsnArr = _KH_KH_DataAccess.Read();
            MultDataSync(sapsnArr.ToList());
        }


        private void MultDataSync(List<string> sapsnArr)
        {
            for (int i = 0; i < sapsnArr.Count; i++)
            {
                try
                {
                    SingleDataSync(sapsnArr[i]);
                }
                catch
                {
                    continue;
                }
            }
        }



        private void SingleDataSync(string sapsn)
        {
            string judge = sapsn.Substring(0, 1);
            if ((judge.Equals("1") && sapsn.Length == 6) || (judge.Equals("8") && sapsn.Length == 4))
            {

            }
            else
            {
                return;
            }

            try
            {
                int row = _KH_KH_DataAccess.DeleteSDF(sapsn);
                //
                row = _KH_HZHB_DataAccess.Delete(sapsn);
                row = _KH_XSQYSJ_DataAccess.Delete(sapsn);

                CRM_KH_KH KHmodel = _KH_KH_DataAccess.ReadBySAPSN(sapsn);
                SAP_HZHBList list = ReadSAPHZHB(sapsn, KHmodel.KHLX);
                if (list.ET_KH.Count == 0)
                {
                    return;
                }
                else
                {
                    List<SAP_KH> KH_LIST = list.ET_KH;
                    int row1 = Modify_KH_KH(KH_LIST);
                }

                List<SAP_HZHB> HZHB_nodes = list.ET_KHHZ;//ok
                List<SAP_KHXS> KHXS_nodes = list.ET_KHXS;
                for (int i = 0; i < KHXS_nodes.Count; i++)
                {
                    int count = InsertKH_XSQYSJ(KHXS_nodes[i]);
                }
                for (int i = 0; i < HZHB_nodes.Count; i++)
                {
                    int count = InsertKH_HZHB(HZHB_nodes[i]);

                    if (HZHB_nodes[i].PARVW == "WE")
                    {
                        //Verify(HZHB_nodes[i].KUNNR);
                        SAP_HZHBList list1 = ReadSAPHZHB(HZHB_nodes[i].KUNN2,0);

                        List<SAP_KH> KH_list = list1.ET_KH;

                        Modify_KH_KH(KH_list);
                    }

                }
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }





        }

        private int InsertKH_HZHB(SAP_HZHB node)
        {
            CRM_KH_HZHB model = new CRM_KH_HZHB();
            model.SAPSN = Convert.ToString(Convert.ToInt32(node.KUNNR)); ;
            model.XSZZ = node.VKORG;
            model.FXQD = node.VTWEG;
            model.CPZ = node.SPART;
            model.HZHBGN = node.PARVW;
            model.HZHBJSQ = Convert.ToInt32(node.PARZA);
            model.HZHBKHID = Convert.ToString(Convert.ToInt32(node.KUNN2)); ;
            model.SFSAPSJ = 1;
            model.ISACTIVE = 1;
            model.BEIZ = "";
            return Create(model);

        }
        private int InsertKH_XSQYSJ(SAP_KHXS node)
        {
            CRM_KH_XSQYSJ model = new CRM_KH_XSQYSJ();
            model.SAPSN = Convert.ToString(Convert.ToInt32(node.KUNNR));
            model.XSZZ = node.VKORG;
            model.FXQD = node.VTWEG;
            model.CPZ = node.SPART;
            model.XSDQ = node.BZIRK;
            model.XSBM = node.VKBUR;
            model.XSZ = node.VKGRP;
            model.ISACTIVE = 1;
            model.BEIZ = "";
            return _KH_XSQYSJ_DataAccess.Create(model);
        }


        private int Verify(string SAPSN, string CRMID)
        {
            return _KH_KH_DataAccess.Verify(SAPSN, CRMID);
        }
        public SAP_HZHBList ReadSAPHZHB(string SAPSN,int KHLX)
        {
            IList<SAP_KH> SAP_KH_nodes = new List<SAP_KH>();
            SAP_KH SAP_KH_node = new SAP_KH();
            SAP_KH_node.KUNNR = SAPSN;
            SAP_KH_nodes.Add(SAP_KH_node);

            SAP_HZHBList list = _KH_HZHB_SAPDataAccess.SyncSapRead(SAP_KH_nodes, KHLX);
            return list;
        }
        public SAP_HZHBList SyncSapRead(IList<SAP_KH> t_KH,int khlx)
        {
            return _KH_HZHB_SAPDataAccess.SyncSapRead(t_KH, khlx);
        }

        public int Modify_KH_KH(List<SAP_KH> nodes)
        {
            int row = 0;
            for (int i = 0; i < nodes.Count; i++)
            {
                SAP_KH obj = nodes[i];
                obj.BEZEI = _HG_DICT_DataAccess.ReadDICIDandType(obj.BEZEI,1).ToString();//省份
                obj.ORT01 = _HG_DICT_DataAccess.ReadDICIDandType(obj.ORT01,2).ToString();//城市

                row += _KH_KH_DataAccess.Modify(nodes[i]);
            }
            return row;
        }

    }
}
