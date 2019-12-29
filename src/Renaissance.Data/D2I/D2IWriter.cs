using System;
using System.Collections.Generic;
using System.Linq;

using Renaissance.Data.Utils;

namespace Renaissance.Data.D2I
{
    public class D2IWriter
    {
        private Dictionary<int, D2IEntry> m_entries;
        private Dictionary<string, D2IEntry> m_uiEntries;
        private List<int> m_sortedIndex;

        public D2IWriter(Dictionary<int, D2IEntry> entries, Dictionary<string, D2IEntry> uiEntries, List<int> sortedIndex)
        {
            this.m_entries = entries;
            this.m_uiEntries = uiEntries;
            this.m_sortedIndex = sortedIndex;
        }


        public byte[] Write()
        {
            /* Improvement : size calculation + DofusWriter (see Renaissance.Binary) */

            using var contentWriter = new BigEndianWriter();
            using var indexWriter = new BigEndianWriter();
            using var indexUIWriter = new BigEndianWriter();
            using var indexSortedWriter = new BigEndianWriter();

            contentWriter.Position = 4;

            foreach (var entry in m_entries.Where(x => x.Value.Text != null))
            {
                indexWriter.Write(entry.Key);
                indexWriter.Write(entry.Value.UseUndiactricalText);
                indexWriter.Write(contentWriter.Position);

                contentWriter.Write(entry.Value.Text);

                if (entry.Value.UseUndiactricalText)
                {
                    indexWriter.Write(contentWriter.Position);
                    contentWriter.Write(entry.Value.UnDiactricialText);
                }
            }

            int indexLen = indexWriter.Data.Length;

            foreach (var uiEntry in m_uiEntries.Where(x => x.Value.Text != null))
            {
                indexUIWriter.Write(uiEntry.Key);
                indexUIWriter.Write(contentWriter.Position);
                contentWriter.Write(uiEntry.Value.Text);
            }

            foreach (var sorted in m_sortedIndex)
                indexSortedWriter.Write(sorted);

            int indexUIPos = contentWriter.Position;
            Memory<byte> uiData = indexWriter.Data;

            contentWriter.Write(indexLen);
            contentWriter.Write(uiData);
            contentWriter.Write(indexUIWriter.Data.Length);
            contentWriter.Write(indexUIWriter.Data);
            contentWriter.Write(indexSortedWriter.Data.Length);
            contentWriter.Write(indexSortedWriter.Data);

            contentWriter.Position = 0;
            contentWriter.Write(indexUIPos);

            return contentWriter.Data;
        }
    }
}
