using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using Renaissance.Binary;
using Renaissance.Data.D2P;
using Renaissance.Data.D2P.Mapping;

namespace Renaissance.WorldEditor.Client.D2P
{
    public class D2PManager
    {
        private readonly Dictionary<byte[], List<DlmEntry>> m_entries;


        public D2PManager(string directory)
        {
            this.m_entries = new Dictionary<byte[], List<DlmEntry>>();

            foreach (string file in Directory.GetFiles(directory))

            {
                if (new FileInfo(file).Extension.ToUpper() == ".D2P")
                {
                    var data = File.ReadAllBytes(file);
                    var reader = new D2PReader(data);

                    m_entries.Add(data, reader.Read());
                }
            }
        }

        public void ExtractAllData()
        {
            foreach (var keyVal in m_entries)
            {
                var reader = new DofusReader(keyVal.Key);

                keyVal.Value.ForEach(entry =>
                {
                    var mapData = reader.ReadFrom(entry.StartPosition, entry.BytesCount, false);

                    using var decompressedData = new MemoryStream();
                    using var deflatedStream = new DeflateStream(new MemoryStream(mapData) { Position = 2L }, CompressionMode.Decompress);

                    deflatedStream.CopyTo(decompressedData);

                    var mapReader = new DofusReader(decompressedData.GetBuffer());
                    var map = new Map();
                    map.FromRaw(mapReader, Encoding.UTF8.GetBytes("649ae451ca33ec53bbcbcc33becf15f4"));
                });
            }
        }
    }
}
