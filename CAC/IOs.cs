﻿using System;
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
        }
        public static void Remove(dynamic IOForm)
        {
            IOForms.Remove(IOForm);
        }
        public static void Swap(int index1, int index2)
        {
            dynamic temp = IOForms[index1];
            IOForms[index1] = IOForms[index2];
            IOForms[index2] = temp;
        }
        public static void Clear()
        {
            IOForms.Clear();
        }
        public static void UpdateListBox()
        {
            CaC mainForm = (CaC)Application.OpenForms[0];
            mainForm.UpdateLbObjects();
        }


    }
}
