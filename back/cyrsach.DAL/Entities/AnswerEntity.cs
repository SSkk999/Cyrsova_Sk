using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.DAL.Entities
{
    public class AnswerEntity : BaseEntity
    {

        public string Text { get; set; } = null!;
        public bool IsCorrect { get; set; }

        public string QuestionId { get; set; } = null!;
        public QuestionEntity Question { get; set; } = null!;
    }
}
