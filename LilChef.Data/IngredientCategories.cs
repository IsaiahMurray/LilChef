using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LilChef.Data
{
    public class IngredientCategories
    {
        public enum CategoryType { Alternatives = 0, Meats = 1, Seafood = 2, Vegetables = 3, Fruit = 4, Dairy = 5, Pasta = 6, Legumes = 7, Eggs = 8, Nuts = 9, Grains = 10, Condiments = 11, Chips_and_Snacks = 12, Baking_Goods = 13, Breads = 14, Sweets = 15 }
        [Key]
        public int CategoryId { get; set; }
    }
}
