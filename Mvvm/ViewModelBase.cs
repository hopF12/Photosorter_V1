using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Mvvm
{
    /// <inheritdoc />
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <inheritdoc />
    public class ViewModelBase<TModel> : ViewModelBase
    {
        private TModel _model;

        protected ViewModelBase()
        {
            _model = Activator.CreateInstance<TModel>();
        }

        private void SetModelValues(TModel value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            var properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            _model = value;

            foreach (var property in properties)
            {
                OnPropertyChanged(property.Name);
            }
        }

        public TModel Model
        {
            get => _model;
            set => SetModelValues(value);
        }
    }
}
