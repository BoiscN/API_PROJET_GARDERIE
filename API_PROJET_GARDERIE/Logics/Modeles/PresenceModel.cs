using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Namespace pour les classes de type Modèle.
/// </summary>
namespace API_PROJET_GARDERIE.Logics.Modeles
{
    /// <summary>
    /// Classe représentant une Presence.
    /// </summary>
    public class PresenceModel
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant la date de la présence.
        /// </summary>
        private string dateTemps;

        /// <summary>
        /// Propriété représentant la date de la présence.
        /// </summary>
        public string DateTemps
        {
            get { return dateTemps; }
            set { dateTemps = value; }
        }

        /// <summary>
        /// Propriété représentant la garderie de la présence
        /// </summary>
        public GarderieModel Garderie { get; set; }

        /// <summary>
        /// Propriété représentant l'enfant de la présence
        /// </summary>
        public EnfantModel Enfant { get; set; }

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur paramétré
        /// </summary>
        /// <param name="uneDateTemps">La date de la présence</param>
        /// <param name="nomGarderie">Le nom de la garderie</param>
        /// <param name="adresseGarderie">L'adresse de la garderie</param>
        /// <param name="villeGarderie">La ville de la garderie</param>
        /// <param name="provinceGarderie">La province de la garerie</param>
        /// <param name="telephoneGarderie">Le telephone de la garderie</param>
        /// <param name="nomEnfant">Le nom de l'enfant</param>
        /// <param name="prenomEnfant">Le prenom de l'enfant</param>
        /// <param name="dateNaissanceEnfant">La date de naissance de l'enfant</param>
        /// <param name="adresseEnfant">L'adresse de l'enfant</param>
        /// <param name="villeEnfant">La ville de l'enfant</param>
        /// <param name="provinceEnfant">La province de l'enfant</param>
        /// <param name="telephoneEnfant">Le telephone de l'enfant</param>
        public PresenceModel(
            string uneDateTemps = "",
            string nomGarderie = "",
            string adresseGarderie = "",
            string villeGarderie = "",
            string provinceGarderie = "",
            string telephoneGarderie = "",
            string nomEnfant = "",
            string prenomEnfant = "",
            string dateNaissanceEnfant = "",
            string adresseEnfant = "",
            string villeEnfant = "",
            string provinceEnfant = "",
            string telephoneEnfant = "")
        {
            DateTemps = uneDateTemps;
            Garderie = new GarderieModel(nomGarderie, adresseGarderie, villeGarderie, provinceGarderie, telephoneGarderie);
            Enfant = new EnfantModel(nomEnfant, prenomEnfant, dateNaissanceEnfant, adresseEnfant, villeEnfant, provinceEnfant, telephoneEnfant);
        }

        #endregion Constructeurs

        #region MethodesService

        #endregion MethodesService

        #region Overrides

        /// <summary>
        /// Méthode de service permettant d'obternir la version textuelle de l'objet Presence.
        /// </summary>
        /// <returns>Version textuelle de l'objet Presence.</returns>
        public override string ToString()
        {
            return DateTemps + "\n";
        }

        /// <summary>
        /// Méthode de service permettant de vérifier l'égalité entre deux objet Presence.
        /// Deux objets Presence sont égaux s'ils ont le même nom.
        /// </summary>
        /// <param name="obj">L'objet de comparaison.</param>
        /// <returns>Vrai si égal, Faux sinon...</returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is PresenceModel) && DateTemps.Equals((obj as PresenceModel).DateTemps);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le HashCode de l'objet Presence.
        /// </summary>
        /// <returns>HashCode de l'objet Presence.</returns>
        public override int GetHashCode()
        {
            return DateTemps.Length;
        }

        #endregion Overrides
    }
}
