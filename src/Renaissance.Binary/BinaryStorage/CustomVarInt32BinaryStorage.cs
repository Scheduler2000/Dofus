using Astron.Binary.Reader;
using Astron.Binary.Storage;
using Astron.Binary.Writer;
using Renaissance.Binary.Definition;
using System;

namespace Renaissance.Binary.BinaryStorage
{
    internal class CustomVarInt32BinaryStorage : IBinaryStorage<CustomVar<int>>
    {
        public Func<IReader, CustomVar<int>> ReadValue
            => (reader) =>
            {
                int result = 0;
                bool hasNext = true;
                for (var offset = 0; offset < 32 && hasNext; offset += 7)
                {
                    byte readByte = reader.ReadValue<byte>();
                    hasNext = (readByte & 128) == 128;

                    if (offset > 0)
                        result += (readByte & sbyte.MaxValue) << offset;
                    else
                        result += readByte & sbyte.MaxValue;
                }
                return new CustomVar<int>(result);
            };

        public Action<IWriter, CustomVar<int>> WriteValue
        { get => null; }

    }
}
