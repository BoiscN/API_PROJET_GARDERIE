using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using API_PROJET_GARDERIE.Logics.DTOs;
using API_PROJET_GARDERIE.Logics.Exceptions;


/// <summary>
/// Namespace pour les classe de type DAO.
/// </summary>
namespace API_PROJET_GARDERIE.Logics.DAOs
{
    /// <summary>
    /// Classe représentant le répository d'une Garderie.
    /// </summary>
    public class GarderieRepository : Repository
    {
        #region AttributsProprietes

        /// <summary>
        /// Instance unique du repository.
        /// </summary>
        private static GarderieRepository instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static GarderieRepository Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new GarderieRepository();
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
        private GarderieRepository() :base() {}

        #endregion

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des garderies.
        /// </summary>
        /// <returns>Liste des garderies.</returns>
        public List<GarderieDTO> ObtenirListeGarderie()
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM T_Garderies ", connexion);

            List<GarderieDTO> liste = new List<GarderieDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GarderieDTO garderie = new GarderieDTO(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    liste.Add(garderie);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention de la liste des garderies...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le ID d'une garderie selon ses informatiques uniques.
        /// </summary>
        /// <param name="nom">Le titre de la garderie.</param>
        /// <returns>Le ID de la garderie.</returns>    
        public int ObtenirIDGarderie(string nomGarderie)
        {
            SqlCommand command = new SqlCommand(" SELECT IdGarderie " +
                                                "   FROM T_Garderies " +
                                                "  WHERE Nom = @nom ", connexion);

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 100);

            nomParam.Value = nomGarderie;

            command.Parameters.Add(nomParam);

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
                throw new Exception("Erreur lors de l'obtention d'un id d'une garderie par son nom...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir une garderie selon ses informations uniques.
        /// </summary>
        /// <param name="nom">Nom de la garderie.</param>
        /// <returns>Le DTO de la garderie.</returns>
        public GarderieDTO ObtenirGarderie(string nomGarderie)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM T_Garderies " +
                                                " WHERE Nom = @nom ", connexion);

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 100);

            nomParam.Value = nomGarderie;

            command.Parameters.Add(nomParam);

            GarderieDTO uneGarderie;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                uneGarderie = new GarderieDTO(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                reader.Close();
            return uneGarderie;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'une garderie par son nom...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter une garderie.
        /// </summary>
        /// <param name="garderie">Le DTO de la garderie.</param>
        public void AjouterGarderie(GarderieDTO garderie)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " INSERT INTO T_Garderies (Nom, Adresse, Ville, Province, Telephone) " +
                                  " VALUES (@nom, @adresse, @ville, @province, @telephone) ";

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 100);
            SqlParameter adresseParam = new SqlParameter("@adresse", SqlDbType.VarChar, 200);
            SqlParameter villeParam = new SqlParameter("@ville", SqlDbType.VarChar, 100);
            SqlParameter provinceParam = new SqlParameter("@province", SqlDbType.VarChar, 50);
            SqlParameter telephoneParam = new SqlParameter("@telephone", SqlDbType.VarChar, 12);

            nomParam.Value = garderie.Nom;
            adresseParam.Value = garderie.Adresse;
            villeParam.Value = garderie.Ville;
            provinceParam.Value = garderie.Province;
            telephoneParam.Value = garderie.Telephone;

            command.Parameters.Add(nomParam);
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
                throw new DBUniqueException("Erreur lors de l'ajout d'une garderie...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de modifier une garderie.
        /// </summary>
        /// <param name="garderie">Le DTO de la garderie.</param>
        public void ModifierGarderie(GarderieDTO garderie)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " UPDATE T_Garderies " +
                                     " SET Adresse = @adresse, " +
                                     "     Ville = @ville, " +
                                     "     Province = @province, " +
                                     "     Telephone = @telephone " +
                                   " WHERE Nom = @nom ";

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 100);
            SqlParameter adresseParam = new SqlParameter("@adresse", SqlDbType.VarChar, 200);
            SqlParameter villeParam = new SqlParameter("@ville", SqlDbType.VarChar, 100);
            SqlParameter provinceParam = new SqlParameter("@province", SqlDbType.VarChar, 50);
            SqlParameter telephoneParam = new SqlParameter("@telephone", SqlDbType.VarChar, 12);

            nomParam.Value = garderie.Nom;
            adresseParam.Value = garderie.Adresse;
            villeParam.Value = garderie.Ville;
            provinceParam.Value = garderie.Province;
            telephoneParam.Value = garderie.Telephone;

            command.Parameters.Add(nomParam);
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
                throw new Exception("Erreur lors de la modification d'une garderie...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de supprimer une garderie.
        /// </summary>
        /// <param name="garderie">Le DTO de la garderie.</param>
        public void SupprimerGarderie(GarderieDTO garderie)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE " +
                                    " FROM T_Garderies " +
                                   " WHERE IdGarderie = @id ";

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);

            idParam.Value = ObtenirIDGarderie(garderie.Nom);

            command.Parameters.Add(idParam);

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
                    throw new DBRelationException("Impossible de supprimer la garderie.", e); // Départements associés.
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'une garderie...", ex);
            }

            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des garderies.
        /// </summary>
        public void ViderListeGarderie()
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE FROM T_Garderies";
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
                    throw new DBRelationException("Impossible de supprimer la garderie.", e); // Départements associés.
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'une garderie...", ex);
            }

            finally
            {
                FermerConnexion();
            }
        }

        #endregion
    }
}
