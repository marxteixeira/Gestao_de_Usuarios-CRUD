using System;

namespace Blog.Screens.UserRoleScreens
{
    public static class MenuUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Vínculos de Perfis com Usuário");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Perfil com Usuários");
            Console.WriteLine("2 - Cadastrar Vínculo");
            Console.WriteLine("3 - Excluir Vínculo");
            Console.WriteLine("0 - Voltar");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListUserRolesScreen.Load();
                    break;
                case 2:
                    CreateUserRoleScreen.Load();
                    break;
                case 3:
                    DeleteUserRoleScreen.Load();
                    break;
                case 0:
                    Program.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}