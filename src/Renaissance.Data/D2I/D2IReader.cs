using System.Collections.Generic;

using Renaissance.Binary;

namespace Renaissance.Data.D2I
{
    public class D2IReader
    {
        private byte[] m_data;

        public D2IReader(byte[] data)
        { this.m_data = data; }


        public void Read(out Dictionary<int, D2IEntry> entries, out Dictionary<string, D2IEntry> uiEntries, out List<int> sortedIndex)
        {
            var reader = new DofusReader(m_data);
            entries = new Dictionary<int, D2IEntry>();
            uiEntries = new Dictionary<string, D2IEntry>();
            sortedIndex = new List<int>();

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
                sortedIndex.Add(reader.Read<int>());

        }

    }
}
