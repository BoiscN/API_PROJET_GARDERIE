using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Namespace pour les classes de type Modèle.
/// </summary>
namespace API_PROJET_GARDERIE.Logics.Modeles
{
    /// <summary>
    /// Classe représentant une Depense.
    /// </summary>
    public class DepenseModel
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant la date de la dépense.
        /// </summary>
        private string dateTemps;
        /// <summary>
        /// Propriété représentant la date de la dépense.
        /// </summary>
        public string DateTemps
        {
            get { return dateTemps; }
            set { dateTemps = value; }
        }

        /// <summary>
        /// Attribut représentant le montant de la dépense.
        /// </summary>
        private double montant;
        /// <summary>
        /// Propriété représentant le montant de la dépense.
        /// </summary>
        public double Montant
        {
            get { return montant; }
            set { montant = value; }
        }

        public CategorieDepenseModel categorieDepenseModel { get; set; }
        public CommerceModel commerceModel { get; set; }

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur paramétré
        /// </summary>
        /// <param name="uneDateTemps">La date de la dépense</param>
        /// <param name="unMontant">Le montant de la dépense</param>
        public DepenseModel(string uneDateTemps="", double unMontant=0)
        {
            DateTemps = uneDateTemps;
            Montant = unMontant;
            categorieDepenseModel = new CategorieDepenseModel();
            commerceModel = new CommerceModel();
        }

        #endregion Constructeurs

        #region MethodesService

        public string ObtenirCategorieDescription()
        {
            return categorieDepenseModel.Description;
        }

        public double ObtenirCategoriePourcentage()
        {
            return categorieDepenseModel.Pourcentage;
        }

        public double CalculerDepenseAdmissible()
        {
            return (Montant * categorieDepenseModel.Pourcentage);
        }

        #endregion MethodesService

        #region Overrides

        /// <summary>
        /// Méthode de service permettant d'obternir la version textuelle de l'objet Depense.
        /// </summary>
        /// <returns>Version textuelle de l'objet Depense.</returns>
        public override string ToString()
        {
            return DateTemps + "\n" + Montant + "\n";
        }

        /// <summary>
        /// Méthode de service permettant de vérifier l'égalité entre deux objet Depense.
        /// Deux objets Depense sont égaux s'ils ont le même nom.
        /// </summary>
        /// <param name="obj">L'objet de comparaison.</param>
        /// <returns>Vrai si égal, Faux sinon...</returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is DepenseModel) && DateTemps.Equals((obj as DepenseModel).DateTemps);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le HashCode de l'objet Depense.
        /// </summary>
        /// <returns>HashCode de l'objet Depense.</returns>
        public override int GetHashCode()
        {
            return DateTemps.Length;
        }

        #endregion Overrides
    }
}
