using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
        : base(connection)
            => _connection = connection;

        public List<User> GetWithRoles()
        {
            var query = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role);

                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);

                    return user;
                }, splitOn: "Id");

            return users;
        }

        public void Create(int userId, int roleId)
        {
            var sql = @"INSERT INTO [UserRole] VALUES [@UserId, @RoleId]";

            var AffectRows = _connection.Query(sql, new {UserId = userId, RoleId = roleId});
            //Console.WriteLine($"{AffectRows}, linhas afetadas.");
        }

        public void Delete(int userId, int roleId)
        {
            var sql = @"DELETE FROM [UserRole] WHERE [UserId] = @userId AND [RoleId] = @roleId";

            var row = _connection.Query(sql, new {UserId = userId, RoleId = roleId});
        }
    }
}