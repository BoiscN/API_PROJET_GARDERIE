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
    /// Classe représentant le répository d'une Enfant.
    /// </summary>
    public class EnfantRepository : Repository
    {
        #region AttributsProprietes

        /// <summary>
        /// Instance unique du repository.
        /// </summary>
        private static EnfantRepository instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static EnfantRepository Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new EnfantRepository();
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
        private EnfantRepository() :base() {}

        #endregion

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des enfants.
        /// </summary>
        /// <returns>Liste des enfants.</returns>
        public List<EnfantDTO> ObtenirListeEnfant()
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM T_Enfants ", connexion);

            List<EnfantDTO> liste = new List<EnfantDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EnfantDTO enfant = new EnfantDTO(reader.GetString(1), reader.GetString(2), reader.GetDateTime(3).ToString(), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                    liste.Add(enfant);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention de la liste des enfants...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le ID d'un enfant selon ses informatiques uniques.
        /// </summary>
        /// <param name="nomEnfant">Le nom de l'enfant.</param>
        /// <param name="prenomEnfant">Le prenom de l'enfant.</param>
        /// <param name="dateNaissanceEnfant">La date de naissance de l'enfant.</param>
        /// <returns>Le ID de l'enfant.</returns>    
        public int ObtenirIDEnfant(string nomEnfant, string prenomEnfant, string dateNaissanceEnfant)
        {
            SqlCommand command = new SqlCommand(" SELECT IdEnfant " +
                                                "   FROM T_Enfants " +
                                                "  WHERE Nom = @nom " +
                                                "  AND Prenom = @prenom " +
                                                "  AND DateNaissance = @dateNaissance", connexion);

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            SqlParameter prenomParam = new SqlParameter("@prenom", SqlDbType.VarChar, 50);
            SqlParameter dateNaissanceParam = new SqlParameter("@dateNaissance", SqlDbType.Date);

            nomParam.Value = nomEnfant;
            prenomParam.Value = prenomEnfant;
            dateNaissanceParam.Value = dateNaissanceEnfant;

            command.Parameters.Add(nomParam);
            command.Parameters.Add(prenomParam);
            command.Parameters.Add(dateNaissanceParam);

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
                throw new Exception("Erreur lors de l'obtention d'un id d'un enfant par son nom, son prenom et sa date de naissance...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un enfant selon ses informations uniques.
        /// </summary>
        /// <param name="nomEnfant">Le nom de l'enfant.</param>
        /// <param name="prenomEnfant">Le prenom de l'enfant.</param>
        /// <param name="dateNaissanceEnfant">La date de naissance de l'enfant.</param>
        /// <returns>Le DTO de l'enfant.</returns>
        public EnfantDTO ObtenirEnfant(string nomEnfant, string prenomEnfant, string dateNaissanceEnfant)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM T_Enfants " +
                                                "  WHERE Nom = @nom " +
                                                "  AND Prenom = @prenom " +
                                                "  AND DateNaissance = @dateNaissance", connexion);

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            SqlParameter prenomParam = new SqlParameter("@prenom", SqlDbType.VarChar, 50);
            SqlParameter dateNaissanceParam = new SqlParameter("@dateNaissance", SqlDbType.Date);

            nomParam.Value = nomEnfant;
            prenomParam.Value = prenomEnfant;
            dateNaissanceParam.Value = dateNaissanceEnfant;

            command.Parameters.Add(nomParam);
            command.Parameters.Add(prenomParam);
            command.Parameters.Add(dateNaissanceParam);

            EnfantDTO unEnfant;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                unEnfant = new EnfantDTO(reader.GetString(1), reader.GetString(2), reader.GetDateTime(3).ToString(), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                reader.Close();
                return unEnfant;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'un enfant par son nom, son prenom et sa date de naissance...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un enfant.
        /// </summary>
        /// <param name="enfantDTO">Le DTO de l'enfant.</param>
        public void AjouterEnfant(EnfantDTO enfantDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " INSERT INTO T_Enfants (Nom, Prenom, DateNaissance, Adresse, Ville, Province, Telephone) " +
                                  " VALUES (@nom, @prenom, @dateNaissance, @adresse, @ville, @province, @telephone) ";

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            SqlParameter prenomParam = new SqlParameter("@prenom", SqlDbType.VarChar, 50);
            SqlParameter dateNaissanceParam = new SqlParameter("@dateNaissance", SqlDbType.Date);
            SqlParameter adresseParam = new SqlParameter("@adresse", SqlDbType.VarChar, 200);
            SqlParameter villeParam = new SqlParameter("@ville", SqlDbType.VarChar, 100);
            SqlParameter provinceParam = new SqlParameter("@province", SqlDbType.VarChar, 100);
            SqlParameter telephoneParam = new SqlParameter("@telephone", SqlDbType.VarChar, 12);

            nomParam.Value = enfantDTO.Nom;
            prenomParam.Value = enfantDTO.Prenom;
            dateNaissanceParam.Value = enfantDTO.DateNaissance;
            adresseParam.Value = enfantDTO.Adresse;
            villeParam.Value = enfantDTO.Ville;
            provinceParam.Value = enfantDTO.Province;
            telephoneParam.Value = enfantDTO.Telephone;

            command.Parameters.Add(nomParam);
            command.Parameters.Add(prenomParam);
            command.Parameters.Add(dateNaissanceParam);
            command.Parameters.Add(adresseParam);
            command.Parameters.Add(villeParam);
            command.Parameters.Add(provinceParam);
            command.Parameters.Add(telephoneParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBUniqueException("Erreur lors de l'ajout d'un enfant...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        #endregion
    }
}
