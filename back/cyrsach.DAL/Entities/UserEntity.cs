using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.DAL.Entities
{
    public enum Role
    {
        User = 0,
        Admin = 1
    }

    public class UserEntity : BaseEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = default!;

        [Required]
        public string HashPassword { get; set; } = default!;

        public int Crystals { get; set; } = 0;


        [Required]
        public Role Role { get; set; }

    }
}
