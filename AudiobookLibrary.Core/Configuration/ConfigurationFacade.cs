using AudiobookLibrary.Core.Library.Factory;
using AudiobookLibrary.Core.Library.Services;
using AudiobookLibrary.Core.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AudiobookLibrary.Core.Configuration
{
    public static class ConfigurationFacade
    {
        public static AppSettings ConfigureCore(this IServiceCollection services, IConfiguration config)
        {
            var applicationCoreAssemply = typeof(AppSettings).Assembly;
            services.AddAutoMapper(applicationCoreAssemply);

            AppSettings settings = new AppSettings();
            config.Bind(settings);
            services.AddSingleton(settings);
            services.AddSingleton<NotificationService>();
            services.AddScoped<AudiobookFileFactory>();

            var dataDirectory = string.IsNullOrEmpty(settings.DataDirectory) ? "" : $"{settings.DataDirectory}/";
            services.AddDbContext<AudioLibraryContext>(options => options.UseSqlite($"Data Source={dataDirectory}Library.db"));
            services.AddMediatR(applicationCoreAssemply);

            return settings;
        }
    }
}