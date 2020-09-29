using Sonluk.Entities.CRM;
using Sonluk.Entities.OA;
using Sonluk.Entities.PP;
using Sonluk.Entities.QM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.OA
{
    public interface IFlow
    {
        IList<FlowInfo> Read(string templateID, int status);

        IList<FlowInfo> Read(FlowInfo keywords);

        QNInfo ReadZ3(string ID);

        IList<QNItemInfo> ReadZ3Item(string ID);

        QNInfo ReadQ1(string ID);

        bool UpdateQ1(string ID, string QualityNotification);

        IList<ProductInfo> ReadQ1Product(string ID);

        IList<ProductInfo> ReadQ1Outsourcing(string ID);

        QNInfo ReadZ2(string ID);

        bool SyncLog(FlowLogInfo node);

        IList<FlowLogInfo> SyncLog(string startDate, string endDate);

        IList<FlowLogInfo> SyncLog(string keyword);


        //CRM
       int ReadOAFinishStatus(long ID, int OACSLB,int OAZT);
       int ReadOABPMStatus(long ID);
       int ReadOADaiFaStatus(long ID);
       IList<CRM_OA_OPINION> ReadOpinion(long ID);
       void UpdateDataSource(long ID, int OACSLB);
    }
}
