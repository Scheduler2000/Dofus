using System;

using Renaissance.Protocol.enums.custom;

namespace Renaissance.World.Database.Maps.Cells
{
    [Serializable]
    public class Cell
    {
        public int Id { get; set; }

        public bool LineOfSight { get; set; }

        public int LosMov { get; set; }

        public CellColorEnum Color { get; set; }

        public bool NonWalkableDuringFight { get; set; }

        public bool FarmCell { get; set; }

        public bool HavenbagCell { get; set; }

        public bool Visible { get; set; }

        public bool NonWalkableDuringRp { get; set; }

        public bool HasLinkedZoneRP { get; set; }

        public int LinkedZoneRP { get; set; }

        public bool HasLinkedZoneFight { get; set; }

        public int LinkedZoneFight { get; set; }

        public bool IsObstacle { get; set; }

        public bool Walkable { get; set; }

    }
}
