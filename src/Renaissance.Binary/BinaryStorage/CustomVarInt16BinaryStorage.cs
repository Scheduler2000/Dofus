using Astron.Binary.Reader;
using Astron.Binary.Storage;
using Astron.Binary.Writer;
using Renaissance.Binary.Definition;
using System;

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

        public Action<IWriter, CustomVar<short>> WriteValue
        { get => null; }
    }
}
