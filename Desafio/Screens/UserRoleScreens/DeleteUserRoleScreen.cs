using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserRoleScreens
{
    public static class DeleteUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir um vínculo");
            Console.WriteLine("-------------");
            Console.Write("Qual o id do Usuário?");
            var idUser = Console.ReadLine();
            Console.Write("Qual o id do Perfil?");
            var idRole = Console.ReadLine();

            Delete(int.Parse(idUser), int.Parse(idRole));
            Console.ReadKey();
            MenuUserRoleScreen.Load();
        }

        public static void Delete(int idUser, int idRole)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                repository.Delete(idUser, idRole);
                Console.WriteLine("Vínculo excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o vínculo.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}