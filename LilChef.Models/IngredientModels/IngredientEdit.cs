using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LilChef.Data.IngredientCategories;

namespace LilChef.Models.IngredientModels
{
    public class IngredientEdit
    {
        [Required]
        [Display(Name = "Ingredient Name")]
        public string IngredientName { get; set; }
        public string Description { get; set; }

        [Display(Name = "Contains Gluten")]
        public bool HasGluten { get; set; }

        [Display(Name = "Contains Nuts")]
        public bool HasNuts { get; set; }

        [Display(Name = "Contains Eggs")]
        public bool HasEggs { get; set; }

        [Display(Name = "Contains Soy")]
        public bool HasSoy { get; set; }
        [Display(Name = "Contains Dairy")]
        public bool HasDairy { get; set; }

        [Display(Name = "Vegan Friendly")]
        public bool IsVegan { get; set; }

        [Display(Name = "Vegetarian Friendly")]
        public bool IsVegetarian { get; set; }

        [Display(Name = "Pescatarian Friendly")]
        public bool IsPescatarian { get; set; }

        [Display(Name = "Keto Friendly")]
        public bool IsKetoFriendly { get; set; }
        public CategoryType Category { get; set; }
        public int IngredientId { get; set; }
    }
}
