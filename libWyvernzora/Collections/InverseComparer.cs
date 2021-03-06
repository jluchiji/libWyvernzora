﻿// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// libWyvernzora/InverseComparer.cs
// --------------------------------------------------------------------------------
// Copyright (c) 2013, Jieni Luchijinzhou a.k.a Aragorn Wyvernzora
// 
// This file is a part of libWyvernzora.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy 
// of this software and associated documentation files (the "Software"), to deal 
// in the Software without restriction, including without limitation the rights 
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies 
// of the Software, and to permit persons to whom the Software is furnished to do 
// so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all 
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
// PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION 
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

using System;
using System.Collections.Generic;

namespace libWyvernzora.Collections
{
    /// <summary>
    ///     Comparer wrapper that inverts compare results.
    /// </summary>
    /// <typeparam name="T">Type of compared items.</typeparam>
    public class InverseComparer<T> : IComparer<T>
    {
        /// <summary>
        ///     Constructor.
        ///     Initializes a new instance.
        /// </summary>
        /// <param name="comparer">Comparer to </param>
        public InverseComparer(IComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException("comparer");
            OriginalComparer = comparer;
        }

        /// <summary>
        ///     Gets the original comparer wrapped into this InverseComparer.
        /// </summary>
        public IComparer<T> OriginalComparer { get; private set; }

        #region IComparer<T> Members

        public int Compare(T x, T y)
        {
            return -OriginalComparer.Compare(x, y);
        }

        #endregion
    }

    /// <summary>
    /// Static class for IComparer.Invert method.
    /// </summary>
    public static class ComparerInverter
    {
        /// <summary>
        /// Inverts the IComparer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="original"></param>
        /// <returns></returns>
        public static IComparer<T> Invert<T>(this IComparer<T> original)
        {
            InverseComparer<T> inverse = original as InverseComparer<T>;
            return inverse == null ? new InverseComparer<T>(original) : inverse.OriginalComparer;
        }
    }
}