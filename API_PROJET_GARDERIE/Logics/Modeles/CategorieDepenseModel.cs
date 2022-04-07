using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Namespace pour les classes de type Modèle.
/// </summary>
namespace API_PROJET_GARDERIE.Logics.Modeles
{
    /// <summary>
    /// Classe représentant une categorie de dépense.
    /// </summary>
    public class CategorieDepenseModel
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant la description de la categorie de dépense.
        /// </summary>
        private string description;
        /// <summary>
        /// Propriété représentant la description de la categorie de dépense.
        /// </summary>
        public string Description
        {
            get { return description; }
            set
            {
                if (value.Length <= 100)
                    description = value;
                else
                    throw new Exception("La description de la catégorie de dépense doit avoir un maximum de 100 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le pourcentage de la catégorie de dépense.
        /// </summary>
        private double pourcentage;
        /// <summary>
        /// Propriété représentant le pourcentage de la catégorie de dépense.
        /// </summary>
        public double Pourcentage
        {
            get { return pourcentage; }
            set { pourcentage = value; }
        }

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur paramétré
        /// </summary>
        /// <param name="uneDescription">La description de la catégorie de dépense</param>
        /// <param name="unPourcentage">Le pourcentage de la catégorie de dépense</param>
        public CategorieDepenseModel(string uneDescription = "", double unPourcentage = 0)
        {
            Description = uneDescription;
            Pourcentage = unPourcentage;
        }

        #endregion Constructeurs

        #region MethodesService

        #endregion MethodesService

        #region Overrides

        /// <summary>
        /// Méthode de service permettant d'obternir la version textuelle de l'objet CategorieDepense.
        /// </summary>
        /// <returns>Version textuelle de l'objet CategorieDepense.</returns>
        public override string ToString()
        {
            return Description + "\n" + Pourcentage + "\n";
        }

        /// <summary>
        /// Méthode de service permettant de vérifier l'égalité entre deux objet CategorieDepense.
        /// Deux objets CategorieDepense sont égaux s'ils ont le même nom.
        /// </summary>
        /// <param name="obj">L'objet de comparaison.</param>
        /// <returns>Vrai si égal, Faux sinon...</returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is CategorieDepenseModel) && description.Equals((obj as CategorieDepenseModel).description);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le HashCode de l'objet CategorieDepense.
        /// </summary>
        /// <returns>HashCode de l'objet CategorieDepense.</returns>
        public override int GetHashCode()
        {
            return Description.Length;
        }

        #endregion Overrides
    }
}
