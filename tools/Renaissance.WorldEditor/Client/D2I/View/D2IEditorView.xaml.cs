using System.Windows.Controls;
using Renaissance.WorldEditor.Client.D2I.ViewModel;

namespace Renaissance.WorldEditor.Client.D2I.View
{
    /// <summary>
    /// Logique d'interaction pour D2IEditorView.xaml
    /// </summary>
    public partial class D2IEditorView : UserControl
    {
        private readonly D2IEditorViewModel m_viewModel;
        public D2IEditorView()
        {
            InitializeComponent();
            this.m_viewModel = new D2IEditorViewModel(DofusDataGrid);
            base.DataContext = m_viewModel;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        { m_viewModel.FindCommand.InvokeCanExecuteChanged(); }

        private void DofusDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m_viewModel.RemoveCommand.InvokeCanExecuteChanged();
            m_viewModel.ApplyCommand.InvokeCanExecuteChanged();
            m_viewModel.EditCommand.InvokeCanExecuteChanged();
        }
    }
}
