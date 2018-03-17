using System.Windows;
using System.Windows.Controls;
using BookStore.ViewModel;

namespace BookStore.View
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
            this.DataContext = new BookStore.ViewModel.MenuViewModel();
        }

        
    }
}
