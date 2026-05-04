using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cyrsach.BLL.Dto.Answer;
namespace cyrsach.BLL.Dto.Question
{
    public class QuestionDto
    {

        public string Id { get; set; }
        public string Text { get; set; } = null!;

        public List<AnswerDto> Answers { get; set; } = new();
    }
}
