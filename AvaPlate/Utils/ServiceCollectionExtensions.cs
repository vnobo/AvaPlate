using AvaPlate.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AvaPlate.Utils;

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        
        collection.AddTransient<MainViewModel>();
    }
}