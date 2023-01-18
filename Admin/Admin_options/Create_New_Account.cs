using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ATM.Admin_options
{
    internal class Create_New_Account
    {
        private string login;
        private string password;
        private int starting_Balance;
        private string status;
        private int ID;
        //public static int previous_ID = starting_previous_id_setter();

        public Create_New_Account(string l, string p, int sb, string st)
        {
            //this.ID = CONTADOR_CUENTAS(); //ver si funciona
            //this.ID = CONTADOR_CUENTAS();
            this.ID = prev_id_plus();
            this.LOGIN = l;
            this.PASSWORD = p;
            this.STARTING_BALANCE = sb;
            this.STATUS = st;
            //previous_ID = this.ID;
        }

        public string LOGIN
        {
            get
            {
                return this.login;
            }
            set 
            {
                //this.login = Utilities.name_or_password("account name");
                this.login = value;
            }
        }

        public string PASSWORD
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public int STARTING_BALANCE
        {
            get
            {
                return this.starting_Balance;
            }
            set
            {
                if (value < 0 || value > 1000000)
                {
                    Console.WriteLine("Error, the starting value shouldn't be too low nor too high.");
                    this.starting_Balance = 0;
                }
                else
                {
                    this.starting_Balance = value;
                }
            }
        }

        public string STATUS
        {
            get
            {
                return this.status;
            }
            set
            {
                if (value == "Active" || value == "Inactive")
                {
                    this.status = value;
                }
                else
                {
                    Console.WriteLine("Error, status must be Active or Inactive.");
                    this.status = "Inactive";
                }
            }
        }

        /*/public static int PREVIOUS_ID()
        {
            return previous_ID;
        }/*/

        /*/public static int starting_previous_id_setter()
        {
            string[] filas = File.ReadAllLines(@"C:\Users\Admin\Desktop\ATM\Accounts_list.txt", Encoding.UTF8);
            string fila = filas.Last();
            string[] data = fila.Split(',');

            return int.Parse(data[0]);
        }/*/

        /*/public static int setter_id()
        {
            return previous_ID + 1;
        }/*/

        public static int prev_id_plus()
        {
            string[] filas = File.ReadAllLines(@"C:\Users\Admin\Desktop\ATM\Accounts_list.txt", Encoding.UTF8);
            string ult_fila = filas.Last();
            string[] data = ult_fila.Split(',');

            return ((int.Parse(data[0]) + 1));
        }

        /*/public static int CONTADOR_CUENTAS()
        {
            if (!File.Exists(@"C:\Users\Admin\Desktop\ATM\Accounts_list.txt"))
            {
                FileStream archivo;
                StreamWriter grabador;
                archivo = new FileStream(@"C:\Users\Admin\Desktop\ATM\Accounts_list.txt", FileMode.Create);
                grabador = new StreamWriter(archivo);
                grabador.WriteLine("ID  NAME  PASSWORD  STARTING_BALANCE  STATUS");
                grabador.Close();
                archivo.Close();
            }
            string[] filas = File.ReadAllLines(@"C:\Users\Admin\Desktop\ATM\Accounts_list.txt", Encoding.UTF8);
            if (filas.Length == 1) { return 1; }
            else
            {
                int id = setter_id();
                return id;
            }
        }/*/
        // propiedad para poder saber la cantidad cuentas creadas.

        public static void acc_Creation() //funcion para crear cuenta.
        {
            Console.Clear();
            string ln = Utilities.name_or_password("name");
            string pc = Utilities.name_or_password("password");
            int sb = Utilities.int_validation("Enter your Starting balance: ");
            string st = "Active";
            Create_New_Account acc = new Create_New_Account(ln, pc, sb, st);
            accounts_List(acc);
            Console.WriteLine("     Account Successfully Created – the account number assigned is: {0}.", acc.ID);
            Console.ReadKey();
            Console.Clear();
        }

        public static void accounts_List(Create_New_Account acc)
        {
            string ruta = @"C:\Users\Admin\Desktop\ATM\Accounts_list.txt";
            if (!File.Exists(ruta))
            {
                FileStream archivo;
                StreamWriter grabador;
                archivo = new FileStream(ruta, FileMode.Create);
                grabador = new StreamWriter(archivo);
                grabador.WriteLine("ID  NAME  PASSWORD  STARTING_BALANCE  STATUS");
                grabador.Close();
                archivo.Close();
            }
            acc_Save(acc);
        } //funcion para crear la lista, y en caso de q ya exista escrbir sobre ella.
        public static void acc_Save(Create_New_Account acc) //funcion para escribir los datos de la cuenta en la lista de cuentas csv
        {
            FileStream archivo;
            StreamWriter grabador;

            string ruta = @"C:\Users\Admin\Desktop\ATM\Accounts_list.txt";
            archivo = new FileStream(ruta, FileMode.Append);
            grabador = new StreamWriter(archivo);
            grabador.WriteLine("{0}, {1}, {2}, {3}, {4},", acc.ID, acc.LOGIN, acc.PASSWORD,
                acc.STARTING_BALANCE, acc.STATUS);
            grabador.Close();
            archivo.Close();
        }
    }
}
