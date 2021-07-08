using Bogus;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Practices.Collections
{
    public static class ItemFactory
    {
        public static Item CreateItem() => GetFaker.Generate();

        public static List<Item> CreateListItems(int count) => GetFaker.Generate(count);
        
        public static Item[] CreateArrayItems(int count) => GetFaker.Generate(count).ToArray();

        public static ImmutableArray<Item> CreateImmutableArrayItems(int count)
        { 
            var array = GetFaker.Generate(count).ToArray();

            var builder =  ImmutableArray.CreateBuilder<Item>(count);

            builder.AddRange(array);

            return builder.ToImmutable();
        }
        
        public static SortedList<int, Item> CreateSortedListItems(int count) =>
            new SortedList<int, Item>(CreateDictionaryItems(count));
        
        public static SortedDictionary<int, Item> CreateSortedDictionaryItems(int count) => 
            new SortedDictionary<int, Item>(CreateDictionaryItems(count));
        
        public static Dictionary<int, Item> CreateDictionaryItems(int count)
        {
            var list = GetFaker.Generate(count);
            var result = new Dictionary<int, Item>();

            for (var i = 0; i < count; i++)
            {
                result.TryAdd(i, list[i]);
            }

            return result;
        }
        
        private static Faker<Item> GetFaker => new Faker<Item>()
                            .RuleFor(item => item.DateEntry, f => f.Date.Past())
                            .RuleFor(item => item.Description, f => f.Company.CompanyName())
                            .RuleFor(item => item.Price, f => f.Random.Decimal());
    }
}
