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
        [Route("Garderie/ObtenirListeCategorieDepense")]
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
    }
}
