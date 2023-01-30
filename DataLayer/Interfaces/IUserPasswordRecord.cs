using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IUserPasswordRecord
    {
        public int UserID { get; set; }
        public int QuestionID { get; set; }
        public string? Answer { get; set; } 
    }
}
