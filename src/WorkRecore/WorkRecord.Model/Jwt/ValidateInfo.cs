using System;
using System.Collections.Generic;
using System.Text;

namespace WorkRecord.Model.Jwt
{
    public class ValidateInfo
    {
        /// <summary>
        /// 编码 0 成功 1失败
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 验证消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///  验证成功时返回的Token信息
        /// </summary>
        public string TokenContent { get; set; }
    }
}
