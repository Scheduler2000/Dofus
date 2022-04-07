using System;
using System.Windows;
using System.Windows.Input;
using StumpR.GUI.Sniffer.Models;
using StumpR.GUI.Sniffer.ViewModels;

namespace StumpR.GUI.Sniffer.Views;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class SnifferWindow : Window
{
    private readonly MenuWindow _caller;
    private readonly SnifferViewModel _viewModel;
    
    public SnifferWindow(SnifferViewModel viewModel, MenuWindow caller)
    {
        
        InitializeComponent();
        
        _caller = caller;
        _viewModel = viewModel;
        
        DataContext = _viewModel;
        
    }

    private void MessagesGridView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (MessagesGridView.SelectedItem is not SniffedPacket item) return;
        
        JsonDataTextBox.Text = item.JsonData;
        HexDataTextBox.Text = item.RawHexData;
    }
    
    private void SnifferWindow_OnClosed(object sender, EventArgs e)
    {
        _viewModel.Dispose();
       _caller.Show();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        _viewModel.SniffedPackets.Clear();
        
        JsonDataTextBox.Text = string.Empty;
        HexDataTextBox.Text = string.Empty;
    }
}