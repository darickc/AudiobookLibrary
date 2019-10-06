using AudiobookLibrary.Core.Persistance;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace AudiobookLibrary.Core.Confguration
{
    public class ConfigurationFacade
    {
        public static AppSettings Configure(IServiceCollection services, IConfigurationRoot config, IFileProvider contentRoot)
        {
            ConfigureMapper();
            return ConfigureDependencies(services, config, contentRoot);
        }

        private static void ConfigureMapper()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfiles(typeof(ConfigurationFacade).Assembly);
            });
        }

        private static AppSettings ConfigureDependencies(IServiceCollection services, IConfigurationRoot config, IFileProvider contentRoot)
        {
            var applicationCoreAssemply = typeof(AppSettings).Assembly;

            AppSettings settings = new AppSettings();
            config.Bind(settings);
            services.AddSingleton(settings);

            services.AddDbContext<AudioLibraryContext>(options => options.UseSqlite("Data Source=Library.db"));
            services.AddMediatR(applicationCoreAssemply);

            return settings;
        }
    }
}