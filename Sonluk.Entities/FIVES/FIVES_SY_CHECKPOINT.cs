using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_CHECKPOINT
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
        private int _DJ;

        public int DJ
        {
            get { return _DJ; }
            set { _DJ = value; }
        }
        private string _SHOWNAMEMS;

        public string SHOWNAMEMS
        {
            get { return _SHOWNAMEMS; }
            set { _SHOWNAMEMS = value; }
        }
        private string _KSTIME;

        public string KSTIME
        {
            get { return _KSTIME; }
            set { _KSTIME = value; }
        }
        private string _JSTIME;

        public string JSTIME
        {
            get { return _JSTIME; }
            set { _JSTIME = value; }
        }
        private int _NUM;//判断当天已检验地点或未检验地点

        public int NUM
        {
            get { return _NUM; }
            set { _NUM = value; }
        }
        private int _INFOID;

        public int INFOID
        {
            get { return _INFOID; }
            set { _INFOID = value; }
        }
        private string _DEPARTMS;

        public string DEPARTMS
        {
            get { return _DEPARTMS; }
            set { _DEPARTMS = value; }
        }
        public int FREQUENCY { get => _FREQUENCY; set => _FREQUENCY = value; }
        public string FREQUENCYNAME { get => _FREQUENCYNAME; set => _FREQUENCYNAME = value; }
        public int ISNEED { get => _ISNEED; set => _ISNEED = value; }
        public string CODE { get => _CODE; set => _CODE = value; }
        public string VIEWS { get => _VIEWS; set => _VIEWS = value; }

        private int _FREQUENCY;//频率
        private string _FREQUENCYNAME;
        private int _ISNEED;//是否需要点检人员
        private string _CODE;//排序字段
        private string _VIEWS;//跳转页面
    }
}
