using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog = UCASSys.Program;
using System.Data.OleDb;

namespace UCASSys.DB
{
    static class Program
    {
        static void Main(string[] args)
        {
            Prog.log.console("UCASSys.DB", "  ==  UCAS System Database Query");
            Prog.log.console("UCASSys.DB", "  ==    To quit, press Ctrl + C");
            Prog.log.console("UCASSys.DB", "  ==");

            Prog.log.console("UCASSys.DB", "Using database: " + Prog.dbInt.currentDatabase);
            Console.Write("Change database (y/N)? ");
            if (Program.getInput().Trim().ToLower() == "y")
            {
                while (!Prog.dbInt.is_connected)
                {
                    Program.openDatabase();
                }
            }
            else
            {
                Prog.dbInt.checkDatabase();
            }

            Classes.StatusMessage loginResult;
            do
            {
                loginResult = login();
                if (!loginResult)
                {
                    Prog.log.console("UCASSys.DB", loginResult.Message);
                }
            } while (!loginResult);

            do
            {
                query();
            } while (true);
        }

        public static void openDatabase()
        {
            Console.Write("Open Database: ");
            Prog.dbInt.currentDatabase = Console.ReadLine().Trim();
            Prog.dbInt.checkDatabase();
            if (!Prog.dbInt.is_connected)
            {
                Console.WriteLine("Failed to open database: " + Prog.dbInt.currentDatabase);
            }
        }
        public static Classes.StatusMessage login()
        {
            Classes.StatusMessage result = new Classes.StatusMessage(false);
            Console.Write("Username: ");
            String username = Program.getInput();
            Console.Write("Password: ");
            String password = Program.getInput(true);
            if (!Prog.userCtrl.is_authenticatedName(password, username))
            {
                result.Message = "Username/password was incorrect!";
                result.Data = 2;
                return result;
            }
            Prog.userCtrl.login(password, username, -1, true);
            if (!Prog.userCtrl.is_admin)
            {
                result.Message = "User must be admin to access this service!";
                result.Data = 3;
                return result;
            }
            result.is_Success = true;
            return result;
        }
        private static string getInput(bool maskChars = false)
        {
            string input = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    input += key.KeyChar;
                    if (!maskChars)
                    {
                        Console.Write(key.KeyChar);
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input = input.Substring(0, (input.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);
            Console.Write("\r\n");
            return input.Trim();
        }
        public static void query()
        {
            Console.Write("Enter Query: ");
            String queryString = Program.getInput();
            if (!Prog.userCtrl.is_admin)
            {
                Prog.log.console("UCASSys.DB", "User must be admin to access this service!");
                return;
            }
            if (!queryString.Contains("SELECT"))
            {
                Prog.log.console("UCASSys.DB", "Only SELECT queries can be made.");
                return;
            }
            using (OleDbCommand query = Prog.dbInt.preparedStmt())
            {
                try
                {
                    query.CommandText = queryString;
                    using (OleDbDataReader data = query.ExecuteReader())
                    {
                        if (!data.HasRows)
                        {
                            Prog.log.console("UCASSys.DB", "No rows returned.");
                        }
                        else
                        {
                            using (System.Data.DataTable table = data.GetSchemaTable())
                            {
                                System.Data.DataColumn columns = table.Columns["ColumnName"];
                                System.Data.DataColumn colLength = table.Columns["ColumnSize"];
                                List<string> fields = new List<string>();
                                foreach (System.Data.DataRow row in table.Rows)
                                {
                                    fields.Add(row[columns].ToString());
                                }
                                Console.WriteLine(string.Join(" | ", fields));
                            }
                            while (data.Read())
                            {
                                printRecord(data);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Prog.log.console("UCASSys.DB", "Query failed. Details: ");
                    Console.Write(ex.Message + "\r\n");
                }
            }
        }
        public static void printRecord(OleDbDataReader data)
        {
            List<string> fields = new List<string>();
            for (int i = 0; i < data.FieldCount; i++)
            {
                fields.Add(data.GetValue(i).ToString());
            }

            Console.WriteLine(string.Join(" | ", fields));
        }
    }
}
