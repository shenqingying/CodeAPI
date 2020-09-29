using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
  public  class COST_PUBLIC
    {
    //  private static readonly ICOST_CLFTT _DataAccess = RMSDataAccess.CreateCOST_CLFTT();
    //   _DataAccess += RMSDataAccess.CreateCOST_CLFTT();

    //  CRM_COST_PUBLIC MODEL = new CRM_COST_PUBLIC();


      private static readonly ICOST_LKAHXZLTT _LKAHXZLDataAccess = RMSDataAccess.CreateCOST_LKAHXZLTT();
      private static readonly ICOST_ZZFTT _ZZFDataAccess = RMSDataAccess.CreateCOST_ZZFTT();

      public IList<CRM_COST_PUBLIC> ReadByPublic(CRM_COST_HXZLTT MODEL, CRM_COST_ZZFTT MODEL_JXS, CRM_COST_ZZFTT MODEL_KA, CRM_COST_ZZFTT MODEL_LKA, CRM_COST_ZZFTT MODEL_ZDWD, int STAFFID)
      {
          IList<CRM_COST_HXZLTT> LKAModel      = _LKAHXZLDataAccess.ReadByPublic(MODEL, STAFFID);
          IList<CRM_COST_ZZFTT>  ZZFModel_JXS  = _ZZFDataAccess.ReadByParam(MODEL_JXS, STAFFID);
          IList<CRM_COST_ZZFTT>  ZZFModel_KA   = _ZZFDataAccess.Read_KA(MODEL_KA, STAFFID);
          IList<CRM_COST_ZZFTT>  ZZFModel_LKA  = _ZZFDataAccess.Read_LKA(MODEL_LKA, STAFFID);
          IList<CRM_COST_ZZFTT>  ZZFModel_ZDWD = _ZZFDataAccess.Read_LKA(MODEL_ZDWD, STAFFID);

       //   IList<CRM_COST_PUBLIC> PUBLICModel = new IList<CRM_COST_PUBLIC>();

          List<CRM_COST_PUBLIC> PUBLICModel = new List<CRM_COST_PUBLIC>();

          int NUM_1 = LKAModel.Count;
          int NUM_2 = ZZFModel_JXS.Count;
          int NUM_3 = ZZFModel_KA.Count;
          int NUM_4 = ZZFModel_LKA.Count;
          int NUM_5 = ZZFModel_ZDWD.Count;



          for (int i = 0; i < NUM_1; i++)
          {
             CRM_COST_PUBLIC Temp = new CRM_COST_PUBLIC();
             Temp.LKAHXZLTT_ID = LKAModel[i].HXZLTTID;
             Temp.CJRNAME = LKAModel[i].CJRNAME;
             Temp.CJSJ = LKAModel[i].CJSJ;
             Temp.LKAHXZLTT_LKAMC = LKAModel[i].LKANAME;
             Temp.TYPE = "LKAHXZL";
             Temp.TITLE = "LKA费用核销资料-" + LKAModel[i].LKANAME;
             PUBLICModel.Add(Temp);
          }
          for (int i = 0; i <  NUM_2; i++)
          {
              CRM_COST_PUBLIC Temp = new CRM_COST_PUBLIC();
              Temp.ZZFTT_ID = ZZFModel_JXS[i].TTID;
              Temp.CJRNAME = ZZFModel_JXS[i].CJRDES;
              Temp.CJSJ = ZZFModel_JXS[i].CJSJ;
              Temp.ZZFTT_MC = ZZFModel_JXS[i].MCNAME;
              Temp.TYPE = "ZZF";
              Temp.TITLE = "制作费审核-经销商-" + ZZFModel_JXS[i].MCNAME;
              PUBLICModel.Add(Temp);
          }
          for (int i = 0; i <  NUM_3; i++)
          {
              CRM_COST_PUBLIC Temp = new CRM_COST_PUBLIC();
              Temp.ZZFTT_ID = ZZFModel_KA[i].TTID;
              Temp.CJRNAME = ZZFModel_KA[i].CJRDES;
              Temp.CJSJ = ZZFModel_KA[i].CJSJ;
              Temp.ZZFTT_MC = ZZFModel_KA[i].MCNAME;
              Temp.TYPE = "ZZF";
              Temp.TITLE = "制作费审核-KA-" + ZZFModel_KA[i].MCNAME;
              Temp.ZZFTT_HXZLMXID = ZZFModel_KA[i].HXZLMXID;
              PUBLICModel.Add(Temp);
          }
          for (int i = 0; i < NUM_4; i++)
          {
              CRM_COST_PUBLIC Temp = new CRM_COST_PUBLIC();
              Temp.ZZFTT_ID = ZZFModel_LKA[i].TTID;
              Temp.CJRNAME = ZZFModel_LKA[i].CJRDES;
              Temp.CJSJ = ZZFModel_LKA[i].CJSJ;
              Temp.ZZFTT_MC = ZZFModel_LKA[i].MCNAME;
              Temp.TYPE = "ZZF";
              Temp.TITLE = "制作费审核-LKA-" + ZZFModel_LKA[i].MCNAME;
              Temp.ZZFTT_HXZLMXID = ZZFModel_KA[i].HXZLMXID;
              PUBLICModel.Add(Temp);
          }
          for (int i = 0; i <  NUM_5; i++)
          {
              CRM_COST_PUBLIC Temp = new CRM_COST_PUBLIC();
              Temp.ZZFTT_ID = ZZFModel_ZDWD[i].TTID;
              Temp.CJRNAME = ZZFModel_ZDWD[i].CJRDES;
              Temp.CJSJ = ZZFModel_ZDWD[i].CJSJ;
              Temp.ZZFTT_MC = ZZFModel_ZDWD[i].MCNAME;
              Temp.TYPE = "ZZF";
              Temp.TITLE = "制作费审核-终端网点-" + ZZFModel_ZDWD[i].MCNAME;
              PUBLICModel.Add(Temp);
          }
          return PUBLICModel;
      }
      //public IList<CRM_COST_ZZFTT> ReadByParam(CRM_COST_ZZFTT model, int STAFFID)
      //{
      //    return _ZZFDataAccess.ReadByParam(model, STAFFID);
      //}

    

    }
}
