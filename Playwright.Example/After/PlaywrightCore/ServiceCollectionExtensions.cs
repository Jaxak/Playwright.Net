using Microsoft.Extensions.DependencyInjection;
using PW.Example.After.POM.Factories;

namespace PW.Example.After.PlaywrightCore;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPlaywright(this IServiceCollection services)
        => services.AddSingleton<IPlaywrightGetter, PlaywrightSingleton>()
            .AddScoped<IBrowserGetter, ChromiumGetter>()
            .AddScoped<IBrowserContextGetter, BrowserContextGetter>()
            .AddScoped<IPlaywrightPageGetter, PlaywrightPageGetter>()
            .AddScoped<IPageFactory, PageFactory>()
            .AddScoped<IControlFactory, SimpleControlFactory>()
            .AddScoped<IDependenciesFactory, DependencyFactory>();
}