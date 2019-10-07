using AudiobookLibrary.Core.Library.Factory;
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
            return ConfigureDependencies(services, config, contentRoot);
        }


        private static AppSettings ConfigureDependencies(IServiceCollection services, IConfigurationRoot config, IFileProvider contentRoot)
        {
            var applicationCoreAssemply = typeof(AppSettings).Assembly;
            services.AddAutoMapper(applicationCoreAssemply);

            AppSettings settings = new AppSettings();
            config.Bind(settings);
            services.AddSingleton(settings);
            services.AddScoped<AudiobookFileFactory>();

            var dataDirectory = string.IsNullOrEmpty(settings.DataDirectory) ? "" : $"{settings.DataDirectory}/";
            services.AddDbContext<AudioLibraryContext>(options => options.UseSqlite($"Data Source={dataDirectory}Library.db"));
            services.AddMediatR(applicationCoreAssemply);

            return settings;
        }
    }
}