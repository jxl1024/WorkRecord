using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkRecord.API.Filter
{
    public class GlobalActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("执行完");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            #region 获取参数
            var dicArguments = context.ActionArguments;

            foreach (var item in dicArguments)
            {

            }
            #endregion

            string displayName= context.ActionDescriptor.DisplayName;

            
            // context.
            Console.WriteLine("执行前");
        }
    }
}
