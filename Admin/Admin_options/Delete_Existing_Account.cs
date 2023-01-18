using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ATM.Admin_options;

namespace ATM
{
    internal class Delete_Existing_Account
    {
        public static void Delete()
        {
            int nro_acc = Utilities.int_validation("Enter the number of the account which you want to delete: ");

            int r = 0;
            string[] datos = Utilities.search_account(0, nro_acc.ToString(), ref r);
            //Create_New_Account ac = new Create_New_Account(); alternativa: crear una cuenta con los datos spliteados.


            Console.WriteLine("\nYou wish to delete the account held by {0};\nIf this information is correct " +
                "please re-enter the account number: ", datos[1]);
            nro_acc = Utilities.int_validation("", "invalid account number. Try again.");


            datos = Utilities.search_account(0, nro_acc.ToString(), ref r);
            string[] filas = File.ReadAllLines(@"C:\Users\Admin\Desktop\ATM\Accounts_list.txt", Encoding.UTF8);
            /*/fila = filas[nro_acc];
            datos = fila.Split(',');/*/
            //filas[nro_acc].Remove(0);
            delete_Acc_and_Redo_AccList(datos);
            Console.Clear();
            Console.WriteLine("Account deleted succesfully.");
            Console.ReadKey();
        }

        public static void delete_Acc_and_Redo_AccList(string[] acc)
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

            string ruta = @"C:\Users\Admin\Desktop\ATM\Accounts_list.txt";
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadAllLines(ruta).Where(l => !l.StartsWith($"{acc[0]}"));

            File.WriteAllLines(tempFile, linesToKeep);

            File.Delete(ruta);
            File.Move(tempFile, ruta);
        }
    }
}
