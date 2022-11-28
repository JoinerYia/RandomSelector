﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomSelector
{
    public class RandomSelectorModel
    {
        private List<string> _list;
        readonly Random _random = new Random();

        public RandomSelectorModel()
        {
            ClearList();
        }

        public void ClearList()
        {
            _list = new List<string>();
        }

        public void AddItem(string item)
        {
            _list.Add(item);
        }

        public void RemoveItem(int index)
        {
            _list.RemoveAt(index);
        }

        public void RemoveItem(string item)
        {
            _list.Remove(item);
        }

        public List<string> GetList()
        {
            return _list;
        }
        public string SelectItem()
        {
            int numberOfItem = _list.Count();
            if (numberOfItem == 0)
                return null;
            int n = _random.Next(numberOfItem);
            return _list[n];
        }

    }
}
