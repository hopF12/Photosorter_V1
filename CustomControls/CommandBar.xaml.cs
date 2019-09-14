using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CustomControls
{
    /// <summary>
    /// Interaction logic for CommandBar.xaml
    /// </summary>
    public partial class CommandBar
    {
        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool),
            typeof(CommandBar), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty LeftSideContentProperty = DependencyProperty.Register("LeftSideContent", typeof(IEnumerable), typeof(CommandBar), new PropertyMetadata(default(IEnumerable)));

        public CommandBar()
        {
            InitializeComponent();

            Height += Convert.ToInt32(IsOpen) * 30;
        }

        public bool IsOpen
        {
            get => (bool)GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }

        public IEnumerable LeftSideContent
        {
            get { return (IEnumerable) GetValue(LeftSideContentProperty); }
            set { SetValue(LeftSideContentProperty, value); }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            IsOpen = !IsOpen;
            Height = IsOpen ? Height + 30 : Height - 30;
        }
    }
}
