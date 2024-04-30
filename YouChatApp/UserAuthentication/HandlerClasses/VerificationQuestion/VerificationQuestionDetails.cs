using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.VerificationQuestion
{
    /// <summary>
    /// The "VerificationQuestionDetails" class represents details of a verification question, including the question, answer, and index.
    /// </summary>
    /// <remarks>
    /// This class provides properties to get or set the question, answer, and index of a verification question.
    /// </remarks>
    public class VerificationQuestionDetails
    {
        #region Private Fields

        /// <summary>
        /// The string "_question" represents the security question.
        /// </summary>
        private string _question;

        /// <summary>
        /// The string "_answer" represents the answer to the security question.
        /// </summary>
        private string _answer;

        /// <summary>
        /// The int "_index" represents the index of the security question.
        /// </summary>
        private int _index;

        #endregion

        #region Constructors

        /// <summary>
        /// The "VerificationQuestionDetails" constructor initializes a new instance of the <see cref="VerificationQuestionDetails"/> class with the specified question, answer, and index.
        /// </summary>
        /// <param name="question">The verification question.</param>
        /// <param name="answer">The answer to the verification question.</param>
        /// <param name="index">The index of the verification question.</param>
        /// <remarks>
        /// This constructor is used to create a new instance of the VerificationQuestionDetails class, setting the question, answer, and index of a verification question.
        /// </remarks>
        public VerificationQuestionDetails(string question, string answer, int index)
        {
            _question = question;
            _answer = answer;
            _index = index;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "Question" property represents a question.
        /// It gets or sets the question.
        /// </summary>
        /// <value>
        /// The question.
        /// </value>
        public string Question
        {
            get
            {
                return _question;
            }
            set
            {
                _question = value;
            }
        }

        /// <summary>
        /// The "Answer" property represents an answer to a question.
        /// It gets or sets the answer.
        /// </summary>
        /// <value>
        /// The answer to the question.
        /// </value>
        public string Answer 
        { 
            get 
            {
                return _answer;
            } 
            set 
            { 
                _answer = value;
            }
        }

        /// <summary>
        /// The "Index" property represents the index of an item.
        /// It gets or sets the index.
        /// </summary>
        /// <value>
        /// The index of the item.
        /// </value>
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
            }
        }

        #endregion
    }
}
