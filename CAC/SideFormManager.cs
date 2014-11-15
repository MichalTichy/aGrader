using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAC
{
    public static class SideFormManager
    {
        private static dynamic SideForm=null;

        public static void Show(dynamic FormToShow)
        {
            Close();
            SideForm = FormToShow;
            UpdatePosition();
            SideForm.Show();
        }
        public static void UpdatePosition()
        {
            SideForm.SetDesktopLocation(Form.ActiveForm.Location.X + Form.ActiveForm.Size.Width, Form.ActiveForm.Location.Y);
        }

        public static void Close()
        {
            if(SideForm!=null)
            {
                SideForm.Close();
                SideForm = null;
            }
        }

    }
}
