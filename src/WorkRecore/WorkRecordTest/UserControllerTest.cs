using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WorkRecord.API;
using WorkRecord.Model.DTO;
using Xunit;
using Xunit.Abstractions;

namespace WorkRecordTest
{
    public class UserControllerTest
    {
        /// <summary>
        /// HttpClient对象
        /// </summary>
        public HttpClient Client { get; }

        /// <summary>
        /// 用来输出返回值
        /// </summary>
        public ITestOutputHelper Output { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="outputHelper"></param>
        public UserControllerTest(ITestOutputHelper outputHelper)
        {
            var server = new TestServer(WebHost.CreateDefaultBuilder()
          .UseStartup<Startup>());
            Client = server.CreateClient();
            Output = outputHelper;
        }

        /// <summary>
        /// 对User控制器的Get方法进行测试
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Get_ShouldBe_Ok()
        {
            // 2、Act
            var response = await Client.GetAsync($"api/user?pageIndex=1&pageSize=10");

            // Output
            string responseText = await response.Content.ReadAsStringAsync();
            // 输出返回信息
            Output.WriteLine(responseText);
            // 反序列化
            List<UserDTO> list = JsonConvert.DeserializeObject<List<UserDTO>>(responseText);

            // 3、Assert
            // 根据返回的集合个数和预期值进行比较
            Assert.Equal(3, list.Count);
        }

        [Fact]
        public async Task Post_ShouldBe_ok()
        {
            // 1、Arrange
            UserDTO entity = new UserDTO()
            {
             Password= "E10ADC3949BA59ABBE56E057F20F883E",
             UserName ="测试",
             Account="test",
             CreatedUserId= "8d19734d-5781-4f54-b31c-4258cf7e3424",
             UpdatedUserId= "8d19734d-5781-4f54-b31c-4258cf7e3424",
             RoleID= "39b5f16c-5321-4ef9-934d-3bad00e5f640",
             DepartmentID= "127ba6cf-6f64-4a31-90a0-5078c7850fd3",
             IsDel=false
            };

            var str = JsonConvert.SerializeObject(entity);
            HttpContent content = new StringContent(str);

            // 2、Act
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await Client.PostAsync("api/user", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            Output.WriteLine(responseBody);

            // 3、Assert
            Assert.Equal("1", responseBody);
        }

        [Fact]
        public async Task Put_ShouldBe_Ok()
        {
            // 1、Arrange
            UserDTO entity = new UserDTO()
            {
                UserID= "d05f4164-09ab-4d54-8c0a-70b4ded3e7a5",
                UserName = "测试2312312312",
                Password = "E10ADC3949BA59ABBE56E057F20F883E",
                //Account = "test",
                //CreatedUserId = "8d19734d-5781-4f54-b31c-4258cf7e3424",
                //UpdatedUserId = "8d19734d-5781-4f54-b31c-4258cf7e3424",
                //RoleID = "39b5f16c-5321-4ef9-934d-3bad00e5f640",
                //DepartmentID = "127ba6cf-6f64-4a31-90a0-5078c7850fd3",
                //IsDel = false
            };

            var str = JsonConvert.SerializeObject(entity);
            HttpContent content = new StringContent(str);

            // 2、Act
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await Client.PutAsync("api/user", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            Output.WriteLine(responseBody);

            // 3、Assert
            Assert.Equal("1", responseBody);
        }

        [Fact]
        public async Task Delete_ShouldBe_Ok()
        {
            // 1
            string id = "dc7b8fee-2f69-4754-82e9-32ac0a886b68";
            // 2、Act
            var response = await Client.DeleteAsync($"api/user?id={id}");

            // Output
            string responseText = await response.Content.ReadAsStringAsync();
            // 输出返回信息
            Output.WriteLine(responseText);

            // 3、Assert
            // 根据返回的集合个数和预期值进行比较
            Assert.Equal("1", responseText);
        }
    }
}
