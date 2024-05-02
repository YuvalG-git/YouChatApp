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
    /// <summary>
    /// The "EmojiKeyboard" class represents a form that provides an emoji keyboard for selecting and sending emojis.
    /// </summary>
    /// <remarks>
    /// This class manages the UI components for displaying emoji options to the user, including mapping picture boxes to panels,
    /// initializing emoji lists, and handling the selection and sending of emojis.
    /// </remarks>
    public partial class EmojiKeyboard : Form
    {
        #region Private Fields

        /// <summary>
        /// The Dictionary<PictureBox, Panel> "ButtonToPanelConnectionMap" represents the mapping between picture boxes and panels.
        /// </summary>
        private Dictionary<PictureBox, Panel> ButtonToPanelConnectionMap = new Dictionary<PictureBox, Panel>();

        /// <summary>
        /// The int "ControlWidth" represents the width of the control.
        /// </summary>
        private int ControlWidth;

        /// <summary>
        /// The int "ControlHeight" represents the height of the control.
        /// </summary>
        private int ControlHeight;

        /// <summary>
        /// The List<List<EmojiObject>> "EmojiImagePathListOfLists" represents the list of lists containing emoji objects.
        /// </summary>
        private List<List<EmojiObject>> EmojiImagePathListOfLists = new List<List<EmojiObject>>();

        /// <summary>
        /// The Panel "lastVisiblePeopleEmojiPanel" represents the last visible panel for people emojis.
        /// </summary>
        private Panel lastVisiblePeopleEmojiPanel;

        /// <summary>
        /// The Image "imageToSend" represents the image to send.
        /// </summary>
        private Image imageToSend;

        #endregion

        #region Private Readonly Fields

        /// <summary>
        /// The readonly int "PictureBoxGap" represents the gap between picture boxes.
        /// </summary>
        private readonly int PictureBoxGap = 4;

        /// <summary>
        /// The readonly int "PictureBoxSize" represents the size of the picture boxes.
        /// </summary>
        private readonly int PictureBoxSize = 36;

        #endregion

        #region Private Const Fields

        /// <summary>
        /// The constant int "EmojiCategories" represents the number of emoji categories.
        /// </summary>
        private const int EmojiCategories = 9;

        #endregion

        #region Constructors

        /// <summary>
        /// The "EmojiKeyboard" constructor initializes a new instance of the <see cref="EmojiKeyboard"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor sets up various components for the EmojiKeyboard, including initializing the form,
        /// setting it as topmost, and initializing lists and arrays for managing emoji panels and resources.
        /// </remarks>
        public EmojiKeyboard()
        {
            InitializeComponent();
            this.TopMost = true;
            ControlWidth = EmojiTabControl.Width;
            ControlHeight = EmojiTabControl.Height;
            PeopleEmojiPanelList = new List<Panel>();
            EmojiResourceSet.InitializeResourceSetArray();
            InitializeEmojiPanelArray();
            InitializeEmojiTabPageArray();
            InitializeEmojiPictureBoxList();
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "ImageToSend" property represents the image to be sent.
        /// It gets or sets the image to be sent.
        /// </summary>
        /// <value>
        /// The image to be sent.
        /// </value>
        public Image ImageToSend
        {
            get
            {
                return imageToSend;
            }
            set
            {
                imageToSend = value;
            }
        }

        #endregion

        #region Private Initializition Methods

        /// <summary>
        /// The "InitializeEmojiPictureBoxList" method initializes the list of emoji picture boxes for different categories.
        /// </summary>
        /// <remarks>
        /// It creates a list for each emoji category and initializes them accordingly. If the category is not 1, it calls the "SetTab" method to set up the tab.
        /// For category 1, it calls the "InitializeEmojiImagePathListOfLists" method to populate the list with emoji images and their corresponding details.
        /// This method is essential for setting up the UI to display emoji options to the user, enabling them to select and use emojis in their messages.
        /// </remarks>
        public void InitializeEmojiPictureBoxList()
        {
            EmojiPictureBoxArrayOfLists = new List<PictureBox>[EmojiCategories];
            for (int i = 0; i < EmojiCategories; i++)
            {
                EmojiPictureBoxArrayOfLists[i] = new List<System.Windows.Forms.PictureBox>();
                if (i != 1)
                {
                    SetTab(i);
                }
                else
                {
                    InitializeEmojiImagePathListOfLists();
                }
            }
        }

        /// <summary>
        /// The "InitializeEmojiPanelArray" method initializes the array of panels for each emoji category.
        /// </summary>
        /// <remarks>
        /// It creates a panel for each emoji category and sets up the panel properties such as auto-scrolling, location, size, and tab index.
        /// The method also assigns a unique name to each panel based on the category it represents.
        /// Additionally, it adds event handlers for scrolling and mouse wheel actions for the PeopleEmojiPanel.
        /// This method is crucial for setting up the UI to display emoji options to the user, organizing them into different categories for easy selection.
        /// </remarks>
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

        /// <summary>
        /// The "InitializeEmojiTabPageArray" method initializes the array of tab pages for each emoji category.
        /// </summary>
        /// <remarks>
        /// It creates a tab page for each emoji category and sets up the tab page properties such as image index, location, padding, size, tab index, and back color.
        /// The method also adds the corresponding panel for each category to its tab page and adds the tab page to the EmojiTabControl.
        /// Additionally, it assigns a unique name to each tab page based on the category it represents.
        /// This method is crucial for organizing the emoji categories into tab pages for display and easy navigation.
        /// </remarks>
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

        /// <summary>
        /// The "InitializeEmojiImagePathListOfLists" method initializes the list of lists containing Emoji packs based on the People Emoji resource set.
        /// </summary>
        /// <remarks>
        /// This method sets up the list of lists containing Emoji packs by iterating through the People Emoji resource set.
        /// For each Emoji in the resource set, it extracts the Emoji's name, ID, color ID, and length of the resource name code.
        /// It then checks if the Emoji's ID matches an existing Emoji in the list of lists.
        /// If a match is found, the method inserts the Emoji into the existing pack in alphabetical order by color ID.
        /// If no match is found, a new Emoji pack is created with the Emoji and added to the list of lists.
        /// </remarks>
        private void InitializeEmojiImagePathListOfLists()
        {
            ResourceSet ResourceSet = EmojiResourceSet.ResourceSetArray[1]; //represnts people emoji
            bool WasHandled;
            EmojiObject EmojiToBeInserted;
            Image EmojiToBeInsertedImage;
            string EmojiToBeInsertedName;
            string EmojiToBeInsertedID = "";
            string EmojiToBeInsertedColorID = "";
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

        /// <summary>
        /// The "SetTab" method initializes and sets the content of a specific tab based on the provided tab number.
        /// </summary>
        /// <param name="TabNumber">The tab number to set.</param>
        /// <remarks>
        /// This method iterates through the resources of the specified tab and adds PictureBoxes for each resource.
        /// It sets the PictureBox properties such as name, image, location, size, and event handlers for click, mouse enter, and mouse leave.
        /// </remarks>
        private void SetTab(int TabNumber)
        {
            int count = 0;
            int x = 0;
            int y = 0;

            int maxXValue = EmojiCategoryTabPage[TabNumber].Size.Width - (2 * PictureBoxSize + PictureBoxGap);
            ResourceSet ResourceSet = EmojiResourceSet.ResourceSetArray[TabNumber];

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

        /// <summary>
        /// The "SetPeopleEmojiTab" method initializes the People Emoji tab.
        /// </summary>
        /// <remarks>
        /// It creates a list to store lists of PictureBoxes for People Emoji.
        /// The method iterates through each Emoji pack in the Emoji image path list of lists.
        /// For each Emoji pack, it adds the first Emoji to the Emoji picture box array of lists.
        /// It sets up properties such as name, image, location, size, and event handlers for the PictureBox.
        /// The method also adds the PictureBox to the controls of the form, the People Emoji tab page, and the People Emoji panel.
        /// If the Emoji pack contains more than one Emoji, it sets up a panel for the pack and adds it to the form's controls.
        /// It calculates the maximum X value for People Emoji and the number of layers for People Emoji based on the pack's count.
        /// For each Emoji in the pack, it adds a PictureBox to the list of People Emoji PictureBoxes.
        /// It sets up properties such as name, image, size, and event handlers for each People Emoji PictureBox.
        /// The method adds each People Emoji PictureBox to the form's controls and the People Emoji panel's controls.
        /// It handles the positioning of People Emoji PictureBoxes within the panel.
        /// Finally, the method increments the panel count and updates the X and Y values for positioning.
        /// This method is essential for setting up the People Emoji tab with all its Emoji packs and their corresponding PictureBoxes.
        /// </remarks>
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
                    else
                    {
                        maxXValueForPeopleEmoji = PictureBoxSize * 5 + PictureBoxGap * 4;
                        PeopleEmojiLayers = EmojiPack.Count / 5;
                    }
                    PeopleEmojiPanelList[PanelCount].Name = "Panel" + Emoji.EmojiName;
                    PeopleEmojiPanelList[PanelCount].Size = new Size(maxXValueForPeopleEmoji, PictureBoxSize * PeopleEmojiLayers + PictureBoxGap * (PeopleEmojiLayers - 1));
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

        #endregion

        #region Private People Emoji Methods

        /// <summary>
        /// The "ClosePeopleEmojiPanel" method hides the last visible people emoji panel.
        /// </summary>
        /// <remarks>
        /// This method checks if the last visible people emoji panel is not null, then sets its visibility to false and sets the lastVisiblePeopleEmojiPanel to null.
        /// </remarks>
        private void ClosePeopleEmojiPanel()
        {
            if (lastVisiblePeopleEmojiPanel != null)
            {
                lastVisiblePeopleEmojiPanel.Visible = false;
                lastVisiblePeopleEmojiPanel = null;
            }
        }

        /// <summary>
        /// The "InsertToListByABC" method inserts the given EmojiObject into the EmojiPack list based on the ABC order of EmojiColorID.
        /// </summary>
        /// <param name="EmojiPack">The list of EmojiObjects to insert into.</param>
        /// <param name="SpecialId">The special ID of the EmojiObject to be inserted.</param>
        /// <param name="EmojiToBeInserted">The EmojiObject to insert into the list.</param>
        /// <remarks>
        /// This method inserts the EmojiToBeInserted into the EmojiPack list based on the ABC order of EmojiColorID.
        /// If SpecialId is "no color", it inserts EmojiToBeInserted at the beginning of the list.
        /// Otherwise, it finds the correct position in the list based on the ABC order of EmojiColorID and inserts EmojiToBeInserted there.
        /// </remarks>
        private void InsertToListByABC(List<EmojiObject> EmojiPack, string SpecialId, EmojiObject EmojiToBeInserted)
        {
            if (SpecialId == "no color")
            {
                EmojiPack.Insert(0, EmojiToBeInserted); //insert as first
            }
            else
            {
                bool WasInserted = false;
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

        /// <summary>
        /// The "ContainKeyWord" method checks if the given EmojiPack list contains an EmojiObject with "no color" as the EmojiColorID.
        /// </summary>
        /// <param name="EmojiPack">The list of EmojiObjects to check.</param>
        /// <returns>True if the list contains an EmojiObject with "no color" as the EmojiColorID, otherwise false.</returns>
        /// <remarks>
        /// This method iterates through the EmojiPack list and checks if any EmojiObject has "no color" as the EmojiColorID.
        /// If such an EmojiObject is found, the method returns true; otherwise, it returns false.
        /// </remarks>
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

        /// <summary>
        /// The "IsFirstStringFirstInABC" method checks if the first string comes first in alphabetical order (case-insensitive) compared to the second string.
        /// </summary>
        /// <param name="string1">The first string to compare.</param>
        /// <param name="string2">The second string to compare.</param>
        /// <returns>True if <paramref name="string1"/> comes before <paramref name="string2"/> in alphabetical order, otherwise false.</returns>
        /// <remarks>
        /// This method compares the two strings using a case-insensitive comparison.
        /// If <paramref name="string1"/> comes before <paramref name="string2"/> in alphabetical order, the method returns true; otherwise, it returns false.
        /// </remarks>
        private bool IsFirstStringFirstInABC(string String1, string String2)
        {
            int comparisonResult = string.Compare(String1, String2, StringComparison.OrdinalIgnoreCase);
            return comparisonResult < 0;
        }

        /// <summary>
        /// The "EmojiPeoplePanel_Scroll" method handles the scrolling event of the People emoji panel.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">A ScrollEventArgs that contains the event data.</param>
        /// <remarks>
        /// This method calls the ClosePeopleEmojiPanel method to close any open emoji panels when scrolling occurs.
        /// </remarks>
        private void EmojiPeoplePanel_Scroll(object sender, ScrollEventArgs e)
        {
            ClosePeopleEmojiPanel();
        }

        /// <summary>
        /// The "EmojiPeoplePanel_MouseWheel" method handles the mouse wheel event of the People emoji panel.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">A MouseEventArgs that contains the event data.</param>
        /// <remarks>
        /// This method calls the ClosePeopleEmojiPanel method to close any open emoji panels when the mouse wheel is scrolled.
        /// </remarks>
        private void EmojiPeoplePanel_MouseWheel(object sender, MouseEventArgs e)
        {
            ClosePeopleEmojiPanel();
        }

        /// <summary>
        /// The "SpecialEmojiPictureBox_Click" method handles the click event of special emoji PictureBoxes.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method closes any previously visible people emoji panel.
        /// It then determines the location of the clicked PictureBox relative to the form, considering its parent panels and tab pages.
        /// The method calculates the new location for the people emoji panel based on the clicked PictureBox's location.
        /// If the people emoji panel is partially or completely outside the visible area of the parent panel, the method adjusts its position to ensure visibility.
        /// Finally, the method sets the people emoji panel's visibility to true, positions its child PictureBox controls, and brings the panel to the front.
        /// </remarks>
        private void SpecialEmojiPictureBox_Click(object sender, EventArgs e)
        {
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

        #endregion

        #region Private Methods 

        /// <summary>
        /// The "EmojiPictureBox_Click" method handles the click event of emoji PictureBoxes.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        /// <remarks>
        /// This method retrieves the clicked PictureBox from the sender object and passes it to the "SendEmoji" method.
        /// </remarks>
        private void EmojiPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            SendEmoji(pictureBox);
        }

        /// <summary>
        /// The "EmojiPictureBox_MouseEnter" method handles the mouse enter event for a PictureBox, changing its background color to LightGray.
        /// </summary>
        /// <param name="sender">The PictureBox that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the mouse enters the PictureBox. It sets the PictureBox's background color to LightGray.
        /// </remarks>
        private void EmojiPictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            HandleBackgroundColor(pictureBox, true);
        }

        /// <summary>
        /// The "EmojiPictureBox_MouseLeave" method handles the mouse leave event for a PictureBox, changing its background color back to transparent.
        /// </summary>
        /// <param name="sender">The PictureBox that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <remarks>
        /// This method is called when the mouse leaves the PictureBox. It sets the PictureBox's background color back to transparent.
        /// </remarks>
        private void EmojiPictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            HandleBackgroundColor(pictureBox, false);
        }

        /// <summary>
        /// The "HandleBackgroundColor" method changes the background color of the specified PictureBox based on the mouse state.
        /// </summary>
        /// <param name="pictureBox">The PictureBox to modify.</param>
        /// <param name="isOnMouseEnter">A boolean indicating whether the mouse is currently over the PictureBox.</param>
        /// <remarks>
        /// If <paramref name="isOnMouseEnter"/> is true, the PictureBox's background color is set to LightGray.
        /// If <paramref name="isOnMouseEnter"/> is false, the PictureBox's background color is set to Transparent.
        /// </remarks>
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

        #endregion

        #region Public Methods

        /// <summary>
        /// The "SendEmoji" method prepares the selected emoji for sending.
        /// </summary>
        /// <param name="pictureBox">The PictureBox containing the selected emoji.</param>
        /// <remarks>
        /// This method sets the imageToSend property to the image of the selected PictureBox and closes the form with a DialogResult.OK result.
        /// </remarks>
        public void SendEmoji(PictureBox pictureBox)
        {
            imageToSend = pictureBox.Image;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion
    }
}
