/**************************************************************************
 *                                                                        *
 *  File:        FileReader.cs                                            *
 *  Copyright:   (c) 2021, Cojocaru Daniel-Alexandru                      *
 *  E-mail:      alex.cojocaru73@gmail.com                                *
 *  Description: Manages the file input and fetches the information       *
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
using System.IO;

namespace Commons
{
    public class FileReader
    {
        public static List<string> ReadLines(string filePath)
        {
            StreamReader file = new StreamReader(filePath);
            List<string> credentials = new List<string>();
            string line;

            while ((line = file.ReadLine()) != null)
            {
                credentials.Add(line);
            }

            return credentials;
        }

        public static string Read(string filePath)
        {
            StreamReader file = new StreamReader(filePath);

            return file.ReadToEnd();
        }
    }
}
