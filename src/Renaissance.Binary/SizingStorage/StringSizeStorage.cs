using System;
using System.Text;
using Astron.Size;
using Astron.Size.Storage;

namespace Renaissance.Binary.SizingStorage
{
    internal class StringSizeStorage : ISizeOfStorage<string>
    {
        public Func<ISizing, string, int> Calculate
            => (Sizing, str) => 2 + Encoding.ASCII.GetBytes(str).Length;
    }
}
