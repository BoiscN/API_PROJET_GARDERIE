using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Namespace pour les classes de type Modèle.
/// </summary>
namespace API_PROJET_GARDERIE.Logics.Modeles
{
    /// <summary>
    /// Classe représentant un commerce.
    /// </summary>
    public class CommerceModel
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant la description du commerce.
        /// </summary>
        private string description;
        /// <summary>
        /// Propriété représentant la description du commerce.
        /// </summary>
        public string Description
        {
            get { return description; }
            set
            {
                if (value.Length <= 50)
                    description = value;
                else
                    throw new Exception("La description du commerce doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant l'adresse du commerce.
        /// </summary>
        private string adresse;
        /// <summary>
        /// Propriété représentant l'adresse du commerce.
        /// </summary>
        public string Adresse
        {
            get { return adresse; }
            set
            {
                if (value.Length <= 200)
                    adresse = value;
                else
                    throw new Exception("L'adresse du commerce doit avoir un maximum de 200 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le numéro de téléphone du commerce.
        /// </summary>
        private string telephone;
        /// <summary>
        /// Propriété représentant le numéro de téléphone du commerce.
        /// </summary>
        public string Telephone
        {
            get { return telephone; }
            set
            {
                if (value.Length <= 12)
                    telephone = value;
                else
                    throw new Exception("L'adresse du commerce doit avoir un maximum de 12 caractères.");
            }
        }

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur paramétré
        /// </summary>
        /// <param name="uneDescription">La description du commerce</param>
        /// <param name="uneAdresse">L'adresse du commerce</param>
        /// <param name="unTelephone">Le numéro de téléphone du commerce</param>
        public CommerceModel(string uneDescription="", string uneAdresse="", string unTelephone="")
        {
            Description = uneDescription;
            Adresse = uneAdresse;
            Telephone = unTelephone;
        }

        #endregion Constructeurs

        #region MethodesService

        #endregion MethodesService

        #region Overrides

        /// <summary>
        /// Méthode de service permettant d'obternir la version textuelle de l'objet Commerce.
        /// </summary>
        /// <returns>Version textuelle de l'objet Commerce.</returns>
        public override string ToString()
        {
            return Description + "\n" + Adresse + "\n" + Telephone + "\n";
        }

        /// <summary>
        /// Méthode de service permettant de vérifier l'égalité entre deux objet Commerce.
        /// Deux objets Commerce sont égaux s'ils ont le même nom.
        /// </summary>
        /// <param name="obj">L'objet de comparaison.</param>
        /// <returns>Vrai si égal, Faux sinon...</returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is CommerceModel) && Telephone.Equals((obj as CommerceModel).Telephone);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le HashCode de l'objet Commerce.
        /// </summary>
        /// <returns>HashCode de l'objet Commerce.</returns>
        public override int GetHashCode()
        {
            return Telephone.Length + Description.Length + Adresse.Length;
        }

        #endregion Overrides
    }
}
