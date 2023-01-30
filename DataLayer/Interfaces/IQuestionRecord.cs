using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IQuestionRecord
    {
        public string? Question { get; set; }
        public int QuestionID { get; set; }

    }
}
