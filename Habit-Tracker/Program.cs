using System;
using Microsoft.Data.Sqlite;

namespace Habit_Tracker
{
    class Program

    {

        static string connectionString = @"Data SOurce=habit-Tracker.db";
        static void Main(string[] args)
        {

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS drinking_water (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT
                        Date TEXT,
                        Quantity INTEGER
                        )";

                tableCmd.ExecuteNonQuery();

                connection.Close();

            }

            GetUserInput();
          

        }

        static void GetUserInput ()
        {
            Console.Clear();
            bool closeApp = false;
            while (closeApp == false)
            {
                Console.WriteLine("\n\nMAIN MENU");
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("\nType 0 to Close Application.");
                Console.WriteLine("Type 1 to view all records.");
                Console.WriteLine("Type 2 to insert record.");
                Console.WriteLine("Type 3 to delete record.");
                Console.WriteLine("Type 4 to update record");
                Console.WriteLine("----------------------------------\n");

                string commandInput = Console.ReadLine();

                switch (command)
                {
                    case 0:
                        Console.WriteLine("\nGoodbye!\n");
                        closeApp = true;
                        break;
                    case 1:
                        GetAllRecords();
                        break;
                    case 2:
                        Insert();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        Update();
                        break;
                    default:
                        Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.\n");
                        break;
                }

       
          

            }
        }

        private static void Insert()
        {
            string date = GetDateInput();

            int quantity = GetNumberInput("\n\nPlease Insert number of glasses. Only full numbers allowed.\n\n");

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    $"INSERT INTO drinking_water(date, quantity) VALUES('{date}', {quantity})";
                tableCmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        internal static string GetDateInput()
        {
            Console.WriteLine("\n\nPlease insert the date: dd-mm-yy. Type 0 to retirn to main menu.");

            string dateInput = Console.ReadLine();

            if (dateInput =="0") GetUserInput();

            return dateInput;

            internal static int GetNumberInput(string message)
                Console.WriteLine(message);
            string numberInput = Console.ReadLine();
            
            if (numberInput == "0") GetUserInput();
            
            int finalInput = Convert.ToInt32(numberInput);

            return finalInput;
        }
    }
}
//Leaving off at 18 minutes, application currently cannot run in current form. Need to tidy up code.