using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.BLL.Dto.Answer
{
    public class CreateAnswerDto
    {
        public string Text { get; set; } = null!;
        public bool IsCorrect { get; set; }

        public string Questionid { get; set; } = null!;
    }
}
