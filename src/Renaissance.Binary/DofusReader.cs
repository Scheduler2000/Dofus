using System;
using System.Text;

using Astron.Binary.Reader;

namespace Renaissance.Binary
{
    public class DofusReader
    {

        private readonly IReader m_reader;

        public int Position
        {
            get => m_reader.Position;
            set => m_reader.Seek(value);
        }

        public int Count { get => m_reader.Count; }

        public DofusReader(Memory<byte> payload)
            => this.m_reader = DofusBinaryFactory.BinaryFactory.Get(payload);

        public bool ReadFlag(byte flag, byte offset)
        {
            bool flag2 = offset >= 8;
            if (flag2)
                throw new ArgumentException("offset must be lesser than 8");

            return (flag & (byte)(1 << offset)) > 0;
        }

        public TData ReadFrom<TData>(int position, bool reset)
        {
            int pos = m_reader.Position;

            m_reader.Seek(position);
            TData data = m_reader.ReadValue<TData>();

            if (reset)
                m_reader.Seek(pos);

            return data;
        }

        public byte[] ReadFrom(int position, int bytesCount, bool reset)
        {
            int pos = m_reader.Position;

            m_reader.Seek(position);
            byte[] data = ReadBytes(bytesCount);

            if (reset)
                m_reader.Seek(pos);

            return data;
        }

        public TData Read<TData>()
        { return m_reader.ReadValue<TData>(); }

        public byte[] ReadBytes(int count)
        { return m_reader.ReadValues<byte>(count); }

        public string ReadUTBytes(ushort len)
        { return Encoding.UTF8.GetString(ReadBytes(len)); }

        public void Skip(int count) { m_reader.Advance(count); }
    }
}
