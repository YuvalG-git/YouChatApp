using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp
{
    /// <summary>
    /// The "PanelHandler" class provides methods for handling Panel controls, including managing scroll bars and setting the view.
    /// </summary>
    /// <remarks>
    /// This class includes methods for deleting horizontal and vertical scroll bars from a Panel control,
    /// as well as a method for setting the panel to show either the first or last control from a list of controls.
    /// </remarks>
    internal class PanelHandler
    {
        #region Public Static Methods

        /// <summary>
        /// The "DeletePanelHorizontalScrollBar" method deletes the horizontal scroll bar of a Panel control.
        /// </summary>
        /// <param name="panel">The Panel control from which to delete the horizontal scroll bar.</param>
        /// <remarks>
        /// This method disables the auto-scroll feature of the panel, hides the horizontal scroll bar, 
        /// sets the maximum scroll value to 0, and then re-enables the auto-scroll feature.
        /// As a result, the horizontal scroll bar is effectively removed from the panel.
        /// </remarks>
        public static void DeletePanelHorizontalScrollBar(Panel panel)
        {
            panel.AutoScroll = false;
            panel.HorizontalScroll.Visible = false;
            panel.HorizontalScroll.Maximum = 0;
            panel.AutoScroll = true;
        }

        /// <summary>
        /// The "DeletePanelVerticalScrollBar" method deletes the vertical scroll bar of a Panel control.
        /// </summary>
        /// <param name="panel">The Panel control from which to delete the vertical scroll bar.</param>
        /// <remarks>
        /// This method disables the auto-scroll feature of the panel, hides the vertical scroll bar, 
        /// sets the maximum scroll value to 0, and then re-enables the auto-scroll feature.
        /// As a result, the vertical scroll bar is effectively removed from the panel.
        /// </remarks>
        public static void DeletePanelVerticalScrollBar(Panel panel)
        {
            panel.AutoScroll = false;
            panel.VerticalScroll.Visible = false;
            panel.VerticalScroll.Maximum = 0;
            panel.AutoScroll = true;
        }

        /// <summary>
        /// The "DeletePanelScrollBars" method deletes both horizontal and vertical scroll bars of a Panel control.
        /// </summary>
        /// <param name="panel">The Panel control from which to delete the scroll bars.</param>
        /// <remarks>
        /// This method calls the "DeletePanelHorizontalScrollBar" and "DeletePanelVerticalScrollBar" methods
        /// to remove both the horizontal and vertical scroll bars from the panel.
        /// </remarks>
        public static void DeletePanelScrollBars(Panel panel)
        {
            DeletePanelHorizontalScrollBar(panel);
            DeletePanelVerticalScrollBar(panel);
        }

        /// <summary>
        /// The "SetPanelToSide" method sets the panel to show either the first or last control from a list of controls.
        /// </summary>
        /// <typeparam name="T">The type of the controls in the list.</typeparam>
        /// <param name="panel">The Panel control to set the view for.</param>
        /// <param name="controlList">The list of controls to choose from.</param>
        /// <param name="setToShowFirst">A boolean value indicating whether to show the first or last control.</param>
        /// <remarks>
        /// This method checks if the panel contains any controls. If it does, it determines the index of the control to show
        /// based on the setToShowFirst parameter. It then retrieves the control at the specified index from the controlList
        /// and scrolls the panel to show that control.
        /// </remarks>
        public static void SetPanelToSide<T>(Panel panel, List<T> controlList, bool setToShowFirst)
        {
            if (panel.Controls.Count > 0)
            {
                int index;
                if (setToShowFirst)
                {
                    index = 0;
                }
                else
                {
                    index = controlList.Count - 1;
                }
                Control LastControl = controlList[index] as Control;
                panel.ScrollControlIntoView(LastControl);
            }
        }

        #endregion
    }
}
