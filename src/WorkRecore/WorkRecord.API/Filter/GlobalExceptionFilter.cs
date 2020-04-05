using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Extensions.Logging;
//using Microsoft.IdentityModel.Logging;
using System;
using System.Net;
using WorkRecord.Common.Log;

namespace WorkRecord.API.Filter
{
    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter
    {

        readonly IHostingEnvironment _env;

        public GlobalExceptionFilter(IHostingEnvironment env)
        {
            _env = env;
        }


        public void OnException(ExceptionContext context)
        {
            var jsonErrorResponse = new JsonErrorResponse();
            // 记录生产环境日志信息
            jsonErrorResponse.Message = context.Exception.Message;

            if (_env.IsDevelopment())
            {
                jsonErrorResponse.DeveloperMessage = context.Exception;
            }

            context.Result = new ApplicationErrorResult(jsonErrorResponse);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            context.ExceptionHandled = true;

            // 使用log4net记录错误日志
            LogHelper.ErrorLog(jsonErrorResponse.Message,context.Exception);
        }
    }

    /// <summary>
    /// 获取HttpCode状态码
    /// </summary>
    public class ApplicationErrorResult : ObjectResult
    {
        public ApplicationErrorResult(object value) : base(value)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }



    public class JsonErrorResponse
    {
        /// <summary>
        /// 生产环境日志信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 开发环境日志信息
        /// </summary>
        public object DeveloperMessage { get; set; }
    }
}
