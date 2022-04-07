using API_PROJET_GARDERIE.Logics.Modeles;

/// <summary>
/// Namespace pour les objets de type DTO.
/// </summary>
namespace API_PROJET_GARDERIE.Logics.DTOs
{
    /// <summary>
    /// Classe de DTO pour la Garderie.
    /// </summary>
    public class GarderieDTO
    {
        #region Proprietes
        /// <summary>
        /// Propriété représentant le nom de la garderie.
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Propriété représentant l'adresse de la garderie.
        /// </summary>
        public string Adresse { get; set; }
        /// <summary>
        /// Propriété représentant la ville de la garderie.
        /// </summary>
        public string Ville { get; set; }
        /// <summary>
        /// Propriété représentant la province de la garderie.
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// Propriété représenant le téléphone de la garderie.
        /// </summary>
        public string Telephone { get; set; }

        #endregion Proprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public GarderieDTO()
        {
            Nom = "";
            Adresse = "";
            Ville = "";
            Province = "";
            Telephone = "";
        }

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="nom">Nom de la garderie.</param>
        /// <param name="adresse">Adresse de la garderie.</param>
        /// <param name="ville">Ville de la garderie.</param>
        /// <param name="province">Province de la garderie.</param>
        /// <param name="telephone">Téléphone de la garderie.</param>
        public GarderieDTO(string nom="", string adresse="", string ville="", string province="", string telephone="")
        {
            Nom = nom;
            Adresse = adresse;
            Ville = ville;
            Province = province;
            Telephone = telephone;
        }

        /// <summary>
        /// Constructeur avec le modèle GarderieModel en paramètre.
        /// </summary>
        /// <param name="laGarderie">L'objet du modèle Garderie.</param>
        public GarderieDTO(GarderieModel laGarderie)
        {
            Nom = laGarderie.Nom;
            Adresse = laGarderie.Adresse;
            Ville = laGarderie.Ville;
            Province = laGarderie.Province;
            Telephone = laGarderie.Telephone;
        }

        #endregion Constructeurs
    }
}
