using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CAC
{
    public static class InputsOutputs
    {
        private static List<dynamic> InOutList = new List<dynamic>();

        private static ListBox InOutListBox = ((CaC) Application.OpenForms[0]).lbObjects;

        public static IEnumerable<dynamic> GetList()
        {
            return InOutList.AsReadOnly();
        }

        public static IEnumerable<dynamic> GetList(Type wantedType)
        {
            return InOutList.Where(item => item.GetType() == wantedType).ToList();
        }

        public static dynamic GetIOForm(int id)
        {
            return InOutList[id];
        }

        public static void Add(dynamic formIO)
        {
            InOutList.Add(formIO);
            InOutListBox.Items.Add(formIO.ToString());
        }

        public static void Remove(dynamic formIO)
        {
            InOutListBox.Items.RemoveAt(InOutList.IndexOf(formIO));
            InOutList.Remove(formIO);
        }

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

        public static void Clear()
        {
            InOutList.Clear();
            InOutListBox.Items.Clear();
        }

        public static void UpdateSelectedLbItem()
        {
            if (InOutListBox.SelectedItem == null) return;

            int selectedindex = InOutListBox.SelectedIndex;
            InOutListBox.SelectedItem = null;
            InOutListBox.Items[selectedindex] = InOutList[selectedindex].ToString();
        }
    }
}