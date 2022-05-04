using API_PROJET_GARDERIE.Logics.Modeles;

/// <summary>
/// Namespace pour les objets de type DTO.
/// </summary>
namespace API_PROJET_GARDERIE.Logics.DTOs
{
    /// <summary>
    /// Classe de DTO pour l'educateur.
    /// </summary>
    public class EducateurDTO
    {
        #region Proprietes
        /// <summary>
        /// Propriété représentant le nom de l'educateur
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Propriété représentant le prenom de l'educateur
        /// </summary>
        public string Prenom { get; set; }
        /// <summary>
        /// Propriété représentant la date de naissance de l'educateur
        /// </summary>
        public string DateNaissance { get; set; }
        /// <summary>
        /// Propriété représentant l'adresse de l'educateur
        /// </summary>
        public string Adresse { get; set; }
        /// <summary>
        /// Propriété représentant la ville de l'educateur
        /// </summary>
        public string Ville { get; set; }
        /// <summary>
        /// Propriété représentant la province de l'educateur
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// Propriété représentant le numéro de téléphone de l'educateur
        /// </summary>
        public string Telephone { get; set; }


        #endregion Proprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public EducateurDTO()
        {
            Nom = "";
            Prenom = "";
            DateNaissance = "";
            Adresse = "";
            Ville = "";
            Province = "";
            Telephone = "";
        }

        /// <summary>
        /// Constructeur paramétré
        /// </summary>
        /// <param name="unNom">Le nom de l'educateur</param>
        /// <param name="unPrenom">Le prenom de l'educateur</param>
        /// <param name="uneDateNaissance">La date de naissance de l'educateur</param>
        /// <param name="uneAdresse">L'adresse de l'educateur</param>
        /// <param name="uneVille">La ville de l'educateur</param>
        /// <param name="uneProvince">La province de l'educateur</param>
        /// <param name="unTelephone">Le telephone de l'educateur</param>
        public EducateurDTO(string unNom = "", string unPrenom = "", string uneDateNaissance = "", string uneAdresse = "", string uneVille = "", string uneProvince = "", string unTelephone = "")
        {
            Nom = unNom;
            Prenom = unPrenom;
            DateNaissance = uneDateNaissance;
            Adresse = uneAdresse;
            Ville = uneVille;
            Province = uneProvince;
            Telephone = unTelephone;
        }

        /// <summary>
        /// Constructeur avec le modèle EducateurModel en paramètre.
        /// </summary>
        /// <param name="unEnfant">L'objet du modèle educateur.</param>
        public EducateurDTO(EducateurModel unEducateur)
        {
            Nom = unEducateur.Nom;
            Prenom = unEducateur.Prenom;
            DateNaissance = unEducateur.DateNaissance;
            Adresse = unEducateur.Adresse;
            Ville = unEducateur.Ville;
            Province = unEducateur.Province;
            Telephone = unEducateur.Telephone;
        }

        #endregion Constructeurs
    }
}
