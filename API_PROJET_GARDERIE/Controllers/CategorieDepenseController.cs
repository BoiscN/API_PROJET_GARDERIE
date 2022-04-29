using API_PROJET_GARDERIE.Logics.Controleurs;
using API_PROJET_GARDERIE.Logics.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API_PROJET_GARDERIE.Controllers
{
    public class CategorieDepenseController : Controller
    {
        /// <summary>
        /// Methode qui permet d'obtenir la liste des catégories de dépenses d'une garderie
        /// </summary>
        /// <returns>La liste des catégories de dépenses d'une garderie dans la base de données</returns>
        [Route("CategorieDepense/ObtenirListeCategorieDepense")]
        [HttpGet]
        public List<CategorieDepenseDTO> ObtenirListeCategorieDepense()
        {
            List<CategorieDepenseDTO> liste;
            try
            {
                liste = CategorieDepenseControleur.Instance.ObtenirListeCategorieDepense();
            }
            catch
            {
                liste = new List<CategorieDepenseDTO>();
            }
            return liste;
        }
        /// <summary>
        /// Permet d'obtenir une categorieDepense selon son DTO
        /// </summary>
        /// <param name="descriptionCategorieDepense">La description du commerce</param>
        /// <returns>Un CommerceDTO</returns>
        [Route("CategorieDepense/ObtenirCategorieDepense")]
        [HttpGet]
        public CategorieDepenseDTO ObtenirCategorieDepense([FromQuery] string descriptionCategorieDepense)
        {
            CategorieDepenseDTO uneCategorieDepense;
            try
            {
                uneCategorieDepense = CategorieDepenseControleur.Instance.ObtenirCategorieDepense(descriptionCategorieDepense);
            }
            catch
            {
                uneCategorieDepense = new CategorieDepenseDTO();
            }
            return uneCategorieDepense;
        }
        /// <summary>
        /// Permet d'ajouter une categorieDepense
        /// </summary>
        /// <param name="categorieDepenseDTO">La CommerceDTO à ajouter</param>
        [Route("CategorieDepense/AjouterCategorieDepense")]
        [HttpPost]
        public void AjouterCategorieDepense([FromBody] CategorieDepenseDTO categorieDepenseDTO)
        {
            try
            {
                CategorieDepenseControleur.Instance.AjouterCategorieDepense(categorieDepenseDTO);
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// Permet de modifier une categorieDepense existant
        /// </summary>
        /// <param name="categorieDepenseDTO">Le commerce modifié</param>
        [Route("CategorieDepense/ModifierCategorieDepense")]
        [HttpPost]
        public void ModifierCategorieDepense([FromBody] CategorieDepenseDTO categorieDepenseDTO)
        {
            try
            {
                CategorieDepenseControleur.Instance.ModifierCategorieDepense(categorieDepenseDTO);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Permet de supprimer une CategorieDepense
        /// </summary>
        /// <param name="descriptionCategorieDepense">La description du commerce à supprimer</param>
        [Route("CategorieDepense/SupprimerCategorieDepense")]
        [HttpPost]
        public void SupprimerCategorieDepense([FromQuery] string descriptionCategorieDepense)
        {
            try
            {
                CategorieDepenseControleur.Instance.SupprimerCategorieDepense(descriptionCategorieDepense);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Supprimer toutes les categoriesDepenses existant dans la base de données
        /// </summary>
        [Route("CategorieDepense/ViderListeCategorieDepense")]
        [HttpPost]
        public void ViderListeCategorieDepense()
        {
            try
            {
                CategorieDepenseControleur.Instance.ViderListeCategorieDepense();
            }
            catch (Exception)
            {
            }
        }
    }
}