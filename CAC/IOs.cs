using System.Collections.Generic;
using System.Windows.Forms;

namespace CAC
{
    public static class InputsOutputs
    {
        private static readonly List<dynamic> InOutList=new List<dynamic>();

        /// <summary>
        /// Contains reference to lbIOs which is at main form.
        /// </summary>
        private static readonly ListBox InOutListBox = ((CaC)Application.OpenForms[1]).lbObjects;

        public static IEnumerable<dynamic> GetList()
        {
            return InOutList.AsReadOnly();
        }
        public static dynamic GetIOForm(int id)
        {
            return InOutList[id];
        }

        /// <summary>
        /// Adds IO Form to list.
        /// </summary>
        /// <param name="formIO"></param>
        public static void Add(dynamic formIO)
        {
            InOutList.Add(formIO);
            InOutListBox.Items.Add(formIO.ToString());

        }

        /// <summary>
        /// Removes IO Form to list.
        /// </summary>
        /// <param name="formIO"></param>
        public static void Remove(dynamic formIO)
        {
            InOutListBox.Items.RemoveAt(InOutList.IndexOf(formIO));
            InOutList.Remove(formIO);
        }

        /// <summary>
        /// Swaps two items in list of IOs.
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        public static void Swap(int index1, int index2)
        {
            dynamic temp = InOutList[index1];
            InOutList[index1] = InOutList[index2];
            InOutList[index2] = temp;

            temp = InOutListBox.Items[index1];
            InOutListBox.Items[index1] = InOutListBox.Items[index2];
            InOutListBox.Items[index2] = temp;
            InOutListBox.SelectedIndex = index2;
        }

        /// <summary>
        /// Deletes all IO Forms from list.
        /// </summary>
        public static void Clear()
        {
            InOutList.Clear();
            InOutListBox.Items.Clear();
        }

        /// <summary>
        /// Updates selected item in lbIOs
        /// </summary>
        public static void UpdateSelectedLbItem()
        {
            int selectedindex = InOutListBox.SelectedIndex;
            InOutListBox.SelectedItem = null;
            InOutListBox.Items[selectedindex] = InOutList[selectedindex].ToString();

        }
    }
}
