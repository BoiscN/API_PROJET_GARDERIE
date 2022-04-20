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

        /// <summary>
        /// Méthode de service permettant d'obtenir le Commerce.
        /// </summary>
        /// <param name="commerceDTO">Le commerce.</param>
        /// <returns>Le DTO du commerce.</returns>
        public CommerceDTO ObtenirCommerce(CommerceDTO commerceDTO)
        {
            CommerceDTO unCommerceDTO = CommerceRepository.Instance.ObtenirCommerce(commerceDTO.Description);
            CommerceModel commerce = new CommerceModel(unCommerceDTO.Description, unCommerceDTO.Adresse, unCommerceDTO.Telephone);
            return new CommerceDTO(commerce);
        }

        /// <summary>
        /// Méthode de service permettant de créer le Commerce.
        /// </summary>
        /// <param name="commerceDTO">Le DTO du commerce.</param>
        public void AjouterCommerce(CommerceDTO commerceDTO)
        {
            bool OK = false;
            try
            {
                CommerceRepository.Instance.ObtenirIDCommerce(commerceDTO.Description);
            }
            catch (Exception)
            {
                OK = true;
            }

            if (OK)
            {
                CommerceModel unCommerce = new CommerceModel(commerceDTO.Description, commerceDTO.Adresse, commerceDTO.Telephone);
                CommerceRepository.Instance.AjouterCommerce(commerceDTO);
            }
            else
                throw new Exception("Erreur - Le commerce est déjà existant.");

        }

        /// <summary>
        /// Méthode de service permettant de modifier le Commerce.
        /// </summary>
        /// <param name="commerceDTO">Le DTO du commerce.</param>
        public void ModifierCommerce(CommerceDTO commerceDTO)
        {
            CommerceDTO commerceDTOBD = ObtenirCommerce(commerceDTO);
            CommerceModel commerceBD = new CommerceModel(commerceDTOBD.Description, commerceDTOBD.Adresse, commerceDTOBD.Telephone);

            if (commerceDTO.Adresse != commerceBD.Adresse || commerceDTO.Telephone != commerceBD.Telephone)
                CommerceRepository.Instance.ModifierCommerce(commerceDTO);
            else
                throw new Exception("Erreur - Veuillez modifier au moins une valeur.");
        }

        /// <summary>
        /// Méthode de service permettant de supprimer le commerce.
        /// </summary>
        /// <param name="nomCommerce">Le nom de la Commerce.</param>
        public void SupprimerCommerce(string nomCommerce)
        {
            CommerceDTO CommerceDTOBD = ObtenirCommerce(new CommerceDTO(nomCommerce));
            CommerceRepository.Instance.SupprimerCommerce(CommerceDTOBD);
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des commerces.
        /// </summary>
        public void ViderListeCommerce()
        {
            if (ObtenirListeCommerce().Count == 0)
                throw new Exception("Erreur - La liste des Commerces est déjà vide.");
            CommerceRepository.Instance.ViderListeCommerce();
        }

        #endregion
    }
}