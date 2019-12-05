using System;
using Astron.Binary.Reader;
using Astron.Binary.Storage;
using Astron.Binary.Writer;
using Renaissance.Binary.Definition;

#pragma warning disable CS0675 // Opérateur OU au niveau du bit utilisé sur un opérande de signe étendu

namespace Renaissance.Binary.BinaryStorage
{
    internal class CustomVarInt64BinaryStorage : IBinaryStorage<CustomVar<long>>
    {
        public Func<IReader, CustomVar<long>> ReadValue
            => (reader) =>
            {
                uint low = 0;
                int high = 0;
                int i = 0;
                int b;

                while (true)
                {
                    b = reader.ReadValue<byte>();
                    if (i == 28) break;
                    if (b < 128)
                    {
                        low |= (uint)(b << i);
                        return new CustomVar<long>((high * 4294967296) + low);
                    }
                    low |= (uint)((b & 127) << i);
                    i += 7;
                }
                if (b >= 128)
                {
                    b &= 127;
                    low |= (uint)(b << i);
                    high = b >> 4;
                    i = 3;
                    while (true)
                    {
                        b = reader.ReadValue<byte>();
                        if (i < 32)
                        {
                            if (b >= 128)
                                high |= (b & 127) << i;
                            else break;
                        }

                        i += 7;
                    }
                    high |= b << i;
                    return new CustomVar<long>((high * 4294967296) + low);
                }
                low |= (uint)(b << i);
                high = b >> 4;
                return new CustomVar<long>((high * 4294967296) + low);
            };

        public Action<IWriter, CustomVar<long>> WriteValue
        { get => null; }

    }
}
