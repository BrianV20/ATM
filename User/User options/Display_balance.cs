using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.User.User_options
{
    internal class Display_balance
    {
        public static void display_bal(string[] acc_user)
        {
            Console.Clear();
            Console.WriteLine($"\nAccount: {acc_user[0]}\nDate: {DateTime.Now.ToShortDateString()}" +
                $"\n\nBalance: {acc_user[3]}");
            Console.ReadKey();
        }
    }
}
