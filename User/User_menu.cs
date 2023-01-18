using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class User_menu
    {
        public static void menu(string[] acc_user)
        {
            int opc;
            do
            {
                string linea = "- - - - - - - - - -";
                string espacio = "          ";
                Console.WriteLine("{0} M E N Ú  D E  U S U A R I O {1}", linea, linea);
                Console.WriteLine("\n{0}1) Withdraw cash.\n{1}2) Cash transfer.\n{2}3) Deposit cash." +
                    "\n{3}4) Display balance.\n{4}5) Exit.\n{5} Enter your option: ", espacio, espacio, espacio, espacio, espacio, espacio);
                opc = Utilities.int_validation("Enter your option: ", "Invalid option.");
                Console.Clear();
                switch (opc)
                {
                    case 1:
                        {
                            Withdraw_cash.withd_cash(acc_user);
                            break;
                        }
                    case 2:
                        {
                            User.User_options.Cash_transfer.cash_trans(acc_user);
                            break;
                        }
                    case 3:
                        {
                            User.User_options.Deposit_cash.depo_cash(acc_user);
                            break;
                        }
                    case 4:
                        {
                            User.User_options.Display_balance.display_bal(acc_user);
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            break;
                        }
                }
            } while (opc != 5);
        }
    }
}
