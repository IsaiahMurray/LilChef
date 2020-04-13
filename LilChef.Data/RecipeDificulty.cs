using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LilChef.Data
{
    public class RecipeDifficulty
    {
        public enum Difficulty { Easy = 0, Normal = 1, Hard = 2, Expert = 3, Oui_Chef = 4 }

        [Key]
        public int DifficultyId { get; set; }
    }
}