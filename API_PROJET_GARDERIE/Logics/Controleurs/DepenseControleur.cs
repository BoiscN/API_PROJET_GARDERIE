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
    public class DepenseControleur
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant l'instance unique de la classe DepenseControleur.
        /// </summary>
        private static DepenseControleur instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static DepenseControleur Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new DepenseControleur();
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
        private DepenseControleur() {}

        #endregion Controleurs

        #region MethodesServices

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des dépenses selon la garderie.
        /// </summary>
        /// <returns>Liste contenant les dépenses.</returns>
        public List<DepenseDTO> ObtenirListeDepense(string nomGarderie)
        {
            List<DepenseDTO> listeDepenseDTO = DepenseRepository.Instance.ObtenirListeDepense(nomGarderie);
            List<DepenseModel> listeDepense = new List<DepenseModel>();
            foreach (DepenseDTO depense in listeDepenseDTO)
            {
                listeDepense.Add(new DepenseModel(depense.DateTemps, depense.Montant, depense.categorieDepenseDTO.Description, depense.categorieDepenseDTO.Pourcentage, depense.commerceDTO.Description, depense.commerceDTO.Adresse, depense.commerceDTO.Telephone));
            }

            listeDepenseDTO.Clear();

            foreach (DepenseModel depense in listeDepense)
            {
                listeDepenseDTO.Add(new DepenseDTO(depense));
            }

            if (listeDepense.Count == listeDepenseDTO.Count)
                return listeDepenseDTO;
            else
                throw new Exception("Erreur lors du chargement des Dépenses, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant de créer la dépense.
        /// </summary>
        /// <param name="depenseDTO">Le DTO de la dépense.</param>
        public void AjouterDepense(string nomGarderie, DepenseDTO depenseDTO)
        {
            GarderieDTO garderieDTO = GarderieRepository.Instance.ObtenirGarderie(nomGarderie);
            GarderieModel garderie = new GarderieModel(garderieDTO.Nom, garderieDTO.Adresse, garderieDTO.Ville, garderieDTO.Province, garderieDTO.Telephone);
            List<DepenseDTO> listeDepense = DepenseRepository.Instance.ObtenirListeDepense(nomGarderie);
            foreach (DepenseDTO uneDepenseDTO in listeDepense)
            {
                garderie.AjouterDepense(new DepenseModel(uneDepenseDTO.DateTemps, uneDepenseDTO.Montant));
            }

            garderie.AjouterDepense(new DepenseModel(depenseDTO.DateTemps, depenseDTO.Montant));

            DepenseRepository.Instance.AjouterDepense(nomGarderie, depenseDTO);
        }

        #endregion MethodesServices
    }
}
