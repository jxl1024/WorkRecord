using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkRecord.API.AOP
{
    public class LogAOP : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("方法执行前");
            //在被拦截的方法执行完毕后 继续执行当前方法，注意是被拦截的是异步的
            invocation.Proceed();
            Console.WriteLine("方法执行后");
        }
    }
}
