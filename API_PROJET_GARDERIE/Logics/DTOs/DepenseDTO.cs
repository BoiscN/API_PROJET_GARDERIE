using API_PROJET_GARDERIE.Logics.Modeles;

/// <summary>
/// Namespace pour les objets de type DTO.
/// </summary>
namespace API_PROJET_GARDERIE.Logics.DTOs
{
    /// <summary>
    /// Classe de DTO pour la Depense.
    /// </summary>
    public class DepenseDTO
    {
        #region Proprietes
        /// <summary>
        /// Propriété représentant la date de la dépense.
        /// </summary>
        public string DateTemps { get; set; }
        /// <summary>
        /// Propriété représentant le montant de la dépense.
        /// </summary>
        public double Montant { get; set; }
        /// <summary>
        /// Propriété représentant le montant admissible de la dépense.
        /// </summary>
        public double MontantAdmissible { get; set; }

        public CategorieDepenseDTO categorieDepenseDTO { get; set; }
        public CommerceDTO commerceDTO { get; set; }

        #endregion Proprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public DepenseDTO()
        {
            DateTemps = "";
            Montant = 0;
            MontantAdmissible = 0;
            categorieDepenseDTO = new CategorieDepenseDTO();
            commerceDTO = new CommerceDTO();
        }

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="dateTemps">La date de la dépense.</param>
        /// <param name="montant">Le montant de la dépense.</param>
        public DepenseDTO(string dateTemps="", double montant=0, string descriptionCategorieDepense = "", double pourcentageCategorieDepense = 0, string descriptionCommerce = "", string adresseCommerce = "", string telephoneCommerce = "")
        {
            DateTemps = dateTemps;
            Montant = montant;
            categorieDepenseDTO = new CategorieDepenseDTO(descriptionCategorieDepense, pourcentageCategorieDepense);
            commerceDTO = new CommerceDTO(descriptionCommerce, adresseCommerce, telephoneCommerce);
        }

        /// <summary>
        /// Constructeur avec le modèle DepenseModel en paramètre.
        /// </summary>
        /// <param name="uneDepense">L'objet du modèle Depense.</param>
        public DepenseDTO(DepenseModel uneDepense)
        {
            DateTemps = uneDepense.DateTemps;
            Montant = uneDepense.Montant;
            MontantAdmissible = uneDepense.CalculerDepenseAdmissible();
            categorieDepenseDTO = new CategorieDepenseDTO(uneDepense.categorieDepenseModel);
            commerceDTO = new CommerceDTO(uneDepense.commerceModel);
        }

        #endregion Constructeurs
    }
}
