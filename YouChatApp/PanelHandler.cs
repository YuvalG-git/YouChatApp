using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp
{
    /// <summary>
    /// The class provides methods for handling Panel controls.
    /// </summary>
    internal class PanelHandler
    {
        /// <summary>
        /// The method deletes the horizontal scroll bar of a Panel control.
        /// </summary>
        /// <param name="panel">The Panel control.</param>
        public static void DeletePanelHorizontalScrollBar(Panel panel)
        {
            panel.AutoScroll = false;
            panel.HorizontalScroll.Visible = false;
            panel.HorizontalScroll.Maximum = 0;
            panel.AutoScroll = true;
        }

        /// <summary>
        /// The method deletes the vertical scroll bar of a Panel control.
        /// </summary>
        /// <param name="panel">The Panel control.</param>
        public static void DeletePanelVerticalScrollBar(Panel panel)
        {
            panel.AutoScroll = false;
            panel.VerticalScroll.Visible = false;
            panel.VerticalScroll.Maximum = 0;
            panel.AutoScroll = true;
        }

        /// <summary>
        /// The method deletes both horizontal and vertical scroll bars of a Panel control.
        /// </summary>
        /// <param name="panel">The Panel control.</param>
        public static void DeletePanelScrollBars(Panel panel)
        {
            DeletePanelHorizontalScrollBar(panel);
            DeletePanelVerticalScrollBar(panel);
        }

        /// <summary>
        /// The method sets the Panel control to show a specified side of a list of controls.
        /// </summary>
        /// <typeparam name="T">The type of controls in the list.</typeparam>
        /// <param name="panel">The Panel control.</param>
        /// <param name="controlList">The list of controls.</param>
        /// <param name="toFirst">True to show the first control, false to show the last control.</param>
        public static void SetPanelToSide<T>(Panel panel, List<T> controlList, bool setToShowFirst)
        {
            if (panel.Controls.Count > 0) // todo - add a check if the current chat has messages already - need to check the chat's MessageNumber var...
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
    }
}
