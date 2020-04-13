using LilChef.Data;
using LilChef.Models.CookingMethodModels;
using LilChef.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LilChef.Data.RecipeDifficulty;

namespace LilChef.Services
{
    public class CookingMethodServices
    {
        public bool CreateCookingMethod(CookingMethodCreate model)
        {
            var entity =
                new CookingMethod()
                {
                    CookingMethodName = model.CookingMethodName,
                    Description = model.Description,
                    Difficulty = model.Difficulty
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.CookingMethods.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CookingMethodListItem> GetCookingMethods()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CookingMethods
                        .Select(
                            e =>
                                new CookingMethodListItem
                                {
                                    CookingMethodName = e.CookingMethodName,
                                    Difficulty = e.Difficulty
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<CookingMethodListItem> GetCookingMethodsByDifficulty(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CookingMethods
                        .Where(e => e.Difficulty == (Difficulty)id)
                        .Select(
                            e =>
                                new CookingMethodListItem
                                {
                                    CookingMethodName = e.CookingMethodName,
                                    Difficulty = e.Difficulty
                                }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateRecipe(CookingMethodEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                        .CookingMethods
                        .Single(e => e.CookingMethodId == model.CookingMethodId);

                entity.CookingMethodName = model.CookingMethodName;
                entity.Description = model.Description;
                entity.Description = model.Description;
                entity.Difficulty = model.Difficulty;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletCookingMethod(int cookingMethodId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CookingMethods.Single(e => e.CookingMethodId == cookingMethodId);
                ctx.CookingMethods.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
