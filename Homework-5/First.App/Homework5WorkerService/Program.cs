using First.App.Business.Abstract;
using First.App.Business.Concretes;
using First.App.DataAccess.EntityFramework;
using First.App.DataAccess.EntityFramework.Repository.Abstracts;
using First.App.DataAccess.EntityFramework.Repository.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework5WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<PostRetriever>();
                    services.AddHostedService<PostRecorderWorker>();
                });
    }
}
