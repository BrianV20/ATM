 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Runtime.Remoting.Lifetime;

namespace ATM
{
    internal class Update_Account_Info
    {
        public static void Update()
        {
            Console.Clear();
            int id = Utilities.int_validation("Enter the account id that you want to update: ");
            /*/string[] filas = System.IO.File.ReadAllLines(@"C:\Users\Admin\Desktop\ATM\Accounts_list", Encoding.UTF8);
            while (filas[id] == null)
            {
                Console.WriteLine("\nThe account you are trying to update doesn't exist.");
                id = Utilities.int_validation("Enter the account id that you want to update: ");
            }/*/
            int row_where_found = 0;
            string[] data = Utilities.search_account(0, id.ToString(), ref row_where_found);
            show_Acc(data);

            update_Acc(data, row_where_found);
        }

        public static void show_Acc(string[] account)
        {
            Console.Clear();
            Console.WriteLine("\n This is the account you are trying to update: \n");
            Console.WriteLine("\nAccount: {0}\nName: {1}\nBalance: {2}\nStatus: {3}"
                , account[0], account[1], account[3], account[4]);
            Console.ReadKey();
        }

        public static void update_Acc(string[] ori_data, int row_where_found)
        {
            string[] new_data = new string[4];
            string[] filas = System.IO.File.ReadAllLines(@"C:\Users\Admin\Desktop\ATM\Accounts_list.txt", Encoding.UTF8);
            Console.WriteLine("\n\n\tPlease enter in the fields you wish to update(leave blank otherwise): ");

            new_data[0] = ori_data[0];

            new_data[1] = Console.ReadLine();
            if (new_data[1] == "") { new_data[1] = ori_data[1]; }

            new_data[2] = Console.ReadLine();
            if (new_data[2] == "") { new_data[2] = ori_data[2]; }

            new_data[3] = ori_data[3];

            new_data[4] = Console.ReadLine();
            if (new_data[4] == "") { new_data[4] = ori_data[4]; }

            // WE REMOVE THE PREVIOUS ACCOUNT, AND REPLACE IT WITH THE UPDATED ONE. 
            /*/filas[id].Remove(0);
            new_data.CopyTo(filas, id);/*/
            string data = new_data.ToString();

            Utilities.Update_Acc_and_Redo_AccList(data, ref row_where_found);
            Console.ReadKey();
            Console.WriteLine("Your account has been succesfully updated.");
            Console.ReadKey();
        }
    }
}
