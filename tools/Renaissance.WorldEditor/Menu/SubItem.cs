using System.Windows.Controls;

namespace Renaissance.WorldEditor.Menu
{
    public class SubItem
    {
        public string Name { get; private set; }
        public UserControl Screen { get; private set; }

        public SubItem(string name, UserControl screen = default)
        {
            this.Name = name;
            this.Screen = screen;
        }
    }
}
