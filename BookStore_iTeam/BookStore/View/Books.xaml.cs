using System;
using System.Windows.Controls;
using BookStore.ViewModel;
using BookStore.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace BookStore.View
{
    /// <summary>
    /// Interaction logic for Books.xaml
    /// </summary>
    public partial class Books : UserControl
    {
        public Books()
        {
            InitializeComponent();
            this.DataContext = new BookStore.ViewModel.BooksViewModel();
            int i=win.Children.Count;
        }
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
    }
}
