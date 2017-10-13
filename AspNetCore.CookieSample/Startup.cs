using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using AspNetCore.CookieSample.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using System;

namespace AspNetCore.CookieSample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.SessionStore = new MemoryCacheTicketStore();
            });

            //DI
            services.AddSingleton<UserStore>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //认证
            app.UseAuthentication();
            //登录（允许匿名访问）
            app.Map("/Account/Login", builder => builder.Run(async context =>
            {
                if (context.Request.Method == "GET")
                {
                    await context.Response.WriteHtmlAsync(async res =>
                    {
                        await res.WriteAsync($"<form method=\"post\">");
                        await res.WriteAsync($"<input type=\"hidden\" name=\"returnUrl\" value=\"{HttpResponseExtensions.HtmlEncode(context.Request.Query["ReturnUrl"])}\"/>");
                        await res.WriteAsync($"<div class=\"form-group\"><label>用户名：<input type=\"text\" name=\"userName\" class=\"form-control\"></label></div>");
                        await res.WriteAsync($"<div class=\"form-group\"><label>密码：<input type=\"password\" name=\"password\" class=\"form-control\"></label></div>");
                        await res.WriteAsync($"<div class=\"form-group\"><label>记住<input type=\"checkbox\" name=\"remember\" class=\"form-control\"></label></div>");
                        await res.WriteAsync($"<button type=\"submit\" class=\"btn btn-default\">登录</button>");
                        await res.WriteAsync($"</form>");
                    });
                }
                else
                { 
                    var userStore = context.RequestServices.GetService<UserStore>();
                    var remember = context.Request.Form["remember"];
                    var user = userStore.FindUser(context.Request.Form["userName"], context.Request.Form["password"]);
                    if (user == null)
                    {
                        await context.Response.WriteHtmlAsync(async res =>
                        {
                            await res.WriteAsync($"<h1>用户名或密码错误。</h1>");
                            await res.WriteAsync("<a class=\"btn btn-default\" href=\"/Account/Login\">返回</a>");
                        });
                    }
                    else
                    {
                        var claimIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                        claimIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                        claimIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
                        claimIdentity.AddClaim(new Claim("额外的字段", "数据接收浪费时间分善良劫匪善良劫匪了设计费了设计费是龙卷风是雷锋精神了附件是雷锋精神龙卷风了设计费啦设计费啦是甲方零售价方式了甲方时间了附件是垃圾分类设计费啦设计费啦是分书法家李司法解释垃圾分类设计费零售价方式了解放路设计费啦设计费啦是甲方了设计费设计费啦设计费啦是解放路设计费啦设计费啦是甲方"));

                        var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
                        // 在上面注册AddAuthentication时，指定了默认的Scheme，在这里便可以不再指定Scheme。
                        await context.SignInAsync(claimsPrincipal, !string.IsNullOrEmpty(remember) ? new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                        } : null);
                        if (string.IsNullOrEmpty(context.Request.Form["ReturnUrl"])) context.Response.Redirect("/");
                        else context.Response.Redirect(context.Request.Form["ReturnUrl"]);
                    }
                }
            }));
            //检查是否已认证
            app.UseAuthorize();

            //用户信息
            app.Map("/profile", builder => builder.Run(async context =>
            {
                await context.Response.WriteHtmlAsync(async res =>
                {
                    await res.WriteAsync($"<h1>你好，当前登录用户： {HttpResponseExtensions.HtmlEncode(context.User.Identity.Name)}</h1>");
                    await res.WriteAsync("<a class=\"btn btn-default\" href=\"/Account/Logout\">退出</a>");
                    await res.WriteAsync($"<h2>AuthenticationType：{context.User.Identity.AuthenticationType}</h2>");

                    await res.WriteAsync("<h2>Claims:</h2>");
                    await res.WriteTableHeader(new string[] { "Claim Type", "Value" },
                        context.User.Claims.Select(c => new string[] { c.Type, c.Value }));
                });
            }));

            //登出
            app.Map("/Account/Logout", builder => builder.Run(async context =>
            {
                await context.SignOutAsync();
                context.Response.Redirect("/");
            }));

            //首页
            app.Run(async context =>
            {
                await context.Response.WriteHtmlAsync(async res =>
                {
                    await res.WriteAsync($"<h2>Hello Cookie Authentication</h2>");
                    await res.WriteAsync("<a class=\"btn btn-default\" href=\"/profile\">我的信息</a>");
                });
            });
        }
    }
}
