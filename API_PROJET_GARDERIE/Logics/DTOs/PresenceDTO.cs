using API_PROJET_GARDERIE.Logics.Modeles;

/// <summary>
/// Namespace pour les objets de type DTO.
/// </summary>
namespace API_PROJET_GARDERIE.Logics.DTOs
{
    /// <summary>
    /// Classe de DTO pour la Presence.
    /// </summary>
    public class PresenceDTO
    {
        #region Proprietes
        /// <summary>
        /// Propriété représentant la date de la presence.
        /// </summary>
        public string DateTemps { get; set; }

        /// <summary>
        /// Propriété représentant la garderie de la présence
        /// </summary>
        public GarderieDTO Garderie { get; set; }

        /// <summary>
        /// Propriété représentant l'enfant de la présence
        /// </summary>
        public EnfantDTO Enfant { get; set; }

        /// <summary>
        /// Propriété représentant l'educateur de la présence
        /// </summary>
        public EducateurDTO Educateur { get; set; }

        #endregion Proprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public PresenceDTO()
        {
            DateTemps = "";
            Garderie = new GarderieDTO();
            Enfant = new EnfantDTO();
        }

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="uneDateTemps">La date de la présence</param>
        /// <param name="nomGarderie">Le nom de la garderie</param>
        /// <param name="adresseGarderie">L'adresse de la garderie</param>
        /// <param name="villeGarderie">La ville de la garderie</param>
        /// <param name="provinceGarderie">La province de la garerie</param>
        /// <param name="telephoneGarderie">Le telephone de la garderie</param>
        /// <param name="nomEnfant">Le nom de l'enfant</param>
        /// <param name="prenomEnfant">Le prenom de l'enfant</param>
        /// <param name="dateNaissanceEnfant">La date de naissance de l'enfant</param>
        /// <param name="adresseEnfant">L'adresse de l'enfant</param>
        /// <param name="villeEnfant">La ville de l'enfant</param>
        /// <param name="provinceEnfant">La province de l'enfant</param>
        /// <param name="telephoneEnfant">Le telephone de l'enfant</param>
        /// <param name="nomEducateur">Le nom de l'educateur</param>
        /// <param name="prenomEducateur">Le prenom de l'educateur</param>
        /// <param name="dateNaissanceEducateur">La date de naissance de l'educateur</param>
        /// <param name="adresseEducateur">L'adresse de l'educateur</param>
        /// <param name="villeEducateur">La ville de l'educateur</param>
        /// <param name="provinceEducateur">La province de l'educateur</param>
        /// <param name="telephoneEducateur">Le telephone de l'educateur</param>
        public PresenceDTO(
            string uneDateTemps = "",
            string nomGarderie = "",
            string adresseGarderie = "",
            string villeGarderie = "",
            string provinceGarderie = "",
            string telephoneGarderie = "",
            string nomEnfant = "",
            string prenomEnfant = "",
            string dateNaissanceEnfant = "",
            string adresseEnfant = "",
            string villeEnfant = "",
            string provinceEnfant = "",
            string telephoneEnfant = "",
            string nomEducateur = "",
            string prenomEducateur = "",
            string dateNaissanceEducateur = "",
            string adresseEducateur = "",
            string villeEducateur = "",
            string provinceEducateur = "",
            string telephoneEducateur = "")
        {
            DateTemps = uneDateTemps;
            Garderie = new GarderieDTO(nomGarderie, adresseGarderie, villeGarderie, provinceGarderie, telephoneGarderie);
            Enfant = new EnfantDTO(nomEnfant, prenomEnfant, dateNaissanceEnfant, adresseEnfant, villeEnfant, provinceEnfant, telephoneEnfant);
            Educateur = new EducateurDTO(nomEducateur, prenomEducateur, dateNaissanceEducateur, adresseEducateur, villeEducateur, provinceEducateur, telephoneEducateur);
        }

        /// <summary>
        /// Constructeur avec le modèle PresenceModel en paramètre.
        /// </summary>
        /// <param name="unePresence">L'objet du modèle Presence.</param>
        public PresenceDTO(PresenceModel unePresence)
        {
            DateTemps = unePresence.DateTemps;
            Garderie = new GarderieDTO(unePresence.Garderie);
            Enfant = new EnfantDTO(unePresence.Enfant);
            Educateur = new EducateurDTO(unePresence.Educateur);
        }

        #endregion Constructeurs
    }
}
