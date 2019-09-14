using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Mvvm.Implementations
{
    public class AdvancedObservableCollection<T> : ObservableCollection<T>, IObservableCollection<T>
    {
        private bool _suppressNotification;

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!_suppressNotification)
                base.OnCollectionChanged(e);
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            _suppressNotification = true;

            foreach (var item in collection)
                Add(item);

            _suppressNotification = false;

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public void Remove(Func<T, bool> func)
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (!func(Items[i])) continue;

                Items.RemoveAt(i);
                i--;
            }

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public void SortBy<TKey>(Func<T, TKey> keySelector, bool @descending = false)
        {
            var ordered = (@descending ? Items.OrderBy(keySelector) : Items.OrderByDescending(keySelector)).ToList();
            Items.Clear();
            AddRange(ordered);
        }
    }
}