using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CAC.IO_Forms
{
    public partial class SettingsProhibitedCommand : CAC.IO_Forms.InputString
    {
        public SettingsProhibitedCommand()
        {
            InitializeComponent();
        }

        public SettingsProhibitedCommand(string command) : base (command)
        {
            
        }
    }
}
