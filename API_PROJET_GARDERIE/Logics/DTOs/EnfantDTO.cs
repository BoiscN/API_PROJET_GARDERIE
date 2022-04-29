using API_PROJET_GARDERIE.Logics.Modeles;

/// <summary>
/// Namespace pour les objets de type DTO.
/// </summary>
namespace API_PROJET_GARDERIE.Logics.DTOs
{
    /// <summary>
    /// Classe de DTO pour l'enfant.
    /// </summary>
    public class EnfantDTO
    {
        #region Proprietes
        /// <summary>
        /// Propriété représentant le nom de l'enfant
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Propriété représentant le prenom de l'enfant
        /// </summary>
        public string Prenom { get; set; }
        /// <summary>
        /// Propriété représentant la date de naissance de l'enfant
        /// </summary>
        public string DateNaissance { get; set; }
        /// <summary>
        /// Propriété représentant l'adresse de l'enfant
        /// </summary>
        public string Adresse { get; set; }
        /// <summary>
        /// Propriété représentant la ville de l'enfant
        /// </summary>
        public string Ville { get; set; }
        /// <summary>
        /// Propriété représentant la province de l'enfant
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// Propriété représentant le numéro de téléphone de l'enfant
        /// </summary>
        public string Telephone { get; set; }


        #endregion Proprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public EnfantDTO()
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
        /// <param name="unNom">Le nom de l'enfant</param>
        /// <param name="unPrenom">Le prenom de l'enfant</param>
        /// <param name="uneDateNaissance">La date de naissance de l'enfant</param>
        /// <param name="uneAdresse">L'adresse de l'enfant</param>
        /// <param name="uneVille">La ville de l'enfant</param>
        /// <param name="uneProvince">La province de l'enfant</param>
        /// <param name="unTelephone">Le telephone de l'enfant</param>
        public EnfantDTO(string unNom = "", string unPrenom = "", string uneDateNaissance = "", string uneAdresse = "", string uneVille = "", string uneProvince = "", string unTelephone = "")
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
        /// Constructeur avec le modèle EnfantModel en paramètre.
        /// </summary>
        /// <param name="unEnfant">L'objet du modèle Enfant.</param>
        public EnfantDTO(EnfantModel unEnfant)
        {
            Nom = unEnfant.Nom;
            Prenom = unEnfant.Prenom;
            DateNaissance = unEnfant.DateNaissance;
            Adresse = unEnfant.Adresse;
            Ville = unEnfant.Ville;
            Province = unEnfant.Province;
            Telephone = unEnfant.Telephone;
        }

        #endregion Constructeurs
    }
}
