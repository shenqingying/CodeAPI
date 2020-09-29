using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class CRM_HG
    {
        private static readonly ICRM_HG _DetaAccess = RMSDataAccess.CreateCRM_HG();
        public List<CRM_HG_DICT> SelectHG_DICTwithTYPEID(int typeID, int fid)//CRM_HG_DICT KH_S
        {
            DataTable dt = _DetaAccess.SelectHG_DICTwithTYPEID(typeID,fid);
            List<CRM_HG_DICT> list = DataTableToList<CRM_HG_DICT>(dt);
            return list;
        }



        /// <summary>  
        /// 将Datatable转换为List集合  
        /// </summary>  
        /// <typeparam name="T">类型参数</typeparam>  
        /// <param name="dt">datatable表</param>  
        /// <returns></returns>  
        public static List<T> DataTableToList<T>(DataTable dt)
        {
            var list = new List<T>();
            Type t = typeof(T);
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());

            foreach (DataRow item in dt.Rows)
            {
                T s = System.Activator.CreateInstance<T>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    PropertyInfo info = plist.Find(p => p.Name == dt.Columns[i].ColumnName);
                    if (info != null)
                    {
                        if (!Convert.IsDBNull(item[i]))
                        {
                            info.SetValue(s, item[i], null);
                        }
                    }
                }
                list.Add(s);
            }
            return list;
        }  

    }
   
}
