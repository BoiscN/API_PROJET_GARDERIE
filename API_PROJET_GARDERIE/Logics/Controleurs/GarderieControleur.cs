using System;
using System.Collections.Generic;
using API_PROJET_GARDERIE.Logics.Modeles;
using API_PROJET_GARDERIE.Logics.DTOs;
using API_PROJET_GARDERIE.Logics.DAOs;

/// <summary>
/// Namespace pour les classes de type Controleur.
/// </summary>
namespace API_PROJET_GARDERIE.Logics.Controleurs
{
    /// <summary>
    /// Classe représentant le controleur de l'application.
    /// </summary>
    public class GarderieControleur
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant l'instance unique de la classe GarderieControleur.
        /// </summary>
        private static GarderieControleur instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static GarderieControleur Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new GarderieControleur();
                }
                //...on retourne l'instance unique.
                return instance;
            }
        }

        #endregion AttributsProprietes

        #region Controleurs

        /// <summary>
        /// Constructeur par défaut de la classe.
        /// </summary>
        private GarderieControleur() {}

        #endregion Controleurs

        #region MethodesServices

        #region MethodesGarderie

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des garderies.
        /// </summary>
        /// <returns>Liste contenant les garderies.</returns>
        public List<GarderieDTO> ObtenirListeGarderie()
        {
            List<GarderieDTO> listeGarderieDTO = GarderieRepository.Instance.ObtenirListeGarderie();
            List<GarderieModel> listeGarderie = new List<GarderieModel>();
            foreach (GarderieDTO garderie in listeGarderieDTO)
            {
                listeGarderie.Add(new GarderieModel(garderie.Nom, garderie.Adresse, garderie.Ville, garderie.Province, garderie.Telephone));
            }

            if (listeGarderie.Count == listeGarderieDTO.Count)
                return listeGarderieDTO;
            else
                throw new Exception("Erreur lors du chargement des Garderies, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir la Garderie.
        /// </summary>
        /// <param name="nomGarderie">Le nom de la garderie.</param>
        /// <returns>Le DTO de la Garderie.</returns>
        public GarderieDTO ObtenirGarderie(string nomGarderie)
        {
            GarderieDTO garderieDTO = GarderieRepository.Instance.ObtenirGarderie(nomGarderie);
            GarderieModel garderie = new GarderieModel(garderieDTO.Nom, garderieDTO.Adresse, garderieDTO.Ville, garderieDTO.Province, garderieDTO.Telephone);
            return new GarderieDTO(garderie);
        }

        /// <summary>
        /// Méthode de service permettant de créer la Garderie.
        /// </summary>
        /// <param name="garderieDTO">Le DTO de la Garderie.</param>
        public void AjouterGarderie(GarderieDTO garderieDTO)
        {
            bool OK = false;
            try
            {
                GarderieRepository.Instance.ObtenirIDGarderie(garderieDTO.Nom);
            }
            catch (Exception)
            {
                OK = true;
            }

            if (OK)
            {
                GarderieModel uneGarderie = new GarderieModel(garderieDTO.Nom, garderieDTO.Adresse, garderieDTO.Ville, garderieDTO.Province, garderieDTO.Telephone);
                GarderieRepository.Instance.AjouterGarderie(garderieDTO);
            }
            else
                throw new Exception("Erreur - La Garderie est déjà existant.");

        }

        /// <summary>
        /// Méthode de service permettant de modifier la Garderie.
        /// </summary>
        /// <param name="garderieDTO">Le DTO de la Garderie.</param>
        public void ModifierGarderie(GarderieDTO garderieDTO)
        {
            GarderieDTO garderieDTOBD = ObtenirGarderie(garderieDTO.Nom);
            GarderieModel garderieBD = new GarderieModel(garderieDTOBD.Nom, garderieDTOBD.Adresse, garderieDTOBD.Ville, garderieDTOBD.Province, garderieDTOBD.Telephone);

            if (garderieDTO.Adresse != garderieBD.Adresse || garderieDTO.Ville != garderieBD.Ville || garderieDTO.Province != garderieBD.Province || garderieDTO.Telephone != garderieBD.Telephone)
                GarderieRepository.Instance.ModifierGarderie(garderieDTO);
            else
                throw new Exception("Erreur - Veuillez modifier au moins une valeur.");
        }

        /// <summary>
        /// Méthode de service permettant de supprimer la Garderie.
        /// </summary>
        /// <param name="nomGarderie">Le nom de la Garderie.</param>
        public void SupprimerGarderie(string nomGarderie)
        {
            GarderieDTO garderieDTOBD = ObtenirGarderie(nomGarderie);
            GarderieRepository.Instance.SupprimerGarderie(garderieDTOBD);
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des Garderies.
        /// </summary>
        public void ViderListeGarderie()
        {
            if (ObtenirListeGarderie().Count == 0)
                throw new Exception("Erreur - La liste des Garderies est déjà vide.");
            GarderieRepository.Instance.ViderListeGarderie();
        }

        #endregion MethodesGarderie

        #endregion MethodesServices
    }
}
