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
        /// Méthode de service permettant d'obtenir une dépense.
        /// </summary>
        /// <param name="dateTemps">La date de la dépense. (Informations du Equals nécessaires)</param>
        /// <returns>Le DTO de la dépense désiré.</returns>
        public DepenseDTO ObtenirDepense(string nomGarderie, string dateTemps)
        {
            DepenseDTO depenseDTO = DepenseRepository.Instance.ObtenirDepense(nomGarderie, dateTemps);

            if (depenseDTO.DateTemps.Equals(dateTemps))
                return depenseDTO;
            else
                throw new Exception("Erreur lors de l'obtention de la dépense, problème avec l'intégrité des données de la base de données.");
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

        /// <summary>
        /// Méthode de service permettant de modifier une dépense.
        /// </summary>
        /// <param name="departement">Le DTO du département de l'enseignant.</param>
        /// <param name="enseignant">Le DTO de l'enseignant a modifier.</param>
        public void ModifierDepense(string nomGarderie, DepenseDTO depenseDTO)
        {
            DepenseDTO uneDepenseDTO = ObtenirDepense(nomGarderie, depenseDTO.DateTemps);
            DepenseModel depenseModele = new DepenseModel(uneDepenseDTO.DateTemps, uneDepenseDTO.Montant, uneDepenseDTO.categorieDepenseDTO.Description, uneDepenseDTO.categorieDepenseDTO.Pourcentage, uneDepenseDTO.commerceDTO.Description, uneDepenseDTO.commerceDTO.Adresse, uneDepenseDTO.commerceDTO.Telephone);

            if (depenseDTO.Montant != depenseModele.Montant || uneDepenseDTO.categorieDepenseDTO.Description != depenseModele.categorieDepenseModel.Description || depenseDTO.categorieDepenseDTO.Pourcentage != depenseModele.categorieDepenseModel.Pourcentage || depenseDTO.commerceDTO.Description != depenseModele.commerceModel.Description || depenseDTO.commerceDTO.Adresse != depenseModele.commerceModel.Adresse || depenseDTO.commerceDTO.Telephone != depenseModele.commerceModel.Telephone)
                DepenseRepository.Instance.ModifierDepense(nomGarderie, depenseDTO);
            else
                throw new Exception("Erreur - Veuillez modifier au moins une valeur.");
        }

        /// <summary>
        /// Méthode de service permettant de supprimer une dépense.
        /// </summary>
        /// <param name="nomGarderie">Le nom de la garderie.</param> 
        /// <param name="depenseDTO">Le DTO de la dépense a supprimer.</param>
        public void SupprimerDepense(string nomGarderie, DepenseDTO depenseDTO)
        {
            GarderieDTO garderieDTO = GarderieControleur.Instance.ObtenirGarderie(nomGarderie);
            GarderieModel garderieModel = new GarderieModel(garderieDTO.Nom, garderieDTO.Adresse, garderieDTO.Ville, garderieDTO.Province, garderieDTO.Telephone);

            List<DepenseDTO> listeDepense = DepenseRepository.Instance.ObtenirListeDepense(nomGarderie);
            foreach (DepenseDTO uneDepenseDTO in listeDepense)
            {
                garderieModel.AjouterDepense(new DepenseModel(depenseDTO.DateTemps, depenseDTO.Montant, depenseDTO.categorieDepenseDTO.Description, depenseDTO.categorieDepenseDTO.Pourcentage, depenseDTO.commerceDTO.Description, depenseDTO.commerceDTO.Adresse, depenseDTO.commerceDTO.Telephone));
            }

            garderieModel.SupprimerDepense(new DepenseModel(depenseDTO.DateTemps, depenseDTO.Montant, depenseDTO.categorieDepenseDTO.Description, depenseDTO.categorieDepenseDTO.Pourcentage, depenseDTO.commerceDTO.Description, depenseDTO.commerceDTO.Adresse, depenseDTO.commerceDTO.Telephone));

            DepenseRepository.Instance.SupprimerDepense(nomGarderie, depenseDTO.DateTemps);
        }

        /// <summary>
        /// Méthode de service permettant vider la liste des dépenses d'une Garderie.
        /// </summary>
        /// <param name="nomGarderie">Le nom de la Garderie.</param>
        public void ViderListeDepense(string nomGarderie)
        {
            GarderieDTO garderieDTO = GarderieControleur.Instance.ObtenirGarderie(nomGarderie);
            GarderieModel garderie = new GarderieModel(garderieDTO.Nom, garderieDTO.Adresse, garderieDTO.Ville, garderieDTO.Province, garderieDTO.Telephone);

            List<DepenseDTO> listeDepense = DepenseRepository.Instance.ObtenirListeDepense(nomGarderie);
            foreach (DepenseDTO depenseDTO in listeDepense)
            {
                garderie.AjouterDepense(new DepenseModel(depenseDTO.DateTemps, depenseDTO.Montant, depenseDTO.categorieDepenseDTO.Description, depenseDTO.categorieDepenseDTO.Pourcentage, depenseDTO.commerceDTO.Description, depenseDTO.commerceDTO.Adresse, depenseDTO.commerceDTO.Telephone));
            }

            garderie.ViderListeDepense();

            DepenseRepository.Instance.ViderListeDepense(nomGarderie);
        }

        #endregion MethodesServices
    }
}
