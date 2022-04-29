using API_PROJET_GARDERIE.Logics.Controleurs;
using API_PROJET_GARDERIE.Logics.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API_PROJET_GARDERIE.Controllers
{
    public class PresenceController : Controller
    {
        /// <summary>
        /// Methode qui permet d'obtenir la liste des présences
        /// </summary>
        /// <returns>La liste des présences dans la base de données</returns>
        [Route("Presence/ObtenirListePresence")]
        [HttpGet]
        public List<PresenceDTO> ObtenirListePresence([FromQuery] string nomGarderie)
        {
            List<PresenceDTO> liste;
            try
            {
                liste = PresenceControleur.Instance.ObtenirListePresence(nomGarderie);
            }
            catch
            {
                liste = new List<PresenceDTO>();
            }
            return liste;
        }

        /// <summary>
        /// Permet d'obtenir une présence selon sa date, le nom, le prenom et la date de naissance de l'enfant
        /// </summary>
        /// <param name="dateTemps">La date de la présence</param>
        /// <param name="nomEnfant">Le nom de l'enfant</param>
        /// <param name="prenomEnfant">Le prenom de l'enfant</param>
        /// <param name="dateNaissanceEnfant">La date de naissance de l'enfant</param>
        /// <returns>Une presenceDTO</returns>
        [Route("Presence/ObtenirPresence")]
        [HttpGet]
        public PresenceDTO ObtenirPresence([FromQuery] string dateTemps, [FromQuery] string nomEnfant, [FromQuery] string prenomEnfant, [FromQuery] string dateNaissanceEnfant)
        {
            PresenceDTO unePresence;
            try
            {
                unePresence = PresenceControleur.Instance.ObtenirPresence(dateTemps, nomEnfant, prenomEnfant, dateNaissanceEnfant);
            }
            catch
            {
                unePresence = new PresenceDTO();
            }
            return unePresence;
        }

        /// <summary>
        /// Permet d'ajouter une présence
        /// </summary>
        /// <param name="presenceDTO">La PresenceDTO à ajouter</param>
        [Route("Presence/AjouterPresence")]
        [HttpPost]
        public void AjouterPresence([FromBody] PresenceDTO presenceDTO)
        {
            try
            {
                PresenceControleur.Instance.AjouterPresence(presenceDTO);
            }
            catch (Exception)
            {
            }
        }
    }
}
