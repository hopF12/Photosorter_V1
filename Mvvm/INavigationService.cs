using System;

namespace Mvvm
{
    public interface INavigationService
    {
        void NavigateTo(string viewType);

        void NavigateTo<TViewModel>(string pageKey, TViewModel viewModel) where TViewModel : ViewModelBase;

        void NavigateBack();

        void Register(string key, Type page);
    }
}