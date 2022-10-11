using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserRoleScreens
{
    public static class ListUserRolesScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Vínculos");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuUserRoleScreen.Load();
        }

        private static void List()
        {
            var repository = new UserRepository(Database.Connection);
            var roleUsers = repository.GetWithRoles();
            foreach (var item in roleUsers)
            {
                Console.WriteLine($"{item.Name} :");
                
                foreach(var role in item.Roles)
                    Console.WriteLine($"{role}");

            }
        }
    }
}