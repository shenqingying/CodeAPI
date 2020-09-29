using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.DAFactory;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.FIVES;


namespace Sonluk.BusinessLogic.FIVES
{
    public class CHECK_INFO
    {
        private static readonly ICHECK_INFO _DataAccess = RMSDataAccess.CreateCHECK_INFO();

        public MES_RETURN Create(FIVES_CHECK_INFO model) 
        {
            MES_RETURN mr = new MES_RETURN();
            mr = _DataAccess.Create(model);
            if(mr.TYPE == "E")
            {
                mr.MESSAGE = "当天检验点今天已新增，不允许重复添加";
            }
            return mr;
          //  return _DataAccess.Create(model);
        } 
        public MES_RETURN Update(FIVES_CHECK_INFO model) 
        { 
            return _DataAccess.Update(model); 
        }
        public IList<FIVES_CHECK_INFOList> Read(FIVES_CHECK_INFOList model) 
        { 
            return _DataAccess.Read(model);
        }
         public IList<FIVES_CHECK_INFOList> Read_HZINFO(FIVES_CHECK_INFOList model) 
        { 
            return _DataAccess.Read_HZINFO(model);
        }
       
        public MES_RETURN Delete(int ID)
        {
            return _DataAccess.Delete(ID);
        }

    }
}
