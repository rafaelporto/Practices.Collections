using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace Practices.Collections
{
    [RankColumn]
    [MemoryDiagnoser]
    [ThreadingDiagnoser]
    [SimpleJob(targetCount: 1)]
    public class Add
    {
        private List<Item> _list;
        private Item[] _array;
        private Dictionary<int, Item> _dictionary;
        private SortedDictionary<int, Item> _sortedDictionary;
        private SortedList<int, Item> _sortedList;
        private int _index;
        private Item _item;
        private int count = 100_000;


        public Add()
        {
            _list = new List<Item>(count);
            _array = new Item[count];
            _dictionary = new Dictionary<int, Item>();
            _sortedDictionary = new SortedDictionary<int, Item>();
            _sortedList = new SortedList<int, Item>();
            _item = ItemFactory.CreateItem();
            _index = new Random().Next(0, count - 1);
        }

        [Benchmark]
        public void AddItemToArray() => _array[_index] = _item;

        [Benchmark]
        public void AddItemToArrayUsingSetValue() => _array.SetValue(_item, _index);

        [Benchmark]
        public void AddItemToList() => _list.Add(_item);

        [Benchmark]
        public void AddItemToSortedList() => _sortedList.TryAdd(_index, _item);

        [Benchmark]
        public void AddItemToDictionary() => _dictionary.TryAdd(_index, _item);

        [Benchmark]
        public void AddItemToSortedDictionary() => _sortedDictionary.TryAdd(_index, _item);
    }
}
