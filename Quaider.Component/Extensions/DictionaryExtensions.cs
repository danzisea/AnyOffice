﻿using System.Collections.Generic;

namespace Quaider.Component.Extensions
{
    public static partial class Extensions
    {
        public static IDictionary<TKey, TValue> SetKeyValue<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue value)
        {
            source = source ?? new Dictionary<TKey, TValue>();
            if (source.ContainsKey(key))
                source[key] = value;
            else
                source.Add(key, value);

            return source;
        }
    }
}