using cyrsach.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.BLL.Dto.User
{
    public class UserDto
    {
        public required string Id { get; set; }
        [Required(ErrorMessage = "Поле 'Name' є обов'язковим")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Поле 'Email' є обов'язковим")]
        public Role Role { get; set; }
    }
}
