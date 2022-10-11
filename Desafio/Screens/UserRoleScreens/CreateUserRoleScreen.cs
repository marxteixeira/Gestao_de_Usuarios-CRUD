using System;
using Blog.Models;
using Blog.Repositories;

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
            var userId = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Escolha uma das opçoes abaixo para vincular:");
            ListUserRolesScreen.List();


            Console.Write("Digite a opção escolhida: ");
            var roleId = Console.ReadLine();

            Create(UserId = int.Parse(userId), RoleId = int.Parse(roleId));
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Create(int UserId, int RoleId)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                repository.Create(UserId, RoleId);
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