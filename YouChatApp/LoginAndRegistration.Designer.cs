using System;

namespace YouChatApp
{
    partial class LoginAndRegistration
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AnotherGenderRadioButton = new System.Windows.Forms.RadioButton();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.FemaleRadioButton = new System.Windows.Forms.RadioButton();
            this.birthDateLabel = new System.Windows.Forms.Label();
            this.MaleRadioButton = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cityTextbox = new System.Windows.Forms.TextBox();
            this.emailTextbox = new System.Windows.Forms.TextBox();
            this.lastnameTextbox = new System.Windows.Forms.TextBox();
            this.firstnameTextbox = new System.Windows.Forms.TextBox();
            this.registButton = new System.Windows.Forms.Button();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.cityLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.lastnameLabel = new System.Windows.Forms.Label();
            this.firstnameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.registLabel = new System.Windows.Forms.Label();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.ReturnToStarterScreen = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ViewPasswordButton = new System.Windows.Forms.Button();
            this.RegisterScreenButton = new System.Windows.Forms.Button();
            this.NoAccountLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.passwordloginTextbox = new System.Windows.Forms.TextBox();
            this.passwordloginButton = new System.Windows.Forms.Label();
            this.usernameloginLabel = new System.Windows.Forms.Label();
            this.loginLabel = new System.Windows.Forms.Label();
            this.usernameloginTextbox = new System.Windows.Forms.TextBox();
            this.YouChatHeadlineLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.TimeLabel = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AnotherGenderRadioButton);
            this.groupBox1.Controls.Add(this.GenderLabel);
            this.groupBox1.Controls.Add(this.FemaleRadioButton);
            this.groupBox1.Controls.Add(this.birthDateLabel);
            this.groupBox1.Controls.Add(this.MaleRadioButton);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.cityTextbox);
            this.groupBox1.Controls.Add(this.emailTextbox);
            this.groupBox1.Controls.Add(this.lastnameTextbox);
            this.groupBox1.Controls.Add(this.firstnameTextbox);
            this.groupBox1.Controls.Add(this.registButton);
            this.groupBox1.Controls.Add(this.passwordTextbox);
            this.groupBox1.Controls.Add(this.cityLabel);
            this.groupBox1.Controls.Add(this.emailLabel);
            this.groupBox1.Controls.Add(this.lastnameLabel);
            this.groupBox1.Controls.Add(this.firstnameLabel);
            this.groupBox1.Controls.Add(this.passwordLabel);
            this.groupBox1.Controls.Add(this.usernameLabel);
            this.groupBox1.Controls.Add(this.registLabel);
            this.groupBox1.Controls.Add(this.usernameTextbox);
            this.groupBox1.Controls.Add(this.ReturnToStarterScreen);
            this.groupBox1.Location = new System.Drawing.Point(368, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 382);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // AnotherGenderRadioButton
            // 
            this.AnotherGenderRadioButton.AutoSize = true;
            this.AnotherGenderRadioButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnotherGenderRadioButton.Location = new System.Drawing.Point(139, 294);
            this.AnotherGenderRadioButton.Name = "AnotherGenderRadioButton";
            this.AnotherGenderRadioButton.Size = new System.Drawing.Size(155, 22);
            this.AnotherGenderRadioButton.TabIndex = 23;
            this.AnotherGenderRadioButton.TabStop = true;
            this.AnotherGenderRadioButton.Text = "Another Gender";
            this.AnotherGenderRadioButton.UseVisualStyleBackColor = true;
            this.AnotherGenderRadioButton.Click += new System.EventHandler(this.registerDetails);
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenderLabel.Location = new System.Drawing.Point(16, 271);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GenderLabel.Size = new System.Drawing.Size(73, 18);
            this.GenderLabel.TabIndex = 20;
            this.GenderLabel.Text = "Gender:";
            // 
            // FemaleRadioButton
            // 
            this.FemaleRadioButton.AutoSize = true;
            this.FemaleRadioButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FemaleRadioButton.Location = new System.Drawing.Point(223, 273);
            this.FemaleRadioButton.Name = "FemaleRadioButton";
            this.FemaleRadioButton.Size = new System.Drawing.Size(84, 22);
            this.FemaleRadioButton.TabIndex = 22;
            this.FemaleRadioButton.TabStop = true;
            this.FemaleRadioButton.Text = "Female";
            this.FemaleRadioButton.UseVisualStyleBackColor = true;
            this.FemaleRadioButton.Click += new System.EventHandler(this.registerDetails);
            // 
            // birthDateLabel
            // 
            this.birthDateLabel.AutoSize = true;
            this.birthDateLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birthDateLabel.Location = new System.Drawing.Point(16, 245);
            this.birthDateLabel.Name = "birthDateLabel";
            this.birthDateLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.birthDateLabel.Size = new System.Drawing.Size(94, 18);
            this.birthDateLabel.TabIndex = 19;
            this.birthDateLabel.Text = "Birth Date:";
            // 
            // MaleRadioButton
            // 
            this.MaleRadioButton.AutoSize = true;
            this.MaleRadioButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaleRadioButton.Location = new System.Drawing.Point(134, 273);
            this.MaleRadioButton.Name = "MaleRadioButton";
            this.MaleRadioButton.Size = new System.Drawing.Size(63, 22);
            this.MaleRadioButton.TabIndex = 21;
            this.MaleRadioButton.TabStop = true;
            this.MaleRadioButton.Text = "Male";
            this.MaleRadioButton.UseVisualStyleBackColor = true;
            this.MaleRadioButton.Click += new System.EventHandler(this.registerDetails);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateTimePicker1.CustomFormat = " ";
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(134, 245);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(173, 23);
            this.dateTimePicker1.TabIndex = 16;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            this.dateTimePicker1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker1_KeyDown);
            // 
            // cityTextbox
            // 
            this.cityTextbox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityTextbox.Location = new System.Drawing.Point(134, 215);
            this.cityTextbox.Name = "cityTextbox";
            this.cityTextbox.Size = new System.Drawing.Size(173, 23);
            this.cityTextbox.TabIndex = 12;
            this.toolTip.SetToolTip(this.cityTextbox, "Don\'t use \'#\'");
            this.cityTextbox.TextChanged += new System.EventHandler(this.registerDetails);
            // 
            // emailTextbox
            // 
            this.emailTextbox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextbox.Location = new System.Drawing.Point(134, 185);
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.emailTextbox.Size = new System.Drawing.Size(173, 23);
            this.emailTextbox.TabIndex = 11;
            this.toolTip.SetToolTip(this.emailTextbox, "Don\'t use \'#\'");
            this.emailTextbox.TextChanged += new System.EventHandler(this.registerDetails);
            // 
            // lastnameTextbox
            // 
            this.lastnameTextbox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastnameTextbox.Location = new System.Drawing.Point(134, 155);
            this.lastnameTextbox.Name = "lastnameTextbox";
            this.lastnameTextbox.Size = new System.Drawing.Size(173, 23);
            this.lastnameTextbox.TabIndex = 10;
            this.toolTip.SetToolTip(this.lastnameTextbox, "Don\'t use \'#\'");
            this.lastnameTextbox.TextChanged += new System.EventHandler(this.registerDetails);
            // 
            // firstnameTextbox
            // 
            this.firstnameTextbox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstnameTextbox.Location = new System.Drawing.Point(134, 125);
            this.firstnameTextbox.Name = "firstnameTextbox";
            this.firstnameTextbox.Size = new System.Drawing.Size(173, 23);
            this.firstnameTextbox.TabIndex = 9;
            this.toolTip.SetToolTip(this.firstnameTextbox, "Don\'t use \'#\'");
            this.firstnameTextbox.TextChanged += new System.EventHandler(this.registerDetails);
            // 
            // registButton
            // 
            this.registButton.Enabled = false;
            this.registButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registButton.Location = new System.Drawing.Point(80, 344);
            this.registButton.Name = "registButton";
            this.registButton.Size = new System.Drawing.Size(90, 32);
            this.registButton.TabIndex = 13;
            this.registButton.Text = "Sign Up";
            this.registButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.registButton, "Press to sign up");
            this.registButton.UseVisualStyleBackColor = true;
            this.registButton.Click += new System.EventHandler(this.registButton_Click);
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextbox.Location = new System.Drawing.Point(134, 95);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.Size = new System.Drawing.Size(173, 23);
            this.passwordTextbox.TabIndex = 8;
            this.toolTip.SetToolTip(this.passwordTextbox, "Don\'t use \'#\'");
            this.passwordTextbox.TextChanged += new System.EventHandler(this.registerDetails);
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityLabel.Location = new System.Drawing.Point(16, 215);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cityLabel.Size = new System.Drawing.Size(42, 18);
            this.cityLabel.TabIndex = 7;
            this.cityLabel.Text = "city:";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(16, 185);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.emailLabel.Size = new System.Drawing.Size(55, 18);
            this.emailLabel.TabIndex = 6;
            this.emailLabel.Text = "email:";
            // 
            // lastnameLabel
            // 
            this.lastnameLabel.AutoSize = true;
            this.lastnameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastnameLabel.Location = new System.Drawing.Point(16, 155);
            this.lastnameLabel.Name = "lastnameLabel";
            this.lastnameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lastnameLabel.Size = new System.Drawing.Size(90, 18);
            this.lastnameLabel.TabIndex = 5;
            this.lastnameLabel.Text = "last name:";
            // 
            // firstnameLabel
            // 
            this.firstnameLabel.AutoSize = true;
            this.firstnameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstnameLabel.Location = new System.Drawing.Point(16, 125);
            this.firstnameLabel.Name = "firstnameLabel";
            this.firstnameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.firstnameLabel.Size = new System.Drawing.Size(92, 18);
            this.firstnameLabel.TabIndex = 4;
            this.firstnameLabel.Text = "first name:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(16, 95);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.passwordLabel.Size = new System.Drawing.Size(91, 18);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "password:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(16, 65);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.usernameLabel.Size = new System.Drawing.Size(93, 18);
            this.usernameLabel.TabIndex = 2;
            this.usernameLabel.Text = "username:";
            // 
            // registLabel
            // 
            this.registLabel.AutoSize = true;
            this.registLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registLabel.Location = new System.Drawing.Point(80, 19);
            this.registLabel.Name = "registLabel";
            this.registLabel.Size = new System.Drawing.Size(152, 32);
            this.registLabel.TabIndex = 1;
            this.registLabel.Text = "REGISTER";
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextbox.Location = new System.Drawing.Point(134, 65);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(173, 23);
            this.usernameTextbox.TabIndex = 0;
            this.toolTip.SetToolTip(this.usernameTextbox, "Don\'t use \'#\'");
            this.usernameTextbox.TextChanged += new System.EventHandler(this.registerDetails);
            // 
            // ReturnToStarterScreen
            // 
            this.ReturnToStarterScreen.BackColor = System.Drawing.Color.White;
            this.ReturnToStarterScreen.BackgroundImage = global::YouChatApp.Properties.Resources.returnArrow;
            this.ReturnToStarterScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ReturnToStarterScreen.Location = new System.Drawing.Point(12, 19);
            this.ReturnToStarterScreen.Name = "ReturnToStarterScreen";
            this.ReturnToStarterScreen.Size = new System.Drawing.Size(46, 29);
            this.ReturnToStarterScreen.TabIndex = 18;
            this.toolTip.SetToolTip(this.ReturnToStarterScreen, "Return to home screen");
            this.ReturnToStarterScreen.UseVisualStyleBackColor = false;
            this.ReturnToStarterScreen.Visible = false;
            this.ReturnToStarterScreen.Click += new System.EventHandler(this.ReturnToStarterScreen_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ViewPasswordButton);
            this.groupBox2.Controls.Add(this.RegisterScreenButton);
            this.groupBox2.Controls.Add(this.NoAccountLabel);
            this.groupBox2.Controls.Add(this.loginButton);
            this.groupBox2.Controls.Add(this.passwordloginTextbox);
            this.groupBox2.Controls.Add(this.passwordloginButton);
            this.groupBox2.Controls.Add(this.usernameloginLabel);
            this.groupBox2.Controls.Add(this.loginLabel);
            this.groupBox2.Controls.Add(this.usernameloginTextbox);
            this.groupBox2.Location = new System.Drawing.Point(64, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 325);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // ViewPasswordButton
            // 
            this.ViewPasswordButton.BackgroundImage = global::YouChatApp.Properties.Resources.showPassword;
            this.ViewPasswordButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ViewPasswordButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ViewPasswordButton.Location = new System.Drawing.Point(223, 95);
            this.ViewPasswordButton.Name = "ViewPasswordButton";
            this.ViewPasswordButton.Size = new System.Drawing.Size(22, 23);
            this.ViewPasswordButton.TabIndex = 18;
            this.ViewPasswordButton.UseMnemonic = false;
            this.ViewPasswordButton.UseVisualStyleBackColor = true;
            this.ViewPasswordButton.Click += new System.EventHandler(this.ViewPasswordButton_Click);
            // 
            // RegisterScreenButton
            // 
            this.RegisterScreenButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterScreenButton.Location = new System.Drawing.Point(75, 285);
            this.RegisterScreenButton.Name = "RegisterScreenButton";
            this.RegisterScreenButton.Size = new System.Drawing.Size(90, 32);
            this.RegisterScreenButton.TabIndex = 17;
            this.RegisterScreenButton.Text = "Sign Up";
            this.toolTip.SetToolTip(this.RegisterScreenButton, "Press to create an account");
            this.RegisterScreenButton.UseVisualStyleBackColor = true;
            this.RegisterScreenButton.Click += new System.EventHandler(this.RegisterScreenButton_Click);
            // 
            // NoAccountLabel
            // 
            this.NoAccountLabel.AutoSize = true;
            this.NoAccountLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoAccountLabel.Location = new System.Drawing.Point(16, 241);
            this.NoAccountLabel.Name = "NoAccountLabel";
            this.NoAccountLabel.Size = new System.Drawing.Size(157, 30);
            this.NoAccountLabel.TabIndex = 14;
            this.NoAccountLabel.Text = "Don\'t have an account?\r\nSign up here!";
            // 
            // loginButton
            // 
            this.loginButton.Enabled = false;
            this.loginButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.loginButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Location = new System.Drawing.Point(75, 166);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(90, 32);
            this.loginButton.TabIndex = 13;
            this.loginButton.Text = "Login";
            this.toolTip.SetToolTip(this.loginButton, "Press to login to the server");
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // passwordloginTextbox
            // 
            this.passwordloginTextbox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordloginTextbox.Location = new System.Drawing.Point(134, 95);
            this.passwordloginTextbox.Name = "passwordloginTextbox";
            this.passwordloginTextbox.PasswordChar = '*';
            this.passwordloginTextbox.Size = new System.Drawing.Size(90, 23);
            this.passwordloginTextbox.TabIndex = 8;
            this.passwordloginTextbox.TextChanged += new System.EventHandler(this.loginDetails);
            // 
            // passwordloginButton
            // 
            this.passwordloginButton.AutoSize = true;
            this.passwordloginButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordloginButton.Location = new System.Drawing.Point(16, 95);
            this.passwordloginButton.Name = "passwordloginButton";
            this.passwordloginButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.passwordloginButton.Size = new System.Drawing.Size(91, 18);
            this.passwordloginButton.TabIndex = 3;
            this.passwordloginButton.Text = "password:";
            // 
            // usernameloginLabel
            // 
            this.usernameloginLabel.AutoSize = true;
            this.usernameloginLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameloginLabel.Location = new System.Drawing.Point(16, 65);
            this.usernameloginLabel.Name = "usernameloginLabel";
            this.usernameloginLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.usernameloginLabel.Size = new System.Drawing.Size(93, 18);
            this.usernameloginLabel.TabIndex = 2;
            this.usernameloginLabel.Text = "username:";
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLabel.Location = new System.Drawing.Point(69, 16);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(101, 32);
            this.loginLabel.TabIndex = 1;
            this.loginLabel.Text = "LOGIN";
            // 
            // usernameloginTextbox
            // 
            this.usernameloginTextbox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameloginTextbox.Location = new System.Drawing.Point(134, 65);
            this.usernameloginTextbox.Name = "usernameloginTextbox";
            this.usernameloginTextbox.Size = new System.Drawing.Size(90, 23);
            this.usernameloginTextbox.TabIndex = 0;
            this.usernameloginTextbox.TextChanged += new System.EventHandler(this.loginDetails);
            // 
            // YouChatHeadlineLabel
            // 
            this.YouChatHeadlineLabel.AutoSize = true;
            this.YouChatHeadlineLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.YouChatHeadlineLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YouChatHeadlineLabel.Location = new System.Drawing.Point(200, 20);
            this.YouChatHeadlineLabel.Name = "YouChatHeadlineLabel";
            this.YouChatHeadlineLabel.Size = new System.Drawing.Size(475, 150);
            this.YouChatHeadlineLabel.TabIndex = 15;
            this.YouChatHeadlineLabel.Text = "WELCOME TO\r\nYOUCHAT";
            this.YouChatHeadlineLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 1000;
            this.toolTip.InitialDelay = 150;
            this.toolTip.ReshowDelay = 100;
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.Location = new System.Drawing.Point(12, 539);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(0, 18);
            this.TimeLabel.TabIndex = 20;
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // LoginAndRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(859, 561);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.YouChatHeadlineLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(875, 600);
            this.MinimumSize = new System.Drawing.Size(875, 600);
            this.Name = "LoginAndRegistration";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Login & Registration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginRegistPage_FormClosing);
            this.Load += new System.EventHandler(this.LoginAndRegistration_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox usernameTextbox;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.Label emailLabel;
        public System.Windows.Forms.Label lastnameLabel;
        public System.Windows.Forms.Label firstnameLabel;
        public System.Windows.Forms.Label passwordLabel;
        public System.Windows.Forms.Label usernameLabel;
        public System.Windows.Forms.Label registLabel;
        public System.Windows.Forms.TextBox cityTextbox;
        public System.Windows.Forms.TextBox emailTextbox;
        public System.Windows.Forms.TextBox lastnameTextbox;
        public System.Windows.Forms.TextBox firstnameTextbox;
        public System.Windows.Forms.TextBox passwordTextbox;
        public System.Windows.Forms.Label cityLabel;
        public System.Windows.Forms.Button registButton;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button loginButton;
        public System.Windows.Forms.TextBox passwordloginTextbox;
        public System.Windows.Forms.Label passwordloginButton;
        public System.Windows.Forms.Label usernameloginLabel;
        public System.Windows.Forms.Label loginLabel;
        public System.Windows.Forms.TextBox usernameloginTextbox;
        private System.Windows.Forms.Label YouChatHeadlineLabel;
        private System.Windows.Forms.Button RegisterScreenButton;
        private System.Windows.Forms.Button ReturnToStarterScreen;
        private System.Windows.Forms.Label NoAccountLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button ViewPasswordButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Timer Timer;
        public System.Windows.Forms.Label GenderLabel;
        public System.Windows.Forms.Label birthDateLabel;
        private System.Windows.Forms.RadioButton MaleRadioButton;
        private System.Windows.Forms.RadioButton FemaleRadioButton;
        private System.Windows.Forms.RadioButton AnotherGenderRadioButton;
    }
}

