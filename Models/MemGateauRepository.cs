namespace SolutionEx5Gateaux.Models
{
    public class MemGateauRepository : IGateauRepository
    {
        public IEnumerable<Gateau> MesGateaux
        {
            get { return _MesGateaux; }
        }
        private List<Gateau> _MesGateaux = new List<Gateau>()
        {/*
            new Gateau{
                Id = 0,
                Nom = "Volcan et dinosaures",
                UrlImage = "/images/Dinos.jpg",
                Description="Gâteau génoise vanille, ganache au chocolat blanc vanille (intérieur) et au chocolat au lait (extérieur), amandes effilées",
                Ingredients="Farine, oeufs, sucre, crème 35%, chocolat blanc, chocolat au lait, café, amandes, etc. "
            },
            new Gateau{
                Id= 1,
                Nom="Mouton mignon",
                UrlImage="/images/Sheep.jpg",
                Description="Gâteau en couches aux couleurs de l'arc-en-ciel avec une dacquoise amandes, crème chantilly mascarpone",
                Ingredients="Farine, oeufs, sucre, amandes, crème 35%, mascarpone, guimauve, etc."
            },
            new Gateau
            {
                Id=2,
                Nom="Ruche",
                UrlImage="/images/Ruche.jpg",
                Description="Gâteau vanille, ganache au chocolat blanc et miel",
                Ingredients="Farine, oeufs, sucre, crème 35%, chocolat blanc, colorant jaune, miel, etc."
            },
            new Gateau
            {
                Id=3,
                Nom="Chat",
                UrlImage="/images/chat.jpg",
                Description="Gâteau damier, génoise chocolat et vanille, crème au beurre meringue italienne, recouvert de pâte à sucre",
                Ingredients="Farine, oeufs, sucre, beurre, colorant, etc."
            },
            new Gateau
            {
                Id=4,
                Nom="Echiquier",
                UrlImage="/images/Echiquier.jpg",
                Description="Gâteau vanille et chocolat, crème au beurre italienne au beurre d'arachides, recouvert de pâte à sucre",
                Ingredients="Farine, oeufs, sucre, vanille, beurre, beurre d'arachides, etc."
            },
            new Gateau
            {
                Id=5,
                Nom="Funfetti",
                UrlImage="/images/funfetti.jpg",
                Description="Gâteau pinata, génoise vanille, crème chantilly mascarpone",
                Ingredients="Farine, oeufs, sucre, crème 35%, mascarpone, etc."
            },
            new Gateau
            {
                Id=6,
                Nom="Halloween",
                UrlImage="/images/Halloween.jpg",
                Description="Tarte panna cotta au chocolat, biscuits oreo, araignées en chocolat, glaçage au sucre",
                Ingredients="Farine, oeufs, beurre, sucre, crème 35%, chocolat, etc."
            }*/
        };

        /// <summary>
        /// Méthode qui cherche et retourne un gâteau
        /// ayant l'identifiant gateauId
        /// </summary>
        /// <param name="gateauId">L'identifiant du gâteau</param>
        /// <returns>Le gâteau avec l'identifiant gateauId</returns>
        public Gateau GetGateau(int gateauId)
        {
            return MesGateaux.FirstOrDefault(g => g.Id == gateauId);
        }

        /// <summary>
        /// Méthode pour ajouter un nouveau gateau dans la liste
        /// </summary>
        /// <param name="gateau">Le gateau à ajouter</param>
        public void AddGateau(Gateau gateau)
        {
            _MesGateaux.Add(gateau);
        }

        /// <summary>
        /// Méthode pour modifier un nouveau gâteau dans la liste
        /// </summary>
        /// <param name="id">L'identifiant du gâteau</param>
        /// <param name="gateau">Le gâteau à modifier</param>
        public void EditGateau(int id, Gateau gateau)
        {
            int i = _MesGateaux.IndexOf(GetGateau(id));
            _MesGateaux[i] = gateau;
        }

        /// <summary>
        /// Méthode pour supprimer un gâteau
        /// </summary>
        /// <param name="id">L'identifiant du gâteau</param>
        public void DeleteGateau(int id)
        {
            _MesGateaux.Remove(GetGateau(id));
        }
    }
}
