﻿#region

using System;
using System.Collections.Generic;
using System.Linq;

namespace aGrader
{

    #endregion

    public static class InputsOutputs
    {
        private static List<dynamic> _inOutList = new List<dynamic>();
        public static event EventHandler<EventArgs> InOutListChanged;

        public static void OnInOutListChanged()
        {
            InOutListChanged?.Invoke(typeof (InputsOutputs), EventArgs.Empty);
        }

        public static void Swap(int index1, int index2)
        {
            dynamic temp = _inOutList[index1];
            _inOutList[index1] = _inOutList[index2];
            _inOutList[index2] = temp;
        }

        #region default list operations

        public static void Add(dynamic formIO)
        {
            _inOutList.Add(formIO);
            OnInOutListChanged();
        }

        public static void Remove(dynamic formIO)
        {
            _inOutList.Remove(formIO);
            OnInOutListChanged();
        }

        public static void Clear()
        {
            _inOutList.Clear();
            OnInOutListChanged();
        }

        #endregion

        #region getting list or its members

        public static IEnumerable<dynamic> GetList()
        {
            return _inOutList.AsReadOnly();
        }

        public static IEnumerable<dynamic> GetList(Type wantedType, int maxIndex=-1)
        {
            var itemWithinRequestedIndexRange= maxIndex == -1 ? _inOutList : _inOutList.Take(maxIndex);
            return itemWithinRequestedIndexRange.Where(item => item.GetType() == wantedType);
        }

        public static IEnumerable<dynamic> GetInputsList(FormType type, int maxIndex = -1)
        {
            var inputsOutputs = maxIndex == -1 ? _inOutList : _inOutList.Take(maxIndex - 1);
            var inputsOutputsMatchingSearch =
                inputsOutputs.Where(t => t.GetType().ToString().Contains(type.ToString()))
                    .Where(t => t.GetType().ToString().StartsWith("aGrader.IOForms.Input"));
            return inputsOutputsMatchingSearch;
        }
        public static IEnumerable<dynamic> GetOutputsList(FormType type, int maxIndex = -1)
        {
            var inputsOutputs = maxIndex == -1 ? _inOutList : _inOutList.Take(maxIndex - 1);
            var inputsOutputsMatchingSearch =
                inputsOutputs.Where(t => t.GetType().ToString().Contains(type.ToString()))
                    .Where(t => t.GetType().ToString().StartsWith("aGrader.IOForms.Output"));
            return inputsOutputsMatchingSearch;
        }

        public static dynamic GetIOForm(int id)
        {
            return _inOutList[id];
        }

        public static int GetIdOfForm(dynamic form)
        {
            return _inOutList.IndexOf(form);
        }

        #endregion
    }

    public enum FormType
    {
        Number,
        String
    }
}