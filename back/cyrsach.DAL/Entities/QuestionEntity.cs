using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.DAL.Entities
{
    public class QuestionEntity : BaseEntity
    {
        public string Text { get; set; } = null!;

        public string TestId { get; set; } = null!;
        public TestEntity Test { get; set; } = null!;

        public List<AnswerEntity> Answers { get; set; } = new();
    }
}
