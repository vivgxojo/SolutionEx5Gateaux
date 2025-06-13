using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SolutionEx5Gateaux.Models
{
    public class BDGateauRepository : IGateauRepository
    {
        private readonly CatalogueGateaux context; //BD

        public BDGateauRepository(CatalogueGateaux context) // Récupérer la BD dans le service
        {
            this.context = context; 
        }

        public IEnumerable<Gateau> MesGateaux
        {
            //Include permet de remplire la propriété de navigation avec les ingrédients à partir des FK
            get {
                return context.Gateau.Include(g => g.IngredientsList);
            }
        }        

        /// <summary>
        /// Méthode qui cherche et retourne un gâteau
        /// ayant l'identifiant gateauId
        /// </summary>
        /// <param name="gateauId">L'identifiant du gâteau</param>
        /// <returns>Le gâteau avec l'identifiant gateauId</returns>
        public Gateau GetGateau(int gateauId)
        {
            return context.Gateau.Include(g => g.IngredientsList).FirstOrDefault(g => g.Id == gateauId);
        }

        /// <summary>
        /// Méthode pour ajouter un nouveau gateau dans la liste
        /// </summary>
        /// <param name="gateau">Le gateau à ajouter</param>
        public void AddGateau(Gateau gateau)
        {
            context.Gateau.Add(gateau);
            context.SaveChanges();
        }

        /// <summary>
        /// Méthode pour modifier un nouveau gâteau dans la liste
        /// </summary>
        /// <param name="id">L'identifiant du gâteau</param>
        /// <param name="gateau">Le gâteau à modifier</param>
        public void EditGateau(int id, Gateau gateau)
        {
            context.Gateau.Update(gateau); //Le id n'est plus modifiable
            context.SaveChanges();
        }

        /// <summary>
        /// Méthode pour supprimer un gâteau
        /// </summary>
        /// <param name="id">L'identifiant du gâteau</param>
        public void DeleteGateau(int id)
        {
            context.Gateau.Remove(GetGateau(id));
            context.SaveChanges();
        }
    }
}
