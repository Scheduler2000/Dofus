using System;

using Astron.Size;
using Astron.Size.Storage;

namespace Renaissance.Binary.SizingStorage
{
    public class ByteSizeStorage : ISizeOfStorage<byte>
    {
        public Func<ISizing, byte, int> Calculate
            => (sizing, value) => 1;
    }

    public class SbyteSizeStorage : ISizeOfStorage<sbyte>
    {
        public Func<ISizing, sbyte, int> Calculate
            => (sizing, value) => 1;
    }

    public class Int16SizeStorage : ISizeOfStorage<short>
    {
        public Func<ISizing, short, int> Calculate
            => (sizing, value) => 2;
    }

    public class Uint16SizeStorage : ISizeOfStorage<ushort>
    {
        public Func<ISizing, ushort, int> Calculate
            => (sizing, value) => 2;
    }

    public class Int32SizeStorage : ISizeOfStorage<int>
    {
        public Func<ISizing, int, int> Calculate
            => (sizing, value) => 4;
    }

    public class Uint32SizeStorage : ISizeOfStorage<uint>
    {
        public Func<ISizing, uint, int> Calculate
            => (sizing, value) => 4;
    }

    public class Int64SizeStorage : ISizeOfStorage<long>
    {
        public Func<ISizing, long, int> Calculate
            => (sizing, value) => 8;
    }

    public class Uint64SizeStorage : ISizeOfStorage<ulong>
    {
        public Func<ISizing, ulong, int> Calculate
            => (sizing, value) => 8;
    }

    public class BooleanSizeStorage : ISizeOfStorage<bool>
    {
        public Func<ISizing, bool, int> Calculate
            => (sizing, value) => 1;
    }

    public class DoubleSizeStorage : ISizeOfStorage<double>
    {
        public Func<ISizing, double, int> Calculate
            => (sizing, value) => 8;
    }

    public class FloatSizeStorage : ISizeOfStorage<float>
    {
        public Func<ISizing, float, int> Calculate
            => (sizing, value) => 4;
    }

    public class DecimalSizeStorage : ISizeOfStorage<decimal>
    {
        public Func<ISizing, decimal, int> Calculate
            => (sizing, value) => 16;
    }
}
