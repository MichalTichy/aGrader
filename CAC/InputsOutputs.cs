using System;
using System.Collections.Generic;
using System.Linq;

namespace CAC
{

    public static class InputsOutputs
    {
        //todo refaktorovat
        public static event EventHandler<EventArgs> InOutListChanged;

        public static void OnInOutListChanged()
        {
            if (InOutListChanged != null)
                InOutListChanged(typeof (InputsOutputs),EventArgs.Empty);
        }

        private static List<dynamic> InOutList = new List<dynamic>();

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

        public static int GetIdOfForm(dynamic form)
        {
            return InOutList.IndexOf(form);
        }

        public static void Add(dynamic formIO)
        {
            InOutList.Add(formIO);
            OnInOutListChanged();
        }

        public static void Remove(dynamic formIO)
        {
            InOutList.Remove(formIO);
            OnInOutListChanged();
        }

        public static void Swap(int index1, int index2)
        {
            dynamic temp = InOutList[index1];
            InOutList[index1] = InOutList[index2];
            InOutList[index2] = temp;
        }

        public static void Clear()
        {
            InOutList.Clear();
            OnInOutListChanged();
        }
    }
}