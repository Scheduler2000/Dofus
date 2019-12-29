using System;

using Renaissance.Binary;

namespace Renaissance.Data.D2P.Mapping
{
    /// <summary>
    /// <see cref="CellData"/> refers to com.ankamagames.atouin.data.map.CellData
    /// </summary>
    public class CellData
    {
        private readonly MapData m_map;

        private int m_arrow;

        private byte m_linkedZone;

        public uint Id { get; private set; }

        public int Speed { get; private set; }

        public bool Los { get; private set; }

        public bool Mov { get; private set; }

        public int LosMov { get; private set; }


        public bool NonWalkableDuringFight { get; private set; }

        public uint MapChangeData { get; private set; }

        public uint MoveZone { get; private set; }

        public int Floor { get; private set; }

        public bool Red { get; private set; }

        public bool Blue { get; private set; }

        public bool FarmCell { get; private set; }

        public bool HavenbagCell { get; private set; }

        public bool Visible { get; private set; }

        public bool NonWalkableDuringRp { get; private set; }

        public bool UseTopArrow => (this.m_arrow & 1) > 0U;

        public bool UseBottomArrow => (this.m_arrow & 2) > 0U;

        public bool UseRightArrow => (this.m_arrow & 4) > 0U;

        public bool UseLeftArrow => (this.m_arrow & 8) > 0U;

        public bool HasLinkedZoneRP => this.Mov ? !this.FarmCell : false;

        public int LinkedZoneRP => (this.m_linkedZone & 240) >> 4;

        public bool HasLinkedZoneFight => this.Mov && !this.NonWalkableDuringFight && !this.FarmCell ? !this.HavenbagCell : false;

        public int LinkedZoneFight => this.m_linkedZone & 15;

        public bool IsObstacle => !this.Mov ? !this.Los : false;

        public bool Walkable => this.Mov;


        public CellData(MapData param1, uint param2)
        {
            this.Id = param2;
            this.m_map = param1;
        }


        public bool IsWalkable(bool isFightMode)
        { return (this.LosMov & (isFightMode ? 5 : 1)) == 1; }

        public void FromRaw(DofusReader reader)
        {
            try
            {
                if ((this.Floor = reader.Read<byte>() * 10) == -1280)
                    return;

                if (this.m_map.MapVersion >= 9)
                {
                    int num = (int)reader.Read<short>();
                    this.Mov = (num & 1) == 0;
                    this.NonWalkableDuringFight = (uint)(num & 2) > 0U;
                    this.NonWalkableDuringRp = (uint)(num & 4) > 0U;
                    this.Los = (num & 8) == 0;
                    this.Blue = (uint)(num & 16) > 0U;
                    this.Red = (uint)(num & 32) > 0U;
                    this.Visible = (uint)(num & 64) > 0U;
                    this.FarmCell = (uint)(num & 128) > 0U;

                    bool flag1;
                    bool flag2;
                    bool flag3;
                    bool flag4;

                    if (this.m_map.MapVersion >= 10)
                    {
                        this.HavenbagCell = (uint)(num & 256) > 0U;
                        flag1 = (uint)(num & 512) > 0U;
                        flag2 = (uint)(num & 1024) > 0U;
                        flag3 = (uint)(num & 2048) > 0U;
                        flag4 = (uint)(num & 4096) > 0U;
                    }
                    else
                    {
                        flag1 = (uint)(num & 256) > 0U;
                        flag2 = (uint)(num & 512) > 0U;
                        flag3 = (uint)(num & 1024) > 0U;
                        flag4 = (uint)(num & 2048) > 0U;
                    }
                    if (flag1)
                        this.m_map.TopArrowCell.Add(this.Id);
                    if (flag2)
                        this.m_map.BottomArrowCell.Add(this.Id);
                    if (flag3)
                        this.m_map.RightArrowCell.Add(this.Id);
                    if (flag4)
                        this.m_map.LeftArrowCell.Add(this.Id);
                }
                else
                {
                    this.LosMov = reader.Read<byte>();
                    this.Los = (this.LosMov & 2) >> 1 == 1;
                    this.Mov = (this.LosMov & 1) == 1;
                    this.Visible = (this.LosMov & 64) >> 6 == 1;
                    this.FarmCell = (this.LosMov & 32) >> 5 == 1;
                    this.Blue = (this.LosMov & 16) >> 4 == 1;
                    this.Red = (this.LosMov & 8) >> 3 == 1;
                    this.NonWalkableDuringRp = (this.LosMov & 128) >> 7 == 1;
                    this.NonWalkableDuringFight = (this.LosMov & 4) >> 2 == 1;
                }
                this.Speed = (int)reader.Read<byte>();
                this.MapChangeData = reader.Read<byte>();

                if (this.m_map.MapVersion > 5)
                    this.MoveZone = reader.Read<byte>();

                if (this.m_map.MapVersion > 10 && (this.HasLinkedZoneRP || this.HasLinkedZoneFight))
                    this.m_linkedZone = reader.Read<byte>();

                if (this.m_map.MapVersion <= 7 || this.m_map.MapVersion >= 9)
                    return;

                this.m_arrow = 15 & (int)reader.Read<byte>();

                if (this.UseTopArrow)
                    this.m_map.TopArrowCell.Add(this.Id);

                if (this.UseBottomArrow)
                    this.m_map.BottomArrowCell.Add(this.Id);

                if (this.UseLeftArrow)
                    this.m_map.LeftArrowCell.Add(this.Id);

                if (!this.UseRightArrow)
                    return;
                this.m_map.RightArrowCell.Add(this.Id);
            }
            catch (Exception ex)
            { Console.WriteLine((object)ex); }
        }
    }
}
