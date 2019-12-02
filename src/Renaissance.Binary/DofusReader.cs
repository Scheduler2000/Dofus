using System;
using Astron.Binary;
using Astron.Binary.Reader;
using Astron.Size;
using Renaissance.Binary.BinaryStorage;
using Renaissance.Binary.SizingStorage;

namespace Renaissance.Binary
{
    public class DofusReader
    {

        private readonly IReader m_reader;
        private static readonly IBinaryFactory m_factory;

        static DofusReader()
            => m_factory = new BinaryBuilder(new SizingBuilder()
                                        .Register(new CustomVarInt16SizeStorage())
                                        .Register(new CustomVarInt32SizeStorage())
                                        .Register(new CustomVarInt64SizeStorage())
                                        .Register(new StringSizeStorage())
                                        .Build(), default, Endianness.BigEndian)
                                            .Register(new CustomVarInt16BinaryStorage())
                                            .Register(new CustomVarInt32BinaryStorage())
                                            .Register(new CustomVarInt64BinaryStorage())
                                            .Register(new StringBinaryStorage())
                                            .Build();

        public DofusReader(Memory<byte> payload)
            => this.m_reader = m_factory.Get(payload);

        public bool ReadFlag(byte flag, byte offset)
        {
            bool flag2 = offset >= 8;
            if (flag2)
                throw new ArgumentException("offset must be lesser than 8");

            return (flag & (byte)(1 << offset)) > 0;
        }

        public T Read<T>()
        {
            return m_reader.ReadValue<T>();
        }

        public void Skip(int count) { m_reader.Advance(count); }
    }
}
