using Sonluk.DAFactory;
using Sonluk.Entities.QM;
using Sonluk.Entities.System;
using Sonluk.IDataAccess.QM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.QM
{
    public class QualityNotification
    {
        private static readonly IQualityNotification _DetaAccess = QMDataAccess.CreateQualityNotification();

        public MessageInfo Create(QNInfo node)
        {
            MessageInfo message;
            if (node.Type.Equals("Q1"))
                message = CreateQ1(node);
            else
                message = _DetaAccess.Update(node);
            return message;
        }

        private MessageInfo CreateQ1(QNInfo node)
        {
            return _DetaAccess.CreateQ1(node);
        }

        public MessageInfo Update(QNInfo node)
        {
            MessageInfo message;
            switch (node.Type) 
            {
                case "Z2": message = UpdateZ2(node); break;
                case "Z3": message = UpdateZ3(node); break;
                default: message = _DetaAccess.Update(node); break;
            }
            return message;
        }

        private MessageInfo UpdateZ3(QNInfo node)
        {
            return _DetaAccess.UpdateZ3(node);
        }

        private MessageInfo UpdateZ2(QNInfo node)
        {
            return _DetaAccess.UpdateZ2(node);
        }

        public MessageInfo Update(string serialNumber, string creator)
        {
            return _DetaAccess.Update(serialNumber, creator);
        }

        public IList<QNInfo> Read(string type) 
        {
            IList<QNInfo> node;
            switch (type)
            {
                case "Z2": node = ReadZ2(); break;
                case "Z3": node = ReadZ3(); break;
                default: node = _DetaAccess.Read(); break;
            }
            return node;
        }

        public IList<QNInfo> ReadZ2() 
        {
            return _DetaAccess.ReadZ2();
        }

        private IList<QNInfo> ReadZ3()
        {
            return _DetaAccess.ReadZ3();
        }

    }
}
