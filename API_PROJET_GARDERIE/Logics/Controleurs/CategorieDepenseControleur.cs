using API_PROJET_GARDERIE.Logics.DAOs;
using API_PROJET_GARDERIE.Logics.DTOs;
using API_PROJET_GARDERIE.Logics.Modeles;
using System;
using System.Collections.Generic;

namespace API_PROJET_GARDERIE.Logics.Controleurs
{
    public class CategorieDepenseControleur
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant l'instance unique de la class CategorieDepenses.
        /// </summary>
        private static CategorieDepenseControleur instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static CategorieDepenseControleur Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new CategorieDepenseControleur();
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
        private CategorieDepenseControleur() { }

        #endregion Controleurs

        #region MethodesServices

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des CategorieDepenses.
        /// </summary>
        /// <returns>Liste contenant les département.</returns>
        public List<CategorieDepenseDTO> ObtenirListeCategorieDepense()
        {
            List<CategorieDepenseDTO> listeCategorieDepenseDTO = CategorieDepenseRepository.Instance.ObtenirListeCategorieDepense();
            List<CategorieDepenseModel> listeCategorieDepense = new List<CategorieDepenseModel>();
            foreach (CategorieDepenseDTO categorieDepense in listeCategorieDepenseDTO)
            {
                listeCategorieDepense.Add(new CategorieDepenseModel(categorieDepense.Description, categorieDepense.Pourcentage));
            }

            if (listeCategorieDepense.Count == listeCategorieDepenseDTO.Count)
                return listeCategorieDepenseDTO;
            else
                throw new Exception("Erreur lors du chargement des CategorieDepenses, problème avec l'intégrité des données de la base de données.");
        }
        /// <summary>
        /// Méthode de service permettant d'obtenir le Commerce.
        /// </summary>
        /// <param name="descriptionCategorieDepense">La description du commerce.</param>
        /// <returns>Le DTO du commerce.</returns>
        public CategorieDepenseDTO ObtenirCategorieDepense(string descriptionCategorieDepense)
        {
            CategorieDepenseDTO unCategorieDepenseDTO = CategorieDepenseRepository.Instance.ObtenirCategorieDepense(descriptionCategorieDepense);
            CategorieDepenseModel categorieDepense = new CategorieDepenseModel(unCategorieDepenseDTO.Description, unCategorieDepenseDTO.Pourcentage);
            return new CategorieDepenseDTO(categorieDepense);
        }

        /// <summary>
        /// Méthode de service permettant de créer le Commerce.
        /// </summary>
        /// <param name="commerceDTO">Le DTO du commerce.</param>
        public void AjouterCategorieDepense(CategorieDepenseDTO categorieDepenseDTO)
        {
            bool OK = false;
            try
            {
                CategorieDepenseRepository.Instance.ObtenirIDCategorieDepense(categorieDepenseDTO.Description);
            }
            catch (Exception)
            {
                OK = true;
            }

            if (OK)
            {
                CategorieDepenseModel uneCategorieDepense = new CategorieDepenseModel(categorieDepenseDTO.Description, categorieDepenseDTO.Pourcentage);
                CategorieDepenseRepository.Instance.AjouterCategorieDepense(categorieDepenseDTO);
            }
            else
                throw new Exception("Erreur - La categorieDepense est déjà existant.");

        }
        /// <summary>
        /// Méthode de service permettant de modifier la categorieDepense.
        /// </summary>
        /// <param name="categorieDepenseDTO">Le DTO du commerce.</param>
        public void ModifierCategorieDepense(CategorieDepenseDTO categorieDepenseDTO)
        {
            CategorieDepenseDTO categorieDepenseDTOBD = ObtenirCategorieDepense(categorieDepenseDTO.Description);
            CategorieDepenseModel categorieDepenseBD = new CategorieDepenseModel(categorieDepenseDTOBD.Description, categorieDepenseDTOBD.Pourcentage);

            if (categorieDepenseDTO.Pourcentage != categorieDepenseBD.Pourcentage)
                CategorieDepenseRepository.Instance.ModifierCategorieDepense(categorieDepenseDTO);
            else
                throw new Exception("Erreur - Veuillez modifier au moins une valeur.");
        }

        /// <summary>
        /// Méthode de service permettant de supprimer la categorieDepense.
        /// </summary>
        /// <param name="descriptionCategorieDepense">Le nom de la Commerce.</param>
        public void SupprimerCategorieDepense(string descriptionCategorieDepense)
        {
            CategorieDepenseDTO categorieDepenseDTOBD = ObtenirCategorieDepense(descriptionCategorieDepense);
            CategorieDepenseRepository.Instance.SupprimerCategorieDepense(categorieDepenseDTOBD);
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des categoriesDepenses.
        /// </summary>
        public void ViderListeCategorieDepense()
        {
            if (ObtenirListeCategorieDepense().Count == 0)
                throw new Exception("Erreur - La liste des CategoriesDepenses est déjà vide.");
            CategorieDepenseRepository.Instance.ViderListeCategorieDepense();
        }

        #endregion


    }
}