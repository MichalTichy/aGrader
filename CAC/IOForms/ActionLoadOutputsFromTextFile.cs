using aGrader.Properties;

namespace aGrader.IOForms
{
    public partial class ActionLoadOutputsFromTextFile : InputOutputForm
    {
        public ActionLoadOutputsFromTextFile()
        {
            InitializeComponent();
        }

        public override string ToString()
        {
            return Resources.IOFDescription_LoadOutputsFromFile;
        }
    }
}
