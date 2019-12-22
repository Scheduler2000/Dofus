using System;
using System.IO;
using System.Text;
using Be.IO;

namespace Renaissance.Data
{
    public class BigEndianWriter : BeBinaryWriter
    {
        public byte[] Data
        { get => (base.BaseStream as MemoryStream).ToArray(); }

        public int Position
        {
            get => (int)base.BaseStream.Position;
            set => base.BaseStream.Seek(value, SeekOrigin.Begin);
        }

        public BigEndianWriter() : base(new MemoryStream()) { }

        public new void Write(string str)
        {
            byte[] data = Encoding.UTF8.GetBytes(str);
            short len = (short)data.Length;

            base.Write(len);
            base.Write(data, 0, data.Length);
        }

        public void Write(Memory<byte> data)
        {
            base.Write(data.ToArray());
        }
    }
}
