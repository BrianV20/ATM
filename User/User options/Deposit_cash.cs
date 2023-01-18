using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.User.User_options
{
    internal class Deposit_cash
    {
        public static void depo_cash(string[] acc_user)
        {
            Console.Clear();
            long val = Utilities.long_validation("Enter the amount to deposit: ");


            // WE DEPOSIT THE CASH  
            int row_where_found = 0;
            string[] f = Utilities.search_account(0, acc_user[0], ref row_where_found);

            long a = int.Parse(f[3]);
            a += val;
            f[3] = a.ToString();
            string fa = f.ToString();

            Utilities.Update_Acc_and_Redo_AccList(fa, ref row_where_found);

            Console.WriteLine("\nCash deposited succesfully.");
            Console.WriteLine("\nDo you wish to print a receipt (Y/N)?"); string o = Console.ReadLine();
            if (o == "Y")
            {
                Console.WriteLine($"\nAccount #{acc_user[0]}\nDate: {DateTime.Now.ToShortDateString()}" +
                    $"\nDeposited: {val}\nBalance: {acc_user[3]}");
                Console.ReadKey();
                Console.Clear();
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
