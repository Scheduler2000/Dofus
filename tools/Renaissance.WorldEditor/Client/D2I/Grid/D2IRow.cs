using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Renaissance.WorldEditor.Client.D2I.Grid
{
    public abstract class D2IRow : INotifyPropertyChanged
    {
        private string m_text;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Text
        {
            get { return m_text; }

            set
            {
                if (string.Equals(m_text, value, StringComparison.Ordinal))
                    return;

                m_text = value;
                OnPropertyChanged("Text");
            }
        }

        protected D2IRow(string text)
        { this.m_text = text; }


        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
    public abstract class D2IRow<TKey> : D2IRow where TKey : IComparable
    {
        private TKey m_id;


        public TKey Id
        {
            get { return m_id; }

            set
            {
                if (Comparer<TKey>.Default.Compare(m_id, value) == 0)
                    return;

                m_id = value;
                OnPropertyChanged("Id");
            }
        }

        protected D2IRow(TKey id, string text) : base(text)
        { this.m_id = id; }

    }
}
