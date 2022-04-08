using API_PROJET_GARDERIE.Logics.DAOs;
using API_PROJET_GARDERIE.Logics.DTOs;
using API_PROJET_GARDERIE.Logics.Modeles;
using System;
using System.Collections.Generic;

namespace API_PROJET_GARDERIE.Logics.Controleurs
{
    public class CommerceControleur
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant l'instance unique de la classe CommerceControleur.
        /// </summary>
        private static CommerceControleur instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static CommerceControleur Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new CommerceControleur();
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
        private CommerceControleur() { }

        #endregion Controleurs

        #region MethodesServices

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des garderies.
        /// </summary>
        /// <returns>Liste contenant les département.</returns>
        public List<CommerceDTO> ObtenirListeCommerce()
        {
            List<CommerceDTO> listeCommerceDTO = CommerceRepository.Instance.ObtenirListeCommerce();
            List<CommerceModel> listeCommerce = new List<CommerceModel>();
            foreach (CommerceDTO commerce in listeCommerceDTO)
            {
                listeCommerce.Add(new CommerceModel(commerce.Description, commerce.Adresse, commerce.Telephone));
            }

            if (listeCommerce.Count == listeCommerceDTO.Count)
                return listeCommerceDTO;
            else
                throw new Exception("Erreur lors du chargement des Garderies, problème avec l'intégrité des données de la base de données.");
        }
        #endregion
    }
}