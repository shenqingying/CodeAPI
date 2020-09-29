using Sonluk.DAFactory;
using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.EM;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sonluk.BusinessLogic.EM
{
    public class SY_MANUALPATH
    {
        private static readonly ISY_MANUALPATH _DataAccess = RMSDataAccess.CreateEMSY_MANUALPATH();
        private static readonly IMES_MM mesdetaAccess = MESDataAccess.CreateMES_MM();
        private static readonly ISY_TYPEMX mesdetaAccess_mx = MESDataAccess.CreateSY_TYPEMX();
        private static readonly ISY_MANUAL _manualDataAccess = RMSDataAccess.CreateEMSY_MANUAL();
        private static readonly ISY_MANUALBB _manualbbDataAccess = RMSDataAccess.CreateEMSY_MANUALBB();
        private static readonly ISY_STAFF_EMTYPE _staff_emtypeDataAccess = RMSDataAccess.CreateEMSY_STAFF_EMTYPE();
        private static readonly ISY_TYPEMX _typemxmesdetaAccess = MESDataAccess.CreateSY_TYPEMX();
        private static readonly IFILE_PATH _FILEPATHDataAccess = RMSDataAccess.CreateEMFILE_PATH();
        private static readonly ISY_SBBHMANUAL _SBBHMANUALDataAccess = RMSDataAccess.CreateEMSY_SBBHMANUAL();
        public MES_RETURN Create(EM_SY_MANUALPATH model)
        {
            return _DataAccess.Create(model);
        }
        public MES_RETURN Update(EM_SY_MANUALPATH model)
        {
            return _DataAccess.Update(model);
        }
        public IList<EM_SY_MANUALPATH> Read(EM_SY_MANUALPATH model)
        {
            return _DataAccess.Read(model);
        }
        public MES_RETURN Delete(int ID)
        {
            return _DataAccess.Delete(ID);
        }
        public EM_SY_MANUALPATH_SELECT ReadByTMLangu(string tm, int staffid, string langums)
        {
            EM_SY_MANUALPATH_SELECT rst = new EM_SY_MANUALPATH_SELECT();
            string tmInit = tm;
            rst.MES_RETURN = new MES_RETURN();
            rst.EM_SY_MANUAL = new EM_SY_MANUAL();
            rst.EM_SY_MANUALBB = new EM_SY_MANUALBB();
            rst.EM_SY_MANUALPATH = new List<EM_SY_MANUALPATH>();
            rst.URLLIST = new List<MES_RETURN>();
            string typems = "";
            int typeid = 0;
            Regex regex = new Regex(@"^[0-9]*$");
            if (regex.IsMatch(tm))
            {
                if (tm.Length == 10)
                {
                    #region  搜索设备编号
                    if (tm.StartsWith("00"))
                    {
                        EM_SY_SBBHMANUAL sbbhmanualmodel = new EM_SY_SBBHMANUAL();
                        sbbhmanualmodel.SBBH = tm;
                        List<EM_SY_SBBHMANUAL> sbbhmanualList = _SBBHMANUALDataAccess.Read(sbbhmanualmodel).ToList();
                        if (sbbhmanualList.Count == 0)
                        {
                            rst.MES_RETURN.TYPE = "E";
                            rst.MES_RETURN.MESSAGE = "没有设备编号为" + tm + "对应的相关信息";
                            return rst;
                        }
                        List<EM_SY_MANUAL> manualList = new List<EM_SY_MANUAL>();

                        for (int i = 0; i < sbbhmanualList.Count; i++)
                        {
                            EM_SY_MANUAL node_manual = new EM_SY_MANUAL();
                            node_manual.MANUALID = sbbhmanualList[i].MANUALID;
                            List<EM_SY_MANUAL> nodes_manual = _manualDataAccess.Read(node_manual).ToList();
                            manualList.AddRange(nodes_manual);
                        }
                        List<EM_SY_MANUALBB> manualbbList = new List<EM_SY_MANUALBB>();
                        for (int i = 0; i < manualList.Count; i++)
                        {
                            EM_SY_MANUALBB node_bb = new EM_SY_MANUALBB();
                            node_bb.ISACTION = 1;
                            node_bb.MANUALID = manualList[i].MANUALID;
                            if (string.IsNullOrEmpty(langums))
                            {
                                langums = "zh-CN";
                            }
                            node_bb.LANGUMS = langums;
                            List<EM_SY_MANUALBB> nodes_manualbb = _manualbbDataAccess.Read(node_bb).ToList();
                            manualbbList.AddRange(nodes_manualbb);
                        }
                        if (manualbbList.Count == 0)
                        {
                            rst.MES_RETURN.TYPE = "E";
                            rst.MES_RETURN.MESSAGE = "没有设备编号为" + tm + "对应的相关版本信息";
                            return rst;
                        }
                        List<EM_SY_MANUALPATH> manualpathLst = new List<EM_SY_MANUALPATH>();
                        for (int i = 0; i < manualbbList.Count; i++)
                        {
                            EM_SY_MANUALPATH node = new EM_SY_MANUALPATH();
                            node.BBID = manualbbList[i].BBID;
                            List<EM_SY_MANUALPATH> nodes = _DataAccess.Read(node).ToList();
                            EM_SY_MANUAL manualnode = manualList.Where(p => p.MANUALID == manualList[i].MANUALID).ToList()[0];
                            for (int j = 0; j < nodes.Count; j++)
                            {
                                nodes[j].BBID = manualbbList[i].MANUALID;
                                nodes[j].CJRNAME = manualbbList[i].BBNAME;
                                nodes[j].JLTIME = manualnode.JLTIME;

                            }
                            manualpathLst.AddRange(nodes);
                        }
                        if (manualpathLst.Count == 0)
                        {
                            rst.MES_RETURN.TYPE = "E";
                            rst.MES_RETURN.MESSAGE = "没有查询到内容";

                            return rst;
                        }
                        else
                        {
                            rst.EM_SY_MANUALPATH = manualpathLst;
                            rst.EM_SY_MANUAL = manualList[0];
                            rst.EM_SY_MANUALBB = manualbbList[0];
                        }
                        rst.MES_RETURN.TYPE = "S";
                        rst.MES_RETURN.MESSAGE = "查询成功";
                        return rst;
                    }
                    #endregion
                }
            }
            return rst;
        }
        /// <summary>
        /// 未来有不同的类型的时候在工单的时候自动把typeID也找出来
        /// </summary>
        /// <param name="tm">条码/描述</param>
        /// <param name="sfaffid"></param>
        /// <returns></returns>
        public EM_SY_MANUALPATH_SELECT ReadBYTM(string tm,int sfaffid)
        {
            
            EM_SY_MANUALPATH_SELECT rst = new EM_SY_MANUALPATH_SELECT();
            string tmInit = tm;
            rst.MES_RETURN = new MES_RETURN();
            rst.EM_SY_MANUAL = new EM_SY_MANUAL();
            rst.EM_SY_MANUALBB = new EM_SY_MANUALBB();
            rst.EM_SY_MANUALPATH = new List<EM_SY_MANUALPATH>();
            rst.URLLIST = new List<MES_RETURN>();
            string typems = "";
            int typeid = 0;
            Regex regex = new Regex(@"^[0-9]*$");


            if (regex.IsMatch(tm))
            {
                if (tm.Length == 8)
                {
                    ZBCFUN_GDLIST_READ gd_rst = mesdetaAccess.GET_GDLIST_1("", "", "", tm, "2000-01-01", "2099-01-01");
                    if (!gd_rst.MES_RETURN.TYPE.Equals("S"))
                    {
                        rst.MES_RETURN = gd_rst.MES_RETURN;

                        return rst;
                    }
                    try
                    {
                        if (gd_rst.ET_POLIST.Count == 1)
                        {
                            tm = gd_rst.ET_POLIST[0].MATNR;
                        }
                        else
                        {
                            rst.MES_RETURN.TYPE = "E";
                            rst.MES_RETURN.MESSAGE = "从工单获取的信息异常,请联系管理员ZBCFUN_GDLIST_READ_1";

                            return rst;
                        }
                    }
                    catch (Exception e)
                    {

                        throw e;
                    }

                    MES_SY_TYPEMX model = new MES_SY_TYPEMX();
                    model.TYPEID = 24;
                    model.MXNAME = "包装作业指导书";
                    MES_SY_TYPEMXLIST[] mxList = mesdetaAccess_mx.SELECT(model).ToArray();
                    if (mxList.Length == 1)
                    {
                        typems = mxList[0].MXNAME;
                        typeid = mxList[0].ID;
                    }



                    List<EM_SY_STAFF_EMTYPE> roleList = _staff_emtypeDataAccess.ReadByEMTYPEMS(sfaffid, typems).ToList();
                    if (roleList.Count == 0)
                    {
                        rst.MES_RETURN.TYPE = "E";
                        rst.MES_RETURN.MESSAGE = "人员对应的查询电子文档类别权限未开通，请联系管理员";

                        return rst;
                    }
                    EM_SY_MANUAL node_manual = new EM_SY_MANUAL();
                    node_manual.TM = tm;
                    //node_manual.TYPENAME = typems;
                    List<EM_SY_MANUAL> nodes_manual = _manualDataAccess.Read(node_manual).ToList();
                    if (nodes_manual.Count == 0)
                    {
                        rst.MES_RETURN.TYPE = "E";
                        rst.MES_RETURN.MESSAGE = "没有条码" + tmInit + "对应的相关信息";
                        return rst;
                    }
                    rst.EM_SY_MANUAL = nodes_manual[0];

                    EM_SY_MANUALBB node_bb = new EM_SY_MANUALBB();
                    node_bb.ISACTION = 1;
                    node_bb.MANUALID = nodes_manual[0].MANUALID;
                    List<EM_SY_MANUALBB> nodes_manualbb = _manualbbDataAccess.Read(node_bb).ToList();
                    if (nodes_manualbb.Count == 0)
                    {
                        rst.MES_RETURN.TYPE = "E";
                        rst.MES_RETURN.MESSAGE = "没有条码对应的相关版本信息";
                        return rst;
                    }
                    tm = nodes_manualbb[0].TM;
                    rst.EM_SY_MANUALBB = nodes_manualbb[0];

                }
                else if (tm.Length == 10)
                {
                    #region tm == 10
                    if (tm.StartsWith("00"))
                    {
                        #region  搜索设备编号
                        EM_SY_SBBHMANUAL sbbhmanualmodel = new EM_SY_SBBHMANUAL();
                        sbbhmanualmodel.SBBH = tm;
                        List<EM_SY_SBBHMANUAL> sbbhmanualList =  _SBBHMANUALDataAccess.Read(sbbhmanualmodel).ToList();
                        if (sbbhmanualList.Count == 0)
                        {
                            rst.MES_RETURN.TYPE = "E";
                            rst.MES_RETURN.MESSAGE = "没有设备编号为" + tm + "对应的相关信息";
                            return rst;
                        }
                        List<EM_SY_MANUAL> manualList = new List<EM_SY_MANUAL>();
                         
                        for (int i = 0; i < sbbhmanualList.Count; i++)
                        {
                            EM_SY_MANUAL node_manual = new EM_SY_MANUAL();
                            node_manual.MANUALID = sbbhmanualList[i].MANUALID;
                            List<EM_SY_MANUAL> nodes_manual = _manualDataAccess.Read(node_manual).ToList();
                            manualList.AddRange(nodes_manual);
                        }
                        List<EM_SY_MANUALBB> manualbbList = new List<EM_SY_MANUALBB>();
                        for (int i = 0; i < manualList.Count; i++)
                        {
                             EM_SY_MANUALBB node_bb = new EM_SY_MANUALBB();
                            node_bb.ISACTION = 1;
                            node_bb.MANUALID = manualList[i].MANUALID;
                            List<EM_SY_MANUALBB> nodes_manualbb = _manualbbDataAccess.Read(node_bb).ToList();
                            manualbbList.AddRange(nodes_manualbb);
                        }
                        if (manualbbList.Count == 0)
                        {
                            rst.MES_RETURN.TYPE = "E";
                            rst.MES_RETURN.MESSAGE = "没有设备编号为" + tm + "对应的相关版本信息" ;
                            return rst;
                        }
                        List<EM_SY_MANUALPATH> manualpathLst = new List<EM_SY_MANUALPATH>();
                        for (int i = 0; i < manualbbList.Count; i++)
                        {
                            EM_SY_MANUALPATH node = new EM_SY_MANUALPATH();
                            node.BBID = manualbbList[i].BBID;
                            manualpathLst.AddRange(_DataAccess.Read(node).ToList());
                        }                       
                        if (manualpathLst.Count == 0)
                        {
                            rst.MES_RETURN.TYPE = "E";
                            rst.MES_RETURN.MESSAGE = "没有查询到内容";

                            return rst;
                        }
                        else
                        {
                            rst.EM_SY_MANUALPATH = manualpathLst;
                        }
                        rst.MES_RETURN.TYPE = "S";
                        rst.MES_RETURN.MESSAGE = "查询成功";
                        return rst;
                    #endregion
                    }
                    else
                    {
                        EM_SY_MANUAL node_manual = new EM_SY_MANUAL();
                        node_manual.TM = tm;
                        //node_manual.TYPENAME = typems;
                        List<EM_SY_MANUAL> nodes_manual = _manualDataAccess.Read(node_manual).ToList();
                        if (nodes_manual.Count == 0)
                        {
                            rst.MES_RETURN.TYPE = "E";
                            rst.MES_RETURN.MESSAGE = "没有条码" + tmInit + "对应的相关信息";
                            return rst;
                        }
                        rst.EM_SY_MANUAL = nodes_manual[0];

                        EM_SY_MANUALBB node_bb = new EM_SY_MANUALBB();
                        node_bb.ISACTION = 1;
                        node_bb.MANUALID = nodes_manual[0].MANUALID;
                        List<EM_SY_MANUALBB> nodes_manualbb = _manualbbDataAccess.Read(node_bb).ToList();
                        if (nodes_manualbb.Count == 0)
                        {
                            rst.MES_RETURN.TYPE = "E";
                            rst.MES_RETURN.MESSAGE = "没有条码对应的相关版本信息";
                            return rst;
                        }
                        tm = nodes_manualbb[0].TM;
                        rst.EM_SY_MANUALBB = nodes_manualbb[0];
                    }
                    #endregion

                }
                else
                {
                    EM_SY_MANUALBB node_bb = new EM_SY_MANUALBB();
                    node_bb.TM = tm;

                    List<EM_SY_MANUALBB> nodes_manualbb = _manualbbDataAccess.Read(node_bb).ToList();
                    if (nodes_manualbb.Count == 0)
                    {
                        rst.MES_RETURN.TYPE = "E";
                        rst.MES_RETURN.MESSAGE = "没有条码对应的相关版本信息";
                        return rst;
                    }
                    rst.EM_SY_MANUALBB = nodes_manualbb[0];

                    EM_SY_MANUAL node_manual = new EM_SY_MANUAL();
                    node_manual.MANUALID = nodes_manualbb[0].MANUALID;
                    //node_manual.TYPENAME = typems;
                    List<EM_SY_MANUAL> nodes_manual = _manualDataAccess.Read(node_manual).ToList();
                    if (nodes_manual.Count == 0)
                    {
                        rst.MES_RETURN.TYPE = "E";
                        rst.MES_RETURN.MESSAGE = "没有条码对应的相关信息";
                        return rst;
                    }
                    rst.EM_SY_MANUAL = nodes_manual[0];
                }
            }
            else
            {
                //查询描述的情况   
                EM_SY_MANUAL node_manual = new EM_SY_MANUAL();
                node_manual.MANUALMS = tm;
                typems = "设备操作规程指导书";
                MES_SY_TYPEMX mxnode = new MES_SY_TYPEMX();
                mxnode.TYPEID = 24;//
                mxnode.MXNAME = typems;
                int TYPEID = mesdetaAccess_mx.SELECT(mxnode)[0].ID;
                node_manual.TYPE = TYPEID;
                List<EM_SY_MANUAL> nodes_manual = _manualDataAccess.Read(node_manual).ToList();
                if (nodes_manual.Count == 0)
                {
                    rst.MES_RETURN.TYPE = "E";
                    rst.MES_RETURN.MESSAGE = "没有描述是" + tm + "对应的相关信息";
                    return rst;
                }
                rst.EM_SY_MANUAL = nodes_manual[0];

                EM_SY_MANUALBB node_bb = new EM_SY_MANUALBB();
                node_bb.ISACTION = 1;
                node_bb.MANUALID = nodes_manual[0].MANUALID;
                List<EM_SY_MANUALBB> nodes_manualbb = _manualbbDataAccess.Read(node_bb).ToList();
                if (nodes_manualbb.Count == 0)
                {
                    rst.MES_RETURN.TYPE = "E";
                    rst.MES_RETURN.MESSAGE = "没有描述是" + tm + "对应的相关版本信息";
                    return rst;
                }
                //tm = nodes_manualbb[0].TM;
                rst.EM_SY_MANUALBB = nodes_manualbb[0];
            }

            
         
            
                                                    
            EM_SY_MANUALPATH node_path = new EM_SY_MANUALPATH();
            node_path.BBID = rst.EM_SY_MANUALBB.BBID;
            List<EM_SY_MANUALPATH> nodes_path = _DataAccess.Read(node_path).ToList();
            if (nodes_path.Count == 0)
            {
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = "没有查询到内容";

                return rst;
            }
            else
            {
                rst.EM_SY_MANUALPATH = nodes_path;
            }
            rst.MES_RETURN.TYPE = "S";
            rst.MES_RETURN.MESSAGE = node_path.BBID.ToString();
            return rst;
        }
    }
}
