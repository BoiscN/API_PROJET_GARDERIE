
using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using API_PROJET_GARDERIE.Logics.DTOs;
using API_PROJET_GARDERIE.Logics.Exceptions;
namespace API_PROJET_GARDERIE.Logics.DAOs
{
    /// <summary>
    /// Classe représentant le répository d'un commerce.
    /// </summary>
    public class CommerceRepository : Repository
    {
        #region AttributsProprietes

        /// <summary>
        /// Instance unique du repository.
        /// </summary>
        private static CommerceRepository instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static CommerceRepository Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new CommerceRepository();
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
        private CommerceRepository() : base() { }

        #endregion

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des commerces.
        /// </summary>
        /// <returns>Liste des commerces.</returns>
        public List<CommerceDTO> ObtenirListeCommerce()
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM T_Commerces", connexion);

            List<CommerceDTO> liste = new List<CommerceDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CommerceDTO commerce = new CommerceDTO(reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    liste.Add(commerce);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention de la liste des commerces...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un commerce.
        /// </summary>
        /// <param name="descriptionCommerce">La description du commerce.</param>
        /// <returns>Le DTO du commerce.</returns>
        public int ObtenirIDCommerce(string descriptionCommerce)
        {
            SqlCommand command = new SqlCommand(" SELECT IdCommerce " +
                                                " FROM T_Commerces " +
                                                " WHERE Description = @description ", connexion);

            SqlParameter descriptionCommerceParam = new SqlParameter("@description", SqlDbType.VarChar, 50);

            descriptionCommerceParam.Value = descriptionCommerce;

            command.Parameters.Add(descriptionCommerceParam);

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
                throw new Exception("Erreur lors de l'obtention d'un id d'un commerce par sa description...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        #endregion
    }
}

