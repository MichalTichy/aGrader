using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAC
{
    public partial class InputNumber : Form
    {
        public InputNumber()
        {
            InitializeComponent();            
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            SideFormManager.Close();
        }

        private void butAddOrChange_Click(object sender, EventArgs e)
        {
            IOMethods.IO.Add(this);
            SideFormManager.Close();
        }

        public override string ToString()
        {
            return "VSTUP: číslo " + numeric.Value;
        }
    }
}
