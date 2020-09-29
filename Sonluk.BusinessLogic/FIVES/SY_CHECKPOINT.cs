using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.DAFactory;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.FIVES;
using Sonluk.IDataAccess.HR;


namespace Sonluk.BusinessLogic.FIVES
{
    public class SY_CHECKPOINT
    {
        private static readonly ISY_CHECKPOINT _DataAccess = RMSDataAccess.CreateSY_CHECKPOINT();
        private static readonly ISY_RELATIONSHIPBIND _ReDataAccess = RMSDataAccess.CreateSY_RELATIONSHIPBIND();
        private static readonly ISY_DICT _DictDataAccess = RMSDataAccess.CreateSY_DICT();
       // private static readonly ISY_STAFF_DEP _Staff_DEPDataAccess = RMSDataAccess.CreateSY_STAFF_DEP();
        private static readonly ISY_RELATIONSHIPBIND _RELATIONDataAccess = RMSDataAccess.CreateSY_RELATIONSHIPBIND();
        private static readonly ISY_CHECKDETAILS _DetailDataAccess = RMSDataAccess.CreateSY_CHECKDETAILS();
        private static readonly ISY_DEPT ISY_DEPTdata = HRDataAccess.CreateSY_DEPT();
        private static readonly ICHECK_INFODETAIL _CheckInfodetailDataAccess = RMSDataAccess.CreateCHECK_INFODETAIL();
        private static readonly ISTAFF_DEP _STAFF_DEPDataAccess = RMSDataAccess.CreateSTAFF_DEP();
        public MES_RETURN Create(FIVES_SY_CHECKPOINT model) 
        { 
            return _DataAccess.Create(model); 
        }
        public MES_RETURN Update(FIVES_SY_CHECKPOINT model) 
        { 
            return _DataAccess.Update(model); 
        }
        public IList<FIVES_SY_CHECKPOINT> Read(FIVES_SY_CHECKPOINT model)
        { 
            return _DataAccess.Read(model);
        }
        public MES_RETURN Delete(int ID)
        { 
            return _DataAccess.Delete(ID); 
        }
        public IList<FIVES_SY_CHECKPOINTList> ReadaddDepName(FIVES_SY_CHECKPOINT model)
        {
            return _DataAccess.ReadaddDepName(model);
        }
        public FIVES_SY_CHECKPOINT_CREATE Select_ByPointID(int pointid)
        {
            FIVES_SY_CHECKPOINT_CREATE node = new FIVES_SY_CHECKPOINT_CREATE();
            MES_RETURN mr = new MES_RETURN();
            FIVES_SY_CHECKPOINT checkpointModel = new FIVES_SY_CHECKPOINT();
            checkpointModel.POINTID = pointid;
            List<FIVES_SY_CHECKPOINT> checkpointresult = _DataAccess.Read(checkpointModel).ToList();
            if (checkpointresult.Count != 1)
            {
                mr.TYPE = "E";
                mr.MESSAGE = "找不到检验点对应的信息，请联系管理员";
                node.MES_RETURN = mr;
                return node;
            };
            node.FIVES_SY_CHECKPOINT = checkpointresult[0];
            FIVES_SY_DICT dictmodel = new FIVES_SY_DICT();
            dictmodel.TYPEID = 5;
            string gwms = "检验点-岗位";
            //string mxms = "检验点-检验明细";
            string flms = "检验点分类-检验项目";
            string pointms = "检验点-检验点分类";
            List<FIVES_SY_DICT> dictresult = _DictDataAccess.Read(dictmodel).ToList();
            int gwtypeID = dictresult.FindIndex(p => p.DICNAME.Equals(gwms));
            if (gwtypeID == -1)
            {
                mr.TYPE = "E";
                mr.MESSAGE = String.Format("没有查询到字典表检验点-岗位的ID字段，请联系管理员");
                node.MES_RETURN = mr;
                return node;
            }
            int flID = dictresult.FindIndex(p => p.DICNAME.Equals(flms));
            if (flID == -1)
            {
                mr.TYPE = "E";
                mr.MESSAGE = String.Format("没有查询到字典表检验点-检验点分类的ID字段，请联系管理员");
                node.MES_RETURN = mr;
                return node;
            }
            int mxID = dictresult.FindIndex(p => p.DICNAME.Equals(pointms));
            if (mxID == -1)
            {
                mr.TYPE = "E";
                mr.MESSAGE = String.Format("没有查询到字典表检验点分类-检验项目的ID字段，请联系管理员");
                node.MES_RETURN = mr;
                return node;
            }


            FIVES_SY_RELATIONSHIPBIND relationmodel = new FIVES_SY_RELATIONSHIPBIND();
            relationmodel.OBJ1 = pointid;
            relationmodel.TYPE = dictresult[gwtypeID].DICID;
            List<FIVES_SY_RELATIONSHIPBINDList> relationresult_gw = _RELATIONDataAccess.Read(relationmodel).ToList();
            if (relationresult_gw.Count == 0)
            {
                mr.TYPE = "E";
                mr.MESSAGE = "找不到检验点对应的信息岗位负责人信息，请联系管理员";
                node.MES_RETURN = mr;
                return node;
            }
            node.GWLIST = relationresult_gw;
            relationmodel.TYPE = dictresult[mxID].DICID;
            List<FIVES_SY_RELATIONSHIPBINDList> relationresult_mx = _RELATIONDataAccess.ReadbyPoint(relationmodel).ToList();
            node.MXLIST = relationresult_mx;

            dictmodel.TYPEID = 1;
            List<FIVES_SY_DICT> pfresult = _DictDataAccess.Read(dictmodel).ToList();
            if (pfresult.Count == 0)
            {
                mr.TYPE = "E";
                mr.MESSAGE = "读取评分信息异常，请联系管理员";
                node.MES_RETURN = mr;
                return node;
            }
            node.PFLIST = pfresult;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            for (int i = 0; i < node.MXLIST.Count; i++)
            {
                if (!dic.ContainsKey(node.MXLIST[i].OBJ1NAME))
                {
                    dic.Add(node.MXLIST[i].OBJ1NAME, 1);
                    node.JydStr += "、" + node.MXLIST[i].OBJ1NAME;
                }
            }
            if (node.JydStr.Length > 0)
            {
                node.JydStr = node.JydStr.Substring(1);
            }
            mr.TYPE = "S";
            node.MES_RETURN = mr;
            return node;
           
        }
        public FIVES_SY_CHECKPOINT_CREATE CheckpointInfo_SelectAll(int staffid, int pointid)
        {
            FIVES_SY_CHECKPOINT_CREATE node = new FIVES_SY_CHECKPOINT_CREATE();
            MES_RETURN mr = new MES_RETURN();
         
            FIVES_SY_CHECKPOINT checkpointModel = new FIVES_SY_CHECKPOINT();
            checkpointModel.POINTID = pointid;
            List<FIVES_SY_CHECKPOINT> checkpointresult = _DataAccess.Read(checkpointModel).ToList();
            if (checkpointresult.Count != 1)
            {
                mr.TYPE = "E";
                mr.MESSAGE = "找不到检验点对应的信息，请联系管理员";
                node.MES_RETURN = mr;
                return node;
            };

            FIVES_STAFF_DEP AccessModel = new FIVES_STAFF_DEP();
            AccessModel.STAFFID = staffid;
            AccessModel.TYPEID = checkpointresult[0].DJ;//点检类型
            List<FIVES_STAFF_DEP> STAFF_DEPresult = _STAFF_DEPDataAccess.Read(AccessModel).ToList();
            if (STAFF_DEPresult.Count == 0)
            {
                mr.TYPE = "E";
                mr.MESSAGE = "该人员没有维护对应的检查部门权限";
                node.MES_RETURN = mr;
                return node;
            }

            node.FIVES_SY_CHECKPOINT = checkpointresult[0];
           
            int staff_depIndex = STAFF_DEPresult.FindIndex(p => p.DEPTID == node.FIVES_SY_CHECKPOINT.DID);
            if (staff_depIndex == -1)
            {
                mr.TYPE = "E";
                mr.MESSAGE = String.Format("你没有对检验点{0}评分的权限", node.FIVES_SY_CHECKPOINT.POINTMS);
                node.MES_RETURN = mr;
                return node;
            }
           
            if (node.FIVES_SY_CHECKPOINT.DJ == 0)
            {
                if (STAFF_DEPresult[staff_depIndex].TYPENAME != "抽检" && STAFF_DEPresult[staff_depIndex].TYPENAME != "巡检")
                {
                    mr.TYPE = "E";
                    mr.MESSAGE = String.Format("你没有对检验点{0}评分的权限(抽检和巡检)", node.FIVES_SY_CHECKPOINT.POINTMS);
                    node.MES_RETURN = mr;
                    return node;
                }
            }
            else
            {
                FIVES_SY_DICT Dmodel = new FIVES_SY_DICT();
                Dmodel.DICID = node.FIVES_SY_CHECKPOINT.DJ;
                List<FIVES_SY_DICT> Ddata = _DictDataAccess.Read(Dmodel).ToList();

                //  bool verify;
                if(STAFF_DEPresult[staff_depIndex].TYPENAME != Ddata[0].DICNAME)
                {
                    mr.TYPE = "E";
                    mr.MESSAGE = String.Format("你没有对检验点{0}{1}的权限", node.FIVES_SY_CHECKPOINT.POINTMS, STAFF_DEPresult[staff_depIndex].TYPENAME);
                    node.MES_RETURN = mr;
                    return node;
                }
                else
                {
                    node.LASTCHECKINFODETAIL = _CheckInfodetailDataAccess.ReadLastCheck(pointid).ToList();
                }
            }
           
           
            node.FIVES_STAFF_DEP = STAFF_DEPresult[staff_depIndex];
            FIVES_SY_DICT dictmodel = new FIVES_SY_DICT();
            dictmodel.TYPEID = 5;
            string gwms = "检验点-岗位";
            //string mxms = "检验点-检验明细";
            string flms = "检验点分类-检验项目";
            string pointms = "检验点-检验点分类";
            List<FIVES_SY_DICT> dictresult = _DictDataAccess.Read(dictmodel).ToList();
            int gwtypeID = dictresult.FindIndex(p => p.DICNAME.Equals(gwms));
            if (gwtypeID == -1)
            {
                mr.TYPE = "E";
                mr.MESSAGE = String.Format("没有查询到字典表检验点-岗位的ID字段，请联系管理员");
                node.MES_RETURN = mr;
                return node;
            }
            int flID = dictresult.FindIndex(p => p.DICNAME.Equals(flms));
            if (flID == -1)
            {
                mr.TYPE = "E";
                mr.MESSAGE = String.Format("没有查询到字典表检验点-检验点分类的ID字段，请联系管理员");
                node.MES_RETURN = mr;
                return node;
            }
            int mxID = dictresult.FindIndex(p => p.DICNAME.Equals(pointms));
            if (mxID == -1)
            {
                mr.TYPE = "E";
                mr.MESSAGE = String.Format("没有查询到字典表检验点分类-检验项目的ID字段，请联系管理员");
                node.MES_RETURN = mr;
                return node;
            }


            FIVES_SY_RELATIONSHIPBIND relationmodel = new FIVES_SY_RELATIONSHIPBIND();
            relationmodel.OBJ1 = pointid;
            relationmodel.TYPE = dictresult[gwtypeID].DICID;
            List<FIVES_SY_RELATIONSHIPBINDList> relationresult_gw = _RELATIONDataAccess.Read(relationmodel).ToList();
            if (relationresult_gw.Count == 0)
            {
                mr.TYPE = "E";
                mr.MESSAGE = "找不到检验点对应的信息岗位负责人信息，请联系管理员";
                node.MES_RETURN = mr;
                return node;
            }
            node.GWLIST = relationresult_gw;
            relationmodel.TYPE = dictresult[mxID].DICID;
            List<FIVES_SY_RELATIONSHIPBINDList> relationresult_mx = _RELATIONDataAccess.ReadbyPoint(relationmodel).ToList();
            if (node.FIVES_SY_CHECKPOINT.DJ != 0 && node.LASTCHECKINFODETAIL.Count > 0)
            {
                for (int i = 0; i < node.LASTCHECKINFODETAIL.Count; i++)
                {
                    for (int j = 0; j < relationresult_mx.Count; j++)
                    {
                        if (node.LASTCHECKINFODETAIL[i].TYPEID == relationresult_mx[j].OBJ2)
                        {
                            relationresult_mx[j].REMARK = node.LASTCHECKINFODETAIL[i].REMARK;
                        }
                    }
                }
            }


            node.MXLIST = relationresult_mx;
            
            dictmodel.TYPEID = 1;
            List<FIVES_SY_DICT> pfresult = _DictDataAccess.Read(dictmodel).ToList();
            if (pfresult.Count == 0)
            {
                 mr.TYPE = "E";
                mr.MESSAGE = "读取评分信息异常，请联系管理员";
                node.MES_RETURN = mr;
                return node;
            }
            node.PFLIST = pfresult;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            for (int i = 0; i < node.MXLIST.Count; i++)
            {
                if (!dic.ContainsKey(node.MXLIST[i].OBJ1NAME))
                {
                    dic.Add(node.MXLIST[i].OBJ1NAME, 1);
                    node.JydStr += "、" + node.MXLIST[i].OBJ1NAME;
                }
            }
            if (node.JydStr.Length > 0)
            {
                node.JydStr = node.JydStr.Substring(1);
            }
            mr.TYPE = "S";
            node.MES_RETURN = mr;

            List<FIVES_SY_RELATIONSHIPBINDList> distictList = new List<FIVES_SY_RELATIONSHIPBINDList>();
            Dictionary<string, string> mxdic = new Dictionary<string, string>();
            for (int i = 0; i < node.MXLIST.Count; i++)
            {
                if (!mxdic.ContainsKey(node.MXLIST[i].OBJ2NAME))
                {
                    mxdic.Add(node.MXLIST[i].OBJ2NAME, "helloworld");
                    distictList.Add(node.MXLIST[i]);
                }
            }
            node.MXLIST = distictList;
            return node;
        }
        public MES_RETURN Create_All(FIVES_SY_CHECKPOINT_CREATE model)
        {
            MES_RETURN mr = new MES_RETURN();
            MES_RETURN checkpoint_mr = _DataAccess.Create(model.FIVES_SY_CHECKPOINT);
            if (!checkpoint_mr.TYPE.Equals("S"))
            {

                return checkpoint_mr;
            }
            int checkpointID = Convert.ToInt32(checkpoint_mr.MESSAGE);
            FIVES_SY_DICT dictmodel = new FIVES_SY_DICT();
            dictmodel.DICNAME = "检验点-岗位";
            List<FIVES_SY_DICT> gwmodel = _DictDataAccess.Read(dictmodel).ToList();
            int gwid = gwmodel[0].DICID;
            FIVES_SY_RELATIONSHIPBIND FIVES_SY_RELATIONSHIPBIND = new FIVES_SY_RELATIONSHIPBIND();
            FIVES_SY_RELATIONSHIPBIND.OBJ1 = checkpointID;
            FIVES_SY_RELATIONSHIPBIND.TYPE = gwid;
            FIVES_SY_RELATIONSHIPBIND.ACTION = 1;
            for (int i = 0; i < model.GW.Count; i++)
            {
                FIVES_SY_RELATIONSHIPBIND.OBJ2 = model.GW[i].DICID;
                MES_RETURN mr_gw = _ReDataAccess.Create(FIVES_SY_RELATIONSHIPBIND);
                if (!mr_gw.TYPE.Equals("S"))
                {               
                    return mr_gw;
                }
            }
            dictmodel.DICNAME = "检验点-检验明细";
            List<FIVES_SY_DICT> mxmodel = _DictDataAccess.Read(dictmodel).ToList();
            int mxid = mxmodel[0].DICID;
            FIVES_SY_RELATIONSHIPBIND.TYPE = mxid;
            for (int i = 0; i < model.CHECKDETAI.Count; i++)
            {
                FIVES_SY_RELATIONSHIPBIND.OBJ2 = model.CHECKDETAI[i].DETAILID;
                MES_RETURN mr_mx = _ReDataAccess.Create(FIVES_SY_RELATIONSHIPBIND);
                if (!mr_mx.TYPE.Equals("S"))
                {
                    return mr_mx;
                }
            }
            mr.TYPE = "S";

            return mr;
        }
        public MES_RETURN Update_All(FIVES_SY_CHECKPOINT_CREATE model) {
            MES_RETURN mr = new MES_RETURN();          
            FIVES_SY_CHECKPOINT checkpoint = model.FIVES_SY_CHECKPOINT;
            MES_RETURN checkpointmr = _DataAccess.Update(checkpoint);
            if (!checkpointmr.TYPE.Equals("S"))
            {
                return checkpointmr;
            }
            int checkpointID = checkpoint.POINTID;
            FIVES_SY_RELATIONSHIPBIND deletemodel = new FIVES_SY_RELATIONSHIPBIND();
            deletemodel.OBJ1 = checkpointID;
            MES_RETURN deletemr = _RELATIONDataAccess.Delete_OJB1(deletemodel);
            if (!deletemr.TYPE.Equals("S"))
            {
                return deletemr;
            }

            
            FIVES_SY_DICT dictmodel = new FIVES_SY_DICT();
            dictmodel.DICNAME = "检验点-岗位";
            List<FIVES_SY_DICT> gwmodel = _DictDataAccess.Read(dictmodel).ToList();
            int gwid = gwmodel[0].DICID;
            FIVES_SY_RELATIONSHIPBIND FIVES_SY_RELATIONSHIPBIND = new FIVES_SY_RELATIONSHIPBIND();
            FIVES_SY_RELATIONSHIPBIND.OBJ1 = checkpointID;
            FIVES_SY_RELATIONSHIPBIND.TYPE = gwid;
            FIVES_SY_RELATIONSHIPBIND.ACTION = 1;
            for (int i = 0; i < model.GW.Count; i++)
            {
                FIVES_SY_RELATIONSHIPBIND.OBJ2 = model.GW[i].DICID;
                MES_RETURN mr_gw = _ReDataAccess.Create(FIVES_SY_RELATIONSHIPBIND);
                if (!mr_gw.TYPE.Equals("S"))
                {
                    return mr_gw;
                }
            }
            dictmodel.DICNAME = "检验点-检验明细";
            List<FIVES_SY_DICT> mxmodel = _DictDataAccess.Read(dictmodel).ToList();
            int mxid = mxmodel[0].DICID;
            FIVES_SY_RELATIONSHIPBIND.TYPE = mxid;
            for (int i = 0; i < model.CHECKDETAI.Count; i++)
            {
                FIVES_SY_RELATIONSHIPBIND.OBJ2 = model.CHECKDETAI[i].DETAILID;
                MES_RETURN mr_mx = _ReDataAccess.Create(FIVES_SY_RELATIONSHIPBIND);
                if (!mr_mx.TYPE.Equals("S"))
                {
                    return mr_mx;
                }
            }
            mr.TYPE = "S";

            return mr;
        }
        public MES_RETURN Delete_All(int pointID)
        {
           MES_RETURN mr = new MES_RETURN();
           MES_RETURN checkpointmr =  _DataAccess.Delete(pointID);
           if (!checkpointmr.TYPE.Equals("S"))
           {
               return checkpointmr;
           }
           FIVES_SY_RELATIONSHIPBIND deletemodel = new FIVES_SY_RELATIONSHIPBIND();
           deletemodel.OBJ1 = pointID;
           MES_RETURN deletemr = _RELATIONDataAccess.Delete_OJB1(deletemodel);
           if (!deletemr.TYPE.Equals("S"))
           {
               return deletemr;
           }
           mr.TYPE = "S";

           return mr;
        }
        public IList<FIVES_SY_CHECKPOINT> Compare(FIVES_SY_CHECKPOINT model)
        {
            return _DataAccess.Compare(model);
        }

    }
}
