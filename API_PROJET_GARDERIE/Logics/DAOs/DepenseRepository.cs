﻿using System;
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
    /// Classe représentant le répository d'une Dépense.
    /// </summary>
    public class DepenseRepository : Repository
    {
        #region AttributsProprietes

        /// <summary>
        /// Instance unique du repository.
        /// </summary>
        private static DepenseRepository instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static DepenseRepository Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new DepenseRepository();
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
        private DepenseRepository() :base() {}

        #endregion

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des dépenses d'une Garderie.
        /// </summary>
        /// <param name="nomGarderie">Le nom de la garderie.</param>
        /// <returns>Liste des dépenses.</returns>
        public List<DepenseDTO> ObtenirListeDepense(string nomGarderie)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM T_Depenses " +
                                                "  WHERE IdGarderie = @idGarderie", connexion);

            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.Int);

            idGarderieParam.Value = GarderieRepository.Instance.ObtenirIDGarderie(nomGarderie);

            command.Parameters.Add(idGarderieParam);

            List<DepenseDTO> liste = new List<DepenseDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DepenseDTO depense = new DepenseDTO(reader.GetString(1), reader.GetDouble(2), reader.GetDouble(3));
                    liste.Add(depense);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention de la liste des dépenses par le nom de la Garderie...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir une dépense selon ses informations uniques.
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie.</param>
        /// <param name="dateTemps">La date de la dépense.</param>
        /// <returns>Le DTO de la dépense.</returns>
        public int ObtenirIDDepense(string nomGarderie, string dateTemps)
        {
            SqlCommand command = new SqlCommand(" SELECT IdDepense " +
                                                " FROM T_Depenses " +
                                                " WHERE DateTemps = @dateTemps " +
                                                "   AND IdGarderie = @idGarderie", connexion);

            SqlParameter dateTempsDepenseParam = new SqlParameter("@dateTemps", SqlDbType.DateTime);
            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.Int);

            dateTempsDepenseParam.Value = dateTemps;
            idGarderieParam.Value = GarderieRepository.Instance.ObtenirIDGarderie(nomGarderie);

            command.Parameters.Add(dateTempsDepenseParam);
            command.Parameters.Add(idGarderieParam);

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
                throw new Exception("Erreur lors de l'obtention d'un id d'une dépense par sa date et sa Garderie...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir une dépense selon ses informations uniques.
        /// </summary>
        /// <param name="nomGarderie">Nom de la garderie.</param>
        /// <param name="dateTemps">Date de la dépense.</param>
        /// <returns>Le DTO de la dépense.</returns>
        public DepenseDTO ObtenirDepense(string nomGarderie, string dateTemps)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM T_Depenses " +
                                                " WHERE DateTemps = @dateTemps " +
                                                "   AND IdGarderie = @idGarderie", connexion);

            SqlParameter dateTempsDepenseParam = new SqlParameter("@dateTemps", SqlDbType.DateTime);
            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.Int);

            dateTempsDepenseParam.Value = dateTemps;
            idGarderieParam.Value = GarderieRepository.Instance.ObtenirIDGarderie(nomGarderie);

            command.Parameters.Add(dateTempsDepenseParam);
            command.Parameters.Add(idGarderieParam);

            DepenseDTO uneDepense;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                uneDepense = new DepenseDTO(reader.GetString(1), reader.GetDouble(2), reader.GetDouble(3));
                reader.Close();
                return uneDepense;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'une dépense par sa date et sa Garderie...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter une dépense.
        /// </summary>
        /// <param name="nomGarderie">Le nom de la Garderie.</param>
        /// <param name="depenseDTO">Le DTO du departement.</param>
        public void AjouterDepense(string nomGarderie, DepenseDTO depenseDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " INSERT INTO T_Depenses (DateTemps, Montant, IdGarderie, IdCategorieDepense, IdCommerce) " +
                                  " VALUES (@dateTemps, @montant, @idGarderie, @idCategorieDepense, @idCommerce) ";

            SqlParameter dateTempsParam = new SqlParameter("@dateTemps", SqlDbType.DateTime);
            SqlParameter montantParam = new SqlParameter("@montant", SqlDbType.Money);
            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.Int);
            SqlParameter idCategorieDepenseParam = new SqlParameter("@idCategorieDepense", SqlDbType.Int);
            SqlParameter idCommerceParam = new SqlParameter("@idCommerce", SqlDbType.Int);

            dateTempsParam.Value = depenseDTO.DateTemps;
            montantParam.Value = depenseDTO.Montant;
            idGarderieParam.Value = GarderieRepository.Instance.ObtenirIDGarderie(nomGarderie);
            idCategorieDepenseParam.Value = CategorieDepenseRepository.Instance.ObtenirIDCategorieDepense(depenseDTO.categorieDepenseDTO.Description);
            idCommerceParam.Value = CommerceRepository.Instance.ObtenirIDCommerce(depenseDTO.commerceDTO.Description);

            command.Parameters.Add(dateTempsParam);
            command.Parameters.Add(montantParam);
            command.Parameters.Add(idGarderieParam);
            command.Parameters.Add(idCategorieDepenseParam);
            command.Parameters.Add(idCommerceParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBUniqueException("Erreur lors de l'ajout d'une dépense...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        #endregion
    }
}
