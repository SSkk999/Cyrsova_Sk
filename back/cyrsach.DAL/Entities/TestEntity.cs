using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.DAL.Entities
{
    public class TestEntity : BaseEntity
    {


        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string AuthorId { get; set; } = null!;
        public UserEntity Author { get; set; } = null!;

        public string Time { get; set; } = null!;


        public string QuestionCount { get; set; } = null!;



        public List<QuestionEntity> Questions { get; set; } = new();
    }
}
