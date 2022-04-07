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
        public List<CategorieDepenseDTO> ObtenirListeCommerce()
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

        #endregion
    }
}