using log4net;
using System;
using System.Text;

namespace WorkRecord.Common.Log
{
    public class LogHelper
    {
        private static readonly ILog logerror = LogManager.GetLogger(InitRepository.LogRepository.Name, "logerror");

        #region 全局异常错误记录持久化
        /// <summary>
        /// 全局异常错误记录持久化
        /// </summary>
        /// <param name="throwMsg"></param>
        /// <param name="ex"></param>
        public static void ErrorLog(string throwMsg, Exception ex)
        {
            StringBuilder sbLog = new StringBuilder();
            sbLog.Append($"\r\n【异常发生时间】：{DateTime.Now.ToString()}");
            sbLog.Append($"\r\n【异常类型】：{ex.GetType().Name}");
            sbLog.Append($"\r\n【异常信息】：{ex.Message}");
            sbLog.Append($"\r\n【堆栈调用】：{ex.StackTrace}");
            logerror.Error(sbLog.ToString());
        }
        #endregion
    }
}
                                                