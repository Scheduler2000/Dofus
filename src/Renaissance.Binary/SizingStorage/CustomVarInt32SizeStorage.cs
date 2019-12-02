using Astron.Size;
using Astron.Size.Storage;
using Renaissance.Binary.Definition;
using System;

namespace Renaissance.Binary.SizingStorage
{
    internal class CustomVarInt32SizeStorage : ISizeOfStorage<CustomVar<int>>
    {
        private readonly (double posLvl, double negLvl)[] m_levels =
       {
           (Math.Pow(2,7), Math.Pow(2,7) * -1),
           (Math.Pow(2,14), Math.Pow(2,14) * -1),
           (Math.Pow(2,21), Math.Pow(2,21) * -1),
           (Math.Pow(2,29), Math.Pow(2,29) * -1)
        };

        public Func<ISizing, CustomVar<int>, int> Calculate
             => (sizing, custom) =>
             {
                 int size = 1;
                 foreach (var (pos, neg) in m_levels)
                     if (custom.Value >= pos || custom.Value < neg) size++;
                 return size;
             };
    }
}
