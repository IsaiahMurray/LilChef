using LilChef.Data;
using LilChef.Models.IngredientModels;
using LilChef.Models.RecipeModels;
using LilChef.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LilChef.Data.RecipeDifficulty;

namespace LilChef.Services
{
    public class RecipeServices
    {
       
            private readonly Guid _userId;

            public RecipeServices(Guid userId)
            {
                _userId = userId;
            }
        
        public bool CreateRecipe(RecipeCreate model)
        {
            var entity =
                new Recipe()
                {
                    AuthorId = _userId,
                    RecipeName = model.RecipeName,
                    Description = model.Description,
                    IngredientItems = model.IngredientItems,
                    Procedure = model.Procedure,
                    HasGluten = model.HasGluten,
                    HasNuts = model.HasNuts,
                    HasEggs = model.HasEggs,
                    HasSoy = model.HasSoy,
                    IsVegan = model.IsVegan,
                    IsVegetarian = model.IsVegetarian,
                    IsPescatarian = model.IsPescatarian,
                    IsKetoFriendly = model.IsKetoFriendly,
                    Difficulty = model.Difficulty
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipeListItem> GetRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Select(
                            e =>
                                new RecipeListItem
                                {
                                    RecipeName = e.RecipeName,
                                    HasGluten = e.HasGluten,
                                    HasNuts = e.HasNuts,
                                    HasEggs = e.HasEggs,
                                    HasSoy = e.HasSoy,
                                    IsVegan = e.IsVegan,
                                    IsVegetarian = e.IsVegetarian,
                                    IsPescatarian = e.IsPescatarian,
                                    IsKetoFriendly = e.IsKetoFriendly,
                                    Difficulty = e.Difficulty
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<RecipeListItem> GetUserRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.AuthorId == _userId)
                        .Select(
                            e =>
                                new RecipeListItem
                                {
                                    RecipeName = e.RecipeName,
                                    HasGluten = e.HasGluten,
                                    HasNuts = e.HasNuts,
                                    HasEggs = e.HasEggs,
                                    HasSoy = e.HasSoy,
                                    IsVegan = e.IsVegan,
                                    IsVegetarian = e.IsVegetarian,
                                    IsPescatarian = e.IsPescatarian,
                                    IsKetoFriendly = e.IsKetoFriendly,
                                    Difficulty = e.Difficulty
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<RecipeListItem> GetRecipeByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.RecipeName.ToLower() == name.ToLower())
                        .Select(
                            e =>
                                new RecipeListItem
                                {
                                    RecipeName = e.RecipeName,
                                    HasGluten = e.HasGluten,
                                    HasNuts = e.HasNuts,
                                    HasEggs = e.HasEggs,
                                    HasSoy = e.HasSoy,
                                    IsVegan = e.IsVegan,
                                    IsVegetarian = e.IsVegetarian,
                                    IsPescatarian = e.IsPescatarian,
                                    IsKetoFriendly = e.IsKetoFriendly,
                                    Difficulty = e.Difficulty
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<RecipeListItem> GetRecipeByDifficulty(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.Difficulty == (Difficulty)id)
                        .Select(
                            e =>
                                new RecipeListItem
                                {
                                    RecipeName = e.RecipeName,
                                    HasGluten = e.HasGluten,
                                    HasNuts = e.HasNuts,
                                    HasEggs = e.HasEggs,
                                    HasSoy = e.HasSoy,
                                    IsVegan = e.IsVegan,
                                    IsVegetarian = e.IsVegetarian,
                                    IsPescatarian = e.IsPescatarian,
                                    IsKetoFriendly = e.IsKetoFriendly,
                                    Difficulty = e.Difficulty
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<RecipeListItem> GetRecipeByHasGluten()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.HasGluten == true)
                        .Select(
                            e =>
                                new RecipeListItem
                                {
                                    RecipeName = e.RecipeName,
                                    HasGluten = e.HasGluten,
                                    HasNuts = e.HasNuts,
                                    HasEggs = e.HasEggs,
                                    HasSoy = e.HasSoy,
                                    IsVegan = e.IsVegan,
                                    IsVegetarian = e.IsVegetarian,
                                    IsPescatarian = e.IsPescatarian,
                                    IsKetoFriendly = e.IsKetoFriendly,
                                    Difficulty = e.Difficulty
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<RecipeListItem> GetRecipeByHasNuts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.HasNuts == true)
                        .Select(
                            e =>
                                new RecipeListItem
                                {
                                    RecipeName = e.RecipeName,
                                    HasGluten = e.HasGluten,
                                    HasNuts = e.HasNuts,
                                    HasEggs = e.HasEggs,
                                    HasSoy = e.HasSoy,
                                    IsVegan = e.IsVegan,
                                    IsVegetarian = e.IsVegetarian,
                                    IsPescatarian = e.IsPescatarian,
                                    IsKetoFriendly = e.IsKetoFriendly,
                                    Difficulty = e.Difficulty
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<RecipeListItem> GetRecipeByHasSoy()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.HasSoy == true)
                        .Select(
                            e =>
                                new RecipeListItem
                                {
                                    RecipeName = e.RecipeName,
                                    HasGluten = e.HasGluten,
                                    HasNuts = e.HasNuts,
                                    HasEggs = e.HasEggs,
                                    HasSoy = e.HasSoy,
                                    IsVegan = e.IsVegan,
                                    IsVegetarian = e.IsVegetarian,
                                    IsPescatarian = e.IsPescatarian,
                                    IsKetoFriendly = e.IsKetoFriendly,
                                    Difficulty = e.Difficulty
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<RecipeListItem> GetRecipeByHasEggs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.HasEggs == true)
                        .Select(
                            e =>
                                new RecipeListItem
                                {
                                    RecipeName = e.RecipeName,
                                    HasGluten = e.HasGluten,
                                    HasNuts = e.HasNuts,
                                    HasEggs = e.HasEggs,
                                    HasSoy = e.HasSoy,
                                    IsVegan = e.IsVegan,
                                    IsVegetarian = e.IsVegetarian,
                                    IsPescatarian = e.IsPescatarian,
                                    IsKetoFriendly = e.IsKetoFriendly,
                                    Difficulty = e.Difficulty
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<RecipeListItem> GetRecipeIsVegan()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.IsVegan == true)
                        .Select(
                            e =>
                                new RecipeListItem
                                {
                                    RecipeName = e.RecipeName,
                                    HasGluten = e.HasGluten,
                                    HasNuts = e.HasNuts,
                                    HasEggs = e.HasEggs,
                                    HasSoy = e.HasSoy,
                                    IsVegan = e.IsVegan,
                                    IsVegetarian = e.IsVegetarian,
                                    IsPescatarian = e.IsPescatarian,
                                    IsKetoFriendly = e.IsKetoFriendly,
                                    Difficulty = e.Difficulty
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<RecipeListItem> GetRecipeIsVegetarian()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.IsVegetarian == true)
                        .Select(
                            e =>
                                new RecipeListItem
                                {
                                    RecipeName = e.RecipeName,
                                    HasGluten = e.HasGluten,
                                    HasNuts = e.HasNuts,
                                    HasEggs = e.HasEggs,
                                    HasSoy = e.HasSoy,
                                    IsVegan = e.IsVegan,
                                    IsVegetarian = e.IsVegetarian,
                                    IsPescatarian = e.IsPescatarian,
                                    IsKetoFriendly = e.IsKetoFriendly,
                                    Difficulty = e.Difficulty
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<RecipeListItem> GetRecipeIsPescatarian()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.IsPescatarian == true)
                        .Select(
                            e =>
                                new RecipeListItem
                                {
                                    RecipeName = e.RecipeName,
                                    HasGluten = e.HasGluten,
                                    HasNuts = e.HasNuts,
                                    HasEggs = e.HasEggs,
                                    HasSoy = e.HasSoy,
                                    IsVegan = e.IsVegan,
                                    IsVegetarian = e.IsVegetarian,
                                    IsPescatarian = e.IsPescatarian,
                                    IsKetoFriendly = e.IsKetoFriendly,
                                    Difficulty = e.Difficulty
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<RecipeListItem> GetRecipeIsKetoFriendly()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.IsKetoFriendly == true)
                        .Select(
                            e =>
                                new RecipeListItem
                                {
                                    RecipeName = e.RecipeName,
                                    HasGluten = e.HasGluten,
                                    HasNuts = e.HasNuts,
                                    HasEggs = e.HasEggs,
                                    HasSoy = e.HasSoy,
                                    IsVegan = e.IsVegan,
                                    IsVegetarian = e.IsVegetarian,
                                    IsPescatarian = e.IsPescatarian,
                                    IsKetoFriendly = e.IsKetoFriendly,
                                    Difficulty = e.Difficulty
                                }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateRecipe(RecipeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                        .Recipes
                        .Single(e => e.RecipeId == model.RecipeId);

                entity.RecipeName = model.RecipeName;
                entity.Description = model.Description;
                entity.IngredientItems = model.IngredientItems;
                entity.Procedure = model.Procedure;
                entity.HasGluten = model.HasGluten;
                entity.HasNuts = model.HasNuts;
                entity.HasEggs = model.HasEggs;
                entity.HasSoy = model.HasSoy;
                entity.IsVegan = model.IsVegan;
                entity.IsVegetarian = model.IsVegetarian;
                entity.IsPescatarian = model.IsPescatarian;
                entity.IsKetoFriendly = model.IsKetoFriendly;
                entity.Difficulty = model.Difficulty;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletRecipe(int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Recipes.Single(e => e.RecipeId == recipeId);
                ctx.Recipes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public List<IngredientListItem> GetAllIngredients()
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
                                    IngredientName = e.IngredientName
                                }
                        );

                return query.ToList();
            }
        }
    }
}
