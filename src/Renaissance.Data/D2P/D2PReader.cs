using System.Collections.Generic;
using System.IO;
using Renaissance.Binary;

namespace Renaissance.Data.D2P
{
    public class D2PReader
    {
        private DofusReader m_reader;
        public byte[] m_data;

        public D2PReader(byte[] data)
        {
            this.m_data = data;
            this.m_reader = new DofusReader(data);
        }

        public List<DlmEntry> Read()
        {
            var entries = new List<DlmEntry>();

            byte vMax = m_reader.Read<byte>();
            byte vMin = m_reader.Read<byte>();

            if (vMax != 2 || vMin != 1)
                throw new InvalidDataException("Invalid header for currently D2P Reader !");

            m_reader.Position = m_reader.Count - 24;

            int dataOffset = m_reader.Read<int>();

            m_reader.Skip(4); /* skip dataCount */

            int indexOffset = m_reader.Read<int>();
            int indexCount = m_reader.Read<int>();

            m_reader.Position = indexOffset;

            for (int i = 0; i < indexCount; i++)
            {
                var dlmName = m_reader.Read<string>();
                var fileOffset = m_reader.Read<int>();
                var fileLength = m_reader.Read<int>();

                entries.Add(new DlmEntry(dlmName, fileOffset + dataOffset, fileLength));
            }

            return entries;
        }

    }
}
