﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HashTableDemo
{
    public class MyMapNode<k, v>
    {
        private readonly int size;
        private readonly LinkedList<KeyValuePair<k, v>>[] items;


        public struct KeyValuePair<k, v>
        {
            public k key { get; set; }
            public v value { get; set; }
        }
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValuePair<k, v>>[size];
        }

        protected int GetArrayPosition(k key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        public v Get(k key) 
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<k, v>> linkedList = GetLinkedList(position);
            foreach(KeyValuePair<k,v> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(v);

        }
        public void Add(k key, v value) 
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<k, v>> linkedList = GetLinkedList(position);
            KeyValuePair<k, v> item = new KeyValuePair<k, v>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }

        public void Remove(k key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<k, v>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValuePair<k,v> foundItem = default(KeyValuePair<k,v>);
            foreach(KeyValuePair<k,v> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }
    }
}
