using cyrsach.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cyrsach.BLL.Dto.Auth
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Поле 'Name' є обов'язковим")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Поле 'Password' є обов'язковим")]
        public required string Password { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required Role Role { get; set; }
    }
}
