
namespace SolutionEx5Gateaux.Models
{
    public class BDIngredientRep : IIngredientRep
    {
        private readonly CatalogueGateaux context; //BD

        public BDIngredientRep(CatalogueGateaux context) // Récupérer la BD dans le service
        {
            this.context = context;
        }

        public IEnumerable<Ingredient> MesIngredients => context.Ingredient;

        public void AddIngredient(Ingredient ingredient)
        {
            context.Ingredient.Add(ingredient);
            context.SaveChanges();
        }

        public void DeleteIngredient(int id)
        {
            context.Ingredient.Remove(GetIngredient(id));
            context.SaveChanges();
        }

        public void EditIngredient(Ingredient ingredient)
        {
            context.Ingredient.Update(ingredient);
            context.SaveChanges();
        }

        public Ingredient GetIngredient(int ingredientId)
        {
            return context.Ingredient.FirstOrDefault(i => i.Id == ingredientId);
        }
    }
}
