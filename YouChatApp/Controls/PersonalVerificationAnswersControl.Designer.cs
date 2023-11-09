namespace YouChatApp.Controls
{
    partial class PersonalVerificationAnswersControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PersonalVerificationQuestionHeadlineLabel = new System.Windows.Forms.Label();
            this.PersonalVerificationQuestionsPanel = new System.Windows.Forms.Panel();
            this.ApproveVerificationInformationCustomButton = new YouChatApp.Controls.CustomButton();
            this.VerificationAnswerLabel = new System.Windows.Forms.Label();
            this.VerificationAnswerTextBox = new YouChatApp.Controls.CustomTextBox();
            this.VerificationQuestionLabel = new System.Windows.Forms.Label();
            this.RightScrollCustomButton = new YouChatApp.Controls.CustomButton();
            this.VerificationQuestionCustomComboBox = new System.Windows.Forms.ComboBox();
            this.VerificationQuestionNumberLabel = new System.Windows.Forms.Label();
            this.LeftScrollCustomButton = new YouChatApp.Controls.CustomButton();
            this.PersonalVerificationQuestionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PersonalVerificationQuestionHeadlineLabel
            // 
            this.PersonalVerificationQuestionHeadlineLabel.AutoSize = true;
            this.PersonalVerificationQuestionHeadlineLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersonalVerificationQuestionHeadlineLabel.Location = new System.Drawing.Point(18, 4);
            this.PersonalVerificationQuestionHeadlineLabel.Name = "PersonalVerificationQuestionHeadlineLabel";
            this.PersonalVerificationQuestionHeadlineLabel.Size = new System.Drawing.Size(365, 28);
            this.PersonalVerificationQuestionHeadlineLabel.TabIndex = 47;
            this.PersonalVerificationQuestionHeadlineLabel.Text = "Personal Verification Question";
            // 
            // PersonalVerificationQuestionsPanel
            // 
            this.PersonalVerificationQuestionsPanel.Controls.Add(this.ApproveVerificationInformationCustomButton);
            this.PersonalVerificationQuestionsPanel.Controls.Add(this.VerificationAnswerLabel);
            this.PersonalVerificationQuestionsPanel.Controls.Add(this.VerificationAnswerTextBox);
            this.PersonalVerificationQuestionsPanel.Controls.Add(this.VerificationQuestionLabel);
            this.PersonalVerificationQuestionsPanel.Controls.Add(this.RightScrollCustomButton);
            this.PersonalVerificationQuestionsPanel.Controls.Add(this.VerificationQuestionCustomComboBox);
            this.PersonalVerificationQuestionsPanel.Controls.Add(this.VerificationQuestionNumberLabel);
            this.PersonalVerificationQuestionsPanel.Controls.Add(this.LeftScrollCustomButton);
            this.PersonalVerificationQuestionsPanel.Location = new System.Drawing.Point(0, 40);
            this.PersonalVerificationQuestionsPanel.Name = "PersonalVerificationQuestionsPanel";
            this.PersonalVerificationQuestionsPanel.Size = new System.Drawing.Size(400, 200);
            this.PersonalVerificationQuestionsPanel.TabIndex = 46;
            // 
            // ApproveVerificationInformationCustomButton
            // 
            this.ApproveVerificationInformationCustomButton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ApproveVerificationInformationCustomButton.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.ApproveVerificationInformationCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ApproveVerificationInformationCustomButton.BorderRadius = 10;
            this.ApproveVerificationInformationCustomButton.BorderSize = 0;
            this.ApproveVerificationInformationCustomButton.Circular = false;
            this.ApproveVerificationInformationCustomButton.Enabled = false;
            this.ApproveVerificationInformationCustomButton.FlatAppearance.BorderSize = 0;
            this.ApproveVerificationInformationCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApproveVerificationInformationCustomButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApproveVerificationInformationCustomButton.ForeColor = System.Drawing.Color.White;
            this.ApproveVerificationInformationCustomButton.Location = new System.Drawing.Point(125, 150);
            this.ApproveVerificationInformationCustomButton.Name = "ApproveVerificationInformationCustomButton";
            this.ApproveVerificationInformationCustomButton.Size = new System.Drawing.Size(150, 40);
            this.ApproveVerificationInformationCustomButton.TabIndex = 0;
            this.ApproveVerificationInformationCustomButton.Text = "Continue";
            this.ApproveVerificationInformationCustomButton.TextColor = System.Drawing.Color.White;
            this.ApproveVerificationInformationCustomButton.UseVisualStyleBackColor = false;
            // 
            // VerificationAnswerLabel
            // 
            this.VerificationAnswerLabel.AutoSize = true;
            this.VerificationAnswerLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerificationAnswerLabel.Location = new System.Drawing.Point(19, 99);
            this.VerificationAnswerLabel.Name = "VerificationAnswerLabel";
            this.VerificationAnswerLabel.Size = new System.Drawing.Size(74, 18);
            this.VerificationAnswerLabel.TabIndex = 44;
            this.VerificationAnswerLabel.Text = "Answer:";
            // 
            // VerificationAnswerTextBox
            // 
            this.VerificationAnswerTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.VerificationAnswerTextBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.VerificationAnswerTextBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.VerificationAnswerTextBox.BorderRadius = 0;
            this.VerificationAnswerTextBox.BorderSize = 2;
            this.VerificationAnswerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerificationAnswerTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.VerificationAnswerTextBox.IsFocused = false;
            this.VerificationAnswerTextBox.Location = new System.Drawing.Point(124, 99);
            this.VerificationAnswerTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.VerificationAnswerTextBox.MaxLength = 32767;
            this.VerificationAnswerTextBox.Multiline = false;
            this.VerificationAnswerTextBox.Name = "VerificationAnswerTextBox";
            this.VerificationAnswerTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.VerificationAnswerTextBox.PasswordChar = false;
            this.VerificationAnswerTextBox.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.VerificationAnswerTextBox.PlaceHolderText = "Enter Username";
            this.VerificationAnswerTextBox.ReadOnly = false;
            this.VerificationAnswerTextBox.Size = new System.Drawing.Size(254, 35);
            this.VerificationAnswerTextBox.TabIndex = 34;
            this.VerificationAnswerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.VerificationAnswerTextBox.TextContent = "";
            this.VerificationAnswerTextBox.UnderlineStyle = false;
            // 
            // VerificationQuestionLabel
            // 
            this.VerificationQuestionLabel.AutoSize = true;
            this.VerificationQuestionLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerificationQuestionLabel.Location = new System.Drawing.Point(19, 54);
            this.VerificationQuestionLabel.Name = "VerificationQuestionLabel";
            this.VerificationQuestionLabel.Size = new System.Drawing.Size(85, 18);
            this.VerificationQuestionLabel.TabIndex = 43;
            this.VerificationQuestionLabel.Text = "Question:";
            // 
            // RightScrollCustomButton
            // 
            this.RightScrollCustomButton.BackColor = System.Drawing.Color.Transparent;
            this.RightScrollCustomButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.RightScrollCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.RightScrollArrow;
            this.RightScrollCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RightScrollCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.RightScrollCustomButton.BorderRadius = 0;
            this.RightScrollCustomButton.BorderSize = 0;
            this.RightScrollCustomButton.Circular = false;
            this.RightScrollCustomButton.Enabled = false;
            this.RightScrollCustomButton.FlatAppearance.BorderSize = 0;
            this.RightScrollCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RightScrollCustomButton.ForeColor = System.Drawing.Color.White;
            this.RightScrollCustomButton.Location = new System.Drawing.Point(5, 10);
            this.RightScrollCustomButton.Name = "RightScrollCustomButton";
            this.RightScrollCustomButton.Size = new System.Drawing.Size(30, 30);
            this.RightScrollCustomButton.TabIndex = 5;
            this.RightScrollCustomButton.TextColor = System.Drawing.Color.White;
            this.RightScrollCustomButton.UseVisualStyleBackColor = false;
            // 
            // VerificationQuestionCustomComboBox
            // 
            this.VerificationQuestionCustomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VerificationQuestionCustomComboBox.FormattingEnabled = true;
            this.VerificationQuestionCustomComboBox.Items.AddRange(new object[] {
            "Select a quesion 😊",
            "What was your first pet’s name?",
            "What’s the name of the city where you were born?",
            "What was your childhood nickname?",
            "What’s the name of the city where your parents met?",
            "What’s the first name of your oldest cousin?",
            "What’s the name of the first school you attended? ",
            "What is your favorite book?",
            "What was the make and model of your first car?",
            "What is your favorite vacation destination?",
            "Who was your childhood best friend?",
            "What is the name of your favorite teacher in school?",
            "What is the middle name of your youngest sibling?",
            "What is the name of your favorite childhood toy?",
            "What is the name of the street you grew up on?",
            "What is your mother\'s maiden name?",
            "What is the name of the first company you worked for?",
            "What is your favorite color?",
            "What is your favorite season?",
            "What is your favorite food?",
            "What is your favorite movie?",
            "What is your favorite animal?",
            "What is your favorite sport?",
            "What is your favorite holiday?",
            "What is your favorite hobby?",
            "What is your favorite fruit?",
            "What is your favorite childhood cartoon character?",
            "What is the name of your first stuffed animal?",
            "What is your favorite type of music?",
            "What is your favorite TV show?",
            "What is your favorite ice cream flavor?",
            "What is your favorite childhood game?",
            "What is the name of the street you grew up on?",
            "What is your favorite fictional character?",
            "What is your favorite historical figure?",
            "What is the name of the first school you attended?",
            "What is your favorite superhero?",
            "What is the name of your favorite childhood book?",
            "What is your favorite type of vehicle (e.g., car, bicycle)?",
            "What is your favorite city to visit?",
            "What is your favorite restaurant?",
            "What is your favorite flower?",
            "What is your favorite clothing brand?",
            "What is your favorite drink (non-alcoholic)?",
            "What is your favorite board game?",
            "What is the name of your favorite childhood teacher?",
            "What is your favorite type of dessert?"});
            this.VerificationQuestionCustomComboBox.Location = new System.Drawing.Point(124, 55);
            this.VerificationQuestionCustomComboBox.Name = "VerificationQuestionCustomComboBox";
            this.VerificationQuestionCustomComboBox.Size = new System.Drawing.Size(254, 21);
            this.VerificationQuestionCustomComboBox.TabIndex = 40;
            // 
            // VerificationQuestionNumberLabel
            // 
            this.VerificationQuestionNumberLabel.AutoSize = true;
            this.VerificationQuestionNumberLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerificationQuestionNumberLabel.Location = new System.Drawing.Point(30, 15);
            this.VerificationQuestionNumberLabel.Name = "VerificationQuestionNumberLabel";
            this.VerificationQuestionNumberLabel.Size = new System.Drawing.Size(36, 21);
            this.VerificationQuestionNumberLabel.TabIndex = 1;
            this.VerificationQuestionNumberLabel.Text = "1/5";
            // 
            // LeftScrollCustomButton
            // 
            this.LeftScrollCustomButton.BackColor = System.Drawing.Color.Transparent;
            this.LeftScrollCustomButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.LeftScrollCustomButton.BackgroundImage = global::YouChatApp.Properties.Resources.LeftScrollArrow;
            this.LeftScrollCustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LeftScrollCustomButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.LeftScrollCustomButton.BorderRadius = 0;
            this.LeftScrollCustomButton.BorderSize = 0;
            this.LeftScrollCustomButton.Circular = false;
            this.LeftScrollCustomButton.Enabled = false;
            this.LeftScrollCustomButton.FlatAppearance.BorderSize = 0;
            this.LeftScrollCustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeftScrollCustomButton.ForeColor = System.Drawing.Color.White;
            this.LeftScrollCustomButton.Location = new System.Drawing.Point(60, 10);
            this.LeftScrollCustomButton.Name = "LeftScrollCustomButton";
            this.LeftScrollCustomButton.Size = new System.Drawing.Size(30, 30);
            this.LeftScrollCustomButton.TabIndex = 4;
            this.LeftScrollCustomButton.TextColor = System.Drawing.Color.White;
            this.LeftScrollCustomButton.UseVisualStyleBackColor = false;
            // 
            // PersonalVerificationAnswersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PersonalVerificationQuestionHeadlineLabel);
            this.Controls.Add(this.PersonalVerificationQuestionsPanel);
            this.Name = "PersonalVerificationAnswersControl";
            this.Size = new System.Drawing.Size(400, 240);
            this.PersonalVerificationQuestionsPanel.ResumeLayout(false);
            this.PersonalVerificationQuestionsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PersonalVerificationQuestionHeadlineLabel;
        private System.Windows.Forms.Panel PersonalVerificationQuestionsPanel;
        private CustomButton ApproveVerificationInformationCustomButton;
        private System.Windows.Forms.Label VerificationAnswerLabel;
        private CustomTextBox VerificationAnswerTextBox;
        private System.Windows.Forms.Label VerificationQuestionLabel;
        private CustomButton RightScrollCustomButton;
        private System.Windows.Forms.ComboBox VerificationQuestionCustomComboBox;
        private System.Windows.Forms.Label VerificationQuestionNumberLabel;
        private CustomButton LeftScrollCustomButton;
    }
}
