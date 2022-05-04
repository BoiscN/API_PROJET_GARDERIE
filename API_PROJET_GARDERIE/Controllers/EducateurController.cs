using API_PROJET_GARDERIE.Logics.Controleurs;
using API_PROJET_GARDERIE.Logics.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API_PROJET_GARDERIE.Controllers
{
    public class EducateurController : Controller
    {
        /// <summary>
        /// Methode qui permet d'obtenir la liste des educateurs
        /// </summary>
        /// <returns>La liste des educateurs dans la base de données</returns>
        [Route("Educateur/ObtenirListeEducateur")]
        [HttpGet]
        public List<EducateurDTO> ObtenirListeEducateur()
        {
            List<EducateurDTO> liste;
            try
            {
                liste = EducateurControleur.Instance.ObtenirListeEducateur();
            }
            catch
            {
                liste = new List<EducateurDTO>();
            }
            return liste;
        }

        /// <summary>
        /// Permet d'obtenir un educateur selon son nom, son prenom et sa date de naissance
        /// </summary>
        /// <param name="nomEducateur">Le nom de l'educateur</param>
        /// <param name="prenomEducateur">Le prenom de l'educateur</param>
        /// <param name="dateNaissanceEducateur">La date de naissance de l'educateur</param>
        /// <returns>Un EducateurDTO</returns>
        [Route("Educateur/ObtenirEducateur")]
        [HttpGet]
        public EducateurDTO ObtenirEducateur([FromQuery] string nomEducateur, [FromQuery] string prenomEducateur, [FromQuery] string dateNaissanceEducateur)
        {
            EducateurDTO unEducateur;
            try
            {
                unEducateur = EducateurControleur.Instance.ObtenirEducateur(nomEducateur, prenomEducateur, dateNaissanceEducateur);
            }
            catch
            {
                unEducateur = new EducateurDTO();
            }
            return unEducateur;
        }

        /// <summary>
        /// Permet d'ajouter un educateur
        /// </summary>
        /// <param name="educateurDTO">La EducateurDTO à ajouter</param>
        [Route("Educateur/AjouterEducateur")]
        [HttpPost]
        public void AjouterEducateur([FromBody] EducateurDTO educateurDTO)
        {
            try
            {
                EducateurControleur.Instance.AjouterEducateur(educateurDTO);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Permet de modifier un educateur existant
        /// </summary>
        /// <param name="educateurDTO">L'educateur modifié</param>
        [Route("Educateur/ModifierEducateur")]
        [HttpPost]
        public void ModifierEducateur([FromBody] EducateurDTO educateurDTO)
        {
            try
            {
                EducateurControleur.Instance.ModifierEducateur(educateurDTO);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Permet de supprimer un educateur
        /// </summary>
        /// <param name="nomEducateur">Le nom de la educateur à supprimer</param>
        /// <param name="prenomEducateur">Le nom de la educateur à supprimer</param>
        /// <param name="dateNaissanceEducateur">Le nom de la educateur à supprimer</param>
        [Route("Educateur/SupprimerEducateur")]
        [HttpPost]
        public void SupprimerEducateur([FromQuery] string nomEducateur, [FromQuery] string prenomEducateur, [FromQuery] string dateNaissanceEducateur)
        {
            try
            {
                EducateurControleur.Instance.SupprimerEducateur(nomEducateur, prenomEducateur, dateNaissanceEducateur);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Supprimer toutes les educateurs existant dans la base de données
        /// </summary>
        [Route("Educateur/ViderListeEducateur")]
        [HttpPost]
        public void ViderListeEducateur()
        {
            try
            {
                EducateurControleur.Instance.ViderListeEducateur();
            }
            catch (Exception)
            {
            }
        }
    }
}
