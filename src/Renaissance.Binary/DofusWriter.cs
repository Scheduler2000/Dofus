using System;
using Astron.Binary.Writer;
using Renaissance.Binary.Definition;

namespace Renaissance.Binary
{
    public class DofusWriter : IDisposable
    {
        private readonly IWriter m_writer;

        public int Position
        {
            get => m_writer.Position;
            set => m_writer.Seek(value);
        }


        public Memory<byte> Data
        { get => m_writer.GetBuffer(); }


        public DofusWriter(int size)
        { m_writer = DofusBinaryFactory.BinaryFactory.Get(size); }


        public byte SetFlag(byte flag, byte offset, WrappedBool wrappedBool)
        {
            bool value = wrappedBool.Value;
            bool flag2 = offset >= 8;
            if (flag2)
                throw new ArgumentException("offset must be lesser than 8");

            return value ? ((byte)(flag | (1 << offset))) : ((byte)(flag & (255 - (1 << offset))));
        }

        public void WriteData<TData>(TData value)
        { m_writer.WriteValue(value); }

        public void WriteDatas<TData>(TData[] values)
        { m_writer.WriteValues(values); }

        public void WriteDatas(Memory<byte> datas)
        { m_writer.WriteBytes(datas); }

        public void Dispose()
        { m_writer.Dispose(); }
    }
}
