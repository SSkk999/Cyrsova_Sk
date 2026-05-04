using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.BLL.Dto.Auth
{
    public class ChangePasswordDto
    {
        public string Id { get; set; } = string.Empty;
        public required string OldPassword { get; set; }
        public required string NewPassword { get; set; }
    }
}
