﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CAC
{
    public static class SideFormManager
    {
        private static dynamic SideForm = null;
        public static void Show(SideForms FormName)
        {
            Close();
            SideForm = Activator.CreateInstance(Type.GetType("CAC." + FormName.ToString()));

            UpdatePosition();
            SideForm.Show();

        }
        public static void UpdatePosition()
        {
            if (SideForm != null)
            {

                //HACK
                try
                {
                    SideForm.SetDesktopLocation(Form.ActiveForm.Location.X + Form.ActiveForm.Size.Width, Form.ActiveForm.Location.Y + 65);
                }
                catch { }
            }
        }
        public static void Close()
        {
            if (SideForm != null)
            {
                SideForm.Hide();
                SideForm = null;
            }
        }


        public enum SideForms
        {
            [Description("VSTUP: soubor")]
            InputFile,
            [Description("VSTUP: číslo")]
            InputNumber,
            [Description("VSTUP: náhodné Číslo")]
            InputRandomNumber,
            [Description("VSTUP: text")]
            InputString
        }
        public static string GetDescription(this Enum currentEnum)
        {
            string description = String.Empty;
            DescriptionAttribute da;

            FieldInfo fi = currentEnum.GetType().
                        GetField(currentEnum.ToString());
            da = (DescriptionAttribute)Attribute.GetCustomAttribute(fi,
                        typeof(DescriptionAttribute));
            if (da != null)
                description = da.Value;
            else
                description = currentEnum.ToString();

            return description;
        }

    }

    public class DescriptionAttribute : System.Attribute
    {

        private string _value;

        public DescriptionAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

    }
}
