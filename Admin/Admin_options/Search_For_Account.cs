using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATM
{
    internal class Search_For_Account
    {
        public static void Search(string[] parameters/*/IEnumerable<string> parameters/*/) //todo
        {
            //string[] param = parameters.ToArray();
            //buscar en el archivo de cuentas en base a los valores contenidos en "parameters".
            //if (parameters[0].GetType().Name == null) { Console.WriteLine(parameters[0].GetType().Name); }
            //PROBAR CON guardar datos en un DICTIONARIE
            string[] filas = File.ReadAllLines(@"C:\Users\Admin\Desktop\ATM\Accounts_list.txt", Encoding.UTF8);
            string fila;
            string[] datos = new string[5];

            for(int i = 0; i < filas.Length; i++)
            {
                fila = filas[i];
                datos = fila.Split(',');
                if (datos[0] == null && datos[1] == null && datos[2] == null) { }
                //else if () ;
            }

            Console.Clear();
            Console.WriteLine("Accounts that match:\n");

            /*/for(int i = 0; i < param.Length; i++)
            {
                if (param[i] != null)
                {

                }
            }

            for(int i = 0; i < filas.Length; i++)
            {
                fila = filas[i];
                datos = fila.Split(',');
                if (param[0] != null) { } //CHEQUEAR COMO SABER SI LOSPARAMETROS SON NULL Y COMO BUSCAR SABIENDO ESO
            }/*/
        }

        public static void Search_parameters()
        {
            string status;
            int id, balance;
            string[] param = new string[4];
            Console.WriteLine("    SEARCH MENU:\n");
            Console.WriteLine("Account ID: ");

             id = Utilities.int_validation("");
             param[0] = id.ToString();


             balance = Utilities.int_validation("Balance: ");
             param[1] = balance.ToString();


            Console.WriteLine("Status: ");
            status = Console.ReadLine();
            param[2] = status;

            /*/IEnumerable<string> param2 = from d in param
                     where d != null
                     select d;/*/

            Search(param);
         }
    }
}
