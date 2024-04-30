using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp.Controls
{
    /// <summary>
    /// The "SearchBar" class represents a user control for performing searches.
    /// </summary>
    /// <remarks>
    /// This class provides functionality for handling search actions and related UI interactions.
    /// </remarks>
    public partial class SearchBar : UserControl
    {
        #region Public Event Handlers

        /// <summary>
        /// The EventHandler "Search" event is raised when a search action is triggered.
        /// </summary>
        public event EventHandler Search;

        #endregion

        #region Constructors

        /// <summary>
        /// The "SearchBar" constructor initializes a new instance of the <see cref="SearchBar"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is used to create a new instance of the SearchBar class, initializing its components and setting the placeholder text for the search bar input field.
        /// </remarks>
        public SearchBar()
        {
            InitializeComponent();
            SearchBarCustomTextBox.PlaceHolderText = "Search...";
        }

        #endregion

        #region Control Properties

        /// <summary>
        /// The "SearchBar" property represents the custom text box used for searching.
        /// It gets the custom text box for the search bar.
        /// </summary>
        /// <value>
        /// The custom search bar text box.
        /// </value>
        public CustomTextBox SeacrhBar
        {
            get
            {
                return SearchBarCustomTextBox;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// The "BorderColor" property represents the color of the border for the SearchBarCustomTextBox control.
        /// It gets the color of the border or sets it to a new value.
        /// </summary>
        /// <value>
        /// The color of the border.
        /// </value>
        /// <remarks>
        /// Setting the BorderColor property will also invalidate the control, triggering a redraw
        /// to reflect the new border color.
        /// </remarks>
        [Category("YouChat")]
        public Color BorderColor
        {
            get
            {
                return SearchBarCustomTextBox.BorderColor;
            }
            set
            {
                SearchBarCustomTextBox.BorderColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// The "BorderFocusColor" property represents the color of the border when the control has focus.
        /// It gets the color of the focus border or sets it to a new value.
        /// </summary>
        /// <value>
        /// The color of the focus border.
        /// </value>
        [Category("YouChat")]
        public Color BorderFocusColor
        {
            get
            {
                return SearchBarCustomTextBox.BorderFocusColor;
            }
            set
            {
                SearchBarCustomTextBox.BorderFocusColor = value;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Adds an event handler to the Search event.
        /// </summary>
        /// <param name="handler">The event handler to add.</param>
        /// <remarks>
        /// This method allows external code to subscribe to the Search event by providing an event handler.
        /// </remarks>
        public void AddSearchOnClickHandler(EventHandler handler)
        {
            Search += handler;
        }

        /// <summary>
        /// The "OnSearch" method invokes the Search event.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void OnSearch(object sender, EventArgs e)
        {
            Search?.Invoke(this, e);
        }

        #endregion
    }
}
