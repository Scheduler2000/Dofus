﻿using System.Collections.Generic;
using System.Linq;

using Renaissance.Data.Utils;

namespace Renaissance.Data.D2I
{
    public class D2IDataAccess
    {
        public Dictionary<int, D2IEntry> Entries { get; private set; }

        public Dictionary<string, D2IEntry> UIEntries { get; private set; }

        public List<int> SortedIndex { get; set; }

        public D2IDataAccess(Dictionary<int, D2IEntry> entries, Dictionary<string, D2IEntry> uIEntries, List<int> sortedIndex)
        {
            this.Entries = entries;
            this.UIEntries = uIEntries;
            this.SortedIndex = sortedIndex;
        }

        public string GetText(int key)
        { return Entries.TryGetValue(key, out var entry) ? entry.Text : null; }


        public string GetUIText(string textKey)
        { return UIEntries.TryGetValue(textKey, out var entry) ? entry.Text : null; }


        public void SetText(int id, string value)
        {
            if (!Entries.TryGetValue(id, out D2IEntry entry))
                Entries.Add(id, new D2IEntry(value));
            else entry.Text = value;

            if (value.HasAccents() || value.Any(char.IsUpper))
            {
                entry.UnDiactricialText = value.RemoveAccents().ToLower();
                entry.UseUndiactricalText = true;
            }
            else
                entry.UseUndiactricalText = false;
        }

        public void SetUIText(string id, string value)
        {
            if (!UIEntries.TryGetValue(id, out D2IEntry entry))
                UIEntries.Add(id, new D2IEntry(value));
            else
                entry.Text = value;
        }

        public void DeleteText(int id)
        { Entries.Remove(id); }

        public void DeleteUIText(string id)
        { UIEntries.Remove(id); }

    }
}
