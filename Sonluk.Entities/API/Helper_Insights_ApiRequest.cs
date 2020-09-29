using System;
using System.Collections.Generic;

namespace Sonluk.Entities.API
{
    public class Helper_Insights_ApiRequest
    {
        /// <summary>
        /// API访问信息唯一标识符
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// API全名（系统.模块.方法）
        /// </summary>
        public string ApiName { get; set; }
        /// <summary>
        /// API相对地址（/前缀/区域/控制器/方法）
        /// </summary>
        public string ApiAdress { get; set; }
        /// <summary>
        /// API操作
        /// </summary>
        public string Operation { get; set; }
        /// <summary>
        /// 服务器IP地址
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// 客户端IP地址
        /// </summary>
        public string Client { get; set; }
        /// <summary>
        /// 登陆ID
        /// </summary>
        public int StaffID { get; set; }
        /// <summary>
        /// 请求内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? DateCreate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? DateModify { get; set; }
        /// <summary>
        /// 授权状态（anonymous：已使用匿名请求，passed：请求已授权，denied：请求授权未通过）
        /// </summary>
        public string Access { get; set; }
        /// <summary>
        /// 操作状态（in progress：请求进行中，error：请求出错，success：请求成功）
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 错误消息标记
        /// </summary>
        public string ErrorTag { get; set; }
        /// <summary>
        /// 错误消息组
        /// </summary>
        public List<Helper_Insights_ApiRequest_ErrorMsg> ErrorMessages { get; set; }

        /// <summary>
        /// 查询创建结束时间（开始时间用DateCreate）
        /// </summary>
        public DateTime? DateCreateE { get; set; }
        /// <summary>
        /// 查询修改结束时间（开始时间用DateModify）
        /// </summary>
        public DateTime? DateModifyE { get; set; }
    }

    public class Helper_Insights_ApiRequest_ErrorMsg
    {
        public long ID { get; set; }
        public long AID { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
