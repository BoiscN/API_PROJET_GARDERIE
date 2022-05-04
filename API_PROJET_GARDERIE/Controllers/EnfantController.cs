using API_PROJET_GARDERIE.Logics.Controleurs;
using API_PROJET_GARDERIE.Logics.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API_PROJET_GARDERIE.Controllers
{
    public class EnfantController : Controller
    {
        /// <summary>
        /// Methode qui permet d'obtenir la liste des enfants
        /// </summary>
        /// <returns>La liste des enfants dans la base de données</returns>
        [Route("Enfant/ObtenirListeEnfant")]
        [HttpGet]
        public List<EnfantDTO> ObtenirListeEnfant()
        {
            List<EnfantDTO> liste;
            try
            {
                liste = EnfantControleur.Instance.ObtenirListeEnfant();
            }
            catch
            {
                liste = new List<EnfantDTO>();
            }
            return liste;
        }

        /// <summary>
        /// Permet d'obtenir un enfant selon son nom, son prenom et sa date de naissance
        /// </summary>
        /// <param name="nomEnfant">Le nom de l'enfant</param>
        /// <param name="prenomEnfant">Le prenom de l'enfant</param>
        /// <param name="dateNaissanceEnfant">La date de naissance de l'enfant</param>
        /// <returns>Un EnfantDTO</returns>
        [Route("Enfant/ObtenirEnfant")]
        [HttpGet]
        public EnfantDTO ObtenirEnfant([FromQuery] string nomEnfant, [FromQuery] string prenomEnfant, [FromQuery] string dateNaissanceEnfant)
        {
            EnfantDTO unEnfant;
            try
            {
                unEnfant = EnfantControleur.Instance.ObtenirEnfant(nomEnfant, prenomEnfant, dateNaissanceEnfant);
            }
            catch
            {
                unEnfant = new EnfantDTO();
            }
            return unEnfant;
        }

        /// <summary>
        /// Permet d'ajouter un enfant
        /// </summary>
        /// <param name="enfantDTO">La EnfantDTO à ajouter</param>
        [Route("Enfant/AjouterEnfant")]
        [HttpPost]
        public void AjouterEnfant([FromBody] EnfantDTO enfantDTO)
        {
            try
            {
                EnfantControleur.Instance.AjouterEnfant(enfantDTO);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Permet de modifier un enfant existant
        /// </summary>
        /// <param name="enfantDTO">L'enfant modifié</param>
        [Route("Enfant/ModifierEnfant")]
        [HttpPost]
        public void ModifierEnfant([FromBody] EnfantDTO enfantDTO)
        {
            try
            {
                EnfantControleur.Instance.ModifierEnfant(enfantDTO);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Permet de supprimer un enfant
        /// </summary>
        /// <param name="nomEnfant">Le nom de l'enfant à supprimer</param>
        /// <param name="prenomEnfant">Le prenom de l'enfant à supprimer</param>
        /// <param name="dateNaissanceEnfant">La date de naissance de l'enfant à supprimer</param>
        [Route("Enfant/SupprimerEnfant")]
        [HttpPost]
        public void SupprimerEducateur([FromQuery] string nomEnfant, [FromQuery] string prenomEnfant, [FromQuery] string dateNaissanceEnfant)
        {
            try
            {
                EnfantControleur.Instance.SupprimerEnfant(nomEnfant, prenomEnfant, dateNaissanceEnfant);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Supprimer toutes les enfants existant dans la base de données
        /// </summary>
        [Route("Enfant/ViderListeEnfant")]
        [HttpPost]
        public void ViderListeEnfant()
        {
            try
            {
                EnfantControleur.Instance.ViderListeEnfant();
            }
            catch (Exception)
            {
            }
        }
    }
}
