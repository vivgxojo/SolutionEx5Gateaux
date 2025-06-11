using System.ComponentModel.DataAnnotations;

namespace SolutionEx5Gateaux.Models
{
    public class Gateau
    {
        public int Id { get; set; } // Clé primaire
        public string Nom { get; set; }

        [Display(Name = "Url de l'image")]
        public string UrlImage { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; } // Sera effacé

        public List<Ingredient> IngredientsList = new List<Ingredient>(); //Navigation
    }
}
