using System;
using System.IO;

namespace AuthenticationSystem
{
    class Program
    {
        // Extracts a specific comma-separated token by 1-based field index
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }

        // Reads up to 5 user credentials from the file into parallel arrays
        static void readData(string path, string[] names, string[] password)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    names[x] = parseData(record, 1);
                    password[x] = parseData(record, 2);
                    x++;
                    if (x >= 5)
                    {
                        break;
                    }
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }

        // Validates user credentials against loaded records
        static void signIn(string n, string p, string[] names, string[] password)
        {
            bool flag = false;
            for (int x = 0; x < 5; x++)
            {
                if (n == names[x] && p == password[x])
                {
                    Console.WriteLine("Valid User");
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            Console.ReadKey();
        }

        // Appends a new user record (name,password) to the file
        static void signUp(string path, string n, string p)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
        }

        // Displays the user menu and reads the selected option
        static int menu()
        {
            Console.WriteLine("1. Sign In");
            Console.WriteLine("2. Sign Up");
            Console.WriteLine("3. Exit");
            Console.Write("Enter Option: ");
            int option = int.Parse(Console.ReadLine());
            return option;
        }

        static void Main(string[] args)
        {
            // Note: Use "textfile.txt" for local execution, or set to your lab directory:
            // string path = @"G:\OOP 2022\BootingCSharp\textfile.txt";
            string path = "textfile.txt";

            string[] names = new string[5];
            string[] password = new string[5];
            int option;

            do
            {
                readData(path, names, password);
                Console.Clear();
                option = menu();
                Console.Clear();

                if (option == 1)
                {
                    Console.WriteLine("Enter Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();
                    signIn(n, p, names, password);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter New Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter New Password: ");
                    string p = Console.ReadLine();
                    signUp(path, n, p);
                }
            }
            while (option < 3);

            Console.Read();
        }
    }
}