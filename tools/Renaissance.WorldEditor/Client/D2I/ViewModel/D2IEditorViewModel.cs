using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using Microsoft.Win32;

using Renaissance.Data.D2I;
using Renaissance.Data.Utils;
using Renaissance.WorldEditor.Client.D2I.Grid;
using Renaissance.WorldEditor.Command;

namespace Renaissance.WorldEditor.Client.D2I.ViewModel
{
    public class D2IEditorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int m_highestId;
        private string m_editText;
        private string m_searchType;
        private string m_searchText;

        private Queue<D2IRow> m_searched;
        private readonly DataGrid m_dofusGrid;

        private D2IManager m_editor;

        public ObservableCollection<D2IRow> Rows { get; }

        public DelegateCommand LoadCommand { get; }

        public DelegateCommand FindCommand { get; }

        public DelegateCommand FindNextCommand { get; }

        public DelegateCommand AddTextRowCommand { get; }

        public DelegateCommand AddTextUiCommand { get; }

        public DelegateCommand RemoveCommand { get; }

        public DelegateCommand ResetCommand { get; }

        public DelegateCommand SaveCommand { get; }

        public DelegateCommand ApplyCommand { get; }

        public DelegateCommand EditCommand { get; }

        public string SearchType
        {
            get { return m_searchType; }

            set
            {
                if (string.Equals(value, m_searchType, StringComparison.Ordinal))
                    return;

                m_searchType = value;
            }
        }

        public string SearchText
        {
            get { return m_searchText; }

            set
            {
                if (string.Equals(value, m_searchText, StringComparison.Ordinal))
                    return;
                if (m_searched.Count > 0)
                    m_searched.Clear();

                FindNextCommand.InvokeCanExecuteChanged();
                m_searchText = value;

                OnPropertyChanged("SearchText");
                FindCommand.InvokeCanExecuteChanged();
            }
        }

        public string EditText
        {
            get { return m_editText; }

            set
            {
                if (string.Equals(value, m_editText, StringComparison.Ordinal))
                    return;

                m_editText = value;
                OnPropertyChanged("EditText");
                ApplyCommand.InvokeCanExecuteChanged();
            }
        }

        public D2IEditorViewModel(DataGrid dataGrid)
        {
            this.m_searchType = "Id";
            this.m_searched = new Queue<D2IRow>();
            this.m_dofusGrid = dataGrid;

            this.Rows = new ObservableCollection<D2IRow>();

            this.LoadCommand = new DelegateCommand(Load, (commandParameter) => m_editor == null);
            this.FindCommand = new DelegateCommand(Find, (commandParamater) => !string.IsNullOrEmpty(m_searchType) &&
                                                                               !string.IsNullOrEmpty(m_searchText));
            this.FindNextCommand = new DelegateCommand(FindNext, (commandParameter) => m_searched.Count() > 0);
            this.AddTextRowCommand = new DelegateCommand(AddTextRow, (commandParameter) => m_editor != null);
            this.AddTextUiCommand = new DelegateCommand(AddTextUiRow, (commandParameter) => m_editor != null);
            this.RemoveCommand = new DelegateCommand(Remove, (commandParameter) => m_editor != null &&
                                                             (m_dofusGrid.SelectedItems as IList).OfType<D2IRow>().Count() > 0);
            this.ResetCommand = new DelegateCommand(Reset, (commandParameter) => m_editor != null);
            this.SaveCommand = new DelegateCommand(Save, (commandParameter) => m_editor != null);
            this.ApplyCommand = new DelegateCommand(Apply, (commandParameter) => m_editor != null &&
                                                           (m_dofusGrid.SelectedItems as IList).OfType<D2IRow>().Count() == 1 &&
                                                            !string.IsNullOrEmpty(EditText) &&
                                                            EditText != "Texte modifié avec succès !");
            this.EditCommand = new DelegateCommand(Edit, (commandParameter) => m_editor != null &&
                                                         (m_dofusGrid.SelectedItems as IList).OfType<D2IRow>().Count() == 1);
        }


        public void Load(object commandParameter)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Dofus file (*.d2i)|*.d2i";

