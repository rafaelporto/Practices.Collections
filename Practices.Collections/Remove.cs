using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Practices.Collections
{
    [RankColumn]
    [MemoryDiagnoser]
    [ThreadingDiagnoser]
    [SimpleJob(targetCount: 1)]
    public class Remove
    {
        private List<Item> _list;
        private Item[] _array;
        private Dictionary<int, Item> _dictionary;
        private SortedDictionary<int, Item> _sortedDictionary;
        private SortedList<int, Item> _sortedList;
        private int _index;
        private ImmutableArray<Item> _immutableArray;

        public Remove()
        {
            int count = 100_000;
            _list = ItemFactory.CreateListItems(count);
            _array = ItemFactory.CreateArrayItems(count);
            _dictionary = ItemFactory.CreateDictionaryItems(count);
            _sortedDictionary = ItemFactory.CreateSortedDictionaryItems(count);
            _sortedList = ItemFactory.CreateSortedListItems(count);
            _index = new Random().Next(0, count - 1);
            _immutableArray = ItemFactory.CreateImmutableArrayItems(count);
        }

        [Benchmark]
        public void RemoveItemToArray() => _array[_index] = null;

        [Benchmark]
        public void RemoveItemToImmutableArray() => _immutableArray.RemoveAt(_index);

        [Benchmark]
        public void RemoveItemToList()
        {
            if (_list.ElementAtOrDefault(_index) != null)
                _list.RemoveAt(_index);
        }


        [Benchmark]
        public void RemoveItemToSortedList()
        {
            if (_sortedList.ContainsKey(_index))
                _sortedList.Remove(_index);
        }

        [Benchmark]
        public void RemoveItemToDictionary()
        {
            if (_dictionary.ContainsKey(_index))
                _dictionary.Remove(_index);
        }

        [Benchmark]
        public void RemoveItemToSortedDictionary()
        {
            if (_sortedDictionary.ContainsKey(_index))
                _sortedDictionary.Remove(_index);
        }
    }
}
