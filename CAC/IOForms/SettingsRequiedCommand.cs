using aGrader.Properties;

namespace aGrader.IOForms
{
    public partial class SettingsRequiedCommand : InputString
    {
        public SettingsRequiedCommand()
        {
            InitializeComponent();
        }

        public SettingsRequiedCommand(string command) : base(command)
        {
            
        }

        public override string ToString()
        {
            return string.Format(Resources.IOFDescription_RequiedCommand, tbString.Text);
        }
    }
}
