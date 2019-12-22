using System;
using System.Collections.Generic;
using System.IO;
using Renaissance.Binary;
using Renaissance.Data.D2P.Mapping.Util;

namespace Renaissance.Data.D2P.Mapping
{
    /// <summary>
    /// <see cref="Map"/> refers to com.ankamagames.atouin.data.map.Map
    /// </summary>
    public class Map
    {
        private int m_zoomScale = 1;

        public int MapVersion { get; private set; }

        public bool Encrypted { get; private set; }

        public uint EncryptionVersion { get; private set; }

        public int GroundCrc { get; private set; }

        public int ZoomOffsetX { get; private set; }

        public int ZoomOffsetY { get; private set; }

        public int Id { get; private set; }

        public int RelativeId { get; private set; }

        public int MapType { get; private set; }

        public int BackgroundsCount { get; private set; }

        public Fixture[] BackgroundsFixtures { get; private set; }

        public int ForegroundsCount { get; private set; }

        public Fixture[] ForegroundFixtures { get; private set; }

        public int SubAreaId { get; private set; }

        public int ShadowBonusOnEntities { get; private set; }

        public uint GridColor { get; private set; }

        public uint BackgroundColor { get; private set; }

        public int BackgroundRed { get; private set; }

        public int BackgroundGreen { get; private set; }

        public int BackgroundBlue { get; private set; }

        public int BackgroundAlpha { get; private set; }

        public int TopNeighbourId { get; private set; }

        public int BottomNeighbourId { get; private set; }

        public int LeftNeighbourId { get; private set; }

        public int RightNeighbourId { get; private set; }

        public bool UseLowPassFilter { get; private set; }

        public bool UseReverb { get; private set; }

        public int PresetId { get; private set; }

        public int CellsCount { get; private set; }

        public int LayersCount { get; private set; }

        public Layer[] Layers { get; private set; }

        public CellData[] Cells { get; private set; }

        public List<uint> TopArrowCell { get; private set; }

        public List<uint> LeftArrowCell { get; private set; }

        public List<uint> BottomArrowCell { get; private set; }

        public List<uint> RightArrowCell { get; private set; }

        public int TacticalModeTemplateId { get; private set; }


        public Map()
        {
            this.TopArrowCell = new List<uint>();
            this.LeftArrowCell = new List<uint>();
            this.BottomArrowCell = new List<uint>();
            this.RightArrowCell = new List<uint>();
        }

        public bool IsLineOfSight(int cellId)
        { return cellId >= 0 && cellId < this.CellsCount ? this.Cells[cellId].Los : false; }

        public bool IsWalkable(int cellId)
        {
            return cellId >= 0 && cellId < this.CellsCount && this.Cells[cellId].Mov
                               ? !this.Cells[cellId].NonWalkableDuringFight : false;
        }

