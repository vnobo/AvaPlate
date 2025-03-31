using AvaPlate.Data;
using AvaPlate.ViewModels;
using AvaPlate.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AvaPlate.Utils;

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddSingleton<UserRepository>();
    }


    public static void RegisterServices(this IServiceCollection collection)
    {
        collection.AddTransient<SecurityContext>();
    }

    public static void RegisterViewModels(this IServiceCollection collection)
    {
        collection.AddSingleton<MainViewModel>();
    }

    public static void RegisterViews(this IServiceCollection collection)
    {
        collection.AddTransient<MainWindow>();
    }
}