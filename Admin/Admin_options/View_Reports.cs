using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Admin.Admin_options
{
    internal class View_Reports
    {
        public static void view()
        {
            string space = "      ";
            Console.Clear();
            Console.WriteLine($"{space}V I E W   R E P O R T S");
            Console.WriteLine($"{space}1---Accounts By Amount.\n{space}2---Accounts By Date.");
            int opc = Utilities.int_validation("Your option: ");
            
            switch(opc)
            {
                case 1:
                    {
                        byAmount();
                        break;
                    }
                case 2:
                    {
                        byDate();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid option.");
                        break;
                    }
            }
        }

        public static void byAmount()
        {
            string space = "      ";
            Console.Clear();
            Console.WriteLine($"{space}V I E W   R E P O R T S --> Accounts by amount.");
            int min = Utilities.int_validation("\nEnter the minimum amount: ");
            if(min < 0) { min = 0;}

            Console.WriteLine( Environment.NewLine);

            int max = Utilities.int_validation("Enter the maximum amount: ");


            string[] filas = System.IO.File.ReadAllLines(@"C:\Users\Admin\Desktop\ATM\Accounts_list", Encoding.UTF8);
            string[] found_accounts = new string[10];

            foreach(string acc in filas)
            {
                string[] data = acc.Split(',');
                if ((int.Parse(data[3]) >= min) && (int.Parse(data[3]) <= max)) 
                { 
                    found_accounts.Append(acc); 
                }
            }

            show_found_accounts(found_accounts);
        }

        public static void byDate() //todo
        {
            string sd = Utilities.date_validation("Enter the starting date: ");
            string ed = Utilities.date_validation("Enter the ending date: ");


            string[] filas = System.IO.File.ReadAllLines(@"C:\Users\Admin\Desktop\ATM\Accounts_list", Encoding.UTF8);
            string[] found_accounts = new string[10];

            /*/foreach(string acc in filas)
            {
                string[] data = acc.Split(',');
                if()
            }/*/
        }

        public static void show_found_accounts(string[] fa)
        {
            Console.WriteLine("====== SEARCH RESULTS ======");
            Console.WriteLine("\nAccount ID  Login  Password  Balance  Status\n");
            foreach(string acc in fa)
            {
                Console.WriteLine($"{acc[0]}     {acc[1]}  {acc[2]}  {acc[3]}  {acc[4]}");
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
