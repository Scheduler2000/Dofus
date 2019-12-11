using System.Windows;
using System.Windows.Controls;

namespace Renaissance.WorldEditor.Menu
{
    /// <summary>
    /// <see cref="MenuItemUserControl"/> représente un menu avec ses sous items
    /// </summary>
    public partial class MenuItemUserControl : UserControl
    {
        private readonly MainWindow m_context;

        public MenuItemUserControl(ItemMenu itemMenu, MainWindow context)
        {
            InitializeComponent();

            m_context = context;

            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            base.DataContext = itemMenu;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { m_context.SwitchScreen(((SubItem)((ListView)sender).SelectedItem).Screen); }
    }
}
