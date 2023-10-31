using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.VerificationQuestion
{
    internal class VerificationQuestionHandler
    {
        public static VerificationQuestionDetails[] VerificationQuestionDetails;
        
        public VerificationQuestionHandler(int questionNumber)
        {
            VerificationQuestionDetails = new VerificationQuestionDetails[questionNumber];
        }

    }
}
