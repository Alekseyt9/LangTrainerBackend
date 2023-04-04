
using LangTrainerServices.Impl;
using LangTrainerServices.Services;
using LangTrainerServices.ServicesImpl;
using LangTrainerServices.ServicesModel;
using Microsoft.Extensions.DependencyInjection;

namespace LangTrainerServies
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureLangServices(this IServiceCollection services)
        {
            if (services != null)
            {
                Register(services);
            }

            return services;
        }

        private static void Register(IServiceCollection services)
        {
            services.AddTransient<IDictionaryService, DictionaryService>();
            services.AddTransient<IDataLoaderService, DataLoaderService>();
            services.AddTransient<ILanguageService, LanguageService>();
            services.AddTransient<IJWTManager, JWTManager>();
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<IWordListService, WordListService>();
        }

    }
}
