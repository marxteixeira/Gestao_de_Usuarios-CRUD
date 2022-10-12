using System;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.RoleScreens;

namespace Blog.Screens.UserRoleScreens
{
    public static class CreateUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Qual o Id do Usuário que deseja criar um perfil?");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            var userId = short.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Escolha uma das opçoes abaixo para vincular:");
            ListRolesScreen.List();


            Console.Write("Digite a opção escolhida: ");
            var roleId = short.Parse(Console.ReadLine());

            Create(userId, roleId);
            Console.ReadKey();
            MenuUserRoleScreen.Load();
        }

        public static void Create(int userId, int roleId)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                repository.Create(userId, roleId);
                Console.WriteLine("Vínculo cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível criar o vínculo");
                Console.WriteLine(ex.Message);
            }
        }
    }
}