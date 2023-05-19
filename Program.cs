using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Application_with_classes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Credentials> users = new List<Credentials>();
            List<Stack> items = new List<Stack>();
            char option = '0';
            string admin_default_key = "lock123";
            read_admin_data(users);
            read_stock_data(items);
            while (option != '3')
            {
                Console.Clear();
                Header();
                option = menu();
                Console.Clear();
                Header();
                if (option == '1')
                {


                   
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("  Sign up Menu");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("--------------------->>>");
                    Console.WriteLine("   ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Enter your Name:");
                    string Name = Console.ReadLine();
                    Console.Write("Enter password:");
                    string Password = Console.ReadLine();
                    Console.Write("Enter role:(admin or user)");
                    string Role = Console.ReadLine();
                    Credentials admin = new Credentials(Name,Password,Role);
                    if (Role == "admin")
                    {
                        bool decision = isvalid_admin_name(users,Name);


                        if (decision == true)
                        {
                            string check_key;
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("Enter Admin Special Login Key:");
                            Console.ForegroundColor = ConsoleColor.White;
                            check_key = Console.ReadLine();
                            if (check_key == admin_default_key)
                            {
                                users.Add(admin);
                                store_admin_data(users);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("signup admin_succssfully:");
                                Console.ForegroundColor = ConsoleColor.White;
                                press();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You are not Admin sign_up as user:");
                                Console.ForegroundColor = ConsoleColor.White;
                                press();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("admin already exits:");
                            Console.ForegroundColor = ConsoleColor.White;
                            press();
                        }
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong role:");
                        Console.ForegroundColor = ConsoleColor.White;
                        press();
                    }
                }



                else if (option =='2')
                {
                    string name, password;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("  Sign in Menu");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("--------------------->>>");
                    Console.WriteLine("     ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Enter your Name:");
                    name = Console.ReadLine();
                    Console.Write("Enter password:");
                    password = Console.ReadLine();
                    string Role = sign_in_admin(users, name, password);
                    if (Role == "admin")
                    {

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Admin Login successfully:");
                        Console.ForegroundColor = ConsoleColor.White;
                        press();
                    }
                    char admin_opinion = '0';
                    while (admin_opinion != '6')
                    {
                        Console.Clear();
                        admin_opinion = Admin_menu();
                        Console.Clear();
                        Header();
                        if (admin_opinion == '1')
                        {
                            stock(items);
                        }
                        else if (admin_opinion == '2')
                        {

                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("  Add Menu");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("--------------------->>>");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;

                            char suggestion = 'y';
                            while (suggestion != 'n')
                            {
                                
                                Console.Write("Enter name of Product:");
                                string Name = Console.ReadLine();
                                bool result = search(Name, items);
                                if (result == false)
                                {

                                    Console.Write("Enter Price:");
                                    float Price = float.Parse(Console.ReadLine());
                                    Console.Write("Enter Quantity:");
                                    int Quantity = int.Parse(Console.ReadLine());
                                    Stack product = new Stack(Name,Price, Quantity);
                                    items.Add(product);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Item already Exits");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\n");
                                Console.Write("Do you want to add more Items:(n to exit press any key to cotinue):");
                                suggestion = char.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.White;

                            }
                            suggestion = 'y';
                            press();


                        }

                        else if (admin_opinion =='3')
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("  Delete Menu");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("--------------------->>>");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            string delete_product;
                            Console.Write("Enter name of Product you want to Delete:");
                            delete_product = Console.ReadLine();
                            bool present = del_product(delete_product, items);

                            if (present == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("item deleted successfully");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("item does not exist:");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            press();

                        }
                        else if (admin_opinion == '4')
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("  Edit Menu");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("--------------------->>>");
                            Console.WriteLine(" ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string update_product;
                            bool result;
                            float new_price;
                            int new_quantity;

                            Console.Write("Enter name of product you want to update : ");
                            update_product = Console.ReadLine();

                            result = search(update_product, items);
                            if (result == true)
                            {

                                Console.Write("Enter new price:");
                                new_price = float.Parse(Console.ReadLine());
                                Console.Write("Enter_new Quantity:");
                                new_quantity = int.Parse(Console.ReadLine());
                                edit_product(update_product, new_price, new_quantity,items);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Item updated successfully");
                                Console.ForegroundColor = ConsoleColor.White;
                                press();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("item does not exist");
                                Console.ForegroundColor = ConsoleColor.White;
                                press();
                            }
                        }
                        else if (admin_opinion == '5')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("   Search Menu");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("--------------------->>>");
                            Console.WriteLine("   ");

                            Console.ForegroundColor = ConsoleColor.White;
                            string search_item;
                            Console.Write("Enter Item You Want to Search:");
                            search_item = Console.ReadLine();
                            bool present = search(search_item, items);
                            if (present == true)
                            {

                                display_search_item(search_item, items);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Item does not exist:");
                                Console.ForegroundColor = ConsoleColor.White;
                                press();
                            }
                        }
                        else if (admin_opinion == '6')
                        {
                            store_add_Items(items);
                            admin_opinion = '0';
                            break;
                        }
                    }
                }


                else if (option == '3')
                {
                    break;
                }
            }

        }
        static void Header()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t_________________________________________________________________________________________________________");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t    ____ ____ _  _ _ ___ ____ ____ _   _    ____ _  _ ___     _  _ ____ ____ ___  _ _ _ ____ ____ ____");
            Console.WriteLine("\t\t\t    [__  |__| |\\ | |  |  |__| |__/  \\_/     |__| |\\ | |  \\    |__| |__| |__/ |  \\ | | | |__| |__/ |___ ");
            Console.WriteLine("\t\t\t    ___] |  | | \\| |  |  |  | |  \\   |      |  | | \\| |__/    |  | |  | |  \\ |__/ |_|_| |  | |  \\ |___ ");
            Console.WriteLine("                                                                                                  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t                                    ITEMS   MANAGEMENT   SYSTEM                     ");
            Console.ForegroundColor = ConsoleColor.White; ;
            Console.ForegroundColor = ConsoleColor.Blue; ;
            Console.WriteLine("\t\t\t_________________________________________________________________________________________________________");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                                                         ");
            Console.WriteLine("                                                                                         ");

        }
        static char menu()
        {
            char choice;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  Main Menu");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------------->>>");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  1: sign up");
            Console.WriteLine("  2: sign in");
            Console.WriteLine("  3: Exit");
            Console.Write("  Enter choice:");
            choice = char.Parse(Console.ReadLine());

            return choice;
        }
        static char Admin_menu()
        {
            Header();
            char opinion;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  Admin Menu");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------------------->>>");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  1-View Stock:");
            Console.WriteLine("  2-Add new Items:");
            Console.WriteLine("  3-Delete Item:");
            Console.WriteLine("  4-Update Item:");
            Console.WriteLine("  5-Search Item:");
            Console.WriteLine("  6-Exit");
            Console.Write("  Enter your opinion:");
            opinion = char.Parse(Console.ReadLine());
            return opinion;
        }
        static bool isvalid_admin_name(List<Credentials> users, string Name)
        {
            bool flag = true;
            for (int indx = 0; indx < users.Count; indx++)
            {
                if (users[indx].Name == Name)
                {

                    flag = false;
                }
            }
            return flag;
        }
        static void store_admin_data(List<Credentials> users)
        {


            char ch = (char)223;
            string path = "E:\\OOP\\ConsoleApp1\\data.txt";
            StreamWriter file = new StreamWriter(path);
            for (int i = 0; i < users.Count; i++)
            {

                file.WriteLine(users[i].Name + ch + users[i].Password + ch + users[i].Role);
            }


            file.Flush();
            file.Close();
        }
        static void press()
        {
            Console.Write("\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Press any key to continue:");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }
        static string sign_in_admin(string name, string password, string[] adminName, string[] adminPassword, string[] adminRole, ref int count_admin)
        {

            for (int i = 0; i < count_admin; i++)
            {
                if (name == adminName[i] && password == adminPassword[i])
                {
                    return adminRole[i];
                }
            }
            return "wrong";
        }
        static string getField(string record, int field)
        {
            char ch = (char)223;
            int commaCount = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ch)
                {
                    commaCount = commaCount + 1;
                }
                else if (commaCount == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void read_admin_data(List<Credentials> user)
        {

            string path = "E:\\OOP\\ConsoleApp1\\data.txt";
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;

                while ((record = fileVariable.ReadLine()) != null)
                {
                    Credentials admin = new Credentials();
                    admin.Name = getField(record, 1);
                    admin.Password = getField(record, 2);
                    admin.Role = getField(record, 3);
                    user.Add(admin);



                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }

        }
        static string sign_in_admin(List<Credentials> user, string name, string password)
        {

            for (int i = 0; i < user.Count; i++)
            {
                if (name == user[i].Name && password == user[i].Password)
                {
                    return user[i].Role;
                }
            }
            return "wrong";
        }

        static void stock(List<Stack> products)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("STOCK Menu");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("---------------------->>>");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Product Id\t\tItemName\t\tPrice\t\tQuantity");
            Console.ForegroundColor = ConsoleColor.White;
            for (int indx = 0; indx < products.Count; indx++)
            {
                if (products[indx].Name == "0" && products[indx].Price == 0 && products[indx].Quantity == 0)

                {
                    continue;
                }
                Console.WriteLine(indx + 1 + "\t\t\t" + products[indx].Name + "\t\t\t" + products[indx].Price + "\t\t" + products[indx].Quantity);
            }
            press();
        }
        static bool search(string item, List<Stack> products)
        {
            bool present = false;
            for (int i = 0; i < products.Count; i++)
            {
                if (item == products[i].Name)
                {
                    present = true;
                }
            }
            return present;
        }
        static bool del_product(string delete_product, List<Stack> products)
        {
            bool present = false;
            for (int indx = 0; indx < products.Count; indx++)
            {
                if (products[indx].Name == delete_product)
                {
                    products[indx].Name = "0";
                    products[indx].Price = 0;
                    products[indx].Quantity = 0;
                    present = true;
                }
            }
            return present;
        }
        static void edit_product(string update_product, float new_price, int new_quantity, List<Stack> products)
        {
            for (int indx = 0; indx < products.Count; indx++)
            {
                if (update_product == products[indx].Name)
                {
                    products[indx].Price = new_price;
                    products[indx].Quantity = new_quantity;
                }
            }
        }
        static void display_search_item(string item, List<Stack> products)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Id NO\t\tName\t\tQuantity\tPrice");
            Console.ForegroundColor = ConsoleColor.White;
            for (int indx = 0; indx < products.Count; indx++)
            {
                if (item == products[indx].Name)
                {
                    Console.WriteLine(indx + 1 + "\t\t" + products[indx].Name + "\t\t" + products[indx].Price + "\t\t" + products[indx].Quantity);

                }
            }
            press();
        }
        static void read_stock_data(List<Stack> products)
        {
            string path = "E:\\OOP\\ConsoleApp1\\stock.txt";
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    Stack item = new Stack();
                    item.Name = getField(record, 1);
                    item.Price = float.Parse(getField(record, 2));
                    item.Quantity = int.Parse(getField(record, 3));
                    products.Add(item);

                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }
        static void store_add_Items(List<Stack> products)
        {
            char ch = (char)223;
            string path = "E:\\OOP\\ConsoleApp1\\stock.txt";
            StreamWriter file = new StreamWriter(path);
            for (int indx = 0; indx < products.Count; indx++)
            {
                file.WriteLine(products[indx].Name + ch + products[indx].Price + ch + products[indx].Quantity);
            }
            file.Flush();
            file.Close();

        }
    }

}

        
    

