﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_CHECK_INFOList
    {
        private int _INFOID;  //检查信息ID

        public int INFOID
        {
            get { return _INFOID; }
            set { _INFOID = value; }
        }
        private int _TYPEID;  //检查类型ID

        public int TYPEID
        {
            get { return _TYPEID; }
            set { _TYPEID = value; }
        }
        private string _TYPEMS;  //检查类型描述

        public string TYPEMS
        {
            get { return _TYPEMS; }
            set { _TYPEMS = value; }
        }
        private int _SCOREID;  //检查结果类型

        public int SCOREID
        {
            get { return _SCOREID; }
            set { _SCOREID = value; }
        }
        private string _SCOREMS;  //检查结果描述

        public string SCOREMS
        {
            get { return _SCOREMS; }
            set { _SCOREMS = value; }
        }
        private string _JLTIME;  //记录时间

        public string JLTIME
        {
            get { return _JLTIME; }
            set { _JLTIME = value; }
        }
        private int _STAFFID;  //人员ID

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        private string _STAFFNAME;  //人员名字

        public string STAFFNAME
        {
            get { return _STAFFNAME; }
            set { _STAFFNAME = value; }
        }
        private string _REMARK;  //备注

        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        private string _GC;  //工厂

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }
        private int _DEPARTID;  //部门ID

        public int DEPARTID
        {
            get { return _DEPARTID; }
            set { _DEPARTID = value; }
        }
        private string _DEPARTMS;  //部门描述

        public string DEPARTMS
        {
            get { return _DEPARTMS; }
            set { _DEPARTMS = value; }
        }
        private int _OPINTID;  //检查点ID

        public int OPINTID
        {
            get { return _OPINTID; }
            set { _OPINTID = value; }
        }
        private string _OPINTMS;  //检查点描述

        public string OPINTMS
        {
            get { return _OPINTMS; }
            set { _OPINTMS = value; }
        }
        private int _WORKSHOPID;  //车间ID

        public int WORKSHOPID
        {
            get { return _WORKSHOPID; }
            set { _WORKSHOPID = value; }
        }
        private string _WORKSHOPMS;  //车间描述

        public string WORKSHOPMS
        {
            get { return _WORKSHOPMS; }
            set { _WORKSHOPMS = value; }
        }
        private int _ACTION;  //状态

        public int ACTION
        {
            get { return _ACTION; }
            set { _ACTION = value; }
        }
        private bool _ISDELETE;  //是否删除

        public bool ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }
        private string _OPINTLOCATION;  //检查点位置

        public string OPINTLOCATION
        {
            get { return _OPINTLOCATION; }
            set { _OPINTLOCATION = value; }
        }
        string _KSTIME;

        public string KSTIME
        {
            get { return _KSTIME; }
            set { _KSTIME = value; }
        }
        string _JSTIME;

        public string JSTIME
        {
            get { return _JSTIME; }
            set { _JSTIME = value; }
        }
        private int _HG;

        public int HG
        {
            get { return _HG; }
            set { _HG = value; }
        }
        string _HGMS;

        public string HGMS
        {
            get { return _HGMS; }
            set { _HGMS = value; }
        }
        int _CHECKCOUNT;

        public int CHECKCOUNT
        {
            get { return _CHECKCOUNT; }
            set { _CHECKCOUNT = value; }
        }
        int _BHGCOUNT;

        public int BHGCOUNT
        {
            get { return _BHGCOUNT; }
            set { _BHGCOUNT = value; }
        }
        string _SHOWTIME;

        public string SHOWTIME
        {
            get { return _SHOWTIME; }
            set { _SHOWTIME = value; }
        }
        int _SHOWNAME;

        public int SHOWNAME
        {
            get { return _SHOWNAME; }
            set { _SHOWNAME = value; }
        }
        string _SHOWNAMEMS;

        public string SHOWNAMEMS
        {
            get { return _SHOWNAMEMS; }
            set { _SHOWNAMEMS = value; }
        }
        public string POSITION { get => _POSITION; set => _POSITION = value; }
        public string FREQUENCYNAME { get => _FREQUENCYNAME; set => _FREQUENCYNAME = value; }

        private string _POSITION;
        private string _FREQUENCYNAME;
    }
}