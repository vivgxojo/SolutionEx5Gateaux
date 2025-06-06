using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolutionEx5Gateaux.Models;

namespace SolutionEx5Gateaux.Controllers
{
    public class GateauxController : Controller
    {

        private readonly IGateauRepository _mesGateaux;
        public GateauxController(IGateauRepository mesGateaux)
        {
            this._mesGateaux = mesGateaux;
        }

        /// <summary>
        /// Méthode d'action qui permet d'afficher 
        /// une liste d'images passées en paramètres 
        /// à la vue.
        /// </summary>
        /// <returns>La vue Liste</returns>
        public ViewResult Liste()
        {
            //ViewBag.Titre = "Mes gâteaux";

            return View(_mesGateaux.MesGateaux);
        }

        /// <summary>
        /// Méthode d'action qui permet d'afficher les 
        /// ingrédiens (ou autre) d'un gâteau
        /// </summary>
        /// <param name="id">Identifiant du gâteau</param>
        /// <returns>La vue Details</returns>
        public ViewResult DetailsGateau(int id)
        {
            Gateau gateau = _mesGateaux.GetGateau(id);

            return View("Details", gateau);
        }

        public IActionResult Nouveau()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ajouter(Gateau gateau)
        {
            _mesGateaux.AddGateau(gateau);
            return RedirectToAction("Liste");

        }

        // GET: GateauxController/Edit/5
        public ActionResult Edit(int id)
        {
            Gateau gateau = _mesGateaux.GetGateau(id);

            return View("Edit", gateau);
        }

        // POST: GateauxController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, Gateau gateau)
        {
            try
            {
                _mesGateaux.EditGateau(id, gateau);
                return RedirectToAction(nameof(Liste));
            }
            catch
            {
                return View("Edit", gateau);
            }
        }

        public IActionResult Supprimer(int id)
        {
            _mesGateaux.DeleteGateau(id);
            return RedirectToAction("Liste");

        }
    }
}
