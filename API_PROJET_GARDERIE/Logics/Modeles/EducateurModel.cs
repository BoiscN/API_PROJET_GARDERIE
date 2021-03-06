using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Namespace pour les classes de type Modèle.
/// </summary>
namespace API_PROJET_GARDERIE.Logics.Modeles
{
    /// <summary>
    /// Classe représentant un educateur.
    /// </summary>
    public class EducateurModel
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant le nom de l'educateur.
        /// </summary>
        private string nom;
        /// <summary>
        /// Propriété représentant le nom de l'educateur.
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set
            {
                if (value.Length <= 50)
                    nom = value;
                else
                    throw new Exception("Le nom de l'educateur doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le prenom de l'educateur.
        /// </summary>
        private string prenom;
        /// <summary>
        /// Propriété représentant le prenom de l'educateur.
        /// </summary>
        public string Prenom
        {
            get { return prenom; }
            set
            {
                if (value.Length <= 50)
                    prenom = value;
                else
                    throw new Exception("Le prenom de l'educateur doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la date de naissance de l'educateur.
        /// </summary>
        private string dateNaissance;
        /// <summary>
        /// Propriété représentant la date de naissance de l'educateur.
        /// </summary>
        public string DateNaissance
        {
            get { return dateNaissance; }
            set { dateNaissance = value; }
        }

        /// <summary>
        /// Attribut représentant l'adresse de l'educateur.
        /// </summary>
        private string adresse;
        /// <summary>
        /// Propriété représentant l'adresse de l'educateur.
        /// </summary>
        public string Adresse
        {
            get { return adresse; }
            set
            {
                if (value == null)
                    adresse = null;
                else if (value.Length <= 200)
                    adresse = value;
                else
                    throw new Exception("L'adresse de l'enfant doit avoir un maximum de 200 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la ville de l'educateur.
        /// </summary>
        private string ville;
        /// <summary>
        /// Propriété représentant la ville de l'educateur.
        /// </summary>
        public string Ville
        {
            get { return ville; }
            set
            {
                if (value == null)
                    ville = null;
                else if (value.Length <= 100)
                    ville = value;
                else
                    throw new Exception("La ville de l'enfant doit avoir un maximum de 100 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la province de l'educateur.
        /// </summary>
        private string province;
        /// <summary>
        /// Propriété représentant la province de l'educateur.
        /// </summary>
        public string Province
        {
            get { return province; }
            set
            {
                if (value == null)
                    province = null;
                else if (value.Length <= 100)
                    province = value;
                else
                    throw new Exception("La province de l'enfant doit avoir un maximum de 100 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le numéro de telephone de l'educateur.
        /// </summary>
        private string telephone;
        /// <summary>
        /// Propriété représentant le numéro de telephone de l'educateur.
        /// </summary>
        public string Telephone
        {
            get { return telephone; }
            set
            {
                if (value == null)
                    telephone = null;
                else if (value.Length <= 12)
                    telephone = value;
                else
                    throw new Exception("Le numéro de telephone de l'enfant doit avoir un maximum de 12 caractères.");
            }
        }

        #endregion AttributsProprietes

        #region Constructeurs

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
        public EducateurModel(string unNom = "", string unPrenom = "", string uneDateNaissance = "", string uneAdresse = "", string uneVille = "", string uneProvince = "", string unTelephone = "")
        {
            Nom = unNom;
            Prenom = unPrenom;
            DateNaissance = uneDateNaissance;
            Adresse = uneAdresse;
            Ville = uneVille;
            Province = uneProvince;
            Telephone = unTelephone;
        }

        #endregion Constructeurs

        #region MethodesService


        #endregion MethodesService

        #region Overrides

        /// <summary>
        /// Méthode de service permettant d'obternir la version textuelle de l'objet educateur.
        /// </summary>
        /// <returns>Version textuelle de l'objet educateur.</returns>
        public override string ToString()
        {
            return Nom + "\n" + Prenom + "\n" + DateNaissance + "\n" + Adresse + "\n" + Ville + "\n" + Province + "\n" + Telephone + "\n";
        }

        /// <summary>
        /// Méthode de service permettant de vérifier l'égalité entre deux objet educateur.
        /// Deux objets educateur sont égaux s'ils ont le même nom.
        /// </summary>
        /// <param name="obj">L'objet de comparaison.</param>
        /// <returns>Vrai si égal, Faux sinon...</returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is EnfantModel) && DateNaissance.Equals((obj as EnfantModel).DateNaissance) && Telephone.Equals((obj as EnfantModel).Telephone);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le HashCode de l'objet educateur.
        /// </summary>
        /// <returns>HashCode de l'objet educateur.</returns>
        public override int GetHashCode()
        {
            return Nom.Length + Prenom.Length;
        }

        #endregion Overrides
    }
}
