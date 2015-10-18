namespace aGrader.IO_Forms
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
            return "Požadovaný příkaz " + tbString.Text;
        }
    }
}
