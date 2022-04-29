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
    /// Classe représentant le répository d'une CategorieDepense.
    /// </summary>
    public class CategorieDepenseRepository : Repository
    {
        #region AttributsProprietes

        /// <summary>
        /// Instance unique du repository.
        /// </summary>
        private static CategorieDepenseRepository instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static CategorieDepenseRepository Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new CategorieDepenseRepository();
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
        private CategorieDepenseRepository() : base() { }

        #endregion

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des CategorieDepense.
        /// </summary>
        /// <returns>Liste des CategorieDepense.</returns>
        public List<CategorieDepenseDTO> ObtenirListeCategorieDepense()
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM T_CategoriesDepense", connexion);

            List<CategorieDepenseDTO> liste = new List<CategorieDepenseDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CategorieDepenseDTO categorieDepense = new CategorieDepenseDTO(reader.GetString(1), (double)reader.GetDecimal(2));
                    liste.Add(categorieDepense);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention de la liste des categories de dépense...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir une CategorieDepense.
        /// </summary>
        /// <param name="descriptionCategorieDepense">La description de la Categorie de Depense.</param>
        /// <returns>Le DTO de la CategorieDepense.</returns>
        public int ObtenirIDCategorieDepense(string descriptionCategorieDepense)
        {
            SqlCommand command = new SqlCommand(" SELECT IdCategorieDepense " +
                                                " FROM T_CategoriesDepense " +
                                                " WHERE Description = @description ", connexion);

            SqlParameter descriptionCategorieDepenseParam = new SqlParameter("@description", SqlDbType.VarChar, 100);

            descriptionCategorieDepenseParam.Value = descriptionCategorieDepense;

            command.Parameters.Add(descriptionCategorieDepenseParam);

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
                throw new Exception("Erreur lors de l'obtention d'un id d'une CategorieDepense par sa description...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }
        /// <summary>
        /// Méthode de service permettant d'obtenir une categorieDepense selon ses informations uniques.
        /// </summary>
        /// <param name="descriptionCategorieDepense">Nom du commerce.</param>
        /// <returns>Le DTO du commerce.</returns>
        public CategorieDepenseDTO ObtenirCategorieDepense(string descriptionCategorieDepense)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM T_CategoriesDepense " +
                                                " WHERE Description = @description", connexion);

            SqlParameter nomParam = new SqlParameter("@description", SqlDbType.VarChar, 50);

            nomParam.Value = descriptionCategorieDepense;

            command.Parameters.Add(nomParam);

            CategorieDepenseDTO uneCategorieDepense;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                uneCategorieDepense = new CategorieDepenseDTO(reader.GetString(1), (double)reader.GetDecimal(2));
                reader.Close();
                return uneCategorieDepense;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'une CategorieDepense par sa description...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un Commerce.
        /// </summary>
        /// <param name="categorieDepenseDTO">Le DTO du commerce.</param>
        public void AjouterCategorieDepense(CategorieDepenseDTO categorieDepenseDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " INSERT INTO T_CategoriesDepense (Description, Pourcentage) " +
                                  " VALUES (@description, @pourcentage) ";

            SqlParameter descriptionParam = new SqlParameter("@description", SqlDbType.VarChar, 50);
            SqlParameter pourcentageParam = new SqlParameter("@pourcentage", SqlDbType.Decimal); ;

            pourcentageParam.Precision = 18;
            pourcentageParam.Scale = 8;

            descriptionParam.Value = categorieDepenseDTO.Description;
            pourcentageParam.Value = categorieDepenseDTO.Pourcentage;


            command.Parameters.Add(descriptionParam);
            command.Parameters.Add(pourcentageParam);


            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBUniqueException("Erreur lors de l'ajout d'une CategorieDepense...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de modifier une categorieDepense.
        /// </summary>
        /// <param name="categorieDepenseDTO">Le DTO categorieDepense.</param>
        public void ModifierCategorieDepense(CategorieDepenseDTO categorieDepenseDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " UPDATE T_CategoriesDepense " +
                                     "SET     Pourcentage = @pourcentage " +
                                   " WHERE Description = @description ";

            SqlParameter descriptionParam = new SqlParameter("@description", SqlDbType.VarChar, 50);
            SqlParameter pourcentageParam = new SqlParameter("@pourcentage", SqlDbType.Decimal);

            pourcentageParam.Precision = 18;
            pourcentageParam.Scale = 8;

            descriptionParam.Value = categorieDepenseDTO.Description;
            pourcentageParam.Value = categorieDepenseDTO.Pourcentage;


            command.Parameters.Add(descriptionParam);
            command.Parameters.Add(pourcentageParam);


            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la modification d'une categorieDepense...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de supprimer une categorieDepense.
        /// </summary>
        /// <param name="categorieDepenseDTO">Le DTO du categorieDepense.</param>
        public void SupprimerCategorieDepense(CategorieDepenseDTO categorieDepenseDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE " +
                                    " FROM T_CategoriesDepense " +
                                   " WHERE IdCategorieDepense = @id ";

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);

            idParam.Value = ObtenirIDCategorieDepense(categorieDepenseDTO.Description);

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
                    throw new DBRelationException("Impossible de supprimer le commerce.", e); // Dépenses associés.
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'une categorieDepense...", ex);
            }

            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des categorieDepenses.
        /// </summary>
        public void ViderListeCategorieDepense()
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE FROM T_CategoriesDepense";
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
                    throw new DBRelationException("Impossible de supprimer les categoriesDepenses.", e); // Dépenses associés.
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'une categorieDepense...", ex);
            }

            finally
            {
                FermerConnexion();
            }
        }

        #endregion
    }
}