using System;
using System.Reflection;
using System.Windows.Forms;

namespace CAC
{
    public static class SideFormManager
    {
        private static dynamic _sideForm;

        public static void Show(SideForms formName)
        {
            Close();
            _sideForm = Activator.CreateInstance(Type.GetType("CAC.IO_Forms." + formName));
            UpdatePosition();
            _sideForm.Show();
        }

        public static void ShowExisting(dynamic formToShow)
        {
            Close();
            _sideForm = formToShow;
            UpdatePosition();
            _sideForm.Show();
        }

        public static void UpdatePosition()
        {
            if (_sideForm != null)
            {
                try
                {
                    _sideForm.SetDesktopLocation(Form.ActiveForm.Location.X + Form.ActiveForm.Size.Width,
                        Form.ActiveForm.Location.Y + 65);
                }
                catch
                {
                    // ignored
                }
            }
        }

        public static void Close()
        {
            if (_sideForm != null)
            {
                _sideForm.Hide();
                _sideForm = null;
            }
        }


        public enum SideForms
        {
            [Description("VSTUP: textový soubor")]
            InputTextFile,
            [Description("VSTUP: číslo")]
            InputNumber,
            [Description("VSTUP: náhodné Číslo")]
            InputRandomNumber,
            [Description("VSTUP: text")]
            InputString,
            [Description("VÝSTUP: náhodné číslo")]
            OutputNumberBasedOnRandomInput, //todo přepsat popisek
            [Description("VÝSTUP: číslo splňující podmínky")]
            OutputNumberMatchingConditions,
            [Description("VÝSTUP: číslo")]
            OutputNumber,
            [Description("VÝSTUP: text")]
            OutputString,
            [Description("NASTAVENÍ: odchylka")]
            SettingsDeviation,
            [Description("NASTAVENÍ: zakázaný příkaz")]
            SettingsProhibitedCommand,
            [Description("NASTAVENÍ: vyžadovaný příkaz")]
            SettingsRequiedCommand,
            [Description("AKCE: opakování poslední akce")]
            ActionRepeatLast
        }

        public static string GetDescription(this Enum currentEnum)
        {
            string description;
            DescriptionAttribute descriptionAttribute;

            FieldInfo fi = currentEnum.GetType().
                GetField(currentEnum.ToString());
            descriptionAttribute = (DescriptionAttribute) Attribute.GetCustomAttribute(fi,
                typeof (DescriptionAttribute));
            if (descriptionAttribute != null)
                description = descriptionAttribute.Value;
            else
                description = currentEnum.ToString();

            return description;
        }
    }

    public class DescriptionAttribute : Attribute
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