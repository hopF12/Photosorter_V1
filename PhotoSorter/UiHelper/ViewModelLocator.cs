using System.ComponentModel;
using System.Windows;
using IContainer = Autofac.IContainer;

namespace PhotoSorter.UiHelper
{
    public class ViewModelLocator
    {
        private readonly IContainer _container;

        public ViewModelLocator() => _container = Bootstrapper.Instance.Container;

        // returns true if editing .xaml file in VS for example
        private static bool IsInDesignMode => DesignerProperties.GetIsInDesignMode(new DependencyObject());
    }
}