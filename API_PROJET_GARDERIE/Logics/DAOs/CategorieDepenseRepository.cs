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
        private CategorieDepenseRepository() :base() {}

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
                    CategorieDepenseDTO categorieDepense = new CategorieDepenseDTO(reader.GetString(1), reader.GetDouble(2));
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

        #endregion
    }
}
