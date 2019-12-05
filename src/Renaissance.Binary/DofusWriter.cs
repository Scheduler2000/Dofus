using System;
using System.IO;
using System.Text;
using Be.IO;
using Renaissance.Binary.Definition;

#pragma warning disable CS0675 // Opérateur OU au niveau du bit utilisé sur un opérande de signe étendu

namespace Renaissance.Binary
{
    public class DofusWriter : BeBinaryWriter
    {
        public byte[] Data
        { get => (base.BaseStream as MemoryStream).ToArray(); }


        public DofusWriter() : base(new MemoryStream()) { }


        public byte SetFlag(byte flag, byte offset, WrappedBool wrappedBool)
        {
            bool value = wrappedBool.Value;
            bool flag2 = offset >= 8;
            if (flag2)
                throw new ArgumentException("offset must be lesser than 8");

            return value ? ((byte)(flag | (1 << offset))) : ((byte)(flag & (255 - (1 << offset))));
        }

        public new void Write(string str)
        {
            byte[] data = Encoding.UTF8.GetBytes(str);
            short len = (short)data.Length;

            base.Write(len);
            base.Write(data, 0, data.Length);
        }

        public void Write(CustomVar<short> val)
        {
            short value = val.Value;

            if (value >= sbyte.MinValue && value <= sbyte.MaxValue)
            {
                Write((sbyte)value);
                return;
            }

            var c = value & ushort.MaxValue;
            while (c != 0)
            {
                var b = c & sbyte.MaxValue;
                c = (int)((uint)c >> 7);

                if (c > 0)
                    b |= 128;

                Write((byte)b);
            }
        }

        public void Write(CustomVar<int> val)
        {
            int value = val.Value;

            if (value >= 0 && value <= sbyte.MaxValue)
            {
                Write((byte)value);
                return;
            }

            while (value != 0)
            {
                var b = value & sbyte.MaxValue;
                value = (int)((uint)value >> 7);

                if (value > 0)
                    b |= 128;

                Write((byte)b);
            }
        }


        public void Write(CustomVar<long> number)
        {

            void WriteVarInt32(uint value)
            {
                while (value >= 128)
                {
                    base.Write((byte)((value & 127) | 128));
                    value >>= 7;
                }
                base.Write((byte)value);
            }

            double value = number.Value;
            uint low = (uint)value;
            int high = (int)Math.Floor(value / 4294967296);

            if (high == 0)
                WriteVarInt32(low);
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    Write((byte)((low & 127) | 128));
                    low >>= 7;
                }
                if ((high & (268435455 << 3)) == 0)
                    Write((byte)((high << 4) | low));
                else
                {
                    Write((byte)((((high << 4) | low) & 127) | 128));
                    WriteVarInt32((uint)high >> 3);
                }
            }
        }
    }
}
