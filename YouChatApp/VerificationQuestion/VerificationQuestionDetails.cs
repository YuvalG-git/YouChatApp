using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.VerificationQuestion
{
    public class VerificationQuestionDetails
    {
        private string _question;
        private string _answer;
        private int _index;

        public string Question { get => _question; set => _question = value; }
        public string Answer { get => _answer; set => _answer = value; }
        public int Index { get => _index; set => _index = value; }

        public VerificationQuestionDetails(string question, string answer, int index)
        {
            _question = question;
            _answer = answer;
            _index = index;
        }
    }
}
