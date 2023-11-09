using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.VerificationQuestion
{
    internal class VerificationQuestionHandler
    {
        public static VerificationQuestionDetails[] VerificationQuestionDetails { get; set; }
        public static bool wasSelected{ get; set; }

        public VerificationQuestionHandler(int questionNumber)
        {
            VerificationQuestionDetails = new VerificationQuestionDetails[questionNumber];
            wasSelected = false;
        }

    }
}
