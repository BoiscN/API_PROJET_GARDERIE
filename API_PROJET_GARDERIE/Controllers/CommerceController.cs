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
        [Route("Garderie/ObtenirListeCommerce")]
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
    }
}
