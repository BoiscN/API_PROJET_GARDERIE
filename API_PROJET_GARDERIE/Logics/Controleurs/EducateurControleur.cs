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
    public class EducateurControleur
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant l'instance unique de la classe EducateurControleur.
        /// </summary>
        private static EducateurControleur instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static EducateurControleur Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new EducateurControleur();
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
        private EducateurControleur() {}

        #endregion Controleurs

        #region MethodesServices

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des educateurs.
        /// </summary>
        /// <returns>Liste contenant les educateurs.</returns>
        public List<EducateurDTO> ObtenirListeEducateur()
        {
            List<EducateurDTO> listeEducateurDTO = EducateurRepository.Instance.ObtenirListeEducateur();
            List<EducateurModel> listeEducateur = new List<EducateurModel>();
            foreach (EducateurDTO educateur in listeEducateurDTO)
            {
                listeEducateur.Add(new EducateurModel(educateur.Nom, educateur.Prenom, educateur.DateNaissance, educateur.Adresse, educateur.Ville, educateur.Province, educateur.Telephone));
            }

            if (listeEducateur.Count == listeEducateurDTO.Count)
                return listeEducateurDTO;
            else
                throw new Exception("Erreur lors du chargement des educateurs, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir l'educateur.
        /// </summary>
        /// <param name="nomEducateur">Le nom de l'educateur.</param>
        /// <param name="prenomEducateur">Le prenom de l'educateur.</param>
        /// <param name="dateNaissanceEducateur">La date de naissance de l'educateur.</param>
        /// <returns>Le DTO de l'educateur.</returns>
        public EducateurDTO ObtenirEducateur(string nomEducateur, string prenomEducateur, string dateNaissanceEducateur)
        {
            EducateurDTO educateurDTO = EducateurRepository.Instance.ObtenirEducateur(nomEducateur, prenomEducateur, dateNaissanceEducateur);
            EducateurModel educateur = new EducateurModel(educateurDTO.Nom, educateurDTO.Prenom, educateurDTO.DateNaissance, educateurDTO.Adresse, educateurDTO.Ville, educateurDTO.Province, educateurDTO.Telephone);
            return new EducateurDTO(educateur);
        }

        /// <summary>
        /// Méthode de service permettant de créer l'educateur.
        /// </summary>
        /// <param name="educateurDTO">Le DTO de l'educateur.</param>
        public void AjouterEducateur(EducateurDTO educateurDTO)
        {
            bool OK = false;
            try
            {
                EducateurRepository.Instance.ObtenirIDEducateur(educateurDTO.Nom, educateurDTO.Prenom, educateurDTO.DateNaissance);
            }
            catch (Exception)
            {
                OK = true;
            }

            if (OK)
            {
                EducateurModel unEducateur = new EducateurModel(educateurDTO.Nom, educateurDTO.Prenom, educateurDTO.DateNaissance, educateurDTO.Adresse, educateurDTO.Ville, educateurDTO.Province, educateurDTO.Telephone);
                EducateurRepository.Instance.AjouterEducateur(educateurDTO);
            }
            else
                throw new Exception("Erreur - L'educateur est déjà existant.");

        }

        /// <summary>
        /// Méthode de service permettant de modifier l'educateur.
        /// </summary>
        /// <param name="educateurDTO">Le DTO de l'educateur.</param>
        public void ModifierEducateur(EducateurDTO educateurDTO)
        {
            EducateurDTO educateurDTOBD = ObtenirEducateur(educateurDTO.Nom, educateurDTO.Prenom, educateurDTO.DateNaissance);
            EducateurModel educateurBD = new EducateurModel(educateurDTOBD.Nom, educateurDTOBD.Prenom, educateurDTOBD.DateNaissance, educateurDTOBD.Adresse, educateurDTOBD.Ville, educateurDTOBD.Province, educateurDTOBD.Telephone);

            if (educateurDTO.Adresse != educateurBD.Adresse || educateurDTO.Ville != educateurBD.Ville || educateurDTO.Province != educateurBD.Province || educateurDTO.Telephone != educateurBD.Telephone)
                EducateurRepository.Instance.ModifierEducateur(educateurDTO);
            else
                throw new Exception("Erreur - Veuillez modifier au moins une valeur.");
        }

        /// <summary>
        /// Méthode de service permettant de supprimer l'educateur.
        /// </summary>
        /// <param name="nomEducateur">Le nom de l'educateur.</param>
        /// <param name="prenomEducateur">Le prenom de l'educateur.</param>
        /// <param name="dateNaissanceEducateur">La date de naissance de l'educateur.</param>
        public void SupprimerEducateur(string nomEducateur, string prenomEducateur, string dateNaissanceEducateur)
        {
            EducateurDTO educateurDTOBD = ObtenirEducateur(nomEducateur, prenomEducateur, dateNaissanceEducateur);
            EducateurRepository.Instance.SupprimerEducateur(educateurDTOBD);
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des educateurs.
        /// </summary>
        public void ViderListeEducateur()
        {
            if (ObtenirListeEducateur().Count == 0)
                throw new Exception("Erreur - La liste des educateurs est déjà vide.");
            EducateurRepository.Instance.ViderListeEducateur();
        }

        #endregion MethodesServices
    }
}
