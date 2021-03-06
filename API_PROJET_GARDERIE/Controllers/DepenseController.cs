using API_PROJET_GARDERIE.Logics.Controleurs;
using API_PROJET_GARDERIE.Logics.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API_PROJET_GARDERIE.Controllers
{
    public class DepenseController : Controller
    {
        /// <summary>
        /// Methode qui permet d'obtenir la liste des dépense selon une garderie
        /// </summary>
        /// <returns>La liste des dépenses d'une garderie dans la base de données</returns>
        [Route("Depense/ObtenirListeDepense")]
        [HttpGet]
        public List<DepenseDTO> ObtenirListeDepense([FromQuery] string nomGarderie)
        {
            List<DepenseDTO> liste;
            try
            {
                liste = DepenseControleur.Instance.ObtenirListeDepense(nomGarderie);
            }
            catch
            {
                liste = new List<DepenseDTO>();
            }
            return liste;
        }

        /// <summary>
        /// Methode qui permet d'obtenir une dépense selon une garderie
        /// </summary>
        /// <returns>La dépense d'une garderie dans la base de données</returns>
        [Route("Depense/ObtenirDepense")]
        [HttpGet]
        public DepenseDTO ObtenirDepense([FromQuery] string nomGarderie, [FromQuery] string dateTemps)
        {
            DepenseDTO uneDepense;
            try
            {
                uneDepense = DepenseControleur.Instance.ObtenirDepense(nomGarderie, dateTemps);
            }
            catch
            {
                uneDepense = new DepenseDTO();
            }
            return uneDepense;
        }

        /// <summary>
        /// Permet d'ajouter une dépense
        /// </summary>
        /// <param name="depenseDTO">La DepenseDTO à ajouter</param>
        [Route("Depense/AjouterDepense")]
        [HttpPost]
        public void AjouterDepense([FromQuery] string nomGarderie, [FromBody] DepenseDTO depenseDTO)
        {
            try
            {
                DepenseControleur.Instance.AjouterDepense(nomGarderie, depenseDTO);
            }
            catch (Exception)
            {
            }
        }

        [Route("Depense/ModifierDepense")]
        [HttpPost]
        public void ModifierDepense([FromQuery] string nomGarderie, [FromBody] DepenseDTO depenseDTO)
        {
            try
            {
                DepenseControleur.Instance.ModifierDepense(nomGarderie, depenseDTO);
            }
            catch (Exception)
            {
            }
        }

        [Route("Depense/SupprimerDepense")]
        [HttpPost]
        public void SupprimerDepense([FromQuery] string nomGarderie, [FromQuery] string dateTemps)
        {
            try
            {
                DepenseControleur.Instance.SupprimerDepense(nomGarderie, dateTemps);
            }
            catch (Exception)
            {
            }
        }

        [Route("Depense/ViderListeDepense")]
        [HttpPost]
        public void ViderListeDepense([FromQuery] string nomGarderie)
        {
            try
            {
                DepenseControleur.Instance.ViderListeDepense(nomGarderie);
            }
            catch (Exception)
            {
            }
        }
    }
}
