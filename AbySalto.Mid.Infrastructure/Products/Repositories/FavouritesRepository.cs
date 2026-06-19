using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AbySalto.Mid.Domain.Business.Databasing;
using AbySalto.Mid.Domain.Data.DTO;
using AbySalto.Mid.Infrastructure.Interfaces.Repo;
using Microsoft.Data.SqlClient;

namespace AbySalto.Mid.Infrastructure.Products.Repository
{
    public class FavouritesRepository
    {
        private readonly Db _db;
        public FavouritesRepository(Db db)
        {
            _db = db;
        }

        public ProductDto? PostFavourite(UserProductDto connection, ProductDto dto)
        {

            decimal newFavouriteId = -1;

            _db.Connect();
            SqlDataReader reader = _db.ExecuteProcedure("AddFavourite",
                new SqlParameter("Title", dto.Title),
                new SqlParameter("Description", dto.Description),
                new SqlParameter("Price", dto.Price),
                new SqlParameter("Stock", dto.Stock),
                new SqlParameter("Rating", dto.Rating)
                );

            reader.Read();
            newFavouriteId = reader.GetDecimal(0);
            _db.Disconnect();

            _db.Connect();
            _db.ExecuteProcedure("AddFavouritesToUser", 
                new SqlParameter("UserId", connection.UserId),
                new SqlParameter("FavouriteID", newFavouriteId)
                );
            _db.Disconnect();

            return dto;
        }
    }
}
