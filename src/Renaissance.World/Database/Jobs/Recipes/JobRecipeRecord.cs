using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Jobs.Recipes
{
    [Table("JobsRecipes")]
    public class JobRecipeRecord : IRecord
    {
        [Key]
        public int Id { get; set; }

        public int ResultId { get; set; }

        public string ResultName { get; set; }

        public int ResultTypeId { get; set; }

        public int ResultLevel { get; set; }

        public List<int> IngredientIds { get; set; }

        public List<int> Quantities { get; set; }

        public int JobId { get; set; }

        public int SkillId { get; set; }

    }
}
