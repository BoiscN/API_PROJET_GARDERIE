using API_PROJET_GARDERIE.Logics.Controleurs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API_PROJET_GARDERIE.Controllers
{
    public class RapportController : Controller
    {
        /// <summary>
        /// Méthode de service qui permet le revenu d'une garderie par année
        /// </summary>
        /// <param name="nomGarderie"></param>
        /// <param name="dateTemps"></param>
        /// <returns></returns>
        [Route("Rapport/CalculerRevenu")]
        [HttpGet]
        public double CalculerRevenu([FromQuery] string nomGarderie, [FromQuery] string dateTemps)
        {
            double nombrePresence = PresenceControleur.Instance.ObtenirRevenue(nomGarderie, dateTemps);

            return nombrePresence;
        }
        /// <summary>
        /// Méthode de service qui permet de calculer les depenses
        /// </summary>
        /// <param name="nomGarderie"></param>
        /// <param name="dateTemps"></param>
        /// <returns></returns>
        [Route("Rapport/CalculerDepense")]
        [HttpGet]
        public double CalculerDepense([FromQuery] string nomGarderie, [FromQuery] string dateTemps)
        {
            double depenseAdmissible = 0;

            try
            {
                depenseAdmissible = PresenceControleur.Instance.CalculerDepensesGarderie(nomGarderie, dateTemps);
            }
            catch (Exception)
            {

                
            }
            return depenseAdmissible;
        }
        /// <summary>
        /// Méthode service qui permet de calculer le profit
        /// </summary>
        /// <param name="nomGarderie"></param>
        /// <param name="dateTemps"></param>
        /// <returns></returns>
        [Route("Rapport/CalculerProfit")]
        [HttpGet]
        public double CalculerProfit([FromQuery] string nomGarderie, [FromQuery] string dateTemps)
        {
            double profile = 0;

            try
            {

                profile = PresenceControleur.Instance.CaluleProfit(nomGarderie, dateTemps);
            }
            catch (Exception)
            {

            }
            return profile;
        }
    }
}
