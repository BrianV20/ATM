using ATM.Admin_options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATM // TODO: LPM, PREGUNTARLE A LA PERSONA SI QUIERE VER EL MENU DE USUARIO O ADMIN. si ya fue.
{
    internal class Login
    {
        public static void which_menu()
        {
            Console.WriteLine("¿Admin menu or User menu? (A/U)"); string opc = Console.ReadLine();
            while(opc != "A" && opc != "B")
            {
                Console.WriteLine("Invalid option. Try again");
                Console.WriteLine("¿Admin menu or User menu? (A/U)"); opc = Console.ReadLine();
            }
            if (opc == "A") { Admin_menu.menu(); }
            else if(opc == "U") { log_user(); }
        }

        public static void log_user()
        {
            Console.WriteLine("Enter login: "); string l = Console.ReadLine();
            Console.WriteLine("Enter password: "); string p = Console.ReadLine();
            int n = Utilities.int_validation("Enter the account number: ");

            // CORROBORAMOS QUE EXISTA EL ARCHIVO DE CUENTAS
            if(File.Exists(@"C:\Users\Admin\Desktop\ATM\Accounts_list.txt"))
            {
                string[] filas = File.ReadAllLines(@"C:\Users\Admin\Desktop\ATM\Accounts_list.txt", Encoding.UTF8);
                if (n < filas.Length && n >= 0)
                {
                    string dat = filas[n];
                    string[] acc = dat.Split(',');

                    if (l == acc[1] && p == acc[2])
                    {
                        User_menu.menu(acc); // SE PASA LA CUENTA DEL USUARIO COMO PARAMETRO.
                    }
                    else
                    {
                        log_error_person();
                    }
                }
                else
                {
                    log_error_person();
                }
            }
            else
            {
                File.Create(@"C:\Users\Admin\Desktop\ATM\Accounts_list.txt");
                log_error_person();
            }
        }

        public static void log_error_person()
        {
            Console.WriteLine("Error, invalid data/account doesn´t exist. And you can't create an account.");
            Console.Clear();
            log_user();
        }

        /*/public static void log_error_admin()
        {
            Console.WriteLine("Error, invalid data/account doesn´t exist.");
            Console.WriteLine("\nDo you wish to create an admin account? (Y/N)"); string opc = Console.ReadLine();
            if (opc == "Y") { Create_New_Account.acc_Creation(); }
            Console.Clear();
            log_user();
        }/*/

        /*/public static void check_if_its_admin(string log, string pin, int num)
        {
            string l = log, p = pin;
            int n = num;

            if(File.Exists(@"C:\Users\Admin\Desktop\ATM\Admin_accounts_list.txt"))
            {
                string[] filas = System.IO.File.ReadAllLines(@"C:\Users\Admin\Desktop\ATM\Accounts_list.txt", Encoding.UTF8);
                if (n < filas.Length && n >= 0)
                {
                    string dat = filas[n];
                    string[] acc = dat.Split(',');

                    if (l == acc[0] && p == acc[1])
                    {
                        Admin_menu.menu();
                    }
                    else
                    {
                        log_error_admin();
                    }
                }
                else
                {
                    log_error_admin();
                }
            }
            else
            {
                File.Create(@"C:\Users\Admin\Desktop\ATM\Admin_accounts_list.txt");
                log_error_admin();
            }
        }/*/
    }
}
