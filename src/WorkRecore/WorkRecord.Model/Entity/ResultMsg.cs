namespace WorkRecord.Model.Entity
{
    /// <summary>
    /// 返回结果
    /// </summary>
    public  class ResultMsg
    {
        /// <summary>
        /// 编码 1：成功 2：失败
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 返回结果信息
        /// </summary>
        public string Message { get; set; }
    }
}
