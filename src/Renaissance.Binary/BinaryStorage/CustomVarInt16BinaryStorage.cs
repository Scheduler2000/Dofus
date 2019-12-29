using System;

using Astron.Binary.Reader;
using Astron.Binary.Storage;
using Astron.Binary.Writer;

using Renaissance.Binary.Definition;

namespace Renaissance.Binary.BinaryStorage
{
    internal class CustomVarInt16BinaryStorage : IBinaryStorage<CustomVar<short>>
    {
        public Func<IReader, CustomVar<short>> ReadValue => reader =>
        {
            var result = 0;

            for (var offset = 0; offset < 16; offset += 7)
            {
                var readByte = reader.ReadValue<sbyte>();
                var hasNext = (readByte & 128) == 128;

                if (offset > 0)
                    result += (readByte & sbyte.MaxValue) << offset;
                else
                    result += (readByte & sbyte.MaxValue);

                if (result > short.MaxValue)
                    result -= 65536;

                if (hasNext) continue;
                return new CustomVar<short>((short)result);
            }

            throw new ArgumentOutOfRangeException($"{nameof(CustomVar<short>)} from reader is invalid.");
        };

        public Action<IWriter, CustomVar<short>> WriteValue => (writer, val) =>
        {

            short value = val.Value;

            if (value >= sbyte.MinValue && value <= sbyte.MaxValue)
            {
                writer.WriteValue((sbyte)value);
                return;
            }

            var c = value & ushort.MaxValue;
            while (c != 0)
            {
                var b = c & sbyte.MaxValue;
                c = (int)((uint)c >> 7);

                if (c > 0)
                    b |= 128;

                writer.WriteValue((byte)b);
            }
        };

    }
}
