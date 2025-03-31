using Avalonia.Controls;
using AvaPlate.ViewModels;

namespace AvaPlate.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}