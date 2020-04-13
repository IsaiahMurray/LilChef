using LilChef.Data;
using LilChef.Models.IngredientModels;
using LilChef.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LilChef.Data.IngredientCategories;

namespace LilChef.Services
{
    public class IngredientServices
    {
        public bool CreateIngredient(IngredientCreate model)
        {
            var entity =
                new Ingredient()
                {
                    IngredientName = model.IngredientName,
                    Description = model.Description,
                    HasGluten = model.HasGluten,
                    HasNuts = model.HasNuts,
                    HasEggs = model.HasEggs,
                    HasSoy = model.HasSoy,
                    HasDairy = model.HasDairy,
                    IsVegan = model.IsVegan,
                    IsVegetarian = model.IsVegetarian,
                    IsPescatarian = model.IsPescatarian,
                    IsKetoFriendly = model.IsKetoFriendly,
                    Category = model.Category
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<IngredientListItem> GetIngredients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredients
                        .Select(
                            e =>
                                new IngredientListItem
                                {
                                    IngredientName = e.IngredientName,
                                    Category = e.Category
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<IngredientListItem> GetIngredientByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredients
                        .Where(e => e.IngredientName.ToLower() == name.ToLower())
                        .Select(
                            e =>
                                new IngredientListItem
                                {
                                    IngredientName = e.IngredientName,
                                    Category = e.Category
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<IngredientListItem> GetIngredientGlutenFree()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredients
                        .Where(e => e.HasGluten == false)
                        .Select(
                            e =>
                                new IngredientListItem
                                {
                                    IngredientName = e.IngredientName,
                                    Category = e.Category
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<IngredientListItem> GetIngredientNutFree()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredients
                        .Where(e => e.HasNuts == false)
                        .Select(
                            e =>
                                new IngredientListItem
                                {
                                    IngredientName = e.IngredientName,
                                    Category = e.Category
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<IngredientListItem> GetIngredientEggFree()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredients
                        .Where(e => e.HasEggs == false)
                        .Select(
                            e =>
                                new IngredientListItem
                                {
                                    IngredientName = e.IngredientName,
                                    Category = e.Category
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<IngredientListItem> GetIngredientSoyFree()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredients
                        .Where(e => e.HasSoy == false)
                        .Select(
                            e =>
                                new IngredientListItem
                                {
                                    IngredientName = e.IngredientName,
                                    Category = e.Category
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<IngredientListItem> GetIngredientDairyFree()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredients
                        .Where(e => e.HasDairy == false)
                        .Select(
                            e =>
                                new IngredientListItem
                                {
                                    IngredientName = e.IngredientName,
                                    Category = e.Category
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<IngredientListItem> GetIngredientIsVegan()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredients
                        .Where(e => e.IsVegan == false)
                        .Select(
                            e =>
                                new IngredientListItem
                                {
                                    IngredientName = e.IngredientName,
                                    Category = e.Category
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<IngredientListItem> GetIngredientIsVegetarian()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredients
                        .Where(e => e.IsVegetarian == false)
                        .Select(
                            e =>
                                new IngredientListItem
                                {
                                    IngredientName = e.IngredientName,
                                    Category = e.Category
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<IngredientListItem> GetIngredientIsPescatarian()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredients
                        .Where(e => e.IsPescatarian == false)
                        .Select(
                            e =>
                                new IngredientListItem
                                {
                                    IngredientName = e.IngredientName,
                                    Category = e.Category
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<IngredientListItem> GetIngredientIsKetoFriendly()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredients
                        .Where(e => e.IsKetoFriendly == false)
                        .Select(
                            e =>
                                new IngredientListItem
                                {
                                    IngredientName = e.IngredientName,
                                    Category = e.Category
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<IngredientListItem> GetRecipeByDifficulty(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredients
                        .Where(e => e.Category == (CategoryType)id)
                        .Select(
                            e =>
                                new IngredientListItem
                                {
                                    IngredientName = e.IngredientName,
                                    Category = e.Category
                                }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateIngredient(IngredientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                        .Ingredients
                        .Single(e => e.IngredientId == model.IngredientId);

                entity.IngredientName = model.IngredientName;
                entity.Description = model.Description;
                entity.Category = model.Category;
                entity.HasGluten = model.HasGluten;
                entity.HasNuts = model.HasNuts;
                entity.HasEggs = model.HasEggs;
                entity.HasSoy = model.HasSoy;
                entity.IsVegan = model.IsVegan;
                entity.IsVegetarian = model.IsVegetarian;
                entity.IsPescatarian = model.IsPescatarian;
                entity.IsKetoFriendly = model.IsKetoFriendly;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletIngredient(int ingreientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ingredients.Single(e => e.IngredientId == ingreientId);
                ctx.Ingredients.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

