using Astron.Size;
using Astron.Size.Storage;
using Renaissance.Binary.Definition;
using System;

namespace Renaissance.Binary.SizingStorage
{
    internal class CustomVarInt16SizeStorage : ISizeOfStorage<CustomVar<short>>
    {
        private readonly (double posLvl, double negLvl)[] m_levels =
        {
           (Math.Pow(2,7), Math.Pow(2,7) * -1),
           (Math.Pow(2,14), Math.Pow(2,14) * -1)
        };

        public Func<ISizing, CustomVar<short>, int> Calculate
            => (sizing, custom) =>
            {
                int size = 1;
                foreach (var (pos, neg) in m_levels)
                    if (custom.Value >= pos || custom.Value < neg) size++;
                return size;
            };
    }
}
