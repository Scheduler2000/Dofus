using System.Collections.Generic;
using System.Linq;

using Renaissance.Data.D2I;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.jobs;
using Renaissance.World.Database.Jobs.Recipes;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class JobRecipeSynchroniser : AbstractSynchroniser<JobRecipe, RecipeData>
    {
        private readonly D2IManager m_d2i;
        private int m_counter = 1;


        public JobRecipeSynchroniser(D2IManager d2i, IEnumerable<RecipeData> datas, IRepository<JobRecipe> database)
            : base(datas, database) { this.m_d2i = d2i; }



        protected override JobRecipe BuildEntity(RecipeData data)
        {
            var result = new JobRecipe()
            {
                Id = m_counter,
                ResultId = data.ResultId,
                ResultName = m_d2i.DataAccess.GetText((int)data.ResultNameId),
                ResultTypeId = (int)data.ResultTypeId,
                ResultLevel = (int)data.ResultLevel,
                IngredientIds = data.IngredientIds,
                Quantities = data.Quantities.Select(x => (int)x).ToList(),
                JobId = data.JobId,
                SkillId = data.SkillId
            };

            m_counter++;
            return result;
        }
    }
}
