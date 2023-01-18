using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace ATM
{
    internal class Utilities
    {
        public static string name_or_password(string th) 
        {
            string aux, ns;
            Console.WriteLine("Enter your new {0} ", th);
            aux = Console.ReadLine();
            bool ContieneNros = aux.Any(char.IsDigit);
            bool EsTodoNros = aux.All(char.IsDigit);
            while ((EsTodoNros == true) || (aux.Length == 0) || (aux.Length > 30) || (ContieneNros == false))
            {
                if ((EsTodoNros == true) || (ContieneNros == false))
                {
                    ns = string.Format("The {0} must be alphanumeric", th);
                }
                else
                {
                    ns = string.Format("The {0} must have a lenght of 8 to 18 characters", th);
                }
                Console.WriteLine("Invalid {0}. {1}", th, ns);
                Console.WriteLine("\nEnter your new {0} ", th);
                aux = Console.ReadLine();
                ContieneNros = aux.Any(char.IsDigit);
                EsTodoNros = aux.All(char.IsDigit);
                Console.Clear();
            }
            Console.WriteLine("\nYour new {0}: \"{1}\" is valid", th, aux);

            return aux;
        }

        public static int int_validation(string message, string error_message="Invalid value. Try again.")
        {
            Console.WriteLine(message); string aux = Console.ReadLine();
            int val;
            while (!int.TryParse(aux, out val))
            {
                Console.WriteLine(error_message);
                Thread.Sleep(1000);
                Console.WriteLine($"\n{message}"); aux = Console.ReadLine();
            }
            return val;
        }

        public static string date_validation(string message, string error_message = "Invalid date. Try again.")
        {
            Console.WriteLine(message); string aux = Console.ReadLine();
            DateTime date;
            while (!DateTime.TryParse(aux, out date))
            {
                Console.WriteLine(error_message);
                Thread.Sleep(1000);
                Console.WriteLine($"\n{message}"); aux = Console.ReadLine();
            }
            return date.ToShortDateString();
        }


        public static long long_validation(string message, string error_message = "Invalid value. Try again.")
        {
            Console.WriteLine(message); string aux = Console.ReadLine();
            long val;
            while (!long.TryParse(aux, out val))
            {
                Console.WriteLine(error_message);
                Thread.Sleep(1000);
                Console.WriteLine($"\n{message}"); aux = Console.ReadLine();
            }
            return val;
        }

        public static string status_validation()
        {
            Console.WriteLine("\nStatus: "); string st = Console.ReadLine();
            while(st != "Active" || st != "Disabled")
            {
                Console.WriteLine(@"Invalid status. Status must be Active or Disabled. Try again.");
                Console.WriteLine("\nStatus: "); st = Console.ReadLine();
            }
            return st;
        }

        public static string[] search_account(int col ,string required, ref int row_where_found)
        {
            string[] filas = System.IO.File.ReadAllLines(@"C:\Users\Admin\Desktop\ATM\Accounts_list.txt", Encoding.UTF8);
            string[] data = new string[4];
            string[] fa = new string[4];

            /*/foreach (string a in filas)
            {
                data = a.Split(',');
                if (data[col] == required)
                {
                    fa = data;
                    row_where_found 
                    break;
                }
            }/*/

            for(int i = 0; i < filas.Length; i++)
            {
                data = filas[i].Split(',');
                if (data[col] == required)
                {
                    fa = data;
                    row_where_found = i;
                    break;
                }
            }

            if(fa == null)
            {
                throw new Exception("Account not found");
            }

            return fa;
        }

        public static void Update_Acc_and_Redo_AccList(string acc, ref int row_where_found)
        {/*/
            string ruta = @"C:\Users\Admin\Desktop\ATM\Accounts_list.txt";
            FileStream archivo;
            StreamWriter grabador;
            archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write);
            grabador = new StreamWriter(archivo);
            //grabador.WriteLine("NAME   PASSWORD   HOLDER NAME   STARTING BALANCE   STATUS   ID");
            //arr[0].Remove(0); // PROBAR. PORQUE SINO QUIZAS SE VUELVE A COPIAR LO DE ARRIBA.
            grabador.WriteLine(arr);
            grabador.Close();
            archivo.Close();/*/

            //Create_New_Account account = new Create_New_Account(acc[0], acc[1], int.Parse(acc[2]), acc[3]);


            string[] filas = System.IO.File.ReadAllLines(@"C:\Users\Admin\Desktop\ATM\Accounts_list.txt", Encoding.UTF8);

            /*/ filas[row_where_found] = acc.t;
            filas./*/

            string ruta = @"C:\Users\Admin\Desktop\ATM\Accounts_list.txt";
            var tempFile = Path.GetTempFileName();

            System.IO.File.WriteAllLines(tempFile, filas);
            System.IO.File.Delete(ruta);
            System.IO.File.Move(tempFile, ruta);
        }
    }
}
