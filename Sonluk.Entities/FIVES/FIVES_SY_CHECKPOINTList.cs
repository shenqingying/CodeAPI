﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_CHECKPOINTList
    {
        private int _POINTID;  //检查点ID

        public int POINTID
        {
            get { return _POINTID; }
            set { _POINTID = value; }
        }
        private string _LOCATIONMS;  //检查点位置

        public string LOCATIONMS
        {
            get { return _LOCATIONMS; }
            set { _LOCATIONMS = value; }
        }
        private string _POINTMS;  //检查点描述

        public string POINTMS
        {
            get { return _POINTMS; }
            set { _POINTMS = value; }
        }
        private int _DID;  //部门ID

        public int DID
        {
            get { return _DID; }
            set { _DID = value; }
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
        private string _DNAME;

        public string DNAME
        {
            get { return _DNAME; }
            set { _DNAME = value; }
        }
        private int _DJ;

        public int DJ
        {
            get { return _DJ; }
            set { _DJ = value; }
        }
        public int FREQUENCY { get => _FREQUENCY; set => _FREQUENCY = value; }
        public string FREQUENCYNAME { get => _FREQUENCYNAME; set => _FREQUENCYNAME = value; }
        public int ISNEED { get => _ISNEED; set => _ISNEED = value; }
        public string CODE { get => _CODE; set => _CODE = value; }
        public string VIEWS { get => _VIEWS; set => _VIEWS = value; }

        private int _FREQUENCY;
        private string _FREQUENCYNAME;
        private int _ISNEED;
        private string _CODE;
        private string _VIEWS;

    }
}