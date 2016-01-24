#region

using System;
using System.Reflection;
using System.Windows.Forms;
using aGrader.Properties;

#endregion

namespace aGrader
{
    public static class SideFormManager
    {
        public enum SideForms
        {
            [Description("InputTextFile")] InputTextFile,
            [Description("InputNumber")] InputNumber,
            [Description("InputRandomNumber")] InputRandomNumber,
            [Description("InputString")] InputString,
            [Description("OutputNumberBasedOnRandomInput")] OutputNumberBasedOnRandomInput,
            [Description("OutputNumberMatchingConditions")] OutputNumberMatchingConditions,
            [Description("OutputCountOfNumbersMatchingConditions")] OutputCountOfNumbersMatchingConditions,
            [Description("OutputNumber")] OutputNumber,
            [Description("OutputString")] OutputString,
            [Description("SettingsDeviation")] SettingsDeviation,
            [Description("SettingsTimeout")]SettingsTimeout,
            [Description("SettingsProhibitedCommand")] SettingsProhibitedCommand,
            [Description("SettingsRequiedCommand")] SettingsRequiedCommand,
            [Description("SettingsStartupArguments")] SettingsStartupArguments,
            [Description("ActionRepeatLast")] ActionRepeatLast,
            [Description("ActionLoadOutputsFromTextFile")] ActionLoadOutputsFromTextFile,
            [Description("ActionCompareFiles")] ActionCompareFiles
        }

        private static dynamic _sideForm;

        public static void Show(SideForms formName)
        {
            Close();
            _sideForm = Activator.CreateInstance(Type.GetType("aGrader.IOForms." + formName));
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
            Value = Resources.ResourceManager.GetString(value);
        }

        public string Value { get; private set; }
    }
}