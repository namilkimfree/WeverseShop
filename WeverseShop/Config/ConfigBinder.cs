using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeverseShop.Manager;


namespace WeverseShop.Config
{
    /// <summary>
    /// ConfigBinder 
    /// 설정 파일 Read
    /// DI 디펜던시 인젝션 기능 관리
    /// </summary>
    public class ConfigBinder
    {
        protected IConfiguration Configuration;
        protected IServiceProvider ServiceProvider;

        /// <summary>
        /// SingInstance 
        /// </summary>
        private static Lazy<ConfigBinder> _lazy = new Lazy<ConfigBinder>(new ConfigBinder());

        public static ConfigBinder ConfigInstance => _lazy.Value;

        public void ServiceConfiguration()
        {
            
            var environment = Environment.GetEnvironmentVariable("Weverse");
            var currentDirectory = Directory.GetCurrentDirectory();

            Configuration = new ConfigurationBuilder()
                .SetBasePath(currentDirectory)
                .AddJsonFile($"appsettings.{environment}.json")
                .Build();

            var appConfig = Configuration.GetSection("AppiumOptions").Get<GlobalConfig>();
            var appPath = Path.Combine(currentDirectory, appConfig.App);

            appConfig.App = appPath;

            var appiumService = new AppiumService();
            var appiumManager = new AppiumManager(appiumService, appConfig);
            var appiumHelper = new AppiumHelper(appiumManager);


            ServiceProvider = new ServiceCollection()
                .AddSingleton(appiumManager)
                .AddSingleton(appiumHelper)
                .BuildServiceProvider();
        }


        /// <summary>
        /// 필요한 Service Instance 가져오는 기능
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetService<T>()
        {
            var service = ServiceProvider.GetService<T>();

            return service;
        }


    }
}