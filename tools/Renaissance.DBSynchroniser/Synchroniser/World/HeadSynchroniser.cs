using System;
using System.Collections.Generic;

using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.breeds;
using Renaissance.World.Database.Heads;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class HeadSynchroniser : AbstractSynchroniser<HeadRecord, HeadData>
    {
        public HeadSynchroniser(IEnumerable<HeadData> datas, IRepository<HeadRecord> database) : base(datas, database) { }

        protected override HeadRecord BuildEntity(HeadData data)
        {
            return new HeadRecord()
            {
                Id = data.Id,
                SkinId = Convert.ToInt16(data.Skins),
                AssetId = data.AssetId,
                Breed = (int)data.Breed,
                Gender = (int)data.Gender,
                Label = data.Label,
                Order = (int)data.Order
            };
        }
    }
}
