using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.BLL.Dto.Answer
{
    public class AnswerDto
    {

        public string Id { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

            public bool IsCorrect { get; set; }
    }
}