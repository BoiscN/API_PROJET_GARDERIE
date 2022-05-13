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
    public class PresenceControleur
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant l'instance unique de la classe PresenceControleur.
        /// </summary>
        private static PresenceControleur instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static PresenceControleur Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new PresenceControleur();
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
        private PresenceControleur() {}

        #endregion Controleurs

        #region MethodesServices

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des présences.
        /// </summary>
        /// <param name="nomGarderie">Le nom de la garderie.</param>
        /// <returns>Liste contenant les présences.</returns>
        public List<PresenceDTO> ObtenirListePresence(string nomGarderie)
        {
            List<PresenceDTO> listePresenceDTO = PresenceRepository.Instance.ObtenirListePresence(nomGarderie);
            List<PresenceModel> listePresence = new List<PresenceModel>();
            foreach (PresenceDTO presence in listePresenceDTO)
            {
                listePresence.Add(new PresenceModel(presence.DateTemps, presence.Garderie.Nom, presence.Garderie.Adresse, presence.Garderie.Ville, presence.Garderie.Province, presence.Garderie.Telephone, presence.Enfant.Nom, presence.Enfant.Prenom, presence.Enfant.DateNaissance, presence.Enfant.Adresse, presence.Enfant.Ville, presence.Enfant.Province, presence.Enfant.Telephone, presence.Educateur.Nom, presence.Educateur.Prenom, presence.Educateur.DateNaissance, presence.Educateur.Adresse, presence.Educateur.Ville, presence.Educateur.Province, presence.Educateur.Telephone));
            }

            if (listePresence.Count == listePresenceDTO.Count)
                return listePresenceDTO;
            else
                throw new Exception("Erreur lors du chargement des présences, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir la présence.
        /// </summary>
        /// <param name="dateTemps">La date de la présence.</param>
        /// <param name="nomEnfant">Le nom de l'enfant de la présence.</param>
        /// <param name="prenomEnfant">Le prenom de l'enfant de la présence.</param>
        /// <param name="dateNaissanceEnfant">La date de naissance de l'enfant de la présence.</param>
        /// <returns>Le DTO de la présence.</returns>
        public PresenceDTO ObtenirPresence(string dateTemps, string nomEnfant, string prenomEnfant, string dateNaissanceEnfant)
        {
            PresenceDTO presenceDTO = PresenceRepository.Instance.ObtenirPresence(dateTemps, nomEnfant, prenomEnfant, dateNaissanceEnfant);
            PresenceModel presence = new PresenceModel(presenceDTO.DateTemps, presenceDTO.Garderie.Nom, presenceDTO.Garderie.Adresse, presenceDTO.Garderie.Ville, presenceDTO.Garderie.Province, presenceDTO.Garderie.Telephone, presenceDTO.Enfant.Nom, presenceDTO.Enfant.Prenom, presenceDTO.Enfant.DateNaissance, presenceDTO.Enfant.Adresse, presenceDTO.Enfant.Ville, presenceDTO.Enfant.Province, presenceDTO.Enfant.Telephone, presenceDTO.Educateur.Nom, presenceDTO.Educateur.Prenom, presenceDTO.Educateur.DateNaissance, presenceDTO.Educateur.Adresse, presenceDTO.Educateur.Ville, presenceDTO.Educateur.Province, presenceDTO.Educateur.Telephone);
            return new PresenceDTO(presence);
        }

        /// <summary>
        /// Méthode de service permettant de créer la présence.
        /// </summary>
        /// <param name="presenceDTO">Le DTO de la presence.</param>
        public void AjouterPresence(PresenceDTO presenceDTO)
        {
            bool OK = false;
            try
            {
                PresenceRepository.Instance.ObtenirIDPresence(presenceDTO.DateTemps, presenceDTO.Enfant.Nom, presenceDTO.Enfant.Prenom, presenceDTO.Enfant.DateNaissance);
            }
            catch (Exception)
            {
                OK = true;
            }

            if (OK)
            {
                PresenceModel unePresence = new PresenceModel(presenceDTO.DateTemps, presenceDTO.Garderie.Nom, presenceDTO.Garderie.Adresse, presenceDTO.Garderie.Ville, presenceDTO.Garderie.Province, presenceDTO.Garderie.Telephone, presenceDTO.Enfant.Nom, presenceDTO.Enfant.Prenom, presenceDTO.Enfant.DateNaissance, presenceDTO.Enfant.Adresse, presenceDTO.Enfant.Ville, presenceDTO.Enfant.Province, presenceDTO.Enfant.Telephone, presenceDTO.Educateur.Nom, presenceDTO.Educateur.Prenom, presenceDTO.Educateur.DateNaissance, presenceDTO.Educateur.Adresse, presenceDTO.Educateur.Ville, presenceDTO.Educateur.Province, presenceDTO.Educateur.Telephone);
                PresenceRepository.Instance.AjouterPresence(presenceDTO);
            }
            else
                throw new Exception("Erreur - La présence est déjà existante.");

        }
        /// <summary>
        /// Méthode service qui permet d'obtenir la liste des presence en fonction
        /// du nom de la garderie et la date de présence
        /// </summary>
        /// <param name="nomGarderie"></param>
        /// <param name="dateTemps"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<PresenceDTO> ObtenirListePresenceDate(string nomGarderie, string dateTemps)
        {
            List<PresenceDTO> listePresenceDTO = PresenceRepository.Instance.ObtenirListePresenceDate(nomGarderie, dateTemps);
            List<PresenceModel> listePresence = new List<PresenceModel>();
            foreach (PresenceDTO presence in listePresenceDTO)
            {
                listePresence.Add(new PresenceModel(presence.DateTemps, presence.Garderie.Nom, presence.Garderie.Adresse, presence.Garderie.Ville, presence.Garderie.Province, presence.Garderie.Telephone, presence.Enfant.Nom, presence.Enfant.Prenom, presence.Enfant.DateNaissance, presence.Enfant.Adresse, presence.Enfant.Ville, presence.Enfant.Province, presence.Enfant.Telephone, presence.Educateur.Nom, presence.Educateur.Prenom, presence.Educateur.DateNaissance, presence.Educateur.Adresse, presence.Educateur.Ville, presence.Educateur.Province, presence.Educateur.Telephone));
            }

            if (listePresence.Count == listePresenceDTO.Count)
                return listePresenceDTO;
            else
                throw new Exception("Erreur lors du chargement des présences, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode service qui permet de calculer le revenu d'une garderie par année
        /// </summary>
        /// <param name="nomGarderie"></param>
        /// <param name="dateTemps"></param>
        /// <returns></returns>
        public double ObtenirRevenue(string nomGarderie, string dateTemps)
        {
            List<PresenceDTO> listePresenceDTO = PresenceRepository.Instance.ObtenirListePresenceDate(nomGarderie, dateTemps);
            List<PresenceModel> listePresence = new List<PresenceModel>();
            foreach (PresenceDTO presence in listePresenceDTO)
            {
                listePresence.Add(new PresenceModel(presence.DateTemps, presence.Garderie.Nom, presence.Garderie.Adresse, presence.Garderie.Ville, presence.Garderie.Province, presence.Garderie.Telephone, presence.Enfant.Nom, presence.Enfant.Prenom, presence.Enfant.DateNaissance, presence.Enfant.Adresse, presence.Enfant.Ville, presence.Enfant.Province, presence.Enfant.Telephone, presence.Educateur.Nom, presence.Educateur.Prenom, presence.Educateur.DateNaissance, presence.Educateur.Adresse, presence.Educateur.Ville, presence.Educateur.Province, presence.Educateur.Telephone));
            }
            return (listePresenceDTO.Count * 8);

        }

        /// <summary>
        /// Méthode de service qui permet d'obtenir de calculer les dépenses d'une garderie
        /// </summary>
        /// <param name="nomGarderie"></param>
        /// <param name="dateTemps"></param>
        /// <returns></returns>
        public double CalculerDepensesGarderie(string nomGarderie, string dateTemps)
        {
            double depenseAdmissible = 0;

            List<DepenseDTO> listeDepenseAdmissibles = new List<DepenseDTO>();
            listeDepenseAdmissibles = DepenseControleur.Instance.ObtenirListeDepense(nomGarderie);
            foreach (DepenseDTO depense in listeDepenseAdmissibles)
            {
                depenseAdmissible += depense.MontantAdmissible;
            }

            int nombreDePresenceEducateur = PresenceRepository.Instance.ObtenirNombreEducateur(nomGarderie, dateTemps);
            double montantDepenseEducateur = (nombreDePresenceEducateur * 8) * 18;

            double montantTotalDepenseGarderie = depenseAdmissible + montantDepenseEducateur;

            return (montantTotalDepenseGarderie);
        }
        /// <summary>
        /// Méthode de service qui permet de calculer le profit d'une garderie
        /// </summary>
        /// <param name="nomGarderie"></param>
        /// <param name="dateTemps"></param>
        /// <returns></returns>
        public double CaluleProfit(string nomGarderie, string dateTemps)
        {
            double depense = CalculerDepensesGarderie(nomGarderie, dateTemps);
            double revenu = ObtenirRevenue(nomGarderie, dateTemps);
            return (revenu - depense);
        }

        #endregion MethodesServices
    }
}
