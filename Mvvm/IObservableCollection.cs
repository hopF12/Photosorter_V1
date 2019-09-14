using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Mvvm
{
    public interface IObservableCollection<T> : INotifyCollectionChanged, INotifyPropertyChanged, IList<T>
    {
        void AddRange(IEnumerable<T> collection);

        void Remove(Func<T, bool> func);

        void SortBy<TKey>(Func<T, TKey> keySelector, bool @descending = false);
    }
}