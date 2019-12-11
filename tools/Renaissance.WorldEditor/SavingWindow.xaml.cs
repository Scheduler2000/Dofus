using System.Windows;

namespace Renaissance.WorldEditor
{

    public enum SavingState
    {
        inSaving,
        Saved
    }

    public partial class SavingWindow : Window
    {
        public SavingWindow()
        {
            InitializeComponent();
        }
    }
}
