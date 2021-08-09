using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace AudiobookLibrary.Test
{
    public class TestFixture : IDisposable
    {
        public readonly IServiceProvider ServiceProvider;
        public TestFixture()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets<TestFixture>();

            IConfigurationRoot config = builder.Build();

            var services = new ServiceCollection();

            IFileProvider physicalFileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
            ConfigurationFacade.Configure(services, config, physicalFileProvider);

            ServiceProvider = services.BuildServiceProvider();
        }
        public void Dispose()
        {
        }
    }
}