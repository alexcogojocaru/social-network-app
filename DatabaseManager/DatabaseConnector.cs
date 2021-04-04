/**************************************************************************
 *                                                                        *
 *  File:        DatabaseConnector.cs                                     *
 *  Copyright:   (c) 2021, Cojocaru Daniel-Alexandru                      *
 *  E-mail:      alex.cojocaru73@gmail.com                                *
 *  Description: Singleton class that manages the CRUD operations.        *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using Npgsql;
using Interfaces;
using System.Collections.Generic;

namespace DatabaseManager
{
    public class DatabaseConnector : IDatabaseManager
    {
        #region Static Fields
        private static DatabaseConnector _instance = null;
        #endregion

        #region Fields
        private NpgsqlConnection _conn;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        DatabaseConnector()
        {
            
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Creates a DatabaseConnector instance based on the singleton design pattern
        /// </summary>
        /// <returns>A DatabaseConnector instance</returns>
        public static DatabaseConnector GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DatabaseConnector();
            }

            return _instance;
        }

        /// <summary>
        /// General method that connects the app to the database
        /// </summary>
        /// <param name="connectionStrings">the C# connection string format has to be passed</param>
        public void Connect(string connectionStrings)
        {
            _conn = new NpgsqlConnection(connectionStrings);
        }

        /// <summary>
        /// Opens the connection to the database <para/>
        /// The exceptions are not treated inside the implemented method
        /// </summary>
        public void OpenConnection()
        {
            _conn.Open();
        }

        /// <summary>
        /// Closes the connection to the database <para/>
        /// The exceptions are not treated inside the implemented method
        /// </summary>
        public void CloseConnection()
        {
            _conn.Close();
        }

        /// <summary>
        /// Executes the given query on the database <para/>
        /// The exceptions are not treated inside the implemented method
        /// </summary>
        /// <param name="command">the query command</param>
        /// <returns>
        /// true - if the command was executed successfully<para/>
        /// false - if the command couldn't be executed
        /// </returns>
        public bool ExecuteQuery(string command)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Executes the given query on the database <para/>
        /// The exceptions are not treated inside the implemented method
        /// </summary>
        /// <param name="command">the query command</param>
        /// <returns>
        /// a list of retrieved rows
        /// </returns>
        public List<string> RetrieveQuery(string command)
        {
            List<string> queries = new List<string>();

            using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(command, _conn))
            {
                NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    queries.Add(reader.GetString(0));
                }
            }

            return queries;
        }
        #endregion
    }
}
