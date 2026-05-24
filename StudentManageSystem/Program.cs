using Microsoft.EntityFrameworkCore;
using StudentManageSystem.Context;

namespace StudentManageSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 注册容器
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // 解决有没有的问题
            // 注册所有依赖服务
            builder.Services.AddRazorPages();

            // 注册数据库依赖
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // 添加中间件，解决需不需要的问题，有些中间件不需要可以不加
            // 管道指定应用程序如何响应HTTP请求

            // 开发环境的判断：开发环境还是生产环境
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // 中间件，一个Http请求应该通过哪些验证
            app.UseHttpsRedirection();  // 强制使用https类型访问
            app.UseStaticFiles();       // 静态文件（wwwroot文件夹），没有这个中间件无法使用静态文件

            app.UseRouting();           // 分配路由

            app.UseAuthentication();    // 身份验证

            app.UseAuthorization();     // 授权

            app.MapRazorPages();

            app.Run();
        }
    }
}
