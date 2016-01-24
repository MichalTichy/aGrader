using aGrader.Properties;

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
            return string.Format(Resources.IOFDescription_OutputString, Text);
        }
    }
}
