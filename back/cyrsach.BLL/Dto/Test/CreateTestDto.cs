using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cyrsach.BLL.Dto.Question;
namespace cyrsach.BLL.Dto.Test
{
    public class CreateTestDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string AuthorId { get; set; } = null!;
        public string QuestionCount { get; set; } = null!;
        public string Time { get; set; } = null!;

    }
}
