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
    public class EnfantControleur
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant l'instance unique de la classe EnfantControleur.
        /// </summary>
        private static EnfantControleur instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static EnfantControleur Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new EnfantControleur();
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
        private EnfantControleur() {}

        #endregion Controleurs

        #region MethodesServices

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des enfants.
        /// </summary>
        /// <returns>Liste contenant les enfants.</returns>
        public List<EnfantDTO> ObtenirListeEnfant()
        {
            List<EnfantDTO> listeEnfantDTO = EnfantRepository.Instance.ObtenirListeEnfant();
            List<EnfantModel> listeEnfant = new List<EnfantModel>();
            foreach (EnfantDTO enfant in listeEnfantDTO)
            {
                listeEnfant.Add(new EnfantModel(enfant.Nom, enfant.Prenom, enfant.DateNaissance, enfant.Adresse, enfant.Ville, enfant.Province, enfant.Telephone));
            }

            if (listeEnfant.Count == listeEnfantDTO.Count)
                return listeEnfantDTO;
            else
                throw new Exception("Erreur lors du chargement des enfants, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir l'enfant.
        /// </summary>
        /// <param name="nomEnfant">Le nom de l'enfant.</param>
        /// <param name="prenomEnfant">Le prenom de l'enfant.</param>
        /// <param name="dateNaissanceEnfant">La date de naissance de l'enfant.</param>
        /// <returns>Le DTO de l'enfant.</returns>
        public EnfantDTO ObtenirEnfant(string nomEnfant, string prenomEnfant, string dateNaissanceEnfant)
        {
            EnfantDTO enfantDTO = EnfantRepository.Instance.ObtenirEnfant(nomEnfant, prenomEnfant, dateNaissanceEnfant);
            EnfantModel enfant = new EnfantModel(enfantDTO.Nom, enfantDTO.Prenom, enfantDTO.DateNaissance, enfantDTO.Adresse, enfantDTO.Ville, enfantDTO.Province, enfantDTO.Telephone);
            return new EnfantDTO(enfant);
        }

        /// <summary>
        /// Méthode de service permettant de créer l'enfant.
        /// </summary>
        /// <param name="enfantDTO">Le DTO de l'enfant.</param>
        public void AjouterEnfant(EnfantDTO enfantDTO)
        {
            bool OK = false;
            try
            {
                EnfantRepository.Instance.ObtenirIDEnfant(enfantDTO.Nom, enfantDTO.Prenom, enfantDTO.DateNaissance);
            }
            catch (Exception)
            {
                OK = true;
            }

            if (OK)
            {
                EnfantModel unEnfant = new EnfantModel(enfantDTO.Nom, enfantDTO.Prenom, enfantDTO.DateNaissance, enfantDTO.Adresse, enfantDTO.Ville, enfantDTO.Province, enfantDTO.Telephone);
                EnfantRepository.Instance.AjouterEnfant(enfantDTO);
            }
            else
                throw new Exception("Erreur - L'enfant est déjà existant.");

        }

        #endregion MethodesServices
    }
}
