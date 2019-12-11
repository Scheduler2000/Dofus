using System.Windows;

namespace Renaissance.WorldEditor
{
    public enum LoadingState
    {
        InLoading,
        Loaded
    }

    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();
        }
    }
}
