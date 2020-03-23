namespace WorkRecord.Model.Jwt
{
    /// <summary>
    /// 对于appsettings.json里面的JWT
    /// </summary>
    public class JWTConfig
    {
        /// <summary>
        /// 令牌签发者
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 令牌接收者
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 加密key
        /// </summary>
        public string IssuerSigningKey { get; set; }

        /// <summary>
        /// 令牌过期时间
        /// </summary>
        public int AccessTokenExpiresMinutes { get; set; }
    }
}
