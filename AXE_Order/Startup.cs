using AXE_Order.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AXE_Order
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            lifetime.ApplicationStarted.Register(GetLogData);
        }

        private void GetLogData()
        {
            string test = Directory.GetCurrentDirectory();
            string sFileName = string.Empty;
            string sFullPath = string.Empty;
            const int nStartTime = 9;
            const int nEndTime = 16;
            for (int x = nStartTime; x < nEndTime; x++)
            {
                sFileName = $"{x.ToString("D2")}_{(x + 1).ToString("D2")}.txt";
                sFullPath = Path.Combine(Data.LogDirPath, sFileName);
                if (File.Exists(sFullPath))
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(sFullPath))
                        {
                            string line = string.Empty;

                            while ((line = sr.ReadLine()) != null)
                            {
                                try
                                {
                                    OrderInfo info = new OrderInfo();
                                    if (line.Length != 28)
                                        continue;
                                    info.CustomerCode = line.Substring(0, 4);
                                    info.StockCode = line.Substring(4, 6);
                                    info.Seq = Convert.ToInt32(line.Substring(10, 6));
                                    info.ExecutionVolumn = Convert.ToInt32(line.Substring(16, 6));
                                    info.ExecutionAmount = Convert.ToInt32(line.Substring(22, 6));
                                    Data.OrderInfo_DataList.Add(info);
                                }
                                catch (FormatException)
                                {
                                    //AddLog;
                                    continue;
                                }

                            }
                        }
                    }
                    catch (IOException)
                    {
                        //AddLog;
                    }

                }
            }
        }
    }
}
