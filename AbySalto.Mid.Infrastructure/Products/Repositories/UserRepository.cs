using AbySalto.Mid.Domain.Business.Databasing;
using AbySalto.Mid.Domain.Data.DTO;
using AbySalto.Mid.Infrastructure.Interfaces.Repo;
using Microsoft.Data.SqlClient;

namespace AbySalto.Mid.Infrastructure.Products.Repository
{
    public class UserRepository : IGetterForOne<UserDto>, IPoster<UserDto>, IDeleter<UserDto>, IPutter<UserDto>
    {
        private readonly Db _db;
        public UserRepository(Db db)
        {
            this._db = db;
        }

        public UserDto? Delete(UserDto entity)
        {
            this._db.Connect();
            _db.ExecuteProcedure("RemoveUser", new SqlParameter("UserId", entity.Id));
            this._db.Disconnect();

            return entity;
        }

        public UserDto GetByEmail(string email)
        {
            UserDto user = default;
            this._db.Connect();
            var reader = this._db.ExecuteProcedure("GetFullUserByEmail", [new SqlParameter("Email", email)]);

            while (reader.Read())
            {
                if (user == default)
                {
                    user = new UserDto();
                    user.Id = (int)reader[0];
                    user.Email = (string)reader[1];
                    user.PaswordHash = (string)reader[2];
                }

                if (reader[3] == DBNull.Value)
                {
                    break;
                }
                else
                {
                    user.Favorites.Add(new ProductDto
                    {
                        Id = (int)reader[3],
                        Title = (string)reader[4],
                        Description = (string)reader[5],
                        Price = (double)reader[6],
                        Rating = (int)reader[7],
                        Stock = (long)reader[8]
                    });
                }
            }

            this._db.Disconnect();

            return user
                ?? new UserDto();
        }

        public UserDto GetOne(int id)
        {
            UserDto user = default;

            this._db.Connect();
            var reader = this._db.ExecuteProcedure("GetOneUser", new SqlParameter("UserId", id));

            while (reader.Read())
            {
                if (user == default)
                {
                    user = new UserDto();
                    user.Id = (int)reader[0];
                    user.Email = (string)reader[1];
                    user.PaswordHash = (string)reader[2];
                }

                if (reader.IsDBNull(3))
                {
                    break;
                }
                else
                {
                    user.Favorites.Add(new ProductDto
                    {
                        Id = (int)reader[3],
                        Title = (string)reader[4],
                        Description = (string)reader[5],
                        Price = (double)reader[6],
                        Rating = (int)reader[7],
                        Stock = (long)reader[8]
                    });
                }
            }

            this._db.Disconnect();

            return user
                ?? throw new KeyNotFoundException("The Id that was searched in the database was not found");
        }

        public UserDto? Post(UserDto entity)
        {
            this._db.Connect();

            var _ = this._db.ExecuteProcedure("RegisterUser",
                new SqlParameter("Email", entity.Email),
                new SqlParameter("PasswordHash", entity.PaswordHash)
                );

            this._db.Disconnect();


            return entity;
        }

        public UserDto? Put(UserDto entity)
        {
            UserDto updatedDto = new UserDto();
            this._db.Connect();

            var reader = this._db.ExecuteProcedure("EditUser",
                new SqlParameter("Id", entity.Id),
                new SqlParameter("Email", entity.Email),
                new SqlParameter("PasswordHash", entity.PaswordHash)
                );


            return entity;
        }
    }
}
