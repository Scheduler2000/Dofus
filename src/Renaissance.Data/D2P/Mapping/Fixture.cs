using System;

using Renaissance.Binary;
using Renaissance.Protocol.datacenter.geometry;

namespace Renaissance.Data.D2P.Mapping
{
    /// <summary>
    /// <see cref="Fixture"/> refers to com.ankamagames.atouin.data.map.Fixture
    /// </summary>
    public class Fixture
    {
        public int FixtureId { get; private set; }

        public Point Offset { get; private set; }

        public int Hue { get; private set; }

        public int RedMultiplier { get; private set; }

        public int GreenMultiplier { get; private set; }

        public int BlueMultiplier { get; private set; }

        public uint Alpha { get; private set; }

        public int XScale { get; private set; }

        public int YScale { get; private set; }

        public int Rotation { get; private set; }

        public Fixture()
        { this.Offset = new Point(); }

        public void FromRaw(DofusReader reader)
        {
            try
            {
                this.FixtureId = reader.Read<int>();

                this.Offset.X = reader.Read<short>();
                this.Offset.Y = reader.Read<short>();

                this.Rotation = reader.Read<short>();
                this.XScale = reader.Read<short>();
                this.YScale = reader.Read<short>();

                this.RedMultiplier = reader.Read<byte>();
                this.GreenMultiplier = reader.Read<byte>();
                this.BlueMultiplier = reader.Read<byte>();
                this.Alpha = reader.Read<byte>();

                this.Hue = RedMultiplier | GreenMultiplier | BlueMultiplier;

            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
        }

    }
}
