using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAC
{
    public static class IOs
    {
        private static List<dynamic> IOForms = new List<dynamic>();

        public static List<dynamic> getList()
        {
            return IOForms;
        }

        public static void Add(dynamic IOForm)
        {
            if (SideFormManager.IsValidDataType(IOForm.GetType()))
                IOForms.Add(IOForm);
        }

        public static void Import()
        {
            throw new System.NotImplementedException();
        }

        public static void Export()
        {
            throw new System.NotImplementedException();
        }

    }
}
