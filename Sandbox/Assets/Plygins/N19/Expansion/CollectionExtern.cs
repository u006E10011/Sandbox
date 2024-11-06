using System;
using System.Collections.Generic;

namespace N19
{
    public static class CollectionExtern
    {
        public static T[] ForEach<T>(this T[] collection, Action<T> action)
        {
            foreach (var item in collection)
                action(item);

            return collection;
        }

        public static List<T> ForEach<T>(this List<T> collection, Action<T> action)
        {
            foreach (var item in collection)
                action(item);

            return collection;
        }

        #region Random
        public static T RandomItem<T>(this T[] collection)
        {
            var item = UnityEngine.Random.Range(0, collection.Length);
            return collection[item];
        }

        public static T RandomItem<T>(this List<T> collection)
        {
            var item = UnityEngine.Random.Range(0, collection.Count);
            return collection[item];
        }
        #endregion
    }
}
