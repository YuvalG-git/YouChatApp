using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Messaging;
using System.Net.NetworkInformation;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using Button = System.Windows.Forms.Button;

namespace YouChatApp.AttachedFiles
{
    public partial class EmojiKeyboard : Form
    {

        public event EventHandler<PictureBoxEventArgs> EmojiPress; // Event to notify Form2

        int ControlWidth = 791;
        int ControlHeight = 406; //maybe in the future to use size based on the form's size
        List<Emoji> RichTextBoxContent;
        int EmojiCategories = 9;
        List<List<EmojiObject>> EmojiImagePathListOfLists = new List<List<EmojiObject>>();
        private bool _isText;
        public Image ImageToSend { get; set; }

        private void InitializeEmojiImagePathListOfLists()
        {
            ResourceSet ResourceSet = EmojiResourceSet.resourceSetArray[1]; //represnts people emoji
            bool WasHandled;
            EmojiObject EmojiToBeInserted;
            Image EmojiToBeInsertedImage;
            string EmojiToBeInsertedName;
            string EmojiToBeInsertedID;
            string EmojiToBeInsertedColorID;
            if (ResourceSet != null)
            {
                foreach (DictionaryEntry entry in ResourceSet)
                {
                    WasHandled = false;
                    string resourceName = entry.Key.ToString();
                    string ResourceNameCode = resourceName;
                    if (ResourceNameCode.StartsWith("_"))
                    {
                        ResourceNameCode = resourceName.Substring(1);
                    }
                    string[] ResourceNameCodeContent = ResourceNameCode.Split('_');
                    int ResourceNameLength = ResourceNameCodeContent.Length;
                    if (entry.Value is Image image)
                    {
                        EmojiToBeInsertedImage = (Image)entry.Value;
                        EmojiToBeInsertedName = resourceName;
                        foreach (List<EmojiObject> EmojiPack in EmojiImagePathListOfLists)
                        {
                            foreach (EmojiObject Emoji in EmojiPack)
                            {
                                if (ResourceNameLength == 1)
                                {
                                    if (Emoji.EmojiID == ResourceNameCode)
                                    {
                                        EmojiToBeInsertedID = ResourceNameCode;
                                        EmojiToBeInserted = new EmojiObject(EmojiToBeInsertedImage, EmojiToBeInsertedName, EmojiToBeInsertedID, ResourceNameLength);
                                        EmojiPack.Insert(0, EmojiToBeInserted); //insert as first
                                        WasHandled = true;
                                    }
                                }
                                else if (ResourceNameLength == 2)
                                {
                                    if (Emoji.EmojiID == ResourceNameCodeContent[0])
                                    {
                                        EmojiToBeInsertedID = ResourceNameCodeContent[0];
                                        EmojiToBeInsertedColorID = ResourceNameCodeContent[1];
                                        EmojiToBeInserted = new EmojiObject(EmojiToBeInsertedImage, EmojiToBeInsertedName, EmojiToBeInsertedID, ResourceNameLength);
                                        InsertToListByABC(EmojiPack, EmojiToBeInsertedColorID, EmojiToBeInserted);
                                        WasHandled = true;
                                    }
                                }
                                else if (ResourceNameLength == 4)
                                {
                                    if (Emoji.EmojiID == ResourceNameCodeContent[0])
                                    {
                                        EmojiToBeInsertedID = ResourceNameCodeContent[0];
                                        EmojiToBeInserted = new EmojiObject(EmojiToBeInsertedImage, EmojiToBeInsertedName, EmojiToBeInsertedID, ResourceNameLength);
                                        EmojiPack.Insert(0, EmojiToBeInserted); //insert as first
                                        WasHandled = true;
                                    }
                                }
                                else if (ResourceNameLength == 5)
                                {
                                    if (Emoji.EmojiID == ResourceNameCodeContent[0])
                                    {
                                        EmojiToBeInsertedID = ResourceNameCodeContent[0];
                                        EmojiToBeInserted = new EmojiObject(EmojiToBeInsertedImage, EmojiToBeInsertedName, EmojiToBeInsertedID, ResourceNameLength);
                                        EmojiPack.Insert(0, EmojiToBeInserted); //insert as first
                                        WasHandled = true;
                                    }
                                }
                                if (!WasHandled)
                                {
                                    EmojiToBeInsertedID = ResourceNameCode;
                                    EmojiToBeInserted = new EmojiObject(EmojiToBeInsertedImage, EmojiToBeInsertedName, EmojiToBeInsertedID, ResourceNameLength);
                                    List<EmojiObject> NewEmojiListToBeInserted = new List<EmojiObject>();
                                    NewEmojiListToBeInserted.Add(EmojiToBeInserted);
                                    EmojiImagePathListOfLists.Add(NewEmojiListToBeInserted);
                                }
                            }
                        }
                    }
                   
                    //1- regular emoji
                    //2 - colored regular emoji
                    //4 - special amoji
                    //5 - colored special emoji
                    // the second one is the one i should be comparing

                }
            }
        }

