using API_PROJET_GARDERIE.Logics.Modeles;

/// <summary>
/// Namespace pour les objets de type DTO.
/// </summary>
namespace API_PROJET_GARDERIE.Logics.DTOs
{
    /// <summary>
    /// Classe de DTO pour le Commerce.
    /// </summary>
    public class CommerceDTO
    {
        #region Proprietes
        /// <summary>
        /// Propriété représentant la description du commerce.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Propriété représentant l'adresse du commerce.
        /// </summary>
        public string Adresse { get; set; }
        /// <summary>
        /// Propriété représenant le téléphone du commerce.
        /// </summary>
        public string Telephone { get; set; }

        #endregion Proprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public CommerceDTO()
        {
            Description = "";
            Adresse = "";
            Telephone = "";
        }

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="description">La description du commerce.</param>
        /// <param name="adresse">Adresse du commerce.</param>
        /// <param name="telephone">Téléphone du commerce.</param>
        public CommerceDTO(string description = "", string adresse = "", string telephone = "")
        {
            Description = description;
            Adresse = adresse;
            Telephone = telephone;
        }

        /// <summary>
        /// Constructeur avec le modèle GarderieModel en paramètre.
        /// </summary>
        /// <param name="laGarderie">L'objet du modèle Garderie.</param>
        public CommerceDTO(CommerceModel leCommerce)
        {
            Description = leCommerce.Description;
            Adresse = leCommerce.Adresse;
            Telephone = leCommerce.Telephone;
        }

        #endregion Constructeurs
    }
}
