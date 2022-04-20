using API_PROJET_GARDERIE.Logics.DAOs;
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
    public class GarderieModel
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant le nom de la garderie.
        /// </summary>
        private string nom;
        /// <summary>
        /// Propriété représentant le nom de la garderie.
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set {
                    if (value.Length <= 100)
                        nom = value;
                    else
                        throw new Exception("Le nom de la garderie doit avoir un maximum de 100 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant l'adresse de la garderie.
        /// </summary>
        private string adresse;
        /// <summary>
        /// Propriété représentant l'adresse de la garderie.
        /// </summary>
        public string Adresse
        {
            get { return adresse; }
            set
            {
                if (value.Length <= 200)
                    adresse = value;
                else
                    throw new Exception("L'adresse de la garderie doit avoir un maximum de 200 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la ville de la garderie.
        /// </summary>
        private string ville;
        /// <summary>
        /// Propriété représentant la ville de la garderie.
        /// </summary>
        public string Ville
        {
            get { return ville; }
            set
            {
                if (value.Length <= 100)
                    ville = value;
                else
                    throw new Exception("La ville de la garderie doit avoir un maximum de 100 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la province de la garderie.
        /// </summary>
        private string province;
        /// <summary>
        /// Propriété représentant la province de la garderie.
        /// </summary>
        public string Province
        {
            get { return province; }
            set
            {
                if (value.Length <= 50)
                    province = value;
                else
                    throw new Exception("La province de la garderie doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le telephone de la garderie.
        /// </summary>
        private string telephone;
        /// <summary>
        /// Propriété représentant le telephone de la garderie.
        /// </summary>
        public string Telephone
        {
            get { return telephone; }
            set
            {
                if (value.Length <= 12)
                    telephone = value;
                else
                    throw new Exception("Le téléphone de la garderie doit avoir un maximum de 12 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la liste des dépense d'une Garderie.
        /// </summary>
        public List<DepenseModel> listeDepense { get; set; }

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur paramétré
        /// </summary>
        /// <param name="unNom">Le nom de la garderie</param>
        /// <param name="uneAdresse">L'adresse de la garderie</param>
        /// <param name="uneVille">La ville de la garderie</param>
        /// <param name="uneProvince">La province de la garderie</param>
        /// <param name="unTelephone">Le téléphone de la garderie</param>
        public GarderieModel(string unNom="", string uneAdresse="", string uneVille="", string uneProvince="", string unTelephone="")
        {
            Nom = unNom;
            Adresse = uneAdresse;
            Ville = uneVille;
            Province = uneProvince;
            Telephone = unTelephone;
            listeDepense = new List<DepenseModel>();
        }

        #endregion Constructeurs

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des dépenses de la garderie.
        /// </summary>
        /// <returns>Une liste de dépenses</returns>
        public List<DepenseModel> ObtenirListeDepense()
        {
            return listeDepense;
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter une dépense à la liste.
        /// </summary>
        /// <param name="depense">La dépense à ajouter.</param>
        public void AjouterDepense(DepenseModel depense)
        {
            if (SiDepensePresent(depense))
                throw new Exception("Erreur - La dépense est déjà présente.");
            listeDepense.Add(depense);
            if (!SiDepensePresent(depense))
                throw new Exception("Erreur - Problème lors de l'ajout d'une dépense.");
        }

        /// <summary>
        /// Méthode de service permettant de modifier une dépense.
        /// </summary>
        /// <param name="depense">La dépense à modifier.</param>
        public void ModifierDepense(DepenseModel depense)
        {
            if (listeDepense.Find(x => x.Equals(depense)) != null)
            {
                DepenseModel depenseListe = listeDepense.Find(x => x.Equals(depense));
                depenseListe.DateTemps = depense.DateTemps;
                depenseListe.Montant = depense.Montant;
                depenseListe.categorieDepenseModel = depense.categorieDepenseModel;
                depenseListe.commerceModel = depense.commerceModel;
            }
            else
            {
                throw new Exception("Erreur - La dépense est inexistante.");
            }
            
        }

        /// <summary>
        /// Méthode de service permettant de supprimer une dépense à la liste.
        /// </summary>
        /// <param name="depense">La depense à supprimer.</param>
        public void SupprimerDepense(DepenseModel depense)
        {
            if (!SiDepensePresent(depense))
                throw new Exception("Erreur - La dépense est déjà absente.");
            listeDepense.Remove(depense);
            if (SiDepensePresent(depense))
                throw new Exception("Erreur - Problème lors de l'enlèvement de la dépense.");
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des dépenses de la Garderie.
        /// </summary>
        public void ViderListeDepense()
        {
            if (ObtenirNombreDepense() == 0)
                throw new Exception("Erreur - La liste des dépenses est déjà vide.");
            listeDepense.Clear();
            if (!SiAucuneDepense())
                throw new Exception("Erreur - Problème lors du vidage de la liste des dépenses.");
        }

        /// <summary>
        /// Méthode de service permettant de vérifier si une dépense est présente dans la liste.
        /// </summary>
        /// <param name="uneDepense">La dépense que l'on cherche. (Information du Equals)</param>
        /// <returns>Vrai si la dépense est trouvé, Faux sinon...</returns>
        private bool SiDepensePresent(DepenseModel uneDepense)
        {
            return listeDepense.Contains(uneDepense);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le nombre de dépense de la Garderie.
        /// </summary>
        /// <returns>Nombre de dépense.</returns>
        private int ObtenirNombreDepense()
        {
            return listeDepense.Count;
        }

        /// <summary>
        /// Méthode de service permettant de savoir si la Garderie a aucune dépense.
        /// </summary>
        /// <returns>Vrai si aucune dépense, Faux sinon...</returns>
        private bool SiAucuneDepense()
        {
            return ObtenirNombreDepense() == 0;
        }

        #endregion MethodesService

        #region Overrides

        /// <summary>
        /// Méthode de service permettant d'obternir la version textuelle de l'objet Garderie.
        /// </summary>
        /// <returns>Version textuelle de l'objet Garderie.</returns>
        public override string ToString()
        {
            return Nom + "\n" + Adresse + "\n" + Ville + ", "
                    + Province + "\n" + Telephone + "\n";
        }

        /// <summary>
        /// Méthode de service permettant de vérifier l'égalité entre deux objet Garderie.
        /// Deux objets Garderie sont égaux s'ils ont le même nom.
        /// </summary>
        /// <param name="obj">L'objet de comparaison.</param>
        /// <returns>Vrai si égal, Faux sinon...</returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is GarderieModel) && Nom.Equals((obj as GarderieModel).Nom);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le HashCode de l'objet Garderie.
        /// </summary>
        /// <returns>HashCode de l'objet Garderie.</returns>
        public override int GetHashCode()
        {
            return Nom.Length;
        }

        #endregion Overrides
    }
}
