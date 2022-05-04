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
    /// Classe représentant le répository d'un educateur.
    /// </summary>
    public class EducateurRepository : Repository
    {
        #region AttributsProprietes

        /// <summary>
        /// Instance unique du repository.
        /// </summary>
        private static EducateurRepository instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static EducateurRepository Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new EducateurRepository();
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
        private EducateurRepository() :base() {}

        #endregion

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des educateurs.
        /// </summary>
        /// <returns>Liste des enfants.</returns>
        public List<EducateurDTO> ObtenirListeEducateur()
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM T_Educateurs ", connexion);

            List<EducateurDTO> liste = new List<EducateurDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EducateurDTO educateur = new EducateurDTO(reader.GetString(1), reader.GetString(2), reader.GetDateTime(3).ToString(), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                    liste.Add(educateur);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention de la liste des educateurs...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le ID d'un educateur selon ses informatiques uniques.
        /// </summary>
        /// <param name="nomEducateur">Le nom de l'educateur.</param>
        /// <param name="prenomEducateur">Le prenom de l'educateur.</param>
        /// <param name="dateNaissanceEducateur">La date de naissance de l'educateur.</param>
        /// <returns>Le ID de l'educateur.</returns>    
        public int ObtenirIDEducateur(string nomEducateur, string prenomEducateur, string dateNaissanceEducateur)
        {
            SqlCommand command = new SqlCommand(" SELECT IdEducateur " +
                                                "   FROM T_Educateurs " +
                                                "  WHERE Nom = @nom " +
                                                "  AND Prenom = @prenom " +
                                                "  AND DateNaissance = @dateNaissance", connexion);

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            SqlParameter prenomParam = new SqlParameter("@prenom", SqlDbType.VarChar, 50);
            SqlParameter dateNaissanceParam = new SqlParameter("@dateNaissance", SqlDbType.Date);

            nomParam.Value = nomEducateur;
            prenomParam.Value = prenomEducateur;
            dateNaissanceParam.Value = dateNaissanceEducateur;

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
                throw new Exception("Erreur lors de l'obtention d'un id d'un educateur par son nom, son prenom et sa date de naissance...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un educateur selon ses informations uniques.
        /// </summary>
        /// <param name="nomEducateur">Le nom de l'educateur.</param>
        /// <param name="prenomEducateur">Le prenom de l'educateur.</param>
        /// <param name="dateNaissanceEducateur">La date de naissance de l'educateur.</param>
        /// <returns>Le DTO de l'educateur.</returns>
        public EducateurDTO ObtenirEducateur(string nomEducateur, string prenomEducateur, string dateNaissanceEducateur)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM T_Educateurs " +
                                                "  WHERE Nom = @nom " +
                                                "  AND Prenom = @prenom " +
                                                "  AND DateNaissance = @dateNaissance", connexion);

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            SqlParameter prenomParam = new SqlParameter("@prenom", SqlDbType.VarChar, 50);
            SqlParameter dateNaissanceParam = new SqlParameter("@dateNaissance", SqlDbType.Date);

            nomParam.Value = nomEducateur;
            prenomParam.Value = prenomEducateur;
            dateNaissanceParam.Value = dateNaissanceEducateur;

            command.Parameters.Add(nomParam);
            command.Parameters.Add(prenomParam);
            command.Parameters.Add(dateNaissanceParam);

            EducateurDTO unEducateur;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                unEducateur = new EducateurDTO(reader.GetString(1), reader.GetString(2), reader.GetDateTime(3).ToString(), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                reader.Close();
                return unEducateur;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'un educateur par son nom, son prenom et sa date de naissance...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un educateur.
        /// </summary>
        /// <param name="educateurDTO">Le DTO de l'educateur.</param>
        public void AjouterEducateur(EducateurDTO educateurDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " INSERT INTO T_Educateurs (Nom, Prenom, DateNaissance, Adresse, Ville, Province, Telephone) " +
                                  " VALUES (@nom, @prenom, @dateNaissance, @adresse, @ville, @province, @telephone) ";

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            SqlParameter prenomParam = new SqlParameter("@prenom", SqlDbType.VarChar, 50);
            SqlParameter dateNaissanceParam = new SqlParameter("@dateNaissance", SqlDbType.Date);
            SqlParameter adresseParam = new SqlParameter("@adresse", SqlDbType.VarChar, 200);
            SqlParameter villeParam = new SqlParameter("@ville", SqlDbType.VarChar, 100);
            SqlParameter provinceParam = new SqlParameter("@province", SqlDbType.VarChar, 100);
            SqlParameter telephoneParam = new SqlParameter("@telephone", SqlDbType.VarChar, 12);

            nomParam.Value = educateurDTO.Nom;
            prenomParam.Value = educateurDTO.Prenom;
            dateNaissanceParam.Value = educateurDTO.DateNaissance;
            adresseParam.Value = educateurDTO.Adresse;
            villeParam.Value = educateurDTO.Ville;
            provinceParam.Value = educateurDTO.Province;
            telephoneParam.Value = educateurDTO.Telephone;

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
                throw new DBUniqueException("Erreur lors de l'ajout d'un educateur...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de modifier un educateur.
        /// </summary>
        /// <param name="educateur">Le DTO de l'educateur.</param>
        public void ModifierEducateur(EducateurDTO educateur)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " UPDATE T_Educateurs " +
                                     " SET Adresse = @adresse, " +
                                     "     Ville = @ville, " +
                                     "     Province = @province, " +
                                     "     Telephone = @telephone " +
                                     " WHERE Nom = @nom " +
                                     " AND Prenom = @Prenom " +
                                     " AND DateNaissance = @dateNaissance";

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            SqlParameter prenomParam = new SqlParameter("@prenom", SqlDbType.VarChar, 50);
            SqlParameter dateNaissanceParam = new SqlParameter("@dateNaissance", SqlDbType.Date);
            SqlParameter adresseParam = new SqlParameter("@adresse", SqlDbType.VarChar, 200);
            SqlParameter villeParam = new SqlParameter("@ville", SqlDbType.VarChar, 100);
            SqlParameter provinceParam = new SqlParameter("@province", SqlDbType.VarChar, 100);
            SqlParameter telephoneParam = new SqlParameter("@telephone", SqlDbType.VarChar, 12);

            nomParam.Value = educateur.Nom;
            prenomParam.Value = educateur.Prenom;
            dateNaissanceParam.Value = educateur.DateNaissance;
            adresseParam.Value = educateur.Adresse;
            villeParam.Value = educateur.Ville;
            provinceParam.Value = educateur.Province;
            telephoneParam.Value = educateur.Telephone;

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
                throw new Exception("Erreur lors de la modification d'un educateur...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de supprimer un educateur.
        /// </summary>
        /// <param name="educateur">Le DTO de l'educateur.</param>
        public void SupprimerEducateur(EducateurDTO educateur)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE " +
                                    " FROM T_Educateurs " +
                                   " WHERE Nom = @nom" +
                                   " AND Prenom = @prenom" +
                                   " AND DateNaissance = @dateNaissance ";

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            SqlParameter prenomParam = new SqlParameter("@prenom", SqlDbType.VarChar, 50);
            SqlParameter dateNaissanceParam = new SqlParameter("@dateNaissance", SqlDbType.Date);

            nomParam.Value = educateur.Nom;
            prenomParam.Value = educateur.Prenom;
            dateNaissanceParam.Value = educateur.DateNaissance;

            command.Parameters.Add(nomParam);
            command.Parameters.Add(prenomParam);
            command.Parameters.Add(dateNaissanceParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                if (e.Number == 547)
                {
                    throw new DBRelationException("Impossible de supprimer l'educateur.", e); // Présences associés.
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'un educateur...", ex);
            }

            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des educateurs.
        /// </summary>
        public void ViderListeEducateur()
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE FROM T_Educateurs";
            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                if (e.Number == 547)
                {
                    throw new DBRelationException("Impossible de supprimer l'educateur.", e); // Présences associés.
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'un educateur...", ex);
            }

            finally
            {
                FermerConnexion();
            }
        }


        #endregion
    }
}
