using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using MaterialDesignThemes.Wpf;

using Renaissance.WorldEditor.Client.D2I.View;
using Renaissance.WorldEditor.Menu;

namespace Renaissance.WorldEditor
{
    public partial class MainWindow : Window
    {
        private readonly LoadingWindow m_loadingWindow;
        private readonly SavingWindow m_savingWindow;
        public static MainWindow Instance { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            Instance = this;

            this.m_loadingWindow = new LoadingWindow();
            this.m_savingWindow = new SavingWindow();

            var editingFormat = new List<SubItem>
            {
                new SubItem("d2i", new D2IEditorView()),
                new SubItem("d2o"),
                new SubItem("d2p")
            };

            var clientMenu = new ItemMenu("Client", editingFormat, PackIconKind.Folder);

            Menu.Children.Add(new MenuItemUserControl(clientMenu, this));
        }

        public void SwitchScreen(object sender)
        {
            if (sender is UserControl screen)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }

        }

        public void InSaving(Action action)
        {
            SwitchSaving(SavingState.inSaving);

            action();

            SwitchSaving(SavingState.Saved);
        }

        public void InLoading(Action action)
        {
            SwitchLoading(LoadingState.InLoading);

            action();

            SwitchLoading(LoadingState.Loaded);
        }

        private void SwitchLoading(LoadingState state)
        {
            switch (state)
            {
                case LoadingState.InLoading:
                    this.Hide();
                    m_loadingWindow.Show();
                    break;
                case LoadingState.Loaded:
                    m_loadingWindow.Hide();
                    this.Show();
                    break;
            }
        }

        private void SwitchSaving(SavingState state)
        {
            switch (state)
            {
                case SavingState.inSaving:
                    this.Hide();
                    m_savingWindow.Show();
                    break;
                case SavingState.Saved:
                    m_savingWindow.Hide();
                    this.Show();
                    break;
            }
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}