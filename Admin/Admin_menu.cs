using ATM.Admin.Admin_options;
using ATM.Admin_options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM
{
    internal class Admin_menu
    {
        public static void menu()
        {
            int opc;
            do
            {
                string linea = "- - - - - - - - - -";
                string espacio = "          ";
                Console.Clear();
                Console.WriteLine("{0} M E N Ú  D E  A D M I N {1}", linea, linea);
                Console.WriteLine("\n{0}1) Create new account..\n{1}2) Delete Existing Account.\n" +
                    "{2}3) Update Account Information.\n{3}4) Update Account Information.\n" +
                    "{4}5) View Reports.\n{5}6) Exit."
                    , espacio, espacio, espacio, espacio, espacio, espacio);
                opc = Utilities.int_validation("Enter your option: ");
                Console.Clear();
                switch (opc)
                {
                    case 1:
                        {
                            Create_New_Account.acc_Creation();
                            break;
                        }
                    case 2:
                        {
                            Delete_Existing_Account.Delete();
                            break;
                        }
                    case 3:
                        {
                            Update_Account_Info.Update();
                            break;
                        }
                    case 4:
                        {
                            Search_For_Account.Search_parameters();
                            break;
                        }
                    case 5:
                        {
                            View_Reports.view();
                            break;
                        }
                }
            } while (opc != 6);
            Console.WriteLine("Bye!");
            Thread.Sleep(500);
        }
    }
}
