using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class ListUsersScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Usuários");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuUserScreens.Load();
        }

        private static void List()
        {
            var repository = new Repository<Tag>(Database.Connection);
            var tags = repository.Get();
            foreach (var item in tags)
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }
    }
}