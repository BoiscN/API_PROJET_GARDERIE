using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Namespace pour les classes de type Modèle.
/// </summary>
namespace API_PROJET_GARDERIE.Logics.Modeles
{
    /// <summary>
    /// Classe représentant une Garderie.
    /// </summary>
    public class DepenseModel
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant le nom de la garderie.
        /// </summary>
        private string dateTemps;
        /// <summary>
        /// Propriété représentant le nom de la garderie.
        /// </summary>
        public string DateTemps
        {
            get { return dateTemps; }
            set { dateTemps=value; }
        }

        /// <summary>
        /// Attribut représentant l'adresse de la garderie.
        /// </summary>
        private double montant;
        /// <summary>
        /// Propriété représentant l'adresse de la garderie.
        /// </summary>
        public double Montant
        {
            get { return montant; }
            set { montant=value; }
        }
        private double montantAdmissible;
        public double MontantAdmissible
        {
            get { return montantAdmissible; }
            set { montantAdmissible = value; }
        }
        public CategorieDepenseModel categorieDepenseModel;
        public CommerceModel commerceModel;


        #endregion AttributsProprietes

        #region Constructeurs
        public DepenseModel()
        {
            

        }
        /// <summary>
        /// Constructeur paramétré
        /// </summary>
        /// <param name="unNom">Le nom de la garderie</param>
        /// <param name="uneAdresse">L'adresse de la garderie</param>
        /// <param name="uneVille">La ville de la garderie</param>
        /// <param name="uneProvince">La province de la garderie</param>
        /// <param name="unTelephone">Le téléphone de la garderie</param>
        public DepenseModel( string unDateTemps="", double unMontant =0.0)
        {
            DateTemps = unDateTemps;
            Montant = unMontant;
            
            //MontantAdmissible = unMontantAdmissible;
            
        }

        #endregion Constructeurs

        #region MethodesService
        public double ObtenirCategoriePourcentage()
        {
            return categorieDepenseModel.Pourcentage;
        }
        public string ObtenirCategorieDescription()
        {
            return categorieDepenseModel.Description;
        }
        public double CalculerDepenseAdmissible()
        {
            return Montant * categorieDepenseModel.Pourcentage;
        }
        #endregion MethodesService

        #region Overrides

        /// <summary>
        /// Méthode de service permettant d'obternir la version textuelle de l'objet Garderie.
        /// </summary>
        /// <returns>Version textuelle de l'objet Garderie.</returns>
        public override string ToString()
        {
            return Montant + "\n" + DateTemps + "\n";
        }
        
        /// <summary>
        /// Méthode de service permettant de vérifier l'égalité entre deux objet Garderie.
        /// Deux objets Garderie sont égaux s'ils ont le même nom.
        /// </summary>
        /// <param name="obj">L'objet de comparaison.</param>
        /// <returns>Vrai si égal, Faux sinon...</returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is DepenseModel) && DateTemps.Equals((obj as DepenseModel).DateTemps);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le HashCode de l'objet Garderie.
        /// </summary>
        /// <returns>HashCode de l'objet Garderie.</returns>
        public override int GetHashCode()
        {
            return DateTemps.Length;
        }

        #endregion Overrides
    }
}
