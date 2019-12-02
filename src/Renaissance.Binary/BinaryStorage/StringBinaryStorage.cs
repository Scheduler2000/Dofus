using Astron.Binary.Reader;
using Astron.Binary.Storage;
using Astron.Binary.Writer;
using System;
using System.Text;

namespace Renaissance.Binary.BinaryStorage
{

    internal class StringBinaryStorage : IBinaryStorage<string>
    {
        public Func<IReader, string> ReadValue => (reader) =>
        {
            var len = reader.ReadValue<short>();
            return Encoding.UTF8.GetString(reader.ReadValues<byte>(len));
        };

        public Action<IWriter, string> WriteValue
        { get => null; }

    }
}
