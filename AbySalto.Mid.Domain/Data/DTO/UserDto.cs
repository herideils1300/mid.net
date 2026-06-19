using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbySalto.Mid.Domain.Data.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PaswordHash { get; set; }
        public List<ProductDto> Favorites { get; set; } = new List<ProductDto>();
    }
}
