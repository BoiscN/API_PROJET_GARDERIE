using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using API_PROJET_GARDERIE.Logics.DTOs;
using API_PROJET_GARDERIE.Logics.Exceptions;
using API_PROJET_GARDERIE.Logics.Modeles;

/// <summary>
/// Namespace pour les classe de type DAO.
/// </summary>
namespace API_PROJET_GARDERIE.Logics.DAOs
{
    /// <summary>
    /// Classe représentant le répository d'une Presence.
    /// </summary>
    public class PresenceRepository : Repository
    {
        #region AttributsProprietes

        /// <summary>
        /// Instance unique du repository.
        /// </summary>
        private static PresenceRepository instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static PresenceRepository Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new PresenceRepository();
                }
                //...on retourne l'instance unique.
                return instance;
            }
        }

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur privée du repository.
        /// </summary>
        private PresenceRepository() :base() {}

        #endregion

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des Presences d'une garderie.
        /// </summary>
        /// <param name="nomGarderie">Le nom de la garderie.</param>
        /// <returns>Liste des présences d'une garderie.</returns>
        public List<PresenceDTO> ObtenirListePresence(string nomGarderie)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM T_Presences tp " +
                                                " INNER JOIN T_Garderies tg ON tp.IdGarderie = tg.IdGarderie " +
                                                " INNER JOIN T_Enfants te ON tp.IdEnfant = te.IdEnfant " +
                                                " INNER JOIN T_Educateurs ted ON tp.IdEducateur = ted.IdEducateur " +
                                                " WHERE tp.IdGarderie = @idGarderie", connexion);

            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.Int);

            idGarderieParam.Value = GarderieRepository.Instance.ObtenirIDGarderie(nomGarderie);

            command.Parameters.Add(idGarderieParam);

            List<PresenceDTO> liste = new List<PresenceDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PresenceDTO presence = new PresenceDTO(reader.GetDateTime(1).ToString(), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(12), reader.GetString(13), reader.GetDateTime(14).ToString(), reader.GetString(15), reader.GetString(16), reader.GetString(17), reader.GetString(18), reader.GetString(20), reader.GetString(21), reader.GetDateTime(22).ToString(), reader.GetString(23), reader.GetString(24), reader.GetString(25), reader.GetString(26));
                    liste.Add(presence);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention de la liste des presences...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir une présence selon ses informations uniques.
        /// </summary>
        /// <param name="dateTemps">La date de la présence.</param>
        /// <param name="nomEnfant">Le nom de l'enfant de la présence.</param>
        /// <param name="prenomEnfant">Le prenom de l'enfant de la présence.</param>
        /// <param name="dateNaissanceEnfant">La date de naissance de l'enfant de la présence.</param>
        /// <returns>Le DTO de la présence.</returns>
        public int ObtenirIDPresence(string dateTemps, string nomEnfant, string prenomEnfant, string dateNaissanceEnfant)
        {
            SqlCommand command = new SqlCommand(" SELECT IdPresence " +
                                                " FROM T_Presences tp " +
                                                " INNER JOIN T_Garderies tg ON tp.IdGarderie = tg.IdGarderie " +
                                                " INNER JOIN T_Enfants te ON tp.IdEnfant = te.IdEnfant " +
                                                " WHERE tp.DateTemps = @dateTemps " +
                                                " AND te.Nom = @nom AND te.Prenom = @prenom " +
                                                " AND te.DateNaissance = @dateNaissance", connexion);

            SqlParameter dateTempsPresenceParam = new SqlParameter("@dateTemps", SqlDbType.DateTime);
            SqlParameter nomEnfantParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            SqlParameter prenomEnfantParam = new SqlParameter("@prenom", SqlDbType.VarChar, 50);
            SqlParameter dateNaissanceEnfantParam = new SqlParameter("@dateNaissance", SqlDbType.Date);

            dateTempsPresenceParam.Value = dateTemps;
            nomEnfantParam.Value = nomEnfant;
            prenomEnfantParam.Value = prenomEnfant;
            dateNaissanceEnfantParam.Value = dateNaissanceEnfant;

            command.Parameters.Add(dateTempsPresenceParam);
            command.Parameters.Add(nomEnfantParam);
            command.Parameters.Add(prenomEnfantParam);
            command.Parameters.Add(dateNaissanceEnfantParam);

            int id;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                id = reader.GetInt32(0);
                reader.Close();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'un id d'une présence par sa date, le nom, prenom et date de naissance de l'enfant et de l'educateur...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir une présence selon ses informations uniques.
        /// </summary>
        /// <param name="dateTemps">Date de la présence.</param>
        /// <param name="nomEnfant">Le nom de l'enfant de la présence.</param>
        /// <param name="prenomEnfant">Le prenom de l'enfant de la présence.</param>
        /// <param name="dateNaissanceEnfant">La date de naissance de l'enfant de la présence.</param>
        /// <returns>Le DTO de la présence.</returns>
        public PresenceDTO ObtenirPresence(string dateTemps, string nomEnfant, string prenomEnfant, string dateNaissanceEnfant)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM T_Presences tp " +
                                                " INNER JOIN T_Garderies tg ON tp.IdGarderie = tg.IdGarderie " +
                                                " INNER JOIN T_Enfants te ON tp.IdEnfant = te.IdEnfant " +
                                                " INNER JOIN T_Educateurs ted ON tp.IdEducateur = ted.IdEducateur " +
                                                " WHERE tp.DateTemps = @dateTemps " +
                                                " AND te.Nom = @nom AND te.Prenom = @prenom " +
                                                " AND te.DateNaissance = @dateNaissance", connexion);

            SqlParameter dateTempsPresenceParam = new SqlParameter("@dateTemps", SqlDbType.DateTime);
            SqlParameter nomEnfantParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            SqlParameter prenomEnfantParam = new SqlParameter("@prenom", SqlDbType.VarChar, 50);
            SqlParameter dateNaissanceEnfantParam = new SqlParameter("@dateNaissance", SqlDbType.Date);

            dateTempsPresenceParam.Value = dateTemps;
            nomEnfantParam.Value = nomEnfant;
            prenomEnfantParam.Value = prenomEnfant;
            dateNaissanceEnfantParam.Value = dateNaissanceEnfant;

            command.Parameters.Add(dateTempsPresenceParam);
            command.Parameters.Add(nomEnfantParam);
            command.Parameters.Add(prenomEnfantParam);
            command.Parameters.Add(dateNaissanceEnfantParam);



            PresenceDTO unePresence;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                unePresence = new PresenceDTO(reader.GetDateTime(1).ToString(), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(12), reader.GetString(13), reader.GetDateTime(14).ToString(), reader.GetString(15), reader.GetString(16), reader.GetString(17), reader.GetString(18), reader.GetString(20), reader.GetString(21), reader.GetDateTime(22).ToString(), reader.GetString(23), reader.GetString(24), reader.GetString(25), reader.GetString(26));
                reader.Close();
                return unePresence;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'une présence par sa date, le nom, prénom et la date de naissance de l'enfant et de l'educateur...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter une présence.
        /// </summary>
        /// <param name="presenceDTO">Le DTO de la présence.</param>
        public void AjouterPresence(PresenceDTO presenceDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " INSERT INTO T_Presences (DateTemps, IdGarderie, IdEnfant, IdEducateur) " +
                                  " VALUES (@dateTemps, @idGarderie, @idEnfant, @idEducateur) ";

            SqlParameter dateTempsParam = new SqlParameter("@dateTemps", SqlDbType.DateTime);
            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.Int);
            SqlParameter idEnfantParam = new SqlParameter("@idEnfant", SqlDbType.Int);
            SqlParameter idEducateurParam = new SqlParameter("@idEducateur", SqlDbType.Int);

            dateTempsParam.Value = presenceDTO.DateTemps;
            idGarderieParam.Value = GarderieRepository.Instance.ObtenirIDGarderie(presenceDTO.Garderie.Nom);
            idEnfantParam.Value = EnfantRepository.Instance.ObtenirIDEnfant(presenceDTO.Enfant.Nom, presenceDTO.Enfant.Prenom, presenceDTO.Enfant.DateNaissance);
            idEducateurParam.Value = EducateurRepository.Instance.ObtenirIDEducateur(presenceDTO.Educateur.Nom, presenceDTO.Educateur.Prenom, presenceDTO.Educateur.DateNaissance);

            command.Parameters.Add(dateTempsParam);
            command.Parameters.Add(idGarderieParam);
            command.Parameters.Add(idEnfantParam);
            command.Parameters.Add(idEducateurParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBUniqueException("Erreur lors de l'ajout d'une présence...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }
        /// <summary>
        /// Méthode de service qui permet d'obtenir la liste des presence enfonction du nom de la garderie
        /// et la date de presence
        /// </summary>
        /// <param name="nomGarderie"></param>
        /// <param name="dateTemps"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<PresenceDTO> ObtenirListePresenceDate(string nomGarderie, string dateTemps)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM T_Presences tp " +
                                                " INNER JOIN T_Garderies tg ON tp.IdGarderie = tg.IdGarderie " +
                                                " INNER JOIN T_Enfants te ON tp.IdEnfant = te.IdEnfant " +
                                                " INNER JOIN T_Educateurs ted ON tp.IdEducateur = ted.IdEducateur " +
                                                " WHERE tp.IdGarderie = @idGarderie" +
                                                " AND Year(tp.DateTemps) = @dateTemps", connexion);

            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.Int);
            SqlParameter datePresenceParam = new SqlParameter("@dateTemps", SqlDbType.Int);

            idGarderieParam.Value = GarderieRepository.Instance.ObtenirIDGarderie(nomGarderie);
            datePresenceParam.Value = dateTemps;

            command.Parameters.Add(idGarderieParam);
            command.Parameters.Add(datePresenceParam);

            List<PresenceDTO> liste = new List<PresenceDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PresenceDTO presence = new PresenceDTO(reader.GetDateTime(1).ToString(), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(12), reader.GetString(13), reader.GetDateTime(14).ToString(), reader.GetString(15), reader.GetString(16), reader.GetString(17), reader.GetString(18), reader.GetString(20), reader.GetString(21), reader.GetDateTime(22).ToString(), reader.GetString(23), reader.GetString(24), reader.GetString(25), reader.GetString(26));
                    liste.Add(presence);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention de la liste des presences...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }
        /// <summary>
        /// Méthode de service qui permet d'
        /// </summary>
        /// <param name="nomGarderie"></param>
        /// <param name="dateTemps"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int ObtenirNombreEducateur(string nomGarderie, string dateTemps)
        {
            SqlCommand command = new SqlCommand("   SELECT Count(*) FROM" +
                                                "   (SELECT DISTINCT(DateTemps), IdEducateur" +
                                                "   FROM T_Presences" +
                                                "   WHERE IdGarderie = @idGarderie" +
                                                " AND Year(DateTemps) = @dateTemps) AS nombrePresence", connexion);


            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.VarChar, 50);
            SqlParameter datePresenceParam = new SqlParameter("@dateTemps", SqlDbType.Int);

            idGarderieParam.Value = GarderieRepository.Instance.ObtenirIDGarderie(nomGarderie);
            datePresenceParam.Value = dateTemps;


            command.Parameters.Add(idGarderieParam);
            command.Parameters.Add(datePresenceParam);
            int nombrePresence;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                nombrePresence = reader.GetInt32(0);
                reader.Close();
                return nombrePresence;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention du nombre de jours et de presences des éducateurs...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        #endregion
    }
}
