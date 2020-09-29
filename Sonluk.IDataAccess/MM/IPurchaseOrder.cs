using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Entities.MM;
using Sonluk.Entities.SD;
using Sonluk.Entities.BC;

namespace Sonluk.IDataAccess.MM
{
    public interface IPurchaseOrder
    {
        POInfo Read(string serialNumber);

        IList<POItemInfo> Read(POKeywordInfo keyword);

        IList<POItemInfo> Read(SOKeywordInfo keyword);

        string ResetRelease(string number, string releaseCode);

        string Release(string number, string releaseCode);

        bool Update();

        string UpdateDeliveryDate(POItemInfo node);

        string UpdateSchedule(POInfo node);

        bool UpdatePrintDate(string number, string date, string time);

        IList<POItemHistoryInfo> History(string number, int itemNumber);

        IList<CustomTextInfo> CustomText(string serialNumber, int item);

        IList<ScheduleLineInfo> Schedule(string serialNumber, int item);

        StorageIdentification GetRKBSPrint(string CGXM, string TPM, string GYS, int TS, int XS, int SL, string mode, string ltbs);

        StorageIdentification GetRKBSZHPrint(int GLTS, string DYFS, string USER, string MODE, int FS, IList<ZSL_BCS104> itemNodes);

        string ZBCFUN_RKBS_CHANGE(string IV_TPM, string IV_MODE, string IV_USER);
        string ZMMFUN_GCDZ_READ(string werks);

        ZMMFUN_PURBS_READ ZMMFUN_PURBS_READ(List<ZSL_BCS303_CT> IT_PURCT);

    }
}
