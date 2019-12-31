using System.Collections.Generic;

using Renaissance.Data.D2I;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.appearance;
using Renaissance.World.Database.Titles;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class TitleSynchroniser : AbstractSynchroniser<TitleRecord, TitleData>
    {
        private readonly D2IManager m_d2i;


        public TitleSynchroniser(D2IManager d2i, IEnumerable<TitleData> datas, IRepository<TitleRecord> database)
            : base(datas, database) { this.m_d2i = d2i; }



        protected override TitleRecord BuildEntity(TitleData data)
        {
            return new TitleRecord()
            {
                Id = data.Id,
                NameMale = m_d2i.DataAccess.GetText((int)data.NameMaleId),
                NameFemale = m_d2i.DataAccess.GetText((int)data.NameFemaleId),
                Visible = data.Visible,
                CategoryId = data.CategoryId
            };
        }
    }
}
