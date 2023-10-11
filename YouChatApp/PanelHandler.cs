using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouChatApp
{
    internal class PanelHandler
    {
        public static void DeletePanelHorizontalScrollBar(Panel panel)
        {
            panel.AutoScroll = false;
            panel.HorizontalScroll.Visible = false;
            panel.HorizontalScroll.Maximum = 0;
            panel.AutoScroll = true;
        }
        public static void DeletePanelVerticalScrollBar(Panel panel)
        {
            panel.AutoScroll = false;
            panel.VerticalScroll.Visible = false;
            panel.VerticalScroll.Maximum = 0;
            panel.AutoScroll = true;
        }
        public static void DeletePanelScrollBars(Panel panel)
        {
            DeletePanelHorizontalScrollBar(panel);
            DeletePanelVerticalScrollBar(panel);
        }
        public static void SetPanelToSide<T>(Panel panel, List<T> controlList, bool ToFirst)
        {
            if (panel.Controls.Count > 0) // todo - add a check if the current chat has messages already - need to check the chat's MessageNumber var...
            {
                int index;
                if (ToFirst)
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
