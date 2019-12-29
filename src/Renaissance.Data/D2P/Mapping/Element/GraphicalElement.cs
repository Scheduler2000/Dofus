using System;

using Renaissance.Binary;
using Renaissance.Data.D2P.Mapping.Util;
using Renaissance.Protocol.datacenter.geometry;

namespace Renaissance.Data.D2P.Mapping.Element
{
    /// <summary>
    /// <see cref="GraphicalElement"/> refers to com.ankamagames.atouin.data.map.elements.GraphicalElement
    /// </summary>
    public class GraphicalElement : BasicElement
    {
        private ColorMultiplicator m_colorMultiplicator;

        public int ElementId { get; private set; }

        public Color Hue { get; private set; }

        public Color Shadow { get; private set; }

        public Color FinalTeint { get; private set; }

        public Point Offset { get; private set; }

        public Point PixelOffset { get; private set; }

        public int Altitude { get; private set; }

        public uint Identifier { get; private set; }


        public GraphicalElement(CellElement cell)
            : base(cell, ElementTypesEnum.Graphical)
        {
            this.Offset = new Point();
            this.PixelOffset = new Point();
            this.m_colorMultiplicator = new ColorMultiplicator();
        }

        public override void FromRaw(DofusReader reader, int mapVersion)
        {
            try
            {
                this.ElementId = reader.Read<int>();
                this.Hue = new Color(reader.Read<byte>(), reader.Read<byte>(), reader.Read<byte>());
                this.Shadow = new Color(reader.Read<byte>(), reader.Read<byte>(), reader.Read<byte>());

                if (mapVersion <= 4)
                {
                    this.Offset.X = reader.Read<byte>();
                    this.Offset.Y = reader.Read<byte>();

                    this.PixelOffset.X = Offset.X * AtouinConstants.CELL_HALF_WIDTH;
                    this.PixelOffset.Y = (int)(Offset.Y * AtouinConstants.CELL_HALF_HEIGHT);
                }
                else
                {
                    this.Offset.X = reader.Read<short>();
                    this.Offset.Y = reader.Read<short>();

                    this.PixelOffset.X = Offset.X / AtouinConstants.CELL_HALF_WIDTH;
                    this.PixelOffset.Y = (int)(Offset.Y / AtouinConstants.CELL_HALF_HEIGHT);
                }

                this.Altitude = reader.Read<byte>();
                this.Identifier = reader.Read<uint>();

                CalculateFinalTeint();
            }
            catch (Exception e)
            { Console.WriteLine(e.ToString()); }
        }

        private void CalculateFinalTeint()
        {
            var r = Hue.Red + Shadow.Red;
            var g = Hue.Green + Shadow.Green;
            var b = Hue.Blue + Shadow.Blue;

            r = m_colorMultiplicator.Clamp((r + 128) * 2, 0, 512);
            g = m_colorMultiplicator.Clamp((g + 128) * 2, 0, 512);
            b = m_colorMultiplicator.Clamp((b + 128) * 2, 0, 512);

            this.FinalTeint = new Color(r, g, b);
        }
    }
}
