#region

using System;
using System.Reflection;
using System.Windows.Forms;

#endregion

namespace aGrader
{
    public static class SideFormManager
    {
        public enum SideForms
        {
            [Description("VSTUP: textový soubor")] InputTextFile,
            [Description("VSTUP: číslo")] InputNumber,
            [Description("VSTUP: náhodné číslo")] InputRandomNumber,
            [Description("VSTUP: text")] InputString,
            [Description("VÝSTUP: číslo založené na vygenerovaném číslu")] OutputNumberBasedOnRandomInput,
            [Description("VÝSTUP: číslo splňující podmínky")] OutputNumberMatchingConditions,
            [Description("VÝSTUP: počet čísel splňujících podmínky")] OutputCountOfNumbersMatchingConditions,
            [Description("VÝSTUP: číslo")] OutputNumber,
            [Description("VÝSTUP: text")] OutputString,
            [Description("NASTAVENÍ: odchylka")] SettingsDeviation,
            [Description("NASTAVENÍ: zakázaný příkaz")] SettingsProhibitedCommand,
            [Description("NASTAVENÍ: vyžadovaný příkaz")] SettingsRequiedCommand,
            [Description("AKCE: opakování poslední akce")] ActionRepeatLast,
            [Description("AKCE: načti výstupy ze souboru")] ActionLoadOutputsFromTextFile,
            [Description("AKCE: porovnej soubory")] ActionCompareFiles
        }

        private static dynamic _sideForm;

        public static void Show(SideForms formName)
        {
            Close();
            _sideForm = Activator.CreateInstance(Type.GetType("aGrader.IO_Forms." + formName));
            UpdatePosition();
            _sideForm.Show();
        }

        public static void ShowExisting(dynamic formToShow)
        {
            Close();
            formToShow.Exists = true;
            _sideForm = formToShow;
            UpdatePosition();
            _sideForm.Show();
        }

        public static void UpdatePosition()
        {
            Form mainForm = Application.OpenForms["aGrader"];
            if (mainForm == null) return;
            if (_sideForm == null) return;
            _sideForm.SetDesktopLocation(mainForm.Location.X + mainForm.Size.Width,
                mainForm.Location.Y + 65);
        }

        public static void Close()
        {
            if (_sideForm == null) return;
            _sideForm.Hide();
            _sideForm = null;
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

        public static void Show(Form form)
        {
            Close();
            _sideForm = form;
            form.Show();
            UpdatePosition();
        }
    }

    public class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}