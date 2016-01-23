namespace aGrader.IOForms
{
    public partial class OutputString : InputString
    {
        public OutputString()
        {
            InitializeComponent();
        }

        public OutputString(string text) : base(text)
        {
            
        }

        public override string ToString()
        {
            return "VÝSTUP: text: \"" + Text + "\"";
        }
    }
}
