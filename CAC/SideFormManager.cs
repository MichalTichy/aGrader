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
        private static string[] ValidDatatypes = {"InputFile","InputNumber","InputRandomNumber","InputString"};

        public static void Show(dynamic FormToShow)
        {
            Close();
            SideForm = FormToShow;
            UpdatePosition();
            SideForm.Show();
            
        }
        public static void UpdatePosition()
        {
            if(SideForm!=null)
            {
                SideForm.SetDesktopLocation(Form.ActiveForm.Location.X + Form.ActiveForm.Size.Width, Form.ActiveForm.Location.Y+65);
            }
        }
        public static bool IsValidDataType(Type DataType)
        {
            if (ValidDatatypes.Contains(DataType.Name))
                return true;
            return false;
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
