using System.Collections.Generic;
using System.Windows.Controls;

using MaterialDesignThemes.Wpf;

namespace Renaissance.WorldEditor.Menu
{
    public class ItemMenu
    {
        public string Header { get; private set; }
        public PackIconKind Icon { get; private set; }
        public List<SubItem> SubItems { get; private set; }

        public UserControl Screen { get; private set; }


        public ItemMenu(string header, List<SubItem> subItems, PackIconKind icon, UserControl screen = default)
        {
            this.Header = header;
            this.SubItems = subItems;
            this.Icon = icon;
            this.Screen = screen;
        }
    }
}
