﻿
using LangTrainerServices.Impl;
using LangTrainerServices.Model;
using LangTrainerServices.Services;
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
            services.AddTransient<ILangService, LangService>();
            services.AddTransient<IDataLoaderService, DataLoaderService>();
        }

    }
}