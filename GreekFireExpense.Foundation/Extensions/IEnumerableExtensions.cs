using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace GreekFire.Foundation.Extensions
{
    /// <summary>
    /// Adds extension methods to the IEnumerable&lt;T&gt; interface.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Performs an action on the specified collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="action">The action.</param>
        /// <remarks>
        /// <para>
        /// Use the ForEach method to perform an action on a collection
        /// of items, one at a time, as you would when using a foreach loop.
        /// </para>
        /// <para>
        /// <example>
        /// <code>
        /// IEnumerable collection = new string[] {"a", "b", "c"};
        /// collection.ForEach(Console.WriteLine);
        /// </code>
        /// produces the following output:
        /// <code>
        /// a
        /// b
        /// c
        /// </code>
        /// </example>
        /// </para>
        /// </remarks>
        public static void ForEach(this IEnumerable collection, Action<object> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }

        /// <summary>
        /// Performs an action on the specified collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="action">The action.</param>
        /// <remarks>
        /// <para>
        /// Use the ForEachWithIndex method to perform an action on a collection
        /// of items, one at a time, as you would when using a foreach loop.
        /// This method allows the action to consider an index, as well.
        /// </para>
        /// <para>
        /// <example>
        /// <code>
        /// IEnumerable collection = new string[] {"a", "b", "c"};
        /// collection.ForEachWithIndex(Console.WriteLine);
        /// </code>
        /// produces the following output:
        /// <code>
        /// a
        /// b
        /// c
        /// </code>
        /// </example>
        /// </para>
        /// </remarks>
        public static void ForEachWithIndex(this IEnumerable collection, Action<object, int> action)
        {
            int i = 0;

            foreach (var item in collection)
            {
                action(item, i++);
            }
        }

        /// <summary>
        /// Performs an action on the specified collection.
        /// </summary>
        /// <typeparam name="T">The type contained in the generic collection.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="action">The action.</param>
        /// <remarks>
        /// <para>
        /// Use the ForEach{T} method to perform an action on a collection
        /// of items, one at a time, as you would when using a foreach loop.
        /// </para>
        /// <para>
        /// <example>
        /// <code>
        /// IEnumerable{string} collection = new string[] {"a", "b", "c"};
        /// collection.ForEach(Console.WriteLine);
        /// </code>
        /// produces the following output:
        /// <code>
        /// a
        /// b
        /// c
        /// </code>
        /// </example>
        /// </para>
        /// </remarks>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            T[] items = collection.ToArray();
            int count = items.Count();

            for (int i = 0; i < count; i++)
            {
                if (items[i] == null)
                {
                    throw new NullReferenceException("The value of the item cannot be null.");
                }

                action(items[i]);
            }
        }

        /// <summary>
        /// Performs an action on the specified collection.
        /// </summary>
        /// <typeparam name="T">The type contained in the generic collection.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="action">The action.</param>
        /// <remarks>
        /// <para>
        /// Use the ForEachWithIndex{T} method to perform an action on a collection
        /// of items, one at a time, as you would when using a foreach loop.
        /// This method allows the action to consider an index, as well.
        /// </para>
        /// <para>
        /// <example>
        /// <code>
        /// IEnumerable{string} collection = new string[] {"a", "b", "c"};
        /// collection.ForEachWithIndex(Console.WriteLine);
        /// </code>
        /// produces the following output:
        /// <code>
        /// a
        /// b
        /// c
        /// </code>
        /// </example>
        /// </para>
        /// </remarks>
        public static void ForEachWithIndex<T>(this IEnumerable<T> collection, Action<T, int> action)
        {
            T[] items = collection.ToArray();
            int count = items.Count();

            for (int i = 0; i < count; i++)
            {
                action(items[i], i);
            }
        }
    }
}
