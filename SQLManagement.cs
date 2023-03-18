﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape_Drawer
{
    public class SQLManagement
    {
        public static void AddShape(int shapeNo, int iteration)
        {
            // create a connection to the SQLite database
            string connectionString = "Data Source=ShapeHistory.db;Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            // create a SQL command to get the last value of a column
            string columnName = "id";
            string sqlCommand = $"SELECT {columnName} FROM Main ORDER BY ROWID DESC LIMIT 1;";
            SQLiteCommand command = new SQLiteCommand(sqlCommand, connection);

            // execute the SQL command and retrieve the last value of the column
            object result = command.ExecuteScalar();



            int lastValue = Convert.ToInt32(result); // convert the result to the appropriate data type
            int newValue = lastValue + 1; // set the initial value to the next integer after the last value

            // loop until the new value is greater than the minimum value
            while (newValue <= iteration)
            {
                // create a SQL command to insert the new value into the table
                sqlCommand = $"INSERT INTO Main ({columnName}) VALUES ({newValue});";
                command = new SQLiteCommand(sqlCommand, connection);

                // execute the SQL command to insert the new value
                command.ExecuteNonQuery();

                // increment the new value
                newValue++;
            }

            // use the last value as needed


        }



        //public static string[] RetrieveDirectories()
        //{

        //}

        /*connectionString = @"Data Source=data\GameDirectories.db;Version=3;";
        connection = new SQLiteConnection(connectionString);
        connection.Open();*/

        /*for(int i = 0; i < list.Length; i++)
        {

            string query = "UPDATE " + whichLibrary[0] + " SET " + whichLibrary[1] + " = '" + list[i] + "' WHERE  id ='%'";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.ExecuteNonQuery();

        }*/
        /*
        for (int i = 0; i < list.Length; i++)
        {
            command.Parameters.Add(new SQLiteParameter("@" + whichLibrary[1], list[i]));
            command.Parameters.Add(new SQLiteParameter("@id", i + 1));
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }
        */
    }
}
