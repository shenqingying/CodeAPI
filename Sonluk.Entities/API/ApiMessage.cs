using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.API
{
    /// <summary>
    /// 返回消息组的个体
    /// </summary>
    public class ApiMessage
    {
        /// <summary>
        /// 消息代码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 消息文本替换
        /// </summary>
        public object[] supply { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string message { get; set; }

        public ApiMessage() { }
        public ApiMessage(string code, params object[] supply)
        {
            this.code = code;
            this.supply = supply;
        }
    }
}
