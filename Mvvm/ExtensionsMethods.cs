using System;
using System.Collections.Generic;
using System.Linq;

namespace Mvvm
{
    public static class ExtensionsMethods
    {
        public static void Cast<TOld, TNew>(this IList<TOld> source, Func<TOld, TNew> factory) where TNew : TOld
        {
            for (var i = 0; i < source.Count(); i++)
                source[i] = factory(source[i]);
        }
    }
}