            if (ofd.ShowDialog() == true)
            {
                MainWindow.Instance.InLoading(() =>
                {
                    m_editor = new D2IManager(ofd.FileName);
                    m_editor.Load();

                    foreach (var entry in m_editor.DataAccess.UIEntries)
                        Rows.Add(new D2IUiTextRow(entry.Key, entry.Value.Text));

                    foreach (var entry in m_editor.DataAccess.Entries)
                        Rows.Add(new D2ITextRow(entry.Key, entry.Value.Text));

                    m_highestId = m_editor.DataAccess.Entries.Keys.Max();

                    AddTextUiCommand.InvokeCanExecuteChanged();
                    AddTextRowCommand.InvokeCanExecuteChanged();
                    LoadCommand.InvokeCanExecuteChanged();
                    ResetCommand.InvokeCanExecuteChanged();
                    SaveCommand.InvokeCanExecuteChanged();
                });
            }
            else
                MessageBox.Show("Erreur lors de l'ouverture du fichier d2i", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void Find(object commandParameter)
        {
            if (m_searched.Count > 0)
                m_searched.Clear();

            switch (SearchType)
            {
                case "Id":
                    if (int.TryParse(m_searchText, out int key))
                    {
                        foreach (var row in Rows)
                            if ((row as D2ITextRow)?.Id == key)
                                m_searched.Enqueue(row);
                    }
                    else
                        foreach (var row in Rows)
                            if ((row is D2IUiTextRow uiRow) && uiRow.Id.Contains(m_searchText))
                                m_searched.Enqueue(row);

                    break;
                case "Texte":
                    foreach (var row in Rows)
                        if (row.Text.Contains(m_searchText))
                            m_searched.Enqueue(row);
                    break;
            }

            int count = m_searched.Count();

            if (count == 0)
                MessageBox.Show("Aucun élément trouvé !", "World Editor", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                MessageBox.Show($"{count} élément(s) trouvé(s) !", "World Editor", MessageBoxButton.OK, MessageBoxImage.Information);

                var row = m_searched.Dequeue();

                FindNextCommand.InvokeCanExecuteChanged();
                m_dofusGrid.SelectedItem = row;
                m_dofusGrid.ScrollIntoView(row);
                m_dofusGrid.Focus();
            }
        }

        public void FindNext(object commandParameter)
        {
            var row = m_searched.Dequeue();

            FindNextCommand.InvokeCanExecuteChanged();
            m_dofusGrid.SelectedItem = row;
            m_dofusGrid.ScrollIntoView(row);
            m_dofusGrid.Focus();
        }

        public void AddTextRow(object commandParameter)
        {
            var row = new D2ITextRow(m_highestId++, string.Empty);

            Rows.Add(row);

            m_dofusGrid.SelectedItem = row;
            m_dofusGrid.ScrollIntoView(row);
            m_dofusGrid.Focus();
        }

        public void AddTextUiRow(object commandParameter)
        {
            var row = new D2IUiTextRow(string.Empty, string.Empty);

            Rows.Add(row);

            m_dofusGrid.SelectedItem = row;
            m_dofusGrid.ScrollIntoView(row);
            m_dofusGrid.Focus();
        }

        public void Remove(object commandParameter)
        {
            var rows = (commandParameter as IList).OfType<D2IRow>();

            for (int i = rows.Count() - 1; i >= 0; i--)
                if (!Rows.Remove(rows.ElementAt(i)))
                    MessageBox.Show("Erreur lors de la suppression de data !", "World Editor", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void Reset(object commandParameter)
        {
            MainWindow.Instance.InLoading(() =>
            {
                Rows.Clear();
                m_editor.Load();

                foreach (var entry in m_editor.DataAccess.UIEntries)
                    Rows.Add(new D2IUiTextRow(entry.Key, entry.Value.Text));

                foreach (var entry in m_editor.DataAccess.Entries)
                    Rows.Add(new D2ITextRow(entry.Key, entry.Value.Text));
            });

            MessageBox.Show("Réinitialisation terminée !", "World Editor", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void Save(object commandParameter)
        {
            MainWindow.Instance.InSaving(() =>
            {
                m_editor.Save();
                m_editor = null;


                AddTextUiCommand.InvokeCanExecuteChanged();
                AddTextRowCommand.InvokeCanExecuteChanged();
                LoadCommand.InvokeCanExecuteChanged();
                ResetCommand.InvokeCanExecuteChanged();
                SaveCommand.InvokeCanExecuteChanged();
            });

            MessageBox.Show("Sauvegarde terminée !", "World Editor", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void Apply(object commandParameter)
        {
            var row = commandParameter as D2IRow;

            row.Text = m_editText;

            if (row is D2IUiTextRow uiText)
            {
                m_editor.DataAccess.UIEntries[uiText.Id].Text = m_editText;
                if (m_editor.DataAccess.UIEntries[uiText.Id].UseUndiactricalText)
                    m_editor.DataAccess.UIEntries[uiText.Id].UnDiactricialText = m_editText.RemoveAccents().ToLower();
            }
            else
            {
                var entry = row as D2ITextRow;

                m_editor.DataAccess.Entries[entry.Id].Text = m_editText;
                if (m_editor.DataAccess.Entries[entry.Id].UseUndiactricalText)
                    m_editor.DataAccess.Entries[entry.Id].UnDiactricialText = m_editText.RemoveAccents().ToLower();
            }

            EditText = "Texte modifié avec succès !";
            ApplyCommand.InvokeCanExecuteChanged();
        }

        public void Edit(object commandParameter)
        {
            var row = commandParameter as D2IRow;
            EditText = row.Text;
            ApplyCommand.InvokeCanExecuteChanged();
        }

        public void OnPropertyChanged(string property)
        { this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property)); }
    }
}
