using System.Collections.Generic;
using System.Windows.Forms;

namespace CAC
{
    public static class IOs
    {
        private static List<dynamic> IOForms = new List<dynamic>();

        /// <summary>
        /// Contains reference to lbIOs which is at main form.
        /// </summary>
        private static ListBox lbIOs = ((CaC)Application.OpenForms[1]).lbObjects;

        public static IReadOnlyCollection<dynamic> getList()
        {
            return IOForms.AsReadOnly();
        }
        public static dynamic getIOForm(int id)
        {
            return IOForms[id];
        }

        /// <summary>
        /// Adds IO Form to list.
        /// </summary>
        /// <param name="IOForm"></param>
        public static void Add(dynamic IOForm)
        {
            IOForms.Add(IOForm);
            lbIOs.Items.Add(IOForm.ToString());

        }

        /// <summary>
        /// Removes IO Form to list.
        /// </summary>
        /// <param name="IOForm"></param>
        public static void Remove(dynamic IOForm)
        {
            lbIOs.Items.RemoveAt(IOForms.IndexOf(IOForm));
            IOForms.Remove(IOForm);
        }

        /// <summary>
        /// Swaps two items in list of IOs.
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        public static void Swap(int index1, int index2)
        {
            dynamic temp = IOForms[index1];
            IOForms[index1] = IOForms[index2];
            IOForms[index2] = temp;

            temp = lbIOs.Items[index1];
            lbIOs.Items[index1] = lbIOs.Items[index2];
            lbIOs.Items[index2] = temp;
            lbIOs.SelectedIndex = index2;
        }

        /// <summary>
        /// Deletes all IO Forms from list.
        /// </summary>
        public static void Clear()
        {
            IOForms.Clear();
            lbIOs.Items.Clear();
        }

        /// <summary>
        /// Updates selected item in lbIOs
        /// </summary>
        public static void UpdateSelectedLbItem()
        {
            int selectedindex = lbIOs.SelectedIndex;
            lbIOs.SelectedItem = null;
            lbIOs.Items[selectedindex] = IOForms[selectedindex].ToString();

        }
    }
}