        public void FromRaw(DofusReader reader, byte[] decryptionKey)
        {
            try
            {
                if (reader.Read<byte>() != 77)
                    throw new Exception("Invalid header for map !");

                this.MapVersion = (int)reader.Read<byte>();
                this.Id = reader.Read<int>();

                if (this.MapVersion >= 7)
                {
                    this.Encrypted = reader.Read<bool>();
                    this.EncryptionVersion = (uint)reader.Read<byte>();
                    int byteCount = reader.Read<int>();

                    if (this.Encrypted)
                    {
                        if (decryptionKey.Length < 1)
                            throw new Exception("Map decryption key is empty");

                        byte[] buffer = reader.ReadBytes(byteCount);

                        for (int index = 0; index < buffer.Length; ++index)
                            buffer[index] = (byte)(buffer[index] ^ (uint)decryptionKey[index % decryptionKey.Length]);

                        reader = new DofusReader(new MemoryStream(buffer).ToArray());
                    }
                }

                this.RelativeId = reader.Read<int>();
                this.MapType = (int)reader.Read<byte>();
                this.SubAreaId = reader.Read<int>();
                this.TopNeighbourId = reader.Read<int>();
                this.BottomNeighbourId = reader.Read<int>();
                this.LeftNeighbourId = reader.Read<int>();
                this.RightNeighbourId = reader.Read<int>();
                this.ShadowBonusOnEntities = reader.Read<int>();

                if (this.MapVersion >= 9)
                {
                    int num2 = reader.Read<int>();
                    this.BackgroundAlpha = (int)((num2 & 4278190080L) >> 32);
                    this.BackgroundRed = (num2 & 16711680) >> 16;
                    this.BackgroundGreen = (num2 & 65280) >> 8;
                    this.BackgroundBlue = num2 & byte.MaxValue;
                    int num3 = reader.Read<int>();
                    this.GridColor = (uint)((int)((num3 & 4278190080L) >> 32) & byte.MaxValue | ((num3 & 16711680) >> 16 & byte.MaxValue) << 16 | ((num3 & 65280) >> 8 & byte.MaxValue) << 8 | num3 & byte.MaxValue & byte.MaxValue);
                }
                else if (this.MapVersion >= 3)
                {
                    this.BackgroundRed = (int)reader.Read<byte>();
                    this.BackgroundGreen = (int)reader.Read<byte>();
                    this.BackgroundBlue = (int)reader.Read<byte>();
                }
                this.BackgroundColor = (uint)(this.BackgroundAlpha & byte.MaxValue | (this.BackgroundRed & byte.MaxValue) << 16 | (this.BackgroundGreen & byte.MaxValue) << 8 | this.BackgroundBlue & byte.MaxValue);

                if (this.MapVersion >= 4)
                {
                    this.m_zoomScale = (int)reader.Read<short>() / 100;
                    this.ZoomOffsetX = (int)reader.Read<short>();
                    this.ZoomOffsetY = (int)reader.Read<short>();
                    if (this.m_zoomScale < 1)
                    {
                        this.m_zoomScale = 1;
                        this.ZoomOffsetY = 0;
                        this.ZoomOffsetX = 0;
                    }
                }
                if (this.MapVersion > 10)
                    this.TacticalModeTemplateId = reader.Read<int>();

                this.UseLowPassFilter = reader.Read<byte>() == 1;
                this.UseReverb = reader.Read<byte>() == 1;
                this.PresetId = !this.UseReverb ? -1 : reader.Read<int>();
                this.BackgroundsCount = (int)reader.Read<byte>();
                this.BackgroundsFixtures = new Fixture[this.BackgroundsCount];

                for (int index = 0; index < this.BackgroundsCount; ++index)
                {
                    var fixture = new Fixture();
                    fixture.FromRaw(reader);
                    this.BackgroundsFixtures[index] = fixture;
                }
                this.ForegroundsCount = (int)reader.Read<byte>();
                this.ForegroundFixtures = new Fixture[this.ForegroundsCount];

                for (int index = 0; index < this.ForegroundsCount; ++index)
                {
                    var fixture = new Fixture();
                    fixture.FromRaw(reader);
                    this.ForegroundFixtures[index] = fixture;
                }
                this.CellsCount = AtouinConstants.MAP_CELLS_COUNT;
                reader.Skip(4);

                this.GroundCrc = reader.Read<int>();
                this.LayersCount = reader.Read<byte>();
                this.Layers = new Layer[this.LayersCount];

                for (int index = 0; index < this.LayersCount; ++index)
                {
                    var layer = new Layer();
                    layer.FromRaw(reader, this.MapVersion);
                    this.Layers[index] = layer;
                }
                this.Cells = new CellData[this.CellsCount];

                for (int index = 0; index < this.CellsCount; ++index)
                {
                    var cellData = new CellData(this, (uint)index);
                    cellData.FromRaw(reader);
                    this.Cells[index] = cellData;
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex); }
        }
    }

}
