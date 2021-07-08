using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace Practices.Collections
{
    [RankColumn]
    [MemoryDiagnoser]
    [ThreadingDiagnoser]
    [SimpleJob(targetCount: 100)]
    public class Replace
    {
        private List<Item> _list;
        private Item[] _array;
        private Dictionary<int, Item> _dictionary;
        private SortedDictionary<int, Item> _sortedDictionary;
        private SortedList<int, Item> _sortedList;
        private int _index;
        private Item _item;

        public Replace()
        {
            int count = 100_000;
            _list = ItemFactory.CreateListItems(count);
            _array = ItemFactory.CreateArrayItems(count);
            _dictionary = ItemFactory.CreateDictionaryItems(count);
            _sortedDictionary = ItemFactory.CreateSortedDictionaryItems(count);
            _sortedList = ItemFactory.CreateSortedListItems(count);
            _item = ItemFactory.CreateItem();
            _index = new Random().Next(0, count - 1);
        }

        [Benchmark]
        public void ReplaceItemToArray() => _array[_index] = _item;

        [Benchmark]
        public void ReplaceItemToList() => _list[_index] = _item;

        [Benchmark]
        public void ReplaceItemToSortedList() => _sortedList[_index] = _item;

        [Benchmark]
        public void ReplaceItemToDictionary() => _dictionary[_index] = _item;

        [Benchmark]
        public void ReplaceItemToSortedDictionary() => _sortedDictionary[_index] = _item;
    }
}
