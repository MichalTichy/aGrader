using aGrader.Properties;

namespace aGrader.IOForms
{
    public partial class OutputNumber : InputNumber
    {
        public OutputNumber()
        {
            InitializeComponent();
        }

        public OutputNumber(decimal value) : base(value)
        {
        }

        public override string ToString()
        {
            return string.Format(Resources.IOFDescription_OutputNumber,Value);
        }
    }
}
