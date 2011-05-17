using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace neprostopleer.Cores
{
    class CoreLogging
    {

        public void processException(Exception e)
        {
            addToLog(e.Message, true);
        }

        public void addToLog(Exception e)
        {
            addToLog(e.ToString(), true);
        }

        public void addToLog(String s)
        {
            addToLog(s, true);
        }

        public void addToLog(String s, bool showWindow)
        {
            if (Program.logWindow == null)
                Program.logWindow = new LogWindow();
            Program.logWindow.textBox1.Text += s + Environment.NewLine;
            if (showWindow)
            {
                Program.logWindow.Show();
            }
        }
    }
}
