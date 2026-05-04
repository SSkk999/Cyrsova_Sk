using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cyrsach.BLL.Dto.Question;
namespace cyrsach.BLL.Dto.Test
{
    public class TestDto
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string Time { get; set; } = null!;

        public string QuestionCount { get; set; } = null!;
        public string AuthorName { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public List<QuestionDto> Questions { get; set; } = new();
    }
}
