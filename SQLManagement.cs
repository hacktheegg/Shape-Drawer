using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectList
{
    public class SQLManagement
    {
        public static void CheckIfAnotherRow(int iteration)
        {
            string connectionString = "Data Source=ShapeHistory.db;Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            

            int lastValue = LastValue();
            int newValue = lastValue + 1;
            string sqlCommand;
            SQLiteCommand command;

            while (newValue <= iteration)
            {
                sqlCommand = "INSERT INTO Main (id) VALUES (" + newValue + ");";
                command = new SQLiteCommand(sqlCommand, connection);

                command.ExecuteNonQuery();

                newValue++;
            }
        }
        public static int LastValue()
        {
            // create a connection to the SQLite database
            string connectionString = "Data Source=ShapeHistory.db;Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            // create a SQL command to get the last value of a column
            string sqlCommand = "SELECT id FROM Main ORDER BY ROWID DESC LIMIT 1;";
            SQLiteCommand command = new SQLiteCommand(sqlCommand, connection);

            // execute the SQL command and retrieve the last value of the column
            object result = command.ExecuteScalar();

            int lastValue = Convert.ToInt32(result); // convert the result to the appropriate data type

            connection.Close();


            return lastValue;
        }

        public class Add
        {
            public static void Square(int iteration, Square square)
            {
                CheckIfAnotherRow(iteration);

                string connectionString = @"Data Source=ShapeHistory.db;Version=3;";
                SQLiteConnection connection = new SQLiteConnection(connectionString);
                connection.Open();

                string query = "UPDATE Main SET Shape = 'Square' WHERE id = '" + iteration.ToString() + "'";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
                
                query = "UPDATE Main SET ParamOne = '" + square.width.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                query = "UPDATE Main SET ParamTwo = '" + square.height.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
                
                query = "UPDATE Main SET ParamThree = '" + square.originPoint.Item1.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                query = "UPDATE Main SET ParamFour = '" + square.originPoint.Item2.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                


                connection.Close();
            }

            public static void Circle(int iteration, Circle circle)
            {
                CheckIfAnotherRow(iteration);

                string connectionString = @"Data Source=ShapeHistory.db;Version=3;";
                SQLiteConnection connection = new SQLiteConnection(connectionString);
                connection.Open();

                string query = "UPDATE Main SET Shape = 'Circle' WHERE id = '" + iteration.ToString() + "'";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                query = "UPDATE Main SET ParamOne = '" + circle.radius.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                query = "UPDATE Main SET ParamTwo = '" + circle.originPoint.Item1.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                query = "UPDATE Main SET ParamThree = '" + circle.originPoint.Item2.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();


                connection.Close();
            }

            public static void Triangle(int iteration, Triangle triangle)
            {
                CheckIfAnotherRow(iteration);

                string connectionString = @"Data Source=ShapeHistory.db;Version=3;";
                SQLiteConnection connection = new SQLiteConnection(connectionString);
                connection.Open();

                string query = "UPDATE Main SET Shape = 'Triangle' WHERE id = '" + iteration.ToString() + "'";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                query = "UPDATE Main SET ParamOne = '" + triangle.pointOne.Item1.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                query = "UPDATE Main SET ParamTwo = '" + triangle.pointOne.Item2.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                query = "UPDATE Main SET ParamThree = '" + triangle.pointTwo.Item1.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                query = "UPDATE Main SET ParamFour = '" + triangle.pointTwo.Item2.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                query = "UPDATE Main SET ParamFive = '" + triangle.pointThree.Item1.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                query = "UPDATE Main SET ParamSix = '" + triangle.pointThree.Item2.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();


                connection.Close();
            }

            public static void Line(int iteration, Line line)
            {
                CheckIfAnotherRow(iteration);

                string connectionString = @"Data Source=ShapeHistory.db;Version=3;";
                SQLiteConnection connection = new SQLiteConnection(connectionString);
                connection.Open();

                string query = "UPDATE Main SET Shape = 'Line' WHERE id = '" + iteration.ToString() + "'";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                query = "UPDATE Main SET ParamOne = '" + line.pointOne.Item1.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                query = "UPDATE Main SET ParamTwo = '" + line.pointOne.Item2.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                query = "UPDATE Main SET ParamThree = '" + line.pointTwo.Item1.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                query = "UPDATE Main SET ParamFour = '" + line.pointTwo.Item2.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();


                connection.Close();
            }

            public static void Board(int iteration, int width, int height)
            {
                CheckIfAnotherRow(iteration);

                string connectionString = @"Data Source=ShapeHistory.db;Version=3;";
                SQLiteConnection connection = new SQLiteConnection(connectionString);
                connection.Open();

                string query = "UPDATE Main SET Shape = 'Board' WHERE id = '" + iteration.ToString() + "'";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                query = "UPDATE Main SET ParamOne = '" + width.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();

                query = "UPDATE Main SET ParamTwo = '" + height.ToString() + "' WHERE id = '" + iteration.ToString() + "'";
                command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();


                connection.Close();
            }
        }

        public static void CheckIfFile()
        {
            if (!System.IO.File.Exists("ShapeHistory.db"))
            {

                string connectionString = @"Data Source=ShapeHistory.db;Version=3;";
                SQLiteConnection connection = new SQLiteConnection(connectionString);
                connection.Open();

                string query = "CREATE TABLE Main (id INTEGER, Shape TEXT, " +
                    "ParamOne INTEGER, ParamTwo INTEGER, ParamThree INTEGER, " +
                    "ParamFour INTEGER, ParamFive INTEGER, ParamSix INTEGER)";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public static Tuple<string, int, int, int, int, int, int> RetrieveRow(int iteration)
        {
            Tuple<string, int, int, int, int, int, int> values = Tuple.Create("NULL", -1, -1, -1, -1, -1, -1);

            string connectionString = @"Data Source=ShapeHistory.db;Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            SQLiteCommand query = new SQLiteCommand(connection);
            query.CommandText = "SELECT * FROM Main WHERE id = '" + iteration.ToString() + "'";
            SQLiteDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                values = Tuple.Create(
                    reader.IsDBNull(1) ? "NULL" : reader.GetString(1),
                    reader.IsDBNull(2) ? -1 : reader.GetInt32(2),
                    reader.IsDBNull(3) ? -1 : reader.GetInt32(3),
                    reader.IsDBNull(4) ? -1 : reader.GetInt32(4),
                    reader.IsDBNull(5) ? -1 : reader.GetInt32(5),
                    reader.IsDBNull(6) ? -1 : reader.GetInt32(6),
                    reader.IsDBNull(7) ? -1 : reader.GetInt32(7)
                );

                //values = Tuple.Create(reader.GetString(1), values.Item2, values.Item3, values.Item4, values.Item5, values.Item6, values.Item7);
                //values = Tuple.Create(values.Item1, reader.GetInt32(2), values.Item3, values.Item4, values.Item5, values.Item6, values.Item7);
                //values = Tuple.Create(values.Item1, values.Item2, reader.GetInt32(3), values.Item4, values.Item5, values.Item6, values.Item7);
                //values = Tuple.Create(values.Item1, values.Item2, values.Item3, reader.GetInt32(4), values.Item5, values.Item6, values.Item7);
                //values = Tuple.Create(values.Item1, values.Item2, values.Item3, values.Item4, reader.GetInt32(5), values.Item6, values.Item7);
                //values = Tuple.Create(values.Item1, values.Item2, values.Item3, values.Item4, values.Item5, reader.GetInt32(6), values.Item7);
                //values = Tuple.Create(values.Item1, values.Item2, values.Item3, values.Item4, values.Item5, values.Item6, reader.GetInt32(7));
            }

            connection.Close();



            return values;
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
