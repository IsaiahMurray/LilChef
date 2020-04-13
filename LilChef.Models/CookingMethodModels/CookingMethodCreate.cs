using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LilChef.Data.RecipeDifficulty;

namespace LilChef.Models.CookingMethodModels
{
    public class CookingMethodCreate
    {
        [Display(Name = "Cooking Method")]
        public string CookingMethodName { get; set; }
        public string Description { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
