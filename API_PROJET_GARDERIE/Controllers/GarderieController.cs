using API_PROJET_GARDERIE.Logics.Controleurs;
using API_PROJET_GARDERIE.Logics.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API_PROJET_GARDERIE.Controllers
{
    public class GarderieController : Controller
    {
        /// <summary>
        /// Methode qui permet d'obtenir la liste des garderies
        /// </summary>
        /// <returns>La liste des garderies dans la base de données</returns>
        
        [Route("Garderie/ObtenirListeGarderie")]
        [HttpGet]
        public List<GarderieDTO> ObtenirListeGarderie()
        {
            List<GarderieDTO> liste;
            try
            {
                liste = GarderieControleur.Instance.ObtenirListeGarderie();
            }
            catch
            {
                liste = new List<GarderieDTO>();
            }
            return liste;
        }

        /// <summary>
        /// Permet d'obtenir une garderie selon son nom
        /// </summary>
        /// <param name="nomGarderie">Le nom de la garderie</param>
        /// <returns>Une GarderieDTO</returns>
        [Route("Garderie/ObtenirGarderie")]
        [HttpGet]
        public GarderieDTO ObtenirGarderie([FromQuery] string nomGarderie)
        {
            GarderieDTO uneGarderie;
            try
            {
                uneGarderie = GarderieControleur.Instance.ObtenirGarderie(nomGarderie);
            }
            catch
            {
                uneGarderie = new GarderieDTO();
            }
            return uneGarderie;
        }

        /// <summary>
        /// Permet d'ajouter une garderie
        /// </summary>
        /// <param name="garderieDTO">La GarderieDTO à ajouter</param>
        [Route("Garderie/AjouterGarderie")]
        [HttpPost]
        public void AjouterGarderie([FromBody] GarderieDTO garderieDTO)
        {
            try
            {
                GarderieControleur.Instance.AjouterGarderie(garderieDTO);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Permet de modifier une garderie existante
        /// </summary>
        /// <param name="garderieDTO">La garderie modifié</param>
        [Route("Garderie/ModifierGarderie")]
        [HttpPost]
        public void ModifierGarderie([FromBody] GarderieDTO garderieDTO)
        {
            try
            {
                GarderieControleur.Instance.ModifierGarderie(garderieDTO);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Permet de supprimer une garderie
        /// </summary>
        /// <param name="nomGarderie">Le nom de la garderie à supprimer</param>
        [Route("Garderie/SupprimerGarderie")]
        [HttpPost]
        public void SupprimerGarderie([FromQuery] string nomGarderie)
        {
            try
            {
                GarderieControleur.Instance.SupprimerGarderie(nomGarderie);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Supprimer toutes les garderies existante dans la base de données
        /// </summary>
        [Route("Garderie/ViderListeGarderie")]
        [HttpPost]
        public void ViderListeGarderie()
        {
            try
            {
                GarderieControleur.Instance.ViderListeGarderie();
            }
            catch (Exception)
            {
            }
        }
    }
}
