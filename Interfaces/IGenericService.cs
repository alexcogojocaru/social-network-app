/**************************************************************************
 *                                                                        *
 *  File:        IGenericService.cs                                       *
 *  Copyright:   (c) 2021, Cojocaru Daniel-Alexandru                      *
 *  E-mail:      alex.cojocaru73@gmail.com                                *
 *  Description: An interface that contains generic operations for the    *
 *               services's dictionaries.                                 *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

namespace Interfaces
{
    public interface IGenericService
    {
        /// <summary>
        /// Deletes all data that a service holds
        /// </summary>
        void PurgeData();
    }
}
