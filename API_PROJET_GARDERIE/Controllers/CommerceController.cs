using API_PROJET_GARDERIE.Logics.Controleurs;
using API_PROJET_GARDERIE.Logics.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API_PROJET_GARDERIE.Controllers
{
    public class CommerceController : Controller
    {
        /// <summary>
        /// Methode qui permet d'obtenir la liste des commerces de dépenses d'une garderie
        /// </summary>
        /// <returns>La liste des commerces de dépenses d'une garderie dans la base de données</returns>
        [Route("Commerce/ObtenirListeCommerce")]
        [HttpGet]
        public List<CommerceDTO> ObtenirListeCommerce()
        {
            List<CommerceDTO> liste;
            try
            {
                liste = CommerceControleur.Instance.ObtenirListeCommerce();
            }
            catch
            {
                liste = new List<CommerceDTO>();
            }
            return liste;
        }

        /// <summary>
        /// Permet d'obtenir un commerce selon son DTO
        /// </summary>
        /// <param name="commerceDTO">Le DTO du commercee</param>
        /// <returns>Une CommerceDTO</returns>
        [Route("Commerce/ObtenirCommerce")]
        [HttpGet]
        public CommerceDTO ObtenirCommerce([FromQuery] CommerceDTO commerceDTO)
        {
            CommerceDTO unCommerce;
            try
            {
                unCommerce = CommerceControleur.Instance.ObtenirCommerce(commerceDTO);
            }
            catch
            {
                unCommerce = new CommerceDTO();
            }
            return unCommerce;
        }

        /// <summary>
        /// Permet d'ajouter un Commerce
        /// </summary>
        /// <param name="commerceDTO">La CommerceDTO à ajouter</param>
        [Route("Commerce/AjouterGarderie")]
        [HttpPost]
        public void AjouterCommerce([FromBody] CommerceDTO commerceDTO)
        {
            try
            {
                CommerceControleur.Instance.AjouterCommerce(commerceDTO);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Permet de modifier un commerce existant
        /// </summary>
        /// <param name="commerceDTO">Le commerce modifié</param>
        [Route("Commerce/ModifierCommerce")]
        [HttpPost]
        public void ModifierCommerce([FromBody] CommerceDTO commerceDTO)
        {
            try
            {
                CommerceControleur.Instance.ModifierCommerce(commerceDTO);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Permet de supprimer un Commerce
        /// </summary>
        /// <param name="descriptionCommerce">La description du commerce à supprimer</param>
        [Route("Commerce/SupprimerCommerce")]
        [HttpPost]
        public void SupprimerCommerce([FromQuery] string descriptionCommerce)
        {
            try
            {
                CommerceControleur.Instance.SupprimerCommerce(descriptionCommerce);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Supprimer toutes les commerces existant dans la base de données
        /// </summary>
        [Route("Commerce/ViderListeCommerce")]
        [HttpPost]
        public void ViderListeCommerce()
        {
            try
            {
                CommerceControleur.Instance.ViderListeCommerce();
            }
            catch (Exception)
            {
            }
        }
    }
}
