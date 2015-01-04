using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace CAC
{
    public static class IOs
    {
        private static List<dynamic> IOForms = new List<dynamic>();

        private static ListBox lbIOs = ((CaC)Application.OpenForms[1]).lbObjects;

        public static IReadOnlyCollection<dynamic> getList()
        {
            return IOForms.AsReadOnly();
        }
        public static dynamic getIOForm(int id)
        {
            return IOForms[id];
        }

        public static void Add(dynamic IOForm)
        {
            IOForms.Add(IOForm);
            lbIOs.Items.Add(IOForm.ToString());
            
        }
        public static void Remove(dynamic IOForm)
        {
            lbIOs.Items.RemoveAt(IOForms.IndexOf(IOForm));
            IOForms.Remove(IOForm);
        }
        public static void Swap(int index1, int index2)
        {
            dynamic temp = IOForms[index1];
            IOForms[index1] = IOForms[index2];
            IOForms[index2] = temp;

            temp=lbIOs.Items[index1];
            lbIOs.Items[index1]=lbIOs.Items[index2];
            lbIOs.Items[index2] = temp;
            lbIOs.SelectedIndex = index2;
        }
        public static void Clear()
        {
            IOForms.Clear();
            lbIOs.Items.Clear();
        }


    }
}
