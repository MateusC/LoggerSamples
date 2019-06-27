using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;

namespace Api.Serilog.File
{
    public static class ApiExtensions
    {
        public static void AddLogger(this IServiceCollection services, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(
                    path: "log.txt", 
                    rollingInterval: RollingInterval.Day, 
                    rollOnFileSizeLimit: true, 
                    retainedFileCountLimit: 100)
                .CreateLogger();
        }
    }
}
