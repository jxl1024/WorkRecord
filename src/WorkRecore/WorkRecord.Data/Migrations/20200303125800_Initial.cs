using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkRecord.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Department",
                columns: table => new
                {
                    DeptID = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedUserId = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedUserId = table.Column<string>(maxLength: 50, nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "DATETIME", nullable: false, computedColumnSql: "GETDATE()"),
                    DeptCode = table.Column<string>(maxLength: 16, nullable: true),
                    DeptName = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Department", x => x.DeptID);
                });

            migrationBuilder.CreateTable(
                name: "T_Role",
                columns: table => new
                {
                    RoleID = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedUserId = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedUserId = table.Column<string>(maxLength: 50, nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "DATETIME", nullable: false, computedColumnSql: "GETDATE()"),
                    RoleCode = table.Column<string>(maxLength: 16, nullable: true),
                    RoleName = table.Column<string>(maxLength: 32, nullable: true),
                    IsDel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "T_User",
                columns: table => new
                {
                    UserID = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedUserId = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedUserId = table.Column<string>(maxLength: 50, nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "DATETIME", nullable: false, computedColumnSql: "GETDATE()"),
                    Account = table.Column<string>(maxLength: 32, nullable: false),
                    Password = table.Column<string>(maxLength: 32, nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    RoleID = table.Column<string>(maxLength: 50, nullable: false),
                    DepartmentID = table.Column<string>(maxLength: 50, nullable: false),
                    IsDel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "T_WorkItem",
                columns: table => new
                {
                    WorkID = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedUserId = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedUserId = table.Column<string>(maxLength: 50, nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "DATETIME", nullable: false, computedColumnSql: "GETDATE()"),
                    WorkContent = table.Column<string>(nullable: true),
                    RecordTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Memos = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WorkItem", x => x.WorkID);
                });

            migrationBuilder.InsertData(
                table: "T_Department",
                columns: new[] { "DeptID", "CreatedUserId", "DeptCode", "DeptName", "UpdatedUserId" },
                values: new object[,]
                {
                    { "127ba6cf-6f64-4a31-90a0-5078c7850fd3", "8d19734d-5781-4f54-b31c-4258cf7e3424", "1001", "开发部", "8d19734d-5781-4f54-b31c-4258cf7e3424" },
                    { "87030fb0-fb51-4a6d-934b-19615fba6bd1", "8d19734d-5781-4f54-b31c-4258cf7e3424", "2001", "综合管理部", "8d19734d-5781-4f54-b31c-4258cf7e3424" }
                });

            migrationBuilder.InsertData(
                table: "T_Role",
                columns: new[] { "RoleID", "CreatedUserId", "IsDel", "RoleCode", "RoleName", "UpdatedUserId" },
                values: new object[,]
                {
                    { "6230ae3d-2014-4a8b-81b4-565e2f053423", "8d19734d-5781-4f54-b31c-4258cf7e3424", false, "1", "系统管理员", "8d19734d-5781-4f54-b31c-4258cf7e3424" },
                    { "b96ea97b-0681-4034-b317-2d0eaf3dfeed", "8d19734d-5781-4f54-b31c-4258cf7e3424", false, "2", "部门管理员", "8d19734d-5781-4f54-b31c-4258cf7e3424" },
                    { "39b5f16c-5321-4ef9-934d-3bad00e5f640", "8d19734d-5781-4f54-b31c-4258cf7e3424", false, "3", "普通员工", "8d19734d-5781-4f54-b31c-4258cf7e3424" }
                });

            migrationBuilder.InsertData(
                table: "T_User",
                columns: new[] { "UserID", "Account", "CreatedUserId", "DepartmentID", "IsDel", "Name", "Password", "RoleID", "UpdatedUserId" },
                values: new object[,]
                {
                    { "8d19734d-5781-4f54-b31c-4258cf7e3424", "System", "8d19734d-5781-4f54-b31c-4258cf7e3424", "87030fb0-fb51-4a6d-934b-19615fba6bd1", false, "系统管理员", "E10ADC3949BA59ABBE56E057F20F883E", "6230ae3d-2014-4a8b-81b4-565e2f053423", "8d19734d-5781-4f54-b31c-4258cf7e3424" },
                    { "88ee150f-78aa-4a06-8600-76683207f01c", "admin", "8d19734d-5781-4f54-b31c-4258cf7e3424", "127ba6cf-6f64-4a31-90a0-5078c7850fd3", false, "admin", "E10ADC3949BA59ABBE56E057F20F883E", "b96ea97b-0681-4034-b317-2d0eaf3dfeed", "8d19734d-5781-4f54-b31c-4258cf7e3424" },
                    { "d05f4164-09ab-4d54-8c0a-70b4ded3e7a5", "张三", "8d19734d-5781-4f54-b31c-4258cf7e3424", "127ba6cf-6f64-4a31-90a0-5078c7850fd3", false, "张三", "E10ADC3949BA59ABBE56E057F20F883E", "39b5f16c-5321-4ef9-934d-3bad00e5f640", "8d19734d-5781-4f54-b31c-4258cf7e3424" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Department");

            migrationBuilder.DropTable(
                name: "T_Role");

            migrationBuilder.DropTable(
                name: "T_User");

            migrationBuilder.DropTable(
                name: "T_WorkItem");
        }
    }
}
