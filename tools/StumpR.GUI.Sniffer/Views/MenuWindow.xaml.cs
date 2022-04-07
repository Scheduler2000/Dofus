using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SharpPcap;
using SharpPcap.LibPcap;
using StumpR.GUI.Sniffer.Models;
using StumpR.GUI.Sniffer.ViewModels;

namespace StumpR.GUI.Sniffer.Views;

public partial class MenuWindow : Window
{
    private readonly MenuViewModel _viewModel;
    
    public MenuWindow()
    {
        InitializeComponent();
        _viewModel = new MenuViewModel();
        DataContext = _viewModel;
    }
    

    private void DevicesDataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (DevicesDataGrid.SelectedItem is not Device item) return;

        ILiveDevice liveDevice = _viewModel.GetLiveDevice(item);

        new SnifferWindow(new SnifferViewModel(liveDevice), this).Show();
        
        Hide();
    }
}