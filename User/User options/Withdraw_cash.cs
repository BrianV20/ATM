using ATM.Admin_options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class Withdraw_cash
    {
        public static void withd_cash(string[] acc_user) //passing the acc as param, now we can operate with the 
        {                                                    // acc inside this class. kinda cheap, but it is what it is
            Console.Clear();
            Console.WriteLine("\n     a) Fast cash.\n     b) Normal cash." +
                "     Please select a mode of withdrawal:"); string opc = Console.ReadLine();

            if (opc == "a")
            {
                Fast_cash(acc_user);
            }
            else if (opc == "b")
            {
                Normal_cash(acc_user);
            }
            else
            {
                Console.WriteLine("Invalid option. Please select again.");
                withd_cash(acc_user);
            }
        }

        private static void Fast_cash(string[] acc_user)
        {
            Console.Clear();
            int value = Utilities.int_validation("\n1----500\r\n2----1000\r\n3----2000\r\n" +
                "4----5000\r\n5----10000\r\n6----15000\r\n7----20000\nEnter your option: ", "Invalid option.");
            int val_to_wit;

            switch(value)
            {
                case 1: { val_to_wit = 500; break; }
                case 2: { val_to_wit = 1000; break; }
                case 3: { val_to_wit = 2000; break; }
                case 4: { val_to_wit = 5000; break; }
                case 5: { val_to_wit = 10000; break; }
                case 6: { val_to_wit = 15000; break; }
                case 7: { val_to_wit = 20000; break; }
                default: { val_to_wit = 0; break; }
            }

            Console.WriteLine($"\nAre you sure you want to withdraw ${val_to_wit} (Y/N)?");
            string op1 = Console.ReadLine();
            
            if(op1 == "Y")
            {
                if ((int.Parse(acc_user[3]) - val_to_wit) >= 0)
                {
                    int row_where_found = 0;
                    string[] f = Utilities.search_account(0, acc_user[0], ref row_where_found);

                    int a = int.Parse(f[3]);
                    a -= val_to_wit;
                    f[3] = a.ToString();
                    string fa = f.ToString();

                    Utilities.Update_Acc_and_Redo_AccList(fa, ref row_where_found);


                    Console.WriteLine("\nCash succesfuly withdrawn!");
                    Console.WriteLine("Do you wish to print a receipt (Y/N)?"); string op2 = Console.ReadLine();
                    if (op2 == "Y")
                    {
                        Console.WriteLine($"\nAccount #{acc_user[0]}\nDate: {System.DateTime.Now.ToShortDateString()}" +
                            $"\nWithdrawn: {val_to_wit}\nBalance: {acc_user[3]}");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            else
            {
                Fast_cash(acc_user);
            }
        }

        private static void Normal_cash(string[] acc_user)
        {
            Console.Clear();
            int val = Utilities.int_validation("Enter the withdrawal amount: ");

            if ((int.Parse(acc_user[3]) - val) >= 0)
            {
                int row_where_found = 0;
                string[] f = Utilities.search_account(0, acc_user[0], ref row_where_found);

                int a = int.Parse(f[3]);
                a -= val;
                f[3] = a.ToString();
                string fa = f.ToString();

                Utilities.Update_Acc_and_Redo_AccList(fa, ref row_where_found);

                Console.WriteLine("\nCash succesfuly withdrawn!");
                Console.WriteLine("Do you wish to print a receipt (Y/N)?"); string op2 = Console.ReadLine();
                if (op2 == "Y")
                {
                    Console.WriteLine($"\nAccount #{acc_user[0]}\nDate: {System.DateTime.Now.ToShortDateString()}" +
                        $"\nWithdrawn: {val}\nBalance: {acc_user[3]}");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
