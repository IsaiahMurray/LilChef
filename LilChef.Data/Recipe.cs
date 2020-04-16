
using LilChef.MVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LilChef.Data.RecipeDifficulty;

namespace LilChef.Data
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [EmailAddress]
        public string Author { get; set; }

        [Display(Name = "Recipe Name")]
        public string RecipeName { get; set; }
        public string Description { get; set; }

        [Display(Name = "Ingredients")]
        public string IngredientItems { get; set; }
        
        public string Procedure { get; set; }

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
        public Difficulty Difficulty { get; set; }
    }
}
