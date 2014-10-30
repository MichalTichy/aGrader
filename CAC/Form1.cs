using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CAC
{
    public partial class CaC : Form
    {
        public CaC()
        {
            InitializeComponent();
        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            if (SourceCodes.setpath())
                tbpath.Text = SourceCodes.getpath();
        }
    }
}
