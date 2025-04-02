using AvaPlate.Data;
using AvaPlate.Services;
using AvaPlate.ViewModels;
using AvaPlate.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AvaPlate.Utilities;

public static class ServiceCollectionExtensions
{
    public static void RegisterServices(this IServiceCollection collection)
    {
        collection.AddTransient<SecurityContext>();
        collection.AddSingleton<UserRepository>();
        collection.AddSingleton<ModalErrorHandler>();
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