        private void InsertToListByABC(List<EmojiObject> EmojiPack, string SpecialId, EmojiObject EmojiToBeInserted)
        {
            Boolean WasInserted = false;
            for (int i = 0; (i < EmojiPack.Count) && (!WasInserted); i++)
            {
                if (EmojiPack[i].EmojiColorID != "first")
                {
                    if (IsFirstStringFirstInABC(SpecialId, EmojiPack[i].EmojiColorID))
                    {
                        EmojiPack.Insert(i, EmojiToBeInserted); 
                        WasInserted = true;
                    }
                }
            }
        }

        private bool IsFirstStringFirstInABC (string String1, string String2)
        {
            int comparisonResult = string.Compare(String1, String2, StringComparison.OrdinalIgnoreCase);
            return comparisonResult < 0;
        }
        public void InitializeEmojiPictureBoxList()
        {
            EmojiPictureBoxArrayOfLists = new List<PictureBox>[EmojiCategories];
            for (int i = 0; i < EmojiCategories; i++)
            {
                EmojiPictureBoxArrayOfLists[i] = new List<System.Windows.Forms.PictureBox>();
                if (i!=1)
                {
                    SetTab(i);
                }
                else
                {
                    InitializeEmojiImagePathListOfLists();
                }

            }
        }
        public void InitializeEmojiPanelArray()
        {
            EmojiCategoryPanel = new Panel[EmojiCategories];
            for (int i = 0; i < EmojiCategories; i++)
            {
                EmojiCategoryPanel[i] = new System.Windows.Forms.Panel();
                this.EmojiCategoryPanel[i].AutoScroll = true;
                this.EmojiCategoryPanel[i].Location = new System.Drawing.Point(4, 40);
                this.EmojiCategoryPanel[i].Size = new System.Drawing.Size(ControlWidth, ControlHeight);
                this.EmojiCategoryPanel[i].TabIndex = 8;
                this.Controls.Add(this.EmojiCategoryPanel[i]);
            }
            this.EmojiCategoryPanel[0].Name = "SmileyEmojiPanel";
            this.EmojiCategoryPanel[1].Name = "PeopleEmojiPanel";
            this.EmojiCategoryPanel[2].Name = "AnimalsAndNatureEmojiPanel";
            this.EmojiCategoryPanel[3].Name = "FoodAndDrinkEmojiPanel";
            this.EmojiCategoryPanel[4].Name = "ActivityEmojiPanel";
            this.EmojiCategoryPanel[5].Name = "TravelAndPlacesEmojiPanel";
            this.EmojiCategoryPanel[6].Name = "ObjectsEmojiPanel";
            this.EmojiCategoryPanel[7].Name = "SymbolsEmojiPanel";
            this.EmojiCategoryPanel[8].Name = "FlagsEmojiPanel";
        }
        public void InitializeEmojiTabPageArray()
        {
            EmojiCategoryTabPage = new TabPage[EmojiCategories];
            for (int i = 0; i < EmojiCategories; i++)
            {
                EmojiCategoryTabPage[i] = new System.Windows.Forms.TabPage();
                this.EmojiCategoryTabPage[i].ImageIndex = i;
                this.EmojiCategoryTabPage[i].Location = new System.Drawing.Point(4, 40);
                this.EmojiCategoryTabPage[i].Padding = new System.Windows.Forms.Padding(3);
                this.EmojiCategoryTabPage[i].Size = new System.Drawing.Size(ControlWidth, ControlHeight);
                this.EmojiCategoryTabPage[i].TabIndex = EmojiCategories;
                this.EmojiCategoryTabPage[i].UseVisualStyleBackColor = true;
                this.EmojiCategoryTabPage[i].Controls.Add(this.EmojiCategoryPanel[i]);
                this.EmojiTabControl.Controls.Add(this.EmojiCategoryTabPage[i]);

            }
            this.EmojiCategoryTabPage[0].Name = "Smileys";
            this.EmojiCategoryTabPage[1].Name = "People";
            this.EmojiCategoryTabPage[2].Name = "Animals & Nature";
            this.EmojiCategoryTabPage[3].Name = "Food & Drink";
            this.EmojiCategoryTabPage[4].Name = "Activity";
            this.EmojiCategoryTabPage[5].Name = "Travel & Places";
            this.EmojiCategoryTabPage[6].Name = "Objects";
            this.EmojiCategoryTabPage[7].Name = "Symbols";
            this.EmojiCategoryTabPage[8].Name = "Flags";


        }
        public EmojiKeyboard(bool isText)
        {
            InitializeComponent();
            this.TopMost = true;
            _isText = isText;
            EmojiResourceSet.InitializeResourceSetArray(); //probably need this - to ask somebody...
            InitializeEmojiPanelArray();
            //string emojiPath = @"C:\Users\יובל\source\repos\YouChatApp\YouChatApp\EmojiIcons\Smileys\1f600.png"; // This is an example path, make sure to adjust it based on the actual emoji you want to use.
            //button2.BackgroundImage = Image.FromFile(emojiPath);
            //string l = "\u128309";
            //TabImageList.Images.Add["\u128309"];
            //TabPage1.ImageIndex = 3;
            InitializeEmojiTabPageArray();
            InitializeEmojiPictureBoxList();
            RichTextBoxContent = new List<Emoji>();
            EmojiPress += ServerCommunication.youChat.OnEmojiPress;
        }


