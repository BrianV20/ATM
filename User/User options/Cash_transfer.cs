using System;
using System.Collections.Generic;
using System.Linq;
using System
    .IO;
using System.Text;
using System.Threading.Tasks;

namespace ATM.User.User_options
{
    internal class Cash_transfer
    {
        public static void cash_trans(string[] acc_user)
        {
            Console.Clear();
            int val = Utilities.int_validation("Enter the amount you want to transfer in multiples of 500: ");


            // VERIFICAMOS QUE SE INGRESE UN INT Y QUE ELNRO DE CUENTA EXISTA.


            Console.WriteLine("Enter the account number to which you want to transfer: "); string aux1 = Console.ReadLine();
            int val1;
            string[] filas = File.ReadAllLines(@"C:\Users\Admin\Desktop\ATM\Accounts_list.txt", Encoding.UTF8);
            while (!(int.TryParse(aux1, out val1)) || (filas[val1] == null))
            {
                Console.WriteLine("Invalid account number. Try again.");
                Console.Clear();
                Console.WriteLine("Enter the account number to which you want to transfer: "); aux1 = Console.ReadLine();
            }

            int rwf = 0;
            string[] acc_to_transfer = Utilities.search_account(0, val1.ToString(), ref rwf);


            Console.Clear();
            Console.WriteLine($"You wish to deposit ${val} in account held by " +
                $"{acc_to_transfer[1]}; If this information is correct please re-enter the account number:");

            string aux2 = Console.ReadLine();
            int val2;
            while (!int.TryParse(aux2, out val2) || (filas[val2] == null))
            {
                Console.WriteLine("Invalid account number. Try again.");
                Console.Clear();
                Console.WriteLine("Enter the account number to which you want to transfer (last): "); aux2 = Console.ReadLine();
            }


            // WE TRANSFER THE CASH
            int a = int.Parse(acc_to_transfer[3]);
            a += val;
            acc_to_transfer[3] = a.ToString();
            string fa = acc_to_transfer.ToString();

            Utilities.Update_Acc_and_Redo_AccList(fa, ref rwf);


            Console.Clear();
            Console.WriteLine("     Transaction confirmed.");
            Console.WriteLine("\nDo you wish to print a receipt (Y/N)?"); string o = Console.ReadLine();
            if (o == "Y")
            {
                Console.WriteLine($"\nAccount #{acc_user[0]}\nDate: {DateTime.Now.ToShortDateString()}" +
                    $"\nAmount transferred: {val1}\nBalance: {acc_user[3]}");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
