using System;
using System.Collections.Generic;
using System.Linq;
using Renaissance.Binary;
using Renaissance.Data.Utils;

namespace Renaissance.Data.D2I
{
    public class D2IReader
    {
        private byte[] m_data;

        private List<int> m_sortedIndex = new List<int>();

        public D2IReader(byte[] data)
        { this.m_data = data; }


        public void Read(out Dictionary<int, D2IEntry> entries, out Dictionary<string, D2IEntry> uiEntries)
        {
            var reader = new DofusReader(m_data);
            entries = new Dictionary<int, D2IEntry>();
            uiEntries = new Dictionary<string, D2IEntry>();

            reader.Position = reader.Read<int>();
            int indexLen = reader.Read<int>();

            int pointer;
            for (int i = 0; i < indexLen; i += 9)
            {
                int key = reader.Read<int>();
                bool diacriticalText = reader.Read<bool>();
                pointer = reader.Read<int>();
                string text = reader.ReadFrom<string>(pointer, true);


                if (diacriticalText)
                {
                    i += 4;
                    int unDiacriticalPointer = reader.Read<int>();
                    string unDiacritialText = reader.ReadFrom<string>(unDiacriticalPointer, true);

                    entries.Add(key, new D2IEntry(text, unDiacritialText));
                }
                else
                    entries.Add(key, new D2IEntry(text));
            }

            int position;
            for (indexLen = reader.Read<int>(); indexLen > 0; indexLen -= reader.Position - position)
            {
                position = reader.Position;

                string textKey = reader.Read<string>();

                pointer = reader.Read<int>();
                string text = reader.ReadFrom<string>(pointer, true);
                uiEntries.Add(textKey, new D2IEntry(text));
            }

            for (indexLen = reader.Read<int>(); indexLen > 0; indexLen -= 4)
                m_sortedIndex.Add(reader.Read<int>());

        }

        public byte[] Save(Dictionary<int, D2IEntry> entries, Dictionary<string, D2IEntry> uiEntries)
        {
            /* Todo : size calculation + DofusWriter (see Renaissance.Binary) */

            using var contentWriter = new BigEndianWriter();
            using var indexWriter = new BigEndianWriter();
            using var indexUIWriter = new BigEndianWriter();
            using var indexSortedWriter = new BigEndianWriter();

            contentWriter.Position = 4;

            foreach (var entry in entries.Where(x => x.Value.Text != null))
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

            foreach (var uiEntry in uiEntries.Where(x => x.Value.Text != null))
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
