using System.Collections.Generic;
using System.Linq;

using Renaissance.Data.D2P.Mapping;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.enums.custom;
using Renaissance.World.Database.Maps;
using Renaissance.World.Database.Maps.Cells;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class MapSynchroniser : AbstractSynchroniser<Map, MapData>
    {
        public MapSynchroniser(IEnumerable<MapData> datas, IRepository<Map> database)
            : base(datas, database) { }

        protected override Map BuildEntity(MapData data)
        {
            var cells = new List<Cell>();

            foreach (var cell in data.Cells)
            {
                cells.Add(new Cell()
                {
                    Id = (int)cell.Id,
                    LineOfSight = cell.Los,
                    LosMov = cell.LosMov,
                    Color = cell.Red ? CellColorEnum.Red : cell.Blue ? CellColorEnum.Blue : CellColorEnum.None,
                    NonWalkableDuringFight = cell.NonWalkableDuringFight,
                    FarmCell = cell.FarmCell,
                    HavenbagCell = cell.HavenbagCell,
                    Visible = cell.Visible,
                    NonWalkableDuringRp = cell.NonWalkableDuringRp,
                    HasLinkedZoneRP = cell.HasLinkedZoneRP,
                    LinkedZoneRP = cell.LinkedZoneRP,
                    HasLinkedZoneFight = cell.HasLinkedZoneFight,
                    LinkedZoneFight = cell.LinkedZoneFight,
                    IsObstacle = cell.IsObstacle,
                    Walkable = cell.Walkable
                });
            }

            var map = new Map()
            {
                Id = data.Id,
                SubAreadId = data.SubAreaId,
                TopNeighbourId = data.TopNeighbourId,
                BottomNeighbourId = data.BottomNeighbourId,
                LeftNeighbourId = data.LeftNeighbourId,
                RightNeighbourId = data.RightNeighbourId,
                FightCellsCount = cells.Where(x => x.Color != CellColorEnum.None).Count(),
                RedCells = cells.Where(x => x.Color == CellColorEnum.Red).Select(x => x.Id).ToList(),
                BlueCells = cells.Where(x => x.Color == CellColorEnum.Blue).Select(x => x.Id).ToList(),
                OtherCells = cells.Where(x => x.Color == CellColorEnum.None).Select(x => x.Id).ToList(),
                Cells = cells
            };

            return map;
        }
    }
}
