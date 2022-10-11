using System;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=marx123!@#;Trusted_Connection=False; TrustServerCertificate=True";

        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();

            Load();

            Console.ReadKey();
            Database.Connection.Close();
        }

        private static void Load()
        {
            Console.Clear();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("-----------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de Usuário");
            Console.WriteLine("2 - Gestão de Perfil");
            Console.WriteLine("3 - Gestão de Categoria");
            Console.WriteLine("4 - Gestão de Tag");
            Console.WriteLine("5 - Vincular Perfil/Usuário");
            Console.WriteLine("6 - Vincular Post/Tag");
            Console.WriteLine("7 - Relatórios");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    MenuUserScreens.Load();
                    break;
                case 2:
                    //MenuRoleScreen.Load();
                    break;
                case 3:
                    //MenuCategoryScreen.Load();
                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                case 5:
                    //MenuRoleUserScreen.Load();
                    break;
                case 6:
                    //MenuPostTagScreen.Load();
                    break;
                case 7:
                    //MenuRelatoriosScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}
