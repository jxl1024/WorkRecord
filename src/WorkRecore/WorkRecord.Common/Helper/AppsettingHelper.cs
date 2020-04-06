using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkRecord.Common.Helper
{
    /// <summary>
    /// appsettings.json操作类
    /// </summary>
    public class AppsettingHelper
    {
        public static IConfiguration Configuration { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="jsonFilePath">json文件路径</param>
        /// <param name="jsonFileName">json文件名称</param>
        public AppsettingHelper(string jsonFilePath,string jsonFileName)
        {
            Configuration=new ConfigurationBuilder()
                               .SetBasePath(jsonFilePath)
               .Add(new JsonConfigurationSource { Path = jsonFileName, Optional = false, ReloadOnChange = true })//这样的话，可以直接读目录里的json文件，而不是 bin 文件夹下的，所以不用修改复制属性
               .Build();
        }

        /// <summary>
        /// 获取json文件中的key
        /// </summary>
        /// <param name="conditions">条件</param>
        /// <returns></returns>
        public static string GetValueByKey(params string[] conditions)
        {
            string value = "";
            try
            {
                if(conditions.Any())
                {
                    // 以：把所有的路径连接起来形成key
                    value = Configuration[string.Join(":", conditions)];
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return value;
        }
    }
}
