namespace Sonluk.Entities.API
{
    public class Helper_Insights_Config
    {
        /// <summary>
        /// API设置项唯一标识符
        /// </summary>
        public int CID { get; set; }
        /// <summary>
        /// API设置项
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// API设置项值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// API设置项描述
        /// </summary>
        public string Note { get; set; }
    }
}
