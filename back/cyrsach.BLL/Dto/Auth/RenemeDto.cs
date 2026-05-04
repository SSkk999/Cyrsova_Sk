using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.BLL.Dto.Auth
{
    public class RenemeDto
    {
        public required string NewName { get; set; }

        public string OldName { get; set; } = string.Empty;

    }
}
