using AForge;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        Dictionary<PictureBox, Panel> ButtonToPanelConnectionMap = new Dictionary<PictureBox, Panel>();
        readonly int PictureBoxGap = 4;
        readonly int PictureBoxSize = 36;
        public event EventHandler<PictureBoxEventArgs> EmojiPress; // Event to notify Form2
        int ControlWidth;
        int ControlHeight; //maybe in the future to use size based on the form's size
        int EmojiCategories = 9;
        List<List<EmojiObject>> EmojiImagePathListOfLists = new List<List<EmojiObject>>();
        public bool _isText;
        private Panel lastVisiblePeopleEmojiPanel;
        public Image ImageToSend { get; set; }

        private void InitializeEmojiImagePathListOfLists()
        {
            ResourceSet ResourceSet = EmojiResourceSet.resourceSetArray[1]; //represnts people emoji
            bool WasHandled;
            EmojiObject EmojiToBeInserted;
            Image EmojiToBeInsertedImage;
            string EmojiToBeInsertedName;
            string EmojiToBeInsertedID = "";
            string EmojiToBeInsertedColorID = "";
            int counter = 0;
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
                        if ((ResourceNameCodeContent[0] == "1f9d1") || (ResourceNameCodeContent[0] == "1f468") || (ResourceNameCodeContent[0] == "1f469"))
                        {
                            if (ResourceNameLength == 1)
                            {
                                EmojiToBeInsertedID = ResourceNameCodeContent[0];
                                EmojiToBeInsertedColorID = "no color";

                            }
                            else if (ResourceNameLength == 2)
                            {
                                EmojiToBeInsertedID = ResourceNameCodeContent[0];
                                EmojiToBeInsertedColorID = ResourceNameCodeContent[1];
                            }
                            else if (ResourceNameLength == 3)
                            {
                                EmojiToBeInsertedID = ResourceNameCodeContent[0] + "#" + ResourceNameCodeContent[2];
                                EmojiToBeInsertedColorID = "no color";
                            }
                            else if (ResourceNameLength == 4)
                            {
                                if ((ResourceNameCodeContent[2] == "2695") || (ResourceNameCodeContent[2] == "2696") || (ResourceNameCodeContent[2] == "2708"))
                                {
                                    EmojiToBeInsertedID = ResourceNameCodeContent[0] + "#" + ResourceNameCodeContent[2];
                                    EmojiToBeInsertedColorID = "no color";
                                }
                                else
                                {
                                    EmojiToBeInsertedID = ResourceNameCodeContent[0] + "#" + ResourceNameCodeContent[3];
                                    EmojiToBeInsertedColorID = ResourceNameCodeContent[1];
                                }
                            }
                            else if (ResourceNameLength == 5)
                            {
                                if (ResourceNameCodeContent[2] == "1f91d")
                                {
                                    EmojiToBeInsertedID = ResourceNameCodeContent[0] + "#" + ResourceNameCodeContent[2];
                                    EmojiToBeInsertedColorID = "no color";
                                }
                                else
                                {
                                    EmojiToBeInsertedID = ResourceNameCodeContent[0] + "#" + ResourceNameCodeContent[3];
                                    EmojiToBeInsertedColorID = ResourceNameCodeContent[1];
                                }
                            }
                            else if (ResourceNameLength == 7)
                            {
                                EmojiToBeInsertedID = ResourceNameCodeContent[0] + "#" + ResourceNameCodeContent[3];
                                EmojiToBeInsertedColorID = ResourceNameCodeContent[1] + "#" + ResourceNameCodeContent[6];
                            }
                            else if (ResourceNameLength == 8)
                            {
                                EmojiToBeInsertedID = ResourceNameCodeContent[0] + "#" + ResourceNameCodeContent[3];
                                EmojiToBeInsertedColorID = ResourceNameCodeContent[1] + "#" + ResourceNameCodeContent[7];
                            }
                            else if (ResourceNameLength == 10)
                            {
                                EmojiToBeInsertedID = ResourceNameCodeContent[0] + "#" + ResourceNameCodeContent[3] + "#" + ResourceNameCodeContent[6];
                                EmojiToBeInsertedColorID = ResourceNameCodeContent[1] + "#" + ResourceNameCodeContent[9];
                            }
                        }
                        else
                        {
                            if (ResourceNameLength == 1)
                            {
                                EmojiToBeInsertedID = ResourceNameCodeContent[0];
                                EmojiToBeInsertedColorID = "no color";

                            }
                            else if (ResourceNameLength == 2)
                            {
                                EmojiToBeInsertedID = ResourceNameCodeContent[0];
                                EmojiToBeInsertedColorID = ResourceNameCodeContent[1];
                            }
                            else if (ResourceNameLength == 4)
                            {
                                EmojiToBeInsertedID = ResourceNameCodeContent[0] + "#" + ResourceNameCodeContent[2];
                                EmojiToBeInsertedColorID = "no color";
                            }
                            else if (ResourceNameLength == 5)
                            {
                                EmojiToBeInsertedID = ResourceNameCodeContent[0] + "#" + ResourceNameCodeContent[3];
                                EmojiToBeInsertedColorID = ResourceNameCodeContent[1];
                            }
                        }
                        foreach (List<EmojiObject> EmojiPack in EmojiImagePathListOfLists)
                        {
                            EmojiObject Emoji = EmojiPack[0];
                            if (Emoji.EmojiID == EmojiToBeInsertedID)
                            {
                                EmojiToBeInserted = new EmojiObject(EmojiToBeInsertedImage, EmojiToBeInsertedName, EmojiToBeInsertedID, EmojiToBeInsertedColorID, ResourceNameLength);
                                InsertToListByABC(EmojiPack, EmojiToBeInsertedColorID, EmojiToBeInserted);
                                WasHandled = true;
                            }
                        
                        }
                        if (!WasHandled)
                        {
                            EmojiToBeInserted = new EmojiObject(EmojiToBeInsertedImage, EmojiToBeInsertedName, EmojiToBeInsertedID, ResourceNameLength);
                            List<EmojiObject> NewEmojiListToBeInserted = new List<EmojiObject> { EmojiToBeInserted };
                            EmojiImagePathListOfLists.Add(NewEmojiListToBeInserted);
                        }
                    }

                }
                
            }
            SetPeopleEmojiTab();
        }
        //1- regular emoji
        //2 - colored regular emoji
        //4 - special amoji
        //5 - colored special emoji
        // the second one is the one i should be comparing
        private void closePeopleEmojiPanel()
        {
            if (lastVisiblePeopleEmojiPanel != null)
            {
                lastVisiblePeopleEmojiPanel.Visible = false;
                lastVisiblePeopleEmojiPanel = null;
            }
        }
        private void SetPeopleEmojiTab()
        {
            PeopleEmojiPictureBoxListOfLists = new List<List<PictureBox>>();
            int EmojiPictureBoxCount = 0;
            int PanelCount = 0;
            int PeopleEmojiPictureBoxCount = 0;
            int x = 0;
            int y = 0;
            int xForPeopleEmoji = 0;
            int yForPeopleEmoji = 0;
            int PeopleEmojiLayers = 1;
            int maxXValue = EmojiCategoryTabPage[1].Size.Width - (2 * PictureBoxSize + PictureBoxGap) - 10;
            int maxXValueForPeopleEmoji = 100;
            int PeopleEmojiPanelXLocation;
            int PeopleEmojiPanelYLocation;
            foreach (List<EmojiObject> EmojiPack in EmojiImagePathListOfLists)
            {
                EmojiObject Emoji = EmojiPack[0];
                this.EmojiPictureBoxArrayOfLists[1].Add(new PictureBox());
                EmojiPictureBoxArrayOfLists[1][EmojiPictureBoxCount].Name = Emoji.EmojiName;
                EmojiPictureBoxArrayOfLists[1][EmojiPictureBoxCount].Image = Emoji.EmojiImage;
                EmojiPictureBoxArrayOfLists[1][EmojiPictureBoxCount].Location = new System.Drawing.Point(x, y);
                EmojiPictureBoxArrayOfLists[1][EmojiPictureBoxCount].Size = new Size(PictureBoxSize, PictureBoxSize);
                EmojiPictureBoxArrayOfLists[1][EmojiPictureBoxCount].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                EmojiPictureBoxArrayOfLists[1][EmojiPictureBoxCount].Padding = new System.Windows.Forms.Padding(2);
                EmojiPictureBoxArrayOfLists[1][EmojiPictureBoxCount].MouseEnter += new System.EventHandler(EmojiPictureBox_MouseEnter);
                EmojiPictureBoxArrayOfLists[1][EmojiPictureBoxCount].MouseLeave += new System.EventHandler(EmojiPictureBox_MouseLeave);
                this.Controls.Add(this.EmojiPictureBoxArrayOfLists[1][EmojiPictureBoxCount]);
                this.EmojiCategoryTabPage[1].Controls.Add(this.EmojiPictureBoxArrayOfLists[1][EmojiPictureBoxCount]);
                this.EmojiCategoryPanel[1].Controls.Add(this.EmojiPictureBoxArrayOfLists[1][EmojiPictureBoxCount]);
                if (EmojiPack.Count > 1)
                {
                    EmojiPictureBoxArrayOfLists[1][EmojiPictureBoxCount].Click += new System.EventHandler(SpecialEmojiPictureBox_Click);
                    this.PeopleEmojiPanelList.Add(new Panel());

                    if (EmojiPack.Count == 6)
                    {
                        maxXValueForPeopleEmoji = PictureBoxSize * 6 + PictureBoxGap * 5;
                        PeopleEmojiLayers = 1;
                    }
                    else //if (EmojiPack.Count % 5 == 0)
                    {
                        maxXValueForPeopleEmoji = PictureBoxSize * 5 + PictureBoxGap * 4;
                        PeopleEmojiLayers = EmojiPack.Count / 5;
                    }

                    PeopleEmojiPanelList[PanelCount].Name = "Panel" + Emoji.EmojiName;

                    PeopleEmojiPanelList[PanelCount].Size = new Size(maxXValueForPeopleEmoji, PictureBoxSize * PeopleEmojiLayers + PictureBoxGap * (PeopleEmojiLayers -1));
                    PeopleEmojiPanelList[PanelCount].Visible = false;
                    PeopleEmojiPanelList[PanelCount].BorderStyle = BorderStyle.FixedSingle;

                    this.Controls.Add(this.PeopleEmojiPanelList[PanelCount]);
                    ButtonToPanelConnectionMap.Add(EmojiPictureBoxArrayOfLists[1][EmojiPictureBoxCount], PeopleEmojiPanelList[PanelCount]);

                    PeopleEmojiPictureBoxListOfLists.Add(new List<PictureBox>());
                    PeopleEmojiPictureBoxCount = 0;
                    foreach (EmojiObject emojiObject in EmojiPack)
                    {
                        this.PeopleEmojiPictureBoxListOfLists[PanelCount].Add(new PictureBox());
                        PeopleEmojiPictureBoxListOfLists[PanelCount][PeopleEmojiPictureBoxCount].Name = emojiObject.EmojiName;
                        PeopleEmojiPictureBoxListOfLists[PanelCount][PeopleEmojiPictureBoxCount].Image = emojiObject.EmojiImage;
                        PeopleEmojiPictureBoxListOfLists[PanelCount][PeopleEmojiPictureBoxCount].Size = new Size(PictureBoxSize, PictureBoxSize);
                        PeopleEmojiPictureBoxListOfLists[PanelCount][PeopleEmojiPictureBoxCount].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        PeopleEmojiPictureBoxListOfLists[PanelCount][PeopleEmojiPictureBoxCount].Padding = new System.Windows.Forms.Padding(2);
                        PeopleEmojiPictureBoxListOfLists[PanelCount][PeopleEmojiPictureBoxCount].Click += new System.EventHandler(EmojiPictureBox_Click);
                        this.Controls.Add(this.PeopleEmojiPictureBoxListOfLists[PanelCount][PeopleEmojiPictureBoxCount]);
                        this.PeopleEmojiPanelList[PanelCount].Controls.Add(PeopleEmojiPictureBoxListOfLists[PanelCount][PeopleEmojiPictureBoxCount]);

                        if (xForPeopleEmoji < maxXValueForPeopleEmoji)
                            xForPeopleEmoji += PictureBoxSize + PictureBoxGap;
                        else
                        {
                            yForPeopleEmoji += PictureBoxSize + PictureBoxGap;
                            xForPeopleEmoji = PictureBoxGap;
                        }
                        PeopleEmojiPictureBoxCount++;

                    }
                    PanelCount++;

                }
                else
                {
                    EmojiPictureBoxArrayOfLists[1][EmojiPictureBoxCount].Click += new System.EventHandler(EmojiPictureBox_Click);

                }

                if (x < maxXValue)
                    x += PictureBoxSize + PictureBoxGap;
                else
                {
                    y += PictureBoxSize + PictureBoxGap;
                    x = 0;
                }
                EmojiPictureBoxCount++;
            }
        }
        private bool IsMouseOverButtonOrPanel(Button button, Panel panel)
        {
            return button.ClientRectangle.Contains(button.PointToClient(MousePosition)) ||
                   panel.ClientRectangle.Contains(panel.PointToClient(MousePosition));
        }

        private void InsertToListByABC(List<EmojiObject> EmojiPack, string SpecialId, EmojiObject EmojiToBeInserted)
        {
            if (SpecialId == "no color")
            {
                EmojiPack.Insert(0, EmojiToBeInserted); //insert as first
            }
            else
            {
                Boolean WasInserted = false;
                int index = 0;
                for (int i = 0; (i < EmojiPack.Count) && (!WasInserted); i++)
                {
                    if (EmojiPack[i].EmojiColorID != "no color")
                    {
                        if (IsFirstStringFirstInABC(SpecialId, EmojiPack[i].EmojiColorID))
                        {
                            index = i;
                            WasInserted = true;
                        }
                    }
                }
                if (ContainKeyWord(EmojiPack))
                {
                    index++;
                }
                EmojiPack.Insert(index, EmojiToBeInserted);
            }
        }
        private bool ContainKeyWord(List<EmojiObject> EmojiPack)
        {
            for (int i = 0; (i < EmojiPack.Count); i++)
            {
                if (EmojiPack[i].EmojiColorID == "no color")
                {
                    return true;
                }
            }
            return false;
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
                this.EmojiCategoryPanel[i].Location = new System.Drawing.Point(3, 40);
                this.EmojiCategoryPanel[i].Size = new System.Drawing.Size(ControlWidth - 4, ControlHeight - 40);
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
            this.EmojiCategoryPanel[1].Scroll += EmojiPeoplePanel_Scroll;
            this.EmojiCategoryPanel[1].MouseWheel += EmojiPeoplePanel_MouseWheel;

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
                this.EmojiCategoryTabPage[i].BackColor = Color.LightBlue;
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
        public EmojiKeyboard()
        {
            InitializeComponent();
            this.TopMost = true;
            ControlWidth = EmojiTabControl.Width;
            ControlHeight = EmojiTabControl.Height; //maybe in the future to use size based on the form's size
            PeopleEmojiPanelList = new List<Panel>();
            EmojiResourceSet.InitializeResourceSetArray(); //probably need this - to ask somebody...
            InitializeEmojiPanelArray();
            //string emojiPath = @"C:\Users\יובל\source\repos\YouChatApp\YouChatApp\EmojiIcons\Smileys\1f600.png"; // This is an example path, make sure to adjust it based on the actual emoji you want to use.
            //button2.BackgroundImage = Image.FromFile(emojiPath);
            //string l = "\u128309";
            //TabImageList.Images.Add["\u128309"];
            //TabPage1.ImageIndex = 3;
            InitializeEmojiTabPageArray();
            InitializeEmojiPictureBoxList();
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




      
        public void SendEmoji(PictureBox pictureBox)
        {
            ImageToSend = pictureBox.Image;
            //needs to close if it was for group image otherwise not..
            this.DialogResult = DialogResult.OK;

            this.Close();
        }
        private void EmojiPeoplePanel_Scroll(object sender, ScrollEventArgs e)
        {
            closePeopleEmojiPanel();
        }
        private void EmojiPeoplePanel_MouseWheel(object sender, MouseEventArgs e)
        {
            closePeopleEmojiPanel();
        }
        private void SpecialEmojiPictureBox_Click(object sender, EventArgs e)
        {
            //foreach (Panel panel1 in PeopleEmojiPanelList)
            //{
            //    panel1.Visible = false;
            //}
            if (lastVisiblePeopleEmojiPanel != null)
            {
                lastVisiblePeopleEmojiPanel.Visible = false;

            }
            PictureBox pictureBox = sender as PictureBox;
            Panel panel = ButtonToPanelConnectionMap[pictureBox];
            lastVisiblePeopleEmojiPanel = panel;
            System.Drawing.Point pictureBoxRealLocation = pictureBox.Location;
            if (pictureBox.Parent != null && pictureBox.Parent is Panel) //panel location
            {
                System.Drawing.Point panelLocation = pictureBox.Parent.Location;
                pictureBoxRealLocation.Offset(panelLocation.X, panelLocation.Y);
            }
            if (pictureBox.Parent.Parent != null && pictureBox.Parent.Parent is TabPage) //tabpage location
            {
                System.Drawing.Point tabPageLocation = pictureBox.Parent.Parent.Location; 
                pictureBoxRealLocation.Offset(tabPageLocation.X, tabPageLocation.Y);
            }
            int pictureBoxRealXLocation = pictureBoxRealLocation.X;
            int pictureBoxRealYLocation = pictureBoxRealLocation.Y;
            panel.Location = new System.Drawing.Point(pictureBoxRealXLocation + ((PictureBoxSize + PictureBoxGap-  panel.Width) / 2), pictureBoxRealYLocation - panel.Height);
            if (!EmojiCategoryPanel[1].ClientRectangle.Contains(panel.Bounds))
            {
                // The second panel is partially or completely outside the first panel
                // Find the closest first panel border and move the second panel there

                int newX = panel.Left;
                int newY = panel.Top;

                // Check the left border
                if (panel.Left < EmojiCategoryPanel[1].Left)
                {
                    newX = EmojiCategoryPanel[1].Left;
                }

                // Check the top border
                if (panel.Top < EmojiCategoryPanel[1].Top)
                {
                    newY = EmojiCategoryPanel[1].Top;
                }

                // Check the right border
                if (panel.Right > EmojiCategoryPanel[1].Right)
                {
                    newX = EmojiCategoryPanel[1].Right - panel.Width;
                }

                // Check the bottom border
                if (panel.Bottom > EmojiCategoryPanel[1].Bottom)
                {
                    newY = EmojiCategoryPanel[1].Bottom - panel.Height;
                }

                // Move the second panel to the new position
                panel.Location = new System.Drawing.Point(newX, newY);
            }
            panel.Visible = true;
            int x = 0;
            int y = 0;
            foreach (Control control in panel.Controls)
            {
                if (control is PictureBox)
                {
                    control.Location = new System.Drawing.Point(x, y);

                }
                if (x < panel.Width - PictureBoxGap - PictureBoxSize)
                    x += PictureBoxSize + PictureBoxGap;
                else
                {
                    y += PictureBoxSize + PictureBoxGap;
                    x = 0;
                }
            }    
            panel.BringToFront();
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
            if (_isText)
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
           


            //if (TabNumber == //anything but people do the code above else call the function that does something)
            int count = 0;
            int x = 0;
            int y = 0;

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
                        EmojiPictureBoxArrayOfLists[TabNumber][count].Location = new System.Drawing.Point(x, y);
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
        private void HandleBackgroundColor(PictureBox pictureBox, bool isOnMouseEnter)
        {
            if (isOnMouseEnter)
            {
                pictureBox.BackColor = System.Drawing.Color.LightGray;
            }
            else
            {
                pictureBox.BackColor = Color.Transparent;

            }
        }
        private void EmojiPictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            HandleBackgroundColor(pictureBox, true);
        }
        private void EmojiPictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            HandleBackgroundColor(pictureBox, false);
        }
    }
}
