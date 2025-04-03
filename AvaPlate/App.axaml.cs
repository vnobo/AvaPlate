using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AvaPlate.Utilities;
using AvaPlate.ViewModels;
using AvaPlate.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AvaPlate;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // 注册应用程序运行所需的所有服务
        var collection = new ServiceCollection();
        collection.RegisterServices();
        collection.RegisterViews();
        collection.RegisterViewModels();

        // 从 collection 提供的 IServiceCollection 中创建包含服务的 ServiceProvider
        var services = collection.BuildServiceProvider();

        var vm = services.GetRequiredService<MainViewModel>();
        var mv = services.GetRequiredService<MainWindow>();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            mv.DataContext = vm;
            desktop.MainWindow = mv;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}