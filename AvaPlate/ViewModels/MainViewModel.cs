using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Logging;
using AvaPlate.Data;
using AvaPlate.Models;
using AvaPlate.Services;
using CommunityToolkit.Mvvm.Input;

namespace AvaPlate.ViewModels;

public partial class MainViewModel(UserRepository userRepository, ModalErrorHandler errorHandler) : ViewModelBase
{
    public List<User> Users { get; set; } = [];
    public bool IsBusy { get; set; }
    public bool IsRefreshing { get; set; }

    private async Task LoadData()
    {
        try
        {
            IsBusy = true;
            Users = await userRepository.ListAsync();
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task Refresh()
    {
        try
        {
            IsRefreshing = true;
            await LoadData();
            Logger.TryGet(LogEventLevel.Debug, LogArea.Control)?.Log(this, "正在执行 Refresh 方法");
        }
        catch (Exception e)
        {
            errorHandler.HandleError(e);
        }
        finally
        {
            IsRefreshing = false;
        }
    }
}