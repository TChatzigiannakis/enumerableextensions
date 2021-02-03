﻿/*
 * EnumerableExtensions
 * Copyright (C) 2014-2015  Theodoros Chatzigiannakis
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

namespace EnumerableExtensions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Extension methods supported by <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns the first element that matches the given predicate, preceded by its preceding element in the original sequence and followed by its following element.
        /// </summary>
        public static IEnumerable<T> Around<T>(
            this IEnumerable<T> sequence,
            Func<T, bool> predicate)
        {
            _ = sequence ?? throw new ArgumentNullException(nameof(sequence));
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

            var array = new T[3];

            using var iterator = sequence.GetEnumerator();
            while (iterator.MoveNext() && !predicate(iterator.Current))
                array[0] = iterator.Current;
            array[1] = iterator.Current;
            if (iterator.MoveNext())
                array[2] = iterator.Current;

            return array;
        }
    }
}
