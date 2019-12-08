using Astron.Binary;
using Astron.Size;
using Renaissance.Binary.BinaryStorage;
using Renaissance.Binary.SizingStorage;

namespace Renaissance.Binary
{
    public static class DofusBinaryFactory
    {
        internal static IBinaryFactory BinaryFactory { get; }

        public static ISizing Sizing { get; }

        static DofusBinaryFactory()
        {
            Sizing = new SizingBuilder().Register(new CustomVarInt16SizeStorage())
                                        .Register(new CustomVarInt32SizeStorage())
                                        .Register(new CustomVarInt64SizeStorage())
                                        .Register(new StringSizeStorage())
                                        .Register(new ByteSizeStorage())
                                        .Register(new SbyteSizeStorage())
                                        .Register(new Int16SizeStorage())
                                        .Register(new Uint16SizeStorage())
                                        .Register(new Int32SizeStorage())
                                        .Register(new Uint32SizeStorage())
                                        .Register(new Int64SizeStorage())
                                        .Register(new Uint64SizeStorage())
                                        .Register(new BooleanSizeStorage())
                                        .Register(new DoubleSizeStorage())
                                        .Register(new FloatSizeStorage())
                                        .Register(new DecimalSizeStorage())
                                        .Build();

            BinaryFactory = new BinaryBuilder(Sizing, default, Endianness.BigEndian)
                                              .Register(new CustomVarInt16BinaryStorage())
                                              .Register(new CustomVarInt32BinaryStorage())
                                              .Register(new CustomVarInt64BinaryStorage())
                                              .Register(new StringBinaryStorage())
                                              .Build();
        }
    }
}
