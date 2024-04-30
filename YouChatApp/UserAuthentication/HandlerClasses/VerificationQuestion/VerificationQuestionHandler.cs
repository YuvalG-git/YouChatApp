using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.VerificationQuestion
{
    /// <summary>
    /// The "VerificationQuestionHandler" class manages verification questions, including their details and selection status.
    /// </summary>
    /// <remarks>
    /// This class provides properties to get or set an array of verification question details and the selection status.
    /// </remarks>
    public class VerificationQuestionHandler
    {
        #region Private Fields

        /// <summary>
        /// The array "verificationQuestionDetails" contains the details of verification questions.
        /// </summary>
        private VerificationQuestionDetails[] verificationQuestionDetails;

        /// <summary>
        /// The bool "wasSelected" indicates whether an item was selected.
        /// </summary>
        private bool wasSelected;

        #endregion

        #region Constructors

        /// <summary>
        /// The "VerificationQuestionHandler" constructor initializes a new instance of the <see cref="VerificationQuestionHandler"/> class with the specified number of verification questions.
        /// </summary>
        /// <param name="questionNumber">The number of verification questions.</param>
        /// <remarks>
        /// This constructor is used to create a new instance of the VerificationQuestionHandler class, initializing an array of verification question details and setting the selection status to false.
        /// </remarks>
        public VerificationQuestionHandler(int questionNumber)
        {
            verificationQuestionDetails = new VerificationQuestionDetails[questionNumber];
            wasSelected = false;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "VerificationQuestionDetails" property represents an array of verification question details.
        /// It gets or sets the verification question details.
        /// </summary>
        /// <value>
        /// An array of verification question details.
        /// </value>
        public VerificationQuestionDetails[] VerificationQuestionDetails
        {
            get
            {
                return verificationQuestionDetails;
            }
            set
            {
                verificationQuestionDetails = value;
            }
        }

        /// <summary>
        /// The "WasSelected" property indicates whether an item was selected.
        /// It gets or sets the selection status.
        /// </summary>
        /// <value>
        /// True if the item was selected; otherwise, false.
        /// </value>
        public bool WasSelected
        {
            get
            {
                return wasSelected;
            }
            set
            {
                wasSelected = value;
            }
        }

        #endregion
    }
}
