using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir um Usuário");
            Console.WriteLine("-------------");
            Console.Write("Qual o id do Usuário que deseja excluir? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuUserScreens.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Usuário excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o Usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}