        private Dictionary<string, Image> embeddedImages = new Dictionary<string, Image>();


        // Function to retrieve an image based on the unique identifier
        private Image GetImageByIdentifier(string uniqueIdentifier)
        {
            if (embeddedImages.ContainsKey(uniqueIdentifier))
            {
                return embeddedImages[uniqueIdentifier];
            }
            return null;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CreateMessageString());
            richTextBox1.ReadOnly = true;
            richTextBox1.Enabled = false;
        }

        //private void EmojiKeyboard_Deactivate(object sender, EventArgs e)
        //{
        //    this.Close();

        //}
        private string CreateMessageString()
        {
            bool PreviousWasChar = false;
            string message = ""; //בעיקרון אם הייתי מכניס את הערך הצאר הנכון הייתי עובר כל אחד ישירות ולוקח את הערך שלו אבל כרגע זה לא המצב אז..
            int Location = 0;
            foreach (Emoji EmojiType in RichTextBoxContent)
            {
                if (EmojiType is MessageChar)
                {
                    if (!PreviousWasChar)
                    {
                        PreviousWasChar = true;
                    }
                    MessageChar messageChar = (MessageChar)EmojiType;
                    message += messageChar.Char;
                    // message += richTextBox1.Text[Location];
                    Location++;

                }
                else
                {
                    MessageImage messageImage = (MessageImage)EmojiType;
                    if (PreviousWasChar)
                    {
                        message += "€";
                        PreviousWasChar = false;

                    }
                    messageImage.ResizeImage(20);
                    message += "¥" + messageImage.ImageName + "€";
                }

            }
            if (message.EndsWith("€"))
                message = message.Substring(0, message.Length - 1);
            return message;
        }
        public void SendEmoji(PictureBox pictureBox)
        {
            ImageToSend = pictureBox.Image;
            //needs to close if it was for group image otherwise not..
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void EmojiPictureBox_Click(object sender, EventArgs e)
        {

            //all of this is gonna be on the youchat form 
            //i will send the image and it be transformed to bitmap and copied there...


            //richTextBox1.Select(richTextBox1.Text.Length, 0);

            //int IndexToAdd = richTextBox1.SelectionStart;
            //MessageImage messageImage = new MessageImage();
            //Image ResizedImage = ((PictureBox)(sender)).Image;
            //Bitmap bitmap = new Bitmap(ResizedImage, 20, 20);
            //Clipboard.SetDataObject(bitmap);
            //messageImage.EmojiImage = ((PictureBox)(sender)).Image;
            //messageImage.ImageName = ((PictureBox)(sender)).Name;
            //messageImage.OnRichTextBoxImage = Clipboard.GetImage();
            //RichTextBoxContent.Insert(IndexToAdd, messageImage);
            //richTextBox1.Paste(); //the paste does " "
            //Clipboard.Clear();

            //if (richTextBox1.Text[IndexToAdd] == ' ')
            //{
            //    richTextBox1.Text.Remove(IndexToAdd, 0);

            //}
            PictureBox pictureBox = sender as PictureBox;
            if (true)
            {
                EmojiPress?.Invoke(this, new PictureBoxEventArgs(pictureBox));
            }
            else
            {
                SendEmoji(pictureBox);
            }


            //if (Clipboard.ContainsImage())
            //{
            //    Image pastedImage = Clipboard.GetImage();
            //    string uniqueIdentifier = Guid.NewGuid().ToString(); // Generate a unique ID
            //    embeddedImages.Add(uniqueIdentifier, pastedImage);

            //    // You can now associate the uniqueIdentifier with the pasted image
            //    // in the RichTextBox using the selected range or any other appropriate method
            //}
            // Select the recently pasted image
            //int start = richTextBox1.Text.IndexOf('\uFFFC'); // The placeholder character for the pasted image
            //int length = 1; // Length of the placeholder character

            //if (start >= 0)
            //{
            //    richTextBox1.Select(start, length);
            //    richTextBox1.SelectionProtected = true; // Prevent resizing of the selected image
            //}

        }
        private void SetTab(int TabNumber)
        {
            //ResourceSet resourceSet;
            //if (TabHeadLine == "Smiley")
            //{
            //    resourceSet = Properties.Smileys_Emoji.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
            //}
            //else
            //{
            //    resourceSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
            //}
            //int count = 0;
            //int x = 0;
            //int y = 0;
            //int PictureBoxSize = 36;
            //int PictureBoxGap = 4;
            //int maxXValue = EmojiCategoryTabPage[TabNumber].Size.Width - (2*PictureBoxSize + PictureBoxGap);
            //if (resourceSet != null)
            //{
            //    foreach (DictionaryEntry entry in resourceSet)
            //    {
            //        string resourceName = entry.Key.ToString();
            //        if (entry.Value is Image image)
            //        {

            //            this.EmojiPictureBoxArrayOfLists[TabNumber].Add(new PictureBox());
            //            EmojiPictureBoxArrayOfLists[TabNumber][count].Name = resourceName;
            //            EmojiPictureBoxArrayOfLists[TabNumber][count].Image = (Image)entry.Value;
            //            EmojiPictureBoxArrayOfLists[TabNumber][count].Location = new Point(x, y);
            //            EmojiPictureBoxArrayOfLists[TabNumber][count].Size = new Size(PictureBoxSize, PictureBoxSize);
            //            EmojiPictureBoxArrayOfLists[TabNumber][count].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            //            EmojiPictureBoxArrayOfLists[TabNumber][count].Padding = new System.Windows.Forms.Padding(2);
            //            EmojiPictureBoxArrayOfLists[TabNumber][count].Click += new System.EventHandler(EmojiPictureBox_Click);
            //            EmojiPictureBoxArrayOfLists[TabNumber][count].MouseEnter += new System.EventHandler(EmojiPictureBox_MouseEnter);
            //            EmojiPictureBoxArrayOfLists[TabNumber][count].MouseLeave += new System.EventHandler(EmojiPictureBox_MouseLeave);


            //            this.Controls.Add(this.EmojiPictureBoxArrayOfLists[TabNumber][count]);
            //            this.EmojiCategoryTabPage[TabNumber].Controls.Add(this.EmojiPictureBoxArrayOfLists[TabNumber][count]);
            //            if (x < maxXValue)
            //                x += PictureBoxSize + PictureBoxGap;
            //            else
            //            {
            //                y += PictureBoxSize + PictureBoxGap;
            //                x = 0;
            //            }
            //            count++;

            //        }
            //    }
            //}


            //if (TabNumber == //anything but people do the code above else call the function that does something)
            int count = 0;
            int x = 0;
            int y = 0;
            int PictureBoxSize = 36;
            int PictureBoxGap = 4;
            int maxXValue = EmojiCategoryTabPage[TabNumber].Size.Width - (2 * PictureBoxSize + PictureBoxGap);
            ResourceSet ResourceSet = EmojiResourceSet.resourceSetArray[TabNumber];

            if (ResourceSet != null)
            {
                foreach (DictionaryEntry entry in ResourceSet)
                {
                    string resourceName = entry.Key.ToString();
                    string ResourceNameCode = resourceName;
                    if (ResourceNameCode.StartsWith("_"))
                    {
                        ResourceNameCode = resourceName.Substring(1);
                    }
                    string[] ResourceNameCodeContent = ResourceNameCode.Split('_');
                    int ResourceNameLength = ResourceNameCodeContent.Length;
                    //if (ResourceNameLength == 1)
                    //{
                    //    //enter to as first
                    //    EmojiImagePathListOfLists.Add(new List<string> { ResourceNameCode });
                    //}
                    //else if (ResourceNameLength == 2)
                    //{
                    //    //foreach(List<string> ResourceNameCodeList in EmojiImagePathListOfLists)
                    //    //{
                    //    //    if
                    //    //}
                    //}
                    //1- regular emoji
                    //2 - colored regular emoji
                    //4 - special amoji
                    //5 - colored special emoji
                    // the second one is the one i should be comparing
                    if (entry.Value is Image image)
                    {

                        this.EmojiPictureBoxArrayOfLists[TabNumber].Add(new PictureBox());
                        EmojiPictureBoxArrayOfLists[TabNumber][count].Name = resourceName;
                        EmojiPictureBoxArrayOfLists[TabNumber][count].Image = (Image)entry.Value;
                        EmojiPictureBoxArrayOfLists[TabNumber][count].Location = new Point(x, y);
                        EmojiPictureBoxArrayOfLists[TabNumber][count].Size = new Size(PictureBoxSize, PictureBoxSize);
                        EmojiPictureBoxArrayOfLists[TabNumber][count].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        EmojiPictureBoxArrayOfLists[TabNumber][count].Padding = new System.Windows.Forms.Padding(2);
                        EmojiPictureBoxArrayOfLists[TabNumber][count].Click += new System.EventHandler(EmojiPictureBox_Click);
                        EmojiPictureBoxArrayOfLists[TabNumber][count].MouseEnter += new System.EventHandler(EmojiPictureBox_MouseEnter);
                        EmojiPictureBoxArrayOfLists[TabNumber][count].MouseLeave += new System.EventHandler(EmojiPictureBox_MouseLeave);


                        this.Controls.Add(this.EmojiPictureBoxArrayOfLists[TabNumber][count]);
                        this.EmojiCategoryTabPage[TabNumber].Controls.Add(this.EmojiPictureBoxArrayOfLists[TabNumber][count]);
                        this.EmojiCategoryPanel[TabNumber].Controls.Add(this.EmojiPictureBoxArrayOfLists[TabNumber][count]);
                        if (x < maxXValue)
                            x += PictureBoxSize + PictureBoxGap;
                        else
                        {
                            y += PictureBoxSize + PictureBoxGap;
                            x = 0;
                        }
                        count++;

                    }
                }
            }

        }

        private void EmojiPictureBox_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)(sender)).BackColor = System.Drawing.Color.LightGray;
        }
        private void EmojiPictureBox_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)(sender)).BackColor = Color.Transparent;
        }

        private void richTextBox1_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            //// Adjust the size of images to a fixed value to prevent resizing
            //foreach (EmbeddedImageInfo imageInfo in embeddedImages)
            //{

            //    // You can adjust the width and height to your preferred values
            //    int maxWidth = 200;
            //    int maxHeight = 150;

            //    //if (image.Width > maxWidth || image.Height > maxHeight)
            //    //{
            //    //    // Calculate the new size while maintaining aspect ratio
            //    //    int newWidth = Math.Min(image.Width, maxWidth);
            //    //    int newHeight = (int)((float)image.Height * newWidth / image.Width);

            //    //    // Resize the image
            //    //    richTextBox1.Select(image.Start, image.End - image.Start);
            //    //    Clipboard.SetImage(image.Image);
            //    //    richTextBox1.Paste();
            //    //}
            //}
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Select(richTextBox1.Text.Length, 0);
            bool ShiftPressed = ((Control.ModifierKeys & Keys.Shift) != 0);
            int Index = richTextBox1.SelectionStart - 1;

            MessageChar messageChar = new MessageChar();
            messageChar.Char = richTextBox1.Text[Index];
            //messageChar.Char = richTextBox1.Text[IndexToAdd]; //להחליף לבזמן לחיצה או אחרי אולי
            RichTextBoxContent.Insert(Index, messageChar);
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            bool ShiftPressed = ((Control.ModifierKeys & Keys.Shift) != 0);

            int IndexToAdd = richTextBox1.SelectionStart;
            if (e.KeyCode == Keys.Back) 
            {
                if ((IndexToAdd != 0) && (RichTextBoxContent[IndexToAdd - 1] != null)) //what if more than one char is deleted at the same time...
                {
                    if (RichTextBoxContent[IndexToAdd - 1] is MessageChar)
                    {
                        RichTextBoxContent.RemoveAt(IndexToAdd - 1);

                    }
                    else
                    {
                        //e.SuppressKeyPress = true; // Prevent the default behavior of the key
                        RichTextBoxContent.RemoveAt(IndexToAdd - 1);

                    }
                    // Customize the behavior of the backspace key here
                    //if (ImageLockMode = true)//if thats the image location
                    //{
                    //    e.SuppressKeyPress = true; // Prevent the default behavior of the key
                    //    //to delete the emoji
                    //}
                }

            }
            //else if (!char.IsControl((char)e.KeyCode))//todo find a solution to ctrl typing
            //{
            //    MessageChar messageChar = new MessageChar();
            //    char CurrentChar = (char)e.KeyCode;
            //    if (ShiftPressed)
            //    {
            //        // Convert the character to uppercase if Shift is pressed
            //        CurrentChar = (char)('!' + (e.KeyCode - Keys.D1));

            //    }
            //    messageChar.Char = CurrentChar;
            //    //messageChar.Char = richTextBox1.Text[IndexToAdd]; //להחליף לבזמן לחיצה או אחרי אולי
            //    RichTextBoxContent.Insert(IndexToAdd, messageChar);

            //}



        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //bool ShiftPressed = ((Control.ModifierKeys & Keys.Shift) != 0);
            //int IndexToAdd = richTextBox1.SelectionStart;
            //if (!char.IsControl(e.KeyChar))//todo find a solution to ctrl typing
            //{
            //    MessageChar messageChar = new MessageChar();
            //    char CurrentChar = e.KeyChar;
            //    if (ShiftPressed)
            //    {
            //        // Convert the character to uppercase if Shift is pressed
            //        CurrentChar = (char)('!' + (e.KeyChar - Keys.D1));

            //    }
            //    messageChar.Char = CurrentChar;
            //    //messageChar.Char = richTextBox1.Text[IndexToAdd]; //להחליף לבזמן לחיצה או אחרי אולי
            //    RichTextBoxContent.Insert(IndexToAdd, messageChar);

            //}
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //bool ShiftPressed = ((Control.ModifierKeys & Keys.Shift) != 0);
            //int IndexToAdd = richTextBox1.SelectionStart;
            //if (!char.IsControl((char)e.KeyCode))//todo find a solution to ctrl typing
            //{
            //    MessageChar messageChar = new MessageChar();
            //    char CurrentChar = (char)e.KeyCode;
            //    if (ShiftPressed)
            //    {
            //        // Convert the character to uppercase if Shift is pressed
            //        CurrentChar = (char)('!' + ((char)e.KeyCode - Keys.D1));

            //    }
            //    messageChar.Char = CurrentChar;
            //    //messageChar.Char = richTextBox1.Text[IndexToAdd]; //להחליף לבזמן לחיצה או אחרי אולי
            //    RichTextBoxContent.Insert(IndexToAdd-1, messageChar);

            //}
        }
        // Import the SetCursorPos function from User32.dll


        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = !flowLayoutPanel1.Visible;
            isButtonPressed = !isButtonPressed;
        }

        private bool isMouseOverButton = false;
        private bool isMouseOverPanel = false;
        private bool isButtonPressed = false;



        private void button2_MouseEnter(object sender, EventArgs e)
        {
            isMouseOverButton = true;
            //UpdatePanelVisibility();
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            isMouseOverButton = false;
            UpdatePanelVisibility();
        }

        private void flowLayoutPanel1_MouseEnter(object sender, EventArgs e)
        {
            //isMouseOverPanel = true;
            ////UpdatePanelVisibility();
        }

        private void flowLayoutPanel1_MouseLeave(object sender, EventArgs e)
        {
            //isMouseOverPanel = false;
            //UpdatePanelVisibility();
        }

        private void UpdatePanelVisibility()
        {
            if (isButtonPressed &&(isMouseOverButton || isMouseOverPanel))
                flowLayoutPanel1.Visible = true;
            else
                flowLayoutPanel1.Visible = false;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
