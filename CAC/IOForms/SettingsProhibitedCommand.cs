namespace aGrader.IOForms
{
    public partial class SettingsProhibitedCommand : InputString
    {
        public SettingsProhibitedCommand()
        {
            InitializeComponent();
        }

        public SettingsProhibitedCommand(string command) : base (command)
        {
            
        }

        public override string ToString()
        {
            return "Zakázaný příkaz " + tbString.Text;
        }
    }
}
