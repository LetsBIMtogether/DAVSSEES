// U2.cs

using System.Collections.Generic;

namespace AG
{
    /// <summary>
    /// General Utilities by others.
    /// </summary>
    public class U2
    {
        /// From:
        /// https://github.com/geewiz/geewiz

        /// <summary>
        /// A class for holding a key value pair.
        /// </summary>
        /// <typeparam name="T">The type of object being stored.</typeparam>
        public class KeyedValue<T>
        {
            // These properties relate to the item
            public T ItemValue { get; set; }
            public string ItemKey { get; set; }
            public int ItemIndex { get; set; }

            // Form behavior
            public bool Checked { get; set; }
            public bool Visible { get; set; }

            /// <summary>
            /// Default constructor
            /// </summary>
            public KeyedValue()
            {
                this.ItemValue = default;
                this.ItemKey = null;
                this.ItemIndex = -1;
                this.Visible = true;
                this.Checked = false;
            }

            /// <summary>
            /// Construct using required data.
            /// </summary>
            /// <param name="itemValue">The object to store.</param>
            /// <param name="itemKey">The key for the item.</param>
            public KeyedValue(T itemValue, string itemKey)
            {
                this.ItemValue = itemValue;
                this.ItemKey = itemKey;
                this.ItemIndex = -1;
                this.Visible = true;
                this.Checked = false;
            }

            /// <summary>
            /// Construct using required data.
            /// </summary>
            /// <param name="itemValue">The object to store.</param>
            /// <param name="itemKey">The key for the item.</param>
            /// <param name="itemIndex">The index to store the item at.</param>
            public KeyedValue(T itemValue, string itemKey, int itemIndex)
            {
                this.ItemValue = itemValue;
                this.ItemKey = itemKey;
                this.ItemIndex = itemIndex;
                this.Visible = true;
                this.Checked = false;
            }
        }

        /// <summary>
        /// Combines keys and values into FormPairs.
        /// </summary>
        /// <typeparam name="T">The type of object being stored.</typeparam>
        /// <param name="values">Objects to add to the FormPair.</param>
        /// <param name="keys">The keys to connect to the FormPair.</param>
        /// <returns>A list of FormPairs.</returns>
        public static List<KeyedValue<T>> CombineAsFormPairs<T>(List<string> keys, List<T> values)
        {
            // Get the shortest count
            var pairCount = keys.Count > values.Count ? values.Count : keys.Count;

            // Empty list of form pairs
            var formPairs = new List<KeyedValue<T>>();

            // Return the list if one list was empty
            if (pairCount == 0) { return formPairs; }

            // Construct the form pairs with indices
            for (int i = 0; i < pairCount; i++)
            {
                formPairs.Add(new KeyedValue<T>(values[i], keys[i], i));
            }

            // Return the formpairs
            return formPairs;
        }

    }
}
