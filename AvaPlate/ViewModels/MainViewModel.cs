using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AvaPlate.Data;
using AvaPlate.Models;
using AvaPlate.Services;
using CommunityToolkit.Mvvm.Input;

namespace AvaPlate.ViewModels;

public partial class MainViewModel(UserRepository userRepository,ModalErrorHandler errorHandler) : ViewModelBase
{
    public List<User> Users { get; set; } = [];
    public bool IsBusy { get; set; }
    public bool IsRefreshing { get; set; }

    public string Greeting { get; } = "苏轼\n清风徐来，水波不兴。" +
                                      "举酒属客，诵明月之诗，歌窈窕之章。少焉，" +
                                      "月出於东山之上，徘徊於斗牛之间。白露横江，" +
                                      "水光接天。纵壹苇之所如，淩万顷之茫然。" +
                                      "浩浩乎如冯虚御风，而不知其所止;飘飘乎如遗世独立，羽化而登仙。";

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