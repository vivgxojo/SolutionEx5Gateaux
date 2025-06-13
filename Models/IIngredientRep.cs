namespace SolutionEx5Gateaux.Models
{
    public interface IIngredientRep
    {
        public IEnumerable<Ingredient> MesIngredients { get; }

        public Ingredient GetIngredient(int ingredientId);

        public void AddIngredient(Ingredient ingredient);

        public void EditIngredient(Ingredient ingredient);

        public void DeleteIngredient(int id);
    }
}
