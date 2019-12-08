using System;
using Astron.Binary.Reader;

namespace Renaissance.Binary
{
    public class DofusReader
    {

        private readonly IReader m_reader;

        public DofusReader(Memory<byte> payload)
            => this.m_reader = DofusBinaryFactory.BinaryFactory.Get(payload);

        public bool ReadFlag(byte flag, byte offset)
        {
            bool flag2 = offset >= 8;
            if (flag2)
                throw new ArgumentException("offset must be lesser than 8");

            return (flag & (byte)(1 << offset)) > 0;
        }

        public TData Read<TData>()
        { return m_reader.ReadValue<TData>(); }

        public void Skip(int count) { m_reader.Advance(count); }
    }
}
