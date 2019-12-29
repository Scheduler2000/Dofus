using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

using Renaissance.Binary;
using Renaissance.Data.D2P.Mapping;

namespace Renaissance.Data.D2P
{
    public class D2PManager
    {
        private readonly Dictionary<byte[], List<DlmEntry>> m_entries;


        public D2PManager(string[] files)
        {
            this.m_entries = new Dictionary<byte[], List<DlmEntry>>();

            foreach (string file in files)
            {
                var data = File.ReadAllBytes(file);
                var reader = new D2PReader(data);

                m_entries.Add(data, reader.Read());
            }
        }

        public List<MapData> ExtractAllData()
        {
            var maps = new List<MapData>();
            byte[] key = Encoding.UTF8.GetBytes("649ae451ca33ec53bbcbcc33becf15f4");

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
                    var map = new MapData();
                    map.FromRaw(mapReader, key);

                    maps.Add(map);
                });
            }

            return maps;
        }
    }
}
