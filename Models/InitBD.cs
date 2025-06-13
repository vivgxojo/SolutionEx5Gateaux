namespace SolutionEx5Gateaux.Models
{
    public static class InitBD
    {
        private static List<Gateau> _MesGateaux = new List<Gateau>()
        {
            new Gateau{
                //Id = 0,
                Nom = "Volcan et dinosaures",
                UrlImage = "/images/Dinos.jpg",
                Description="Gâteau génoise vanille, ganache au chocolat blanc vanille (intérieur) et au chocolat au lait (extérieur), amandes effilées",
                //Ingredients="Farine, oeufs, sucre, crème 35%, chocolat blanc, chocolat au lait, café, amandes, etc. "
            },
            new Gateau{
                //Id= 1,
                Nom="Mouton mignon",
                UrlImage="/images/Sheep.jpg",
                Description="Gâteau en couches aux couleurs de l'arc-en-ciel avec une dacquoise amandes, crème chantilly mascarpone",
                //Ingredients="Farine, oeufs, sucre, amandes, crème 35%, mascarpone, guimauve, etc."
            },
            new Gateau
            {
                //Id=2,
                Nom="Ruche",
                UrlImage="/images/Ruche.jpg",
                Description="Gâteau vanille, ganache au chocolat blanc et miel",
                //Ingredients="Farine, oeufs, sucre, crème 35%, chocolat blanc, colorant jaune, miel, etc."
            },
            new Gateau
            {
                //Id=3,
                Nom="Chat",
                UrlImage="/images/chat.jpg",
                Description="Gâteau damier, génoise chocolat et vanille, crème au beurre meringue italienne, recouvert de pâte à sucre",
                //Ingredients="Farine, oeufs, sucre, beurre, colorant, etc."
            },
            new Gateau
            {
                //Id=4,
                Nom="Echiquier",
                UrlImage="/images/Echiquier.jpg",
                Description="Gâteau vanille et chocolat, crème au beurre italienne au beurre d'arachides, recouvert de pâte à sucre",
                //Ingredients="Farine, oeufs, sucre, vanille, beurre, beurre d'arachides, etc."
            },
            new Gateau
            {
                //Id=5,
                Nom="Funfetti",
                UrlImage="/images/funfetti.jpg",
                Description="Gâteau pinata, génoise vanille, crème chantilly mascarpone",
                //Ingredients="Farine, oeufs, sucre, crème 35%, mascarpone, etc."
            },
            new Gateau
            {
                //Id=6,
                Nom="Halloween",
                UrlImage="/images/Halloween.jpg",
                Description="Tarte panna cotta au chocolat, biscuits oreo, araignées en chocolat, glaçage au sucre",
                //Ingredients="Farine, oeufs, beurre, sucre, crème 35%, chocolat, etc."
            }
        };

        private static List<Ingredient> _ingredients = new List<Ingredient>
        {
            new Ingredient
            {
                // Par défaut, l'identifiant est auto-incrémenté.
                Nom = "Miel",
                Type = "Sucre",
                Quantite = 10,
                //Unite = "ml",
                Prix = 5,
                //Gateau = NomGateauDict["Ruche"]
            },
            new Ingredient
            {
                Nom = "Colorant jaune",
                Type = "Colorant artificiel",
                Quantite = 500,
                //Unite = "ml",
                Prix = 5,
                //Gateau = NomGateauDict["Ruche"]
            },
            new Ingredient
            {
                Nom = "Citron",
                Type = "Fruit",
                Quantite = 2,
                //Unite = "",
                Prix = 5,
                //Gateau = NomGateauDict["Ruche"]
            },
            new Ingredient
            {
                Nom = "Bonbons",
                Type = "Sucre",
                Quantite = 50,
                //Unite = "g",
                Prix = 5,
                //Gateau = NomGateauDict["Funfetti"]
            },
            new Ingredient
            {
                Nom = "araignées colorées en chocolat",
                Type = "Chocolat",
                Quantite = 12,
                //Unite = "",
                Prix = 5,
                //Gateau = NomGateauDict["Halloween"]
            }
        };


        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            //Récupérer le contexte de la base de données à partir du service
            CatalogueGateaux context = applicationBuilder.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<CatalogueGateaux>();

            if (!context.Gateau.Any()) //Si la table est vide
            {
                context.Gateau.AddRange(_MesGateaux); //Remplir la table avec notre liste
                context.SaveChanges(); //Toujour sauvegarder la BD
            }

            if (!context.Ingredient.Any()) //Si la table est vide
            {
                // Associer les ingrédients aux Gateaux existants dans la BD pour générer les valeurs de FK
                for (int i = 0; i < 3; i++)
                {
                    _ingredients[i].Gateau = context.Gateau.FirstOrDefault(x => x.Nom == "Ruche");
                }
                _ingredients[3].Gateau = context.Gateau.FirstOrDefault(x => x.Nom == "Funfetti");
                _ingredients[4].Gateau = context.Gateau.FirstOrDefault(x => x.Nom == "Halloween");

                context.Ingredient.AddRange(_ingredients); //Remplir la table avec notre liste
                context.SaveChanges(); //Toujour sauvegarder la BD
            }
        }
    }
}
