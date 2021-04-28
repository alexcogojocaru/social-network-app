/**************************************************************************
 *                                                                        *
 *  File:        IDatabaseManager.cs                                      *
 *  Copyright:   (c) 2021, Cojocaru Daniel-Alexandru                      *
 *  E-mail:      alex.cojocaru73@gmail.com                                *
 *  Description: Interface for a database manager.                        *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using System.Collections.Generic;

namespace Interfaces
{
    public interface IDatabaseManager
    {
        /// <summary>
        /// General method that connects the app to the database
        /// </summary>
        /// <param name="connectionStrings">the C# connection string format has to be passed</param>
        void Connect(string connectionStrings);

        /// <summary>
        /// Opens the connection to the database
        /// </summary>
        void OpenConnection();

        /// <summary>
        /// Closes the connection to the database
        /// </summary>
        void CloseConnection();

        /// <summary>
        /// Executes the given query on the database
        /// </summary>
        /// <param name="command">the query command</param>
        /// <returns>
        /// true - if the command was executed successfully<para/>
        /// false - if the command couldn't be executed
        /// </returns>
        bool ExecuteQuery(string command);

        /// <summary>
        /// Executes the given query on the database
        /// </summary>
        /// <param name="command">the query command</param>
        /// <returns>
        /// a list of retrieved rows
        /// </returns>
        List<string> RetrieveQuery(string command);

        bool InsertQuery(string command);
    }
}
