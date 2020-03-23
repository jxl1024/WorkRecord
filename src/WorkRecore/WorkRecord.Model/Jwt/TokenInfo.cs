using System;

namespace WorkRecord.Model.Jwt
{
    /// <summary>
    /// Token信息
    /// </summary>
    public class TokenInfo
    {
        /// <summary>
        /// Token内容
        /// </summary>
        public string TokenContent { get; set; }

        /// <summary>
        /// Token过期时间
        /// </summary>
        public DateTime TokenExpiresTime { get; set; }
    }
}
