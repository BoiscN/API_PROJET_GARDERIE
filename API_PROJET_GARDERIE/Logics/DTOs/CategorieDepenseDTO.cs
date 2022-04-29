using API_PROJET_GARDERIE.Logics.Modeles;

/// <summary>
/// Namespace pour les objets de type DTO.
/// </summary>
namespace API_PROJET_GARDERIE.Logics.DTOs
{
    /// <summary>
    /// Classe de DTO pour la catégorie de dépense.
    /// </summary>
    public class CategorieDepenseDTO
    {
        #region Proprietes
        /// <summary>
        /// Propriété représentant la description de la catégorie de dépense.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Propriété représentant le pourcentage de la catégorie de dépense.
        /// </summary>
        public double Pourcentage { get; set; }

        #endregion Proprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public CategorieDepenseDTO()
        {
            Description = "";
            Pourcentage = 0;
        }

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="description">Description de la Catégorie de dépense.</param>
        /// <param name="pourcentage">Pourcentage de la Catégorie de dépense.</param>
        public CategorieDepenseDTO(string description = "", double pourcentage = 0)
        {
            Description = description;
            Pourcentage = pourcentage;
        }

        /// <summary>
        /// Constructeur avec le modèle CategorieDepenseModel en paramètre.
        /// </summary>
        /// <param name="laCategorieDepense">L'objet du modèle CategorieDepense.</param>
        public CategorieDepenseDTO(CategorieDepenseModel laCategorieDepense)
        {
            Description = laCategorieDepense.Description;
            Pourcentage = laCategorieDepense.Pourcentage;
        }

        #endregion Constructeurs
    }
}